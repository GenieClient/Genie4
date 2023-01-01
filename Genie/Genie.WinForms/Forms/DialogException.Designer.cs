using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogException : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogException));
            _TableLayoutPanel1 = new TableLayoutPanel();
            _OK_Button = new Button();
            _OK_Button.Click += new EventHandler(OK_Button_Click);
            _lblMoreHeading = new Label();
            _lblActionHeading = new Label();
            _lblScopeHeading = new Label();
            _lblErrorHeading = new Label();
            _ActionBox = new RichTextBox();
            _ScopeBox = new RichTextBox();
            _ErrorBox = new RichTextBox();
            _PictureBox1 = new PictureBox();
            _txtMore = new TextBox();
            _LinkLabel1 = new LinkLabel();
            _LinkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked);
            _TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            _TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _TableLayoutPanel1.ColumnCount = 1;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Controls.Add(_OK_Button, 0, 0);
            _TableLayoutPanel1.Location = new Point(12, 371);
            _TableLayoutPanel1.Name = "TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29.0F));
            _TableLayoutPanel1.Size = new Size(411, 29);
            _TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
            _OK_Button.DialogResult = DialogResult.Cancel;
            _OK_Button.Location = new Point(172, 3);
            _OK_Button.Name = "OK_Button";
            _OK_Button.Size = new Size(67, 23);
            _OK_Button.TabIndex = 0;
            _OK_Button.Text = "OK";
            // 
            // lblMoreHeading
            // 
            _lblMoreHeading.AutoSize = true;
            _lblMoreHeading.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _lblMoreHeading.Location = new Point(9, 219);
            _lblMoreHeading.Name = "lblMoreHeading";
            _lblMoreHeading.Size = new Size(101, 13);
            _lblMoreHeading.TabIndex = 14;
            _lblMoreHeading.Text = "More information";
            // 
            // lblActionHeading
            // 
            _lblActionHeading.AutoSize = true;
            _lblActionHeading.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _lblActionHeading.Location = new Point(9, 150);
            _lblActionHeading.Name = "lblActionHeading";
            _lblActionHeading.Size = new Size(151, 13);
            _lblActionHeading.TabIndex = 12;
            _lblActionHeading.Text = "What you can do about it";
            // 
            // lblScopeHeading
            // 
            _lblScopeHeading.AutoSize = true;
            _lblScopeHeading.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _lblScopeHeading.Location = new Point(9, 81);
            _lblScopeHeading.Name = "lblScopeHeading";
            _lblScopeHeading.Size = new Size(139, 13);
            _lblScopeHeading.TabIndex = 10;
            _lblScopeHeading.Text = "How this will affect you";
            // 
            // lblErrorHeading
            // 
            _lblErrorHeading.AutoSize = true;
            _lblErrorHeading.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblErrorHeading.Location = new Point(52, 8);
            _lblErrorHeading.Name = "lblErrorHeading";
            _lblErrorHeading.Size = new Size(97, 13);
            _lblErrorHeading.TabIndex = 8;
            _lblErrorHeading.Text = "What happened";
            // 
            // ActionBox
            // 
            _ActionBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _ActionBox.BackColor = SystemColors.Control;
            _ActionBox.BorderStyle = BorderStyle.None;
            _ActionBox.CausesValidation = false;
            _ActionBox.Location = new Point(28, 166);
            _ActionBox.Name = "ActionBox";
            _ActionBox.ReadOnly = true;
            _ActionBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            _ActionBox.Size = new Size(395, 50);
            _ActionBox.TabIndex = 13;
            _ActionBox.Text = "";
            // 
            // ScopeBox
            // 
            _ScopeBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _ScopeBox.BackColor = SystemColors.Control;
            _ScopeBox.BorderStyle = BorderStyle.None;
            _ScopeBox.CausesValidation = false;
            _ScopeBox.Location = new Point(28, 97);
            _ScopeBox.Name = "ScopeBox";
            _ScopeBox.ReadOnly = true;
            _ScopeBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            _ScopeBox.Size = new Size(395, 50);
            _ScopeBox.TabIndex = 11;
            _ScopeBox.Text = "";
            // 
            // ErrorBox
            // 
            _ErrorBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _ErrorBox.BackColor = SystemColors.Control;
            _ErrorBox.BorderStyle = BorderStyle.None;
            _ErrorBox.CausesValidation = false;
            _ErrorBox.Location = new Point(55, 24);
            _ErrorBox.Name = "ErrorBox";
            _ErrorBox.ReadOnly = true;
            _ErrorBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            _ErrorBox.Size = new Size(368, 50);
            _ErrorBox.TabIndex = 9;
            _ErrorBox.Text = "";
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = My.Resources.Resources.dialog_warning;
            _PictureBox1.Location = new Point(12, 12);
            _PictureBox1.Name = "PictureBox1";
            _PictureBox1.Size = new Size(32, 32);
            _PictureBox1.TabIndex = 7;
            _PictureBox1.TabStop = false;
            // 
            // txtMore
            // 
            _txtMore.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtMore.CausesValidation = false;
            _txtMore.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtMore.Location = new Point(12, 235);
            _txtMore.Multiline = true;
            _txtMore.Name = "txtMore";
            _txtMore.ReadOnly = true;
            _txtMore.ScrollBars = ScrollBars.Vertical;
            _txtMore.Size = new Size(411, 130);
            _txtMore.TabIndex = 15;
            // 
            // LinkLabel1
            // 
            _LinkLabel1.AutoSize = true;
            _LinkLabel1.Location = new Point(304, 219);
            _LinkLabel1.Name = "LinkLabel1";
            _LinkLabel1.Size = new Size(122, 13);
            _LinkLabel1.TabIndex = 16;
            _LinkLabel1.TabStop = true;
            _LinkLabel1.Text = "Copy details to clipboard";
            // 
            // DialogException
            // 
            AcceptButton = _OK_Button;
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _OK_Button;
            ClientSize = new Size(435, 412);
            Controls.Add(_LinkLabel1);
            Controls.Add(_txtMore);
            Controls.Add(_lblMoreHeading);
            Controls.Add(_lblActionHeading);
            Controls.Add(_lblScopeHeading);
            Controls.Add(_lblErrorHeading);
            Controls.Add(_ActionBox);
            Controls.Add(_ScopeBox);
            Controls.Add(_ErrorBox);
            Controls.Add(_PictureBox1);
            Controls.Add(_TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogException";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Genie has encountered a problem";
            _TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

        private Label _lblMoreHeading;

        internal Label lblMoreHeading
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMoreHeading;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMoreHeading != null)
                {
                }

                _lblMoreHeading = value;
                if (_lblMoreHeading != null)
                {
                }
            }
        }

        private Label _lblActionHeading;

        internal Label lblActionHeading
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblActionHeading;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblActionHeading != null)
                {
                }

                _lblActionHeading = value;
                if (_lblActionHeading != null)
                {
                }
            }
        }

        private Label _lblScopeHeading;

        internal Label lblScopeHeading
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblScopeHeading;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblScopeHeading != null)
                {
                }

                _lblScopeHeading = value;
                if (_lblScopeHeading != null)
                {
                }
            }
        }

        private Label _lblErrorHeading;

        internal Label lblErrorHeading
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblErrorHeading;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblErrorHeading != null)
                {
                }

                _lblErrorHeading = value;
                if (_lblErrorHeading != null)
                {
                }
            }
        }

        private RichTextBox _ActionBox;

        internal RichTextBox ActionBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ActionBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ActionBox != null)
                {
                }

                _ActionBox = value;
                if (_ActionBox != null)
                {
                }
            }
        }

        private RichTextBox _ScopeBox;

        internal RichTextBox ScopeBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ScopeBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ScopeBox != null)
                {
                }

                _ScopeBox = value;
                if (_ScopeBox != null)
                {
                }
            }
        }

        private RichTextBox _ErrorBox;

        internal RichTextBox ErrorBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ErrorBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ErrorBox != null)
                {
                }

                _ErrorBox = value;
                if (_ErrorBox != null)
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

        private TextBox _txtMore;

        internal TextBox txtMore
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMore;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMore != null)
                {
                }

                _txtMore = value;
                if (_txtMore != null)
                {
                }
            }
        }

        private LinkLabel _LinkLabel1;

        internal LinkLabel LinkLabel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LinkLabel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LinkLabel1 != null)
                {
                    _LinkLabel1.LinkClicked -= LinkLabel1_LinkClicked;
                }

                _LinkLabel1 = value;
                if (_LinkLabel1 != null)
                {
                    _LinkLabel1.LinkClicked += LinkLabel1_LinkClicked;
                }
            }
        }
    }
}