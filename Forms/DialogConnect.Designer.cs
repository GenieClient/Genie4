using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogConnect : Form
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
            _TableLayoutPanel1 = new TableLayoutPanel();
            _OK_Button = new Button();
            _OK_Button.Click += new EventHandler(OK_Button_Click);
            _Cancel_Button = new Button();
            _Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            _GroupBox1 = new GroupBox();
            _CheckBoxSavePassword = new CheckBox();
            _CheckBoxSavePassword.CheckedChanged += new EventHandler(CheckBoxSavePassword_CheckedChanged);
            _Label5 = new Label();
            _ComboBoxGame = new ComboBox();
            _TextBoxCharacter = new TextBox();
            _Label4 = new Label();
            _TextBoxPassword = new TextBox();
            _Label3 = new Label();
            _TextBoxAccount = new TextBox();
            _Label2 = new Label();
            _Label1 = new Label();
            _PictureBox1 = new PictureBox();
            _TableLayoutPanel1.SuspendLayout();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            _TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _TableLayoutPanel1.ColumnCount = 2;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Controls.Add(_OK_Button, 0, 0);
            _TableLayoutPanel1.Controls.Add(_Cancel_Button, 1, 0);
            _TableLayoutPanel1.Location = new Point(221, 170);
            _TableLayoutPanel1.Name = "TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Size = new Size(146, 29);
            _TableLayoutPanel1.TabIndex = 1;
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
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_CheckBoxSavePassword);
            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Controls.Add(_ComboBoxGame);
            _GroupBox1.Controls.Add(_TextBoxCharacter);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_TextBoxPassword);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_TextBoxAccount);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_PictureBox1);
            _GroupBox1.Location = new Point(6, 4);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(357, 162);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Play.net";
            // 
            // CheckBoxSavePassword
            // 
            _CheckBoxSavePassword.AutoSize = true;
            _CheckBoxSavePassword.Location = new Point(9, 98);
            _CheckBoxSavePassword.Name = "CheckBoxSavePassword";
            _CheckBoxSavePassword.Size = new Size(141, 17);
            _CheckBoxSavePassword.TabIndex = 16;
            _CheckBoxSavePassword.Text = "Save password in profile";
            _CheckBoxSavePassword.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            _Label5.AutoSize = true;
            _Label5.Location = new Point(180, 55);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(35, 13);
            _Label5.TabIndex = 15;
            _Label5.Text = "Game";
            // 
            // ComboBoxGame
            // 
            _ComboBoxGame.FormattingEnabled = true;
            _ComboBoxGame.Items.AddRange(new object[] { "DR", "DRX", "DRF", "GS3", "GSX", "MO", "HX" });
            _ComboBoxGame.Location = new Point(183, 71);
            _ComboBoxGame.Name = "ComboBoxGame";
            _ComboBoxGame.Size = new Size(165, 21);
            _ComboBoxGame.TabIndex = 3;
            _ComboBoxGame.Text = "DR";
            // 
            // TextBoxCharacter
            // 
            _TextBoxCharacter.Location = new Point(9, 71);
            _TextBoxCharacter.Name = "TextBoxCharacter";
            _TextBoxCharacter.Size = new Size(165, 20);
            _TextBoxCharacter.TabIndex = 2;
            // 
            // Label4
            // 
            _Label4.AutoSize = true;
            _Label4.Location = new Point(6, 55);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(84, 13);
            _Label4.TabIndex = 12;
            _Label4.Text = "Character Name";
            // 
            // TextBoxPassword
            // 
            _TextBoxPassword.Location = new Point(183, 32);
            _TextBoxPassword.Name = "TextBoxPassword";
            _TextBoxPassword.Size = new Size(165, 20);
            _TextBoxPassword.TabIndex = 1;
            _TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Location = new Point(180, 16);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(53, 13);
            _Label3.TabIndex = 10;
            _Label3.Text = "Password";
            // 
            // TextBoxAccount
            // 
            _TextBoxAccount.CharacterCasing = CharacterCasing.Upper;
            _TextBoxAccount.Location = new Point(9, 32);
            _TextBoxAccount.Name = "TextBoxAccount";
            _TextBoxAccount.Size = new Size(165, 20);
            _TextBoxAccount.TabIndex = 0;
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 16);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(78, 13);
            _Label2.TabIndex = 8;
            _Label2.Text = "Account Name";
            // 
            // Label1
            // 
            _Label1.Location = new Point(51, 121);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(301, 32);
            _Label1.TabIndex = 7;
            _Label1.Text = "Leave character name empty to get a list of characters on the account.";
            // 
            // PictureBox1
            // 
            _PictureBox1.Image = My.Resources.Resources.network_transmit;
            _PictureBox1.Location = new Point(9, 121);
            _PictureBox1.Name = "PictureBox1";
            _PictureBox1.Size = new Size(32, 32);
            _PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            _PictureBox1.TabIndex = 6;
            _PictureBox1.TabStop = false;
            // 
            // DialogConnect
            // 
            AcceptButton = _OK_Button;
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _Cancel_Button;
            ClientSize = new Size(370, 202);
            Controls.Add(_GroupBox1);
            Controls.Add(_TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogConnect";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Simutronics Game Connect";
            TopMost = true;
            _TableLayoutPanel1.ResumeLayout(false);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_PictureBox1).EndInit();
            Load += new EventHandler(DialogConnect_Load);
            VisibleChanged += new EventHandler(DialogConnect_VisibleChanged);
            ResumeLayout(false);
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

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private ComboBox _ComboBoxGame;

        internal ComboBox ComboBoxGame
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBoxGame;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBoxGame != null)
                {
                }

                _ComboBoxGame = value;
                if (_ComboBoxGame != null)
                {
                }
            }
        }

        private TextBox _TextBoxCharacter;

        internal TextBox TextBoxCharacter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxCharacter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxCharacter != null)
                {
                }

                _TextBoxCharacter = value;
                if (_TextBoxCharacter != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private TextBox _TextBoxPassword;

        internal TextBox TextBoxPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxPassword != null)
                {
                }

                _TextBoxPassword = value;
                if (_TextBoxPassword != null)
                {
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private TextBox _TextBoxAccount;

        internal TextBox TextBoxAccount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxAccount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxAccount != null)
                {
                }

                _TextBoxAccount = value;
                if (_TextBoxAccount != null)
                {
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
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

        private CheckBox _CheckBoxSavePassword;

        internal CheckBox CheckBoxSavePassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBoxSavePassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBoxSavePassword != null)
                {
                    _CheckBoxSavePassword.CheckedChanged -= CheckBoxSavePassword_CheckedChanged;
                }

                _CheckBoxSavePassword = value;
                if (_CheckBoxSavePassword != null)
                {
                    _CheckBoxSavePassword.CheckedChanged += CheckBoxSavePassword_CheckedChanged;
                }
            }
        }
    }
}