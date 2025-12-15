// Windows-specific P/Invoke functionality for window enumeration and management.
// This file only compiles on Windows platform.
#if WINDOWS

/// <summary>
/// Window Style Flags
/// </summary>
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [Flags()]
    public enum WindowStyleFlags : uint
    {
        WS_OVERLAPPED = 0x0,
        WS_POPUP = 0x80000000,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x8000000,
        WS_CLIPSIBLINGS = 0x4000000,
        WS_CLIPCHILDREN = 0x2000000,
        WS_MAXIMIZE = 0x1000000,
        WS_BORDER = 0x800000,
        WS_DLGFRAME = 0x400000,
        WS_VSCROLL = 0x200000,
        WS_HSCROLL = 0x100000,
        WS_SYSMENU = 0x80000,
        WS_THICKFRAME = 0x40000,
        WS_GROUP = 0x20000,
        WS_TABSTOP = 0x10000,
        WS_MINIMIZEBOX = 0x20000,
        WS_MAXIMIZEBOX = 0x10000
    }

    /// <summary>
/// Extended Windows Style flags
/// </summary>
    [Flags()]
    public enum ExtendedWindowStyleFlags : int
    {
        WS_EX_DLGMODALFRAME = 0x1,
        WS_EX_NOPARENTNOTIFY = 0x4,
        WS_EX_TOPMOST = 0x8,
        WS_EX_ACCEPTFILES = 0x10,
        WS_EX_TRANSPARENT = 0x20,
        WS_EX_MDICHILD = 0x40,
        WS_EX_TOOLWINDOW = 0x80,
        WS_EX_WINDOWEDGE = 0x100,
        WS_EX_CLIENTEDGE = 0x200,
        WS_EX_CONTEXTHELP = 0x400,
        WS_EX_RIGHT = 0x1000,
        WS_EX_LEFT = 0x0,
        WS_EX_RTLREADING = 0x2000,
        WS_EX_LTRREADING = 0x0,
        WS_EX_LEFTSCROLLBAR = 0x4000,
        WS_EX_RIGHTSCROLLBAR = 0x0,
        WS_EX_CONTROLPARENT = 0x10000,
        WS_EX_STATICEDGE = 0x20000,
        WS_EX_APPWINDOW = 0x40000,
        WS_EX_LAYERED = 0x80000,
        WS_EX_NOINHERITLAYOUT = 0x100000,    // Disable inheritence of mirroring by children
        WS_EX_LAYOUTRTL = 0x400000,          // Right to left mirroring
        WS_EX_COMPOSITED = 0x2000000,
        WS_EX_NOACTIVATE = 0x8000000
    }


    /* TODO ERROR: Skipped RegionDirectiveTrivia *//// <summary>
    public class EnumWindows
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private delegate int EnumWindowsProc(IntPtr hwnd, int lParam);
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private class UnManagedMethods
        {
            [DllImport("user32")]
            public static extern int EnumWindows(EnumWindowsProc lpEnumFunc, int lParam);


            [DllImport("user32")]
            public static extern int EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpEnumFunc, int lParam);



        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private EnumWindowsCollection m_items = null;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /// <summary>
    /// Returns the collection of windows returned by
    /// GetWindows
    /// </summary>
        public EnumWindowsCollection Items
        {
            get
            {
                return m_items;
            }
        }

        /// <summary>
    /// Gets all top level windows on the system.
    /// </summary>
        public void GetWindows()
        {
            m_items = new EnumWindowsCollection();
            UnManagedMethods.EnumWindows(WindowEnum, 0);

        }

        /// <summary>
    /// Gets all child windows of the specified window
    /// </summary>
    /// <param name="hWndParent">Window Handle to get children for</param>
        public void GetWindows(IntPtr hWndParent)

        {
            m_items = new EnumWindowsCollection();
            UnManagedMethods.EnumChildWindows(hWndParent, WindowEnum, 0);


        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */    /// <summary>
    /// The enum Windows callback.
    /// </summary>
    /// <param name="hWnd">Window Handle</param>
    /// <param name="lParam">Application defined value</param>
    /// <returns>1 to continue enumeration, 0 to stop</returns>
        private int WindowEnum(IntPtr hWnd, int lParam)


        {
            if (OnWindowEnum(hWnd))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /// <summary>
    /// Called whenever a new window is about to be added
    /// by the Window enumeration called from GetWindows.
    /// If overriding this function, return true to continue
    /// enumeration or false to stop.  If you do not call
    /// the base implementation the Items collection will
    /// be empty.
    /// </summary>
    /// <param name="hWnd">Window handle to add</param>
    /// <returns>True to continue enumeration, False to stop</returns>
        protected virtual bool OnWindowEnum(IntPtr hWnd)

        {
            m_items.Add(hWnd);
            return true;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public EnumWindows()
        {
            // nothing to do
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

    /* TODO ERROR: Skipped RegionDirectiveTrivia *//// <summary>
    public class EnumWindowsCollection : ReadOnlyCollectionBase
    {

        /// <summary>
    /// Add a new Window to the collection.  Intended for
    /// internal use by EnumWindows only.
    /// </summary>
    /// <param name="hWnd">Window handle to add</param>
        public void Add(IntPtr hWnd)
        {
            var Item = new EnumWindowsItem(hWnd);
            InnerList.Add(Item);
        }

        /// <summary>
    /// Gets the Window at the specified index
    /// </summary>
        public EnumWindowsItem this[int index]
        {
            get
            {
                return (EnumWindowsItem)InnerList[index];
            }
        }

        /// <summary>
    /// Constructs a new EnumWindowsCollection object.
    /// </summary>
        public EnumWindowsCollection()
        {
            // nothing to do
        }
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia *//// <summary>
    public class EnumWindowsItem
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct FLASHWINFO
        {
            public int cbSize;
            public IntPtr hwnd;
            public int dwFlags;
            public int uCount;
            public int dwTimeout;
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private class UnManagedMethods
        {
            [DllImport("user32")]
            public static extern int IsWindowVisible(IntPtr hWnd);
            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int cch);


            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int GetWindowTextLength(IntPtr hWnd);
            [DllImport("user32")]
            public static extern int BringWindowToTop(IntPtr hWnd);
            [DllImport("user32")]
            public static extern int SetForegroundWindow(IntPtr hWnd);
            [DllImport("user32")]
            public static extern bool IsIconic(IntPtr Hwnd);
            [DllImport("user32")]
            public static extern int IsZoomed(IntPtr hwnd);
            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);



            [DllImport("user32")]
            public static extern int FlashWindow(IntPtr hWnd, FLASHWINFO pwfi);

            [DllImport("user32")]
            public static extern int GetWindowRect(IntPtr hWnd, RECT lpRect);

            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);




            [DllImport("user32", CharSet = CharSet.Auto)]
            public static extern int GetWindowLong(IntPtr hwnd, int nIndex);


            public const int WM_COMMAND = 0x111;
            public const int WM_SYSCOMMAND = 0x112;
            public const int SC_RESTORE = 61728;
            public const int SC_CLOSE = 61536;
            public const int SC_MAXIMIZE = 61488;
            public const int SC_MINIMIZE = 61472;
            public const int GWL_STYLE = -16;
            public const int GWL_EXSTYLE = -20;

            /// <summary>
        /// Stop flashing. The system restores the window to its original state.
        /// </summary>
            public const int FLASHW_STOP = 0;
            /// <summary>
        /// Flash the window caption.
        /// </summary>
            public const int FLASHW_CAPTION = 0x1;
            /// <summary>
        /// Flash the taskbar button.
        /// </summary>
            public const int FLASHW_TRAY = 0x2;
            /// <summary>
        /// Flash both the window caption and taskbar button.
        /// </summary>
            public const int FLASHW_ALL = FLASHW_CAPTION | FLASHW_TRAY;
            /// <summary>
        /// Flash continuously, until the FLASHW_STOP flag is set.
        /// </summary>
            public const int FLASHW_TIMER = 0x4;
            /// <summary>
        /// Flash continuously until the window comes to the foreground.
        /// </summary>
            public const int FLASHW_TIMERNOFG = 0xC;
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /// <summary>
    /// The window handle.
    /// </summary>
        private IntPtr hWnd = IntPtr.Zero;

        /// <summary>
    /// To allow items to be compared, the hash code
    /// is set to the Window handle, so two EnumWindowsItem
    /// objects for the same Window will be equal.
    /// </summary>
    /// <returns>The Window Handle for this window</returns>
        public override int GetHashCode()
        {
            return hWnd.ToInt32();
        }

        /// <summary>
    /// Gets the window's handle
    /// </summary>
        public IntPtr Handle
        {
            get
            {
                return hWnd;
            }
        }

        /// <summary>
    /// Gets the window's title (caption)
    /// </summary>
        public string Text
        {
            get
            {
                var title = new System.Text.StringBuilder(260, 260);
                UnManagedMethods.GetWindowText(hWnd, title, title.Capacity);
                return title.ToString();
            }
        }

        /// <summary>
    /// Gets the window's class name.
    /// </summary>
        public string ClassName
        {
            get
            {
                var theClassName = new System.Text.StringBuilder(260, 260);
                UnManagedMethods.GetClassName(hWnd, theClassName, theClassName.Capacity);
                return theClassName.ToString();
            }
        }

        /// <summary>
    /// Gets/Sets whether the window is iconic (mimimised) or not.
    /// </summary>
        public bool Iconic
        {
            get
            {
                return Conversions.ToBoolean(Interaction.IIf(Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(UnManagedMethods.IsIconic(hWnd), 0, false)), false, true));
            }

            set
            {
                UnManagedMethods.SendMessage(hWnd, UnManagedMethods.WM_SYSCOMMAND, new IntPtr(UnManagedMethods.SC_MINIMIZE), IntPtr.Zero);



            }
        }

        /// <summary>
    /// Gets/Sets whether the window is maximised or not.
    /// </summary>
        public bool Maximised
        {
            get
            {
                return Conversions.ToBoolean(Interaction.IIf(UnManagedMethods.IsZoomed(hWnd) == 0, false, true));
            }

            set
            {
                UnManagedMethods.SendMessage(hWnd, UnManagedMethods.WM_SYSCOMMAND, new IntPtr(UnManagedMethods.SC_MAXIMIZE), IntPtr.Zero);



            }
        }

        /// <summary>
    /// Gets whether the window is visible.
    /// </summary>
        public bool Visible
        {
            get
            {
                return Conversions.ToBoolean(Interaction.IIf(UnManagedMethods.IsWindowVisible(hWnd) == 0, false, true));
            }
        }

        /// <summary>
    /// Gets the bounding rectangle of the window
    /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                var rc = new RECT();
                UnManagedMethods.GetWindowRect(hWnd, rc);

                var rcRet = new Rectangle(rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top);

                return rcRet;
            }
        }

        /// <summary>
    /// Gets the location of the window relative to the screen.
    /// </summary>
        public Point Location
        {
            get
            {
                var rc = Rectangle;
                var pt = new Point(rc.Left, rc.Top);

                return pt;
            }
        }

        /// <summary>
    /// Gets the size of the window.
    /// </summary>
        public Size Size
        {
            get
            {
                var rc = Rectangle;
                var sz = new Size(rc.Right - rc.Left, rc.Bottom - rc.Top);

                return sz;
            }
        }

        /// <summary>
    /// Restores and Brings the window to the front,
    /// assuming it is a visible application window.
    /// </summary>
        public void Restore()
        {
            if (Iconic)
            {
                UnManagedMethods.SendMessage(hWnd, UnManagedMethods.WM_SYSCOMMAND, new IntPtr(UnManagedMethods.SC_RESTORE), IntPtr.Zero);



            }

            UnManagedMethods.BringWindowToTop(hWnd);
            UnManagedMethods.SetForegroundWindow(hWnd);
        }

        public WindowStyleFlags WindowStyle
        {
            get
            {
                return (WindowStyleFlags)UnManagedMethods.GetWindowLong(hWnd, UnManagedMethods.GWL_STYLE);
            }
        }

        public ExtendedWindowStyleFlags ExtendedWindowStyle
        {
            get
            {
                return (ExtendedWindowStyleFlags)UnManagedMethods.GetWindowLong(hWnd, UnManagedMethods.GWL_EXSTYLE);
            }
        }

        /// <summary>
    /// Constructs a new instance of this class for
    /// the specified Window Handle.
    /// </summary>
    /// <param name="hWnd">The Window Handle</param>
        public EnumWindowsItem(IntPtr hWnd)
        {
            this.hWnd = hWnd;
        }
    }
}
/* TODO ERROR: Skipped EndRegionDirectiveTrivia */

#endif // WINDOWS
