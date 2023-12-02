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
            _profiles = new TreeView();
            _ListBoxProfiles = new ListBox();
            _Cancel_Button = new Button();
            _TableLayoutPanel1 = new TableLayoutPanel();
            ToggleView = new Button();
            _OK_Button = new Button();
            EditNote = new Button();
            _GroupBox1.SuspendLayout();
            _TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // _GroupBox1
            // 
            _GroupBox1.Controls.Add(_profiles);
            _GroupBox1.Controls.Add(_ListBoxProfiles);
            _GroupBox1.Location = new Point(7, 5);
            _GroupBox1.Margin = new Padding(4, 3, 4, 3);
            _GroupBox1.Name = "_GroupBox1";
            _GroupBox1.Padding = new Padding(4, 3, 4, 3);
            _GroupBox1.Size = new Size(416, 298);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Profile";
            // 
            // _profiles
            // 
            _profiles.Location = new Point(4, 19);
            _profiles.Name = "_profiles";
            _profiles.Size = new Size(409, 276);
            _profiles.TabIndex = 1;
            _profiles.AfterSelect += _profiles_AfterSelect;
            _profiles.DoubleClick += _profiles_DoubleClick;
            _profiles.KeyDown += _profiles_KeyDown;
            // 
            // _ListBoxProfiles
            // 
            _ListBoxProfiles.Dock = DockStyle.Fill;
            _ListBoxProfiles.FormattingEnabled = true;
            _ListBoxProfiles.ItemHeight = 15;
            _ListBoxProfiles.Location = new Point(4, 19);
            _ListBoxProfiles.Margin = new Padding(4, 3, 4, 3);
            _ListBoxProfiles.Name = "_ListBoxProfiles";
            _ListBoxProfiles.Size = new Size(408, 276);
            _ListBoxProfiles.TabIndex = 0;
            _ListBoxProfiles.KeyDown += ListBoxProfiles_KeyDown;
            _ListBoxProfiles.MouseDoubleClick += ListBoxProfiles_MouseDoubleClick;
            // 
            // _Cancel_Button
            // 
            _Cancel_Button.Anchor = AnchorStyles.None;
            _Cancel_Button.DialogResult = DialogResult.Cancel;
            _Cancel_Button.Location = new Point(247, 3);
            _Cancel_Button.Margin = new Padding(4, 3, 4, 3);
            _Cancel_Button.Name = "_Cancel_Button";
            _Cancel_Button.Size = new Size(76, 27);
            _Cancel_Button.TabIndex = 1;
            _Cancel_Button.Text = "C&ancel";
            _Cancel_Button.Click += Cancel_Button_Click;
            // 
            // _TableLayoutPanel1
            // 
            _TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _TableLayoutPanel1.ColumnCount = 4;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.71698F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.28302F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 83F));
            _TableLayoutPanel1.Controls.Add(ToggleView, 0, 0);
            _TableLayoutPanel1.Controls.Add(_Cancel_Button, 3, 0);
            _TableLayoutPanel1.Controls.Add(_OK_Button, 2, 0);
            _TableLayoutPanel1.Controls.Add(EditNote, 1, 0);
            _TableLayoutPanel1.Location = new Point(96, 306);
            _TableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            _TableLayoutPanel1.Name = "_TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _TableLayoutPanel1.Size = new Size(327, 33);
            _TableLayoutPanel1.TabIndex = 3;
            // 
            // ToggleView
            // 
            ToggleView.Anchor = AnchorStyles.None;
            ToggleView.Location = new Point(4, 3);
            ToggleView.Margin = new Padding(4, 3, 4, 3);
            ToggleView.Name = "ToggleView";
            ToggleView.Size = new Size(79, 27);
            ToggleView.TabIndex = 4;
            ToggleView.Text = "Toggle View";
            ToggleView.Click += ToggleView_Click;
            // 
            // _OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
            _OK_Button.Location = new Point(163, 3);
            _OK_Button.Margin = new Padding(4, 3, 4, 3);
            _OK_Button.Name = "_OK_Button";
            _OK_Button.Size = new Size(76, 27);
            _OK_Button.TabIndex = 0;
            _OK_Button.Text = "&Connect";
            _OK_Button.Click += OK_Button_Click;
            // 
            // EditNote
            // 
            EditNote.Anchor = AnchorStyles.None;
            EditNote.Location = new Point(91, 3);
            EditNote.Margin = new Padding(4, 3, 4, 3);
            EditNote.Name = "EditNote";
            EditNote.Size = new Size(64, 27);
            EditNote.TabIndex = 5;
            EditNote.Text = "Edit Note";
            EditNote.Click += EditNote_Click;
            // 
            // DialogProfileConnect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 343);
            Controls.Add(_GroupBox1);
            Controls.Add(_TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogProfileConnect";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Profile Connect";
            TopMost = true;
            VisibleChanged += DialogProfileConnect_VisibleChanged;
            _GroupBox1.ResumeLayout(false);
            _TableLayoutPanel1.ResumeLayout(false);
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
        private TreeView _profiles;
        private Button ToggleView;
        private Button EditNote;

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