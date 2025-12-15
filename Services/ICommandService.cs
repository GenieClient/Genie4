using System;
using System.Threading.Tasks;

namespace GenieClient.Services
{
    #region Event Args

    /// <summary>
    /// Event args for connection requests.
    /// </summary>
    public class ConnectRequestEventArgs : EventArgs
    {
        public string AccountName { get; }
        public string Password { get; }
        public string Character { get; }
        public string Game { get; }
        public bool IsLich { get; }

        public ConnectRequestEventArgs(string accountName, string password, string character, string game, bool isLich = false)
        {
            AccountName = accountName;
            Password = password;
            Character = character;
            Game = game;
            IsLich = isLich;
        }
    }

    /// <summary>
    /// Event args for text echo operations.
    /// </summary>
    public class EchoTextEventArgs : EventArgs
    {
        public string Text { get; }
        public string? WindowName { get; }
        public GenieColor? ForegroundColor { get; }
        public GenieColor? BackgroundColor { get; }

        public EchoTextEventArgs(string text, string? windowName = null, GenieColor? foreground = null, GenieColor? background = null)
        {
            Text = text;
            WindowName = windowName;
            ForegroundColor = foreground;
            BackgroundColor = background;
        }
    }

    /// <summary>
    /// Event args for link creation.
    /// </summary>
    public class LinkTextEventArgs : EventArgs
    {
        public string Text { get; }
        public string Command { get; }
        public string? WindowName { get; }

        public LinkTextEventArgs(string text, string command, string? windowName = null)
        {
            Text = text;
            Command = command;
            WindowName = windowName;
        }
    }

    /// <summary>
    /// Event args for window operations.
    /// </summary>
    public class WindowEventArgs : EventArgs
    {
        public string WindowName { get; }
        public int? Width { get; }
        public int? Height { get; }
        public int? Top { get; }
        public int? Left { get; }

        public WindowEventArgs(string windowName, int? width = null, int? height = null, int? top = null, int? left = null)
        {
            WindowName = windowName;
            Width = width;
            Height = height;
            Top = top;
            Left = left;
        }
    }

    /// <summary>
    /// Event args for script operations.
    /// </summary>
    public class ScriptEventArgs : EventArgs
    {
        public string ScriptName { get; }
        public string? Filter { get; }
        public int DebugLevel { get; }

        public ScriptEventArgs(string scriptName, string? filter = null, int debugLevel = 0)
        {
            ScriptName = scriptName;
            Filter = filter;
            DebugLevel = debugLevel;
        }
    }

    /// <summary>
    /// Event args for plugin operations.
    /// </summary>
    public class PluginEventArgs : EventArgs
    {
        public string PluginName { get; }

        public PluginEventArgs(string pluginName)
        {
            PluginName = pluginName;
        }
    }

    /// <summary>
    /// Event args for status bar updates.
    /// </summary>
    public class StatusBarEventArgs : EventArgs
    {
        public string Text { get; }
        public int Index { get; }

        public StatusBarEventArgs(string text, int index)
        {
            Text = text;
            Index = index;
        }
    }

    /// <summary>
    /// Event args for image display.
    /// </summary>
    public class ImageEventArgs : EventArgs
    {
        public string Filename { get; }
        public string? WindowName { get; }
        public int Width { get; }
        public int Height { get; }

        public ImageEventArgs(string filename, string? windowName = null, int width = 0, int height = 0)
        {
            Filename = filename;
            WindowName = windowName;
            Width = width;
            Height = height;
        }
    }

    #endregion

    /// <summary>
    /// Abstracts the command parsing and execution system.
    /// Handles user commands (#echo, #var, #script, etc.), aliases, and event firing.
    /// </summary>
    public interface ICommandService
    {
        #region Command Processing

        /// <summary>
        /// Parses and executes a command string.
        /// </summary>
        /// <param name="text">The command text to parse.</param>
        /// <param name="sendToGame">If true, send unrecognized commands to the game server.</param>
        /// <param name="isUserInput">Whether this is direct user input.</param>
        /// <param name="origin">Origin identifier (e.g., script name).</param>
        /// <param name="parseQuickSend">Whether to parse quick-send characters.</param>
        /// <returns>The result of command processing.</returns>
        Task<string> ParseCommandAsync(string text, bool sendToGame = false, bool isUserInput = false, string origin = "", bool parseQuickSend = true);

        /// <summary>
        /// Evaluates an expression and returns the result.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        /// <returns>The evaluation result as a string.</returns>
        string Evaluate(string expression);

        #endregion

        #region Text Output Events

        /// <summary>
        /// Raised when text should be echoed to a window.
        /// </summary>
        event EventHandler<EchoTextEventArgs>? EchoText;

        /// <summary>
        /// Raised when a clickable link should be displayed.
        /// </summary>
        event EventHandler<LinkTextEventArgs>? LinkText;

        /// <summary>
        /// Raised when a window should be cleared.
        /// </summary>
        event EventHandler<string>? ClearWindow;

        /// <summary>
        /// Raised when an image should be displayed.
        /// </summary>
        event EventHandler<ImageEventArgs>? DisplayImage;

        #endregion

        #region Connection Events

        /// <summary>
        /// Raised when a connection is requested.
        /// </summary>
        event EventHandler<ConnectRequestEventArgs>? ConnectRequested;

        /// <summary>
        /// Raised when reconnection is requested.
        /// </summary>
        event EventHandler? ReconnectRequested;

        /// <summary>
        /// Raised when disconnection is requested.
        /// </summary>
        event EventHandler? DisconnectRequested;

        /// <summary>
        /// Raised when application exit is requested.
        /// </summary>
        event EventHandler? ExitRequested;

        #endregion

        #region Data Events

        /// <summary>
        /// Raised when text should be sent to the game server.
        /// </summary>
        event EventHandler<(string Text, bool IsUserInput, string Origin)>? SendText;

        /// <summary>
        /// Raised when raw data should be sent to the game server.
        /// </summary>
        event EventHandler<string>? SendRaw;

        /// <summary>
        /// Raised when data should be copied (e.g., to another application).
        /// </summary>
        event EventHandler<(string Destination, string Data)>? CopyData;

        /// <summary>
        /// Raised when text should be parsed for triggers.
        /// </summary>
        event EventHandler<string>? ParseLine;

        #endregion

        #region Variable Events

        /// <summary>
        /// Raised when a variable has changed.
        /// </summary>
        event EventHandler<string>? VariableChanged;

        /// <summary>
        /// Raised when a preset color has changed.
        /// </summary>
        event EventHandler<string>? PresetChanged;

        /// <summary>
        /// Raised when class settings have changed.
        /// </summary>
        event EventHandler? ClassChanged;

        #endregion

        #region Script Events

        /// <summary>
        /// Raised when a script should be run.
        /// </summary>
        event EventHandler<string>? RunScript;

        /// <summary>
        /// Raised when scripts should be listed.
        /// </summary>
        event EventHandler<string?>? ListScripts;

        /// <summary>
        /// Raised when script trace is toggled.
        /// </summary>
        event EventHandler<string>? ScriptTrace;

        /// <summary>
        /// Raised when a script should be aborted.
        /// </summary>
        event EventHandler<string>? ScriptAbort;

        /// <summary>
        /// Raised when a script should be paused.
        /// </summary>
        event EventHandler<string>? ScriptPause;

        /// <summary>
        /// Raised when a script should be paused or resumed (toggle).
        /// </summary>
        event EventHandler<string>? ScriptPauseOrResume;

        /// <summary>
        /// Raised when a script should be resumed.
        /// </summary>
        event EventHandler<string>? ScriptResume;

        /// <summary>
        /// Raised when a script should be reloaded.
        /// </summary>
        event EventHandler<string>? ScriptReload;

        /// <summary>
        /// Raised when script debug level should change.
        /// </summary>
        event EventHandler<ScriptEventArgs>? ScriptDebug;

        /// <summary>
        /// Raised when script variables should be displayed.
        /// </summary>
        event EventHandler<ScriptEventArgs>? ScriptVariables;

        /// <summary>
        /// Raised when script explorer should be shown.
        /// </summary>
        event EventHandler? ShowScriptExplorer;

        #endregion

        #region Window Events

        /// <summary>
        /// Raised when a window should be added/created.
        /// </summary>
        event EventHandler<WindowEventArgs>? AddWindow;

        /// <summary>
        /// Raised when a window should be repositioned/resized.
        /// </summary>
        event EventHandler<WindowEventArgs>? PositionWindow;

        /// <summary>
        /// Raised when a window should be removed.
        /// </summary>
        event EventHandler<string>? RemoveWindow;

        /// <summary>
        /// Raised when a window should be closed.
        /// </summary>
        event EventHandler<string>? CloseWindow;

        /// <summary>
        /// Raised when a window title should change.
        /// </summary>
        event EventHandler<(string Window, string Title)>? ChangeWindowTitle;

        #endregion

        #region UI Events

        /// <summary>
        /// Raised when the status bar should be updated.
        /// </summary>
        event EventHandler<StatusBarEventArgs>? StatusBarUpdate;

        /// <summary>
        /// Raised when the window should flash.
        /// </summary>
        event EventHandler? FlashWindow;

        /// <summary>
        /// Raised when the application icon should change.
        /// </summary>
        event EventHandler<string>? ChangeIcon;

        /// <summary>
        /// Raised when raw output mode should toggle.
        /// </summary>
        event EventHandler<string>? RawToggle;

        /// <summary>
        /// Raised to launch a browser with a URL.
        /// </summary>
        event EventHandler<string>? LaunchBrowser;

        #endregion

        #region Layout Events

        /// <summary>
        /// Raised when a layout should be loaded.
        /// </summary>
        event EventHandler<string>? LoadLayout;

        /// <summary>
        /// Raised when the layout should be saved.
        /// </summary>
        event EventHandler<string>? SaveLayout;

        /// <summary>
        /// Raised when the profile should be loaded.
        /// </summary>
        event EventHandler? LoadProfile;

        /// <summary>
        /// Raised when the profile should be saved.
        /// </summary>
        event EventHandler? SaveProfile;

        #endregion

        #region Plugin Events

        /// <summary>
        /// Raised when a plugin should be loaded.
        /// </summary>
        event EventHandler<string>? LoadPlugin;

        /// <summary>
        /// Raised when a plugin should be unloaded.
        /// </summary>
        event EventHandler<string>? UnloadPlugin;

        /// <summary>
        /// Raised when a plugin should be enabled.
        /// </summary>
        event EventHandler<string>? EnablePlugin;

        /// <summary>
        /// Raised when a plugin should be disabled.
        /// </summary>
        event EventHandler<string>? DisablePlugin;

        /// <summary>
        /// Raised when plugins should be reloaded.
        /// </summary>
        event EventHandler? ReloadPlugins;

        /// <summary>
        /// Raised when plugins should be listed.
        /// </summary>
        event EventHandler? ListPlugins;

        #endregion

        #region Mapper Events

        /// <summary>
        /// Raised when a mapper command should be executed.
        /// </summary>
        event EventHandler<string>? MapperCommand;

        #endregion
    }
}

