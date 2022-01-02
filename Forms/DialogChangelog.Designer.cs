using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogChangelog : Form
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
            _TextBoxInfo = new TextBox();
            _TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            _TableLayoutPanel1.ColumnCount = 1;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Controls.Add(_OK_Button, 0, 0);
            _TableLayoutPanel1.Dock = DockStyle.Bottom;
            _TableLayoutPanel1.Location = new Point(0, 478);
            _TableLayoutPanel1.Margin = new Padding(4, 4, 4, 4);
            _TableLayoutPanel1.Name = "TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.Size = new Size(792, 36);
            _TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
            _OK_Button.DialogResult = DialogResult.Cancel;
            _OK_Button.Location = new Point(351, 4);
            _OK_Button.Margin = new Padding(4, 4, 4, 4);
            _OK_Button.Name = "OK_Button";
            _OK_Button.Size = new Size(89, 28);
            _OK_Button.TabIndex = 0;
            _OK_Button.Text = "&Close";
            // 
            // TextBoxInfo
            // 
            _TextBoxInfo.BackColor = Color.White;
            _TextBoxInfo.Dock = DockStyle.Fill;
            _TextBoxInfo.Font = new Font("Courier New", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _TextBoxInfo.ForeColor = Color.Black;
            _TextBoxInfo.Location = new Point(0, 0);
            _TextBoxInfo.Margin = new Padding(4, 4, 4, 4);
            _TextBoxInfo.Multiline = true;
            _TextBoxInfo.Name = "TextBoxInfo";
            _TextBoxInfo.ReadOnly = true;
            _TextBoxInfo.ScrollBars = ScrollBars.Vertical;
            _TextBoxInfo.Size = new Size(792, 478);
            _TextBoxInfo.TabIndex = 1;
            // 
            // DialogChangelog
            // 
            AcceptButton = _OK_Button;
            AutoScaleDimensions = new SizeF(8.0F, 16.0F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _OK_Button;
            ClientSize = new Size(792, 514);
            Controls.Add(_TextBoxInfo);
            Controls.Add(_TableLayoutPanel1);
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogChangelog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Log";
            _TableLayoutPanel1.ResumeLayout(false);
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

        private TextBox _TextBoxInfo;

        internal TextBox TextBoxInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxInfo != null)
                {
                }

                _TextBoxInfo = value;
                if (_TextBoxInfo != null)
                {
                }
            }
        }
    }
}