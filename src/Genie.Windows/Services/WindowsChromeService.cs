using System;
using System.Runtime.InteropServices;
using GenieClient.Services;

namespace GenieClient.Windows.Services
{
    /// <summary>
    /// Windows implementation of IWindowChromeService for custom window chrome/skinning.
    /// </summary>
    public sealed class WindowsChromeService : IWindowChromeService
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Window messages for non-client area
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 2;

        public void StartWindowDrag(IntPtr windowHandle)
        {
            if (windowHandle == IntPtr.Zero)
                return;

            ReleaseCapture();
            SendMessage(windowHandle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        public void StartWindowResize(IntPtr windowHandle, WindowResizeEdge edge)
        {
            if (windowHandle == IntPtr.Zero)
                return;

            ReleaseCapture();
            SendMessage(windowHandle, WM_NCLBUTTONDOWN, (int)edge, 0);
        }

        bool IWindowChromeService.ReleaseCapture(IntPtr windowHandle)
        {
            return ReleaseCapture();
        }

        IntPtr IWindowChromeService.SendMessage(IntPtr windowHandle, int msg, int wParam, int lParam)
        {
            return SendMessage(windowHandle, msg, wParam, lParam);
        }
    }
}

