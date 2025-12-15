using System;

namespace GenieClient.Services
{
    /// <summary>
    /// Specifies the edge of a window for resize operations.
    /// </summary>
    public enum WindowResizeEdge
    {
        Left = 10,
        Right = 11,
        Top = 12,
        TopLeft = 13,
        TopRight = 14,
        Bottom = 15,
        BottomLeft = 16,
        BottomRight = 17
    }

    /// <summary>
    /// Provides cross-platform custom window chrome/skinning operations.
    /// Abstracts Windows-specific WM_NCHITTEST handling and Avalonia's window chrome.
    /// </summary>
    public interface IWindowChromeService
    {
        /// <summary>
        /// Initiates a window drag operation (allows dragging from custom title bar areas).
        /// </summary>
        /// <param name="windowHandle">Native window handle.</param>
        void StartWindowDrag(IntPtr windowHandle);

        /// <summary>
        /// Initiates a window resize operation from a specific edge.
        /// </summary>
        /// <param name="windowHandle">Native window handle.</param>
        /// <param name="edge">The edge to resize from.</param>
        void StartWindowResize(IntPtr windowHandle, WindowResizeEdge edge);

        /// <summary>
        /// Releases mouse capture from the window.
        /// </summary>
        /// <param name="windowHandle">Native window handle.</param>
        /// <returns>True if successful.</returns>
        bool ReleaseCapture(IntPtr windowHandle);

        /// <summary>
        /// Sends a message to the window (Windows-specific, may be no-op on other platforms).
        /// </summary>
        /// <param name="windowHandle">Native window handle.</param>
        /// <param name="msg">Message identifier.</param>
        /// <param name="wParam">First message parameter.</param>
        /// <param name="lParam">Second message parameter.</param>
        /// <returns>Result of message processing.</returns>
        IntPtr SendMessage(IntPtr windowHandle, int msg, int wParam, int lParam);
    }
}

