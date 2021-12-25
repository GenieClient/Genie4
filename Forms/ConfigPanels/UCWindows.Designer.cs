using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class UCWindows : UserControl
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
            components = new System.ComponentModel.Container();
            _ListViewBase = new ListView();
            _ListViewBase.KeyUp += new KeyEventHandler(ListViewBase_KeyUp);
            _ListViewBase.MouseUp += new MouseEventHandler(ListViewBase_MouseUp);
            _ListViewBase.SelectedIndexChanged += new EventHandler(ListViewBase_SelectedIndexChanged);
            _ContextMenuStripBase = new ContextMenuStrip(components);
            _AddToolStripMenuItem = new ToolStripMenuItem();
            _AddToolStripMenuItem.Click += new EventHandler(AddToolStripMenuItem_Click);
            _RemoveToolStripMenuItem = new ToolStripMenuItem();
            _RemoveToolStripMenuItem.Click += new EventHandler(RemoveToolStripMenuItem_Click);
            _ToolStripMenu = new ToolStrip();
            _ToolStripButtonRefresh = new ToolStripButton();
            _ToolStripButtonRefresh.Click += new EventHandler(ToolStripButtonRefresh_Click);
            _ToolStripSeparator2 = new ToolStripSeparator();
            _ToolStripButtonAdd = new ToolStripButton();
            _ToolStripButtonAdd.Click += new EventHandler(ToolStripButtonAdd_Click);
            _ToolStripButtonRemove = new ToolStripButton();
            _ToolStripButtonRemove.Click += new EventHandler(ToolStripButtonRemove_Click);
            _ToolStripSeparator1 = new ToolStripSeparator();
            _ToolStripButtonLoad = new ToolStripButton();
            _ToolStripButtonLoad.Click += new EventHandler(ToolStripButtonLoad_Click);
            _ToolStripButtonSave = new ToolStripButton();
            _ToolStripButtonSave.Click += new EventHandler(ToolStripButtonSave_Click);
            _TextBoxTitle = new TextBox();
            _TextBoxTitle.TextChanged += new EventHandler(TextBoxTitle_TextChanged);
            _ButtonApply = new Button();
            _ButtonApply.Click += new EventHandler(ButtonApply_Click);
            _GroupBoxBase = new GroupBox();
            _LabelIfClosed = new Label();
            _ComboBoxIfClosed = new ComboBox();
            _ButtonColorBg = new Button();
            _ButtonColorBg.Click += new EventHandler(ButtonColorBg_Click);
            _LabelExampleColor = new Label();
            _ButtonColorFg = new Button();
            _ButtonColorFg.Click += new EventHandler(ButtonColorFg_Click);
            _LabelColor = new Label();
            _TextBoxColor = new TextBox();
            _TextBoxColor.TextChanged += new EventHandler(TextBoxTitle_TextChanged);
            _TextBoxColor.KeyDown += new KeyEventHandler(TextBoxColor_KeyDown);
            _TextBoxColor.Leave += new EventHandler(TextBoxColor_Leave);
            _CheckBoxNameListOnly = new CheckBox();
            _CheckBoxNameListOnly.CheckedChanged += new EventHandler(CheckBoxNameListOnly_CheckedChanged);
            _CheckBoxTimeStamp = new CheckBox();
            _CheckBoxTimeStamp.CheckedChanged += new EventHandler(CheckBoxTimeStamp_CheckedChanged);
            _ButtonFont = new Button();
            _ButtonFont.Click += new EventHandler(ButtonFont_Click);
            _LabelFont = new Label();
            _TextBoxFont = new TextBox();
            _LabelTitle = new Label();
            _FontDialogPicker = new FontDialog();
            _ColorDialogPicker = new ColorDialog();
            _OpenFileDialogLayout = new OpenFileDialog();
            _SaveFileDialogLayout = new SaveFileDialog();
            _ContextMenuStripBase.SuspendLayout();
            _ToolStripMenu.SuspendLayout();
            _GroupBoxBase.SuspendLayout();
            SuspendLayout();
            // 
            // ListViewBase
            // 
            _ListViewBase.BackColor = Color.Black;
            _ListViewBase.ContextMenuStrip = _ContextMenuStripBase;
            _ListViewBase.Dock = DockStyle.Fill;
            _ListViewBase.ForeColor = Color.White;
            _ListViewBase.FullRowSelect = true;
            _ListViewBase.HideSelection = false;
            _ListViewBase.Location = new Point(0, 25);
            _ListViewBase.Name = "ListViewBase";
            _ListViewBase.ShowGroups = false;
            _ListViewBase.Size = new Size(698, 259);
            _ListViewBase.Sorting = SortOrder.Ascending;
            _ListViewBase.TabIndex = 0;
            _ListViewBase.UseCompatibleStateImageBehavior = false;
            _ListViewBase.View = View.Details;
            // 
            // ContextMenuStripBase
            // 
            _ContextMenuStripBase.Items.AddRange(new ToolStripItem[] { _AddToolStripMenuItem, _RemoveToolStripMenuItem });
            _ContextMenuStripBase.Name = "ContextMenuStripBase";
            _ContextMenuStripBase.Size = new Size(118, 48);
            // 
            // AddToolStripMenuItem
            // 
            _AddToolStripMenuItem.Image = My.Resources.Resources.document_new;
            _AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            _AddToolStripMenuItem.Size = new Size(117, 22);
            _AddToolStripMenuItem.Text = "Add";
            // 
            // RemoveToolStripMenuItem
            // 
            _RemoveToolStripMenuItem.Enabled = false;
            _RemoveToolStripMenuItem.Image = My.Resources.Resources.edit_clear;
            _RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            _RemoveToolStripMenuItem.Size = new Size(117, 22);
            _RemoveToolStripMenuItem.Text = "Remove";
            // 
            // ToolStripMenu
            // 
            _ToolStripMenu.AllowMerge = false;
            _ToolStripMenu.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripMenu.Items.AddRange(new ToolStripItem[] { _ToolStripButtonRefresh, _ToolStripSeparator2, _ToolStripButtonAdd, _ToolStripButtonRemove, _ToolStripSeparator1, _ToolStripButtonLoad, _ToolStripButtonSave });
            _ToolStripMenu.Location = new Point(0, 0);
            _ToolStripMenu.Name = "ToolStripMenu";
            _ToolStripMenu.Size = new Size(698, 25);
            _ToolStripMenu.TabIndex = 5;
            // 
            // ToolStripButtonRefresh
            // 
            _ToolStripButtonRefresh.Image = My.Resources.Resources.view_refresh;
            _ToolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRefresh.Name = "ToolStripButtonRefresh";
            _ToolStripButtonRefresh.Size = new Size(66, 22);
            _ToolStripButtonRefresh.Text = "Refresh";
            // 
            // ToolStripSeparator2
            // 
            _ToolStripSeparator2.Name = "ToolStripSeparator2";
            _ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripButtonAdd
            // 
            _ToolStripButtonAdd.Image = My.Resources.Resources.document_new;
            _ToolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonAdd.Name = "ToolStripButtonAdd";
            _ToolStripButtonAdd.Size = new Size(49, 22);
            _ToolStripButtonAdd.Text = "Add";
            // 
            // ToolStripButtonRemove
            // 
            _ToolStripButtonRemove.Enabled = false;
            _ToolStripButtonRemove.Image = My.Resources.Resources.edit_clear;
            _ToolStripButtonRemove.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRemove.Name = "ToolStripButtonRemove";
            _ToolStripButtonRemove.Size = new Size(70, 22);
            _ToolStripButtonRemove.Text = "Remove";
            // 
            // ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "ToolStripSeparator1";
            _ToolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolStripButtonLoad
            // 
            _ToolStripButtonLoad.Image = My.Resources.Resources.document_open;
            _ToolStripButtonLoad.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonLoad.Name = "ToolStripButtonLoad";
            _ToolStripButtonLoad.Size = new Size(62, 22);
            _ToolStripButtonLoad.Text = "Load...";
            // 
            // ToolStripButtonSave
            // 
            _ToolStripButtonSave.Image = My.Resources.Resources.document_save;
            _ToolStripButtonSave.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonSave.Name = "ToolStripButtonSave";
            _ToolStripButtonSave.Size = new Size(60, 22);
            _ToolStripButtonSave.Text = "Save...";
            // 
            // TextBoxTitle
            // 
            _TextBoxTitle.Location = new Point(6, 32);
            _TextBoxTitle.Name = "TextBoxTitle";
            _TextBoxTitle.Size = new Size(300, 20);
            _TextBoxTitle.TabIndex = 6;
            // 
            // ButtonApply
            // 
            _ButtonApply.Location = new Point(6, 120);
            _ButtonApply.Name = "ButtonApply";
            _ButtonApply.Size = new Size(75, 23);
            _ButtonApply.TabIndex = 7;
            _ButtonApply.Text = "Apply";
            _ButtonApply.UseVisualStyleBackColor = true;
            // 
            // GroupBoxBase
            // 
            _GroupBoxBase.AutoSize = true;
            _GroupBoxBase.Controls.Add(_LabelIfClosed);
            _GroupBoxBase.Controls.Add(_ComboBoxIfClosed);
            _GroupBoxBase.Controls.Add(_ButtonColorBg);
            _GroupBoxBase.Controls.Add(_LabelExampleColor);
            _GroupBoxBase.Controls.Add(_ButtonColorFg);
            _GroupBoxBase.Controls.Add(_LabelColor);
            _GroupBoxBase.Controls.Add(_TextBoxColor);
            _GroupBoxBase.Controls.Add(_CheckBoxNameListOnly);
            _GroupBoxBase.Controls.Add(_CheckBoxTimeStamp);
            _GroupBoxBase.Controls.Add(_ButtonFont);
            _GroupBoxBase.Controls.Add(_LabelFont);
            _GroupBoxBase.Controls.Add(_TextBoxFont);
            _GroupBoxBase.Controls.Add(_LabelTitle);
            _GroupBoxBase.Controls.Add(_ButtonApply);
            _GroupBoxBase.Controls.Add(_TextBoxTitle);
            _GroupBoxBase.Dock = DockStyle.Bottom;
            _GroupBoxBase.Enabled = false;
            _GroupBoxBase.Location = new Point(0, 284);
            _GroupBoxBase.Name = "GroupBoxBase";
            _GroupBoxBase.Size = new Size(698, 162);
            _GroupBoxBase.TabIndex = 4;
            _GroupBoxBase.TabStop = false;
            // 
            // LabelIfClosed
            // 
            _LabelIfClosed.AutoSize = true;
            _LabelIfClosed.Location = new Point(309, 55);
            _LabelIfClosed.Name = "LabelIfClosed";
            _LabelIfClosed.Size = new Size(91, 13);
            _LabelIfClosed.TabIndex = 20;
            _LabelIfClosed.Text = "Redirect If Closed";
            // 
            // ComboBoxIfClosed
            // 
            _ComboBoxIfClosed.DropDownStyle = ComboBoxStyle.DropDownList;
            _ComboBoxIfClosed.FormattingEnabled = true;
            _ComboBoxIfClosed.Location = new Point(312, 70);
            _ComboBoxIfClosed.Name = "ComboBoxIfClosed";
            _ComboBoxIfClosed.Size = new Size(245, 21);
            _ComboBoxIfClosed.Sorted = true;
            _ComboBoxIfClosed.TabIndex = 19;
            // 
            // ButtonColorBg
            // 
            _ButtonColorBg.Image = My.Resources.Resources.preferences_desktop_locale;
            _ButtonColorBg.Location = new Point(263, 70);
            _ButtonColorBg.Name = "ButtonColorBg";
            _ButtonColorBg.Size = new Size(23, 23);
            _ButtonColorBg.TabIndex = 18;
            _ButtonColorBg.UseVisualStyleBackColor = true;
            // 
            // LabelExampleColor
            // 
            _LabelExampleColor.BackColor = Color.Black;
            _LabelExampleColor.Font = new Font("Verdana", 9.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelExampleColor.ForeColor = Color.Black;
            _LabelExampleColor.Location = new Point(164, 71);
            _LabelExampleColor.Name = "LabelExampleColor";
            _LabelExampleColor.Size = new Size(64, 20);
            _LabelExampleColor.TabIndex = 17;
            _LabelExampleColor.Text = "Color";
            _LabelExampleColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonColorFg
            // 
            _ButtonColorFg.Image = My.Resources.Resources.applications_graphics;
            _ButtonColorFg.Location = new Point(234, 70);
            _ButtonColorFg.Name = "ButtonColorFg";
            _ButtonColorFg.Size = new Size(23, 23);
            _ButtonColorFg.TabIndex = 15;
            _ButtonColorFg.UseVisualStyleBackColor = true;
            // 
            // LabelColor
            // 
            _LabelColor.AutoSize = true;
            _LabelColor.Location = new Point(3, 55);
            _LabelColor.Name = "LabelColor";
            _LabelColor.Size = new Size(73, 13);
            _LabelColor.TabIndex = 16;
            _LabelColor.Text = "Window Color";
            // 
            // TextBoxColor
            // 
            _TextBoxColor.Location = new Point(6, 71);
            _TextBoxColor.Name = "TextBoxColor";
            _TextBoxColor.Size = new Size(152, 20);
            _TextBoxColor.TabIndex = 14;
            // 
            // CheckBoxNameListOnly
            // 
            _CheckBoxNameListOnly.AutoSize = true;
            _CheckBoxNameListOnly.Location = new Point(145, 97);
            _CheckBoxNameListOnly.Name = "CheckBoxNameListOnly";
            _CheckBoxNameListOnly.Size = new Size(103, 17);
            _CheckBoxNameListOnly.TabIndex = 13;
            _CheckBoxNameListOnly.Text = "Name List Only?";
            _CheckBoxNameListOnly.UseVisualStyleBackColor = true;
            // 
            // CheckBoxTimeStamp
            // 
            _CheckBoxTimeStamp.AutoSize = true;
            _CheckBoxTimeStamp.Location = new Point(6, 97);
            _CheckBoxTimeStamp.Name = "CheckBoxTimeStamp";
            _CheckBoxTimeStamp.Size = new Size(123, 17);
            _CheckBoxTimeStamp.TabIndex = 12;
            _CheckBoxTimeStamp.Text = "Time Stamp Output?";
            _CheckBoxTimeStamp.UseVisualStyleBackColor = true;
            // 
            // ButtonFont
            // 
            _ButtonFont.Image = My.Resources.Resources.font_x_generic;
            _ButtonFont.ImageAlign = ContentAlignment.BottomLeft;
            _ButtonFont.Location = new Point(482, 30);
            _ButtonFont.Name = "ButtonFont";
            _ButtonFont.Size = new Size(75, 23);
            _ButtonFont.TabIndex = 11;
            _ButtonFont.Text = "Font";
            _ButtonFont.UseVisualStyleBackColor = true;
            // 
            // LabelFont
            // 
            _LabelFont.AutoSize = true;
            _LabelFont.Location = new Point(309, 16);
            _LabelFont.Name = "LabelFont";
            _LabelFont.Size = new Size(28, 13);
            _LabelFont.TabIndex = 10;
            _LabelFont.Text = "Font";
            // 
            // TextBoxFont
            // 
            _TextBoxFont.Location = new Point(312, 32);
            _TextBoxFont.Name = "TextBoxFont";
            _TextBoxFont.ReadOnly = true;
            _TextBoxFont.Size = new Size(168, 20);
            _TextBoxFont.TabIndex = 9;
            // 
            // LabelTitle
            // 
            _LabelTitle.AutoSize = true;
            _LabelTitle.Location = new Point(3, 16);
            _LabelTitle.Name = "LabelTitle";
            _LabelTitle.Size = new Size(27, 13);
            _LabelTitle.TabIndex = 8;
            _LabelTitle.Text = "Title";
            // 
            // FontDialogPicker
            // 
            _FontDialogPicker.FontMustExist = true;
            _FontDialogPicker.ShowEffects = false;
            // 
            // ColorDialogPicker
            // 
            _ColorDialogPicker.FullOpen = true;
            // 
            // OpenFileDialogLayout
            // 
            _OpenFileDialogLayout.DefaultExt = "layout";
            _OpenFileDialogLayout.Filter = "Genie Layout|*.layout|All files|*.*";
            _OpenFileDialogLayout.RestoreDirectory = true;
            _OpenFileDialogLayout.Title = "Open Layout";
            // 
            // SaveFileDialogLayout
            // 
            _SaveFileDialogLayout.DefaultExt = "layout";
            _SaveFileDialogLayout.Filter = "Genie Layout|*.layout|All files|*.*";
            _SaveFileDialogLayout.RestoreDirectory = true;
            _SaveFileDialogLayout.Title = "Save Layout";
            // 
            // UCWindows
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_ListViewBase);
            Controls.Add(_ToolStripMenu);
            Controls.Add(_GroupBoxBase);
            Name = "UCWindows";
            Size = new Size(698, 446);
            _ContextMenuStripBase.ResumeLayout(false);
            _ToolStripMenu.ResumeLayout(false);
            _ToolStripMenu.PerformLayout();
            _GroupBoxBase.ResumeLayout(false);
            _GroupBoxBase.PerformLayout();
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

        private ContextMenuStrip _ContextMenuStripBase;

        internal ContextMenuStrip ContextMenuStripBase
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContextMenuStripBase;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContextMenuStripBase != null)
                {
                }

                _ContextMenuStripBase = value;
                if (_ContextMenuStripBase != null)
                {
                }
            }
        }

        private ToolStripMenuItem _AddToolStripMenuItem;

        internal ToolStripMenuItem AddToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AddToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AddToolStripMenuItem != null)
                {
                    _AddToolStripMenuItem.Click -= AddToolStripMenuItem_Click;
                }

                _AddToolStripMenuItem = value;
                if (_AddToolStripMenuItem != null)
                {
                    _AddToolStripMenuItem.Click += AddToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _RemoveToolStripMenuItem;

        internal ToolStripMenuItem RemoveToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RemoveToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RemoveToolStripMenuItem != null)
                {
                    _RemoveToolStripMenuItem.Click -= RemoveToolStripMenuItem_Click;
                }

                _RemoveToolStripMenuItem = value;
                if (_RemoveToolStripMenuItem != null)
                {
                    _RemoveToolStripMenuItem.Click += RemoveToolStripMenuItem_Click;
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

        private ToolStripButton _ToolStripButtonAdd;

        internal ToolStripButton ToolStripButtonAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonAdd != null)
                {
                    _ToolStripButtonAdd.Click -= ToolStripButtonAdd_Click;
                }

                _ToolStripButtonAdd = value;
                if (_ToolStripButtonAdd != null)
                {
                    _ToolStripButtonAdd.Click += ToolStripButtonAdd_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonRemove;

        internal ToolStripButton ToolStripButtonRemove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonRemove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonRemove != null)
                {
                    _ToolStripButtonRemove.Click -= ToolStripButtonRemove_Click;
                }

                _ToolStripButtonRemove = value;
                if (_ToolStripButtonRemove != null)
                {
                    _ToolStripButtonRemove.Click += ToolStripButtonRemove_Click;
                }
            }
        }

        private TextBox _TextBoxTitle;

        internal TextBox TextBoxTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxTitle != null)
                {
                    _TextBoxTitle.TextChanged -= TextBoxTitle_TextChanged;
                }

                _TextBoxTitle = value;
                if (_TextBoxTitle != null)
                {
                    _TextBoxTitle.TextChanged += TextBoxTitle_TextChanged;
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

        private Label _LabelTitle;

        internal Label LabelTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelTitle != null)
                {
                }

                _LabelTitle = value;
                if (_LabelTitle != null)
                {
                }
            }
        }

        private Button _ButtonFont;

        internal Button ButtonFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonFont != null)
                {
                    _ButtonFont.Click -= ButtonFont_Click;
                }

                _ButtonFont = value;
                if (_ButtonFont != null)
                {
                    _ButtonFont.Click += ButtonFont_Click;
                }
            }
        }

        private Label _LabelFont;

        internal Label LabelFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelFont != null)
                {
                }

                _LabelFont = value;
                if (_LabelFont != null)
                {
                }
            }
        }

        private TextBox _TextBoxFont;

        internal TextBox TextBoxFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxFont != null)
                {
                }

                _TextBoxFont = value;
                if (_TextBoxFont != null)
                {
                }
            }
        }

        private FontDialog _FontDialogPicker;

        internal FontDialog FontDialogPicker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FontDialogPicker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FontDialogPicker != null)
                {
                }

                _FontDialogPicker = value;
                if (_FontDialogPicker != null)
                {
                }
            }
        }

        private CheckBox _CheckBoxTimeStamp;

        internal CheckBox CheckBoxTimeStamp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBoxTimeStamp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBoxTimeStamp != null)
                {
                    _CheckBoxTimeStamp.CheckedChanged -= CheckBoxTimeStamp_CheckedChanged;
                }

                _CheckBoxTimeStamp = value;
                if (_CheckBoxTimeStamp != null)
                {
                    _CheckBoxTimeStamp.CheckedChanged += CheckBoxTimeStamp_CheckedChanged;
                }
            }
        }

        private CheckBox _CheckBoxNameListOnly;

        internal CheckBox CheckBoxNameListOnly
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBoxNameListOnly;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBoxNameListOnly != null)
                {
                    _CheckBoxNameListOnly.CheckedChanged -= CheckBoxNameListOnly_CheckedChanged;
                }

                _CheckBoxNameListOnly = value;
                if (_CheckBoxNameListOnly != null)
                {
                    _CheckBoxNameListOnly.CheckedChanged += CheckBoxNameListOnly_CheckedChanged;
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
                    _TextBoxColor.TextChanged -= TextBoxTitle_TextChanged;
                    _TextBoxColor.KeyDown -= TextBoxColor_KeyDown;
                    _TextBoxColor.Leave -= TextBoxColor_Leave;
                }

                _TextBoxColor = value;
                if (_TextBoxColor != null)
                {
                    _TextBoxColor.TextChanged += TextBoxTitle_TextChanged;
                    _TextBoxColor.KeyDown += TextBoxColor_KeyDown;
                    _TextBoxColor.Leave += TextBoxColor_Leave;
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

        private Label _LabelIfClosed;

        internal Label LabelIfClosed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelIfClosed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelIfClosed != null)
                {
                }

                _LabelIfClosed = value;
                if (_LabelIfClosed != null)
                {
                }
            }
        }

        private ComboBox _ComboBoxIfClosed;

        internal ComboBox ComboBoxIfClosed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBoxIfClosed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBoxIfClosed != null)
                {
                }

                _ComboBoxIfClosed = value;
                if (_ComboBoxIfClosed != null)
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

        private OpenFileDialog _OpenFileDialogLayout;

        internal OpenFileDialog OpenFileDialogLayout
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpenFileDialogLayout;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpenFileDialogLayout != null)
                {
                }

                _OpenFileDialogLayout = value;
                if (_OpenFileDialogLayout != null)
                {
                }
            }
        }

        private SaveFileDialog _SaveFileDialogLayout;

        internal SaveFileDialog SaveFileDialogLayout
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveFileDialogLayout;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveFileDialogLayout != null)
                {
                }

                _SaveFileDialogLayout = value;
                if (_SaveFileDialogLayout != null)
                {
                }
            }
        }
    }
}