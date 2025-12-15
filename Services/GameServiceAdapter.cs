using System;
using System.Drawing;
using System.Threading.Tasks;
using GenieClient.Genie;

namespace GenieClient.Services
{
    /// <summary>
    /// Adapter that wraps the existing Game class and implements IGameService.
    /// This allows gradual migration from the old Game class to the new service interface.
    /// 
    /// The adapter:
    /// - Converts GenieColor ↔ System.Drawing.Color at boundaries
    /// - Translates Game.WindowTarget ↔ OutputWindow enums
    /// - Wraps legacy events into the new strongly-typed event system
    /// </summary>
    public class GameServiceAdapter : IGameService
    {
        private readonly Game _game;
        private readonly Globals _globals;

        // State tracking for interface properties
        private RoomInfo _currentRoom = new();
        private CharacterVitals _vitals;
        private CharacterStatus _status;

        public GameServiceAdapter(Game game, Globals globals)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            _globals = globals ?? throw new ArgumentNullException(nameof(globals));

            // Wire up legacy events to new event system
            WireUpEvents();

            // Initialize vitals from globals
            UpdateVitalsFromGlobals();
        }

        #region Event Wiring

        private void WireUpEvents()
        {
            // Text output events
            _game.EventPrintText += OnGamePrintText;
            _game.EventPrintError += OnGamePrintError;
            _game.EventClearWindow += OnGameClearWindow;
            _game.EventAddImage += OnGameAddImage;

            // State events
            _game.EventRoundTime += OnGameRoundTime;
            _game.EventCastTime += OnGameCastTime;
            _game.EventSpellTime += OnGameSpellTime;
            _game.EventClearSpellTime += OnGameClearSpellTime;
            _game.EventStatusBarUpdate += OnGameStatusBarUpdate;
            _game.EventVariableChanged += OnGameVariableChanged;

            // Parse events
            _game.EventTriggerParse += OnGameTriggerParse;
            _game.EventTriggerPrompt += OnGameTriggerPrompt;
            _game.EventParseXML += OnGameParseXML;

            // Window events
            _game.EventStreamWindow += OnGameStreamWindow;

            // Data events
            _game.EventDataRecieveEnd += OnGameDataReceiveEnd;
        }

        private void OnGamePrintText(string text, Color color, Color bgcolor, Game.WindowTarget targetwindow, string targetwindowstring, bool mono, bool isprompt, bool isinput)
        {
            var args = new GameTextEventArgs(
                text,
                color.ToGenieColor(),
                bgcolor.ToGenieColor(),
                ConvertWindowTarget(targetwindow),
                string.IsNullOrEmpty(targetwindowstring) ? null : targetwindowstring,
                mono,
                isprompt,
                isinput
            );
            TextOutput?.Invoke(this, args);
        }

        private void OnGamePrintError(string text)
        {
            ErrorOutput?.Invoke(this, text);
        }

        private void OnGameClearWindow(string window)
        {
            ClearWindowRequested?.Invoke(this, window);
        }

        private void OnGameAddImage(string filename, string window, int width, int height)
        {
            ImageRequested?.Invoke(this, (filename, window, width, height));
        }

        private void OnGameRoundTime(int time)
        {
            RoundTimeChanged?.Invoke(this, time);
        }

        private void OnGameCastTime()
        {
            CastTimeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnGameSpellTime()
        {
            // Spell time update - could add specific event if needed
            CastTimeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnGameClearSpellTime()
        {
            // Clear spell time - could add specific event if needed
        }

        private void OnGameStatusBarUpdate()
        {
            // Update vitals from globals when status bar updates
            UpdateVitalsFromGlobals();
            VitalsChanged?.Invoke(this, new VitalsChangedEventArgs(_vitals));
        }

        private void OnGameVariableChanged(string variable)
        {
            VariableChanged?.Invoke(this, variable);

            // Check for status-related variables
            UpdateStatusFromGlobals();
        }

        private void OnGameTriggerParse(string text)
        {
            TriggerParse?.Invoke(this, text);
        }

        private void OnGameTriggerPrompt()
        {
            PromptReceived?.Invoke(this, EventArgs.Empty);
        }

        private void OnGameParseXML(string xml)
        {
            XmlReceived?.Invoke(this, xml);
        }

        private void OnGameStreamWindow(object id, object title, object ifClosed)
        {
            StreamWindowRequested?.Invoke(this, (id?.ToString() ?? "", title?.ToString() ?? "", ifClosed?.ToString() ?? ""));
        }

        private void OnGameDataReceiveEnd()
        {
            OutputFlush?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Helper Methods

        private void UpdateVitalsFromGlobals()
        {
            _vitals = new CharacterVitals
            {
                Health = ParseIntVariable("health", 100),
                Mana = ParseIntVariable("mana", 100),
                Spirit = ParseIntVariable("spirit", 100),
                Stamina = ParseIntVariable("stamina", 100),
                Concentration = ParseIntVariable("concentration", 100),
                Encumbrance = ParseIntVariable("encumbrance", 0)
            };
        }

        private void UpdateStatusFromGlobals()
        {
            var newStatus = CharacterStatus.None;

            if (ParseBoolVariable("kneeling")) newStatus |= CharacterStatus.Kneeling;
            if (ParseBoolVariable("prone")) newStatus |= CharacterStatus.Prone;
            if (ParseBoolVariable("sitting")) newStatus |= CharacterStatus.Sitting;
            if (ParseBoolVariable("standing")) newStatus |= CharacterStatus.Standing;
            if (ParseBoolVariable("stunned")) newStatus |= CharacterStatus.Stunned;
            if (ParseBoolVariable("hidden")) newStatus |= CharacterStatus.Hidden;
            if (ParseBoolVariable("invisible")) newStatus |= CharacterStatus.Invisible;
            if (ParseBoolVariable("dead")) newStatus |= CharacterStatus.Dead;
            if (ParseBoolVariable("webbed")) newStatus |= CharacterStatus.Webbed;
            if (ParseBoolVariable("joined")) newStatus |= CharacterStatus.Joined;
            if (ParseBoolVariable("bleeding")) newStatus |= CharacterStatus.Bleeding;
            if (ParseBoolVariable("poisoned")) newStatus |= CharacterStatus.Poisoned;
            if (ParseBoolVariable("diseased")) newStatus |= CharacterStatus.Diseased;

            if (_status != newStatus)
            {
                _status = newStatus;
                StatusChanged?.Invoke(this, _status);
            }
        }

        private int ParseIntVariable(string name, int defaultValue)
        {
            var value = _globals.VariableList[name];
            if (value != null && int.TryParse(value.ToString(), out int result))
                return result;
            return defaultValue;
        }

        private bool ParseBoolVariable(string name)
        {
            var value = _globals.VariableList[name];
            return value != null && value.ToString() == "1";
        }

        private static OutputWindow ConvertWindowTarget(Game.WindowTarget target)
        {
            return target switch
            {
                Game.WindowTarget.Main => OutputWindow.Main,
                Game.WindowTarget.Thoughts => OutputWindow.Thoughts,
                Game.WindowTarget.Room => OutputWindow.Room,
                Game.WindowTarget.Death => OutputWindow.Death,
                Game.WindowTarget.Familiar => OutputWindow.Familiar,
                Game.WindowTarget.Logons => OutputWindow.Logons,
                Game.WindowTarget.Combat => OutputWindow.Combat,
                Game.WindowTarget.Log => OutputWindow.Log,
                _ => OutputWindow.Main
            };
        }

        private static Game.WindowTarget ConvertOutputWindow(OutputWindow window)
        {
            return window switch
            {
                OutputWindow.Main => Game.WindowTarget.Main,
                OutputWindow.Thoughts => Game.WindowTarget.Thoughts,
                OutputWindow.Room => Game.WindowTarget.Room,
                OutputWindow.Death => Game.WindowTarget.Death,
                OutputWindow.Familiar => Game.WindowTarget.Familiar,
                OutputWindow.Logons => Game.WindowTarget.Logons,
                OutputWindow.Combat => Game.WindowTarget.Combat,
                OutputWindow.Log => Game.WindowTarget.Log,
                _ => Game.WindowTarget.Main
            };
        }

        #endregion

        #region IGameService Implementation - Properties

        public bool IsConnected => _game.IsConnected;

        public bool IsConnectedToGame => _game.IsConnectedToGame;

        public GameConnectionState ConnectionState
        {
            get
            {
                // Map internal state - for now just use connected/disconnected
                if (_game.IsConnectedToGame)
                    return GameConnectionState.ConnectedGame;
                if (_game.IsConnected)
                    return GameConnectionState.ConnectedGameHandshake;
                return GameConnectionState.Disconnected;
            }
        }

        public bool IsLich
        {
            get => _game.IsLich;
            set => _game.IsLich = value;
        }

        public string AccountName => _game.AccountName;

        public string CharacterName => _globals.VariableList["charactername"]?.ToString() ?? "";

        public string GameInstance => _game.AccountGame;

        public CharacterVitals Vitals => _vitals;

        public CharacterStatus Status => _status;

        public RoomInfo CurrentRoom => _currentRoom;

        public int RoundTime => ParseIntVariable("roundtime", 0);

        public int CastTime => ParseIntVariable("casttime", 0);

        public int GameTime => ParseIntVariable("gametime", 0);

        public bool ShowRawOutput
        {
            get => _game.ShowRawOutput;
            set => _game.ShowRawOutput = value;
        }

        #endregion

        #region IGameService Implementation - Connection Methods

        public Task ConnectAsync(string genieKey, string accountName, string password, string character, string game)
        {
            _game.Connect(genieKey, accountName, password, character, game);
            return Task.CompletedTask;
        }

        public Task DirectConnectAsync(string character, string game, string host, int port, string? key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                _game.DirectConnect(character, game, host, port);
            }
            else
            {
                _game.DirectConnect(character, game, host, port, key);
            }
            return Task.CompletedTask;
        }

        public void Disconnect(bool exitAfterDisconnect = false)
        {
            _game.Disconnect(exitAfterDisconnect);
        }

        #endregion

        #region IGameService Implementation - Communication Methods

        public void SendText(string text, bool isUserInput = false, string origin = "")
        {
            _game.SendText(text, isUserInput, origin);
        }

        public void SendRaw(string text)
        {
            _game.SendRaw(text);
        }

        #endregion

        #region IGameService Implementation - Parsing Methods

        public void ParseGameRow(string text)
        {
            _game.ParseGameRow(text);
        }

        public string ProcessXml(string xml)
        {
            return _game.ProcessXML(xml);
        }

        public void ResetIndicators()
        {
            _game.ResetIndicators();
            _status = CharacterStatus.None;
            StatusChanged?.Invoke(this, _status);
        }

        public void UpdateRoom()
        {
            _game.UpdateRoom();

            // Update room info from globals
            _currentRoom = new RoomInfo
            {
                Title = _globals.VariableList["roomname"]?.ToString() ?? "",
                Description = _globals.VariableList["roomdesc"]?.ToString() ?? "",
                Objects = _globals.VariableList["roomobjs"]?.ToString() ?? "",
                Players = _globals.VariableList["roomplayers"]?.ToString() ?? "",
                Exits = _globals.VariableList["roomexits"]?.ToString() ?? "",
                AvailableDirections = GetCompassDirections()
            };

            RoomChanged?.Invoke(this, new RoomChangedEventArgs(_currentRoom));
        }

        private CompassDirections GetCompassDirections()
        {
            var directions = CompassDirections.None;

            if (ParseBoolVariable("north")) directions |= CompassDirections.North;
            if (ParseBoolVariable("northeast")) directions |= CompassDirections.NorthEast;
            if (ParseBoolVariable("east")) directions |= CompassDirections.East;
            if (ParseBoolVariable("southeast")) directions |= CompassDirections.SouthEast;
            if (ParseBoolVariable("south")) directions |= CompassDirections.South;
            if (ParseBoolVariable("southwest")) directions |= CompassDirections.SouthWest;
            if (ParseBoolVariable("west")) directions |= CompassDirections.West;
            if (ParseBoolVariable("northwest")) directions |= CompassDirections.NorthWest;
            if (ParseBoolVariable("up")) directions |= CompassDirections.Up;
            if (ParseBoolVariable("down")) directions |= CompassDirections.Down;
            if (ParseBoolVariable("out")) directions |= CompassDirections.Out;

            return directions;
        }

        #endregion

        #region IGameService Events

        public event EventHandler<GameTextEventArgs>? TextOutput;
        public event EventHandler<string>? ErrorOutput;
        public event EventHandler<GameConnectionState>? ConnectionStateChanged;
        public event EventHandler<RoomChangedEventArgs>? RoomChanged;
        public event EventHandler<VitalsChangedEventArgs>? VitalsChanged;
        public event EventHandler<CharacterStatus>? StatusChanged;
        public event EventHandler<int>? RoundTimeChanged;
        public event EventHandler? CastTimeChanged;
        public event EventHandler<string>? VariableChanged;
        public event EventHandler<string>? TriggerParse;
        public event EventHandler? PromptReceived;
        public event EventHandler<string>? XmlReceived;
        public event EventHandler<string>? ClearWindowRequested;
        public event EventHandler<(string Id, string Title, string IfClosed)>? StreamWindowRequested;
        public event EventHandler<(string Filename, string Window, int Width, int Height)>? ImageRequested;
        public event EventHandler? OutputFlush;

        #endregion
    }
}

