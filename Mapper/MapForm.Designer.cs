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
        #pragma warning disable 0649
        private System.ComponentModel.IContainer components;
        #pragma warning restore 0649

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this._ToolStripMain = new System.Windows.Forms.ToolStrip();
            this._ToolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonWalk = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonSnap = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonProperties = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonRecord = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonLockPositions = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonAllowDuplicates = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonMoveNodes = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonFixID = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonDock = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this._ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripButtonDown = new System.Windows.Forms.ToolStripButton();
            this._ToolStripButtonUp = new System.Windows.Forms.ToolStripButton();
            this._ToolStripLabelZ = new System.Windows.Forms.ToolStripLabel();
            this._OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this._PanelDetails = new System.Windows.Forms.Panel();
            this._PanelNodeDetails = new GenieClient.NodeDetails();
            this._PanelLabelDetails = new GenieClient.LabelDetails();
            this._StatusStripMain = new System.Windows.Forms.StatusStrip();
            this._ToolStripStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this._PanelBase = new System.Windows.Forms.Panel();
            this._PanelMap = new GenieClient.FlickerFreePanel();
            this._ToolStripMaps = new System.Windows.Forms.ToolStrip();
            this._ToolStripDropDownButtonMaps = new System.Windows.Forms.ToolStripDropDownButton();
            this._TestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this._ToolStripMain.SuspendLayout();
            this._PanelDetails.SuspendLayout();
            this._StatusStripMain.SuspendLayout();
            this._PanelBase.SuspendLayout();
            this._ToolStripMaps.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ToolStripMain
            // 
            this._ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._ToolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripButtonClear,
            this._ToolStripButtonLoad,
            this._ToolStripButtonSave,
            this._ToolStripSeparator1,
            this._ToolStripButtonWalk,
            this._ToolStripSeparator3,
            this._ToolStripButtonSnap,
            this._ToolStripButtonProperties,
            this._ToolStripSeparator4,
            this._ToolStripButtonRecord,
            this._ToolStripButtonLockPositions,
            this._ToolStripButtonAllowDuplicates,
            this._ToolStripSeparator5,
            this._ToolStripButtonMoveNodes,
            this._ToolStripButtonRemove,
            this._ToolStripSeparator2,
            this._ToolStripButtonFixID,
            this._ToolStripButtonDock,
            this._ToolStripSeparator7,
            this._ToolStripButtonZoomOut,
            this._ToolStripButtonZoomIn,
            this._ToolStripSeparator6,
            this._ToolStripButtonDown,
            this._ToolStripButtonUp,
            this._ToolStripLabelZ});
            this._ToolStripMain.Location = new System.Drawing.Point(0, 0);
            this._ToolStripMain.Name = "_ToolStripMain";
            this._ToolStripMain.Size = new System.Drawing.Size(1299, 25);
            this._ToolStripMain.TabIndex = 5;
            this._ToolStripMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GraphForm_KeyUp);
            // 
            // _ToolStripButtonClear
            // 
            this._ToolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonClear.Image")));
            this._ToolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonClear.Name = "_ToolStripButtonClear";
            this._ToolStripButtonClear.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonClear.Text = "New";
            this._ToolStripButtonClear.Click += new System.EventHandler(this.ToolStripButtonClear_Click);
            // 
            // _ToolStripButtonLoad
            // 
            this._ToolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonLoad.Image")));
            this._ToolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonLoad.Name = "_ToolStripButtonLoad";
            this._ToolStripButtonLoad.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonLoad.Text = "Load";
            this._ToolStripButtonLoad.Click += new System.EventHandler(this.ToolStripButtonLoad_Click);
            // 
            // _ToolStripButtonSave
            // 
            this._ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonSave.Image")));
            this._ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonSave.Name = "_ToolStripButtonSave";
            this._ToolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonSave.Text = "Save";
            this._ToolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSave_Click);
            // 
            // _ToolStripSeparator1
            // 
            this._ToolStripSeparator1.Name = "_ToolStripSeparator1";
            this._ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonWalk
            // 
            this._ToolStripButtonWalk.Checked = true;
            this._ToolStripButtonWalk.CheckOnClick = true;
            this._ToolStripButtonWalk.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ToolStripButtonWalk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonWalk.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonWalk.Image")));
            this._ToolStripButtonWalk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonWalk.Name = "_ToolStripButtonWalk";
            this._ToolStripButtonWalk.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonWalk.Text = "Auto Walk Path";
            this._ToolStripButtonWalk.Click += new System.EventHandler(this.ToolStripButtonWalk_Click);
            // 
            // _ToolStripSeparator3
            // 
            this._ToolStripSeparator3.Name = "_ToolStripSeparator3";
            this._ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonSnap
            // 
            this._ToolStripButtonSnap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonSnap.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonSnap.Image")));
            this._ToolStripButtonSnap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._ToolStripButtonSnap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonSnap.Name = "_ToolStripButtonSnap";
            this._ToolStripButtonSnap.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonSnap.Text = "Snap To Grid";
            this._ToolStripButtonSnap.Click += new System.EventHandler(this.ToolStripButtonSnap_Click);
            // 
            // _ToolStripButtonProperties
            // 
            this._ToolStripButtonProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonProperties.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonProperties.Image")));
            this._ToolStripButtonProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonProperties.Name = "_ToolStripButtonProperties";
            this._ToolStripButtonProperties.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonProperties.Text = "Edit Panel";
            this._ToolStripButtonProperties.Click += new System.EventHandler(this.ToolStripButtonProperties_Click);
            // 
            // _ToolStripSeparator4
            // 
            this._ToolStripSeparator4.Name = "_ToolStripSeparator4";
            this._ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonRecord
            // 
            this._ToolStripButtonRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonRecord.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonRecord.Image")));
            this._ToolStripButtonRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonRecord.Name = "_ToolStripButtonRecord";
            this._ToolStripButtonRecord.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonRecord.Text = "Record Mode";
            this._ToolStripButtonRecord.Click += new System.EventHandler(this.ToolStripButtonRecord_Click);
            // 
            // _ToolStripButtonLockPositions
            // 
            this._ToolStripButtonLockPositions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonLockPositions.Enabled = false;
            this._ToolStripButtonLockPositions.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonLockPositions.Image")));
            this._ToolStripButtonLockPositions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonLockPositions.Name = "_ToolStripButtonLockPositions";
            this._ToolStripButtonLockPositions.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonLockPositions.Text = "Lock Positions";
            this._ToolStripButtonLockPositions.Click += new System.EventHandler(this.ToolStripButtonLockPositions_Click);
            // 
            // _ToolStripButtonAllowDuplicates
            // 
            this._ToolStripButtonAllowDuplicates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonAllowDuplicates.Enabled = false;
            this._ToolStripButtonAllowDuplicates.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonAllowDuplicates.Image")));
            this._ToolStripButtonAllowDuplicates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonAllowDuplicates.Name = "_ToolStripButtonAllowDuplicates";
            this._ToolStripButtonAllowDuplicates.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonAllowDuplicates.Text = "Allow Duplicate";
            this._ToolStripButtonAllowDuplicates.ToolTipText = "Allow Duplicate Nodes";
            this._ToolStripButtonAllowDuplicates.Click += new System.EventHandler(this.ToolStripButtonAllowDuplicates_Click);
            // 
            // _ToolStripSeparator5
            // 
            this._ToolStripSeparator5.Name = "_ToolStripSeparator5";
            this._ToolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonMoveNodes
            // 
            this._ToolStripButtonMoveNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonMoveNodes.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonMoveNodes.Image")));
            this._ToolStripButtonMoveNodes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._ToolStripButtonMoveNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonMoveNodes.Name = "_ToolStripButtonMoveNodes";
            this._ToolStripButtonMoveNodes.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonMoveNodes.Text = "Move Nodes/Labels";
            this._ToolStripButtonMoveNodes.Click += new System.EventHandler(this.ToolStripButtonMoveNodes_Click);
            // 
            // _ToolStripButtonRemove
            // 
            this._ToolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonRemove.Enabled = false;
            this._ToolStripButtonRemove.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonRemove.Image")));
            this._ToolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonRemove.Name = "_ToolStripButtonRemove";
            this._ToolStripButtonRemove.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonRemove.Text = "Remove Selected Nodes/Labels";
            this._ToolStripButtonRemove.Click += new System.EventHandler(this.ToolStripButtonRemove_Click);
            // 
            // _ToolStripSeparator2
            // 
            this._ToolStripSeparator2.Name = "_ToolStripSeparator2";
            this._ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonFixID
            // 
            this._ToolStripButtonFixID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonFixID.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonFixID.Image")));
            this._ToolStripButtonFixID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonFixID.Name = "_ToolStripButtonFixID";
            this._ToolStripButtonFixID.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonFixID.Text = "Reset Map IDs";
            this._ToolStripButtonFixID.ToolTipText = "Reset Map IDs";
            this._ToolStripButtonFixID.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // _ToolStripButtonDock
            // 
            this._ToolStripButtonDock.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._ToolStripButtonDock.Checked = true;
            this._ToolStripButtonDock.CheckOnClick = true;
            this._ToolStripButtonDock.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ToolStripButtonDock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonDock.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonDock.Image")));
            this._ToolStripButtonDock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonDock.Name = "_ToolStripButtonDock";
            this._ToolStripButtonDock.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonDock.Text = "Docked";
            this._ToolStripButtonDock.Click += new System.EventHandler(this.ToolStripButtonDock_Click);
            // 
            // _ToolStripSeparator7
            // 
            this._ToolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._ToolStripSeparator7.Name = "_ToolStripSeparator7";
            this._ToolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonZoomOut
            // 
            this._ToolStripButtonZoomOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._ToolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonZoomOut.Enabled = false;
            this._ToolStripButtonZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonZoomOut.Image")));
            this._ToolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonZoomOut.Name = "_ToolStripButtonZoomOut";
            this._ToolStripButtonZoomOut.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonZoomOut.Text = "Zoom Out";
            this._ToolStripButtonZoomOut.Click += new System.EventHandler(this.ToolStripButtonZoomOut_Click);
            // 
            // _ToolStripButtonZoomIn
            // 
            this._ToolStripButtonZoomIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._ToolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonZoomIn.Image")));
            this._ToolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonZoomIn.Name = "_ToolStripButtonZoomIn";
            this._ToolStripButtonZoomIn.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonZoomIn.Text = "Zoom In";
            this._ToolStripButtonZoomIn.Click += new System.EventHandler(this.ToolStripButtonZoomIn_Click);
            // 
            // _ToolStripSeparator6
            // 
            this._ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._ToolStripSeparator6.Name = "_ToolStripSeparator6";
            this._ToolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // _ToolStripButtonDown
            // 
            this._ToolStripButtonDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._ToolStripButtonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonDown.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonDown.Image")));
            this._ToolStripButtonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonDown.Name = "_ToolStripButtonDown";
            this._ToolStripButtonDown.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonDown.Text = "Down";
            this._ToolStripButtonDown.Click += new System.EventHandler(this.ToolStripButtonDown_Click);
            // 
            // _ToolStripButtonUp
            // 
            this._ToolStripButtonUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._ToolStripButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonUp.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonUp.Image")));
            this._ToolStripButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonUp.Name = "_ToolStripButtonUp";
            this._ToolStripButtonUp.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonUp.Text = "Up";
            this._ToolStripButtonUp.Click += new System.EventHandler(this.ToolStripButtonUp_Click);
            // 
            // _ToolStripLabelZ
            // 
            this._ToolStripLabelZ.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._ToolStripLabelZ.Name = "_ToolStripLabelZ";
            this._ToolStripLabelZ.Size = new System.Drawing.Size(46, 22);
            this._ToolStripLabelZ.Text = "Level: 0";
            // 
            // _OpenFileDialog1
            // 
            this._OpenFileDialog1.DefaultExt = "xml";
            this._OpenFileDialog1.Filter = "XML files|*.xml";
            this._OpenFileDialog1.InitialDirectory = "Maps\\";
            this._OpenFileDialog1.RestoreDirectory = true;
            // 
            // _SaveFileDialog1
            // 
            this._SaveFileDialog1.DefaultExt = "xml";
            this._SaveFileDialog1.Filter = "XML files|*.xml";
            this._SaveFileDialog1.InitialDirectory = "Maps\\";
            this._SaveFileDialog1.RestoreDirectory = true;
            // 
            // _PanelDetails
            // 
            this._PanelDetails.Controls.Add(this._PanelNodeDetails);
            this._PanelDetails.Controls.Add(this._PanelLabelDetails);
            this._PanelDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PanelDetails.Location = new System.Drawing.Point(0, 413);
            this._PanelDetails.Name = "_PanelDetails";
            this._PanelDetails.Size = new System.Drawing.Size(1299, 175);
            this._PanelDetails.TabIndex = 17;
            this._PanelDetails.Visible = false;
            // 
            // _PanelNodeDetails
            // 
            this._PanelNodeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelNodeDetails.Location = new System.Drawing.Point(0, 0);
            this._PanelNodeDetails.MinimumSize = new System.Drawing.Size(0, 175);
            this._PanelNodeDetails.Name = "_PanelNodeDetails";
            this._PanelNodeDetails.Node = null;
            this._PanelNodeDetails.Size = new System.Drawing.Size(1299, 175);
            this._PanelNodeDetails.TabIndex = 0;
            this._PanelNodeDetails.NewNode += new GenieClient.NodeDetails.NewNodeEventHandler(this.PanelNodeDetails_NewNode);
            this._PanelNodeDetails.CopyNode += new GenieClient.NodeDetails.CopyNodeEventHandler(this.PanelNodeDetails_CopyNode);
            this._PanelNodeDetails.RemoveNode += new GenieClient.NodeDetails.RemoveNodeEventHandler(this.PanelNodeDetails_RemoveNode);
            this._PanelNodeDetails.AddNode += new GenieClient.NodeDetails.AddNodeEventHandler(this.PanelNodeDetails_AddNode);
            this._PanelNodeDetails.UpdateMap += new GenieClient.NodeDetails.UpdateMapEventHandler(this.PanelNodeDetails_UpdateMap);
            this._PanelNodeDetails.ArcChanged += new GenieClient.NodeDetails.ArcChangedEventHandler(this.PanelNodeDetails_ArcChanged);
            this._PanelNodeDetails.NewLabel += new GenieClient.NodeDetails.NewLabelEventHandler(this.EventAddLabel);
            // 
            // _PanelLabelDetails
            // 
            this._PanelLabelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelLabelDetails.Label = null;
            this._PanelLabelDetails.Location = new System.Drawing.Point(0, 0);
            this._PanelLabelDetails.MinimumSize = new System.Drawing.Size(0, 97);
            this._PanelLabelDetails.Name = "_PanelLabelDetails";
            this._PanelLabelDetails.Size = new System.Drawing.Size(1299, 175);
            this._PanelLabelDetails.TabIndex = 1;
            this._PanelLabelDetails.NewLabel += new GenieClient.LabelDetails.NewLabelEventHandler(this.EventAddLabel);
            this._PanelLabelDetails.UpdateMap += new GenieClient.LabelDetails.UpdateMapEventHandler(this.PanelNodeDetails_UpdateMap);
            // 
            // _StatusStripMain
            // 
            this._StatusStripMain.BackColor = System.Drawing.SystemColors.Control;
            this._StatusStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this._StatusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripStatusText});
            this._StatusStripMain.Location = new System.Drawing.Point(0, 588);
            this._StatusStripMain.Name = "_StatusStripMain";
            this._StatusStripMain.Size = new System.Drawing.Size(1299, 24);
            this._StatusStripMain.TabIndex = 18;
            // 
            // _ToolStripStatusText
            // 
            this._ToolStripStatusText.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusText.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusText.Name = "_ToolStripStatusText";
            this._ToolStripStatusText.Size = new System.Drawing.Size(1284, 19);
            this._ToolStripStatusText.Spring = true;
            this._ToolStripStatusText.Text = "Ready.";
            this._ToolStripStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _PanelBase
            // 
            this._PanelBase.AutoScroll = true;
            this._PanelBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._PanelBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._PanelBase.Controls.Add(this._PanelMap);
            this._PanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelBase.Location = new System.Drawing.Point(0, 50);
            this._PanelBase.Name = "_PanelBase";
            this._PanelBase.Size = new System.Drawing.Size(1299, 363);
            this._PanelBase.TabIndex = 19;
            // 
            // _PanelMap
            // 
            this._PanelMap.AutoScroll = true;
            this._PanelMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._PanelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelMap.DrawLines = false;
            this._PanelMap.Location = new System.Drawing.Point(0, 0);
            this._PanelMap.Name = "_PanelMap";
            this._PanelMap.Size = new System.Drawing.Size(1295, 359);
            this._PanelMap.TabIndex = 6;
            this._PanelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.FlickerFreePanel1_Paint);
            this._PanelMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlickerFreePanel1_MouseDown);
            this._PanelMap.MouseLeave += new System.EventHandler(this.FlickerFreePanel1_MouseLeave);
            this._PanelMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlickerFreePanel1_MouseMove);
            this._PanelMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FlickerFreePanel1_MouseUp);
            // 
            // _ToolStripMaps
            // 
            this._ToolStripMaps.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._ToolStripMaps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripDropDownButtonMaps,
            this._ToolStripButtonReload});
            this._ToolStripMaps.Location = new System.Drawing.Point(0, 25);
            this._ToolStripMaps.Name = "_ToolStripMaps";
            this._ToolStripMaps.Size = new System.Drawing.Size(1299, 25);
            this._ToolStripMaps.TabIndex = 20;
            this._ToolStripMaps.Text = "ToolStripMaps";
            // 
            // _ToolStripDropDownButtonMaps
            // 
            this._ToolStripDropDownButtonMaps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._ToolStripDropDownButtonMaps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._TestToolStripMenuItem});
            this._ToolStripDropDownButtonMaps.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripDropDownButtonMaps.Image")));
            this._ToolStripDropDownButtonMaps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripDropDownButtonMaps.Name = "_ToolStripDropDownButtonMaps";
            this._ToolStripDropDownButtonMaps.Size = new System.Drawing.Size(89, 22);
            this._ToolStripDropDownButtonMaps.Text = "Untitled Map";
            this._ToolStripDropDownButtonMaps.ToolTipText = "Maps";
            // 
            // _TestToolStripMenuItem
            // 
            this._TestToolStripMenuItem.Name = "_TestToolStripMenuItem";
            this._TestToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this._TestToolStripMenuItem.Text = "Test";
            // 
            // _ToolStripButtonReload
            // 
            this._ToolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToolStripButtonReload.Image = ((System.Drawing.Image)(resources.GetObject("_ToolStripButtonReload.Image")));
            this._ToolStripButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToolStripButtonReload.Name = "_ToolStripButtonReload";
            this._ToolStripButtonReload.Size = new System.Drawing.Size(23, 22);
            this._ToolStripButtonReload.Text = "Reload Map List";
            this._ToolStripButtonReload.Click += new System.EventHandler(this.ToolStripButtonReload_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 612);
            this.Controls.Add(this._PanelBase);
            this.Controls.Add(this._PanelDetails);
            this.Controls.Add(this._StatusStripMain);
            this.Controls.Add(this._ToolStripMaps);
            this.Controls.Add(this._ToolStripMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MapForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AutoMapper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapForm_FormClosing);
            this.Load += new System.EventHandler(this.GraphForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MapForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GraphForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GraphForm_KeyUp);
            this.Resize += new System.EventHandler(this.PanelBase_Resize);
            this._ToolStripMain.ResumeLayout(false);
            this._ToolStripMain.PerformLayout();
            this._PanelDetails.ResumeLayout(false);
            this._StatusStripMain.ResumeLayout(false);
            this._StatusStripMain.PerformLayout();
            this._PanelBase.ResumeLayout(false);
            this._ToolStripMaps.ResumeLayout(false);
            this._ToolStripMaps.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        public FlickerFreePanel _PanelMap;

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