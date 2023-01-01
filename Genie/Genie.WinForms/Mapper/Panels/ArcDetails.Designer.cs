using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GenieClient
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ArcDetails : UserControl
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
        #pragma warning disable 0649
        private System.ComponentModel.IContainer components;
        #pragma warning restore 0649

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _PanelProperties = new TableLayoutPanel();
            _ButtonApply = new Button();
            _ButtonApply.Click += new EventHandler(ButtonApply_Click);
            _TextBoxToNodeID = new TextBox();
            _LabelName = new Label();
            _TextBoxName = new TextBox();
            _LabelDirection = new Label();
            _LabelToRoom = new Label();
            _ComboBoxDirection = new ComboBox();
            _CheckBoxHideArc = new CheckBox();
            _ListViewBase = new ListView();
            _ListViewBase.KeyUp += new KeyEventHandler(ListViewBase_KeyUp);
            _ListViewBase.MouseUp += new MouseEventHandler(ListViewBase_MouseUp);
            _ListViewBase.SelectedIndexChanged += new EventHandler(ListViewBase_SelectedIndexChanged);
            _ToolStripNodeDetails = new ToolStrip();
            _PanelProperties.SuspendLayout();
            SuspendLayout();
            // 
            // PanelProperties
            // 
            _PanelProperties.ColumnCount = 3;
            _PanelProperties.ColumnStyles.Add(new ColumnStyle());
            _PanelProperties.ColumnStyles.Add(new ColumnStyle());
            _PanelProperties.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0F));
            _PanelProperties.Controls.Add(_ButtonApply, 0, 2);
            _PanelProperties.Controls.Add(_TextBoxToNodeID, 1, 1);
            _PanelProperties.Controls.Add(_LabelName, 2, 0);
            _PanelProperties.Controls.Add(_TextBoxName, 2, 1);
            _PanelProperties.Controls.Add(_LabelDirection, 0, 0);
            _PanelProperties.Controls.Add(_LabelToRoom, 1, 0);
            _PanelProperties.Controls.Add(_ComboBoxDirection, 0, 1);
            _PanelProperties.Controls.Add(_CheckBoxHideArc, 2, 2);
            _PanelProperties.Dock = DockStyle.Bottom;
            _PanelProperties.Location = new Point(0, 103);
            _PanelProperties.Name = "PanelProperties";
            _PanelProperties.Padding = new Padding(0, 3, 0, 0);
            _PanelProperties.RowCount = 4;
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.Size = new Size(537, 72);
            _PanelProperties.TabIndex = 14;
            // 
            // ButtonApply
            // 
            _ButtonApply.Location = new Point(3, 46);
            _ButtonApply.Name = "ButtonApply";
            _ButtonApply.Size = new Size(75, 23);
            _ButtonApply.TabIndex = 7;
            _ButtonApply.Text = "Create";
            _ButtonApply.UseVisualStyleBackColor = true;
            // 
            // TextBoxToNodeID
            // 
            _TextBoxToNodeID.Dock = DockStyle.Fill;
            _TextBoxToNodeID.Location = new Point(159, 19);
            _TextBoxToNodeID.Name = "TextBoxToNodeID";
            _TextBoxToNodeID.Size = new Size(63, 20);
            _TextBoxToNodeID.TabIndex = 5;
            _TextBoxToNodeID.Text = "0";
            // 
            // LabelName
            // 
            _LabelName.AutoSize = true;
            _LabelName.Location = new Point(228, 3);
            _LabelName.Name = "LabelName";
            _LabelName.Size = new Size(252, 13);
            _LabelName.TabIndex = 0;
            _LabelName.Text = "Move command (leave empty for cardinal directions)";
            // 
            // TextBoxName
            // 
            _TextBoxName.Dock = DockStyle.Fill;
            _TextBoxName.Location = new Point(228, 19);
            _TextBoxName.Name = "TextBoxName";
            _TextBoxName.Size = new Size(306, 20);
            _TextBoxName.TabIndex = 1;
            // 
            // LabelDirection
            // 
            _LabelDirection.AutoSize = true;
            _LabelDirection.Location = new Point(3, 3);
            _LabelDirection.Name = "LabelDirection";
            _LabelDirection.Size = new Size(49, 13);
            _LabelDirection.TabIndex = 0;
            _LabelDirection.Text = "Direction";
            // 
            // LabelToRoom
            // 
            _LabelToRoom.AutoSize = true;
            _LabelToRoom.Location = new Point(159, 3);
            _LabelToRoom.Name = "LabelToRoom";
            _LabelToRoom.Size = new Size(63, 13);
            _LabelToRoom.TabIndex = 4;
            _LabelToRoom.Text = "To Node ID";
            // 
            // ComboBoxDirection
            // 
            _ComboBoxDirection.FormattingEnabled = true;
            _ComboBoxDirection.Location = new Point(3, 19);
            _ComboBoxDirection.Name = "ComboBoxDirection";
            _ComboBoxDirection.Size = new Size(150, 21);
            _ComboBoxDirection.TabIndex = 6;
            // 
            // CheckBoxHideArc
            // 
            _CheckBoxHideArc.AutoSize = true;
            _CheckBoxHideArc.Location = new Point(228, 46);
            _CheckBoxHideArc.Name = "CheckBoxHideArc";
            _CheckBoxHideArc.Size = new Size(164, 17);
            _CheckBoxHideArc.TabIndex = 8;
            _CheckBoxHideArc.Text = "Hide Arc (For Maze Mapping)";
            _CheckBoxHideArc.UseVisualStyleBackColor = true;
            // 
            // ListViewBase
            // 
            _ListViewBase.Dock = DockStyle.Fill;
            _ListViewBase.FullRowSelect = true;
            _ListViewBase.HideSelection = false;
            _ListViewBase.Location = new Point(0, 25);
            _ListViewBase.MultiSelect = false;
            _ListViewBase.Name = "ListViewBase";
            _ListViewBase.ShowGroups = false;
            _ListViewBase.Size = new Size(537, 78);
            _ListViewBase.Sorting = SortOrder.Ascending;
            _ListViewBase.TabIndex = 7;
            _ListViewBase.UseCompatibleStateImageBehavior = false;
            _ListViewBase.View = View.Details;
            // 
            // ToolStripNodeDetails
            // 
            _ToolStripNodeDetails.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripNodeDetails.Location = new Point(0, 0);
            _ToolStripNodeDetails.Name = "ToolStripNodeDetails";
            _ToolStripNodeDetails.Size = new Size(537, 25);
            _ToolStripNodeDetails.TabIndex = 13;
            // 
            // ArcDetails
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_ListViewBase);
            Controls.Add(_PanelProperties);
            Controls.Add(_ToolStripNodeDetails);
            MinimumSize = new Size(0, 175);
            Name = "ArcDetails";
            Size = new Size(537, 175);
            _PanelProperties.ResumeLayout(false);
            _PanelProperties.PerformLayout();
            Load += new EventHandler(ArcDetails_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private TableLayoutPanel _PanelProperties;

        internal TableLayoutPanel PanelProperties
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelProperties;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelProperties != null)
                {
                }

                _PanelProperties = value;
                if (_PanelProperties != null)
                {
                }
            }
        }

        private Label _LabelName;

        internal Label LabelName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelName != null)
                {
                }

                _LabelName = value;
                if (_LabelName != null)
                {
                }
            }
        }

        private TextBox _TextBoxName;

        internal TextBox TextBoxName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxName != null)
                {
                }

                _TextBoxName = value;
                if (_TextBoxName != null)
                {
                }
            }
        }

        private Label _LabelToRoom;

        internal Label LabelToRoom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelToRoom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelToRoom != null)
                {
                }

                _LabelToRoom = value;
                if (_LabelToRoom != null)
                {
                }
            }
        }

        private TextBox _TextBoxToNodeID;

        internal TextBox TextBoxToNodeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxToNodeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxToNodeID != null)
                {
                }

                _TextBoxToNodeID = value;
                if (_TextBoxToNodeID != null)
                {
                }
            }
        }

        private Label _LabelDirection;

        internal Label LabelDirection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelDirection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelDirection != null)
                {
                }

                _LabelDirection = value;
                if (_LabelDirection != null)
                {
                }
            }
        }

        private ComboBox _ComboBoxDirection;

        internal ComboBox ComboBoxDirection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComboBoxDirection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComboBoxDirection != null)
                {
                }

                _ComboBoxDirection = value;
                if (_ComboBoxDirection != null)
                {
                }
            }
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

        private ToolStrip _ToolStripNodeDetails;

        internal ToolStrip ToolStripNodeDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripNodeDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripNodeDetails != null)
                {
                }

                _ToolStripNodeDetails = value;
                if (_ToolStripNodeDetails != null)
                {
                }
            }
        }

        private CheckBox _CheckBoxHideArc;

        internal CheckBox CheckBoxHideArc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBoxHideArc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBoxHideArc != null)
                {
                }

                _CheckBoxHideArc = value;
                if (_CheckBoxHideArc != null)
                {
                }
            }
        }
    }
}