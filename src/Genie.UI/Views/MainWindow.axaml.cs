using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using GenieClient.Services;
using System;

namespace GenieClient.Views;

public partial class MainWindow : Window
{
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
    }

    /// <summary>
    /// Updates the vital bars with the given percentages (0-100).
    /// </summary>
    public void UpdateVitals(int health, int mana, int fatigue, int spirit, int concentration)
    {
        UpdateBar(HealthBar, HealthText, health, "#22c55e");
        UpdateBar(ManaBar, ManaText, mana, "#3b82f6");
        UpdateBar(FatigueBar, FatigueText, fatigue, "#eab308");
        UpdateBar(SpiritBar, SpiritText, spirit, "#a855f7");
        UpdateBar(ConcentrationBar, ConcentrationText, concentration, "#06b6d4");
    }

    private void UpdateBar(Border bar, TextBlock text, int percent, string color)
    {
        percent = Math.Clamp(percent, 0, 100);
        text.Text = $"{percent}%";
        
        // Use RenderTransform with ScaleX to show percentage
        bar.RenderTransformOrigin = new Avalonia.RelativePoint(0, 0.5, Avalonia.RelativeUnit.Relative);
        bar.RenderTransform = new ScaleTransform(percent / 100.0, 1.0);
    }

    /// <summary>
    /// Updates the roundtime display.
    /// </summary>
    public void UpdateRoundtime(int seconds)
    {
        RoundtimeText.Text = seconds.ToString();
        RoundtimeText.Foreground = seconds > 0 
            ? new SolidColorBrush(Color.Parse("#e94560")) 
            : new SolidColorBrush(Color.Parse("#666"));
    }

    private void OnConnect(object? sender, RoutedEventArgs e)
    {
        AppendText("Connecting...\n", Colors.Yellow);
        // TODO: Show connection dialog and connect to game server
        StatusText.Text = "Connecting...";
        ConnectionStatus.Foreground = new SolidColorBrush(Colors.Yellow);
    }

    private void OnDisconnect(object? sender, RoutedEventArgs e)
    {
        AppendText("Disconnected.\n", Colors.Gray);
        StatusText.Text = "Disconnected";
        ConnectionStatus.Foreground = new SolidColorBrush(Color.Parse("#ef4444"));
    }

    private void OnExit(object? sender, RoutedEventArgs e)
    {
        Close();
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
                
                // TODO: Send command to game server
                // For now, just echo it back as a test
                if (command.Equals("test", StringComparison.OrdinalIgnoreCase))
                {
                    AppendText("This is a test response from Genie 5!\n", Colors.LightGreen);
                    AppendText("The cross-platform UI is working.\n", Colors.White);
                }
                else if (command.Equals("colors", StringComparison.OrdinalIgnoreCase))
                {
                    ShowColorTest();
                }
                else if (command.Equals("clear", StringComparison.OrdinalIgnoreCase))
                {
                    GameOutput.Text = "";
                }
                else if (command.Equals("vitals", StringComparison.OrdinalIgnoreCase))
                {
                    // Demo vitals at various levels
                    var rand = new Random();
                    UpdateVitals(rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100), rand.Next(20, 100));
                    UpdateRoundtime(rand.Next(0, 15));
                    AppendText("Vitals randomized!\n", Colors.Yellow);
                }
                else
                {
                    AppendText($"Command not recognized (not connected): {command}\n", Colors.Gray);
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

    private void AppendText(string text, Color color)
    {
        // For now, just append plain text
        // TODO: Implement rich text with colors using Avalonia's inline support
        GameOutput.Text += text;
        
        // Auto-scroll to bottom
        OutputScroller.ScrollToEnd();
    }
}

