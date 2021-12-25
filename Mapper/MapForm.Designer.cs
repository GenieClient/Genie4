using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Mapper
{
    [DesignerGenerated()]
    public partial class MapForm : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            _ToolStripMain = new ToolStrip();
            _ToolStripMain.KeyUp += new KeyEventHandler(GraphForm_KeyDown);
            _ToolStripMain.KeyUp += new KeyEventHandler(GraphForm_KeyUp);
            _ToolStripButtonClear = new ToolStripButton();
            _ToolStripButtonClear.Click += new EventHandler(ToolStripButtonClear_Click);
            _ToolStripButtonLoad = new ToolStripButton();
            _ToolStripButtonLoad.Click += new EventHandler(ToolStripButtonLoad_Click);
            _ToolStripButtonSave = new ToolStripButton();
            _ToolStripButtonSave.Click += new EventHandler(ToolStripButtonSave_Click);
            _ToolStripSeparator1 = new ToolStripSeparator();
            _ToolStripButtonWalk = new ToolStripButton();
            _ToolStripButtonWalk.Click += new EventHandler(ToolStripButtonWalk_Click);
            _ToolStripSeparator3 = new ToolStripSeparator();
            _ToolStripButtonSnap = new ToolStripButton();
            _ToolStripButtonSnap.Click += new EventHandler(ToolStripButtonSnap_Click);
            _ToolStripButtonProperties = new ToolStripButton();
            _ToolStripButtonProperties.Click += new EventHandler(ToolStripButtonProperties_Click);
            _ToolStripSeparator4 = new ToolStripSeparator();
            _ToolStripButtonRecord = new ToolStripButton();
            _ToolStripButtonRecord.Click += new EventHandler(ToolStripButtonRecord_Click);
            _ToolStripButtonLockPositions = new ToolStripButton();
            _ToolStripButtonLockPositions.Click += new EventHandler(ToolStripButtonLockPositions_Click);
            _ToolStripButtonAllowDuplicates = new ToolStripButton();
            _ToolStripButtonAllowDuplicates.Click += new EventHandler(ToolStripButtonAllowDuplicates_Click);
            _ToolStripSeparator5 = new ToolStripSeparator();
            _ToolStripButtonMoveNodes = new ToolStripButton();
            _ToolStripButtonMoveNodes.Click += new EventHandler(ToolStripButtonMoveNodes_Click);
            _ToolStripButtonRemove = new ToolStripButton();
            _ToolStripButtonRemove.Click += new EventHandler(ToolStripButtonRemove_Click);
            _ToolStripSeparator2 = new ToolStripSeparator();
            _ToolStripButtonFixID = new ToolStripButton();
            _ToolStripButtonFixID.Click += new EventHandler(ToolStripButton1_Click);
            _ToolStripButtonDock = new ToolStripButton();
            _ToolStripButtonDock.Click += new EventHandler(ToolStripButtonDock_Click);
            _ToolStripSeparator7 = new ToolStripSeparator();
            _ToolStripButtonZoomOut = new ToolStripButton();
            _ToolStripButtonZoomOut.Click += new EventHandler(ToolStripButtonZoomOut_Click);
            _ToolStripButtonZoomIn = new ToolStripButton();
            _ToolStripButtonZoomIn.Click += new EventHandler(ToolStripButtonZoomIn_Click);
            _ToolStripSeparator6 = new ToolStripSeparator();
            _ToolStripButtonDown = new ToolStripButton();
            _ToolStripButtonDown.Click += new EventHandler(ToolStripButtonDown_Click);
            _ToolStripButtonUp = new ToolStripButton();
            _ToolStripButtonUp.Click += new EventHandler(ToolStripButtonUp_Click);
            _ToolStripLabelZ = new ToolStripLabel();
            _OpenFileDialog1 = new OpenFileDialog();
            _SaveFileDialog1 = new SaveFileDialog();
            _PanelDetails = new Panel();
            _PanelNodeDetails = new NodeDetails();
            _PanelNodeDetails.UpdateMap += new NodeDetails.UpdateMapEventHandler(PanelNodeDetails_UpdateMap);
            _PanelNodeDetails.CopyNode += new NodeDetails.CopyNodeEventHandler(PanelNodeDetails_CopyNode);
            _PanelNodeDetails.AddNode += new NodeDetails.AddNodeEventHandler(PanelNodeDetails_AddNode);
            _PanelNodeDetails.RemoveNode += new NodeDetails.RemoveNodeEventHandler(PanelNodeDetails_RemoveNode);
            _PanelNodeDetails.NewNode += new NodeDetails.NewNodeEventHandler(PanelNodeDetails_NewNode);
            _PanelNodeDetails.ArcChanged += new NodeDetails.ArcChangedEventHandler(PanelNodeDetails_ArcChanged);
            _PanelNodeDetails.NewLabel += new NodeDetails.NewLabelEventHandler(EventAddLabel);
            _PanelLabelDetails = new LabelDetails();
            _PanelLabelDetails.UpdateMap += new LabelDetails.UpdateMapEventHandler(PanelNodeDetails_UpdateMap);
            _PanelLabelDetails.NewLabel += new LabelDetails.NewLabelEventHandler(EventAddLabel);
            _StatusStripMain = new StatusStrip();
            _ToolStripStatusText = new ToolStripStatusLabel();
            _PanelBase = new Panel();
            _PanelMap = new FlickerFreePanel();
            _PanelMap.MouseDown += new MouseEventHandler(FlickerFreePanel1_MouseDown);
            _PanelMap.MouseLeave += new EventHandler(FlickerFreePanel1_MouseLeave);
            _PanelMap.MouseMove += new MouseEventHandler(FlickerFreePanel1_MouseMove);
            _PanelMap.MouseUp += new MouseEventHandler(FlickerFreePanel1_MouseUp);
            _PanelMap.Paint += new PaintEventHandler(FlickerFreePanel1_Paint);
            _ToolStripMaps = new ToolStrip();
            _ToolStripDropDownButtonMaps = new ToolStripDropDownButton();
            _TestToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripButtonReload = new ToolStripButton();
            _ToolStripButtonReload.Click += new EventHandler(ToolStripButtonReload_Click);
            _ToolStripMain.SuspendLayout();
            _PanelDetails.SuspendLayout();
            _StatusStripMain.SuspendLayout();
            _PanelBase.SuspendLayout();
            _ToolStripMaps.SuspendLayout();
            SuspendLayout();
            // 
            // ToolStripMain
            // 
            _ToolStripMain.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripMain.Items.AddRange(new ToolStripItem[] { _ToolStripButtonClear, _ToolStripButtonLoad, _ToolStripButtonSave, _ToolStripSeparator1, _ToolStripButtonWalk, _ToolStripSeparator3, _ToolStripButtonSnap, _ToolStripButtonProperties, _ToolStripSeparator4, _ToolStripButtonRecord, _ToolStripButtonLockPositions, _ToolStripButtonAllowDuplicates, _ToolStripSeparator5, _ToolStripButtonMoveNodes, _ToolStripButtonRemove, _ToolStripSeparator2, _ToolStripButtonFixID, _ToolStripButtonDock, _ToolStripSeparator7, _ToolStripButtonZoomOut, _ToolStripButtonZoomIn, _ToolStripSeparator6, _ToolStripButtonDown, _ToolStripButtonUp, _ToolStripLabelZ });
            _ToolStripMain.Location = new Point(0, 0);
            _ToolStripMain.Name = "ToolStripMain";
            _ToolStripMain.Size = new Size(803, 25);
            _ToolStripMain.TabIndex = 5;
            // 
            // ToolStripButtonClear
            // 
            _ToolStripButtonClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonClear.Image = (Image)resources.GetObject("ToolStripButtonClear.Image");
            _ToolStripButtonClear.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonClear.Name = "ToolStripButtonClear";
            _ToolStripButtonClear.Size = new Size(23, 22);
            _ToolStripButtonClear.Text = "New";
            // 
            // ToolStripButtonLoad
            // 
            _ToolStripButtonLoad.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonLoad.Image = (Image)resources.GetObject("ToolStripButtonLoad.Image");
            _ToolStripButtonLoad.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonLoad.Name = "ToolStripButtonLoad";
            _ToolStripButtonLoad.Size = new Size(23, 22);
            _ToolStripButtonLoad.Text = "Load";
            // 
            // ToolStripButtonSave
            // 
            _ToolStripButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonSave.Image = (Image)resources.GetObject("ToolStripButtonSave.Image");
            _ToolStripButtonSave.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonSave.Name = "ToolStripButtonSave";
            _ToolStripButtonSave.Size = new Size(23, 22);
            _ToolStripButtonSave.Text = "Save";
            // 
            // ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "ToolStripSeparator1";
            _ToolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolStripButtonWalk
            // 
            _ToolStripButtonWalk.Checked = true;
            _ToolStripButtonWalk.CheckOnClick = true;
            _ToolStripButtonWalk.CheckState = CheckState.Checked;
            _ToolStripButtonWalk.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonWalk.Image = (Image)resources.GetObject("ToolStripButtonWalk.Image");
            _ToolStripButtonWalk.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonWalk.Name = "ToolStripButtonWalk";
            _ToolStripButtonWalk.Size = new Size(23, 22);
            _ToolStripButtonWalk.Text = "Auto Walk Path";
            // 
            // ToolStripSeparator3
            // 
            _ToolStripSeparator3.Name = "ToolStripSeparator3";
            _ToolStripSeparator3.Size = new Size(6, 25);
            // 
            // ToolStripButtonSnap
            // 
            _ToolStripButtonSnap.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonSnap.Image = (Image)resources.GetObject("ToolStripButtonSnap.Image");
            _ToolStripButtonSnap.ImageScaling = ToolStripItemImageScaling.None;
            _ToolStripButtonSnap.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonSnap.Name = "ToolStripButtonSnap";
            _ToolStripButtonSnap.Size = new Size(23, 22);
            _ToolStripButtonSnap.Text = "Snap To Grid";
            // 
            // ToolStripButtonProperties
            // 
            _ToolStripButtonProperties.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonProperties.Image = (Image)resources.GetObject("ToolStripButtonProperties.Image");
            _ToolStripButtonProperties.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonProperties.Name = "ToolStripButtonProperties";
            _ToolStripButtonProperties.Size = new Size(23, 22);
            _ToolStripButtonProperties.Text = "Edit Panel";
            // 
            // ToolStripSeparator4
            // 
            _ToolStripSeparator4.Name = "ToolStripSeparator4";
            _ToolStripSeparator4.Size = new Size(6, 25);
            // 
            // ToolStripButtonRecord
            // 
            _ToolStripButtonRecord.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonRecord.Image = (Image)resources.GetObject("ToolStripButtonRecord.Image");
            _ToolStripButtonRecord.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRecord.Name = "ToolStripButtonRecord";
            _ToolStripButtonRecord.Size = new Size(23, 22);
            _ToolStripButtonRecord.Text = "Record Mode";
            // 
            // ToolStripButtonLockPositions
            // 
            _ToolStripButtonLockPositions.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonLockPositions.Enabled = false;
            _ToolStripButtonLockPositions.Image = (Image)resources.GetObject("ToolStripButtonLockPositions.Image");
            _ToolStripButtonLockPositions.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonLockPositions.Name = "ToolStripButtonLockPositions";
            _ToolStripButtonLockPositions.Size = new Size(23, 22);
            _ToolStripButtonLockPositions.Text = "Lock Positions";
            // 
            // ToolStripButtonAllowDuplicates
            // 
            _ToolStripButtonAllowDuplicates.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonAllowDuplicates.Enabled = false;
            _ToolStripButtonAllowDuplicates.Image = (Image)resources.GetObject("ToolStripButtonAllowDuplicates.Image");
            _ToolStripButtonAllowDuplicates.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonAllowDuplicates.Name = "ToolStripButtonAllowDuplicates";
            _ToolStripButtonAllowDuplicates.Size = new Size(23, 22);
            _ToolStripButtonAllowDuplicates.Text = "Allow Duplicate";
            _ToolStripButtonAllowDuplicates.ToolTipText = "Allow Duplicate Nodes";
            // 
            // ToolStripSeparator5
            // 
            _ToolStripSeparator5.Name = "ToolStripSeparator5";
            _ToolStripSeparator5.Size = new Size(6, 25);
            // 
            // ToolStripButtonMoveNodes
            // 
            _ToolStripButtonMoveNodes.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonMoveNodes.Image = (Image)resources.GetObject("ToolStripButtonMoveNodes.Image");
            _ToolStripButtonMoveNodes.ImageScaling = ToolStripItemImageScaling.None;
            _ToolStripButtonMoveNodes.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonMoveNodes.Name = "ToolStripButtonMoveNodes";
            _ToolStripButtonMoveNodes.Size = new Size(23, 22);
            _ToolStripButtonMoveNodes.Text = "Move Nodes/Labels";
            // 
            // ToolStripButtonRemove
            // 
            _ToolStripButtonRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonRemove.Enabled = false;
            _ToolStripButtonRemove.Image = (Image)resources.GetObject("ToolStripButtonRemove.Image");
            _ToolStripButtonRemove.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRemove.Name = "ToolStripButtonRemove";
            _ToolStripButtonRemove.Size = new Size(23, 22);
            _ToolStripButtonRemove.Text = "Remove Selected Nodes/Labels";
            // 
            // ToolStripSeparator2
            // 
            _ToolStripSeparator2.Name = "ToolStripSeparator2";
            _ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripButtonFixID
            // 
            _ToolStripButtonFixID.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonFixID.Image = My.Resources.Resources.text_x_script;
            _ToolStripButtonFixID.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonFixID.Name = "ToolStripButtonFixID";
            _ToolStripButtonFixID.Size = new Size(23, 22);
            _ToolStripButtonFixID.Text = "Reset Map IDs";
            _ToolStripButtonFixID.ToolTipText = "Reset Map IDs";
            // 
            // ToolStripButtonDock
            // 
            _ToolStripButtonDock.Alignment = ToolStripItemAlignment.Right;
            _ToolStripButtonDock.Checked = true;
            _ToolStripButtonDock.CheckOnClick = true;
            _ToolStripButtonDock.CheckState = CheckState.Checked;
            _ToolStripButtonDock.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonDock.Image = My.Resources.Resources.document_save;
            _ToolStripButtonDock.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonDock.Name = "ToolStripButtonDock";
            _ToolStripButtonDock.Size = new Size(23, 22);
            _ToolStripButtonDock.Text = "Docked";
            // 
            // ToolStripSeparator7
            // 
            _ToolStripSeparator7.Alignment = ToolStripItemAlignment.Right;
            _ToolStripSeparator7.Name = "ToolStripSeparator7";
            _ToolStripSeparator7.Size = new Size(6, 25);
            // 
            // ToolStripButtonZoomOut
            // 
            _ToolStripButtonZoomOut.Alignment = ToolStripItemAlignment.Right;
            _ToolStripButtonZoomOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonZoomOut.Enabled = false;
            _ToolStripButtonZoomOut.Image = (Image)resources.GetObject("ToolStripButtonZoomOut.Image");
            _ToolStripButtonZoomOut.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonZoomOut.Name = "ToolStripButtonZoomOut";
            _ToolStripButtonZoomOut.Size = new Size(23, 22);
            _ToolStripButtonZoomOut.Text = "Zoom Out";
            // 
            // ToolStripButtonZoomIn
            // 
            _ToolStripButtonZoomIn.Alignment = ToolStripItemAlignment.Right;
            _ToolStripButtonZoomIn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonZoomIn.Image = (Image)resources.GetObject("ToolStripButtonZoomIn.Image");
            _ToolStripButtonZoomIn.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonZoomIn.Name = "ToolStripButtonZoomIn";
            _ToolStripButtonZoomIn.Size = new Size(23, 22);
            _ToolStripButtonZoomIn.Text = "Zoom In";
            // 
            // ToolStripSeparator6
            // 
            _ToolStripSeparator6.Alignment = ToolStripItemAlignment.Right;
            _ToolStripSeparator6.Name = "ToolStripSeparator6";
            _ToolStripSeparator6.Size = new Size(6, 25);
            // 
            // ToolStripButtonDown
            // 
            _ToolStripButtonDown.Alignment = ToolStripItemAlignment.Right;
            _ToolStripButtonDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonDown.Image = (Image)resources.GetObject("ToolStripButtonDown.Image");
            _ToolStripButtonDown.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonDown.Name = "ToolStripButtonDown";
            _ToolStripButtonDown.Size = new Size(23, 22);
            _ToolStripButtonDown.Text = "Down";
            // 
            // ToolStripButtonUp
            // 
            _ToolStripButtonUp.Alignment = ToolStripItemAlignment.Right;
            _ToolStripButtonUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonUp.Image = (Image)resources.GetObject("ToolStripButtonUp.Image");
            _ToolStripButtonUp.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonUp.Name = "ToolStripButtonUp";
            _ToolStripButtonUp.Size = new Size(23, 22);
            _ToolStripButtonUp.Text = "Up";
            // 
            // ToolStripLabelZ
            // 
            _ToolStripLabelZ.Alignment = ToolStripItemAlignment.Right;
            _ToolStripLabelZ.Name = "ToolStripLabelZ";
            _ToolStripLabelZ.Size = new Size(45, 22);
            _ToolStripLabelZ.Text = "Level: 0";
            // 
            // OpenFileDialog1
            // 
            _OpenFileDialog1.DefaultExt = "xml";
            _OpenFileDialog1.Filter = "XML files|*.xml";
            _OpenFileDialog1.InitialDirectory = @"Maps\";
            _OpenFileDialog1.RestoreDirectory = true;
            // 
            // SaveFileDialog1
            // 
            _SaveFileDialog1.DefaultExt = "xml";
            _SaveFileDialog1.Filter = "XML files|*.xml";
            _SaveFileDialog1.InitialDirectory = @"Maps\";
            _SaveFileDialog1.RestoreDirectory = true;
            // 
            // PanelDetails
            // 
            _PanelDetails.Controls.Add(_PanelNodeDetails);
            _PanelDetails.Controls.Add(_PanelLabelDetails);
            _PanelDetails.Dock = DockStyle.Bottom;
            _PanelDetails.Location = new Point(0, 415);
            _PanelDetails.Name = "PanelDetails";
            _PanelDetails.Size = new Size(803, 175);
            _PanelDetails.TabIndex = 17;
            _PanelDetails.Visible = false;
            // 
            // PanelNodeDetails
            // 
            _PanelNodeDetails.Dock = DockStyle.Fill;
            _PanelNodeDetails.Location = new Point(0, 0);
            _PanelNodeDetails.MinimumSize = new Size(0, 175);
            _PanelNodeDetails.Name = "PanelNodeDetails";
            _PanelNodeDetails.Node = null;
            _PanelNodeDetails.Size = new Size(803, 175);
            _PanelNodeDetails.TabIndex = 0;
            // 
            // PanelLabelDetails
            // 
            _PanelLabelDetails.Dock = DockStyle.Fill;
            _PanelLabelDetails.Label = null;
            _PanelLabelDetails.Location = new Point(0, 0);
            _PanelLabelDetails.MinimumSize = new Size(0, 97);
            _PanelLabelDetails.Name = "PanelLabelDetails";
            _PanelLabelDetails.Size = new Size(803, 175);
            _PanelLabelDetails.TabIndex = 1;
            // 
            // StatusStripMain
            // 
            _StatusStripMain.BackColor = SystemColors.Control;
            _StatusStripMain.GripStyle = ToolStripGripStyle.Visible;
            _StatusStripMain.Items.AddRange(new ToolStripItem[] { _ToolStripStatusText });
            _StatusStripMain.Location = new Point(0, 590);
            _StatusStripMain.Name = "StatusStripMain";
            _StatusStripMain.Size = new Size(803, 22);
            _StatusStripMain.TabIndex = 18;
            // 
            // ToolStripStatusText
            // 
            _ToolStripStatusText.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusText.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusText.Name = "ToolStripStatusText";
            _ToolStripStatusText.Size = new Size(788, 17);
            _ToolStripStatusText.Spring = true;
            _ToolStripStatusText.Text = "Ready.";
            _ToolStripStatusText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PanelBase
            // 
            _PanelBase.AutoScroll = true;
            _PanelBase.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            _PanelBase.BorderStyle = BorderStyle.Fixed3D;
            _PanelBase.Controls.Add(_PanelMap);
            _PanelBase.Dock = DockStyle.Fill;
            _PanelBase.Location = new Point(0, 50);
            _PanelBase.Name = "PanelBase";
            _PanelBase.Size = new Size(803, 365);
            _PanelBase.TabIndex = 19;
            // 
            // PanelMap
            // 
            _PanelMap.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            _PanelMap.Dock = DockStyle.Fill;
            _PanelMap.DrawLines = false;
            _PanelMap.Location = new Point(0, 0);
            _PanelMap.Name = "PanelMap";
            _PanelMap.Size = new Size(799, 361);
            _PanelMap.TabIndex = 6;
            // 
            // ToolStripMaps
            // 
            _ToolStripMaps.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripMaps.Items.AddRange(new ToolStripItem[] { _ToolStripDropDownButtonMaps, _ToolStripButtonReload });
            _ToolStripMaps.Location = new Point(0, 25);
            _ToolStripMaps.Name = "ToolStripMaps";
            _ToolStripMaps.Size = new Size(803, 25);
            _ToolStripMaps.TabIndex = 20;
            _ToolStripMaps.Text = "ToolStripMaps";
            // 
            // ToolStripDropDownButtonMaps
            // 
            _ToolStripDropDownButtonMaps.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _ToolStripDropDownButtonMaps.DropDownItems.AddRange(new ToolStripItem[] { _TestToolStripMenuItem });
            _ToolStripDropDownButtonMaps.Image = (Image)resources.GetObject("ToolStripDropDownButtonMaps.Image");
            _ToolStripDropDownButtonMaps.ImageTransparentColor = Color.Magenta;
            _ToolStripDropDownButtonMaps.Name = "ToolStripDropDownButtonMaps";
            _ToolStripDropDownButtonMaps.Size = new Size(80, 22);
            _ToolStripDropDownButtonMaps.Text = "Untitled Map";
            _ToolStripDropDownButtonMaps.ToolTipText = "Maps";
            // 
            // TestToolStripMenuItem
            // 
            _TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            _TestToolStripMenuItem.Size = new Size(95, 22);
            _TestToolStripMenuItem.Text = "Test";
            // 
            // ToolStripButtonReload
            // 
            _ToolStripButtonReload.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _ToolStripButtonReload.Image = (Image)resources.GetObject("ToolStripButtonReload.Image");
            _ToolStripButtonReload.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonReload.Name = "ToolStripButtonReload";
            _ToolStripButtonReload.Size = new Size(23, 22);
            _ToolStripButtonReload.Text = "Reload Map List";
            // 
            // MapForm
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 612);
            Controls.Add(_PanelBase);
            Controls.Add(_PanelDetails);
            Controls.Add(_StatusStripMain);
            Controls.Add(_ToolStripMaps);
            Controls.Add(_ToolStripMain);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "MapForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.Manual;
            Text = "AutoMapper";
            _ToolStripMain.ResumeLayout(false);
            _ToolStripMain.PerformLayout();
            _PanelDetails.ResumeLayout(false);
            _StatusStripMain.ResumeLayout(false);
            _StatusStripMain.PerformLayout();
            _PanelBase.ResumeLayout(false);
            _ToolStripMaps.ResumeLayout(false);
            _ToolStripMaps.PerformLayout();
            FormClosing += new FormClosingEventHandler(MapForm_FormClosing);
            KeyDown += new KeyEventHandler(GraphForm_KeyDown);
            KeyUp += new KeyEventHandler(GraphForm_KeyUp);
            Load += new EventHandler(GraphForm_Load);
            Resize += new EventHandler(GraphForm_Resize);
            Resize += new EventHandler(PanelBase_Resize);
            VisibleChanged += new EventHandler(MapForm_VisibleChanged);
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStrip _ToolStripMain;

        internal ToolStrip ToolStripMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMain != null)
                {
                    _ToolStripMain.KeyUp -= GraphForm_KeyDown;
                    _ToolStripMain.KeyUp -= GraphForm_KeyUp;
                }

                _ToolStripMain = value;
                if (_ToolStripMain != null)
                {
                    _ToolStripMain.KeyUp += GraphForm_KeyDown;
                    _ToolStripMain.KeyUp += GraphForm_KeyUp;
                }
            }
        }

        private ToolStripButton _ToolStripButtonClear;

        internal ToolStripButton ToolStripButtonClear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonClear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonClear != null)
                {
                    _ToolStripButtonClear.Click -= ToolStripButtonClear_Click;
                }

                _ToolStripButtonClear = value;
                if (_ToolStripButtonClear != null)
                {
                    _ToolStripButtonClear.Click += ToolStripButtonClear_Click;
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

        private ToolStripButton _ToolStripButtonRecord;

        internal ToolStripButton ToolStripButtonRecord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonRecord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonRecord != null)
                {
                    _ToolStripButtonRecord.Click -= ToolStripButtonRecord_Click;
                }

                _ToolStripButtonRecord = value;
                if (_ToolStripButtonRecord != null)
                {
                    _ToolStripButtonRecord.Click += ToolStripButtonRecord_Click;
                }
            }
        }

        private FlickerFreePanel _PanelMap;

        internal FlickerFreePanel PanelMap
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelMap;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelMap != null)
                {
                    _PanelMap.MouseDown -= FlickerFreePanel1_MouseDown;
                    _PanelMap.MouseLeave -= FlickerFreePanel1_MouseLeave;
                    _PanelMap.MouseMove -= FlickerFreePanel1_MouseMove;
                    _PanelMap.MouseUp -= FlickerFreePanel1_MouseUp;
                    _PanelMap.Paint -= FlickerFreePanel1_Paint;
                }

                _PanelMap = value;
                if (_PanelMap != null)
                {
                    _PanelMap.MouseDown += FlickerFreePanel1_MouseDown;
                    _PanelMap.MouseLeave += FlickerFreePanel1_MouseLeave;
                    _PanelMap.MouseMove += FlickerFreePanel1_MouseMove;
                    _PanelMap.MouseUp += FlickerFreePanel1_MouseUp;
                    _PanelMap.Paint += FlickerFreePanel1_Paint;
                }
            }
        }

        private ToolStripButton _ToolStripButtonSnap;

        internal ToolStripButton ToolStripButtonSnap
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonSnap;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonSnap != null)
                {
                    _ToolStripButtonSnap.Click -= ToolStripButtonSnap_Click;
                }

                _ToolStripButtonSnap = value;
                if (_ToolStripButtonSnap != null)
                {
                    _ToolStripButtonSnap.Click += ToolStripButtonSnap_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonMoveNodes;

        internal ToolStripButton ToolStripButtonMoveNodes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonMoveNodes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonMoveNodes != null)
                {
                    _ToolStripButtonMoveNodes.Click -= ToolStripButtonMoveNodes_Click;
                }

                _ToolStripButtonMoveNodes = value;
                if (_ToolStripButtonMoveNodes != null)
                {
                    _ToolStripButtonMoveNodes.Click += ToolStripButtonMoveNodes_Click;
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

        private OpenFileDialog _OpenFileDialog1;

        internal OpenFileDialog OpenFileDialog1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpenFileDialog1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpenFileDialog1 != null)
                {
                }

                _OpenFileDialog1 = value;
                if (_OpenFileDialog1 != null)
                {
                }
            }
        }

        private SaveFileDialog _SaveFileDialog1;

        internal SaveFileDialog SaveFileDialog1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveFileDialog1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveFileDialog1 != null)
                {
                }

                _SaveFileDialog1 = value;
                if (_SaveFileDialog1 != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonProperties;

        internal ToolStripButton ToolStripButtonProperties
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonProperties;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonProperties != null)
                {
                    _ToolStripButtonProperties.Click -= ToolStripButtonProperties_Click;
                }

                _ToolStripButtonProperties = value;
                if (_ToolStripButtonProperties != null)
                {
                    _ToolStripButtonProperties.Click += ToolStripButtonProperties_Click;
                }
            }
        }

        private Panel _PanelDetails;

        internal Panel PanelDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelDetails != null)
                {
                }

                _PanelDetails = value;
                if (_PanelDetails != null)
                {
                }
            }
        }

        private StatusStrip _StatusStripMain;

        internal StatusStrip StatusStripMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StatusStripMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StatusStripMain != null)
                {
                }

                _StatusStripMain = value;
                if (_StatusStripMain != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusText;

        internal ToolStripStatusLabel ToolStripStatusText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusText != null)
                {
                }

                _ToolStripStatusText = value;
                if (_ToolStripStatusText != null)
                {
                }
            }
        }

        private Panel _PanelBase;

        internal Panel PanelBase
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelBase;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelBase != null)
                {
                }

                _PanelBase = value;
                if (_PanelBase != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonUp;

        internal ToolStripButton ToolStripButtonUp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonUp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonUp != null)
                {
                    _ToolStripButtonUp.Click -= ToolStripButtonUp_Click;
                }

                _ToolStripButtonUp = value;
                if (_ToolStripButtonUp != null)
                {
                    _ToolStripButtonUp.Click += ToolStripButtonUp_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonDown;

        internal ToolStripButton ToolStripButtonDown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonDown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonDown != null)
                {
                    _ToolStripButtonDown.Click -= ToolStripButtonDown_Click;
                }

                _ToolStripButtonDown = value;
                if (_ToolStripButtonDown != null)
                {
                    _ToolStripButtonDown.Click += ToolStripButtonDown_Click;
                }
            }
        }

        private ToolStripLabel _ToolStripLabelZ;

        internal ToolStripLabel ToolStripLabelZ
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripLabelZ;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripLabelZ != null)
                {
                }

                _ToolStripLabelZ = value;
                if (_ToolStripLabelZ != null)
                {
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

        private ToolStripButton _ToolStripButtonWalk;

        internal ToolStripButton ToolStripButtonWalk
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonWalk;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonWalk != null)
                {
                    _ToolStripButtonWalk.Click -= ToolStripButtonWalk_Click;
                }

                _ToolStripButtonWalk = value;
                if (_ToolStripButtonWalk != null)
                {
                    _ToolStripButtonWalk.Click += ToolStripButtonWalk_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonAllowDuplicates;

        internal ToolStripButton ToolStripButtonAllowDuplicates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonAllowDuplicates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonAllowDuplicates != null)
                {
                    _ToolStripButtonAllowDuplicates.Click -= ToolStripButtonAllowDuplicates_Click;
                }

                _ToolStripButtonAllowDuplicates = value;
                if (_ToolStripButtonAllowDuplicates != null)
                {
                    _ToolStripButtonAllowDuplicates.Click += ToolStripButtonAllowDuplicates_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonLockPositions;

        internal ToolStripButton ToolStripButtonLockPositions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonLockPositions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonLockPositions != null)
                {
                    _ToolStripButtonLockPositions.Click -= ToolStripButtonLockPositions_Click;
                }

                _ToolStripButtonLockPositions = value;
                if (_ToolStripButtonLockPositions != null)
                {
                    _ToolStripButtonLockPositions.Click += ToolStripButtonLockPositions_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator4;

        internal ToolStripSeparator ToolStripSeparator4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator4 != null)
                {
                }

                _ToolStripSeparator4 = value;
                if (_ToolStripSeparator4 != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator5;

        internal ToolStripSeparator ToolStripSeparator5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator5 != null)
                {
                }

                _ToolStripSeparator5 = value;
                if (_ToolStripSeparator5 != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator3;

        internal ToolStripSeparator ToolStripSeparator3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator3 != null)
                {
                }

                _ToolStripSeparator3 = value;
                if (_ToolStripSeparator3 != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator6;

        internal ToolStripSeparator ToolStripSeparator6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator6 != null)
                {
                }

                _ToolStripSeparator6 = value;
                if (_ToolStripSeparator6 != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonZoomIn;

        internal ToolStripButton ToolStripButtonZoomIn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonZoomIn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonZoomIn != null)
                {
                    _ToolStripButtonZoomIn.Click -= ToolStripButtonZoomIn_Click;
                }

                _ToolStripButtonZoomIn = value;
                if (_ToolStripButtonZoomIn != null)
                {
                    _ToolStripButtonZoomIn.Click += ToolStripButtonZoomIn_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonZoomOut;

        internal ToolStripButton ToolStripButtonZoomOut
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonZoomOut;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonZoomOut != null)
                {
                    _ToolStripButtonZoomOut.Click -= ToolStripButtonZoomOut_Click;
                }

                _ToolStripButtonZoomOut = value;
                if (_ToolStripButtonZoomOut != null)
                {
                    _ToolStripButtonZoomOut.Click += ToolStripButtonZoomOut_Click;
                }
            }
        }

        private ToolStrip _ToolStripMaps;

        internal ToolStrip ToolStripMaps
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMaps;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMaps != null)
                {
                }

                _ToolStripMaps = value;
                if (_ToolStripMaps != null)
                {
                }
            }
        }

        private ToolStripDropDownButton _ToolStripDropDownButtonMaps;

        internal ToolStripDropDownButton ToolStripDropDownButtonMaps
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripDropDownButtonMaps;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripDropDownButtonMaps != null)
                {
                }

                _ToolStripDropDownButtonMaps = value;
                if (_ToolStripDropDownButtonMaps != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonReload;

        internal ToolStripButton ToolStripButtonReload
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonReload;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonReload != null)
                {
                    _ToolStripButtonReload.Click -= ToolStripButtonReload_Click;
                }

                _ToolStripButtonReload = value;
                if (_ToolStripButtonReload != null)
                {
                    _ToolStripButtonReload.Click += ToolStripButtonReload_Click;
                }
            }
        }

        private ToolStripMenuItem _TestToolStripMenuItem;

        internal ToolStripMenuItem TestToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TestToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TestToolStripMenuItem != null)
                {
                }

                _TestToolStripMenuItem = value;
                if (_TestToolStripMenuItem != null)
                {
                }
            }
        }

        private LabelDetails _PanelLabelDetails;

        internal LabelDetails PanelLabelDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelLabelDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelLabelDetails != null)
                {
                    _PanelLabelDetails.UpdateMap -= PanelNodeDetails_UpdateMap;
                    _PanelLabelDetails.NewLabel -= EventAddLabel;
                }

                _PanelLabelDetails = value;
                if (_PanelLabelDetails != null)
                {
                    _PanelLabelDetails.UpdateMap += PanelNodeDetails_UpdateMap;
                    _PanelLabelDetails.NewLabel += EventAddLabel;
                }
            }
        }

        private NodeDetails _PanelNodeDetails;

        internal NodeDetails PanelNodeDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelNodeDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelNodeDetails != null)
                {
                    _PanelNodeDetails.UpdateMap -= PanelNodeDetails_UpdateMap;
                    _PanelNodeDetails.CopyNode -= PanelNodeDetails_CopyNode;
                    _PanelNodeDetails.AddNode -= PanelNodeDetails_AddNode;
                    _PanelNodeDetails.RemoveNode -= PanelNodeDetails_RemoveNode;
                    _PanelNodeDetails.NewNode -= PanelNodeDetails_NewNode;
                    _PanelNodeDetails.ArcChanged -= PanelNodeDetails_ArcChanged;
                    _PanelNodeDetails.NewLabel -= EventAddLabel;
                }

                _PanelNodeDetails = value;
                if (_PanelNodeDetails != null)
                {
                    _PanelNodeDetails.UpdateMap += PanelNodeDetails_UpdateMap;
                    _PanelNodeDetails.CopyNode += PanelNodeDetails_CopyNode;
                    _PanelNodeDetails.AddNode += PanelNodeDetails_AddNode;
                    _PanelNodeDetails.RemoveNode += PanelNodeDetails_RemoveNode;
                    _PanelNodeDetails.NewNode += PanelNodeDetails_NewNode;
                    _PanelNodeDetails.ArcChanged += PanelNodeDetails_ArcChanged;
                    _PanelNodeDetails.NewLabel += EventAddLabel;
                }
            }
        }

        private ToolStripButton _ToolStripButtonFixID;

        internal ToolStripButton ToolStripButtonFixID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonFixID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonFixID != null)
                {
                    _ToolStripButtonFixID.Click -= ToolStripButton1_Click;
                }

                _ToolStripButtonFixID = value;
                if (_ToolStripButtonFixID != null)
                {
                    _ToolStripButtonFixID.Click += ToolStripButton1_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonDock;

        internal ToolStripButton ToolStripButtonDock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonDock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonDock != null)
                {
                    _ToolStripButtonDock.Click -= ToolStripButtonDock_Click;
                }

                _ToolStripButtonDock = value;
                if (_ToolStripButtonDock != null)
                {
                    _ToolStripButtonDock.Click += ToolStripButtonDock_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator7;

        internal ToolStripSeparator ToolStripSeparator7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator7 != null)
                {
                }

                _ToolStripSeparator7 = value;
                if (_ToolStripSeparator7 != null)
                {
                }
            }
        }
    }
}