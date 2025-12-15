using System;
using System.Runtime.InteropServices;

namespace GenieClient
{

    /// <summary>
/// Necessary native methods to import
/// </summary>
    public static class NativeMethods
    {
        static NativeMethods()
        {
        }

        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern bool FlashWindow(IntPtr hwnd, bool bInvert);
    }
}