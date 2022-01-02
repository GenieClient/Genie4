using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogEdit : Form
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
            _TableLayoutPanel1 = new TableLayoutPanel();
            _OK_Button = new Button();
            _OK_Button.Click += new EventHandler(OK_Button_Click);
            _Cancel_Button = new Button();
            _Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            _RichTextBoxEdit = new RichTextBox();
            _Panel1 = new Panel();
            _TableLayoutPanel1.SuspendLayout();
            _Panel1.SuspendLayout();
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
            _TableLayoutPanel1.Location = new Point(277, 14);
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
            // RichTextBoxEdit
            // 
            _RichTextBoxEdit.DetectUrls = false;
            _RichTextBoxEdit.Dock = DockStyle.Fill;
            _RichTextBoxEdit.Font = new Font("Courier New", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _RichTextBoxEdit.Location = new Point(0, 0);
            _RichTextBoxEdit.Name = "RichTextBoxEdit";
            _RichTextBoxEdit.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            _RichTextBoxEdit.Size = new Size(435, 260);
            _RichTextBoxEdit.TabIndex = 0;
            _RichTextBoxEdit.Text = "";
            _RichTextBoxEdit.WordWrap = false;
            // 
            // Panel1
            // 
            _Panel1.Controls.Add(_TableLayoutPanel1);
            _Panel1.Dock = DockStyle.Bottom;
            _Panel1.Location = new Point(0, 260);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(435, 55);
            _Panel1.TabIndex = 2;
            // 
            // DialogEdit
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _Cancel_Button;
            ClientSize = new Size(435, 315);
            Controls.Add(_RichTextBoxEdit);
            Controls.Add(_Panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogEdit";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit";
            _TableLayoutPanel1.ResumeLayout(false);
            _Panel1.ResumeLayout(false);
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

        private RichTextBox _RichTextBoxEdit;

        internal RichTextBox RichTextBoxEdit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RichTextBoxEdit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RichTextBoxEdit != null)
                {
                }

                _RichTextBoxEdit = value;
                if (_RichTextBoxEdit != null)
                {
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }
    }
}