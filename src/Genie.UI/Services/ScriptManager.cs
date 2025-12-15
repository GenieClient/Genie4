using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using GenieClient.Genie;
using GenieClient.Services;

namespace GenieClient.UI.Services;

/// <summary>
/// Information about a running script for the UI.
/// </summary>
public class ScriptInfo
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public string FileName { get; set; } = "";
    public string DisplayName => Path.GetFileNameWithoutExtension(FileName);
    public bool IsPaused { get; set; }
    public bool IsRunning { get; set; } = true;
    public int DebugLevel { get; set; }
    public DateTime StartTime { get; } = DateTime.Now;
    
    // Reference to the actual script (internal use)
    internal Script? ScriptInstance { get; set; }
}

/// <summary>
/// Manages scripts for the Avalonia UI.
/// Provides a clean interface between the core Script system and the UI.
/// </summary>
public class ScriptManager : IDisposable
{
    private readonly List<ScriptInfo> _runningScripts = new();
    private readonly ReaderWriterLockSlim _lock = new(LockRecursionPolicy.SupportsRecursion);
    private readonly Timer _tickTimer;
    private Globals? _globals;
    private bool _disposed;

    /// <summary>
    /// Gets an observable collection of running scripts for UI binding.
    /// </summary>
    public ObservableCollection<ScriptInfo> RunningScripts { get; } = new();

    /// <summary>
    /// Raised when a script starts.
    /// </summary>
    public event Action<ScriptInfo>? ScriptStarted;

    /// <summary>
    /// Raised when a script stops.
    /// </summary>
    public event Action<ScriptInfo>? ScriptStopped;

    /// <summary>
    /// Raised when a script is paused or resumed.
    /// </summary>
    public event Action<ScriptInfo>? ScriptPauseStateChanged;

    /// <summary>
    /// Raised when script output should be displayed.
    /// </summary>
    public event Action<string, bool>? ScriptOutput; // (message, isError)

    /// <summary>
    /// Raised when a script wants to send a command to the game.
    /// </summary>
    public event Action<string, bool>? SendCommand; // (command, toQueue)

    /// <summary>
    /// Raised when the script list changes.
    /// </summary>
    public event Action? ScriptListChanged;

    public ScriptManager()
    {
        // Timer to tick scripts and clean up finished ones
        _tickTimer = new Timer(OnTick, null, 100, 100);
    }

    /// <summary>
    /// Sets the Globals instance (called when game is initialized).
    /// </summary>
    public void SetGlobals(Globals globals)
    {
        _globals = globals;
    }

    /// <summary>
    /// Gets the script directory from config.
    /// </summary>
    public string GetScriptDirectory()
    {
        if (_globals?.Config?.ScriptDir != null)
        {
            return _globals.Config.ScriptDir;
        }
        
        // Default fallback
        return Path.Combine(LocalDirectory.Path, "Scripts");
    }

    /// <summary>
    /// Gets the default script file extension.
    /// </summary>
    public string GetScriptExtension()
    {
        return _globals?.Config?.ScriptExtension ?? "cmd";
    }

    /// <summary>
    /// Runs a script by name.
    /// </summary>
    /// <param name="scriptPath">Script name or path (relative to script dir)</param>
    /// <param name="arguments">Optional arguments</param>
    /// <returns>The script info if started successfully, null otherwise</returns>
    public ScriptInfo? RunScript(string scriptPath, string? arguments = null)
    {
        if (_globals == null)
        {
            ScriptOutput?.Invoke("Cannot run script: Game not initialized.", true);
            return null;
        }

        try
        {
            // Normalize the script path
            var scriptName = scriptPath.TrimStart('.', ' ');
            if (!Path.HasExtension(scriptName))
            {
                scriptName += $".{GetScriptExtension()}";
            }

            var scriptDir = GetScriptDirectory();
            if (!scriptDir.EndsWith(Path.DirectorySeparatorChar))
            {
                scriptDir += Path.DirectorySeparatorChar;
            }

            var fullPath = Path.Combine(scriptDir, scriptName);
            
            if (!File.Exists(fullPath))
            {
                ScriptOutput?.Invoke($"Script not found: {scriptName}", true);
                return null;
            }

            // Check for duplicate script (abort if configured)
            if (_globals.Config.bAbortDupeScript)
            {
                AbortScript(scriptName);
            }

            // Parse arguments
            var argList = new System.Collections.ArrayList();
            argList.Add(scriptPath);
            if (!string.IsNullOrEmpty(arguments))
            {
                foreach (var arg in Utility.ParseArgs(arguments))
                {
                    argList.Add(arg);
                }
            }

            // Create the script
            var script = new Script(_globals);
            
            // Subscribe to script events
            script.EventPrintText += OnScriptPrintText;
            script.EventPrintError += OnScriptPrintError;
            script.EventSendText += OnScriptSendText;
            script.EventStatusChanged += OnScriptStatusChanged;

            // Load and run
            if (!script.LoadFile(fullPath, argList))
            {
                ScriptOutput?.Invoke($"Failed to load script: {scriptName}", true);
                return null;
            }

            // Create script info
            var info = new ScriptInfo
            {
                FileName = scriptName,
                ScriptInstance = script
            };

            // Add to running list
            _lock.EnterWriteLock();
            try
            {
                _runningScripts.Add(info);
            }
            finally
            {
                _lock.ExitWriteLock();
            }

            // Start the script
            script.RunScript();

            // Notify UI
            ScriptStarted?.Invoke(info);
            UpdateObservableCollection();
            
            ScriptOutput?.Invoke($"[Script started: {info.DisplayName}]", false);

            return info;
        }
        catch (Exception ex)
        {
            ScriptOutput?.Invoke($"Error starting script: {ex.Message}", true);
            return null;
        }
    }

    /// <summary>
    /// Aborts a script by name.
    /// </summary>
    public void AbortScript(string? scriptName = null)
    {
        _lock.EnterReadLock();
        try
        {
            var toAbort = string.IsNullOrEmpty(scriptName)
                ? _runningScripts.ToList()
                : _runningScripts.Where(s => 
                    s.FileName.Equals(scriptName, StringComparison.OrdinalIgnoreCase) ||
                    s.DisplayName.Equals(scriptName, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var info in toAbort)
            {
                info.ScriptInstance?.AbortScript();
                ScriptOutput?.Invoke($"[Script aborted: {info.DisplayName}]", false);
            }
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    /// <summary>
    /// Aborts a script by its info.
    /// </summary>
    public void AbortScript(ScriptInfo info)
    {
        info.ScriptInstance?.AbortScript();
        ScriptOutput?.Invoke($"[Script aborted: {info.DisplayName}]", false);
    }

    /// <summary>
    /// Pauses a script.
    /// </summary>
    public void PauseScript(ScriptInfo info)
    {
        if (info.ScriptInstance != null && !info.IsPaused)
        {
            info.ScriptInstance.PauseScript();
            info.IsPaused = true;
            ScriptPauseStateChanged?.Invoke(info);
            ScriptOutput?.Invoke($"[Script paused: {info.DisplayName}]", false);
            UpdateObservableCollection();
        }
    }

    /// <summary>
    /// Pauses a script by name.
    /// </summary>
    public void PauseScript(string? scriptName = null)
    {
        _lock.EnterReadLock();
        try
        {
            var toPause = string.IsNullOrEmpty(scriptName)
                ? _runningScripts.ToList()
                : _runningScripts.Where(s => 
                    s.FileName.Equals(scriptName, StringComparison.OrdinalIgnoreCase) ||
                    s.DisplayName.Equals(scriptName, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var info in toPause)
            {
                PauseScript(info);
            }
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    /// <summary>
    /// Resumes a paused script.
    /// </summary>
    public void ResumeScript(ScriptInfo info)
    {
        if (info.ScriptInstance != null && info.IsPaused)
        {
            info.ScriptInstance.ResumeScript();
            info.IsPaused = false;
            ScriptPauseStateChanged?.Invoke(info);
            ScriptOutput?.Invoke($"[Script resumed: {info.DisplayName}]", false);
            UpdateObservableCollection();
        }
    }

    /// <summary>
    /// Resumes a script by name.
    /// </summary>
    public void ResumeScript(string? scriptName = null)
    {
        _lock.EnterReadLock();
        try
        {
            var toResume = string.IsNullOrEmpty(scriptName)
                ? _runningScripts.Where(s => s.IsPaused).ToList()
                : _runningScripts.Where(s => 
                    (s.FileName.Equals(scriptName, StringComparison.OrdinalIgnoreCase) ||
                     s.DisplayName.Equals(scriptName, StringComparison.OrdinalIgnoreCase)) && s.IsPaused).ToList();

            foreach (var info in toResume)
            {
                ResumeScript(info);
            }
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    /// <summary>
    /// Toggles pause/resume for a script.
    /// </summary>
    public void TogglePauseScript(ScriptInfo info)
    {
        if (info.IsPaused)
            ResumeScript(info);
        else
            PauseScript(info);
    }

    /// <summary>
    /// Sets the debug level for a script.
    /// </summary>
    public void SetDebugLevel(ScriptInfo info, int level)
    {
        if (info.ScriptInstance != null)
        {
            info.ScriptInstance.DebugLevel = level;
            info.DebugLevel = level;
            ScriptOutput?.Invoke($"[Script debug level set to {level}: {info.DisplayName}]", false);
            UpdateObservableCollection();
        }
    }

    /// <summary>
    /// Passes game text to all running scripts for trigger processing.
    /// </summary>
    public void TriggerParse(string text, bool bufferWait = false)
    {
        _lock.EnterReadLock();
        try
        {
            foreach (var info in _runningScripts)
            {
                info.ScriptInstance?.TriggerParse(text, bufferWait);
            }
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    /// <summary>
    /// Gets the list of currently running scripts.
    /// </summary>
    public IReadOnlyList<ScriptInfo> GetRunningScripts()
    {
        _lock.EnterReadLock();
        try
        {
            return _runningScripts.Where(s => s.IsRunning).ToList();
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    /// <summary>
    /// Gets a comma-separated list of running script names.
    /// </summary>
    public string GetRunningScriptNames()
    {
        _lock.EnterReadLock();
        try
        {
            return string.Join(", ", _runningScripts
                .Where(s => s.IsRunning)
                .Select(s => s.DisplayName));
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    /// <summary>
    /// Gets a list of scripts in the script directory.
    /// </summary>
    public List<string> GetAvailableScripts(string? subdirectory = null)
    {
        var scriptDir = GetScriptDirectory();
        if (!string.IsNullOrEmpty(subdirectory))
        {
            scriptDir = Path.Combine(scriptDir, subdirectory);
        }

        if (!Directory.Exists(scriptDir))
        {
            return new List<string>();
        }

        var extension = GetScriptExtension();
        return Directory.GetFiles(scriptDir, $"*.{extension}", SearchOption.TopDirectoryOnly)
            .Select(Path.GetFileName)
            .Where(f => f != null)
            .Cast<string>()
            .OrderBy(f => f)
            .ToList();
    }

    /// <summary>
    /// Gets subdirectories in the script directory.
    /// </summary>
    public List<string> GetScriptDirectories(string? subdirectory = null)
    {
        var scriptDir = GetScriptDirectory();
        if (!string.IsNullOrEmpty(subdirectory))
        {
            scriptDir = Path.Combine(scriptDir, subdirectory);
        }

        if (!Directory.Exists(scriptDir))
        {
            return new List<string>();
        }

        return Directory.GetDirectories(scriptDir)
            .Select(Path.GetFileName)
            .Where(d => d != null)
            .Cast<string>()
            .OrderBy(d => d)
            .ToList();
    }

    private void OnTick(object? state)
    {
        if (_disposed) return;

        _lock.EnterUpgradeableReadLock();
        try
        {
            // Tick all scripts
            foreach (var info in _runningScripts)
            {
                info.ScriptInstance?.TickScript();
            }

            // Find finished scripts
            var finished = _runningScripts
                .Where(s => s.ScriptInstance?.ScriptDone == true)
                .ToList();

            if (finished.Count > 0)
            {
                _lock.EnterWriteLock();
                try
                {
                    foreach (var info in finished)
                    {
                        info.IsRunning = false;
                        _runningScripts.Remove(info);
                        
                        // Unsubscribe from events
                        if (info.ScriptInstance != null)
                        {
                            info.ScriptInstance.EventPrintText -= OnScriptPrintText;
                            info.ScriptInstance.EventPrintError -= OnScriptPrintError;
                            info.ScriptInstance.EventSendText -= OnScriptSendText;
                            info.ScriptInstance.EventStatusChanged -= OnScriptStatusChanged;
                        }
                        
                        ScriptStopped?.Invoke(info);
                        ScriptOutput?.Invoke($"[Script finished: {info.DisplayName}]", false);
                    }
                }
                finally
                {
                    _lock.ExitWriteLock();
                }

                UpdateObservableCollection();
            }
        }
        finally
        {
            _lock.ExitUpgradeableReadLock();
        }
    }

    private void OnScriptPrintText(string text, GenieColor color, GenieColor bgcolor)
    {
        ScriptOutput?.Invoke(text, false);
    }

    private void OnScriptPrintError(string text)
    {
        ScriptOutput?.Invoke(text, true);
    }

    private void OnScriptSendText(string text, string scriptName, bool toQueue, bool doCommand)
    {
        // This event fires when a script wants to send text to the game
        // Route to the SendCommand event for GameManager to handle
        SendCommand?.Invoke(text, toQueue);
    }

    private void OnScriptStatusChanged(Script sender, Script.ScriptState state)
    {
        // Find the script info for this script
        _lock.EnterReadLock();
        try
        {
            var info = _runningScripts.FirstOrDefault(s => s.ScriptInstance == sender);
            if (info != null)
            {
                info.IsPaused = state == Script.ScriptState.pausing;
                ScriptPauseStateChanged?.Invoke(info);
            }
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    private void UpdateObservableCollection()
    {
        // This should be called on UI thread
        RunningScripts.Clear();
        _lock.EnterReadLock();
        try
        {
            foreach (var info in _runningScripts.Where(s => s.IsRunning))
            {
                RunningScripts.Add(info);
            }
        }
        finally
        {
            _lock.ExitReadLock();
        }
        
        ScriptListChanged?.Invoke();
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        _tickTimer.Dispose();

        // Abort all running scripts
        _lock.EnterWriteLock();
        try
        {
            foreach (var info in _runningScripts)
            {
                info.ScriptInstance?.AbortScript();
            }
            _runningScripts.Clear();
        }
        finally
        {
            _lock.ExitWriteLock();
        }

        _lock.Dispose();
    }
}

