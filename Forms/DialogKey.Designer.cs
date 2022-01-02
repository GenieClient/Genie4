using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogKey : Form
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
            _Label1 = new Label();
            _TextBox1 = new TextBox();
            _TableLayoutPanel1.SuspendLayout();
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
            _TableLayoutPanel1.Location = new Point(177, 55);
            _TableLayoutPanel1.Name = "TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Size = new Size(146, 29);
            _TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
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
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(3, 9);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(112, 13);
            _Label1.TabIndex = 1;
            _Label1.Text = "Enter your Genie3 key";
            // 
            // TextBox1
            // 
            _TextBox1.Location = new Point(6, 25);
            _TextBox1.Name = "TextBox1";
            _TextBox1.Size = new Size(314, 20);
            _TextBox1.TabIndex = 2;
            // 
            // DialogKey
            // 
            AcceptButton = _OK_Button;
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _Cancel_Button;
            ClientSize = new Size(326, 87);
            Controls.Add(_TextBox1);
            Controls.Add(_Label1);
            Controls.Add(_TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogKey";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Genie3 Key";
            _TableLayoutPanel1.ResumeLayout(false);
            Load += new EventHandler(DialogKey_Load);
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

        private TextBox _TextBox1;

        internal TextBox TextBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBox1 != null)
                {
                }

                _TextBox1 = value;
                if (_TextBox1 != null)
                {
                }
            }
        }
    }
}