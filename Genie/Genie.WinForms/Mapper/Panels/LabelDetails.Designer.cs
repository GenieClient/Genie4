using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class LabelDetails : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelDetails));
            _PanelProperties = new TableLayoutPanel();
            _TextBoxPosition = new TextBox();
            _TextBoxPosition.Validating += new System.ComponentModel.CancelEventHandler(TextBoxPosition_Validating);
            _LabelDescription = new Label();
            _LabelXYZ = new Label();
            _TextBoxText = new TextBox();
            _ButtonApply = new Button();
            _ButtonApply.Click += new EventHandler(ButtonApply_Click);
            _ToolStripButtonNew = new ToolStripButton();
            _ToolStripButtonNew.Click += new EventHandler(ToolStripButtonNew_Click);
            _ToolStripButtonCopy = new ToolStripButton();
            _ToolStripButtonCopy.Click += new EventHandler(ToolStripButtonCopy_Click);
            _ToolStripButtonRemove = new ToolStripButton();
            _ToolStripButtonRemove.Click += new EventHandler(ToolStripButtonRemove_Click);
            _ToolStripNodeDetails = new ToolStrip();
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
            _PanelProperties.Controls.Add(_TextBoxPosition, 0, 3);
            _PanelProperties.Controls.Add(_LabelDescription, 1, 2);
            _PanelProperties.Controls.Add(_LabelXYZ, 0, 2);
            _PanelProperties.Controls.Add(_TextBoxText, 1, 3);
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
            _PanelProperties.Size = new Size(579, 72);
            _PanelProperties.TabIndex = 13;
            // 
            // TextBoxPosition
            // 
            _TextBoxPosition.Dock = DockStyle.Fill;
            _TextBoxPosition.Location = new Point(3, 19);
            _TextBoxPosition.Name = "TextBoxPosition";
            _TextBoxPosition.Size = new Size(100, 20);
            _TextBoxPosition.TabIndex = 0;
            _TextBoxPosition.Text = "0, 0, 0";
            // 
            // LabelDescription
            // 
            _LabelDescription.AutoSize = true;
            _LabelDescription.Location = new Point(109, 3);
            _LabelDescription.Name = "LabelDescription";
            _LabelDescription.Size = new Size(28, 13);
            _LabelDescription.TabIndex = 0;
            _LabelDescription.Text = "Text";
            // 
            // LabelXYZ
            // 
            _LabelXYZ.AutoSize = true;
            _LabelXYZ.Location = new Point(3, 3);
            _LabelXYZ.Name = "LabelXYZ";
            _LabelXYZ.Size = new Size(86, 13);
            _LabelXYZ.TabIndex = 4;
            _LabelXYZ.Text = "Position (X, Y, Z)";
            // 
            // TextBoxText
            // 
            _PanelProperties.SetColumnSpan(_TextBoxText, 2);
            _TextBoxText.Dock = DockStyle.Fill;
            _TextBoxText.Location = new Point(109, 19);
            _TextBoxText.Name = "TextBoxText";
            _TextBoxText.Size = new Size(467, 20);
            _TextBoxText.TabIndex = 1;
            // 
            // ButtonApply
            // 
            _ButtonApply.Location = new Point(3, 45);
            _ButtonApply.Name = "ButtonApply";
            _ButtonApply.Size = new Size(75, 23);
            _ButtonApply.TabIndex = 2;
            _ButtonApply.Text = "Create";
            _ButtonApply.UseVisualStyleBackColor = true;
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
            // ToolStripNodeDetails
            // 
            _ToolStripNodeDetails.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripNodeDetails.Items.AddRange(new ToolStripItem[] { _ToolStripButtonNew, _ToolStripButtonCopy, _ToolStripButtonRemove });
            _ToolStripNodeDetails.Location = new Point(0, 0);
            _ToolStripNodeDetails.Name = "ToolStripNodeDetails";
            _ToolStripNodeDetails.Size = new Size(579, 25);
            _ToolStripNodeDetails.TabIndex = 14;
            // 
            // LabelDetails
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_PanelProperties);
            Controls.Add(_ToolStripNodeDetails);
            MinimumSize = new Size(0, 97);
            Name = "LabelDetails";
            Size = new Size(579, 97);
            _PanelProperties.ResumeLayout(false);
            _PanelProperties.PerformLayout();
            _ToolStripNodeDetails.ResumeLayout(false);
            _ToolStripNodeDetails.PerformLayout();
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

        private TextBox _TextBoxText;

        internal TextBox TextBoxText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxText != null)
                {
                }

                _TextBoxText = value;
                if (_TextBoxText != null)
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
    }
}