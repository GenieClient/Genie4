using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class FormSkin : Form
    {
        public FormSkin()
        {
            InitializeComponent();
        }

        public FormSkin(string sID, string sTitle, ref Genie.Globals oGlobal)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            ID = sID;
            Text = sTitle;
            Title = sTitle;
            Globals = oGlobal;
            RichTextBoxOutput.FormParent = this;
            LoadSkin();
        }

        public event EventLinkClickedEventHandler EventLinkClicked;

        public delegate void EventLinkClickedEventHandler(string link);

        public int TriggerDistance = 5;
        public int SnapDistance = 15;
        private Bitmap oTopLeft;
        private Bitmap oTopRight;
        private Bitmap oTop;
        private Bitmap oLeft;
        private Bitmap oRight;
        private Bitmap oBottom;
        private Bitmap oBottomLeft;
        private Bitmap oBottomRight;

        // int windowCloseX, windowCloseY, windowCloseWidth, windowCloseHeight; 

        private Font oTitleFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
        private DragType oDragType;

        private enum DragType
        {
            Move = 0,
            TopLeft = 1,
            TopRight = 2,
            Top = 3,
            BottomLeft = 4,
            BottomRight = 5,
            Bottom = 6,
            Right = 7,
            Left = 8
        }

        public void LoadSkin()
        {
            oTopLeft = GetResourceBitmap("GenieClient.Resources.skin_topleft.bmp");
            oTopRight = GetResourceBitmap("GenieClient.Resources.skin_topright.bmp");
            oTop = GetResourceBitmap("GenieClient.Resources.skin_top.bmp");
            oLeft = GetResourceBitmap("GenieClient.Resources.skin_left.bmp");
            oRight = GetResourceBitmap("GenieClient.Resources.skin_right.bmp");
            oBottom = GetResourceBitmap("GenieClient.Resources.skin_bottom.bmp");
            oBottomLeft = GetResourceBitmap("GenieClient.Resources.skin_bottomleft.bmp");
            oBottomRight = GetResourceBitmap("GenieClient.Resources.skin_bottomright.bmp");
            Padding = new Padding(oLeft.Width, oTop.Height, oRight.Width, oBottom.Height);
        }

        private string _IfClosed = string.Empty;

        public string IfClosed
        {
            get
            {
                return _IfClosed;
            }

            set
            {
                _IfClosed = value;
            }
        }

        private string _ID = string.Empty;

        public string ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value.ToLower();
            }
        }

        private string _Title = string.Empty;

        public string Title
        {
            get
            {
                return _Title;
            }

            set
            {
                _Title = value;
                UpdateTitle();
            }
        }

        private string _Comment = string.Empty;

        public string Comment
        {
            get
            {
                return _Comment;
            }

            set
            {
                _Comment = value;
                if (Title.Length == 0)
                    Title = Text;
                UpdateTitle();
            }
        }

        private void UpdateTitle()
        {
            string sTitle = Title;
            if (Comment.Length > 0)
                sTitle += " (" + Comment + ")";
            Text = sTitle;
        }

        private Bitmap GetResourceBitmap(string sRef)
        {
            var ResStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(sRef);
            var resourceName = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            //Console.Write(resourceName);
            return (Bitmap)Image.FromStream(ResStream);
        }

        protected override void WndProc(ref Message m)
        {
            var switchExpr = m.Msg;
            switch (switchExpr)
            {
                case Win32Utility.WM_GETMINMAXINFO:
                    {
                        GetMinMaxInfoHelper(m);
                        base.WndProc(ref m);
                        break;
                    }

                case (int)Win32Utility.WindowMessages.WM_SETTEXT:
                    {
                        base.DefWndProc(ref m);
                        break;
                    }

                case (int)Win32Utility.WindowMessages.WM_NCACTIVATE:
                    {
                        if (WindowState == FormWindowState.Minimized)
                        {
                            base.DefWndProc(ref m);
                        }
                        else
                        {
                            m.Result = Win32Utility.TRUE;
                        }

                        break;
                    }

                case (int)Win32Utility.WindowMessages.WM_NCPAINT:
                    {
                        m.Result = Win32Utility.TRUE;
                        break;
                    }

                case (int)Win32Utility.WindowMessages.WM_NCUAHDRAWCAPTION: // Ignore
                    {
                        return;
                    }

                case (int)Win32Utility.WindowMessages.WM_NCUAHDRAWFRAME: // Ignore
                    {
                        return;
                    }

                case Win32Utility.WM_WINDOWPOSCHANGING:
                    {
                        Win32Utility.WINDOWPOSINFO pos = (Win32Utility.WINDOWPOSINFO)m.GetLParam(typeof(Win32Utility.WINDOWPOSINFO));
                        {
                            var withBlock = (FormMain)MdiParent;
                            if (withBlock.m_IsChangingLayout == false)
                            {
                                bool bSnappedX = false;
                                bool bSnappedY = false;
                                if (oDragType == DragType.Move)
                                {
                                    if (pos.x < SnapDistance)
                                    {
                                        pos.x = 0;
                                        bSnappedX = true;
                                    }
                                    else if (Conversions.ToBoolean(pos.x + Width > ((Size)withBlock.ClientSize).Width - SystemInformation.Border3DSize.Width * 2 - SnapDistance))
                                    {
                                        pos.x = Conversions.ToInteger(((Size)withBlock.ClientSize).Width - SystemInformation.Border3DSize.Width * 2 - Width);
                                        bSnappedX = true;
                                    }

                                    if (pos.y < SnapDistance)
                                    {
                                        pos.y = 0;
                                        bSnappedY = true;
                                    }
                                    else if (Conversions.ToBoolean(pos.y + Height > ((Size)withBlock.ClientSize).Height - SystemInformation.Border3DSize.Height * 2 - SnapDistance))
                                    {
                                        pos.y = Conversions.ToInteger(((Size)withBlock.ClientSize).Height - SystemInformation.Border3DSize.Height * 2 - Height);
                                        bSnappedY = true;
                                    }
                                }

                                for (int i = 0, loopTo = withBlock.MdiChildren.Length - 1; i <= loopTo; i++)
                                {
                                    if (withBlock.MdiChildren[i] is FormSkin && withBlock.MdiChildren[i].Visible == true)
                                    {
                                        // Snap to other windows
                                        if ((Name ?? "") != (withBlock.MdiChildren[i].Name ?? ""))
                                        {
                                            if (bSnappedX == false & pos.x + pos.cx + SnapDistance > withBlock.MdiChildren[i].Left)
                                            {
                                                if (pos.x + pos.cx - SnapDistance < withBlock.MdiChildren[i].Left)
                                                {
                                                    if (oDragType == DragType.Move)
                                                    {
                                                        pos.x = withBlock.MdiChildren[i].Left - Width;
                                                        bSnappedX = true;
                                                    }
                                                    else if (oDragType == DragType.Right || oDragType == DragType.TopRight || oDragType == DragType.BottomRight)
                                                    {
                                                        pos.cx = withBlock.MdiChildren[i].Left - Left;
                                                        bSnappedX = true;
                                                    }
                                                }
                                            }

                                            if (bSnappedX == false & pos.x + SnapDistance > withBlock.MdiChildren[i].Left + withBlock.MdiChildren[i].Width)
                                            {
                                                if (pos.x - SnapDistance < withBlock.MdiChildren[i].Left + withBlock.MdiChildren[i].Width)
                                                {
                                                    if (oDragType == DragType.Move)
                                                    {
                                                        pos.x = withBlock.MdiChildren[i].Left + withBlock.MdiChildren[i].Width;
                                                        bSnappedX = true;
                                                    }
                                                    else if (oDragType == DragType.Left || oDragType == DragType.TopLeft || oDragType == DragType.BottomLeft)
                                                    {
                                                        int t = pos.x;
                                                        pos.x = withBlock.MdiChildren[i].Left + withBlock.MdiChildren[i].Width;
                                                        pos.cx = pos.cx + (t - pos.x);
                                                        bSnappedX = true;
                                                    }
                                                }
                                            }

                                            if (bSnappedY == false & pos.y + pos.cy + SnapDistance > withBlock.MdiChildren[i].Top)
                                            {
                                                if (pos.y + pos.cy - SnapDistance < withBlock.MdiChildren[i].Top)
                                                {
                                                    if (oDragType == DragType.Move)
                                                    {
                                                        pos.y = withBlock.MdiChildren[i].Top - Height;
                                                        bSnappedY = true;
                                                    }
                                                    else if (oDragType == DragType.Bottom || oDragType == DragType.BottomRight || oDragType == DragType.BottomLeft)
                                                    {
                                                        pos.cy = withBlock.MdiChildren[i].Top - Top;
                                                        bSnappedY = true;
                                                    }
                                                }
                                            }

                                            if (bSnappedY == false & pos.y + SnapDistance > withBlock.MdiChildren[i].Top + withBlock.MdiChildren[i].Height)
                                            {
                                                if (pos.y - SnapDistance < withBlock.MdiChildren[i].Top + withBlock.MdiChildren[i].Height)
                                                {
                                                    if (oDragType == DragType.Move)
                                                    {
                                                        pos.y = withBlock.MdiChildren[i].Top + withBlock.MdiChildren[i].Height;
                                                        bSnappedY = true;
                                                    }
                                                    else if (oDragType == DragType.Top || oDragType == DragType.TopLeft || oDragType == DragType.TopRight)
                                                    {
                                                        int t = pos.y;
                                                        pos.y = withBlock.MdiChildren[i].Top + withBlock.MdiChildren[i].Height;
                                                        pos.cy = pos.cy + (t - pos.y);
                                                        bSnappedY = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Invalidate();
                            }
                        }

                        Marshal.StructureToPtr(pos, m.LParam, true);
                        m.Result = IntPtr.Zero;
                        base.WndProc(ref m);
                        break;
                    }

                default:
                    {
                        base.WndProc(ref m);
                        break;
                    }
            }
        }

        private void SetRegion()
        {
            if (Information.IsNothing(oTopLeft))
                return;

            // Make topleft and topright transparent 
            var oRegion = new Region();
            var oRegtionTemp = new Region();
            oRegion.MakeEmpty();
            oRegtionTemp.MakeEmpty();
            oRegion.Union(GetRegion(oTopLeft, Color.Magenta));
            var rc = new Rectangle(oTopLeft.Width, 0, Width - oTopLeft.Width - oTopRight.Width, oTopLeft.Height);
            oRegion.Union(rc);
            oRegtionTemp = GetRegion(oTopRight, Color.Magenta);
            oRegtionTemp.Translate(Width - oTopRight.Width, 0);
            oRegion.Union(oRegtionTemp);
            rc = new Rectangle(0, oTopLeft.Height, Width, Height - oTopLeft.Height);
            oRegion.Union(rc);
            Region = oRegion;
            Invalidate();
            RichTextBoxOutput.Invalidate();
        }

        private void GetMinMaxInfoHelper(Message m)
        {
            Win32Utility.MINMAXINFO mmi = (Win32Utility.MINMAXINFO)m.GetLParam(typeof(Win32Utility.MINMAXINFO));
            if (!MinimumSize.IsEmpty)
            {
                mmi.ptMinTrackSize.x = MinimumSize.Width;
                mmi.ptMinTrackSize.y = MinimumSize.Height;
            }

            if (!MaximumSize.IsEmpty)
            {
                mmi.ptMaxTrackSize.x = MaximumSize.Width;
                mmi.ptMaxTrackSize.y = MaximumSize.Height;
            }

            Marshal.StructureToPtr(mmi, m.LParam, true);
            m.Result = IntPtr.Zero;
        }

        private void FormSkin_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void FormSkin_Load(object sender, EventArgs e)
        {
        }

        private void FormSkin_Paint(object sender, PaintEventArgs e)
        {
            if (Information.IsNothing(oTopLeft))
                return;
            int j;
            int i;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(oTopLeft, 0, 0, oTopLeft.Width, oTopLeft.Height);
            j = Width - oTopRight.Width + 100;
            i = oTopLeft.Width;
            while (i < j)
            {
                e.Graphics.DrawImage(oTop, i, 0, oTop.Width, oTop.Height);
                i += oTop.Width;
            }

            e.Graphics.DrawImage(oTopRight, Width - oTopRight.Width, 0, oTopRight.Width, oTopRight.Height);
            j = Height - oBottomLeft.Height + 100;
            i = oTopLeft.Height;
            while (i < j)
            {
                e.Graphics.DrawImage(oLeft, 0, i, oLeft.Width, oLeft.Height);
                i += oLeft.Height;
            }

            e.Graphics.DrawImage(oBottomLeft, 0, Height - oBottomLeft.Height, oBottomLeft.Width, oBottomLeft.Height);
            j = Width - oTopRight.Width + 100;
            i = oBottomLeft.Width;
            while (i < j)
            {
                e.Graphics.DrawImage(oBottom, i, Height - oBottom.Height, oBottom.Width, oBottom.Height);
                i += oBottom.Width;
            }

            j = Height - oBottomLeft.Height + 100;
            i = oTopRight.Height;
            while (i < j)
            {
                e.Graphics.DrawImage(oRight, Width - oRight.Width, i, oRight.Width, oRight.Height);
                i += oRight.Height;
            }

            e.Graphics.DrawImage(oBottomRight, Width - oBottomRight.Width, Height - oBottomRight.Height, oBottomRight.Width, oBottomRight.Height);
            e.Graphics.DrawString(Text, oTitleFont, new SolidBrush(Color.White), 5, 2);
            if (bIsBitsSet == false)
            {
                SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.Opaque, true);
                bIsBitsSet = true;
            }
        }

        private bool bIsBitsSet = false;

        private void FormSkin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ResizeForm(e.X, e.Y);
                Cursor = Cursors.Default;
            }
        }

        private Region GetRegion(Bitmap _img, Color clr)
        {
            var _matchColor = Color.FromArgb(clr.R, clr.G, clr.B);
            var rgn = new Region();
            rgn.MakeEmpty();
            var rc = new Rectangle(0, 0, 0, 0);
            bool inimage = false;
            for (int y = 0, loopTo = _img.Height - 1; y <= loopTo; y++)
            {
                for (int x = 0, loopTo1 = _img.Width - 1; x <= loopTo1; x++)
                {
                    if (!inimage)
                    {
                        if (_img.GetPixel(x, y) != _matchColor)
                        {
                            inimage = true;
                            rc.X = x;
                            rc.Y = y;
                            rc.Height = 1;
                        }
                    }
                    else if (_img.GetPixel(x, y) == _matchColor)
                    {
                        inimage = false;
                        rc.Width = x - rc.X;
                        rgn.Union(rc);
                    }
                }

                if (inimage)
                {
                    inimage = false;
                    rc.Width = _img.Width - rc.X;
                    rgn.Union(rc);
                }
            }

            return rgn;
        }

        private void FormSkin_MouseMove(object sender, MouseEventArgs e)
        {
            SetCursorShape(e.X, e.Y);
        }

        private void ResizeForm(int X, int Y)
        {
            Win32Utility.ReleaseCapture();
            if (Y < TriggerDistance)
            {
                if (X < TriggerDistance)
                {
                    oDragType = DragType.TopLeft;
                    Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTTOPLEFT, 0);
                }
                else if (X > Width - TriggerDistance)
                {
                    oDragType = DragType.TopRight;
                    Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTTOPRIGHT, 0);
                }
                else
                {
                    oDragType = DragType.Top;
                    Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTTOP, 0);
                }
            }
            else if (Y > Height - TriggerDistance)
            {
                if (X < TriggerDistance)
                {
                    oDragType = DragType.BottomLeft;
                    Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTBOTTOMLEFT, 0);
                }
                else if (X > Width - TriggerDistance)
                {
                    oDragType = DragType.BottomRight;
                    Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTBOTTOMRIGHT, 0);
                }
                else
                {
                    oDragType = DragType.Bottom;
                    Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTBOTTOM, 0);
                }
            }
            else if (X > Width - TriggerDistance)
            {
                oDragType = DragType.Right;
                Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTRIGHT, 0);
            }
            else if (X < TriggerDistance)
            {
                oDragType = DragType.Left;
                Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTLEFT, 0);
            }
            else
            {
                oDragType = DragType.Move;
                Win32Utility.SendMessage(Handle, Win32Utility.WM_NCLBUTTONDOWN, Win32Utility.HTCAPTION, 0);
            }

            // Update layout 
            Invalidate();
            RichTextBoxOutput.Invalidate();
        }

        private void SetCursorShape(int X, int Y)
        {
            if (Y < TriggerDistance)
            {
                if (X < TriggerDistance)
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else if (X > Width - TriggerDistance)
                {
                    Cursor = Cursors.SizeNESW;
                }
                else
                {
                    Cursor = Cursors.SizeNS;
                }
            }
            else if (Y > Height - TriggerDistance)
            {
                if (X < TriggerDistance)
                {
                    Cursor = Cursors.SizeNESW;
                }
                else if (X > Width - TriggerDistance)
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    Cursor = Cursors.SizeNS;
                }
            }
            else if (X > Width - TriggerDistance || X < TriggerDistance)
            {
                Cursor = Cursors.SizeWE;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void FormSkin_Resize(object sender, EventArgs e)
        {
            SetRegion();
        }

        // Private Sub Resized()
        // If Not IsNothing(oLeft) Then
        // PanelContents.Width = Me.Width - oLeft.Width - oRight.Width
        // PanelContents.Height = Me.Height - oTop.Height - oBottom.Height
        // If RichTextBoxOutput.Visible = False Then
        // RichTextBoxOutput.Visible = True
        // End If
        // End If
        // End Sub

        private void PanelContents_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        public Genie.Globals Globals { get; }

        public bool IsMainWindow
        {
            get
            {
                return RichTextBoxOutput.IsMainWindow;
            }

            set
            {
                RichTextBoxOutput.IsMainWindow = value;
            }
        }

        public bool TimeStamp
        {
            get
            {
                return RichTextBoxOutput.TimeStamp;
            }

            set
            {
                RichTextBoxOutput.TimeStamp = value;
                TimeStampToolStripMenuItem.Checked = value;
            }
        }

        public bool NameListOnly
        {
            get
            {
                return RichTextBoxOutput.NameListOnly;
            }

            set
            {
                RichTextBoxOutput.NameListOnly = value;
                NameListOnlyToolStripMenuItem.Checked = value;
            }
        }

        private bool m_bUserForm = true;

        public bool UserForm
        {
            get
            {
                return m_bUserForm;
            }

            set
            {
                m_bUserForm = value;
            }
        }

        public Font TextFont
        {
            get
            {
                return RichTextBoxOutput.Font;
            }

            set
            {
                RichTextBoxOutput.Font = value;
            }
        }

        private void MyKeyDown(KeyEventArgs e)
        {
            ((FormMain)MdiParent).InputKeyDown(e);
        }

        private void MyKeyPress(KeyPressEventArgs e)
        {
            ((FormMain)MdiParent).InputKeyPress(e);
        }

        public void ClearWindow()
        {
            RichTextBoxOutput.ClearWindow();
        }

        public void Unload()
        {
            m_bUnloadWindow = true;
            Close();
        }

        private bool m_bUnloadWindow = false;

        protected override void OnClosing(CancelEventArgs e)
        {
            if (Information.IsNothing(My.MyProject.Forms.FormMain))
            {
                return;
            }

            if (((FormMain)MdiParent).bCloseAllDocument == false & m_bUnloadWindow == false)
            {
                RichTextBoxOutput.Visible = false;
                Visible = false;
                e.Cancel = true;
            }
        }

        private void FormSkin_Enter(object sender, EventArgs e)
        {
            if (!Information.IsNothing(MdiParent))
            {
                ((FormMain)MdiParent).ActiveFormSkin = this;
            }
        }

        // Private Sub FormSkin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        // If Not IsNothing(Me.MdiParent) Then
        // CType(Me.MdiParent, FormMain).ActiveFormSkin = Me
        // End If
        // End Sub

        private void FormSkin_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                ShowOutput();
            }
        }

        private void FormSkin_Shown(object sender, EventArgs e)
        {
            ShowOutput();
        }

        private void ShowOutput()
        {
            PanelContents.Visible = true;
            RichTextBoxOutput.Visible = true;
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxOutput.ClearWindow();
        }

        private void TimeStampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeStamp = !TimeStamp;
        }

        private void NameListOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameListOnly = !NameListOnly;
        }

        private void CloseWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxOutput.Visible = false;
            Visible = false;
        }

        private void RichTextBoxOutput_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            EventLinkClicked?.Invoke(e.LinkText);
        }

        private void _RichTextBoxOutput_KeyDown(object sender, KeyEventArgs e)
        {
            this._RichTextBoxOutput.ComponentRichTextBox_KeyDown(sender, e);
        }

        private void _RichTextBoxOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            this._RichTextBoxOutput.ComponentRichTextBox_KeyPress(sender, e);
        }

        private void _RichTextBoxOutput_MouseUp(object sender, MouseEventArgs e)
        {
            this._RichTextBoxOutput.ComponentRichTextBox_MouseUp(sender, e);
        }

        private void _RichTextBoxOutput_MouseDown(object sender, MouseEventArgs e)
        {
            this._RichTextBoxOutput.ComponentRichTextBox_MouseDown(sender, e);
        }
    }
}