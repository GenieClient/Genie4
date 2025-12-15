using Avalonia.Controls.Documents;
using Avalonia.Media;
using GenieClient.Genie;
using GenieClient.Services;
using System;
using System.Collections.Generic;

namespace GenieClient.UI.Services;

/// <summary>
/// Represents the type of game window (matches Game.WindowTarget).
/// </summary>
public enum GameWindowType
{
    Main,
    Room,
    Inventory,
    Familiar,
    Thoughts,
    Arrivals,  // Logons in original
    Deaths,
    Combat,
    ActiveSpells,
    Raw,
    Debug,
    Custom
}

/// <summary>
/// Represents a game output window/panel.
/// </summary>
public class GameWindow
{
    public GameWindowType Type { get; }
    public string Id { get; }
    public string Title { get; set; }
    public bool IsVisible { get; set; } = true;
    public bool ClearOnUpdate { get; set; } = false;  // For Room window
    public InlineCollection? Inlines { get; set; }
    
    // Buffer for suspended updates
    private List<StyledTextSegment> _pendingSegments = new();
    private bool _isSuspended = false;
    
    public GameWindow(GameWindowType type, string title)
    {
        Type = type;
        Id = type.ToString().ToLower();
        Title = title;
    }
    
    public GameWindow(string customId, string title)
    {
        Type = GameWindowType.Custom;
        Id = customId;
        Title = title;
    }
    
    /// <summary>
    /// Suspends updates (for batching multiple lines).
    /// For windows with ClearOnUpdate, this also clears the content.
    /// </summary>
    public void Suspend()
    {
        _isSuspended = true;
        _pendingSegments.Clear();
        
        // For windows that clear on update (like Room), clear now
        if (ClearOnUpdate)
        {
            Inlines?.Clear();
        }
    }
    
    /// <summary>
    /// Resumes updates and flushes pending content.
    /// </summary>
    public void Resume()
    {
        _isSuspended = false;
        FlushPending();
    }
    
    /// <summary>
    /// Adds styled text to the window.
    /// </summary>
    public void AddText(StyledTextSegment segment)
    {
        if (_isSuspended)
        {
            _pendingSegments.Add(segment);
        }
        else
        {
            RenderSegment(segment);
        }
    }
    
    /// <summary>
    /// Adds styled text to the window.
    /// </summary>
    public void AddText(string text, GenieColor fg, GenieColor bg)
    {
        AddText(new StyledTextSegment(text, fg, bg));
    }
    
    /// <summary>
    /// Clears all content from the window.
    /// </summary>
    public void Clear()
    {
        _pendingSegments.Clear();
        Inlines?.Clear();
    }
    
    private void FlushPending()
    {
        if (Inlines == null) return;
        
        // If this window clears on update (like Room), clear first
        if (ClearOnUpdate && _pendingSegments.Count > 0)
        {
            Inlines.Clear();
        }
        
        foreach (var segment in _pendingSegments)
        {
            RenderSegment(segment);
        }
        _pendingSegments.Clear();
    }
    
    private void RenderSegment(StyledTextSegment segment)
    {
        if (Inlines == null || string.IsNullOrEmpty(segment.Text)) return;
        
        var fg = Color.FromRgb(segment.ForegroundColor.R, segment.ForegroundColor.G, segment.ForegroundColor.B);
        var run = new Run(segment.Text)
        {
            Foreground = new SolidColorBrush(fg)
        };
        
        if (segment.BackgroundColor != GenieColor.Transparent)
        {
            var bg = Color.FromRgb(segment.BackgroundColor.R, segment.BackgroundColor.G, segment.BackgroundColor.B);
            run.Background = new SolidColorBrush(bg);
        }
        
        if (segment.IsBold)
        {
            run.FontWeight = FontWeight.Bold;
        }
        
        Inlines.Add(run);
    }
    
    /// <summary>
    /// Maps Game.WindowTarget to GameWindowType.
    /// </summary>
    public static GameWindowType FromWindowTarget(Game.WindowTarget target, string customId = "")
    {
        return target switch
        {
            Game.WindowTarget.Main => GameWindowType.Main,
            Game.WindowTarget.Room => GameWindowType.Room,
            Game.WindowTarget.Inv => GameWindowType.Inventory,
            Game.WindowTarget.Familiar => GameWindowType.Familiar,
            Game.WindowTarget.Thoughts => GameWindowType.Thoughts,
            Game.WindowTarget.Logons => GameWindowType.Arrivals,
            Game.WindowTarget.Death => GameWindowType.Deaths,
            Game.WindowTarget.Combat => GameWindowType.Combat,
            Game.WindowTarget.ActiveSpells => GameWindowType.ActiveSpells,
            Game.WindowTarget.Raw => GameWindowType.Raw,
            Game.WindowTarget.Debug => GameWindowType.Debug,
            Game.WindowTarget.Other => GameWindowType.Custom,
            _ => GameWindowType.Main
        };
    }
}

/// <summary>
/// Manages all game windows.
/// </summary>
public class GameWindowManager
{
    private readonly Dictionary<string, GameWindow> _windows = new();
    
    public event Action<GameWindow>? WindowCreated;
    public event Action<GameWindow>? WindowCleared;
    public event Action<GameWindow>? WindowUpdated;
    
    public GameWindowManager()
    {
        // Create standard windows
        CreateWindow(new GameWindow(GameWindowType.Main, "Game"));
        CreateWindow(new GameWindow(GameWindowType.Room, "Room") { ClearOnUpdate = true });
        CreateWindow(new GameWindow(GameWindowType.Inventory, "Inventory") { ClearOnUpdate = true });
        CreateWindow(new GameWindow(GameWindowType.Thoughts, "Thoughts"));
        CreateWindow(new GameWindow(GameWindowType.Familiar, "Familiar"));
        CreateWindow(new GameWindow(GameWindowType.Arrivals, "Arrivals"));
        CreateWindow(new GameWindow(GameWindowType.Deaths, "Deaths"));
        CreateWindow(new GameWindow(GameWindowType.Combat, "Combat"));
        CreateWindow(new GameWindow(GameWindowType.ActiveSpells, "Spells"));
    }
    
    public GameWindow? GetWindow(GameWindowType type)
    {
        var id = type.ToString().ToLower();
        return _windows.TryGetValue(id, out var window) ? window : null;
    }
    
    public GameWindow? GetWindow(string id)
    {
        return _windows.TryGetValue(id.ToLower(), out var window) ? window : null;
    }
    
    public GameWindow GetOrCreateWindow(string id, string title)
    {
        var lowerId = id.ToLower();
        if (!_windows.TryGetValue(lowerId, out var window))
        {
            window = new GameWindow(lowerId, title);
            CreateWindow(window);
        }
        return window;
    }
    
    public IEnumerable<GameWindow> GetAllWindows() => _windows.Values;
    
    private void CreateWindow(GameWindow window)
    {
        _windows[window.Id] = window;
        WindowCreated?.Invoke(window);
    }
    
    public void ClearWindow(string id)
    {
        if (_windows.TryGetValue(id.ToLower(), out var window))
        {
            window.Clear();
            WindowCleared?.Invoke(window);
        }
    }
    
    public void ClearWindow(GameWindowType type)
    {
        ClearWindow(type.ToString().ToLower());
    }
}

