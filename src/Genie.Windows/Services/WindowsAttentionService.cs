using System;
using System.Runtime.InteropServices;
using GenieClient.Services;

namespace GenieClient.Windows.Services
{
    /// <summary>
    /// Windows implementation of IWindowAttentionService using FlashWindow P/Invoke.
    /// </summary>
    public sealed class WindowsAttentionService : IWindowAttentionService
    {
        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, EntryPoint = "FlashWindow")]
        private static extern bool NativeFlashWindow(IntPtr hwnd, bool bInvert);

        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        private const uint FLASHW_STOP = 0;
        private const uint FLASHW_CAPTION = 1;
        private const uint FLASHW_TRAY = 2;
        private const uint FLASHW_ALL = FLASHW_CAPTION | FLASHW_TRAY;
        private const uint FLASHW_TIMER = 4;
        private const uint FLASHW_TIMERNOFG = 12;

        public void RequestAttention(IntPtr windowHandle, bool critical = false)
        {
            if (windowHandle == IntPtr.Zero)
                return;

            var info = new FLASHWINFO
            {
                cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
                hwnd = windowHandle,
                dwFlags = critical ? FLASHW_ALL | FLASHW_TIMERNOFG : FLASHW_ALL | FLASHW_TIMER,
                uCount = critical ? uint.MaxValue : 5,
                dwTimeout = 0
            };

            FlashWindowEx(ref info);
        }

        public void CancelAttention(IntPtr windowHandle)
        {
            if (windowHandle == IntPtr.Zero)
                return;

            var info = new FLASHWINFO
            {
                cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
                hwnd = windowHandle,
                dwFlags = FLASHW_STOP,
                uCount = 0,
                dwTimeout = 0
            };

            FlashWindowEx(ref info);
        }

        public bool FlashWindow(IntPtr windowHandle, bool invert = true)
        {
            if (windowHandle == IntPtr.Zero)
                return false;

            return NativeFlashWindow(windowHandle, invert);
        }
    }
}

