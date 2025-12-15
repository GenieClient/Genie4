namespace GenieClient.Services
{
    /// <summary>
    /// Defines output window targets for game text.
    /// Platform-agnostic replacement for Game.WindowTarget enum.
    /// </summary>
    public enum OutputWindow
    {
        Main,
        Thoughts,
        Room,
        Death,
        Familiar,
        Assess,
        Whispers,
        Log,
        Conversation,
        Atmospherics,
        Logons,
        Combat,
        Percwindow,
        Combat2,
        Combat3,
        Custom  // For named custom windows
    }

    /// <summary>
    /// Represents a styled text segment for output.
    /// </summary>
    public readonly struct StyledText
    {
        public string Text { get; }
        public GenieColor ForegroundColor { get; }
        public GenieColor BackgroundColor { get; }
        public bool IsMonospace { get; }
        public bool IsPrompt { get; }
        public bool IsUserInput { get; }

        public StyledText(
            string text,
            GenieColor foregroundColor,
            GenieColor backgroundColor,
            bool isMonospace = false,
            bool isPrompt = false,
            bool isUserInput = false)
        {
            Text = text;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            IsMonospace = isMonospace;
            IsPrompt = isPrompt;
            IsUserInput = isUserInput;
        }

        public static StyledText Plain(string text) =>
            new(text, GenieColor.White, GenieColor.Transparent);

        public static StyledText Colored(string text, GenieColor foreground) =>
            new(text, foreground, GenieColor.Transparent);
    }

    /// <summary>
    /// Interface for receiving game output.
    /// Implemented by the UI layer to receive text, events, and status updates.
    /// This decouples the game logic from any specific UI framework.
    /// </summary>
    public interface IGameOutput
    {
        /// <summary>
        /// Writes styled text to a specified output window.
        /// </summary>
        void WriteText(StyledText text, OutputWindow window, string? customWindowName = null);

        /// <summary>
        /// Writes an error message.
        /// </summary>
        void WriteError(string message);

        /// <summary>
        /// Clears the specified output window.
        /// </summary>
        void ClearWindow(OutputWindow window, string? customWindowName = null);

        /// <summary>
        /// Updates the roundtime display.
        /// </summary>
        void UpdateRoundTime(int seconds);

        /// <summary>
        /// Updates the cast time display.
        /// </summary>
        void UpdateCastTime();

        /// <summary>
        /// Updates the spell time display.
        /// </summary>
        void UpdateSpellTime();

        /// <summary>
        /// Clears the spell time display.
        /// </summary>
        void ClearSpellTime();

        /// <summary>
        /// Updates the status bar.
        /// </summary>
        void UpdateStatusBar();

        /// <summary>
        /// Notifies that a variable has changed.
        /// </summary>
        void OnVariableChanged(string variableName);

        /// <summary>
        /// Adds an image to a window.
        /// </summary>
        void AddImage(string filename, OutputWindow window, string? customWindowName, int width, int height);

        /// <summary>
        /// Called when output batch is complete (for UI refresh optimization).
        /// </summary>
        void FlushOutput();

        /// <summary>
        /// Shows or creates a stream window.
        /// </summary>
        void ShowStreamWindow(string id, string title, string ifClosed);
    }
}

