using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GenieClient
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class UCIgnore : UserControl
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
            _ButtonApply = new Button();
            _ButtonApply.Click += new EventHandler(ButtonApply_Click);
            _GroupBoxBase = new GroupBox();
            _CheckBoxIgnoreCase = new CheckBox();
            _CheckBoxIgnoreCase.CheckedChanged += new EventHandler(TextBox_TextChanged);
            _TextBoxReplace = new TextBox();
            _TextBoxReplace.TextChanged += new EventHandler(TextBox_TextChanged);
            _LabelGag = new Label();
            _FontDialogPicker = new FontDialog();
            _LabelClass = new Label();
            _ComboBoxClass = new ComboBox();
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
            _ListViewBase.Size = new Size(698, 258);
            _ListViewBase.Sorting = SortOrder.Ascending;
            _ListViewBase.TabIndex = 3;
            _ListViewBase.UseCompatibleStateImageBehavior = false;
            _ListViewBase.View = View.Details;
            // 
            // ContextMenuStripBase
            // 
            _ContextMenuStripBase.Items.AddRange(new ToolStripItem[] { _AddToolStripMenuItem, _RemoveToolStripMenuItem });
            _ContextMenuStripBase.Name = "ContextMenuStripBase";
            _ContextMenuStripBase.Size = new Size(125, 48);
            // 
            // AddToolStripMenuItem
            // 
            _AddToolStripMenuItem.Image = My.Resources.Resources.document_new;
            _AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            _AddToolStripMenuItem.Size = new Size(124, 22);
            _AddToolStripMenuItem.Text = "Add";
            // 
            // RemoveToolStripMenuItem
            // 
            _RemoveToolStripMenuItem.Enabled = false;
            _RemoveToolStripMenuItem.Image = My.Resources.Resources.edit_clear;
            _RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            _RemoveToolStripMenuItem.Size = new Size(124, 22);
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
            _ToolStripButtonRefresh.Size = new Size(65, 22);
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
            _ToolStripButtonAdd.Size = new Size(46, 22);
            _ToolStripButtonAdd.Text = "Add";
            // 
            // ToolStripButtonRemove
            // 
            _ToolStripButtonRemove.Enabled = false;
            _ToolStripButtonRemove.Image = My.Resources.Resources.edit_clear;
            _ToolStripButtonRemove.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRemove.Name = "ToolStripButtonRemove";
            _ToolStripButtonRemove.Size = new Size(66, 22);
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
            // ButtonApply
            // 
            _ButtonApply.Location = new Point(6, 121);
            _ButtonApply.Name = "ButtonApply";
            _ButtonApply.Size = new Size(75, 23);
            _ButtonApply.TabIndex = 3;
            _ButtonApply.Text = "Apply";
            _ButtonApply.UseVisualStyleBackColor = true;
            // 
            // GroupBoxBase
            // 
            _GroupBoxBase.AutoSize = true;
            _GroupBoxBase.Controls.Add(_LabelClass);
            _GroupBoxBase.Controls.Add(_ComboBoxClass);
            _GroupBoxBase.Controls.Add(_CheckBoxIgnoreCase);
            _GroupBoxBase.Controls.Add(_TextBoxReplace);
            _GroupBoxBase.Controls.Add(_LabelGag);
            _GroupBoxBase.Controls.Add(_ButtonApply);
            _GroupBoxBase.Dock = DockStyle.Bottom;
            _GroupBoxBase.Enabled = false;
            _GroupBoxBase.Location = new Point(0, 283);
            _GroupBoxBase.Name = "GroupBoxBase";
            _GroupBoxBase.Size = new Size(698, 163);
            _GroupBoxBase.TabIndex = 4;
            _GroupBoxBase.TabStop = false;
            // 
            // CheckBoxIgnoreCase
            // 
            _CheckBoxIgnoreCase.AutoSize = true;
            _CheckBoxIgnoreCase.Location = new Point(6, 58);
            _CheckBoxIgnoreCase.Name = "CheckBoxIgnoreCase";
            _CheckBoxIgnoreCase.Size = new Size(83, 17);
            _CheckBoxIgnoreCase.TabIndex = 11;
            _CheckBoxIgnoreCase.Text = "Ignore Case";
            _CheckBoxIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // TextBoxReplace
            // 
            _TextBoxReplace.Location = new Point(6, 32);
            _TextBoxReplace.Name = "TextBoxReplace";
            _TextBoxReplace.Size = new Size(426, 20);
            _TextBoxReplace.TabIndex = 1;
            // 
            // LabelGag
            // 
            _LabelGag.AutoSize = true;
            _LabelGag.Location = new Point(3, 16);
            _LabelGag.Name = "LabelGag";
            _LabelGag.Size = new Size(127, 13);
            _LabelGag.TabIndex = 8;
            _LabelGag.Text = "Gag (Regular Expression)";
            // 
            // FontDialogPicker
            // 
            _FontDialogPicker.FontMustExist = true;
            _FontDialogPicker.ShowEffects = false;
            // 
            // LabelClass
            // 
            _LabelClass.AutoSize = true;
            _LabelClass.Location = new Point(3, 78);
            _LabelClass.Name = "LabelClass";
            _LabelClass.Size = new Size(32, 13);
            _LabelClass.TabIndex = 19;
            _LabelClass.Text = "Class";
            // 
            // ComboBoxClass
            // 
            _ComboBoxClass.FormattingEnabled = true;
            _ComboBoxClass.Location = new Point(6, 94);
            _ComboBoxClass.Name = "ComboBoxClass";
            _ComboBoxClass.Size = new Size(128, 21);
            _ComboBoxClass.TabIndex = 18;
            _ComboBoxClass.Text = "(default)";
            // 
            // UCIgnore
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_ListViewBase);
            Controls.Add(_ToolStripMenu);
            Controls.Add(_GroupBoxBase);
            Name = "UCIgnore";
            Size = new Size(698, 446);
            _ContextMenuStripBase.ResumeLayout(false);
            _ToolStripMenu.ResumeLayout(false);
            _ToolStripMenu.PerformLayout();
            _GroupBoxBase.ResumeLayout(false);
            _GroupBoxBase.PerformLayout();
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

        private Label _LabelGag;

        internal Label LabelGag
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelGag;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelGag != null)
                {
                }

                _LabelGag = value;
                if (_LabelGag != null)
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

        private TextBox _TextBoxReplace;

        internal TextBox TextBoxReplace
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxReplace;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxReplace != null)
                {
                    _TextBoxReplace.TextChanged -= TextBox_TextChanged;
                }

                _TextBoxReplace = value;
                if (_TextBoxReplace != null)
                {
                    _TextBoxReplace.TextChanged += TextBox_TextChanged;
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

        private CheckBox _CheckBoxIgnoreCase;

        internal CheckBox CheckBoxIgnoreCase
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBoxIgnoreCase;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBoxIgnoreCase != null)
                {
                    _CheckBoxIgnoreCase.CheckedChanged -= TextBox_TextChanged;
                }

                _CheckBoxIgnoreCase = value;
                if (_CheckBoxIgnoreCase != null)
                {
                    _CheckBoxIgnoreCase.CheckedChanged += TextBox_TextChanged;
                }
            }
        }

        private Label _LabelClass;

        internal Label LabelClass
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelClass;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelClass != null)
                {
                }

                _LabelClass = value;
                if (_LabelClass != null)
                {
                }
            }
        }

        private ComboBox _ComboBoxClass;

        internal ComboBox ComboBoxClass
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBoxClass;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBoxClass != null)
                {
                }

                _ComboBoxClass = value;
                if (_ComboBoxClass != null)
                {
                }
            }
        }
    }
}