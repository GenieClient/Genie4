using System;
using System.Threading;
using System.Threading.Tasks;
using GenieClient.Genie;
using GenieClient.Services;

namespace GenieClient.UI.Services;

/// <summary>
/// Manages the connection to the game server and bridges Genie.Core to the Avalonia UI.
/// </summary>
public class GameManager : IDisposable
{
    private Globals? _globals;
    private Game? _game;
    private bool _disposed;
    private bool _initialized;

    // Roundtime countdown
    private Timer? _roundtimeTimer;
    private int _currentRoundtime;
    private int _maxRoundtime;
    
    // Window manager for multi-window support
    private GameWindowManager? _windowManager;
    public GameWindowManager? WindowManager => _windowManager;

    /// <summary>
    /// Event for text received with window targeting.
    /// </summary>
    public event Action<GameWindowType, string, string, GenieColor, GenieColor>? WindowTextReceived;
    public event Action<string>? ErrorReceived;
    public event Action? Connected;
    public event Action? Disconnected;
    public event Action<string, string>? VariableChanged;
    public event Action<int, int, int, int, int>? VitalsChanged;
    public event Action<int>? RoundtimeChanged;
    public event Action<bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool>? CompassChanged;
    public event Action<string, string>? HandsChanged; // left, right
    public event Action<string>? SpellChanged;
    public event Action<string, bool, bool, bool, bool, bool, bool, bool>? StatusChanged; // position, hidden, invisible, joined, webbed, stunned, bleeding, dead

    public bool IsConnected => _game?.IsConnected ?? false;
    public string? LastError { get; private set; }
    
    /// <summary>
    /// Gets the Globals instance for accessing highlights, presets, and other configuration.
    /// Returns null if not initialized.
    /// </summary>
    public Globals? Globals => _globals;

    public GameManager()
    {
        // Defer initialization to avoid constructor crashes
        _roundtimeTimer = new Timer(OnRoundtimeTick, null, Timeout.Infinite, Timeout.Infinite);
    }

    private void OnRoundtimeTick(object? state)
    {
        if (_currentRoundtime > 0)
        {
            _currentRoundtime--;
            RoundtimeChanged?.Invoke(_currentRoundtime);
            
            if (_currentRoundtime <= 0)
            {
                // Stop the timer when RT reaches 0
                _roundtimeTimer?.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
    }

    private void SetRoundtime(int seconds)
    {
        _currentRoundtime = seconds;
        _maxRoundtime = seconds;
        
        // Fire initial event
        RoundtimeChanged?.Invoke(_currentRoundtime);
        
        if (seconds > 0)
        {
            // Start countdown timer (1 second interval)
            _roundtimeTimer?.Change(1000, 1000);
        }
        else
        {
            // Stop timer
            _roundtimeTimer?.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }

    private bool Initialize()
    {
        if (_initialized) return _game != null;
        _initialized = true;

        try
        {
            Console.WriteLine("[GameManager] Initializing Globals...");
            _globals = new Globals();
            
            Console.WriteLine("[GameManager] Creating Game instance...");
            _game = new Game(ref _globals);
            
            Console.WriteLine("[GameManager] Creating window manager...");
            _windowManager = new GameWindowManager();
            
            Console.WriteLine("[GameManager] Subscribing to events...");
            _game.EventPrintText += OnGamePrintText;
            _game.EventPrintError += OnGamePrintError;
            _game.EventVariableChanged += OnVariableChanged;
            _game.EventClearWindow += OnClearWindow;
            _game.EventDataRecieveEnd += OnDataReceiveEnd;
            
            Console.WriteLine("[GameManager] Initialization complete.");
            return true;
        }
        catch (Exception ex)
        {
            LastError = $"Failed to initialize game engine: {ex.Message}";
            Console.WriteLine($"[GameManager] ERROR: {LastError}");
            Console.WriteLine($"[GameManager] Stack trace: {ex.StackTrace}");
            ErrorReceived?.Invoke(LastError);
            return false;
        }
    }

    /// <summary>
    /// Connects to the game server with the given credentials.
    /// </summary>
    public Task<bool> ConnectAsync(string account, string password, string character, string game)
    {
        return Task.Run(() =>
        {
            try
            {
                Console.WriteLine($"[GameManager] ConnectAsync called: account={account}, character={character}, game={game}");
                
                // Initialize on first connect
                if (!Initialize())
                {
                    Console.WriteLine("[GameManager] Initialization failed");
                    return false;
                }

                Console.WriteLine("[GameManager] Calling Game.Connect...");
                
                // The Game class handles the full authentication flow
                _game!.Connect("", account, password, character, game);
                
                Console.WriteLine("[GameManager] Connect called, waiting for connection...");
                
                // Wait a bit for connection to establish
                // In a real implementation, we'd use proper async/await with events
                for (int i = 0; i < 30; i++) // Wait up to 15 seconds
                {
                    System.Threading.Thread.Sleep(500);
                    if (_game.IsConnected)
                    {
                        Console.WriteLine("[GameManager] Connected!");
                        Connected?.Invoke();
                        return true;
                    }
                }
                
                Console.WriteLine("[GameManager] Connection timed out");
                LastError = "Connection timed out";
                ErrorReceived?.Invoke(LastError);
                return false;
            }
            catch (Exception ex)
            {
                LastError = $"Connection failed: {ex.Message}";
                Console.WriteLine($"[GameManager] ERROR: {LastError}");
                Console.WriteLine($"[GameManager] Stack trace: {ex.StackTrace}");
                ErrorReceived?.Invoke(LastError);
                return false;
            }
        });
    }

    /// <summary>
    /// Disconnects from the game server.
    /// </summary>
    public void Disconnect()
    {
        try
        {
            _game?.Disconnect();
            Disconnected?.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GameManager] Disconnect error: {ex.Message}");
        }
    }

    /// <summary>
    /// Sends a command to the game server.
    /// </summary>
    public void SendCommand(string command)
    {
        try
        {
            if (_game?.IsConnected == true)
            {
                _game.SendText(command, true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GameManager] SendCommand error: {ex.Message}");
            ErrorReceived?.Invoke($"Failed to send command: {ex.Message}");
        }
    }

    private void OnGamePrintText(string text, GenieColor color, GenieColor bgcolor, 
        Game.WindowTarget targetwindow, string targetwindowstring, bool mono, bool isprompt, bool isinput)
    {
        // Debug: Log ALL incoming events at entry point (including Room)
        if (targetwindow == Game.WindowTarget.Room)
        {
            var roomDebug = text?.Replace("\r", "").Replace("\n", "\\n") ?? "";
            if (roomDebug.Length > 60) roomDebug = roomDebug.Substring(0, 60) + "...";
            Console.WriteLine($"[GameManager] *** ROOM EVENT ***: text=\"{roomDebug}\"");
        }
        
        // Determine the window type
        var winType = GameWindow.FromWindowTarget(targetwindow, targetwindowstring);
        
        // Handle control markers for window batching
        var trimmedText = text?.Trim() ?? "";
        if (trimmedText == "@suspend@")
        {
            Console.WriteLine($"[GameManager] SUSPEND: target={targetwindow}, winType={winType}");
            var window = _windowManager?.GetWindow(winType);
            window?.Suspend();
            return;
        }
        if (trimmedText == "@resume@")
        {
            Console.WriteLine($"[GameManager] RESUME: target={targetwindow}, winType={winType}");
            var window = _windowManager?.GetWindow(winType);
            window?.Resume();
            return;
        }
        
        // For custom windows, use the targetwindowstring as the ID
        var customWindowId = targetwindow == Game.WindowTarget.Other ? targetwindowstring : "";
        
        // Debug: log ALL window text (including Main)
        var debugText = (text ?? "").Replace("\r", "").Replace("\n", "\\n");
        if (debugText.Length > 50) debugText = debugText.Substring(0, 50) + "...";
        Console.WriteLine($"[GameManager] target={targetwindow}, winType={winType}, text=\"{debugText}\"");
        
        // Fire the window-specific event (this is now the primary event)
        WindowTextReceived?.Invoke(winType, customWindowId, text, color, bgcolor);
        
        // Check for vital updates in the globals
        CheckVitals();
    }
    
    private void OnClearWindow(string windowId)
    {
        _windowManager?.ClearWindow(windowId);
    }
    
    /// <summary>
    /// Called when the game socket finishes receiving a batch of data.
    /// This triggers deferred operations like Room window updates.
    /// </summary>
    private void OnDataReceiveEnd()
    {
        // Critical: Call SetBufferEnd to trigger deferred Room window updates
        _game?.SetBufferEnd();
    }

    private void OnGamePrintError(string text)
    {
        ErrorReceived?.Invoke(text);
    }

    private void OnVariableChanged(string variable)
    {
        if (_globals == null) return;
        
        try
        {
            // Handle compass updates (no $ prefix)
            if (variable == "compass")
            {
                UpdateCompass();
                return;
            }
            
            // Check if it's a vital-related variable
            if (variable.StartsWith("$"))
            {
                var varName = variable.Substring(1);
                var value = _globals.VariableList?.ContainsKey(varName) == true
                    ? _globals.VariableList[varName]?.ToString() ?? "" 
                    : "";
                
                VariableChanged?.Invoke(varName, value);
                
                // Update vitals if needed
                if (varName == "health" || varName == "mana" || varName == "fatigue" || 
                    varName == "spirit" || varName == "concentration")
                {
                    CheckVitals();
                }
                
                // Update roundtime - starts the countdown timer
                if (varName == "roundtime")
                {
                    if (int.TryParse(value, out int rt))
                    {
                        SetRoundtime(rt);
                    }
                }
                
                // Update hands
                if (varName == "lefthand" || varName == "righthand")
                {
                    UpdateHands();
                }
                
                // Update prepared spell
                if (varName == "preparedspell")
                {
                    UpdateSpell();
                }
                
                // Update status indicators
                if (varName == "standing" || varName == "sitting" || varName == "kneeling" || varName == "prone" ||
                    varName == "hidden" || varName == "invisible" || varName == "joined" || varName == "webbed" ||
                    varName == "stunned" || varName == "bleeding" || varName == "dead")
                {
                    UpdateStatus();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GameManager] OnVariableChanged error: {ex.Message}");
        }
    }

    private void CheckVitals()
    {
        if (_globals == null) return;
        
        try
        {
            int health = GetVitalPercent("health");
            int mana = GetVitalPercent("mana");
            int concentration = GetVitalPercent("concentration");
            int stamina = GetVitalPercent("fatigue"); // DR calls it fatigue
            int spirit = GetVitalPercent("spirit");
            
            VitalsChanged?.Invoke(health, mana, concentration, stamina, spirit);
        }
        catch
        {
            // Ignore parsing errors
        }
    }

    private void UpdateCompass()
    {
        if (_globals == null) return;
        
        try
        {
            bool GetDir(string name) => _globals.VariableList?.ContainsKey(name) == true 
                && _globals.VariableList[name]?.ToString() == "1";
            
            bool n = GetDir("north");
            bool ne = GetDir("northeast");
            bool e = GetDir("east");
            bool se = GetDir("southeast");
            bool s = GetDir("south");
            bool sw = GetDir("southwest");
            bool w = GetDir("west");
            bool nw = GetDir("northwest");
            bool up = GetDir("up");
            bool down = GetDir("down");
            bool @out = GetDir("out");
            
            CompassChanged?.Invoke(n, ne, e, se, s, sw, w, nw, up, down, @out);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GameManager] UpdateCompass error: {ex.Message}");
        }
    }

    private void UpdateHands()
    {
        if (_globals == null) return;
        
        try
        {
            string GetVar(string name) => _globals.VariableList?.ContainsKey(name) == true 
                ? _globals.VariableList[name]?.ToString() ?? "Empty" 
                : "Empty";
            
            var leftHand = GetVar("lefthand");
            var rightHand = GetVar("righthand");
            
            // Empty string means empty hand
            if (string.IsNullOrWhiteSpace(leftHand)) leftHand = "Empty";
            if (string.IsNullOrWhiteSpace(rightHand)) rightHand = "Empty";
            
            HandsChanged?.Invoke(leftHand, rightHand);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GameManager] UpdateHands error: {ex.Message}");
        }
    }

    private void UpdateSpell()
    {
        if (_globals == null) return;
        
        try
        {
            var spell = _globals.VariableList?.ContainsKey("preparedspell") == true 
                ? _globals.VariableList["preparedspell"]?.ToString() ?? "" 
                : "";
            
            // "None" from the game means no spell
            if (string.IsNullOrWhiteSpace(spell) || spell.Equals("None", StringComparison.OrdinalIgnoreCase))
            {
                spell = "";
            }
            
            SpellChanged?.Invoke(spell);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GameManager] UpdateSpell error: {ex.Message}");
        }
    }

    private void UpdateStatus()
    {
        if (_globals == null) return;
        
        try
        {
            bool IsActive(string name) => _globals.VariableList?.ContainsKey(name) == true 
                && _globals.VariableList[name]?.ToString() == "1";
            
            // Determine position (only one should be active)
            string position = "Standing"; // default
            if (IsActive("sitting")) position = "Sitting";
            else if (IsActive("kneeling")) position = "Kneeling";
            else if (IsActive("prone")) position = "Prone";
            else if (IsActive("standing")) position = "Standing";
            
            // Status effects
            bool hidden = IsActive("hidden");
            bool invisible = IsActive("invisible");
            bool joined = IsActive("joined");
            bool webbed = IsActive("webbed");
            bool stunned = IsActive("stunned");
            bool bleeding = IsActive("bleeding");
            bool dead = IsActive("dead");
            
            StatusChanged?.Invoke(position, hidden, invisible, joined, webbed, stunned, bleeding, dead);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[GameManager] UpdateStatus error: {ex.Message}");
        }
    }

    private int GetVitalPercent(string vitalName)
    {
        if (_globals?.VariableList?.ContainsKey(vitalName) == true)
        {
            var value = _globals.VariableList[vitalName]?.ToString() ?? "100";
            if (int.TryParse(value, out int percent))
            {
                return Math.Clamp(percent, 0, 100);
            }
        }
        return 100;
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        // Stop and dispose the roundtime timer
        _roundtimeTimer?.Change(Timeout.Infinite, Timeout.Infinite);
        _roundtimeTimer?.Dispose();
        _roundtimeTimer = null;

        if (_game != null)
        {
            try
            {
                _game.EventPrintText -= OnGamePrintText;
                _game.EventPrintError -= OnGamePrintError;
                _game.EventVariableChanged -= OnVariableChanged;
                _game.EventDataRecieveEnd -= OnDataReceiveEnd;
                
                if (_game.IsConnected)
                {
                    _game.Disconnect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GameManager] Error during dispose: {ex.Message}");
            }
        }
    }
}

