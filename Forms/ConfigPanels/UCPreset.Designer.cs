using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class UCPreset : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
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
            _ListViewBase = new ListView();
            _ListViewBase.KeyUp += new KeyEventHandler(ListViewBase_KeyUp);
            _ListViewBase.MouseUp += new MouseEventHandler(ListViewBase_MouseUp);
            _ListViewBase.SelectedIndexChanged += new EventHandler(ListViewBase_SelectedIndexChanged);
            _GroupBoxBase = new GroupBox();
            _ButtonColorBg = new Button();
            _ButtonColorBg.Click += new EventHandler(ButtonColorBg_Click);
            _LabelExampleColor = new Label();
            _ButtonColorFg = new Button();
            _ButtonColorFg.Click += new EventHandler(ButtonColorFg_Click);
            _LabelColor = new Label();
            _TextBoxPreset = new TextBox();
            _TextBoxPreset.TextChanged += new EventHandler(TextBox_TextChanged);
            _LabelAlias = new Label();
            _ButtonApply = new Button();
            _ButtonApply.Click += new EventHandler(ButtonApply_Click);
            _TextBoxColor = new TextBox();
            _TextBoxColor.KeyDown += new KeyEventHandler(TextBoxColor_KeyDown);
            _TextBoxColor.Leave += new EventHandler(TextBoxColor_Leave);
            _TextBoxColor.TextChanged += new EventHandler(TextBox_TextChanged);
            _ColorDialogPicker = new ColorDialog();
            _ToolStripMenu = new ToolStrip();
            _ToolStripButtonRefresh = new ToolStripButton();
            _ToolStripButtonRefresh.Click += new EventHandler(ToolStripButtonRefresh_Click);
            _ToolStripSeparator2 = new ToolStripSeparator();
            _ToolStripButtonLoad = new ToolStripButton();
            _ToolStripButtonLoad.Click += new EventHandler(ToolStripButtonLoad_Click);
            _ToolStripButtonSave = new ToolStripButton();
            _ToolStripButtonSave.Click += new EventHandler(ToolStripButtonSave_Click);
            _GroupBoxBase.SuspendLayout();
            _ToolStripMenu.SuspendLayout();
            SuspendLayout();
            // 
            // ListViewBase
            // 
            _ListViewBase.BackColor = Color.Black;
            _ListViewBase.Dock = DockStyle.Fill;
            _ListViewBase.ForeColor = Color.White;
            _ListViewBase.FullRowSelect = true;
            _ListViewBase.HideSelection = false;
            _ListViewBase.Location = new Point(0, 25);
            _ListViewBase.Name = "ListViewBase";
            _ListViewBase.ShowGroups = false;
            _ListViewBase.Size = new Size(698, 312);
            _ListViewBase.Sorting = SortOrder.Ascending;
            _ListViewBase.TabIndex = 0;
            _ListViewBase.UseCompatibleStateImageBehavior = false;
            _ListViewBase.View = View.Details;
            // 
            // GroupBoxBase
            // 
            _GroupBoxBase.AutoSize = true;
            _GroupBoxBase.Controls.Add(_ButtonColorBg);
            _GroupBoxBase.Controls.Add(_LabelExampleColor);
            _GroupBoxBase.Controls.Add(_ButtonColorFg);
            _GroupBoxBase.Controls.Add(_LabelColor);
            _GroupBoxBase.Controls.Add(_TextBoxPreset);
            _GroupBoxBase.Controls.Add(_LabelAlias);
            _GroupBoxBase.Controls.Add(_ButtonApply);
            _GroupBoxBase.Controls.Add(_TextBoxColor);
            _GroupBoxBase.Dock = DockStyle.Bottom;
            _GroupBoxBase.Enabled = false;
            _GroupBoxBase.Location = new Point(0, 337);
            _GroupBoxBase.Name = "GroupBoxBase";
            _GroupBoxBase.Size = new Size(698, 109);
            _GroupBoxBase.TabIndex = 2;
            _GroupBoxBase.TabStop = false;
            // 
            // ButtonColorBg
            // 
            _ButtonColorBg.Image = My.Resources.Resources.preferences_desktop_locale;
            _ButtonColorBg.Location = new Point(421, 31);
            _ButtonColorBg.Name = "ButtonColorBg";
            _ButtonColorBg.Size = new Size(23, 23);
            _ButtonColorBg.TabIndex = 12;
            _ButtonColorBg.UseVisualStyleBackColor = true;
            // 
            // LabelExampleColor
            // 
            _LabelExampleColor.BackColor = Color.Black;
            _LabelExampleColor.Font = new Font("Verdana", 9.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelExampleColor.ForeColor = Color.Black;
            _LabelExampleColor.Location = new Point(322, 32);
            _LabelExampleColor.Name = "LabelExampleColor";
            _LabelExampleColor.Size = new Size(64, 20);
            _LabelExampleColor.TabIndex = 11;
            _LabelExampleColor.Text = "Color";
            _LabelExampleColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonColorFg
            // 
            _ButtonColorFg.Image = My.Resources.Resources.applications_graphics;
            _ButtonColorFg.Location = new Point(392, 31);
            _ButtonColorFg.Name = "ButtonColorFg";
            _ButtonColorFg.Size = new Size(23, 23);
            _ButtonColorFg.TabIndex = 3;
            _ButtonColorFg.UseVisualStyleBackColor = true;
            // 
            // LabelColor
            // 
            _LabelColor.AutoSize = true;
            _LabelColor.Location = new Point(161, 16);
            _LabelColor.Name = "LabelColor";
            _LabelColor.Size = new Size(31, 13);
            _LabelColor.TabIndex = 10;
            _LabelColor.Text = "Color";
            // 
            // TextBoxPreset
            // 
            _TextBoxPreset.Location = new Point(6, 32);
            _TextBoxPreset.Name = "TextBoxPreset";
            _TextBoxPreset.ReadOnly = true;
            _TextBoxPreset.Size = new Size(152, 20);
            _TextBoxPreset.TabIndex = 0;
            // 
            // LabelAlias
            // 
            _LabelAlias.AutoSize = true;
            _LabelAlias.Location = new Point(3, 16);
            _LabelAlias.Name = "LabelAlias";
            _LabelAlias.Size = new Size(37, 13);
            _LabelAlias.TabIndex = 8;
            _LabelAlias.Text = "Preset";
            // 
            // ButtonApply
            // 
            _ButtonApply.Location = new Point(6, 67);
            _ButtonApply.Name = "ButtonApply";
            _ButtonApply.Size = new Size(75, 23);
            _ButtonApply.TabIndex = 2;
            _ButtonApply.Text = "Apply";
            _ButtonApply.UseVisualStyleBackColor = true;
            // 
            // TextBoxColor
            // 
            _TextBoxColor.Location = new Point(164, 32);
            _TextBoxColor.Name = "TextBoxColor";
            _TextBoxColor.Size = new Size(152, 20);
            _TextBoxColor.TabIndex = 1;
            // 
            // ColorDialogPicker
            // 
            _ColorDialogPicker.FullOpen = true;
            // 
            // ToolStripMenu
            // 
            _ToolStripMenu.AllowMerge = false;
            _ToolStripMenu.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripMenu.Items.AddRange(new ToolStripItem[] { _ToolStripButtonRefresh, _ToolStripSeparator2, _ToolStripButtonLoad, _ToolStripButtonSave });
            _ToolStripMenu.Location = new Point(0, 0);
            _ToolStripMenu.Name = "ToolStripMenu";
            _ToolStripMenu.Size = new Size(698, 25);
            _ToolStripMenu.TabIndex = 6;
            // 
            // ToolStripButtonRefresh
            // 
            _ToolStripButtonRefresh.Image = My.Resources.Resources.view_refresh;
            _ToolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRefresh.Name = "ToolStripButtonRefresh";
            _ToolStripButtonRefresh.Size = new Size(65, 22);
            _ToolStripButtonRefresh.Text = "Refresh";
            // 
            // ToolStripSeparator2
            // 
            _ToolStripSeparator2.Name = "ToolStripSeparator2";
            _ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripButtonLoad
            // 
            _ToolStripButtonLoad.Image = My.Resources.Resources.document_open;
            _ToolStripButtonLoad.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonLoad.Name = "ToolStripButtonLoad";
            _ToolStripButtonLoad.Size = new Size(50, 22);
            _ToolStripButtonLoad.Text = "Load";
            // 
            // ToolStripButtonSave
            // 
            _ToolStripButtonSave.Image = My.Resources.Resources.document_save;
            _ToolStripButtonSave.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonSave.Name = "ToolStripButtonSave";
            _ToolStripButtonSave.Size = new Size(51, 22);
            _ToolStripButtonSave.Text = "Save";
            // 
            // UCPreset
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_ListViewBase);
            Controls.Add(_GroupBoxBase);
            Controls.Add(_ToolStripMenu);
            Name = "UCPreset";
            Size = new Size(698, 446);
            _GroupBoxBase.ResumeLayout(false);
            _GroupBoxBase.PerformLayout();
            _ToolStripMenu.ResumeLayout(false);
            _ToolStripMenu.PerformLayout();
            Load += new EventHandler(UCWindows_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private ListView _ListViewBase;

        internal ListView ListViewBase
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ListViewBase;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ListViewBase != null)
                {
                    _ListViewBase.KeyUp -= ListViewBase_KeyUp;
                    _ListViewBase.MouseUp -= ListViewBase_MouseUp;
                    _ListViewBase.SelectedIndexChanged -= ListViewBase_SelectedIndexChanged;
                }

                _ListViewBase = value;
                if (_ListViewBase != null)
                {
                    _ListViewBase.KeyUp += ListViewBase_KeyUp;
                    _ListViewBase.MouseUp += ListViewBase_MouseUp;
                    _ListViewBase.SelectedIndexChanged += ListViewBase_SelectedIndexChanged;
                }
            }
        }

        private GroupBox _GroupBoxBase;

        internal GroupBox GroupBoxBase
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBoxBase;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBoxBase != null)
                {
                }

                _GroupBoxBase = value;
                if (_GroupBoxBase != null)
                {
                }
            }
        }

        private Label _LabelColor;

        internal Label LabelColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelColor != null)
                {
                }

                _LabelColor = value;
                if (_LabelColor != null)
                {
                }
            }
        }

        private TextBox _TextBoxPreset;

        internal TextBox TextBoxPreset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxPreset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxPreset != null)
                {
                    _TextBoxPreset.TextChanged -= TextBox_TextChanged;
                }

                _TextBoxPreset = value;
                if (_TextBoxPreset != null)
                {
                    _TextBoxPreset.TextChanged += TextBox_TextChanged;
                }
            }
        }

        private Label _LabelAlias;

        internal Label LabelAlias
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelAlias;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelAlias != null)
                {
                }

                _LabelAlias = value;
                if (_LabelAlias != null)
                {
                }
            }
        }

        private Button _ButtonApply;

        internal Button ButtonApply
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonApply;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonApply != null)
                {
                    _ButtonApply.Click -= ButtonApply_Click;
                }

                _ButtonApply = value;
                if (_ButtonApply != null)
                {
                    _ButtonApply.Click += ButtonApply_Click;
                }
            }
        }

        private TextBox _TextBoxColor;

        internal TextBox TextBoxColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxColor != null)
                {
                    _TextBoxColor.KeyDown -= TextBoxColor_KeyDown;
                    _TextBoxColor.Leave -= TextBoxColor_Leave;
                    _TextBoxColor.TextChanged -= TextBox_TextChanged;
                }

                _TextBoxColor = value;
                if (_TextBoxColor != null)
                {
                    _TextBoxColor.KeyDown += TextBoxColor_KeyDown;
                    _TextBoxColor.Leave += TextBoxColor_Leave;
                    _TextBoxColor.TextChanged += TextBox_TextChanged;
                }
            }
        }

        private ColorDialog _ColorDialogPicker;

        internal ColorDialog ColorDialogPicker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ColorDialogPicker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ColorDialogPicker != null)
                {
                }

                _ColorDialogPicker = value;
                if (_ColorDialogPicker != null)
                {
                }
            }
        }

        private Button _ButtonColorFg;

        internal Button ButtonColorFg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonColorFg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonColorFg != null)
                {
                    _ButtonColorFg.Click -= ButtonColorFg_Click;
                }

                _ButtonColorFg = value;
                if (_ButtonColorFg != null)
                {
                    _ButtonColorFg.Click += ButtonColorFg_Click;
                }
            }
        }

        private Label _LabelExampleColor;

        internal Label LabelExampleColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelExampleColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelExampleColor != null)
                {
                }

                _LabelExampleColor = value;
                if (_LabelExampleColor != null)
                {
                }
            }
        }

        private Button _ButtonColorBg;

        internal Button ButtonColorBg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonColorBg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonColorBg != null)
                {
                    _ButtonColorBg.Click -= ButtonColorBg_Click;
                }

                _ButtonColorBg = value;
                if (_ButtonColorBg != null)
                {
                    _ButtonColorBg.Click += ButtonColorBg_Click;
                }
            }
        }

        private ToolStrip _ToolStripMenu;

        internal ToolStrip ToolStripMenu
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenu;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenu != null)
                {
                }

                _ToolStripMenu = value;
                if (_ToolStripMenu != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonRefresh;

        internal ToolStripButton ToolStripButtonRefresh
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonRefresh;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonRefresh != null)
                {
                    _ToolStripButtonRefresh.Click -= ToolStripButtonRefresh_Click;
                }

                _ToolStripButtonRefresh = value;
                if (_ToolStripButtonRefresh != null)
                {
                    _ToolStripButtonRefresh.Click += ToolStripButtonRefresh_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator2;

        internal ToolStripSeparator ToolStripSeparator2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator2 != null)
                {
                }

                _ToolStripSeparator2 = value;
                if (_ToolStripSeparator2 != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonLoad;

        internal ToolStripButton ToolStripButtonLoad
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonLoad;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonLoad != null)
                {
                    _ToolStripButtonLoad.Click -= ToolStripButtonLoad_Click;
                }

                _ToolStripButtonLoad = value;
                if (_ToolStripButtonLoad != null)
                {
                    _ToolStripButtonLoad.Click += ToolStripButtonLoad_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonSave;

        internal ToolStripButton ToolStripButtonSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonSave != null)
                {
                    _ToolStripButtonSave.Click -= ToolStripButtonSave_Click;
                }

                _ToolStripButtonSave = value;
                if (_ToolStripButtonSave != null)
                {
                    _ToolStripButtonSave.Click += ToolStripButtonSave_Click;
                }
            }
        }
    }
}