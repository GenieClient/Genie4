using System;
using System.Runtime.InteropServices;

namespace GenieClient
{
    public class Win32Utility
    {
        [DllImport("user32")]
        private static extern int GetTopWindow(int hwnd);
        [DllImport("user32", EntryPoint = "GetWindow")]
        private static extern int GetNextWindow(int hwnd, int wFlag);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessageA(IntPtr hwnd, int wMsg, int wParam, int lParam);





        private const int WM_SETREDRAW = 0xB;
        private const int EM_GETFIRSTVISIBLELINE = 0xCE;
        private const int EM_LINESCROLL = 0xB6;
        // private const int EM_GETLINECOUNT = 0xBA;

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

        [DllImport("user32.dll")]
        private static extern bool GetScrollInfo(IntPtr hWnd, int nBar, SCROLLINFO lpScrollInfo);



        [DllImport("user32.dll")]
        private static extern bool SetScrollInfo(IntPtr hWnd, int nBar, SCROLLINFO lpScrollInfo, bool fRedraw);





        public const int WM_USER = 0x400;
        public const int EM_SETEVENTMASK = WM_USER + 69;
        private static int UpdatingCount = 0;
        private static int EventMaskOld = 0;
        private SCROLLINFO sc = new SCROLLINFO();
        private const int SBS_HORZ = 0;
        private const int SBS_VERT = 1;
        private const int SIF_RANGE = 1;
        private const int SIF_PAGE = 2;
        private const int SIF_POS = 4;
        private const int SIF_DISABLENOSCROLL = 8;
        private const int SIF_TRACKPOS = 10;
        private const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;

        public int GetFirstLineVisible(IntPtr hwnd)
        {
            return (int)SendMessage(hwnd, EM_GETFIRSTVISIBLELINE, 0, 0);
        }

        public void LineScroll(IntPtr hwnd, int line)
        {
            SendMessage(hwnd, EM_LINESCROLL, 0, line);
        }

        public int GetScrollPos(IntPtr hwnd)
        {
            sc.fMask = SIF_ALL;
            sc.cbSize = Marshal.SizeOf(sc);
            GetScrollInfo(hwnd, SBS_VERT, sc);
            return sc.nPos;
        }

        public bool SetScrollPos(IntPtr hwnd, int pos)
        {
            sc.fMask = SIF_ALL;
            sc.nPos = pos;
            sc.cbSize = Marshal.SizeOf(sc);
            return SetScrollInfo(hwnd, SBS_VERT, sc, true);
        }

        public static void BeginUpdate(IntPtr hwnd)
        {
            UpdatingCount += 1;
            if (UpdatingCount > 1)
            {
                return;
            }

            EventMaskOld = (int)SendMessage(hwnd, EM_SETEVENTMASK, 1, 0);
            SendMessage(hwnd, WM_SETREDRAW, 0, 0);
        }

        public static void EndUpdate(IntPtr hwnd)
        {
            UpdatingCount -= 1;
            if (UpdatingCount < 0)
            {
                return;
            }

            SendMessage(hwnd, WM_SETREDRAW, 1, 0);
            SendMessage(hwnd, EM_SETEVENTMASK, 0, EventMaskOld);
        }

        // Skinning

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTAPI
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINTAPI ptReserved;
            public POINTAPI ptMaxSize;
            public POINTAPI ptMaxPosition;
            public POINTAPI ptMinTrackSize;
            public POINTAPI ptMaxTrackSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOSINFO
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }

        public const int WM_WINDOWPOSCHANGING = 70;
        public const int WM_SIZE = 5;
        public static readonly IntPtr TRUE = new IntPtr(1);
        public static readonly IntPtr FALSE = new IntPtr(0);
        public const int WM_GETMINMAXINFO = 36;
        public const int WM_NCLBUTTONDOWN = 161;
        public const int HTCAPTION = 2;
        public const int HTLEFT = 10;
        public const int HTRIGHT = 11;
        public const int HTTOP = 12;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 16;
        public const int HTBOTTOMRIGHT = 17;

        public enum WindowMessages
        {
            WM_NULL = 0x0,
            WM_CREATE = 0x1,
            WM_DESTROY = 0x2,
            WM_MOVE = 0x3,
            WM_SIZE = 0x5,
            WM_ACTIVATE = 0x6,
            WM_SETFOCUS = 0x7,
            WM_KILLFOCUS = 0x8,
            WM_ENABLE = 0xA,
            WM_SETREDRAW = 0xB,
            WM_SETTEXT = 0xC,
            WM_GETTEXT = 0xD,
            WM_GETTEXTLENGTH = 0xE,
            WM_PAINT = 0xF,
            WM_CLOSE = 0x10,
            WM_QUIT = 0x12,
            WM_ERASEBKGND = 0x14,
            WM_SYSCOLORCHANGE = 0x15,
            WM_SHOWWINDOW = 0x18,
            WM_ACTIVATEAPP = 0x1C,
            WM_SETCURSOR = 0x20,
            WM_MOUSEACTIVATE = 0x21,
            WM_GETMINMAXINFO = 0x24,
            WM_WINDOWPOSCHANGING = 0x46,
            WM_WINDOWPOSCHANGED = 0x47,
            WM_CONTEXTMENU = 0x7B,
            WM_STYLECHANGING = 0x7C,
            WM_STYLECHANGED = 0x7D,
            WM_DISPLAYCHANGE = 0x7E,
            WM_GETICON = 0x7F,
            WM_SETICON = 0x80,

            // non client area
            WM_NCCREATE = 0x81,
            WM_NCDESTROY = 0x82,
            WM_NCCALCSIZE = 0x83,
            WM_NCHITTEST = 0x84,
            WM_NCPAINT = 0x85,
            WM_NCACTIVATE = 0x86,
            WM_GETDLGCODE = 0x87,
            WM_SYNCPAINT = 0x88,

            // non client mouse
            WM_NCMOUSEMOVE = 0xA0,
            WM_NCLBUTTONDOWN = 0xA1,
            WM_NCLBUTTONUP = 0xA2,
            WM_NCLBUTTONDBLCLK = 0xA3,
            WM_NCRBUTTONDOWN = 0xA4,
            WM_NCRBUTTONUP = 0xA5,
            WM_NCRBUTTONDBLCLK = 0xA6,
            WM_NCMBUTTONDOWN = 0xA7,
            WM_NCMBUTTONUP = 0xA8,
            WM_NCMBUTTONDBLCLK = 0xA9,

            // keyboard
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_CHAR = 0x102,
            WM_SYSCOMMAND = 0x112,

            // menu
            WM_INITMENU = 0x116,
            WM_INITMENUPOPUP = 0x117,
            WM_MENUSELECT = 0x11F,
            WM_MENUCHAR = 0x120,
            WM_ENTERIDLE = 0x121,
            WM_MENURBUTTONUP = 0x122,
            WM_MENUDRAG = 0x123,
            WM_MENUGETOBJECT = 0x124,
            WM_UNINITMENUPOPUP = 0x125,
            WM_MENUCOMMAND = 0x126,
            WM_CHANGEUISTATE = 0x127,
            WM_UPDATEUISTATE = 0x128,
            WM_QUERYUISTATE = 0x129,

            // mouse
            WM_MOUSEFIRST = 0x200,
            WM_MOUSEMOVE = 0x200,
            WM_LBUTTONDOWN = 0x201,
            WM_LBUTTONUP = 0x202,
            WM_LBUTTONDBLCLK = 0x203,
            WM_RBUTTONDOWN = 0x204,
            WM_RBUTTONUP = 0x205,
            WM_RBUTTONDBLCLK = 0x206,
            WM_MBUTTONDOWN = 0x207,
            WM_MBUTTONUP = 0x208,
            WM_MBUTTONDBLCLK = 0x209,
            WM_MOUSEWHEEL = 0x20A,
            WM_MOUSELAST = 0x20D,
            WM_PARENTNOTIFY = 0x210,
            WM_ENTERMENULOOP = 0x211,
            WM_EXITMENULOOP = 0x212,
            WM_NEXTMENU = 0x213,
            WM_SIZING = 0x214,
            WM_CAPTURECHANGED = 0x215,
            WM_MOVING = 0x216,
            WM_ENTERSIZEMOVE = 0x231,
            WM_EXITSIZEMOVE = 0x232,
            WM_MOUSELEAVE = 0x2A3,
            WM_MOUSEHOVER = 0x2A1,
            WM_NCMOUSEHOVER = 0x2A0,
            WM_NCMOUSELEAVE = 0x2A2,
            WM_MDIACTIVATE = 0x222,
            WM_HSCROLL = 0x114,
            WM_VSCROLL = 0x115,
            WM_PRINT = 0x317,
            WM_PRINTCLIENT = 0x318,
            WM_NCUAHDRAWCAPTION = 0xAE,
            WM_NCUAHDRAWFRAME = 0xAF
        }
    }
}