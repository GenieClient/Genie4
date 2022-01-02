using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogDownload : Form
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
            _ProgressBar1 = new ProgressBar();
            _LabelFile = new Label();
            _LabelSpeed = new Label();
            _ButtonDownload = new Button();
            _ButtonDownload.Click += new EventHandler(Button1_Click);
            _LabelNewVersion = new Label();
            _TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            _TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _TableLayoutPanel1.ColumnCount = 2;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20.0F));
            _TableLayoutPanel1.Controls.Add(_OK_Button, 0, 0);
            _TableLayoutPanel1.Controls.Add(_Cancel_Button, 1, 0);
            _TableLayoutPanel1.Location = new Point(186, 136);
            _TableLayoutPanel1.Name = "TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Size = new Size(146, 29);
            _TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
            _OK_Button.Enabled = false;
            _OK_Button.Location = new Point(3, 3);
            _OK_Button.Name = "OK_Button";
            _OK_Button.Size = new Size(67, 23);
            _OK_Button.TabIndex = 0;
            _OK_Button.Text = "OK";
            // 
            // Cancel_Button
            // 
            _Cancel_Button.Anchor = AnchorStyles.None;
            _Cancel_Button.DialogResult = DialogResult.Cancel;
            _Cancel_Button.Location = new Point(76, 3);
            _Cancel_Button.Name = "Cancel_Button";
            _Cancel_Button.Size = new Size(67, 23);
            _Cancel_Button.TabIndex = 1;
            _Cancel_Button.Text = "Cancel";
            // 
            // ProgressBar1
            // 
            _ProgressBar1.Location = new Point(15, 91);
            _ProgressBar1.Name = "ProgressBar1";
            _ProgressBar1.Size = new Size(312, 16);
            _ProgressBar1.TabIndex = 1;
            // 
            // LabelFile
            // 
            _LabelFile.AutoSize = true;
            _LabelFile.Location = new Point(12, 75);
            _LabelFile.Name = "LabelFile";
            _LabelFile.Size = new Size(51, 13);
            _LabelFile.TabIndex = 2;
            _LabelFile.Text = "FileName";
            // 
            // LabelSpeed
            // 
            _LabelSpeed.AutoSize = true;
            _LabelSpeed.Location = new Point(12, 110);
            _LabelSpeed.Name = "LabelSpeed";
            _LabelSpeed.Size = new Size(38, 13);
            _LabelSpeed.TabIndex = 3;
            _LabelSpeed.Text = "Speed";
            // 
            // ButtonDownload
            // 
            _ButtonDownload.Location = new Point(12, 139);
            _ButtonDownload.Name = "ButtonDownload";
            _ButtonDownload.Size = new Size(67, 23);
            _ButtonDownload.TabIndex = 4;
            _ButtonDownload.Text = "Download";
            _ButtonDownload.UseVisualStyleBackColor = true;
            // 
            // LabelNewVersion
            // 
            _LabelNewVersion.AutoSize = true;
            _LabelNewVersion.Location = new Point(12, 9);
            _LabelNewVersion.Name = "LabelNewVersion";
            _LabelNewVersion.Size = new Size(162, 52);
            _LabelNewVersion.TabIndex = 5;
            _LabelNewVersion.Text = "There is a new version available!" + (char)13 + (char)10 + (char)13 + (char)10 + "Your version: 1.0.0.0" + (char)13 + (char)10 + "Available version: 1." + "0.0.0" + (char)13 + (char)10;
            // 
            // DialogDownload
            // 
            AcceptButton = _OK_Button;
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _Cancel_Button;
            ClientSize = new Size(344, 177);
            Controls.Add(_LabelNewVersion);
            Controls.Add(_ButtonDownload);
            Controls.Add(_LabelSpeed);
            Controls.Add(_LabelFile);
            Controls.Add(_ProgressBar1);
            Controls.Add(_TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogDownload";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update Status";
            _TableLayoutPanel1.ResumeLayout(false);
            Load += new EventHandler(DialogDownload_Load);
            FormClosing += new FormClosingEventHandler(DialogDownload_FormClosing);
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

        private ProgressBar _ProgressBar1;

        internal ProgressBar ProgressBar1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ProgressBar1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ProgressBar1 != null)
                {
                }

                _ProgressBar1 = value;
                if (_ProgressBar1 != null)
                {
                }
            }
        }

        private Label _LabelFile;

        internal Label LabelFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelFile != null)
                {
                }

                _LabelFile = value;
                if (_LabelFile != null)
                {
                }
            }
        }

        private Label _LabelSpeed;

        internal Label LabelSpeed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelSpeed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelSpeed != null)
                {
                }

                _LabelSpeed = value;
                if (_LabelSpeed != null)
                {
                }
            }
        }

        private Button _ButtonDownload;

        internal Button ButtonDownload
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonDownload;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonDownload != null)
                {
                    _ButtonDownload.Click -= Button1_Click;
                }

                _ButtonDownload = value;
                if (_ButtonDownload != null)
                {
                    _ButtonDownload.Click += Button1_Click;
                }
            }
        }

        private Label _LabelNewVersion;

        internal Label LabelNewVersion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelNewVersion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelNewVersion != null)
                {
                }

                _LabelNewVersion = value;
                if (_LabelNewVersion != null)
                {
                }
            }
        }
    }
}