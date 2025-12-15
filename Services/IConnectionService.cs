using System;
using System.Threading.Tasks;

namespace GenieClient.Services
{
    /// <summary>
    /// Connection state for the game server.
    /// </summary>
    public enum ConnectionState
    {
        Disconnected,
        Connecting,
        Connected,
        Authenticating,
        Authenticated,
        ConnectionLost
    }

    /// <summary>
    /// Event arguments for received data.
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        public string Data { get; }
        public bool IsPartial { get; }

        public DataReceivedEventArgs(string data, bool isPartial = false)
        {
            Data = data;
            IsPartial = isPartial;
        }
    }

    /// <summary>
    /// Event arguments for connection state changes.
    /// </summary>
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        public ConnectionState OldState { get; }
        public ConnectionState NewState { get; }
        public string? Message { get; }

        public ConnectionStateChangedEventArgs(ConnectionState oldState, ConnectionState newState, string? message = null)
        {
            OldState = oldState;
            NewState = newState;
            Message = message;
        }
    }

    /// <summary>
    /// Abstracts the network connection to the game server.
    /// Allows for easier testing and potential future transport alternatives.
    /// </summary>
    public interface IConnectionService
    {
        /// <summary>
        /// Gets the current connection state.
        /// </summary>
        ConnectionState State { get; }

        /// <summary>
        /// Gets whether the connection is currently active.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets the last time data was received from the server.
        /// </summary>
        DateTime LastServerActivity { get; }

        /// <summary>
        /// Connects to the specified host and port.
        /// </summary>
        Task ConnectAsync(string hostname, int port);

        /// <summary>
        /// Connects with SSL/TLS authentication.
        /// </summary>
        Task ConnectWithSslAsync(string hostname, int port);

        /// <summary>
        /// Authenticates with the server using account credentials.
        /// </summary>
        /// <returns>True if authentication succeeded.</returns>
        Task<bool> AuthenticateAsync(string account, string password);

        /// <summary>
        /// Gets the login key for a specific character.
        /// </summary>
        /// <returns>Login key string or error message.</returns>
        Task<string> GetLoginKeyAsync(string instance, string character);

        /// <summary>
        /// Sends text to the server.
        /// </summary>
        void Send(string text);

        /// <summary>
        /// Sends raw bytes to the server.
        /// </summary>
        void Send(byte[] data);

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        /// <param name="exitAfterDisconnect">If true, exit the application after disconnect.</param>
        void Disconnect(bool exitAfterDisconnect = false);

        /// <summary>
        /// Raised when a complete line of data is received.
        /// </summary>
        event EventHandler<DataReceivedEventArgs>? DataReceived;

        /// <summary>
        /// Raised when partial data is received (for prompts, etc.).
        /// </summary>
        event EventHandler<DataReceivedEventArgs>? PartialDataReceived;

        /// <summary>
        /// Raised when the connection state changes.
        /// </summary>
        event EventHandler<ConnectionStateChangedEventArgs>? StateChanged;

        /// <summary>
        /// Raised when data is sent to the server.
        /// </summary>
        event EventHandler? DataSent;
    }
}

