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
            components = new System.ComponentModel.Container();
            _PanelContents = new Panel();
            _PanelContents.MouseEnter += new EventHandler(PanelContents_MouseEnter);
            _ContextMenuStripOutput = new ContextMenuStrip(components);
            _ClearToolStripMenuItem = new ToolStripMenuItem();
            _ClearToolStripMenuItem.Click += new EventHandler(ClearToolStripMenuItem_Click);
            _TimeStampToolStripMenuItem = new ToolStripMenuItem();
            _TimeStampToolStripMenuItem.Click += new EventHandler(TimeStampToolStripMenuItem_Click);
            _NameListOnlyToolStripMenuItem = new ToolStripMenuItem();
            _NameListOnlyToolStripMenuItem.Click += new EventHandler(NameListOnlyToolStripMenuItem_Click);
            _ToolStripSeparator1 = new ToolStripSeparator();
            _CloseWindowToolStripMenuItem = new ToolStripMenuItem();
            _CloseWindowToolStripMenuItem.Click += new EventHandler(CloseWindowToolStripMenuItem_Click);
            _RichTextBoxOutput = new ComponentRichTextBox();
            _RichTextBoxOutput.EventKeyDown += new ComponentRichTextBox.EventKeyDownEventHandler(MyKeyDown);
            _RichTextBoxOutput.EventKeyPress += new ComponentRichTextBox.EventKeyPressEventHandler(MyKeyPress);
            _RichTextBoxOutput.LinkClicked += new LinkClickedEventHandler(RichTextBoxOutput_LinkClicked);
            _PanelContents.SuspendLayout();
            _ContextMenuStripOutput.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContents
            // 
            _PanelContents.BackColor = Color.Black;
            _PanelContents.Controls.Add(_RichTextBoxOutput);
            _PanelContents.Dock = DockStyle.Fill;
            _PanelContents.Location = new Point(0, 0);
            _PanelContents.Name = "PanelContents";
            _PanelContents.Size = new Size(300, 200);
            _PanelContents.TabIndex = 2;
            _PanelContents.Visible = false;
            // 
            // ContextMenuStripOutput
            // 
            _ContextMenuStripOutput.Items.AddRange(new ToolStripItem[] { _ClearToolStripMenuItem, _TimeStampToolStripMenuItem, _NameListOnlyToolStripMenuItem, _ToolStripSeparator1, _CloseWindowToolStripMenuItem });
            _ContextMenuStripOutput.Name = "ContextMenuStripOutput";
            _ContextMenuStripOutput.Size = new Size(156, 98);
            // 
            // ClearToolStripMenuItem
            // 
            _ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            _ClearToolStripMenuItem.Size = new Size(155, 22);
            _ClearToolStripMenuItem.Text = "Clear";
            // 
            // TimeStampToolStripMenuItem
            // 
            _TimeStampToolStripMenuItem.Name = "TimeStampToolStripMenuItem";
            _TimeStampToolStripMenuItem.Size = new Size(155, 22);
            _TimeStampToolStripMenuItem.Text = "Time Stamp";
            // 
            // NameListOnlyToolStripMenuItem
            // 
            _NameListOnlyToolStripMenuItem.Name = "NameListOnlyToolStripMenuItem";
            _NameListOnlyToolStripMenuItem.Size = new Size(155, 22);
            _NameListOnlyToolStripMenuItem.Text = "Name List Only";
            // 
            // ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "ToolStripSeparator1";
            _ToolStripSeparator1.Size = new Size(152, 6);
            // 
            // CloseWindowToolStripMenuItem
            // 
            _CloseWindowToolStripMenuItem.Name = "CloseWindowToolStripMenuItem";
            _CloseWindowToolStripMenuItem.Size = new Size(155, 22);
            _CloseWindowToolStripMenuItem.Text = "Close Window";
            // 
            // RichTextBoxOutput
            // 
            _RichTextBoxOutput.BackColor = Color.Black;
            _RichTextBoxOutput.BorderStyle = BorderStyle.None;
            _RichTextBoxOutput.ContextMenuStrip = _ContextMenuStripOutput;
            _RichTextBoxOutput.DetectUrls = false;
            _RichTextBoxOutput.Dock = DockStyle.Fill;
            _RichTextBoxOutput.Font = new Font("Verdana", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _RichTextBoxOutput.ForeColor = Color.WhiteSmoke;
            _RichTextBoxOutput.FormParent = null;
            _RichTextBoxOutput.HideSelection = false;
            _RichTextBoxOutput.IsMainWindow = false;
            _RichTextBoxOutput.Location = new Point(0, 0);
            _RichTextBoxOutput.MaxBufferSize = 500000;
            _RichTextBoxOutput.MonoFont = new Font("Courier New", 9.0F);
            _RichTextBoxOutput.Name = "RichTextBoxOutput";
            _RichTextBoxOutput.NameListOnly = false;
            _RichTextBoxOutput.ReadOnly = true;
            _RichTextBoxOutput.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            _RichTextBoxOutput.ShowSelectionMargin = true;
            _RichTextBoxOutput.Size = new Size(300, 200);
            _RichTextBoxOutput.TabIndex = 7;
            _RichTextBoxOutput.Text = "";
            _RichTextBoxOutput.TimeStamp = false;
            _RichTextBoxOutput.Visible = false;
            // 
            // FormSkin
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(300, 200);
            Controls.Add(_PanelContents);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(50, 50);
            Name = "FormSkin";
            StartPosition = FormStartPosition.Manual;
            _PanelContents.ResumeLayout(false);
            _ContextMenuStripOutput.ResumeLayout(false);
            DoubleClick += new EventHandler(FormSkin_DoubleClick);
            Load += new EventHandler(FormSkin_Load);
            Paint += new PaintEventHandler(FormSkin_Paint);
            MouseDown += new MouseEventHandler(FormSkin_MouseDown);
            MouseMove += new MouseEventHandler(FormSkin_MouseMove);
            Resize += new EventHandler(FormSkin_Resize);
            Enter += new EventHandler(FormSkin_Enter);
            VisibleChanged += new EventHandler(FormSkin_VisibleChanged);
            Shown += new EventHandler(FormSkin_Shown);
            ResumeLayout(false);
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