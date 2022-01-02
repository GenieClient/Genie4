using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class NodeDetails : UserControl
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeDetails));
            _PanelProperties = new TableLayoutPanel();
            _TextBoxNote = new TextBox();
            _TextBoxPosition = new TextBox();
            _TextBoxPosition.Validating += new System.ComponentModel.CancelEventHandler(TextBoxPosition_Validating);
            _LabelID = new Label();
            _TextBoxRoomID = new TextBox();
            _LabelName = new Label();
            _TextBoxRoomName = new TextBox();
            _LabelDescription = new Label();
            _LabelXYZ = new Label();
            _TextBoxDescription = new TextBox();
            _LabelColor = new Label();
            _LabelNote = new Label();
            _ColorPicker1 = new ColorPicker();
            _ButtonApply = new Button();
            _ButtonApply.Click += new EventHandler(ButtonApply_Click);
            _ToolStripNodeDetails = new ToolStrip();
            _ToolStripButtonNew = new ToolStripButton();
            _ToolStripButtonNew.Click += new EventHandler(ToolStripButtonNew_Click);
            _ToolStripButtonCopy = new ToolStripButton();
            _ToolStripButtonCopy.Click += new EventHandler(ToolStripButtonCopy_Click);
            _ToolStripButtonRemove = new ToolStripButton();
            _ToolStripButtonRemove.Click += new EventHandler(ToolStripButtonRemove_Click);
            _ToolStripSeparator2 = new ToolStripSeparator();
            _ToolStripButtonArcs = new ToolStripButton();
            _ToolStripButtonArcs.Click += new EventHandler(ToolStripButtonArcs_Click);
            _ToolStripSeparator1 = new ToolStripSeparator();
            _ToolStripButtonAddLabel = new ToolStripButton();
            _ToolStripButtonAddLabel.Click += new EventHandler(ToolStripButtonAddLabel_Click);
            _PanelProperties.SuspendLayout();
            _ToolStripNodeDetails.SuspendLayout();
            SuspendLayout();
            // 
            // PanelProperties
            // 
            _PanelProperties.ColumnCount = 3;
            _PanelProperties.ColumnStyles.Add(new ColumnStyle());
            _PanelProperties.ColumnStyles.Add(new ColumnStyle());
            _PanelProperties.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0F));
            _PanelProperties.Controls.Add(_TextBoxNote, 0, 7);
            _PanelProperties.Controls.Add(_TextBoxPosition, 0, 3);
            _PanelProperties.Controls.Add(_LabelID, 0, 0);
            _PanelProperties.Controls.Add(_TextBoxRoomID, 0, 1);
            _PanelProperties.Controls.Add(_LabelName, 1, 0);
            _PanelProperties.Controls.Add(_TextBoxRoomName, 1, 1);
            _PanelProperties.Controls.Add(_LabelDescription, 1, 2);
            _PanelProperties.Controls.Add(_LabelXYZ, 0, 2);
            _PanelProperties.Controls.Add(_TextBoxDescription, 1, 3);
            _PanelProperties.Controls.Add(_LabelColor, 0, 6);
            _PanelProperties.Controls.Add(_LabelNote, 1, 6);
            _PanelProperties.Controls.Add(_ColorPicker1, 0, 7);
            _PanelProperties.Controls.Add(_ButtonApply, 0, 8);
            _PanelProperties.Dock = DockStyle.Fill;
            _PanelProperties.Location = new Point(0, 25);
            _PanelProperties.Name = "PanelProperties";
            _PanelProperties.Padding = new Padding(0, 3, 0, 0);
            _PanelProperties.RowCount = 9;
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.RowStyles.Add(new RowStyle());
            _PanelProperties.Size = new Size(590, 150);
            _PanelProperties.TabIndex = 0;
            // 
            // TextBoxNote
            // 
            _PanelProperties.SetColumnSpan(_TextBoxNote, 2);
            _TextBoxNote.Dock = DockStyle.Fill;
            _TextBoxNote.Location = new Point(109, 97);
            _TextBoxNote.Name = "TextBoxNote";
            _TextBoxNote.Size = new Size(478, 20);
            _TextBoxNote.TabIndex = 5;
            // 
            // TextBoxPosition
            // 
            _TextBoxPosition.Dock = DockStyle.Fill;
            _TextBoxPosition.Location = new Point(3, 58);
            _TextBoxPosition.Name = "TextBoxPosition";
            _TextBoxPosition.Size = new Size(100, 20);
            _TextBoxPosition.TabIndex = 2;
            _TextBoxPosition.Text = "0, 0, 0";
            // 
            // LabelID
            // 
            _LabelID.AutoSize = true;
            _LabelID.Location = new Point(3, 3);
            _LabelID.Name = "LabelID";
            _LabelID.Size = new Size(18, 13);
            _LabelID.TabIndex = 0;
            _LabelID.Text = "ID";
            // 
            // TextBoxRoomID
            // 
            _TextBoxRoomID.Dock = DockStyle.Fill;
            _TextBoxRoomID.Location = new Point(3, 19);
            _TextBoxRoomID.Name = "TextBoxRoomID";
            _TextBoxRoomID.ReadOnly = true;
            _TextBoxRoomID.Size = new Size(100, 20);
            _TextBoxRoomID.TabIndex = 0;
            _TextBoxRoomID.Text = "0";
            // 
            // LabelName
            // 
            _LabelName.AutoSize = true;
            _LabelName.Location = new Point(109, 3);
            _LabelName.Name = "LabelName";
            _LabelName.Size = new Size(35, 13);
            _LabelName.TabIndex = 0;
            _LabelName.Text = "Name";
            // 
            // TextBoxRoomName
            // 
            _PanelProperties.SetColumnSpan(_TextBoxRoomName, 2);
            _TextBoxRoomName.Dock = DockStyle.Fill;
            _TextBoxRoomName.Location = new Point(109, 19);
            _TextBoxRoomName.Name = "TextBoxRoomName";
            _TextBoxRoomName.Size = new Size(478, 20);
            _TextBoxRoomName.TabIndex = 1;
            // 
            // LabelDescription
            // 
            _LabelDescription.AutoSize = true;
            _LabelDescription.Location = new Point(109, 42);
            _LabelDescription.Name = "LabelDescription";
            _LabelDescription.Size = new Size(71, 13);
            _LabelDescription.TabIndex = 0;
            _LabelDescription.Text = "Description(s)";
            // 
            // LabelXYZ
            // 
            _LabelXYZ.AutoSize = true;
            _LabelXYZ.Location = new Point(3, 42);
            _LabelXYZ.Name = "LabelXYZ";
            _LabelXYZ.Size = new Size(86, 13);
            _LabelXYZ.TabIndex = 4;
            _LabelXYZ.Text = "Position (X, Y, Z)";
            // 
            // TextBoxDescription
            // 
            _PanelProperties.SetColumnSpan(_TextBoxDescription, 2);
            _TextBoxDescription.Dock = DockStyle.Fill;
            _TextBoxDescription.Location = new Point(109, 58);
            _TextBoxDescription.Name = "TextBoxDescription";
            _TextBoxDescription.Size = new Size(478, 20);
            _TextBoxDescription.TabIndex = 3;
            // 
            // LabelColor
            // 
            _LabelColor.AutoSize = true;
            _LabelColor.Location = new Point(3, 81);
            _LabelColor.Name = "LabelColor";
            _LabelColor.Size = new Size(49, 13);
            _LabelColor.TabIndex = 11;
            _LabelColor.Text = "BG Color";
            // 
            // LabelNote
            // 
            _LabelNote.AutoSize = true;
            _LabelNote.Location = new Point(109, 81);
            _LabelNote.Name = "LabelNote";
            _LabelNote.Size = new Size(152, 13);
            _LabelNote.TabIndex = 12;
            _LabelNote.Text = "Key/Linked Map (filename.xml)";
            // 
            // ColorPicker1
            // 
            _ColorPicker1.Color = Color.White;
            _ColorPicker1.Location = new Point(3, 97);
            _ColorPicker1.Name = "ColorPicker1";
            _ColorPicker1.Size = new Size(100, 21);
            _ColorPicker1.TabIndex = 4;
            // 
            // ButtonApply
            // 
            _ButtonApply.Location = new Point(3, 124);
            _ButtonApply.Name = "ButtonApply";
            _ButtonApply.Size = new Size(75, 23);
            _ButtonApply.TabIndex = 6;
            _ButtonApply.Text = "Create";
            _ButtonApply.UseVisualStyleBackColor = true;
            // 
            // ToolStripNodeDetails
            // 
            _ToolStripNodeDetails.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripNodeDetails.Items.AddRange(new ToolStripItem[] { _ToolStripButtonNew, _ToolStripButtonCopy, _ToolStripButtonRemove, _ToolStripSeparator2, _ToolStripButtonArcs, _ToolStripSeparator1, _ToolStripButtonAddLabel });
            _ToolStripNodeDetails.Location = new Point(0, 0);
            _ToolStripNodeDetails.Name = "ToolStripNodeDetails";
            _ToolStripNodeDetails.Size = new Size(590, 25);
            _ToolStripNodeDetails.TabIndex = 12;
            // 
            // ToolStripButtonNew
            // 
            _ToolStripButtonNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonNew.Enabled = false;
            _ToolStripButtonNew.Image = (Image)resources.GetObject("ToolStripButtonNew.Image");
            _ToolStripButtonNew.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonNew.Name = "ToolStripButtonNew";
            _ToolStripButtonNew.Size = new Size(23, 22);
            _ToolStripButtonNew.Text = "New Node";
            _ToolStripButtonNew.ToolTipText = "New";
            // 
            // ToolStripButtonCopy
            // 
            _ToolStripButtonCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonCopy.Enabled = false;
            _ToolStripButtonCopy.Image = (Image)resources.GetObject("ToolStripButtonCopy.Image");
            _ToolStripButtonCopy.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonCopy.Name = "ToolStripButtonCopy";
            _ToolStripButtonCopy.Size = new Size(23, 22);
            _ToolStripButtonCopy.Text = "Copy Node";
            _ToolStripButtonCopy.ToolTipText = "Copy";
            // 
            // ToolStripButtonRemove
            // 
            _ToolStripButtonRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonRemove.Enabled = false;
            _ToolStripButtonRemove.Image = (Image)resources.GetObject("ToolStripButtonRemove.Image");
            _ToolStripButtonRemove.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRemove.Name = "ToolStripButtonRemove";
            _ToolStripButtonRemove.Size = new Size(23, 22);
            _ToolStripButtonRemove.Text = "Remove Node";
            _ToolStripButtonRemove.ToolTipText = "Remove";
            // 
            // ToolStripSeparator2
            // 
            _ToolStripSeparator2.Name = "ToolStripSeparator2";
            _ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripButtonArcs
            // 
            _ToolStripButtonArcs.Enabled = false;
            _ToolStripButtonArcs.Image = My.Resources.Resources.text_x_script;
            _ToolStripButtonArcs.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonArcs.Name = "ToolStripButtonArcs";
            _ToolStripButtonArcs.Size = new Size(69, 22);
            _ToolStripButtonArcs.Text = "Edit Arcs";
            // 
            // ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "ToolStripSeparator1";
            _ToolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolStripButtonAddLabel
            // 
            _ToolStripButtonAddLabel.Image = My.Resources.Resources.font_x_generic;
            _ToolStripButtonAddLabel.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonAddLabel.Name = "ToolStripButtonAddLabel";
            _ToolStripButtonAddLabel.Size = new Size(99, 22);
            _ToolStripButtonAddLabel.Text = "New Map Label";
            // 
            // NodeDetails
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_PanelProperties);
            Controls.Add(_ToolStripNodeDetails);
            MinimumSize = new Size(0, 175);
            Name = "NodeDetails";
            Size = new Size(590, 175);
            _PanelProperties.ResumeLayout(false);
            _PanelProperties.PerformLayout();
            _ToolStripNodeDetails.ResumeLayout(false);
            _ToolStripNodeDetails.PerformLayout();
            Load += new EventHandler(NodeDetails_Load);
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

        private Label _LabelID;

        internal Label LabelID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelID != null)
                {
                }

                _LabelID = value;
                if (_LabelID != null)
                {
                }
            }
        }

        private TextBox _TextBoxRoomID;

        internal TextBox TextBoxRoomID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxRoomID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxRoomID != null)
                {
                }

                _TextBoxRoomID = value;
                if (_TextBoxRoomID != null)
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

        private TextBox _TextBoxRoomName;

        internal TextBox TextBoxRoomName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxRoomName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxRoomName != null)
                {
                }

                _TextBoxRoomName = value;
                if (_TextBoxRoomName != null)
                {
                }
            }
        }

        private Label _LabelDescription;

        internal Label LabelDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelDescription != null)
                {
                }

                _LabelDescription = value;
                if (_LabelDescription != null)
                {
                }
            }
        }

        private TextBox _TextBoxDescription;

        internal TextBox TextBoxDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxDescription != null)
                {
                }

                _TextBoxDescription = value;
                if (_TextBoxDescription != null)
                {
                }
            }
        }

        private Label _LabelXYZ;

        internal Label LabelXYZ
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelXYZ;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelXYZ != null)
                {
                }

                _LabelXYZ = value;
                if (_LabelXYZ != null)
                {
                }
            }
        }

        private TextBox _TextBoxPosition;

        internal TextBox TextBoxPosition
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxPosition;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxPosition != null)
                {
                    _TextBoxPosition.Validating -= TextBoxPosition_Validating;
                }

                _TextBoxPosition = value;
                if (_TextBoxPosition != null)
                {
                    _TextBoxPosition.Validating += TextBoxPosition_Validating;
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

        private ToolStripButton _ToolStripButtonNew;

        internal ToolStripButton ToolStripButtonNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonNew != null)
                {
                    _ToolStripButtonNew.Click -= ToolStripButtonNew_Click;
                }

                _ToolStripButtonNew = value;
                if (_ToolStripButtonNew != null)
                {
                    _ToolStripButtonNew.Click += ToolStripButtonNew_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonCopy;

        internal ToolStripButton ToolStripButtonCopy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonCopy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonCopy != null)
                {
                    _ToolStripButtonCopy.Click -= ToolStripButtonCopy_Click;
                }

                _ToolStripButtonCopy = value;
                if (_ToolStripButtonCopy != null)
                {
                    _ToolStripButtonCopy.Click += ToolStripButtonCopy_Click;
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

        private ToolStripButton _ToolStripButtonArcs;

        internal ToolStripButton ToolStripButtonArcs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonArcs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonArcs != null)
                {
                    _ToolStripButtonArcs.Click -= ToolStripButtonArcs_Click;
                }

                _ToolStripButtonArcs = value;
                if (_ToolStripButtonArcs != null)
                {
                    _ToolStripButtonArcs.Click += ToolStripButtonArcs_Click;
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

        private Label _LabelNote;

        internal Label LabelNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelNote != null)
                {
                }

                _LabelNote = value;
                if (_LabelNote != null)
                {
                }
            }
        }

        private ColorPicker _ColorPicker1;

        internal ColorPicker ColorPicker1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ColorPicker1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ColorPicker1 != null)
                {
                }

                _ColorPicker1 = value;
                if (_ColorPicker1 != null)
                {
                }
            }
        }

        private TextBox _TextBoxNote;

        internal TextBox TextBoxNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxNote != null)
                {
                }

                _TextBoxNote = value;
                if (_TextBoxNote != null)
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

        private ToolStripButton _ToolStripButtonAddLabel;

        internal ToolStripButton ToolStripButtonAddLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonAddLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonAddLabel != null)
                {
                    _ToolStripButtonAddLabel.Click -= ToolStripButtonAddLabel_Click;
                }

                _ToolStripButtonAddLabel = value;
                if (_ToolStripButtonAddLabel != null)
                {
                    _ToolStripButtonAddLabel.Click += ToolStripButtonAddLabel_Click;
                }
            }
        }
    }
}