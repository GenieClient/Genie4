using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogProfileConnect : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
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
            _GroupBox1 = new GroupBox();
            _ListBoxProfiles = new ListBox();
            _ListBoxProfiles.MouseDoubleClick += new MouseEventHandler(ListBoxProfiles_MouseDoubleClick);
            _ListBoxProfiles.KeyDown += new KeyEventHandler(ListBoxProfiles_KeyDown);
            _Cancel_Button = new Button();
            _Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            _TableLayoutPanel1 = new TableLayoutPanel();
            _OK_Button = new Button();
            _OK_Button.Click += new EventHandler(OK_Button_Click);
            _GroupBox1.SuspendLayout();
            _TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_ListBoxProfiles);
            _GroupBox1.Location = new Point(6, 4);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(357, 258);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Profile";
            // 
            // ListBoxProfiles
            // 
            _ListBoxProfiles.Dock = DockStyle.Fill;
            _ListBoxProfiles.FormattingEnabled = true;
            _ListBoxProfiles.Location = new Point(3, 16);
            _ListBoxProfiles.Name = "ListBoxProfiles";
            _ListBoxProfiles.Size = new Size(351, 238);
            _ListBoxProfiles.TabIndex = 0;
            // 
            // Cancel_Button
            // 
            _Cancel_Button.Anchor = AnchorStyles.None;
            _Cancel_Button.DialogResult = DialogResult.Cancel;
            _Cancel_Button.Location = new Point(76, 3);
            _Cancel_Button.Name = "Cancel_Button";
            _Cancel_Button.Size = new Size(67, 23);
            _Cancel_Button.TabIndex = 1;
            _Cancel_Button.Text = "C&ancel";
            // 
            // TableLayoutPanel1
            // 
            _TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _TableLayoutPanel1.ColumnCount = 2;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Controls.Add(_OK_Button, 0, 0);
            _TableLayoutPanel1.Controls.Add(_Cancel_Button, 1, 0);
            _TableLayoutPanel1.Location = new Point(221, 265);
            _TableLayoutPanel1.Name = "TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Size = new Size(146, 29);
            _TableLayoutPanel1.TabIndex = 3;
            // 
            // OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
            _OK_Button.Location = new Point(3, 3);
            _OK_Button.Name = "OK_Button";
            _OK_Button.Size = new Size(67, 23);
            _OK_Button.TabIndex = 0;
            _OK_Button.Text = "&Connect";
            // 
            // DialogProfileConnect
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 297);
            Controls.Add(_GroupBox1);
            Controls.Add(_TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogProfileConnect";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Profile Connect";
            _GroupBox1.ResumeLayout(false);
            _TableLayoutPanel1.ResumeLayout(false);
            VisibleChanged += new EventHandler(DialogProfileConnect_VisibleChanged);
            ResumeLayout(false);
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private Button _Cancel_Button;

        internal Button Cancel_Button
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Cancel_Button;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Cancel_Button != null)
                {
                    _Cancel_Button.Click -= Cancel_Button_Click;
                }

                _Cancel_Button = value;
                if (_Cancel_Button != null)
                {
                    _Cancel_Button.Click += Cancel_Button_Click;
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

        private Button _OK_Button;

        internal Button OK_Button
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OK_Button;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OK_Button != null)
                {
                    _OK_Button.Click -= OK_Button_Click;
                }

                _OK_Button = value;
                if (_OK_Button != null)
                {
                    _OK_Button.Click += OK_Button_Click;
                }
            }
        }

        private ListBox _ListBoxProfiles;

        internal ListBox ListBoxProfiles
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ListBoxProfiles;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ListBoxProfiles != null)
                {
                    _ListBoxProfiles.MouseDoubleClick -= ListBoxProfiles_MouseDoubleClick;
                    _ListBoxProfiles.KeyDown -= ListBoxProfiles_KeyDown;
                }

                _ListBoxProfiles = value;
                if (_ListBoxProfiles != null)
                {
                    _ListBoxProfiles.MouseDoubleClick += ListBoxProfiles_MouseDoubleClick;
                    _ListBoxProfiles.KeyDown += ListBoxProfiles_KeyDown;
                }
            }
        }
    }
}