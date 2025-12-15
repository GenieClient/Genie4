using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using GenieClient.UI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GenieClient.Views;

/// <summary>
/// Represents a node in the script tree (file or directory).
/// </summary>
public class ScriptTreeNode
{
    public string Name { get; set; } = "";
    public string FullPath { get; set; } = "";
    public bool IsDirectory { get; set; }
    public string Icon => IsDirectory ? "📁" : "📜";
    public ObservableCollection<ScriptTreeNode> Children { get; } = new();
}

public partial class ScriptExplorerDialog : Window
{
    private readonly ScriptManager? _scriptManager;
    private ScriptTreeNode? _selectedNode;
    private readonly DispatcherTimer _refreshTimer;

    /// <summary>
    /// Event raised when a script should be run.
    /// </summary>
    public event Action<string>? RunScriptRequested;

    public ScriptExplorerDialog()
    {
        InitializeComponent();
        
        // Timer to refresh running scripts display
        _refreshTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _refreshTimer.Tick += (s, e) => UpdateRunningScripts();
    }

    public ScriptExplorerDialog(ScriptManager? scriptManager) : this()
    {
        _scriptManager = scriptManager;
        LoadScripts();
        UpdateRunningScripts();
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        _refreshTimer.Start();
    }

    protected override void OnClosed(EventArgs e)
    {
        _refreshTimer.Stop();
        base.OnClosed(e);
    }

    /// <summary>
    /// Shows the dialog and returns when closed.
    /// </summary>
    public static async Task ShowDialog(Window parent, ScriptManager? scriptManager, Action<string>? onRunScript = null)
    {
        var dialog = new ScriptExplorerDialog(scriptManager);
        if (onRunScript != null)
        {
            dialog.RunScriptRequested += onRunScript;
        }
        await dialog.ShowDialog(parent);
    }

    private void LoadScripts()
    {
        var scriptDir = _scriptManager?.GetScriptDirectory() ?? "";
        
        if (!Directory.Exists(scriptDir))
        {
            StatusText.Text = $"Script directory not found: {scriptDir}";
            return;
        }

        var rootNodes = new ObservableCollection<ScriptTreeNode>();
        LoadDirectory(scriptDir, rootNodes, "");
        
        ScriptTree.ItemsSource = rootNodes;
        StatusText.Text = $"Scripts: {scriptDir}";
    }

    private void LoadDirectory(string baseDir, ObservableCollection<ScriptTreeNode> nodes, string relativePath)
    {
        var currentDir = string.IsNullOrEmpty(relativePath) 
            ? baseDir 
            : Path.Combine(baseDir, relativePath);

        if (!Directory.Exists(currentDir)) return;

        try
        {
            // Add subdirectories
            foreach (var dir in Directory.GetDirectories(currentDir).OrderBy(d => d))
            {
                var dirName = Path.GetFileName(dir);
                var node = new ScriptTreeNode
                {
                    Name = dirName,
                    FullPath = string.IsNullOrEmpty(relativePath) ? dirName : Path.Combine(relativePath, dirName),
                    IsDirectory = true
                };
                
                // Recursively load children
                LoadDirectory(baseDir, node.Children, node.FullPath);
                
                nodes.Add(node);
            }

            // Add files
            var extension = _scriptManager?.GetScriptExtension() ?? "cmd";
            foreach (var file in Directory.GetFiles(currentDir, $"*.{extension}").OrderBy(f => f))
            {
                var fileName = Path.GetFileName(file);
                var node = new ScriptTreeNode
                {
                    Name = fileName,
                    FullPath = string.IsNullOrEmpty(relativePath) ? fileName : Path.Combine(relativePath, fileName),
                    IsDirectory = false
                };
                nodes.Add(node);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading directory {currentDir}: {ex.Message}");
        }
    }

    private void UpdateRunningScripts()
    {
        var scripts = _scriptManager?.GetRunningScripts();
        RunningScriptsList.ItemsSource = scripts;
        
        // Show/hide the running scripts panel based on whether any are running
        RunningScriptsPanel.IsVisible = scripts?.Count > 0;
        
        // Update button states for selected item
        if (_selectedNode != null && !_selectedNode.IsDirectory)
        {
            var isRunning = scripts?.Any(s => 
                s.FileName.Equals(_selectedNode.FullPath, StringComparison.OrdinalIgnoreCase) ||
                s.FileName.Equals(_selectedNode.Name, StringComparison.OrdinalIgnoreCase)) == true;
            
            AbortButton.IsEnabled = isRunning;
            PauseButton.IsEnabled = isRunning;
        }
    }

    private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        _selectedNode = ScriptTree.SelectedItem as ScriptTreeNode;
        
        if (_selectedNode == null)
        {
            RunButton.IsEnabled = false;
            PauseButton.IsEnabled = false;
            AbortButton.IsEnabled = false;
            return;
        }

        // Enable Run button for files only
        RunButton.IsEnabled = !_selectedNode.IsDirectory;
        
        // Check if script is running
        var scripts = _scriptManager?.GetRunningScripts();
        var isRunning = scripts?.Any(s => 
            s.FileName.Equals(_selectedNode.FullPath, StringComparison.OrdinalIgnoreCase) ||
            s.FileName.Equals(_selectedNode.Name, StringComparison.OrdinalIgnoreCase)) == true;
        
        AbortButton.IsEnabled = isRunning;
        PauseButton.IsEnabled = isRunning;
        
        if (!_selectedNode.IsDirectory)
        {
            StatusText.Text = isRunning ? $"Running: {_selectedNode.Name}" : $"Selected: {_selectedNode.Name}";
        }
        else
        {
            StatusText.Text = $"Folder: {_selectedNode.Name}";
        }
    }

    private void OnDoubleClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedNode != null && !_selectedNode.IsDirectory)
        {
            RunSelectedScript();
        }
    }

    private void OnRunClick(object? sender, RoutedEventArgs e)
    {
        RunSelectedScript();
    }

    private void RunSelectedScript()
    {
        if (_selectedNode == null || _selectedNode.IsDirectory) return;
        
        // Run the script
        var scriptPath = _selectedNode.FullPath;
        
        // Raise event to let parent handle it
        RunScriptRequested?.Invoke(scriptPath);
        
        // Or run directly if we have a script manager
        _scriptManager?.RunScript(scriptPath);
        
        StatusText.Text = $"Started: {_selectedNode.Name}";
        UpdateRunningScripts();
    }

    private void OnPauseClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedNode == null || _selectedNode.IsDirectory) return;
        
        var scripts = _scriptManager?.GetRunningScripts();
        var script = scripts?.FirstOrDefault(s => 
            s.FileName.Equals(_selectedNode.FullPath, StringComparison.OrdinalIgnoreCase) ||
            s.FileName.Equals(_selectedNode.Name, StringComparison.OrdinalIgnoreCase));
        
        if (script != null)
        {
            _scriptManager?.TogglePauseScript(script);
            UpdateRunningScripts();
        }
    }

    private void OnAbortClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedNode == null || _selectedNode.IsDirectory) return;
        
        _scriptManager?.AbortScript(_selectedNode.Name);
        UpdateRunningScripts();
    }

    private void OnRefreshClick(object? sender, RoutedEventArgs e)
    {
        LoadScripts();
        UpdateRunningScripts();
    }

    private void OnPauseRunningClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is ScriptInfo info)
        {
            _scriptManager?.TogglePauseScript(info);
            UpdateRunningScripts();
        }
    }

    private void OnAbortRunningClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is ScriptInfo info)
        {
            _scriptManager?.AbortScript(info);
            UpdateRunningScripts();
        }
    }

    private void OnCloseClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}

