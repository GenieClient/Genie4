using System;
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

    // Events for UI to subscribe to
    public event Action<string, GenieColor, GenieColor>? TextReceived;
    public event Action<string>? ErrorReceived;
    public event Action? Connected;
    public event Action? Disconnected;
    public event Action<string, string>? VariableChanged;
    public event Action<int, int, int, int, int>? VitalsChanged;
    public event Action<int>? RoundtimeChanged;

    public bool IsConnected => _game?.IsConnected ?? false;
    public string? LastError { get; private set; }

    public GameManager()
    {
        // Defer initialization to avoid constructor crashes
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
            
            Console.WriteLine("[GameManager] Subscribing to events...");
            _game.EventPrintText += OnGamePrintText;
            _game.EventPrintError += OnGamePrintError;
            _game.EventVariableChanged += OnVariableChanged;
            
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
        // Filter out control markers that shouldn't be displayed
        var trimmedText = text?.Trim() ?? "";
        if (trimmedText == "@suspend@" || trimmedText == "@resume@")
        {
            return; // These are window batching control signals, don't display
        }
        
        // Forward to UI on main thread
        TextReceived?.Invoke(text, color, bgcolor);
        
        // Check for vital updates in the globals
        CheckVitals();
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
                
                // Update roundtime
                if (varName == "roundtime")
                {
                    if (int.TryParse(value, out int rt))
                    {
                        RoundtimeChanged?.Invoke(rt);
                    }
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

        if (_game != null)
        {
            try
            {
                _game.EventPrintText -= OnGamePrintText;
                _game.EventPrintError -= OnGamePrintError;
                _game.EventVariableChanged -= OnVariableChanged;
                
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

