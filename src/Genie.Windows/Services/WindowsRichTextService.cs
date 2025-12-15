using System;
using System.Runtime.InteropServices;
using GenieClient.Services;

namespace GenieClient.Windows.Services
{
    /// <summary>
    /// Windows implementation of IRichTextService using Win32 APIs for RichTextBox control.
    /// </summary>
    public sealed class WindowsRichTextService : IRichTextService
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool GetScrollInfo(IntPtr hWnd, int nBar, ref SCROLLINFO lpScrollInfo);

        [DllImport("user32.dll")]
        private static extern bool SetScrollInfo(IntPtr hWnd, int nBar, ref SCROLLINFO lpScrollInfo, bool fRedraw);

        [StructLayout(LayoutKind.Sequential)]
        private struct SCROLLINFO
        {
            public int cbSize;
            public int fMask;
            public int nMin;
            public int nMax;
            public int nPage;
            public int nPos;
            public int nTrackPos;
        }

        // Window messages
        private const int WM_SETREDRAW = 0xB;
        private const int WM_USER = 0x400;
        private const int EM_SETEVENTMASK = WM_USER + 69;
        private const int EM_GETFIRSTVISIBLELINE = 0xCE;
        private const int EM_LINESCROLL = 0xB6;

        // Scroll bar constants
        private const int SBS_VERT = 1;
        private const int SIF_RANGE = 1;
        private const int SIF_PAGE = 2;
        private const int SIF_POS = 4;
        private const int SIF_TRACKPOS = 16;
        private const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;

        // Instance state for tracking update nesting
        private int _updatingCount = 0;
        private int _eventMaskOld = 0;
        private IntPtr _lastHandle = IntPtr.Zero;

        public void BeginUpdate(IntPtr controlHandle)
        {
            if (controlHandle == IntPtr.Zero)
                return;

            _updatingCount++;
            if (_updatingCount > 1)
                return;

            _lastHandle = controlHandle;
            _eventMaskOld = (int)SendMessage(controlHandle, EM_SETEVENTMASK, 1, 0);
            SendMessage(controlHandle, WM_SETREDRAW, 0, 0);
        }

        public void EndUpdate(IntPtr controlHandle)
        {
            if (controlHandle == IntPtr.Zero)
                return;

            _updatingCount--;
            if (_updatingCount > 0)
                return;

            if (_updatingCount < 0)
                _updatingCount = 0;

            SendMessage(controlHandle, WM_SETREDRAW, 1, 0);
            SendMessage(controlHandle, EM_SETEVENTMASK, 0, _eventMaskOld);
        }

        public int GetFirstVisibleLine(IntPtr controlHandle)
        {
            if (controlHandle == IntPtr.Zero)
                return 0;

            return (int)SendMessage(controlHandle, EM_GETFIRSTVISIBLELINE, 0, 0);
        }

        public void ScrollByLines(IntPtr controlHandle, int lineCount)
        {
            if (controlHandle == IntPtr.Zero)
                return;

            SendMessage(controlHandle, EM_LINESCROLL, 0, lineCount);
        }

        public int GetScrollPosition(IntPtr controlHandle)
        {
            if (controlHandle == IntPtr.Zero)
                return 0;

            var scrollInfo = new SCROLLINFO
            {
                cbSize = Marshal.SizeOf<SCROLLINFO>(),
                fMask = SIF_ALL
            };

            GetScrollInfo(controlHandle, SBS_VERT, ref scrollInfo);
            return scrollInfo.nPos;
        }

        public bool SetScrollPosition(IntPtr controlHandle, int position)
        {
            if (controlHandle == IntPtr.Zero)
                return false;

            var scrollInfo = new SCROLLINFO
            {
                cbSize = Marshal.SizeOf<SCROLLINFO>(),
                fMask = SIF_ALL,
                nPos = position
            };

            return SetScrollInfo(controlHandle, SBS_VERT, ref scrollInfo, true);
        }
    }
}

