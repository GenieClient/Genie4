using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class FormSkin : Form
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
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._PanelContents = new System.Windows.Forms.Panel();
            this._RichTextBoxOutput = new GenieClient.ComponentRichTextBox();
            this._ContextMenuStripOutput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._TimeStampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._NameListOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._CloseWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._PanelContents.SuspendLayout();
            this._ContextMenuStripOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // _PanelContents
            // 
            this._PanelContents.BackColor = System.Drawing.Color.Black;
            this._PanelContents.Controls.Add(this._RichTextBoxOutput);
            this._PanelContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelContents.Location = new System.Drawing.Point(0, 0);
            this._PanelContents.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._PanelContents.Name = "_PanelContents";
            this._PanelContents.Size = new System.Drawing.Size(500, 385);
            this._PanelContents.TabIndex = 2;
            this._PanelContents.Visible = false;
            this._PanelContents.MouseEnter += new System.EventHandler(this.PanelContents_MouseEnter);
            // 
            // _RichTextBoxOutput
            // 
            this._RichTextBoxOutput.BackColor = System.Drawing.Color.Black;
            this._RichTextBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._RichTextBoxOutput.ContextMenuStrip = this._ContextMenuStripOutput;
            this._RichTextBoxOutput.DetectUrls = false;
            this._RichTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this._RichTextBoxOutput.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._RichTextBoxOutput.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._RichTextBoxOutput.FormParent = null;
            this._RichTextBoxOutput.HideSelection = false;
            this._RichTextBoxOutput.IsMainWindow = false;
            this._RichTextBoxOutput.Location = new System.Drawing.Point(0, 0);
            this._RichTextBoxOutput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._RichTextBoxOutput.MaxBufferSize = 500000;
            this._RichTextBoxOutput.MonoFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._RichTextBoxOutput.Name = "_RichTextBoxOutput";
            this._RichTextBoxOutput.NameListOnly = false;
            this._RichTextBoxOutput.ReadOnly = true;
            this._RichTextBoxOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this._RichTextBoxOutput.ShowSelectionMargin = true;
            this._RichTextBoxOutput.Size = new System.Drawing.Size(500, 385);
            this._RichTextBoxOutput.TabIndex = 7;
            this._RichTextBoxOutput.Text = "";
            this._RichTextBoxOutput.TimeStamp = false;
            this._RichTextBoxOutput.Visible = false;
            this._RichTextBoxOutput.EventKeyDown += new GenieClient.ComponentRichTextBox.EventKeyDownEventHandler(this.MyKeyDown);
            this._RichTextBoxOutput.EventKeyPress += new GenieClient.ComponentRichTextBox.EventKeyPressEventHandler(this.MyKeyPress);
            this._RichTextBoxOutput.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBoxOutput_LinkClicked);
            this._RichTextBoxOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this._RichTextBoxOutput_KeyDown);
            this._RichTextBoxOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._RichTextBoxOutput_KeyPress);
            this._RichTextBoxOutput.MouseUp += new System.Windows.Forms.MouseEventHandler(this._RichTextBoxOutput_MouseUp);
            this._RichTextBoxOutput.MouseDown += new System.Windows.Forms.MouseEventHandler(_RichTextBoxOutput_MouseDown);

            // 
            // _ContextMenuStripOutput
            // 
            this._ContextMenuStripOutput.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._ContextMenuStripOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ClearToolStripMenuItem,
            this._TimeStampToolStripMenuItem,
            this._NameListOnlyToolStripMenuItem,
            this._ToolStripSeparator1,
            this._CloseWindowToolStripMenuItem});
            this._ContextMenuStripOutput.Name = "ContextMenuStripOutput";
            this._ContextMenuStripOutput.Size = new System.Drawing.Size(205, 138);
            // 
            // _ClearToolStripMenuItem
            // 
            this._ClearToolStripMenuItem.Name = "_ClearToolStripMenuItem";
            this._ClearToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this._ClearToolStripMenuItem.Text = "Clear";
            this._ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // _TimeStampToolStripMenuItem
            // 
            this._TimeStampToolStripMenuItem.Name = "_TimeStampToolStripMenuItem";
            this._TimeStampToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this._TimeStampToolStripMenuItem.Text = "Time Stamp";
            this._TimeStampToolStripMenuItem.Click += new System.EventHandler(this.TimeStampToolStripMenuItem_Click);
            // 
            // _NameListOnlyToolStripMenuItem
            // 
            this._NameListOnlyToolStripMenuItem.Name = "_NameListOnlyToolStripMenuItem";
            this._NameListOnlyToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this._NameListOnlyToolStripMenuItem.Text = "Name List Only";
            this._NameListOnlyToolStripMenuItem.Click += new System.EventHandler(this.NameListOnlyToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator1
            // 
            this._ToolStripSeparator1.Name = "_ToolStripSeparator1";
            this._ToolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // _CloseWindowToolStripMenuItem
            // 
            this._CloseWindowToolStripMenuItem.Name = "_CloseWindowToolStripMenuItem";
            this._CloseWindowToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this._CloseWindowToolStripMenuItem.Text = "Close Window";
            this._CloseWindowToolStripMenuItem.Click += new System.EventHandler(this.CloseWindowToolStripMenuItem_Click);
            // 
            // FormSkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 385);
            this.Controls.Add(this._PanelContents);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MinimumSize = new System.Drawing.Size(83, 96);
            this.Name = "FormSkin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FormSkin_Load);
            this.Shown += new System.EventHandler(this.FormSkin_Shown);
            this.VisibleChanged += new System.EventHandler(this.FormSkin_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSkin_Paint);
            this.DoubleClick += new System.EventHandler(this.FormSkin_DoubleClick);
            this.Enter += new System.EventHandler(this.FormSkin_Enter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSkin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormSkin_MouseMove);
            this.GotFocus += FormSkin_GotFocus;
            this.Resize += new System.EventHandler(this.FormSkin_Resize);
            this._PanelContents.ResumeLayout(false);
            this._ContextMenuStripOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void FormSkin_GotFocus(object sender, EventArgs e)
        {
            this._RichTextBoxOutput.ComponentRichTextBox_GotFocus(sender, e);
        }

        private Panel _PanelContents;

        private Panel PanelContents
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelContents;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelContents != null)
                {
                    _PanelContents.MouseEnter -= PanelContents_MouseEnter;
                }

                _PanelContents = value;
                if (_PanelContents != null)
                {
                    _PanelContents.MouseEnter += PanelContents_MouseEnter;
                }
            }
        }

        private ComponentRichTextBox _RichTextBoxOutput;

        internal ComponentRichTextBox RichTextBoxOutput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RichTextBoxOutput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RichTextBoxOutput != null)
                {
                    _RichTextBoxOutput.EventKeyDown -= MyKeyDown;
                    _RichTextBoxOutput.EventKeyPress -= MyKeyPress;
                    _RichTextBoxOutput.LinkClicked -= RichTextBoxOutput_LinkClicked;
                }

                _RichTextBoxOutput = value;
                if (_RichTextBoxOutput != null)
                {
                    _RichTextBoxOutput.EventKeyDown += MyKeyDown;
                    _RichTextBoxOutput.EventKeyPress += MyKeyPress;
                    _RichTextBoxOutput.LinkClicked += RichTextBoxOutput_LinkClicked;
                }
            }
        }

        private ContextMenuStrip _ContextMenuStripOutput;

        internal ContextMenuStrip ContextMenuStripOutput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContextMenuStripOutput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContextMenuStripOutput != null)
                {
                }

                _ContextMenuStripOutput = value;
                if (_ContextMenuStripOutput != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ClearToolStripMenuItem;

        internal ToolStripMenuItem ClearToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ClearToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ClearToolStripMenuItem != null)
                {
                    _ClearToolStripMenuItem.Click -= ClearToolStripMenuItem_Click;
                }

                _ClearToolStripMenuItem = value;
                if (_ClearToolStripMenuItem != null)
                {
                    _ClearToolStripMenuItem.Click += ClearToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _TimeStampToolStripMenuItem;

        internal ToolStripMenuItem TimeStampToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TimeStampToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TimeStampToolStripMenuItem != null)
                {
                    _TimeStampToolStripMenuItem.Click -= TimeStampToolStripMenuItem_Click;
                }

                _TimeStampToolStripMenuItem = value;
                if (_TimeStampToolStripMenuItem != null)
                {
                    _TimeStampToolStripMenuItem.Click += TimeStampToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _NameListOnlyToolStripMenuItem;

        internal ToolStripMenuItem NameListOnlyToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NameListOnlyToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NameListOnlyToolStripMenuItem != null)
                {
                    _NameListOnlyToolStripMenuItem.Click -= NameListOnlyToolStripMenuItem_Click;
                }

                _NameListOnlyToolStripMenuItem = value;
                if (_NameListOnlyToolStripMenuItem != null)
                {
                    _NameListOnlyToolStripMenuItem.Click += NameListOnlyToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator1;

        internal ToolStripSeparator ToolStripSeparator1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator1 != null)
                {
                }

                _ToolStripSeparator1 = value;
                if (_ToolStripSeparator1 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _CloseWindowToolStripMenuItem;

        internal ToolStripMenuItem CloseWindowToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CloseWindowToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CloseWindowToolStripMenuItem != null)
                {
                    _CloseWindowToolStripMenuItem.Click -= CloseWindowToolStripMenuItem_Click;
                }

                _CloseWindowToolStripMenuItem = value;
                if (_CloseWindowToolStripMenuItem != null)
                {
                    _CloseWindowToolStripMenuItem.Click += CloseWindowToolStripMenuItem_Click;
                }
            }
        }
    }
}