using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class DialogUserWalk : Form
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            _TextboxRetry = new TextBox();
            _TextboxSuccess = new TextBox();
            _TextboxAction = new TextBox();
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
            _TableLayoutPanel1.Location = new Point(125, 158);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 101);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 22;
            label4.Text = "Retry - Optional";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 60);
            label3.Name = "label3";
            label3.Size = new Size(290, 15);
            label3.TabIndex = 21;
            label3.Text = "Success - Required for User Walk to function correctly";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 16);
            label2.Name = "label2";
            label2.Size = new Size(284, 15);
            label2.TabIndex = 20;
            label2.Text = "Action - Required for User Walk to function correctly";
            // 
            // _TextboxRetry
            // 
            _TextboxRetry.Location = new Point(12, 119);
            _TextboxRetry.Name = "_TextboxRetry";
            _TextboxRetry.Size = new Size(290, 23);
            _TextboxRetry.TabIndex = 19;
            // 
            // _TextboxSuccess
            // 
            _TextboxSuccess.Location = new Point(12, 78);
            _TextboxSuccess.Name = "_TextboxSuccess";
            _TextboxSuccess.Size = new Size(290, 23);
            _TextboxSuccess.TabIndex = 18;
            // 
            // _TextboxAction
            // 
            _TextboxAction.Location = new Point(12, 34);
            _TextboxAction.Name = "_TextboxAction";
            _TextboxAction.Size = new Size(290, 23);
            _TextboxAction.TabIndex = 17;
            // 
            // DialogUserWalk
            // 
            AcceptButton = _OK_Button;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _Cancel_Button;
            ClientSize = new Size(308, 203);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(_TextboxRetry);
            Controls.Add(_TextboxSuccess);
            Controls.Add(_TextboxAction);
            Controls.Add(_TableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogUserWalk";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Walk Configuration";
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
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox _TextboxRetry;
        private TextBox _TextboxSuccess;
        private TextBox _TextboxAction;

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
    }
}