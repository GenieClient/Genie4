using System;
using System.Threading.Tasks;

namespace GenieClient.Services
{
    /// <summary>
    /// Game connection states.
    /// </summary>
    public enum GameConnectionState
    {
        Disconnected,
        ConnectingKeyServer,
        ConnectingGameServer,
        ConnectedKey,
        ConnectedGameHandshake,
        ConnectedGame
    }

    /// <summary>
    /// Game character status indicators.
    /// </summary>
    [Flags]
    public enum CharacterStatus
    {
        None = 0,
        Kneeling = 1 << 0,
        Prone = 1 << 1,
        Sitting = 1 << 2,
        Standing = 1 << 3,
        Stunned = 1 << 4,
        Hidden = 1 << 5,
        Invisible = 1 << 6,
        Dead = 1 << 7,
        Webbed = 1 << 8,
        Joined = 1 << 9,
        Bleeding = 1 << 10,
        Poisoned = 1 << 11,
        Diseased = 1 << 12
    }

    /// <summary>
    /// Compass/direction information.
    /// </summary>
    [Flags]
    public enum CompassDirections
    {
        None = 0,
        North = 1 << 0,
        NorthEast = 1 << 1,
        East = 1 << 2,
        SouthEast = 1 << 3,
        South = 1 << 4,
        SouthWest = 1 << 5,
        West = 1 << 6,
        NorthWest = 1 << 7,
        Up = 1 << 8,
        Down = 1 << 9,
        Out = 1 << 10
    }

    /// <summary>
    /// Represents vital statistics for a character.
    /// </summary>
    public readonly struct CharacterVitals
    {
        public int Health { get; init; }
        public int Mana { get; init; }
        public int Spirit { get; init; }
        public int Stamina { get; init; }
        public int Concentration { get; init; }
        public int Encumbrance { get; init; }
    }

    /// <summary>
    /// Represents room information.
    /// </summary>
    public class RoomInfo
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Objects { get; set; } = string.Empty;
        public string Players { get; set; } = string.Empty;
        public string Exits { get; set; } = string.Empty;
        public CompassDirections AvailableDirections { get; set; }
    }

    /// <summary>
    /// Event args for text output events.
    /// </summary>
    public class GameTextEventArgs : EventArgs
    {
        public string Text { get; }
        public GenieColor ForegroundColor { get; }
        public GenieColor BackgroundColor { get; }
        public OutputWindow Window { get; }
        public string? CustomWindowName { get; }
        public bool IsMonospace { get; }
        public bool IsPrompt { get; }
        public bool IsUserInput { get; }

        public GameTextEventArgs(
            string text,
            GenieColor foregroundColor,
            GenieColor backgroundColor,
            OutputWindow window,
            string? customWindowName = null,
            bool isMonospace = false,
            bool isPrompt = false,
            bool isUserInput = false)
        {
            Text = text;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            Window = window;
            CustomWindowName = customWindowName;
            IsMonospace = isMonospace;
            IsPrompt = isPrompt;
            IsUserInput = isUserInput;
        }
    }

    /// <summary>
    /// Event args for room updates.
    /// </summary>
    public class RoomChangedEventArgs : EventArgs
    {
        public RoomInfo Room { get; }

        public RoomChangedEventArgs(RoomInfo room)
        {
            Room = room;
        }
    }

    /// <summary>
    /// Event args for vitals updates.
    /// </summary>
    public class VitalsChangedEventArgs : EventArgs
    {
        public CharacterVitals Vitals { get; }

        public VitalsChangedEventArgs(CharacterVitals vitals)
        {
            Vitals = vitals;
        }
    }

    /// <summary>
    /// Abstracts the game protocol and state management.
    /// Handles communication with the game server and parsing of game data.
    /// </summary>
    public interface IGameService
    {
        #region Connection Properties

        /// <summary>
        /// Gets whether the game is connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets whether the game connection is fully established (past handshake).
        /// </summary>
        bool IsConnectedToGame { get; }

        /// <summary>
        /// Gets the current connection state.
        /// </summary>
        GameConnectionState ConnectionState { get; }

        /// <summary>
        /// Gets whether using Lich as middleware.
        /// </summary>
        bool IsLich { get; set; }

        #endregion

        #region Account Properties

        /// <summary>
        /// Gets the account name.
        /// </summary>
        string AccountName { get; }

        /// <summary>
        /// Gets the character name.
        /// </summary>
        string CharacterName { get; }

        /// <summary>
        /// Gets the game instance (DR, DRX, DRF, etc.).
        /// </summary>
        string GameInstance { get; }

        #endregion

        #region Game State Properties

        /// <summary>
        /// Gets the current character vitals.
        /// </summary>
        CharacterVitals Vitals { get; }

        /// <summary>
        /// Gets the current character status flags.
        /// </summary>
        CharacterStatus Status { get; }

        /// <summary>
        /// Gets the current room information.
        /// </summary>
        RoomInfo CurrentRoom { get; }

        /// <summary>
        /// Gets the current roundtime in seconds.
        /// </summary>
        int RoundTime { get; }

        /// <summary>
        /// Gets the current spell/cast time in seconds.
        /// </summary>
        int CastTime { get; }

        /// <summary>
        /// Gets the game time.
        /// </summary>
        int GameTime { get; }

        /// <summary>
        /// Gets or sets whether to show raw game output for debugging.
        /// </summary>
        bool ShowRawOutput { get; set; }

        #endregion

        #region Connection Methods

        /// <summary>
        /// Connects to the game using account credentials.
        /// </summary>
        Task ConnectAsync(string genieKey, string accountName, string password, string character, string game);

        /// <summary>
        /// Connects directly to a game server (for Lich or direct connections).
        /// </summary>
        Task DirectConnectAsync(string character, string game, string host, int port, string? key = null);

        /// <summary>
        /// Disconnects from the game.
        /// </summary>
        void Disconnect(bool exitAfterDisconnect = false);

        #endregion

        #region Communication Methods

        /// <summary>
        /// Sends text to the game server.
        /// </summary>
        /// <param name="text">Text to send.</param>
        /// <param name="isUserInput">Whether this is direct user input.</param>
        /// <param name="origin">Origin identifier (e.g., script name).</param>
        void SendText(string text, bool isUserInput = false, string origin = "");

        /// <summary>
        /// Sends raw data to the game server (no formatting).
        /// </summary>
        void SendRaw(string text);

        #endregion

        #region Parsing Methods

        /// <summary>
        /// Parses a row of game text.
        /// </summary>
        void ParseGameRow(string text);

        /// <summary>
        /// Processes XML data from the game.
        /// </summary>
        string ProcessXml(string xml);

        /// <summary>
        /// Resets all status indicators to default.
        /// </summary>
        void ResetIndicators();

        /// <summary>
        /// Triggers a room update.
        /// </summary>
        void UpdateRoom();

        #endregion

        #region Events

        /// <summary>
        /// Raised when text should be displayed.
        /// </summary>
        event EventHandler<GameTextEventArgs>? TextOutput;

        /// <summary>
        /// Raised when an error should be displayed.
        /// </summary>
        event EventHandler<string>? ErrorOutput;

        /// <summary>
        /// Raised when connection state changes.
        /// </summary>
        event EventHandler<GameConnectionState>? ConnectionStateChanged;

        /// <summary>
        /// Raised when the room changes.
        /// </summary>
        event EventHandler<RoomChangedEventArgs>? RoomChanged;

        /// <summary>
        /// Raised when character vitals change.
        /// </summary>
        event EventHandler<VitalsChangedEventArgs>? VitalsChanged;

        /// <summary>
        /// Raised when character status changes.
        /// </summary>
        event EventHandler<CharacterStatus>? StatusChanged;

        /// <summary>
        /// Raised when roundtime updates.
        /// </summary>
        event EventHandler<int>? RoundTimeChanged;

        /// <summary>
        /// Raised when cast/spell time updates.
        /// </summary>
        event EventHandler? CastTimeChanged;

        /// <summary>
        /// Raised when a variable changes.
        /// </summary>
        event EventHandler<string>? VariableChanged;

        /// <summary>
        /// Raised when text should be parsed for triggers.
        /// </summary>
        event EventHandler<string>? TriggerParse;

        /// <summary>
        /// Raised when a game prompt is received.
        /// </summary>
        event EventHandler? PromptReceived;

        /// <summary>
        /// Raised when XML should be passed to plugins.
        /// </summary>
        event EventHandler<string>? XmlReceived;

        /// <summary>
        /// Raised when a window clear is requested.
        /// </summary>
        event EventHandler<string>? ClearWindowRequested;

        /// <summary>
        /// Raised when a stream window should be shown.
        /// </summary>
        event EventHandler<(string Id, string Title, string IfClosed)>? StreamWindowRequested;

        /// <summary>
        /// Raised when an image should be added.
        /// </summary>
        event EventHandler<(string Filename, string Window, int Width, int Height)>? ImageRequested;

        /// <summary>
        /// Raised when output batch is complete.
        /// </summary>
        event EventHandler? OutputFlush;

        #endregion
    }
}

