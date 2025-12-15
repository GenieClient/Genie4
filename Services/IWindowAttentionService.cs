using System;

namespace GenieClient.Services
{
    /// <summary>
    /// Provides cross-platform window attention/flashing.
    /// Abstracts the Windows FlashWindow P/Invoke and macOS/Linux equivalents.
    /// </summary>
    public interface IWindowAttentionService
    {
        /// <summary>
        /// Requests the user's attention by flashing the window or taskbar.
        /// </summary>
        /// <param name="windowHandle">Platform-specific window handle (IntPtr on Windows).</param>
        /// <param name="critical">If true, flash until the window is focused. If false, flash briefly.</param>
        void RequestAttention(IntPtr windowHandle, bool critical = false);

        /// <summary>
        /// Stops any ongoing window attention animation.
        /// </summary>
        /// <param name="windowHandle">Platform-specific window handle.</param>
        void CancelAttention(IntPtr windowHandle);

        /// <summary>
        /// Flashes the window once. Simple one-shot flash.
        /// </summary>
        /// <param name="windowHandle">Platform-specific window handle.</param>
        /// <param name="invert">Whether to invert the window state.</param>
        /// <returns>True if the window was active before the flash.</returns>
        bool FlashWindow(IntPtr windowHandle, bool invert = true);
    }
}

