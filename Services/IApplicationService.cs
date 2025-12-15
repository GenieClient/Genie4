using System;

namespace GenieClient.Services
{
    /// <summary>
    /// Abstracts application lifecycle operations for cross-platform support.
    /// Implemented by the platform-specific UI layer.
    /// </summary>
    public interface IApplicationService
    {
        /// <summary>
        /// Exits the application gracefully.
        /// </summary>
        void Exit();

        /// <summary>
        /// Requests the application to restart.
        /// </summary>
        void Restart();

        /// <summary>
        /// Gets whether the application is running.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Invokes an action on the UI thread.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        void InvokeOnUIThread(Action action);

        /// <summary>
        /// Invokes an action on the UI thread asynchronously.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        void BeginInvokeOnUIThread(Action action);
    }
}

