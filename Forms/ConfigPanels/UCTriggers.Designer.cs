using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GenieClient
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class UCTriggers : UserControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTriggers));
            this._ListViewBase = new System.Windows.Forms.ListView();
            this._ContextMenuStripBase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripMenu = new System.Windows.Forms.ToolStrip();
            this._ToolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this._TextBoxAction = new System.Windows.Forms.TextBox();
            this._ButtonApply = new System.Windows.Forms.Button();
            this._GroupBoxBase = new System.Windows.Forms.GroupBox();
            this._ButtonEdit = new System.Windows.Forms.Button();
            this._LabelClass = new System.Windows.Forms.Label();
            this._ComboBoxClass = new System.Windows.Forms.ComboBox();
            this._CheckBoxEval = new System.Windows.Forms.CheckBox();
            this._LabelAction = new System.Windows.Forms.Label();
            this._TextBoxTrigger = new System.Windows.Forms.TextBox();
            this._LabelTrigger = new System.Windows.Forms.Label();
            this._FontDialogPicker = new System.Windows.Forms.FontDialog();
            this._ContextMenuStripBase.SuspendLayout();
            this._ToolStripMenu.SuspendLayout();
            this._GroupBoxBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ListViewBase
            // 
            this._ListViewBase.BackColor = System.Drawing.Color.Black;
            this._ListViewBase.ContextMenuStrip = this._ContextMenuStripBase;
            this._ListViewBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ListViewBase.ForeColor = System.Drawing.Color.White;
            this._ListViewBase.FullRowSelect = true;
            this._ListViewBase.Location = new System.Drawing.Point(0, 25);
            this._ListViewBase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._ListViewBase.Name = "_ListViewBase";
            this._ListViewBase.ShowGroups = false;
            this._ListViewBase.Size = new System.Drawing.Size(814, 283);
            this._ListViewBase.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._ListViewBase.TabIndex = 3;
            this._ListViewBase.UseCompatibleStateImageBehavior = false;
            this._ListViewBase.View = System.Windows.Forms.View.Details;
            this._ListViewBase.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewBase_SortColumnClick);
            this._ListViewBase.SelectedIndexChanged += new System.EventHandler(this.ListViewBase_SelectedIndexChanged);
            this._ListViewBase.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListViewBase_KeyUp);
            this._ListViewBase.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListViewBase_MouseUp);
            // 
            // _ContextMenuStripBase
            // 
            this._ContextMenuStripBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._AddToolStripMenuItem,
            this._RemoveToolStripMenuItem});
            this._ContextMenuStripBase.Name = "ContextMenuStripBase";
            this._ContextMenuStripBase.Size = new System.Drawing.Size(118, 48);
            // 
            // _AddToolStripMenuItem
            // 
            this._AddToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_AddToolStripMenuItem.Image")));
            this._AddToolStripMenuItem.Name = "_AddToolStripMenuItem";
            this._AddToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this._AddToolStripMenuItem.Text = "Add";
            this._AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // _RemoveToolStripMenuItem
            // 
            this._RemoveToolStripMenuItem.Enabled = false;
            this._RemoveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_RemoveToolStripMenuItem.Image")));
            this._RemoveToolStripMenuItem.Name = "_RemoveToolStripMenuItem";
            this._RemoveToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this._RemoveToolStripMenuItem.Text = "Remove";
            this._RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // _ToolStripMenu
            // 
            this._ToolStripMenu.AllowMerge = false;
            this._ToolStripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._ToolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripButtonRefresh,
            this._ToolStripSeparator2,
            this._ToolStripButtonAdd,
            this._ToolStripButtonRemove,
            this._ToolStripSeparator1,
            this._ToolStripButtonLoad,
            this._ToolStripButtonSave});
            this._ToolStripMenu.Location = new System.Drawing.Point(0, 0);
            this._ToolStripMenu.Name = "_ToolStripMenu";
            this._ToolStripMenu.Size = new System.Drawing.Size(814, 25);
            this._ToolStripMenu.TabIndex = 5;
            // 
            // _ToolStripButtonRefresh
            // 
            this._ToolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonRefresh.Image")));
            this._ToolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonRefresh.Name = "_ToolStripButtonRefresh";
            this._ToolStripButtonRefresh.Size = new System.Drawing.Size(66, 22);
            this._ToolStripButtonRefresh.Text = "Refresh";
            this._ToolStripButtonRefresh.Click += new System.EventHandler(this.ToolStripButtonRefresh_Click);
            // 
            // _ToolStripSeparator2
            // 
            this._ToolStripSeparator2.Name = "_ToolStripSeparator2";
            this._ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonAdd
            // 
            this._ToolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonAdd.Image")));
            this._ToolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonAdd.Name = "_ToolStripButtonAdd";
            this._ToolStripButtonAdd.Size = new System.Drawing.Size(49, 22);
            this._ToolStripButtonAdd.Text = "Add";
            this._ToolStripButtonAdd.Click += new System.EventHandler(this.ToolStripButtonAdd_Click);
            // 
            // _ToolStripButtonRemove
            // 
            this._ToolStripButtonRemove.Enabled = false;
            this._ToolStripButtonRemove.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonRemove.Image")));
            this._ToolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonRemove.Name = "_ToolStripButtonRemove";
            this._ToolStripButtonRemove.Size = new System.Drawing.Size(70, 22);
            this._ToolStripButtonRemove.Text = "Remove";
            this._ToolStripButtonRemove.Click += new System.EventHandler(this.ToolStripButtonRemove_Click);
            // 
            // _ToolStripSeparator1
            // 
            this._ToolStripSeparator1.Name = "_ToolStripSeparator1";
            this._ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonLoad
            // 
            this._ToolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonLoad.Image")));
            this._ToolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonLoad.Name = "_ToolStripButtonLoad";
            this._ToolStripButtonLoad.Size = new System.Drawing.Size(53, 22);
            this._ToolStripButtonLoad.Text = "Load";
            this._ToolStripButtonLoad.Click += new System.EventHandler(this.ToolStripButtonLoad_Click);
            // 
            // _ToolStripButtonSave
            // 
            this._ToolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonSave.Image")));
            this._ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonSave.Name = "_ToolStripButtonSave";
            this._ToolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this._ToolStripButtonSave.Text = "Save";
            this._ToolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSave_Click);
            // 
            // _TextBoxAction
            // 
            this._TextBoxAction.Location = new System.Drawing.Point(7, 82);
            this._TextBoxAction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._TextBoxAction.Name = "_TextBoxAction";
            this._TextBoxAction.Size = new System.Drawing.Size(462, 23);
            this._TextBoxAction.TabIndex = 1;
            this._TextBoxAction.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // _ButtonApply
            // 
            this._ButtonApply.Location = new System.Drawing.Point(7, 158);
            this._ButtonApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._ButtonApply.Name = "_ButtonApply";
            this._ButtonApply.Size = new System.Drawing.Size(88, 27);
            this._ButtonApply.TabIndex = 3;
            this._ButtonApply.Text = "Apply";
            this._ButtonApply.UseVisualStyleBackColor = true;
            this._ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // _GroupBoxBase
            // 
            this._GroupBoxBase.AutoSize = true;
            this._GroupBoxBase.Controls.Add(this._ButtonEdit);
            this._GroupBoxBase.Controls.Add(this._LabelClass);
            this._GroupBoxBase.Controls.Add(this._ComboBoxClass);
            this._GroupBoxBase.Controls.Add(this._CheckBoxEval);
            this._GroupBoxBase.Controls.Add(this._LabelAction);
            this._GroupBoxBase.Controls.Add(this._TextBoxTrigger);
            this._GroupBoxBase.Controls.Add(this._LabelTrigger);
            this._GroupBoxBase.Controls.Add(this._ButtonApply);
            this._GroupBoxBase.Controls.Add(this._TextBoxAction);
            this._GroupBoxBase.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._GroupBoxBase.Enabled = false;
            this._GroupBoxBase.Location = new System.Drawing.Point(0, 308);
            this._GroupBoxBase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._GroupBoxBase.Name = "_GroupBoxBase";
            this._GroupBoxBase.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._GroupBoxBase.Size = new System.Drawing.Size(814, 207);
            this._GroupBoxBase.TabIndex = 4;
            this._GroupBoxBase.TabStop = false;
            // 
            // _ButtonEdit
            // 
            this._ButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("_ButtonEdit.Image")));
            this._ButtonEdit.Location = new System.Drawing.Point(477, 81);
            this._ButtonEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._ButtonEdit.Name = "_ButtonEdit";
            this._ButtonEdit.Size = new System.Drawing.Size(27, 27);
            this._ButtonEdit.TabIndex = 16;
            this._ButtonEdit.UseVisualStyleBackColor = true;
            this._ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // _LabelClass
            // 
            this._LabelClass.AutoSize = true;
            this._LabelClass.Location = new System.Drawing.Point(4, 108);
            this._LabelClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._LabelClass.Name = "_LabelClass";
            this._LabelClass.Size = new System.Drawing.Size(34, 15);
            this._LabelClass.TabIndex = 15;
            this._LabelClass.Text = "Class";
            // 
            // _ComboBoxClass
            // 
            this._ComboBoxClass.FormattingEnabled = true;
            this._ComboBoxClass.Location = new System.Drawing.Point(7, 127);
            this._ComboBoxClass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._ComboBoxClass.Name = "_ComboBoxClass";
            this._ComboBoxClass.Size = new System.Drawing.Size(149, 23);
            this._ComboBoxClass.TabIndex = 14;
            this._ComboBoxClass.Text = "(default)";
            // 
            // _CheckBoxEval
            // 
            this._CheckBoxEval.AutoSize = true;
            this._CheckBoxEval.Location = new System.Drawing.Point(449, 39);
            this._CheckBoxEval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._CheckBoxEval.Name = "_CheckBoxEval";
            this._CheckBoxEval.Size = new System.Drawing.Size(47, 19);
            this._CheckBoxEval.TabIndex = 11;
            this._CheckBoxEval.Text = "Eval";
            this._CheckBoxEval.UseVisualStyleBackColor = true;
            // 
            // _LabelAction
            // 
            this._LabelAction.AutoSize = true;
            this._LabelAction.Location = new System.Drawing.Point(4, 63);
            this._LabelAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._LabelAction.Name = "_LabelAction";
            this._LabelAction.Size = new System.Drawing.Size(42, 15);
            this._LabelAction.TabIndex = 10;
            this._LabelAction.Text = "Action";
            // 
            // _TextBoxTrigger
            // 
            this._TextBoxTrigger.Location = new System.Drawing.Point(7, 37);
            this._TextBoxTrigger.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._TextBoxTrigger.Name = "_TextBoxTrigger";
            this._TextBoxTrigger.Size = new System.Drawing.Size(434, 23);
            this._TextBoxTrigger.TabIndex = 1;
            this._TextBoxTrigger.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // _LabelTrigger
            // 
            this._LabelTrigger.AutoSize = true;
            this._LabelTrigger.Location = new System.Drawing.Point(4, 18);
            this._LabelTrigger.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._LabelTrigger.Name = "_LabelTrigger";
            this._LabelTrigger.Size = new System.Drawing.Size(153, 15);
            this._LabelTrigger.TabIndex = 8;
            this._LabelTrigger.Text = "Trigger (Regular Expression)";
            // 
            // _FontDialogPicker
            // 
            this._FontDialogPicker.FontMustExist = true;
            this._FontDialogPicker.ShowEffects = false;
            // 
            // UCTriggers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ListViewBase);
            this.Controls.Add(this._ToolStripMenu);
            this.Controls.Add(this._GroupBoxBase);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UCTriggers";
            this.Size = new System.Drawing.Size(814, 515);
            this.Load += new System.EventHandler(this.UCWindows_Load);
            this._ContextMenuStripBase.ResumeLayout(false);
            this._ToolStripMenu.ResumeLayout(false);
            this._ToolStripMenu.PerformLayout();
            this._GroupBoxBase.ResumeLayout(false);
            this._GroupBoxBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private TextBox _TextBoxAction;

        internal TextBox TextBoxAction
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxAction;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxAction != null)
                {
                    _TextBoxAction.TextChanged -= TextBox_TextChanged;
                }

                _TextBoxAction = value;
                if (_TextBoxAction != null)
                {
                    _TextBoxAction.TextChanged += TextBox_TextChanged;
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

        private Label _LabelTrigger;

        internal Label LabelTrigger
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelTrigger;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelTrigger != null)
                {
                }

                _LabelTrigger = value;
                if (_LabelTrigger != null)
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

        private TextBox _TextBoxTrigger;

        internal TextBox TextBoxTrigger
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxTrigger;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxTrigger != null)
                {
                    _TextBoxTrigger.TextChanged -= TextBox_TextChanged;
                }

                _TextBoxTrigger = value;
                if (_TextBoxTrigger != null)
                {
                    _TextBoxTrigger.TextChanged += TextBox_TextChanged;
                }
            }
        }

        private Label _LabelAction;

        internal Label LabelAction
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelAction;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelAction != null)
                {
                }

                _LabelAction = value;
                if (_LabelAction != null)
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

        private CheckBox _CheckBoxEval;

        internal CheckBox CheckBoxEval
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBoxEval;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBoxEval != null)
                {
                }

                _CheckBoxEval = value;
                if (_CheckBoxEval != null)
                {
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

        private Button _ButtonEdit;

        internal Button ButtonEdit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonEdit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonEdit != null)
                {
                    _ButtonEdit.Click -= ButtonEdit_Click;
                }

                _ButtonEdit = value;
                if (_ButtonEdit != null)
                {
                    _ButtonEdit.Click += ButtonEdit_Click;
                }
            }
        }
    }
}