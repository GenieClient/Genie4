using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogReconnect : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        #pragma warning disable 0649
        private System.ComponentModel.IContainer components;
        #pragma warning restore 0649

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _ButtonConnect = new Button();
            _ButtonConnect.Click += new EventHandler(ButtonConnect_Click);
            _Label1 = new Label();
            _PictureBox1 = new PictureBox();
            _PanelTop = new Panel();
            _TableLayoutPanel1 = new TableLayoutPanel();
            _TextBoxLog = new TextBox();
            _ButtonClose = new Button();
            _ButtonClose.Click += new EventHandler(ButtonClose_Click);
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            _PanelTop.SuspendLayout();
            _TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonConnect
            // 
            _ButtonConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _ButtonConnect.AutoSize = true;
            _ButtonConnect.Location = new Point(101, 3);
            _ButtonConnect.Name = "ButtonConnect";
            _ButtonConnect.Size = new Size(82, 23);
            _ButtonConnect.TabIndex = 0;
            _ButtonConnect.Text = "&Connect Now";
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(41, 5);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(220, 26);
            _Label1.TabIndex = 4;
            _Label1.Text = "The connection to the game was lost." + (char)13 + (char)10 + "Genie will attempt to reconnect in X second" + "s.";
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = My.Resources.Resources.network_offline;
            _PictureBox1.Location = new Point(3, 3);
            _PictureBox1.Name = "PictureBox1";
            _PictureBox1.Size = new Size(32, 32);
            _PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            _PictureBox1.TabIndex = 5;
            _PictureBox1.TabStop = false;
            // 
            // PanelTop
            // 
            _PanelTop.Controls.Add(_PictureBox1);
            _PanelTop.Controls.Add(_Label1);
            _PanelTop.Dock = DockStyle.Top;
            _PanelTop.Location = new Point(0, 0);
            _PanelTop.Name = "PanelTop";
            _PanelTop.Size = new Size(373, 39);
            _PanelTop.TabIndex = 4;
            // 
            // TableLayoutPanel1
            // 
            _TableLayoutPanel1.ColumnCount = 2;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Controls.Add(_ButtonClose, 0, 0);
            _TableLayoutPanel1.Controls.Add(_ButtonConnect, 0, 0);
            _TableLayoutPanel1.Dock = DockStyle.Bottom;
            _TableLayoutPanel1.Location = new Point(0, 151);
            _TableLayoutPanel1.Name = "TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0F));
            _TableLayoutPanel1.Size = new Size(373, 29);
            _TableLayoutPanel1.TabIndex = 0;
            // 
            // TextBoxLog
            // 
            _TextBoxLog.BackColor = Color.White;
            _TextBoxLog.Dock = DockStyle.Fill;
            _TextBoxLog.Location = new Point(0, 39);
            _TextBoxLog.Multiline = true;
            _TextBoxLog.Name = "TextBoxLog";
            _TextBoxLog.ReadOnly = true;
            _TextBoxLog.ScrollBars = ScrollBars.Vertical;
            _TextBoxLog.Size = new Size(373, 112);
            _TextBoxLog.TabIndex = 1;
            // 
            // ButtonClose
            // 
            _ButtonClose.AutoSize = true;
            _ButtonClose.DialogResult = DialogResult.Cancel;
            _ButtonClose.Location = new Point(189, 3);
            _ButtonClose.Name = "ButtonClose";
            _ButtonClose.Size = new Size(80, 23);
            _ButtonClose.TabIndex = 1;
            _ButtonClose.Text = "&Abort && Close";
            // 
            // DialogReconnect
            // 
            AcceptButton = _ButtonConnect;
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _ButtonClose;
            ClientSize = new Size(373, 180);
            Controls.Add(_TextBoxLog);
            Controls.Add(_TableLayoutPanel1);
            Controls.Add(_PanelTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogReconnect";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connection Lost";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            _PanelTop.ResumeLayout(false);
            _PanelTop.PerformLayout();
            _TableLayoutPanel1.ResumeLayout(false);
            _TableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button _ButtonConnect;

        internal Button ButtonConnect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonConnect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonConnect != null)
                {
                    _ButtonConnect.Click -= ButtonConnect_Click;
                }

                _ButtonConnect = value;
                if (_ButtonConnect != null)
                {
                    _ButtonConnect.Click += ButtonConnect_Click;
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private PictureBox _PictureBox1;

        internal PictureBox PictureBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBox1 != null)
                {
                }

                _PictureBox1 = value;
                if (_PictureBox1 != null)
                {
                }
            }
        }

        private Panel _PanelTop;

        internal Panel PanelTop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelTop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelTop != null)
                {
                }

                _PanelTop = value;
                if (_PanelTop != null)
                {
                }
            }
        }

        private TableLayoutPanel _TableLayoutPanel1;

        internal TableLayoutPanel TableLayoutPanel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TableLayoutPanel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TableLayoutPanel1 != null)
                {
                }

                _TableLayoutPanel1 = value;
                if (_TableLayoutPanel1 != null)
                {
                }
            }
        }

        private Button _ButtonClose;

        internal Button ButtonClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonClose != null)
                {
                    _ButtonClose.Click -= ButtonClose_Click;
                }

                _ButtonClose = value;
                if (_ButtonClose != null)
                {
                    _ButtonClose.Click += ButtonClose_Click;
                }
            }
        }

        private TextBox _TextBoxLog;

        internal TextBox TextBoxLog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxLog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxLog != null)
                {
                }

                _TextBoxLog = value;
                if (_TextBoxLog != null)
                {
                }
            }
        }
    }
}