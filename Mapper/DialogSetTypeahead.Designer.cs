using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogSetTypeahead : Form
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
            _Cancel_Button = new Button();
            _TextboxTypeahead = new TextBox();
            labelAction = new Label();
            _TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // _TableLayoutPanel1
            // 
            _TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _TableLayoutPanel1.ColumnCount = 2;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _TableLayoutPanel1.Controls.Add(_OK_Button, 0, 0);
            _TableLayoutPanel1.Controls.Add(_Cancel_Button, 1, 0);
            _TableLayoutPanel1.Location = new Point(12, 39);
            _TableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            _TableLayoutPanel1.Name = "_TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _TableLayoutPanel1.Size = new Size(170, 33);
            _TableLayoutPanel1.TabIndex = 0;
            // 
            // _OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
            _OK_Button.Location = new Point(4, 3);
            _OK_Button.Margin = new Padding(4, 3, 4, 3);
            _OK_Button.Name = "_OK_Button";
            _OK_Button.Size = new Size(77, 27);
            _OK_Button.TabIndex = 0;
            _OK_Button.Text = "OK";
            _OK_Button.Click += OK_Button_Click;
            // 
            // _Cancel_Button
            // 
            _Cancel_Button.Anchor = AnchorStyles.None;
            _Cancel_Button.DialogResult = DialogResult.Cancel;
            _Cancel_Button.Location = new Point(89, 3);
            _Cancel_Button.Margin = new Padding(4, 3, 4, 3);
            _Cancel_Button.Name = "_Cancel_Button";
            _Cancel_Button.Size = new Size(77, 27);
            _Cancel_Button.TabIndex = 1;
            _Cancel_Button.Text = "Cancel";
            _Cancel_Button.Click += Cancel_Button_Click;
            // 
            // _TextboxTypeahead
            // 
            _TextboxTypeahead.Location = new Point(125, 7);
            _TextboxTypeahead.Margin = new Padding(4, 3, 4, 3);
            _TextboxTypeahead.Name = "_TextboxTypeahead";
            _TextboxTypeahead.Size = new Size(38, 23);
            _TextboxTypeahead.TabIndex = 0;
            // 
            // labelAction
            // 
            labelAction.AutoSize = true;
            labelAction.Location = new Point(14, 10);
            labelAction.Margin = new Padding(4, 0, 4, 0);
            labelAction.Name = "labelAction";
            labelAction.Size = new Size(93, 15);
            labelAction.TabIndex = 2;
            labelAction.Text = "Enter Typeahead";
            // 
            // DialogSetTypeahead
            // 
            AcceptButton = _OK_Button;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _Cancel_Button;
            ClientSize = new Size(196, 86);
            Controls.Add(labelAction);
            Controls.Add(_TextboxTypeahead);
            Controls.Add(_TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogSetTypeahead";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter Typeahead";
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

        private TextBox _TextboxTypeahead;

        internal TextBox TextBoxTarget
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextboxTypeahead;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextboxTypeahead != null)
                {
                }

                _TextboxTypeahead = value;
                if (_TextboxTypeahead != null)
                {
                }
            }
        }

        private Label labelAction;

        internal Label LabelName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return labelAction;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (labelAction != null)
                {
                }

                labelAction = value;
                if (labelAction != null)
                {
                }
            }
        }
    }
}