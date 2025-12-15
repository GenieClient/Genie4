using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using GenieClient.Genie;
using GenieClient.Services;
using GenieClient.UI.Services;
using System;
using System.Collections.Generic;

namespace GenieClient.Views;

public partial class MainWindow : Window
{
    private GameManager? _gameManager;
    private HighlightProcessor? _highlightProcessor;
    
    // Window scrollers for auto-scroll
    private readonly Dictionary<GameWindowType, ScrollViewer> _windowScrollers = new();
    private readonly Dictionary<GameWindowType, SelectableTextBlock> _windowOutputs = new();

    public MainWindow()
    {
        InitializeComponent();
        
        // Initialize services with null implementations for now
        // Platform-specific implementations will be registered later
        GenieServices.InitializeWithNullServices();
        
        // Focus the command input on load
        CommandInput.AttachedToVisualTree += (s, e) => CommandInput.Focus();
        
        // Initialize vitals at 100%
        UpdateVitals(100, 100, 100, 100, 100);
        
        // Clear the initial text from XAML since we'll use Inlines
        GameOutput.Text = "";
        AppendText("Welcome to Genie 5 - Cross-Platform Edition\n\n", Colors.LightGreen);
        AppendText("Use File → Connect to connect to a game server.\n\n", Colors.Gray);
        
        // Setup window output mappings
        SetupWindowMappings();
        
        // Initialize game manager
        InitializeGameManager();
    }
    
    private void SetupWindowMappings()
    {
        // Map window types to their UI elements
        _windowOutputs[GameWindowType.Main] = GameOutput;
        _windowOutputs[GameWindowType.Room] = RoomOutput;
        _windowOutputs[GameWindowType.Inventory] = InventoryOutput;
        _windowOutputs[GameWindowType.Thoughts] = ThoughtsOutput;
        
        // Find scrollers (parent ScrollViewer)
        _windowScrollers[GameWindowType.Main] = OutputScroller;
    }

    private void InitializeGameManager()
    {
        _gameManager = new GameManager();
        
        // Subscribe to game events
        // Note: Using WindowTextReceived for all text routing (not TextReceived)
        _gameManager.WindowTextReceived += OnWindowTextReceived;
        _gameManager.ErrorReceived += OnGameErrorReceived;
        _gameManager.Connected += OnGameConnected;
        _gameManager.Disconnected += OnGameDisconnected;
        _gameManager.VitalsChanged += OnVitalsChanged;
        _gameManager.RoundtimeChanged += OnRoundtimeChanged;
        _gameManager.CompassChanged += OnCompassChanged;
        _gameManager.HandsChanged += OnHandsChanged;
        _gameManager.SpellChanged += OnSpellChanged;
        _gameManager.StatusChanged += OnStatusChanged;
    }
    
    private void OnWindowTextReceived(GameWindowType windowType, string customId, string text, GenieColor color, GenieColor bgcolor)
    {
        Dispatcher.UIThread.Post(() =>
        {
            // Get the output for this window type
            if (!_windowOutputs.TryGetValue(windowType, out var output))
            {
                // For unknown windows, route to main
                output = GameOutput;
            }
            
            EnsureHighlightProcessor();
            
            // For Inventory window, clear when we see the header line
            if (windowType == GameWindowType.Inventory)
            {
                var trimmed = text.Trim();
                if (trimmed.StartsWith("Your worn items are:") || 
                    trimmed.StartsWith("You are carrying:") ||
                    trimmed.StartsWith("You have:"))
                {
                    InventoryOutput.Inlines?.Clear();
                }
            }
            
            // For Room window, clear when we see a room title (starts with [)
            if (windowType == GameWindowType.Room)
            {
                var trimmed = text.Trim();
                if (trimmed.StartsWith("[") && trimmed.Contains("]"))
                {
                    RoomOutput.Inlines?.Clear();
                }
            }
            
            // Apply highlights
            if (_highlightProcessor != null)
            {
                var segments = _highlightProcessor.Process(text, color, bgcolor);
                foreach (var segment in segments)
                {
                    var fg = Color.FromRgb(segment.ForegroundColor.R, segment.ForegroundColor.G, segment.ForegroundColor.B);
                    var bg = segment.BackgroundColor != GenieColor.Transparent 
                        ? Color.FromRgb(segment.BackgroundColor.R, segment.BackgroundColor.G, segment.BackgroundColor.B)
                        : (Color?)null;
                    AppendStyledTextTo(output, segment.Text, fg, bg);
                }
            }
            else
            {
                var avaloniaColor = Color.FromRgb(color.R, color.G, color.B);
                AppendStyledTextTo(output, text, avaloniaColor);
            }
            
            // Auto-scroll if we have a scroller for this window
            if (_windowScrollers.TryGetValue(windowType, out var scroller))
            {
                scroller.ScrollToEnd();
            }
        });
    }
    
    private void OnToggleWindow(object? sender, RoutedEventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            var isChecked = !menuItem.IsChecked;
            menuItem.IsChecked = isChecked;
            
            // Toggle panel visibility
            if (menuItem == MenuShowRoom)
                RoomPanel.IsVisible = isChecked;
            else if (menuItem == MenuShowInventory)
                InventoryPanel.IsVisible = isChecked;
            else if (menuItem == MenuShowThoughts)
                ThoughtsPanel.IsVisible = isChecked;
        }
    }

    private void EnsureHighlightProcessor()
    {
        // Create the highlight processor once globals is available
        if (_highlightProcessor == null && _gameManager?.Globals != null)
        {
            _highlightProcessor = new HighlightProcessor(_gameManager.Globals);
        }
    }

    private void OnGameTextReceived(string text, GenieColor color, GenieColor bgcolor)
    {
        // Marshal to UI thread
        Dispatcher.UIThread.Post(() =>
        {
            EnsureHighlightProcessor();
            
            if (_highlightProcessor != null)
            {
                // Process text through highlight system
                var segments = _highlightProcessor.Process(text, color, bgcolor);
                foreach (var segment in segments)
                {
                    var fg = Color.FromRgb(segment.ForegroundColor.R, segment.ForegroundColor.G, segment.ForegroundColor.B);
                    var bg = segment.BackgroundColor != GenieColor.Transparent 
                        ? Color.FromRgb(segment.BackgroundColor.R, segment.BackgroundColor.G, segment.BackgroundColor.B)
                        : (Color?)null;
                    AppendStyledText(segment.Text, fg, bg);
                    
                    // Play sound if specified
                    if (!string.IsNullOrEmpty(segment.SoundFile))
                    {
                        GenieServices.Sound.PlayWaveFile(segment.SoundFile);
                    }
                }
            }
            else
            {
                // Fall back to simple text append
                var avaloniaColor = Color.FromRgb(color.R, color.G, color.B);
                AppendText(text, avaloniaColor);
            }
        });
    }

    private void OnGameErrorReceived(string text)
    {
        Dispatcher.UIThread.Post(() =>
        {
            AppendText(text + "\n", Colors.Red);
        });
    }

    private void OnGameConnected()
    {
        Dispatcher.UIThread.Post(() =>
        {
            StatusText.Text = "Connected";
            ConnectionStatus.Foreground = new SolidColorBrush(Color.Parse("#22c55e"));
            AppendText("Connected to game server.\n", Colors.Green);
        });
    }

    private void OnGameDisconnected()
    {
        Dispatcher.UIThread.Post(() =>
        {
            StatusText.Text = "Disconnected";
            ConnectionStatus.Foreground = new SolidColorBrush(Color.Parse("#ef4444"));
            AppendText("Disconnected from game server.\n", Colors.Gray);
        });
    }

    private void OnVitalsChanged(int health, int mana, int concentration, int stamina, int spirit)
    {
        Dispatcher.UIThread.Post(() =>
        {
            UpdateVitals(health, mana, concentration, stamina, spirit);
        });
    }

    private void OnRoundtimeChanged(int seconds)
    {
        Dispatcher.UIThread.Post(() =>
        {
            UpdateRoundtime(seconds);
        });
    }

    private void OnCompassChanged(bool n, bool ne, bool e, bool se, bool s, bool sw, bool w, bool nw, bool up, bool down, bool @out)
    {
        Dispatcher.UIThread.Post(() =>
        {
            UpdateCompass(n, ne, e, se, s, sw, w, nw, up, down, @out);
        });
    }

    private void OnHandsChanged(string leftHand, string rightHand)
    {
        Dispatcher.UIThread.Post(() =>
        {
            UpdateHands(leftHand, rightHand);
        });
    }

    private void OnSpellChanged(string spell)
    {
        Dispatcher.UIThread.Post(() =>
        {
            UpdateSpell(spell);
        });
    }

    private void OnStatusChanged(string position, bool hidden, bool invisible, bool joined, bool webbed, bool stunned, bool bleeding, bool dead)
    {
        Dispatcher.UIThread.Post(() =>
        {
            UpdatePosition(position);
            UpdateStatusEffects(hidden, invisible, joined, webbed, stunned, bleeding, dead);
        });
    }

    /// <summary>
    /// Updates the vital bars with the given percentages (0-100).
    /// </summary>
    public void UpdateVitals(int health, int mana, int concentration, int stamina, int spirit)
    {
        UpdateBar(HealthBar, HealthText, health, "#ef4444");      // Red
        UpdateBar(ManaBar, ManaText, mana, "#3b82f6");            // Blue
        UpdateBar(ConcentrationBar, ConcentrationText, concentration, "#22d3ee"); // Cyan
        UpdateBar(StaminaBar, StaminaText, stamina, "#22c55e");   // Green
        UpdateBar(SpiritBar, SpiritText, spirit, "#e879f9");      // Magenta
    }

    /// <summary>
    /// Updates what's in the character's hands.
    /// </summary>
    public void UpdateHands(string leftHand, string rightHand)
    {
        LeftHandText.Text = string.IsNullOrEmpty(leftHand) ? "Empty" : leftHand;
        RightHandText.Text = string.IsNullOrEmpty(rightHand) ? "Empty" : rightHand;
    }

    /// <summary>
    /// Updates the prepared spell display.
    /// </summary>
    public void UpdateSpell(string spellName)
    {
        PreparedSpellText.Text = string.IsNullOrEmpty(spellName) ? "None" : spellName;
        PreparedSpellText.Foreground = string.IsNullOrEmpty(spellName) 
            ? new SolidColorBrush(Color.Parse("#666")) 
            : new SolidColorBrush(Color.Parse("#a855f7"));
    }

    /// <summary>
    /// Updates compass direction availability.
    /// </summary>
    public void UpdateCompass(bool n, bool ne, bool e, bool se, bool s, bool sw, bool w, bool nw, bool up, bool down, bool @out)
    {
        var activeColor = new SolidColorBrush(Color.Parse("#f97316")); // Orange
        var inactiveColor = new SolidColorBrush(Color.Parse("#444"));
        
        CompassN.Foreground = n ? activeColor : inactiveColor;
        CompassNE.Foreground = ne ? activeColor : inactiveColor;
        CompassE.Foreground = e ? activeColor : inactiveColor;
        CompassSE.Foreground = se ? activeColor : inactiveColor;
        CompassS.Foreground = s ? activeColor : inactiveColor;
        CompassSW.Foreground = sw ? activeColor : inactiveColor;
        CompassW.Foreground = w ? activeColor : inactiveColor;
        CompassNW.Foreground = nw ? activeColor : inactiveColor;
        CompassUp.Foreground = up ? activeColor : inactiveColor;
        CompassDown.Foreground = down ? activeColor : inactiveColor;
        CompassOut.Foreground = @out ? activeColor : inactiveColor;
    }

    /// <summary>
    /// Updates the position indicator (standing/sitting/kneeling/prone).
    /// </summary>
    public void UpdatePosition(string position)
    {
        // Update tooltip
        ToolTip.SetTip(PositionBorder, position);
        
        // Hide all icons first
        IconStanding.IsVisible = false;
        IconSitting.IsVisible = false;
        IconKneeling.IsVisible = false;
        IconProne.IsVisible = false;
        
        // Show the correct icon
        switch (position)
        {
            case "Standing":
                IconStanding.IsVisible = true;
                break;
            case "Sitting":
                IconSitting.IsVisible = true;
                break;
            case "Kneeling":
                IconKneeling.IsVisible = true;
                break;
            case "Prone":
                IconProne.IsVisible = true;
                break;
            default:
                IconStanding.IsVisible = true;
                break;
        }
    }

    /// <summary>
    /// Updates status effect visibility.
    /// </summary>
    public void UpdateStatusEffects(bool hidden = false, bool invisible = false, bool joined = false, 
        bool webbed = false, bool stunned = false, bool bleeding = false, bool dead = false)
    {
        StatusHidden.IsVisible = hidden;
        StatusInvisible.IsVisible = invisible;
        StatusJoined.IsVisible = joined;
        StatusWebbed.IsVisible = webbed;
        StatusStunned.IsVisible = stunned;
        StatusBleeding.IsVisible = bleeding;
        StatusDead.IsVisible = dead;
    }

    private void UpdateBar(Border bar, TextBlock text, int percent, string color)
    {
        percent = Math.Clamp(percent, 0, 100);
        text.Text = $"{percent}%";
        
        // Use RenderTransform with ScaleX to show percentage
        bar.RenderTransformOrigin = new Avalonia.RelativePoint(0, 0.5, Avalonia.RelativeUnit.Relative);
        bar.RenderTransform = new ScaleTransform(percent / 100.0, 1.0);
    }

    private int _maxRoundtime = 1; // Track max RT for percentage calculation

    /// <summary>
    /// Updates the roundtime display.
    /// </summary>
    public void UpdateRoundtime(int seconds, int? maxSeconds = null)
    {
        if (maxSeconds.HasValue && maxSeconds.Value > 0)
            _maxRoundtime = maxSeconds.Value;
        else if (seconds > _maxRoundtime)
            _maxRoundtime = seconds;

        RoundtimeText.Text = seconds.ToString();
        RoundtimeText.Foreground = seconds > 0 
            ? new SolidColorBrush(Color.Parse("#ef4444")) 
            : new SolidColorBrush(Color.Parse("#666"));

        // Update progress bar width (70px is the container width)
        double percentage = _maxRoundtime > 0 ? (double)seconds / _maxRoundtime : 0;
        RoundtimeBar.Width = 70 * percentage;
        
        // Reset max when RT hits 0
        if (seconds == 0)
            _maxRoundtime = 1;
    }

    private async void OnConnect(object? sender, RoutedEventArgs e)
    {
        var result = await ConnectDialog.Show(this);
        if (result == null)
        {
            AppendText("Connection cancelled.\n", Colors.Gray);
            return;
        }

        AppendText($"Connecting to {result.SelectedGame}...\n", Colors.Yellow);
        AppendText($"Account: {result.Account}\n", Colors.Gray);
        if (!string.IsNullOrEmpty(result.Character))
            AppendText($"Character: {result.Character}\n", Colors.Gray);
        
        StatusText.Text = $"Connecting to {result.SelectedGame}...";
        ConnectionStatus.Foreground = new SolidColorBrush(Colors.Yellow);

        // SelectedGame now contains the game code directly (from Tag property)
        var gameCode = result.SelectedGame ?? "DR";

        try
        {
            var connected = await _gameManager!.ConnectAsync(
                result.Account ?? "", 
                result.Password ?? "", 
                result.Character ?? "", 
                gameCode);
            
            if (!connected)
            {
                AppendText("Connection failed. Check your credentials and try again.\n", Colors.Red);
                StatusText.Text = "Connection failed";
                ConnectionStatus.Foreground = new SolidColorBrush(Color.Parse("#ef4444"));
            }
        }
        catch (Exception ex)
        {
            AppendText($"Connection error: {ex.Message}\n", Colors.Red);
            StatusText.Text = "Connection error";
            ConnectionStatus.Foreground = new SolidColorBrush(Color.Parse("#ef4444"));
        }
    }

    private void OnDisconnect(object? sender, RoutedEventArgs e)
    {
        _gameManager?.Disconnect();
    }

    private void OnExit(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void OnCompassClick(object? sender, PointerPressedEventArgs e)
    {
        if (sender is TextBlock textBlock && textBlock.Tag is string direction)
        {
            // Send the movement command
            _gameManager?.SendCommand(direction);
            
            // Echo to show it was sent
            AppendText($"> {direction}\n", Colors.Cyan);
        }
    }

    private void OnCommandKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            var command = CommandInput.Text;
            if (!string.IsNullOrWhiteSpace(command))
            {
                // Echo the command
                AppendText($"> {command}\n", Colors.Cyan);
                
                // Check for local commands first
                if (command.Equals("test", StringComparison.OrdinalIgnoreCase))
                {
                    AppendText("This is a test response from Genie 5!\n", Colors.LightGreen);
                    AppendText("The cross-platform UI is working.\n", Colors.White);
                }
                else if (command.Equals("colors", StringComparison.OrdinalIgnoreCase))
                {
                    ShowColorTest();
                }
                else if (command.Equals("highlights", StringComparison.OrdinalIgnoreCase))
                {
                    ShowHighlightInfo();
                }
                else if (command.StartsWith("#highlight ", StringComparison.OrdinalIgnoreCase))
                {
                    // Add a test highlight: #highlight <pattern> <color>
                    AddTestHighlight(command);
                }
                else if (command.StartsWith("#echo ", StringComparison.OrdinalIgnoreCase))
                {
                    // Echo text through the highlight processor: #echo <text>
                    var echoText = command.Substring(6);
                    EchoWithHighlights(echoText + "\n");
                }
                else if (command.Equals("clear", StringComparison.OrdinalIgnoreCase))
                {
                    ClearOutput();
                }
                else if (command.Equals("vitals", StringComparison.OrdinalIgnoreCase))
                {
                    // Demo vitals at various levels
                    var rand = new Random();
                    UpdateVitals(rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100));
                    UpdateRoundtime(rand.Next(0, 15));
                    AppendText("Vitals randomized!\n", Colors.Yellow);
                }
                else if (command.Equals("demo", StringComparison.OrdinalIgnoreCase))
                {
                    // Full UI demo
                    var rand = new Random();
                    UpdateVitals(rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100));
                    UpdateRoundtime(rand.Next(3, 12), 12); // Show RT with max of 12 for visible bar
                    UpdateHands("broadsword", "steel shield");
                    UpdateSpell("Fire Ball");
                    UpdateCompass(true, false, true, true, true, false, true, false, false, true, true);
                    UpdateStatusEffects(hidden: rand.Next(2) == 1, joined: rand.Next(2) == 1);
                    AppendText("Full UI demo activated!\n", Colors.Yellow);
                }
                else if (_gameManager?.IsConnected == true)
                {
                    // Send to game server
                    _gameManager.SendCommand(command);
                }
                else
                {
                    AppendText($"Not connected. Use File → Connect to connect to a game server.\n", Colors.Gray);
                }
                
                CommandInput.Text = "";
            }
            e.Handled = true;
        }
    }

    private void ShowColorTest()
    {
        AppendText("Color Test:\n", Colors.White);
        AppendText("  Red text\n", Colors.Red);
        AppendText("  Green text\n", Colors.Green);
        AppendText("  Blue text\n", Colors.Blue);
        AppendText("  Yellow text\n", Colors.Yellow);
        AppendText("  Cyan text\n", Colors.Cyan);
        AppendText("  Magenta text\n", Colors.Magenta);
        AppendText("  Orange text\n", Colors.Orange);
        AppendText("  LightGray text\n", Colors.LightGray);
    }

    private void ShowHighlightInfo()
    {
        EnsureHighlightProcessor();
        var globals = _gameManager?.Globals;
        
        if (globals?.HighlightList == null)
        {
            AppendText("Highlights not initialized. Connect to game first or use #highlight to add test patterns.\n", Colors.Yellow);
            return;
        }
        
        AppendText("Highlight System Info:\n", Colors.White);
        AppendText($"  String highlights: {globals.HighlightList.Count}\n", Colors.Gray);
        
        if (globals.HighlightList.Count > 0)
        {
            AppendText("\nDefined Highlights:\n", Colors.LightGreen);
            foreach (var key in globals.HighlightList.Keys)
            {
                if (globals.HighlightList[key] is GenieClient.Genie.Highlights.Highlight hl)
                {
                    var fg = Color.FromRgb(hl.Foreground.R, hl.Foreground.G, hl.Foreground.B);
                    AppendText($"  • ", Colors.Gray);
                    AppendStyledText(key.ToString() ?? "", fg);
                    AppendText($" → {hl.ColorName}\n", Colors.Gray);
                }
            }
        }
        
        AppendText("\nTest highlight with: #highlight <pattern> <color>\n", Colors.Gray);
        AppendText("Example: #highlight dragon red\n", Colors.Gray);
        AppendText("Example: #highlight treasure gold\n", Colors.Gray);
    }

    private void AddTestHighlight(string command)
    {
        // Parse: #highlight <pattern> <color>
        var parts = command.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3)
        {
            AppendText("Usage: #highlight <pattern> <color>\n", Colors.Yellow);
            return;
        }
        
        var pattern = parts[1];
        var colorName = parts[2];
        
        var globals = _gameManager?.Globals;
        if (globals?.HighlightList == null)
        {
            // Need to initialize globals first
            AppendText("Initializing highlight system...\n", Colors.Gray);
            _ = _gameManager?.ConnectAsync("", "", "", ""); // Trigger init
            
            // Wait a bit for initialization
            System.Threading.Tasks.Task.Delay(500).ContinueWith(_ =>
            {
                Dispatcher.UIThread.Post(() =>
                {
                    if (_gameManager?.Globals?.HighlightList != null)
                    {
                        DoAddHighlight(pattern, colorName);
                    }
                    else
                    {
                        AppendText("Could not initialize highlight system.\n", Colors.Red);
                    }
                });
            });
            return;
        }
        
        DoAddHighlight(pattern, colorName);
    }

    private void DoAddHighlight(string pattern, string colorName)
    {
        var globals = _gameManager?.Globals;
        if (globals?.HighlightList == null) return;
        
        // Add the highlight
        globals.HighlightList.Add(pattern, false, colorName);
        globals.HighlightList.RebuildStringIndex();
        
        // Recreate the highlight processor to pick up changes
        _highlightProcessor = new HighlightProcessor(globals);
        
        var color = ColorCode.StringToGenieColor(colorName);
        var fg = Color.FromRgb(color.R, color.G, color.B);
        AppendText("Added highlight: ", Colors.Gray);
        AppendStyledText(pattern, fg);
        AppendText($" → {colorName}\n", Colors.Gray);
        AppendText($"Test with: #echo The dragon breathes fire!\n", Colors.Gray);
    }

    /// <summary>
    /// Echos text through the highlight processor for testing highlights locally.
    /// </summary>
    private void EchoWithHighlights(string text)
    {
        EnsureHighlightProcessor();
        
        // Use default colors for echo
        var defaultFg = GenieColor.FromRgb(201, 209, 217); // #c9d1d9
        var defaultBg = GenieColor.Transparent;
        
        if (_highlightProcessor != null)
        {
            var segments = _highlightProcessor.Process(text, defaultFg, defaultBg);
            foreach (var segment in segments)
            {
                var fg = Color.FromRgb(segment.ForegroundColor.R, segment.ForegroundColor.G, segment.ForegroundColor.B);
                var bg = segment.BackgroundColor != GenieColor.Transparent 
                    ? Color.FromRgb(segment.BackgroundColor.R, segment.BackgroundColor.G, segment.BackgroundColor.B)
                    : (Color?)null;
                AppendStyledText(segment.Text, fg, bg);
            }
        }
        else
        {
            AppendText(text, Color.Parse("#c9d1d9"));
        }
    }

    /// <summary>
    /// Appends styled text to a specific SelectableTextBlock.
    /// </summary>
    private void AppendStyledTextTo(SelectableTextBlock output, string text, Color foreground, Color? background = null)
    {
        if (string.IsNullOrEmpty(text)) return;
        
        var run = new Run(text)
        {
            Foreground = new SolidColorBrush(foreground)
        };
        
        if (background.HasValue)
        {
            run.Background = new SolidColorBrush(background.Value);
        }
        
        output.Inlines?.Add(run);
    }

    /// <summary>
    /// Appends styled text with foreground and optional background color using Inlines.
    /// </summary>
    private void AppendStyledText(string text, Color foreground, Color? background = null)
    {
        AppendStyledTextTo(GameOutput, text, foreground, background);
        OutputScroller.ScrollToEnd();
    }

    /// <summary>
    /// Appends plain text with the specified color (convenience method).
    /// </summary>
    private void AppendText(string text, Color color)
    {
        AppendStyledText(text, color);
    }

    /// <summary>
    /// Clears all text from the output.
    /// </summary>
    private void ClearOutput()
    {
        GameOutput.Inlines?.Clear();
    }
    
    /// <summary>
    /// Clears a specific window's output.
    /// </summary>
    private void ClearWindowOutput(GameWindowType windowType)
    {
        if (_windowOutputs.TryGetValue(windowType, out var output))
        {
            output.Inlines?.Clear();
        }
    }
}

