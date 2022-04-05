using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class FormMain : Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this._Castbar = new GenieClient.ComponentRoundtime();
            this._StatusStripMain = new System.Windows.Forms.StatusStrip();
            this._ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this._ToolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this._MenuStripMain = new System.Windows.Forms.MenuStrip();
            this._FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ConnectToolStripMenuItemConnectDialog = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this._OpenUserDataDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this._AutoLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._OpenLogInEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this._AutoReconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._IgnoresEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripMenuItemTriggers = new System.Windows.Forms.ToolStripMenuItem();
            this._PluginsEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._AutoMapperEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._MuteSoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this._ToolStripMenuItemShowXML = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripMenuItemSpecialPaste = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._ConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._LoadProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._SaveProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this._SavePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._LayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._LoadSettingsOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._LoadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this._SaveSettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._SaveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._SaveSizedDefaultLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._BasicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._IconBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._DockTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._DockBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ShowScriptBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._DockTopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._DockBottomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._HealthBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._DockTopToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this._DockBottomToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this._MagicPanelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._StatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._WindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ScriptExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this._ListAllScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._TraceAllScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this._PauseAllScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ResumeAllScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this._AbortAllScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._AutoMapperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ShowWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._PluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._NoPluginsLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTestClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.autoUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpdatesOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ChangelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this._OpenGenieDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenGenieGithubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._OpenGenieDocsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elanthipediaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dRServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lichDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isharonsGenieSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._LabelSpellC = new System.Windows.Forms.Label();
            this._LabelRHC = new System.Windows.Forms.Label();
            this._LabelLHC = new System.Windows.Forms.Label();
            this._LabelSpell = new System.Windows.Forms.Label();
            this._LabelRH = new System.Windows.Forms.Label();
            this._LabelLH = new System.Windows.Forms.Label();
            this._LabelRT = new System.Windows.Forms.Label();
            this._PanelBars = new System.Windows.Forms.Panel();
            this._TableLayoutPanelBars = new System.Windows.Forms.TableLayoutPanel();
            this._ComponentBarsConc = new GenieClient.ComponentBars();
            this._ComponentBarsFatigue = new GenieClient.ComponentBars();
            this._ComponentBarsMana = new GenieClient.ComponentBars();
            this._ComponentBarsSpirit = new GenieClient.ComponentBars();
            this._ComponentBarsHealth = new GenieClient.ComponentBars();
            this._PanelStatus = new System.Windows.Forms.Panel();
            this._TableLayoutPanelFlow = new System.Windows.Forms.TableLayoutPanel();
            this._PanelFixed = new System.Windows.Forms.Panel();
            this._oRTControl = new GenieClient.ComponentRoundtime();
            this._IconBar = new GenieClient.ComponentIconBar();
            this._ToolStripButtons = new System.Windows.Forms.ToolStrip();
            this._ContextMenuStripButtons = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._TimerReconnect = new System.Windows.Forms.Timer(this.components);
            this._OpenFileDialogLayout = new System.Windows.Forms.OpenFileDialog();
            this._SaveFileDialogLayout = new System.Windows.Forms.SaveFileDialog();
            this._TimerBgWorker = new System.Windows.Forms.Timer(this.components);
            this._PanelInput = new System.Windows.Forms.Panel();
            this._TextBoxInput = new GenieClient.ComponentTextBox();
            this._OpenFileDialogProfile = new System.Windows.Forms.OpenFileDialog();
            this._StatusStripMain.SuspendLayout();
            this._MenuStripMain.SuspendLayout();
            this._PanelBars.SuspendLayout();
            this._TableLayoutPanelBars.SuspendLayout();
            this._PanelStatus.SuspendLayout();
            this._TableLayoutPanelFlow.SuspendLayout();
            this._PanelFixed.SuspendLayout();
            this._PanelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Castbar
            // 
            this._Castbar.BackColor = System.Drawing.Color.Black;
            this._Castbar.BackgroundColor = System.Drawing.Color.Black;
            this._Castbar.BackgroundColorRT = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(75)))));
            this._Castbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._Castbar.BorderColorRT = System.Drawing.Color.White;
            this._Castbar.ForegroundColor = System.Drawing.Color.Magenta;
            this._Castbar.IsConnected = false;
            this._Castbar.Location = new System.Drawing.Point(1172, 7);
            this._Castbar.Margin = new System.Windows.Forms.Padding(5);
            this._Castbar.Name = "_Castbar";
            this._Castbar.Size = new System.Drawing.Size(117, 30);
            this._Castbar.TabIndex = 1;
            // 
            // _StatusStripMain
            // 
            this._StatusStripMain.BackColor = System.Drawing.SystemColors.Control;
            this._StatusStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this._StatusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripStatusLabel1,
            this._ToolStripStatusLabel2,
            this._ToolStripStatusLabel3,
            this._ToolStripStatusLabel4,
            this._ToolStripStatusLabel5,
            this._ToolStripStatusLabel6,
            this._ToolStripStatusLabel7,
            this._ToolStripStatusLabel8,
            this._ToolStripStatusLabel9,
            this._ToolStripStatusLabel10});
            this._StatusStripMain.Location = new System.Drawing.Point(0, 744);
            this._StatusStripMain.Name = "_StatusStripMain";
            this._StatusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this._StatusStripMain.Size = new System.Drawing.Size(1449, 24);
            this._StatusStripMain.TabIndex = 2;
            // 
            // _ToolStripStatusLabel1
            // 
            this._ToolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel1.Name = "_ToolStripStatusLabel1";
            this._ToolStripStatusLabel1.Size = new System.Drawing.Size(1432, 19);
            this._ToolStripStatusLabel1.Spring = true;
            this._ToolStripStatusLabel1.Text = "Ready";
            this._ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _ToolStripStatusLabel2
            // 
            this._ToolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel2.Name = "_ToolStripStatusLabel2";
            this._ToolStripStatusLabel2.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel2.Visible = false;
            // 
            // _ToolStripStatusLabel3
            // 
            this._ToolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel3.Name = "_ToolStripStatusLabel3";
            this._ToolStripStatusLabel3.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel3.Visible = false;
            // 
            // _ToolStripStatusLabel4
            // 
            this._ToolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel4.Name = "_ToolStripStatusLabel4";
            this._ToolStripStatusLabel4.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel4.Visible = false;
            // 
            // _ToolStripStatusLabel5
            // 
            this._ToolStripStatusLabel5.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel5.Name = "_ToolStripStatusLabel5";
            this._ToolStripStatusLabel5.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel5.Visible = false;
            // 
            // _ToolStripStatusLabel6
            // 
            this._ToolStripStatusLabel6.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel6.Name = "_ToolStripStatusLabel6";
            this._ToolStripStatusLabel6.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel6.Visible = false;
            // 
            // _ToolStripStatusLabel7
            // 
            this._ToolStripStatusLabel7.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel7.Name = "_ToolStripStatusLabel7";
            this._ToolStripStatusLabel7.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel7.Visible = false;
            // 
            // _ToolStripStatusLabel8
            // 
            this._ToolStripStatusLabel8.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel8.Name = "_ToolStripStatusLabel8";
            this._ToolStripStatusLabel8.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel8.Visible = false;
            // 
            // _ToolStripStatusLabel9
            // 
            this._ToolStripStatusLabel9.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel9.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel9.Name = "_ToolStripStatusLabel9";
            this._ToolStripStatusLabel9.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel9.Visible = false;
            // 
            // _ToolStripStatusLabel10
            // 
            this._ToolStripStatusLabel10.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._ToolStripStatusLabel10.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._ToolStripStatusLabel10.Name = "_ToolStripStatusLabel10";
            this._ToolStripStatusLabel10.Size = new System.Drawing.Size(4, 19);
            this._ToolStripStatusLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ToolStripStatusLabel10.Visible = false;
            // 
            // _MenuStripMain
            // 
            this._MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._FileToolStripMenuItem,
            this._EditToolStripMenuItem,
            this._ProfileToolStripMenuItem,
            this._LayoutToolStripMenuItem,
            this._WindowToolStripMenuItem,
            this._ScriptToolStripMenuItem,
            this._AutoMapperToolStripMenuItem,
            this._PluginsToolStripMenuItem,
            this._HelpToolStripMenuItem});
            this._MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this._MenuStripMain.Name = "_MenuStripMain";
            this._MenuStripMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this._MenuStripMain.Size = new System.Drawing.Size(1449, 24);
            this._MenuStripMain.TabIndex = 1;
            this._MenuStripMain.Text = "MenuStrip1";
            // 
            // _FileToolStripMenuItem
            // 
            this._FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ConnectToolStripMenuItem,
            this._ConnectToolStripMenuItemConnectDialog,
            this._ToolStripSeparator7,
            this._OpenUserDataDirectoryToolStripMenuItem,
            this._ToolStripMenuItem4,
            this._AutoLogToolStripMenuItem,
            this._OpenLogInEditorToolStripMenuItem,
            this._ToolStripSeparator13,
            this._AutoReconnectToolStripMenuItem,
            this._IgnoresEnabledToolStripMenuItem,
            this._ToolStripMenuItemTriggers,
            this._PluginsEnabledToolStripMenuItem,
            this._AutoMapperEnabledToolStripMenuItem,
            this._MuteSoundsToolStripMenuItem,
            this._ToolStripSeparator8,
            this._ToolStripMenuItemShowXML,
            this._ToolStripMenuItem1,
            this._ToolStripSeparator1,
            this._ExitToolStripMenuItem});
            this._FileToolStripMenuItem.Name = "_FileToolStripMenuItem";
            this._FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this._FileToolStripMenuItem.Text = "&File";
            // 
            // _ConnectToolStripMenuItem
            // 
            this._ConnectToolStripMenuItem.Name = "_ConnectToolStripMenuItem";
            this._ConnectToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._ConnectToolStripMenuItem.Text = "&Connect...";
            this._ConnectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // _ConnectToolStripMenuItemConnectDialog
            // 
            this._ConnectToolStripMenuItemConnectDialog.Name = "_ConnectToolStripMenuItemConnectDialog";
            this._ConnectToolStripMenuItemConnectDialog.Size = new System.Drawing.Size(216, 22);
            this._ConnectToolStripMenuItemConnectDialog.Text = "Connect &Using Profile...";
            this._ConnectToolStripMenuItemConnectDialog.Click += new System.EventHandler(this.ConnectToolStripMenuItemConnectDialog_Click);
            // 
            // _ToolStripSeparator7
            // 
            this._ToolStripSeparator7.Name = "_ToolStripSeparator7";
            this._ToolStripSeparator7.Size = new System.Drawing.Size(213, 6);
            // 
            // _OpenUserDataDirectoryToolStripMenuItem
            // 
            this._OpenUserDataDirectoryToolStripMenuItem.Name = "_OpenUserDataDirectoryToolStripMenuItem";
            this._OpenUserDataDirectoryToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._OpenUserDataDirectoryToolStripMenuItem.Text = "Open &User Data Directory...";
            this._OpenUserDataDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenUserDataDirectoryToolStripMenuItem_Click);
            // 
            // _ToolStripMenuItem4
            // 
            this._ToolStripMenuItem4.Name = "_ToolStripMenuItem4";
            this._ToolStripMenuItem4.Size = new System.Drawing.Size(213, 6);
            // 
            // _AutoLogToolStripMenuItem
            // 
            this._AutoLogToolStripMenuItem.Checked = true;
            this._AutoLogToolStripMenuItem.CheckOnClick = true;
            this._AutoLogToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._AutoLogToolStripMenuItem.Name = "_AutoLogToolStripMenuItem";
            this._AutoLogToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._AutoLogToolStripMenuItem.Text = "&Auto Log";
            this._AutoLogToolStripMenuItem.Click += new System.EventHandler(this.AutoLogToolStripMenuItem_Click);
            // 
            // _OpenLogInEditorToolStripMenuItem
            // 
            this._OpenLogInEditorToolStripMenuItem.Name = "_OpenLogInEditorToolStripMenuItem";
            this._OpenLogInEditorToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._OpenLogInEditorToolStripMenuItem.Text = "&Open Log In Editor";
            this._OpenLogInEditorToolStripMenuItem.Click += new System.EventHandler(this.OpenLogInEditorToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator13
            // 
            this._ToolStripSeparator13.Name = "_ToolStripSeparator13";
            this._ToolStripSeparator13.Size = new System.Drawing.Size(213, 6);
            // 
            // _AutoReconnectToolStripMenuItem
            // 
            this._AutoReconnectToolStripMenuItem.Checked = true;
            this._AutoReconnectToolStripMenuItem.CheckOnClick = true;
            this._AutoReconnectToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._AutoReconnectToolStripMenuItem.Name = "_AutoReconnectToolStripMenuItem";
            this._AutoReconnectToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._AutoReconnectToolStripMenuItem.Text = "Auto &Reconnect";
            this._AutoReconnectToolStripMenuItem.Click += new System.EventHandler(this.AutoReconnectToolStripMenuItem_Click);
            // 
            // _IgnoresEnabledToolStripMenuItem
            // 
            this._IgnoresEnabledToolStripMenuItem.Checked = true;
            this._IgnoresEnabledToolStripMenuItem.CheckOnClick = true;
            this._IgnoresEnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._IgnoresEnabledToolStripMenuItem.Name = "_IgnoresEnabledToolStripMenuItem";
            this._IgnoresEnabledToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._IgnoresEnabledToolStripMenuItem.Text = "&Ignores/Gags Enabled";
            this._IgnoresEnabledToolStripMenuItem.Click += new System.EventHandler(this.IgnoresEnabledToolStripMenuItem_Click);
            // 
            // _ToolStripMenuItemTriggers
            // 
            this._ToolStripMenuItemTriggers.Checked = true;
            this._ToolStripMenuItemTriggers.CheckOnClick = true;
            this._ToolStripMenuItemTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ToolStripMenuItemTriggers.Name = "_ToolStripMenuItemTriggers";
            this._ToolStripMenuItemTriggers.Size = new System.Drawing.Size(216, 22);
            this._ToolStripMenuItemTriggers.Text = "&Triggers Enabled";
            this._ToolStripMenuItemTriggers.Click += new System.EventHandler(this.ToolStripMenuItemTriggers_Click);
            // 
            // _PluginsEnabledToolStripMenuItem
            // 
            this._PluginsEnabledToolStripMenuItem.Checked = true;
            this._PluginsEnabledToolStripMenuItem.CheckOnClick = true;
            this._PluginsEnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._PluginsEnabledToolStripMenuItem.Name = "_PluginsEnabledToolStripMenuItem";
            this._PluginsEnabledToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._PluginsEnabledToolStripMenuItem.Text = "&Plugins Enabled";
            this._PluginsEnabledToolStripMenuItem.Click += new System.EventHandler(this.PluginsEnabledToolStripMenuItem_Click);
            // 
            // _AutoMapperEnabledToolStripMenuItem
            // 
            this._AutoMapperEnabledToolStripMenuItem.Checked = true;
            this._AutoMapperEnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._AutoMapperEnabledToolStripMenuItem.Name = "_AutoMapperEnabledToolStripMenuItem";
            this._AutoMapperEnabledToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._AutoMapperEnabledToolStripMenuItem.Text = "Auto&Mapper Enabled";
            this._AutoMapperEnabledToolStripMenuItem.Click += new System.EventHandler(this.AutoMapperEnabledToolStripMenuItem_Click);
            // 
            // _MuteSoundsToolStripMenuItem
            // 
            this._MuteSoundsToolStripMenuItem.CheckOnClick = true;
            this._MuteSoundsToolStripMenuItem.Name = "_MuteSoundsToolStripMenuItem";
            this._MuteSoundsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._MuteSoundsToolStripMenuItem.Text = "&Mute Sounds";
            this._MuteSoundsToolStripMenuItem.Click += new System.EventHandler(this.MuteSoundsToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator8
            // 
            this._ToolStripSeparator8.Name = "_ToolStripSeparator8";
            this._ToolStripSeparator8.Size = new System.Drawing.Size(213, 6);
            // 
            // _ToolStripMenuItemShowXML
            // 
            this._ToolStripMenuItemShowXML.CheckOnClick = true;
            this._ToolStripMenuItemShowXML.Name = "_ToolStripMenuItemShowXML";
            this._ToolStripMenuItemShowXML.Size = new System.Drawing.Size(216, 22);
            this._ToolStripMenuItemShowXML.Text = "Show &Raw Data";
            this._ToolStripMenuItemShowXML.Click += new System.EventHandler(this.ToolStripMenuItemShowXML_Click);
            // 
            // _ToolStripMenuItem1
            // 
            this._ToolStripMenuItem1.Name = "_ToolStripMenuItem1";
            this._ToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this._ToolStripMenuItem1.Text = "P&erformace Test Parse";
            this._ToolStripMenuItem1.Visible = false;
            this._ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // _ToolStripSeparator1
            // 
            this._ToolStripSeparator1.Name = "_ToolStripSeparator1";
            this._ToolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // _ExitToolStripMenuItem
            // 
            this._ExitToolStripMenuItem.Name = "_ExitToolStripMenuItem";
            this._ExitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._ExitToolStripMenuItem.Text = "E&xit";
            this._ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // _EditToolStripMenuItem
            // 
            this._EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripMenuItemSpecialPaste,
            this._ToolStripSeparator6,
            this._ConfigurationToolStripMenuItem});
            this._EditToolStripMenuItem.Name = "_EditToolStripMenuItem";
            this._EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this._EditToolStripMenuItem.Text = "&Edit";
            // 
            // _ToolStripMenuItemSpecialPaste
            // 
            this._ToolStripMenuItemSpecialPaste.Name = "_ToolStripMenuItemSpecialPaste";
            this._ToolStripMenuItemSpecialPaste.Size = new System.Drawing.Size(158, 22);
            this._ToolStripMenuItemSpecialPaste.Text = "Paste &Multi Line";
            this._ToolStripMenuItemSpecialPaste.Click += new System.EventHandler(this.ToolStripMenuItemSpecialPaste_Click);
            // 
            // _ToolStripSeparator6
            // 
            this._ToolStripSeparator6.Name = "_ToolStripSeparator6";
            this._ToolStripSeparator6.Size = new System.Drawing.Size(155, 6);
            // 
            // _ConfigurationToolStripMenuItem
            // 
            this._ConfigurationToolStripMenuItem.Name = "_ConfigurationToolStripMenuItem";
            this._ConfigurationToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this._ConfigurationToolStripMenuItem.Text = "&Configuration...";
            this._ConfigurationToolStripMenuItem.Click += new System.EventHandler(this.ConfigurationToolStripMenuItem_Click);
            // 
            // _ProfileToolStripMenuItem
            // 
            this._ProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._LoadProfileToolStripMenuItem,
            this._SaveProfileToolStripMenuItem,
            this._ToolStripMenuItem2,
            this._SavePasswordToolStripMenuItem});
            this._ProfileToolStripMenuItem.Name = "_ProfileToolStripMenuItem";
            this._ProfileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this._ProfileToolStripMenuItem.Text = "&Profile";
            // 
            // _LoadProfileToolStripMenuItem
            // 
            this._LoadProfileToolStripMenuItem.Name = "_LoadProfileToolStripMenuItem";
            this._LoadProfileToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._LoadProfileToolStripMenuItem.Text = "&Load Profile...";
            this._LoadProfileToolStripMenuItem.Click += new System.EventHandler(this.LoadProfileToolStripMenuItem_Click);
            // 
            // _SaveProfileToolStripMenuItem
            // 
            this._SaveProfileToolStripMenuItem.Name = "_SaveProfileToolStripMenuItem";
            this._SaveProfileToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._SaveProfileToolStripMenuItem.Text = "&Save Profile";
            this._SaveProfileToolStripMenuItem.Click += new System.EventHandler(this.SaveProfileToolStripMenuItem_Click);
            // 
            // _ToolStripMenuItem2
            // 
            this._ToolStripMenuItem2.Name = "_ToolStripMenuItem2";
            this._ToolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // _SavePasswordToolStripMenuItem
            // 
            this._SavePasswordToolStripMenuItem.CheckOnClick = true;
            this._SavePasswordToolStripMenuItem.Name = "_SavePasswordToolStripMenuItem";
            this._SavePasswordToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this._SavePasswordToolStripMenuItem.Text = "Include &Password In Profile";
            this._SavePasswordToolStripMenuItem.Click += new System.EventHandler(this.SavePasswordToolStripMenuItem_Click);
            // 
            // _LayoutToolStripMenuItem
            // 
            this._LayoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._LoadSettingsOpenToolStripMenuItem,
            this._LoadSettingsToolStripMenuItem,
            this._ToolStripSeparator12,
            this._SaveSettingsToolStripMenuItem1,
            this._SaveSettingsToolStripMenuItem,
            this._SaveSizedDefaultLayoutToolStripMenuItem,
            this._ToolStripSeparator5,
            this._BasicToolStripMenuItem,
            this._ToolStripSeparator4,
            this._IconBarToolStripMenuItem,
            this._ShowScriptBarToolStripMenuItem,
            this._HealthBarToolStripMenuItem,
            this._MagicPanelsToolStripMenuItem,
            this._StatusBarToolStripMenuItem});
            this._LayoutToolStripMenuItem.Name = "_LayoutToolStripMenuItem";
            this._LayoutToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this._LayoutToolStripMenuItem.Text = "&Layout";
            // 
            // _LoadSettingsOpenToolStripMenuItem
            // 
            this._LoadSettingsOpenToolStripMenuItem.Name = "_LoadSettingsOpenToolStripMenuItem";
            this._LoadSettingsOpenToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._LoadSettingsOpenToolStripMenuItem.Text = "Load Layout...";
            this._LoadSettingsOpenToolStripMenuItem.Click += new System.EventHandler(this.LoadSettingsOpenToolStripMenuItem_Click);
            // 
            // _LoadSettingsToolStripMenuItem
            // 
            this._LoadSettingsToolStripMenuItem.Name = "_LoadSettingsToolStripMenuItem";
            this._LoadSettingsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._LoadSettingsToolStripMenuItem.Text = "Load Default Layout";
            this._LoadSettingsToolStripMenuItem.Click += new System.EventHandler(this.LoadSettingsToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator12
            // 
            this._ToolStripSeparator12.Name = "_ToolStripSeparator12";
            this._ToolStripSeparator12.Size = new System.Drawing.Size(205, 6);
            // 
            // _SaveSettingsToolStripMenuItem1
            // 
            this._SaveSettingsToolStripMenuItem1.Name = "_SaveSettingsToolStripMenuItem1";
            this._SaveSettingsToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this._SaveSettingsToolStripMenuItem1.Text = "Save Layout As...";
            this._SaveSettingsToolStripMenuItem1.Click += new System.EventHandler(this.SaveSettingsToolStripMenuItem1_Click);
            // 
            // _SaveSettingsToolStripMenuItem
            // 
            this._SaveSettingsToolStripMenuItem.Name = "_SaveSettingsToolStripMenuItem";
            this._SaveSettingsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._SaveSettingsToolStripMenuItem.Text = "Save Default Layout";
            this._SaveSettingsToolStripMenuItem.Click += new System.EventHandler(this.SaveSettingsToolStripMenuItem_Click);
            // 
            // _SaveSizedDefaultLayoutToolStripMenuItem
            // 
            this._SaveSizedDefaultLayoutToolStripMenuItem.Name = "_SaveSizedDefaultLayoutToolStripMenuItem";
            this._SaveSizedDefaultLayoutToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._SaveSizedDefaultLayoutToolStripMenuItem.Text = "Save Sized Default Layout";
            this._SaveSizedDefaultLayoutToolStripMenuItem.Click += new System.EventHandler(this.SaveSizedDefaultLayoutToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator5
            // 
            this._ToolStripSeparator5.Name = "_ToolStripSeparator5";
            this._ToolStripSeparator5.Size = new System.Drawing.Size(205, 6);
            // 
            // _BasicToolStripMenuItem
            // 
            this._BasicToolStripMenuItem.Name = "_BasicToolStripMenuItem";
            this._BasicToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._BasicToolStripMenuItem.Text = "Basic Layout";
            this._BasicToolStripMenuItem.Click += new System.EventHandler(this.BasicToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator4
            // 
            this._ToolStripSeparator4.Name = "_ToolStripSeparator4";
            this._ToolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // _IconBarToolStripMenuItem
            // 
            this._IconBarToolStripMenuItem.Checked = true;
            this._IconBarToolStripMenuItem.CheckOnClick = true;
            this._IconBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._IconBarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._DockTopToolStripMenuItem,
            this._DockBottomToolStripMenuItem});
            this._IconBarToolStripMenuItem.Name = "_IconBarToolStripMenuItem";
            this._IconBarToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._IconBarToolStripMenuItem.Text = "Icon Bar";
            this._IconBarToolStripMenuItem.Click += new System.EventHandler(this.IconBarToolStripMenuItem_Click);
            // 
            // _DockTopToolStripMenuItem
            // 
            this._DockTopToolStripMenuItem.Name = "_DockTopToolStripMenuItem";
            this._DockTopToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this._DockTopToolStripMenuItem.Text = "Dock Top";
            this._DockTopToolStripMenuItem.Click += new System.EventHandler(this.DockTopToolStripMenuItem_Click);
            // 
            // _DockBottomToolStripMenuItem
            // 
            this._DockBottomToolStripMenuItem.Checked = true;
            this._DockBottomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._DockBottomToolStripMenuItem.Name = "_DockBottomToolStripMenuItem";
            this._DockBottomToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this._DockBottomToolStripMenuItem.Text = "Dock Bottom";
            this._DockBottomToolStripMenuItem.Click += new System.EventHandler(this.DockBottomToolStripMenuItem_Click);
            // 
            // _ShowScriptBarToolStripMenuItem
            // 
            this._ShowScriptBarToolStripMenuItem.Checked = true;
            this._ShowScriptBarToolStripMenuItem.CheckOnClick = true;
            this._ShowScriptBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ShowScriptBarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._DockTopToolStripMenuItem1,
            this._DockBottomToolStripMenuItem1});
            this._ShowScriptBarToolStripMenuItem.Name = "_ShowScriptBarToolStripMenuItem";
            this._ShowScriptBarToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._ShowScriptBarToolStripMenuItem.Text = "Script Bar";
            this._ShowScriptBarToolStripMenuItem.Click += new System.EventHandler(this.ShowScriptBarToolStripMenuItem_Click);
            // 
            // _DockTopToolStripMenuItem1
            // 
            this._DockTopToolStripMenuItem1.Name = "_DockTopToolStripMenuItem1";
            this._DockTopToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this._DockTopToolStripMenuItem1.Text = "Dock Top";
            this._DockTopToolStripMenuItem1.Click += new System.EventHandler(this.DockTopToolStripMenuItem1_Click);
            // 
            // _DockBottomToolStripMenuItem1
            // 
            this._DockBottomToolStripMenuItem1.Checked = true;
            this._DockBottomToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this._DockBottomToolStripMenuItem1.Name = "_DockBottomToolStripMenuItem1";
            this._DockBottomToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this._DockBottomToolStripMenuItem1.Text = "Dock Bottom";
            this._DockBottomToolStripMenuItem1.Click += new System.EventHandler(this.DockBottomToolStripMenuItem1_Click);
            // 
            // _HealthBarToolStripMenuItem
            // 
            this._HealthBarToolStripMenuItem.Checked = true;
            this._HealthBarToolStripMenuItem.CheckOnClick = true;
            this._HealthBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._HealthBarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._DockTopToolStripMenuItem2,
            this._DockBottomToolStripMenuItem2});
            this._HealthBarToolStripMenuItem.Name = "_HealthBarToolStripMenuItem";
            this._HealthBarToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._HealthBarToolStripMenuItem.Text = "Health Bar";
            this._HealthBarToolStripMenuItem.Click += new System.EventHandler(this.HealthBarToolStripMenuItem_Click);
            // 
            // _DockTopToolStripMenuItem2
            // 
            this._DockTopToolStripMenuItem2.Name = "_DockTopToolStripMenuItem2";
            this._DockTopToolStripMenuItem2.Size = new System.Drawing.Size(144, 22);
            this._DockTopToolStripMenuItem2.Text = "Dock Top";
            this._DockTopToolStripMenuItem2.Click += new System.EventHandler(this.DockTopToolStripMenuItem2_Click);
            // 
            // _DockBottomToolStripMenuItem2
            // 
            this._DockBottomToolStripMenuItem2.Checked = true;
            this._DockBottomToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this._DockBottomToolStripMenuItem2.Name = "_DockBottomToolStripMenuItem2";
            this._DockBottomToolStripMenuItem2.Size = new System.Drawing.Size(144, 22);
            this._DockBottomToolStripMenuItem2.Text = "Dock Bottom";
            this._DockBottomToolStripMenuItem2.Click += new System.EventHandler(this.DockBottomToolStripMenuItem2_Click);
            // 
            // _MagicPanelsToolStripMenuItem
            // 
            this._MagicPanelsToolStripMenuItem.Checked = true;
            this._MagicPanelsToolStripMenuItem.CheckOnClick = true;
            this._MagicPanelsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._MagicPanelsToolStripMenuItem.Name = "_MagicPanelsToolStripMenuItem";
            this._MagicPanelsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._MagicPanelsToolStripMenuItem.Text = "Magic Panels";
            this._MagicPanelsToolStripMenuItem.Click += new System.EventHandler(this.MagicPanelsToolStripMenuItem_Click);
            // 
            // _StatusBarToolStripMenuItem
            // 
            this._StatusBarToolStripMenuItem.Checked = true;
            this._StatusBarToolStripMenuItem.CheckOnClick = true;
            this._StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this._StatusBarToolStripMenuItem.Name = "_StatusBarToolStripMenuItem";
            this._StatusBarToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._StatusBarToolStripMenuItem.Text = "Status Bar";
            this._StatusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // _WindowToolStripMenuItem
            // 
            this._WindowToolStripMenuItem.Name = "_WindowToolStripMenuItem";
            this._WindowToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this._WindowToolStripMenuItem.Text = "&Windows";
            // 
            // _ScriptToolStripMenuItem
            // 
            this._ScriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ScriptExplorerToolStripMenuItem,
            this._ToolStripSeparator11,
            this._ListAllScriptsToolStripMenuItem,
            this._TraceAllScriptsToolStripMenuItem,
            this._ToolStripSeparator9,
            this._PauseAllScriptsToolStripMenuItem,
            this._ResumeAllScriptsToolStripMenuItem,
            this._ToolStripMenuItem3,
            this._AbortAllScriptsToolStripMenuItem});
            this._ScriptToolStripMenuItem.Name = "_ScriptToolStripMenuItem";
            this._ScriptToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this._ScriptToolStripMenuItem.Text = "&Script";
            // 
            // _ScriptExplorerToolStripMenuItem
            // 
            this._ScriptExplorerToolStripMenuItem.Name = "_ScriptExplorerToolStripMenuItem";
            this._ScriptExplorerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._ScriptExplorerToolStripMenuItem.Text = "Script &Explorer...";
            this._ScriptExplorerToolStripMenuItem.Click += new System.EventHandler(this.ScriptExplorerToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator11
            // 
            this._ToolStripSeparator11.Name = "_ToolStripSeparator11";
            this._ToolStripSeparator11.Size = new System.Drawing.Size(174, 6);
            // 
            // _ListAllScriptsToolStripMenuItem
            // 
            this._ListAllScriptsToolStripMenuItem.Name = "_ListAllScriptsToolStripMenuItem";
            this._ListAllScriptsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._ListAllScriptsToolStripMenuItem.Text = "&Show Active Scripts";
            this._ListAllScriptsToolStripMenuItem.Click += new System.EventHandler(this.ListAllScriptsToolStripMenuItem_Click);
            // 
            // _TraceAllScriptsToolStripMenuItem
            // 
            this._TraceAllScriptsToolStripMenuItem.Name = "_TraceAllScriptsToolStripMenuItem";
            this._TraceAllScriptsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._TraceAllScriptsToolStripMenuItem.Text = "&Trace Active Scripts";
            this._TraceAllScriptsToolStripMenuItem.Click += new System.EventHandler(this.TraceAllScriptsToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator9
            // 
            this._ToolStripSeparator9.Name = "_ToolStripSeparator9";
            this._ToolStripSeparator9.Size = new System.Drawing.Size(174, 6);
            // 
            // _PauseAllScriptsToolStripMenuItem
            // 
            this._PauseAllScriptsToolStripMenuItem.Name = "_PauseAllScriptsToolStripMenuItem";
            this._PauseAllScriptsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._PauseAllScriptsToolStripMenuItem.Text = "&Pause All Scripts";
            this._PauseAllScriptsToolStripMenuItem.Click += new System.EventHandler(this.PauseAllScriptsToolStripMenuItem_Click);
            // 
            // _ResumeAllScriptsToolStripMenuItem
            // 
            this._ResumeAllScriptsToolStripMenuItem.Name = "_ResumeAllScriptsToolStripMenuItem";
            this._ResumeAllScriptsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._ResumeAllScriptsToolStripMenuItem.Text = "&Resume All Scripts";
            this._ResumeAllScriptsToolStripMenuItem.Click += new System.EventHandler(this.ResumeAllScriptsToolStripMenuItem_Click);
            // 
            // _ToolStripMenuItem3
            // 
            this._ToolStripMenuItem3.Name = "_ToolStripMenuItem3";
            this._ToolStripMenuItem3.Size = new System.Drawing.Size(174, 6);
            // 
            // _AbortAllScriptsToolStripMenuItem
            // 
            this._AbortAllScriptsToolStripMenuItem.Name = "_AbortAllScriptsToolStripMenuItem";
            this._AbortAllScriptsToolStripMenuItem.ShortcutKeyDisplayString = "";
            this._AbortAllScriptsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._AbortAllScriptsToolStripMenuItem.Text = "&Abort All Scripts";
            this._AbortAllScriptsToolStripMenuItem.Click += new System.EventHandler(this.AbortAllScriptsToolStripMenuItem_Click);
            // 
            // _AutoMapperToolStripMenuItem
            // 
            this._AutoMapperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ShowWindowToolStripMenuItem,
            this.updateMapsToolStripMenuItem});
            this._AutoMapperToolStripMenuItem.Name = "_AutoMapperToolStripMenuItem";
            this._AutoMapperToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this._AutoMapperToolStripMenuItem.Text = "&AutoMapper";
            // 
            // _ShowWindowToolStripMenuItem
            // 
            this._ShowWindowToolStripMenuItem.Name = "_ShowWindowToolStripMenuItem";
            this._ShowWindowToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this._ShowWindowToolStripMenuItem.Text = "&Show Window";
            this._ShowWindowToolStripMenuItem.Click += new System.EventHandler(this.ShowWindowToolStripMenuItem_Click);
            // 
            // updateMapsToolStripMenuItem
            // 
            this.updateMapsToolStripMenuItem.Name = "updateMapsToolStripMenuItem";
            this.updateMapsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.updateMapsToolStripMenuItem.Text = "&Update Maps";
            this.updateMapsToolStripMenuItem.Click += new System.EventHandler(this.updateMapsToolStripMenuItem_Click);
            // 
            // _PluginsToolStripMenuItem
            // 
            this._PluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._NoPluginsLoadedToolStripMenuItem,
            this.updatePluginsToolStripMenuItem});
            this._PluginsToolStripMenuItem.Name = "_PluginsToolStripMenuItem";
            this._PluginsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this._PluginsToolStripMenuItem.Text = "Pl&ugins";
            // 
            // _NoPluginsLoadedToolStripMenuItem
            // 
            this._NoPluginsLoadedToolStripMenuItem.Name = "_NoPluginsLoadedToolStripMenuItem";
            this._NoPluginsLoadedToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this._NoPluginsLoadedToolStripMenuItem.Text = "No plugins loaded";
            // 
            // updatePluginsToolStripMenuItem
            // 
            this.updatePluginsToolStripMenuItem.Name = "updatePluginsToolStripMenuItem";
            this.updatePluginsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.updatePluginsToolStripMenuItem.Text = "&Update Plugins";
            this.updatePluginsToolStripMenuItem.Click += new System.EventHandler(this.updatePluginsToolStripMenuItem_Click);
            // 
            // _HelpToolStripMenuItem
            // 
            this._HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.forceUpdateToolStripMenuItem,
            this.loadTestClientToolStripMenuItem,
            this._ToolStripSeparator3,
            this.autoUpdateToolStripMenuItem,
            this.checkUpdatesOnStartupToolStripMenuItem,
            this._ChangelogToolStripMenuItem,
            this._ToolStripSeparator10,
            this._OpenGenieDiscordToolStripMenuItem,
            this.OpenGenieGithubToolStripMenuItem,
            this._OpenGenieDocsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1});
            this._HelpToolStripMenuItem.Name = "_HelpToolStripMenuItem";
            this._HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this._HelpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For &Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // forceUpdateToolStripMenuItem
            // 
            this.forceUpdateToolStripMenuItem.Name = "forceUpdateToolStripMenuItem";
            this.forceUpdateToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.forceUpdateToolStripMenuItem.Text = "&Force Update";
            this.forceUpdateToolStripMenuItem.Click += new System.EventHandler(this.forceUpdateToolStripMenuItem_Click);
            // 
            // loadTestClientToolStripMenuItem
            // 
            this.loadTestClientToolStripMenuItem.Name = "loadTestClientToolStripMenuItem";
            this.loadTestClientToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.loadTestClientToolStripMenuItem.Text = "Load Test Client";
            this.loadTestClientToolStripMenuItem.Click += new System.EventHandler(this.loadTestClientToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator3
            // 
            this._ToolStripSeparator3.Name = "_ToolStripSeparator3";
            this._ToolStripSeparator3.Size = new System.Drawing.Size(208, 6);
            // 
            // autoUpdateToolStripMenuItem
            // 
            this.autoUpdateToolStripMenuItem.Name = "autoUpdateToolStripMenuItem";
            this.autoUpdateToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.autoUpdateToolStripMenuItem.Text = "&AutoUpdate";
            this.autoUpdateToolStripMenuItem.Click += new System.EventHandler(this.autoUpdateToolStripMenuItem_Click);
            // 
            // checkUpdatesOnStartupToolStripMenuItem
            // 
            this.checkUpdatesOnStartupToolStripMenuItem.Checked = true;
            this.checkUpdatesOnStartupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUpdatesOnStartupToolStripMenuItem.Name = "checkUpdatesOnStartupToolStripMenuItem";
            this.checkUpdatesOnStartupToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.checkUpdatesOnStartupToolStripMenuItem.Text = "&Check Updates on Startup";
            this.checkUpdatesOnStartupToolStripMenuItem.Click += new System.EventHandler(this.checkUpdatesOnStartupToolStripMenuItem_Click);
            // 
            // _ChangelogToolStripMenuItem
            // 
            this._ChangelogToolStripMenuItem.Name = "_ChangelogToolStripMenuItem";
            this._ChangelogToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this._ChangelogToolStripMenuItem.Text = "&Latest Release Page";
            this._ChangelogToolStripMenuItem.Click += new System.EventHandler(this.ChangelogToolStripMenuItem_Click);
            // 
            // _ToolStripSeparator10
            // 
            this._ToolStripSeparator10.Name = "_ToolStripSeparator10";
            this._ToolStripSeparator10.Size = new System.Drawing.Size(208, 6);
            // 
            // _OpenGenieDiscordToolStripMenuItem
            // 
            this._OpenGenieDiscordToolStripMenuItem.Name = "_OpenGenieDiscordToolStripMenuItem";
            this._OpenGenieDiscordToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this._OpenGenieDiscordToolStripMenuItem.Text = "&Discord";
            this._OpenGenieDiscordToolStripMenuItem.Click += new System.EventHandler(this.OpenGenieDiscordToolStripMenuItem_Click);
            // 
            // OpenGenieGithubToolStripMenuItem
            // 
            this.OpenGenieGithubToolStripMenuItem.Name = "OpenGenieGithubToolStripMenuItem";
            this.OpenGenieGithubToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.OpenGenieGithubToolStripMenuItem.Text = "GitHub";
            this.OpenGenieGithubToolStripMenuItem.Click += new System.EventHandler(this.OpenGenieGithubToolStripMenuItem_Click);
            // 
            // _OpenGenieDocsToolStripMenuItem
            // 
            this._OpenGenieDocsToolStripMenuItem.Name = "_OpenGenieDocsToolStripMenuItem";
            this._OpenGenieDocsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this._OpenGenieDocsToolStripMenuItem.Text = "&Wiki";
            this._OpenGenieDocsToolStripMenuItem.Click += new System.EventHandler(this.OpenGenieWikiToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playnetToolStripMenuItem,
            this.elanthipediaToolStripMenuItem1,
            this.dRServiceToolStripMenuItem,
            this.lichDiscordToolStripMenuItem,
            this.isharonsGenieSettingsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItem1.Text = "Community Links";
            // 
            // playnetToolStripMenuItem
            // 
            this.playnetToolStripMenuItem.Name = "playnetToolStripMenuItem";
            this.playnetToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.playnetToolStripMenuItem.Text = "Play.net";
            this.playnetToolStripMenuItem.Click += new System.EventHandler(this.playnetToolStripMenuItem_Click);
            // 
            // elanthipediaToolStripMenuItem1
            // 
            this.elanthipediaToolStripMenuItem1.Name = "elanthipediaToolStripMenuItem1";
            this.elanthipediaToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.elanthipediaToolStripMenuItem1.Text = "Elanthipedia";
            this.elanthipediaToolStripMenuItem1.Click += new System.EventHandler(this.elanthipediaToolStripMenuItem1_Click);
            // 
            // dRServiceToolStripMenuItem
            // 
            this.dRServiceToolStripMenuItem.Name = "dRServiceToolStripMenuItem";
            this.dRServiceToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.dRServiceToolStripMenuItem.Text = "DR Service";
            this.dRServiceToolStripMenuItem.Click += new System.EventHandler(this.dRServiceToolStripMenuItem_Click);
            // 
            // lichDiscordToolStripMenuItem
            // 
            this.lichDiscordToolStripMenuItem.Name = "lichDiscordToolStripMenuItem";
            this.lichDiscordToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.lichDiscordToolStripMenuItem.Text = "Lich Discord";
            this.lichDiscordToolStripMenuItem.Click += new System.EventHandler(this.lichDiscordToolStripMenuItem_Click);
            // 
            // isharonsGenieSettingsToolStripMenuItem
            // 
            this.isharonsGenieSettingsToolStripMenuItem.Name = "isharonsGenieSettingsToolStripMenuItem";
            this.isharonsGenieSettingsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.isharonsGenieSettingsToolStripMenuItem.Text = "Isharon\'s Genie Settings";
            this.isharonsGenieSettingsToolStripMenuItem.Click += new System.EventHandler(this.isharonsGenieSettingsToolStripMenuItem_Click);
            // 
            // _LabelSpellC
            // 
            this._LabelSpellC.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LabelSpellC.ForeColor = System.Drawing.Color.White;
            this._LabelSpellC.Location = new System.Drawing.Point(925, 0);
            this._LabelSpellC.Margin = new System.Windows.Forms.Padding(0);
            this._LabelSpellC.Name = "_LabelSpellC";
            this._LabelSpellC.Size = new System.Drawing.Size(242, 43);
            this._LabelSpellC.TabIndex = 12;
            this._LabelSpellC.Text = "None";
            this._LabelSpellC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _LabelRHC
            // 
            this._LabelRHC.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LabelRHC.ForeColor = System.Drawing.Color.White;
            this._LabelRHC.Location = new System.Drawing.Point(673, 0);
            this._LabelRHC.Margin = new System.Windows.Forms.Padding(0);
            this._LabelRHC.Name = "_LabelRHC";
            this._LabelRHC.Size = new System.Drawing.Size(240, 43);
            this._LabelRHC.TabIndex = 11;
            this._LabelRHC.Text = "Empty";
            this._LabelRHC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _LabelLHC
            // 
            this._LabelLHC.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LabelLHC.ForeColor = System.Drawing.Color.White;
            this._LabelLHC.Location = new System.Drawing.Point(420, 0);
            this._LabelLHC.Margin = new System.Windows.Forms.Padding(0);
            this._LabelLHC.Name = "_LabelLHC";
            this._LabelLHC.Size = new System.Drawing.Size(241, 43);
            this._LabelLHC.TabIndex = 10;
            this._LabelLHC.Text = "Empty";
            this._LabelLHC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _LabelSpell
            // 
            this._LabelSpell.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LabelSpell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._LabelSpell.ForeColor = System.Drawing.Color.DimGray;
            this._LabelSpell.Location = new System.Drawing.Point(913, 0);
            this._LabelSpell.Margin = new System.Windows.Forms.Padding(0);
            this._LabelSpell.Name = "_LabelSpell";
            this._LabelSpell.Size = new System.Drawing.Size(12, 43);
            this._LabelSpell.TabIndex = 9;
            this._LabelSpell.Text = "S";
            this._LabelSpell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _LabelRH
            // 
            this._LabelRH.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LabelRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._LabelRH.ForeColor = System.Drawing.Color.DimGray;
            this._LabelRH.Location = new System.Drawing.Point(661, 0);
            this._LabelRH.Margin = new System.Windows.Forms.Padding(0);
            this._LabelRH.Name = "_LabelRH";
            this._LabelRH.Size = new System.Drawing.Size(12, 43);
            this._LabelRH.TabIndex = 8;
            this._LabelRH.Text = "R";
            this._LabelRH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _LabelLH
            // 
            this._LabelLH.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LabelLH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._LabelLH.ForeColor = System.Drawing.Color.DimGray;
            this._LabelLH.Location = new System.Drawing.Point(408, 0);
            this._LabelLH.Margin = new System.Windows.Forms.Padding(0);
            this._LabelLH.Name = "_LabelLH";
            this._LabelLH.Size = new System.Drawing.Size(12, 43);
            this._LabelLH.TabIndex = 7;
            this._LabelLH.Text = "L";
            this._LabelLH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _LabelRT
            // 
            this._LabelRT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._LabelRT.ForeColor = System.Drawing.Color.DimGray;
            this._LabelRT.Location = new System.Drawing.Point(1, 0);
            this._LabelRT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._LabelRT.Name = "_LabelRT";
            this._LabelRT.Size = new System.Drawing.Size(12, 37);
            this._LabelRT.TabIndex = 6;
            this._LabelRT.Text = "RT";
            this._LabelRT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _PanelBars
            // 
            this._PanelBars.BackColor = System.Drawing.Color.Black;
            this._PanelBars.Controls.Add(this._TableLayoutPanelBars);
            this._PanelBars.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PanelBars.Location = new System.Drawing.Point(0, 724);
            this._PanelBars.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._PanelBars.Name = "_PanelBars";
            this._PanelBars.Size = new System.Drawing.Size(1449, 20);
            this._PanelBars.TabIndex = 10;
            // 
            // _TableLayoutPanelBars
            // 
            this._TableLayoutPanelBars.ColumnCount = 5;
            this._TableLayoutPanelBars.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._TableLayoutPanelBars.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._TableLayoutPanelBars.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._TableLayoutPanelBars.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._TableLayoutPanelBars.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._TableLayoutPanelBars.Controls.Add(this._ComponentBarsConc, 1, 0);
            this._TableLayoutPanelBars.Controls.Add(this._ComponentBarsFatigue, 2, 0);
            this._TableLayoutPanelBars.Controls.Add(this._ComponentBarsMana, 0, 0);
            this._TableLayoutPanelBars.Controls.Add(this._ComponentBarsSpirit, 3, 0);
            this._TableLayoutPanelBars.Controls.Add(this._ComponentBarsHealth, 0, 0);
            this._TableLayoutPanelBars.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TableLayoutPanelBars.Location = new System.Drawing.Point(0, 0);
            this._TableLayoutPanelBars.Margin = new System.Windows.Forms.Padding(0);
            this._TableLayoutPanelBars.Name = "_TableLayoutPanelBars";
            this._TableLayoutPanelBars.RowCount = 1;
            this._TableLayoutPanelBars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._TableLayoutPanelBars.Size = new System.Drawing.Size(1449, 20);
            this._TableLayoutPanelBars.TabIndex = 0;
            // 
            // _ComponentBarsConc
            // 
            this._ComponentBarsConc.BackColor = System.Drawing.Color.Black;
            this._ComponentBarsConc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._ComponentBarsConc.BarText = "Concentration";
            this._ComponentBarsConc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._ComponentBarsConc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ComponentBarsConc.ForegroundColor = System.Drawing.Color.Teal;
            this._ComponentBarsConc.IsConnected = false;
            this._ComponentBarsConc.Location = new System.Drawing.Point(578, 0);
            this._ComponentBarsConc.Margin = new System.Windows.Forms.Padding(0);
            this._ComponentBarsConc.Name = "_ComponentBarsConc";
            this._ComponentBarsConc.Size = new System.Drawing.Size(289, 20);
            this._ComponentBarsConc.TabIndex = 20;
            this._ComponentBarsConc.Value = 100;
            // 
            // _ComponentBarsFatigue
            // 
            this._ComponentBarsFatigue.BackColor = System.Drawing.Color.Black;
            this._ComponentBarsFatigue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this._ComponentBarsFatigue.BarText = "Stamina";
            this._ComponentBarsFatigue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this._ComponentBarsFatigue.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ComponentBarsFatigue.ForegroundColor = System.Drawing.Color.Green;
            this._ComponentBarsFatigue.IsConnected = false;
            this._ComponentBarsFatigue.Location = new System.Drawing.Point(867, 0);
            this._ComponentBarsFatigue.Margin = new System.Windows.Forms.Padding(0);
            this._ComponentBarsFatigue.Name = "_ComponentBarsFatigue";
            this._ComponentBarsFatigue.Size = new System.Drawing.Size(289, 20);
            this._ComponentBarsFatigue.TabIndex = 17;
            this._ComponentBarsFatigue.Value = 100;
            // 
            // _ComponentBarsMana
            // 
            this._ComponentBarsMana.BackColor = System.Drawing.Color.Black;
            this._ComponentBarsMana.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this._ComponentBarsMana.BarText = "Mana";
            this._ComponentBarsMana.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this._ComponentBarsMana.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ComponentBarsMana.ForegroundColor = System.Drawing.Color.Navy;
            this._ComponentBarsMana.IsConnected = false;
            this._ComponentBarsMana.Location = new System.Drawing.Point(289, 0);
            this._ComponentBarsMana.Margin = new System.Windows.Forms.Padding(0);
            this._ComponentBarsMana.Name = "_ComponentBarsMana";
            this._ComponentBarsMana.Size = new System.Drawing.Size(289, 20);
            this._ComponentBarsMana.TabIndex = 19;
            this._ComponentBarsMana.Value = 100;
            // 
            // _ComponentBarsSpirit
            // 
            this._ComponentBarsSpirit.BackColor = System.Drawing.Color.Black;
            this._ComponentBarsSpirit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this._ComponentBarsSpirit.BarText = "Spirit";
            this._ComponentBarsSpirit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this._ComponentBarsSpirit.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ComponentBarsSpirit.ForegroundColor = System.Drawing.Color.Purple;
            this._ComponentBarsSpirit.IsConnected = false;
            this._ComponentBarsSpirit.Location = new System.Drawing.Point(1156, 0);
            this._ComponentBarsSpirit.Margin = new System.Windows.Forms.Padding(0);
            this._ComponentBarsSpirit.Name = "_ComponentBarsSpirit";
            this._ComponentBarsSpirit.Size = new System.Drawing.Size(293, 20);
            this._ComponentBarsSpirit.TabIndex = 18;
            this._ComponentBarsSpirit.Value = 100;
            // 
            // _ComponentBarsHealth
            // 
            this._ComponentBarsHealth.BackColor = System.Drawing.Color.Black;
            this._ComponentBarsHealth.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._ComponentBarsHealth.BarText = "Health";
            this._ComponentBarsHealth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._ComponentBarsHealth.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ComponentBarsHealth.ForegroundColor = System.Drawing.Color.Maroon;
            this._ComponentBarsHealth.IsConnected = false;
            this._ComponentBarsHealth.Location = new System.Drawing.Point(0, 0);
            this._ComponentBarsHealth.Margin = new System.Windows.Forms.Padding(0);
            this._ComponentBarsHealth.Name = "_ComponentBarsHealth";
            this._ComponentBarsHealth.Size = new System.Drawing.Size(289, 20);
            this._ComponentBarsHealth.TabIndex = 0;
            this._ComponentBarsHealth.Value = 100;
            // 
            // _PanelStatus
            // 
            this._PanelStatus.BackColor = System.Drawing.Color.Black;
            this._PanelStatus.Controls.Add(this._Castbar);
            this._PanelStatus.Controls.Add(this._TableLayoutPanelFlow);
            this._PanelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PanelStatus.Location = new System.Drawing.Point(0, 658);
            this._PanelStatus.Margin = new System.Windows.Forms.Padding(0);
            this._PanelStatus.Name = "_PanelStatus";
            this._PanelStatus.Size = new System.Drawing.Size(1449, 43);
            this._PanelStatus.TabIndex = 12;
            this._PanelStatus.Visible = false;
            // 
            // _TableLayoutPanelFlow
            // 
            this._TableLayoutPanelFlow.BackColor = System.Drawing.Color.Transparent;
            this._TableLayoutPanelFlow.ColumnCount = 7;
            this._TableLayoutPanelFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 408F));
            this._TableLayoutPanelFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this._TableLayoutPanelFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._TableLayoutPanelFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this._TableLayoutPanelFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._TableLayoutPanelFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this._TableLayoutPanelFlow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._TableLayoutPanelFlow.Controls.Add(this._LabelSpellC, 6, 0);
            this._TableLayoutPanelFlow.Controls.Add(this._PanelFixed, 0, 0);
            this._TableLayoutPanelFlow.Controls.Add(this._LabelSpell, 5, 0);
            this._TableLayoutPanelFlow.Controls.Add(this._LabelRHC, 4, 0);
            this._TableLayoutPanelFlow.Controls.Add(this._LabelLH, 1, 0);
            this._TableLayoutPanelFlow.Controls.Add(this._LabelLHC, 2, 0);
            this._TableLayoutPanelFlow.Controls.Add(this._LabelRH, 3, 0);
            this._TableLayoutPanelFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TableLayoutPanelFlow.Location = new System.Drawing.Point(0, 0);
            this._TableLayoutPanelFlow.Margin = new System.Windows.Forms.Padding(0);
            this._TableLayoutPanelFlow.MaximumSize = new System.Drawing.Size(1167, 115);
            this._TableLayoutPanelFlow.Name = "_TableLayoutPanelFlow";
            this._TableLayoutPanelFlow.RowCount = 1;
            this._TableLayoutPanelFlow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._TableLayoutPanelFlow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._TableLayoutPanelFlow.Size = new System.Drawing.Size(1167, 43);
            this._TableLayoutPanelFlow.TabIndex = 0;
            // 
            // _PanelFixed
            // 
            this._PanelFixed.BackColor = System.Drawing.Color.Black;
            this._PanelFixed.Controls.Add(this._oRTControl);
            this._PanelFixed.Controls.Add(this._IconBar);
            this._PanelFixed.Controls.Add(this._LabelRT);
            this._PanelFixed.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelFixed.Location = new System.Drawing.Point(2, 2);
            this._PanelFixed.Margin = new System.Windows.Forms.Padding(2);
            this._PanelFixed.Name = "_PanelFixed";
            this._PanelFixed.Size = new System.Drawing.Size(404, 39);
            this._PanelFixed.TabIndex = 13;
            // 
            // _oRTControl
            // 
            this._oRTControl.BackColor = System.Drawing.Color.Black;
            this._oRTControl.BackgroundColor = System.Drawing.Color.Black;
            this._oRTControl.BackgroundColorRT = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(75)))));
            this._oRTControl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._oRTControl.BorderColorRT = System.Drawing.Color.White;
            this._oRTControl.ForegroundColor = System.Drawing.Color.MediumBlue;
            this._oRTControl.IsConnected = false;
            this._oRTControl.Location = new System.Drawing.Point(16, 3);
            this._oRTControl.Margin = new System.Windows.Forms.Padding(5);
            this._oRTControl.Name = "_oRTControl";
            this._oRTControl.Size = new System.Drawing.Size(117, 30);
            this._oRTControl.TabIndex = 0;
            // 
            // _IconBar
            // 
            this._IconBar.BackColor = System.Drawing.Color.Transparent;
            this._IconBar.Globals = null;
            this._IconBar.IsConnected = false;
            this._IconBar.Location = new System.Drawing.Point(136, 0);
            this._IconBar.Margin = new System.Windows.Forms.Padding(0);
            this._IconBar.Name = "_IconBar";
            this._IconBar.Size = new System.Drawing.Size(262, 37);
            this._IconBar.TabIndex = 0;
            // 
            // _ToolStripButtons
            // 
            this._ToolStripButtons.BackColor = System.Drawing.SystemColors.Control;
            this._ToolStripButtons.ContextMenuStrip = this._ContextMenuStripButtons;
            this._ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._ToolStripButtons.Location = new System.Drawing.Point(0, 24);
            this._ToolStripButtons.Name = "_ToolStripButtons";
            this._ToolStripButtons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this._ToolStripButtons.Size = new System.Drawing.Size(1449, 25);
            this._ToolStripButtons.TabIndex = 14;
            this._ToolStripButtons.VisibleChanged += new System.EventHandler(this.ToolStripButtons_VisibleChanged);
            // 
            // _ContextMenuStripButtons
            // 
            this._ContextMenuStripButtons.Name = "ContextMenuStripButtons";
            this._ContextMenuStripButtons.Size = new System.Drawing.Size(61, 4);
            // 
            // _TimerReconnect
            // 
            this._TimerReconnect.Enabled = true;
            this._TimerReconnect.Interval = 1000;
            this._TimerReconnect.Tick += new System.EventHandler(this.TimerReconnect_Tick);
            // 
            // _OpenFileDialogLayout
            // 
            this._OpenFileDialogLayout.DefaultExt = "layout";
            this._OpenFileDialogLayout.Filter = "Genie Layout|*.layout|All files|*.*";
            this._OpenFileDialogLayout.RestoreDirectory = true;
            this._OpenFileDialogLayout.Title = "Open Layout";
            // 
            // _SaveFileDialogLayout
            // 
            this._SaveFileDialogLayout.DefaultExt = "layout";
            this._SaveFileDialogLayout.Filter = "Genie Layout|*.layout|All files|*.*";
            this._SaveFileDialogLayout.RestoreDirectory = true;
            this._SaveFileDialogLayout.Title = "Save Layout";
            // 
            // _TimerBgWorker
            // 
            this._TimerBgWorker.Interval = 10;
            this._TimerBgWorker.Tick += new System.EventHandler(this.TimerBgWorker_Tick);
            // 
            // _PanelInput
            // 
            this._PanelInput.BackColor = System.Drawing.Color.White;
            this._PanelInput.Controls.Add(this._TextBoxInput);
            this._PanelInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PanelInput.Location = new System.Drawing.Point(0, 701);
            this._PanelInput.Margin = new System.Windows.Forms.Padding(0);
            this._PanelInput.Name = "_PanelInput";
            this._PanelInput.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this._PanelInput.Size = new System.Drawing.Size(1449, 23);
            this._PanelInput.TabIndex = 0;
            // 
            // _TextBoxInput
            // 
            this._TextBoxInput.AcceptsTab = true;
            this._TextBoxInput.BackColor = System.Drawing.Color.White;
            this._TextBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._TextBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TextBoxInput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._TextBoxInput.HideSelection = false;
            this._TextBoxInput.KeepInput = false;
            this._TextBoxInput.Location = new System.Drawing.Point(4, 2);
            this._TextBoxInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._TextBoxInput.Multiline = true;
            this._TextBoxInput.Name = "_TextBoxInput";
            this._TextBoxInput.Size = new System.Drawing.Size(1445, 21);
            this._TextBoxInput.TabIndex = 0;
            this._TextBoxInput.WordWrap = false;
            this._TextBoxInput.SendText += new GenieClient.ComponentTextBox.SendTextEventHandler(this.TextBoxInput_SendText);
            this._TextBoxInput.PageUp += new GenieClient.ComponentTextBox.PageUpEventHandler(this.TextBoxInput_PageUp);
            this._TextBoxInput.PageDown += new GenieClient.ComponentTextBox.PageDownEventHandler(this.TextBoxInput_PageDown);
            this._TextBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxInput_KeyDown);
            // 
            // _OpenFileDialogProfile
            // 
            this._OpenFileDialogProfile.DefaultExt = "layout";
            this._OpenFileDialogProfile.Filter = "Genie Profile|*.xml|All files|*.*";
            this._OpenFileDialogProfile.RestoreDirectory = true;
            this._OpenFileDialogProfile.Title = "Open Profile";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1449, 768);
            this.Controls.Add(this._PanelStatus);
            this.Controls.Add(this._PanelInput);
            this.Controls.Add(this._PanelBars);
            this.Controls.Add(this._ToolStripButtons);
            this.Controls.Add(this._StatusStripMain);
            this.Controls.Add(this._MenuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this._MenuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormMain";
            this.Text = "Genie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResizeEnd += new System.EventHandler(this.FormMain_SizeChange);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.Resize += new System.EventHandler(this.FormMain_SizeChange);
            this._StatusStripMain.ResumeLayout(false);
            this._StatusStripMain.PerformLayout();
            this._MenuStripMain.ResumeLayout(false);
            this._MenuStripMain.PerformLayout();
            this._PanelBars.ResumeLayout(false);
            this._TableLayoutPanelBars.ResumeLayout(false);
            this._PanelStatus.ResumeLayout(false);
            this._TableLayoutPanelFlow.ResumeLayout(false);
            this._PanelFixed.ResumeLayout(false);
            this._PanelInput.ResumeLayout(false);
            this._PanelInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComponentTextBox _TextBoxInput;

        internal ComponentTextBox TextBoxInput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxInput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxInput != null)
                {
                    _TextBoxInput.KeyDown -= TextBoxInput_KeyDown;
                    _TextBoxInput.SendText -= TextBoxInput_SendText;
                    _TextBoxInput.PageUp -= TextBoxInput_PageUp;
                    _TextBoxInput.PageDown -= TextBoxInput_PageDown;
                }

                _TextBoxInput = value;
                if (_TextBoxInput != null)
                {
                    _TextBoxInput.KeyDown += TextBoxInput_KeyDown;
                    _TextBoxInput.SendText += TextBoxInput_SendText;
                    _TextBoxInput.PageUp += TextBoxInput_PageUp;
                    _TextBoxInput.PageDown += TextBoxInput_PageDown;
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

        private MenuStrip _MenuStripMain;

        internal MenuStrip MenuStripMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MenuStripMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MenuStripMain != null)
                {
                }

                _MenuStripMain = value;
                if (_MenuStripMain != null)
                {
                }
            }
        }

        private ToolStripMenuItem _FileToolStripMenuItem;

        internal ToolStripMenuItem FileToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FileToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FileToolStripMenuItem != null)
                {
                }

                _FileToolStripMenuItem = value;
                if (_FileToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _EditToolStripMenuItem;

        internal ToolStripMenuItem EditToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _EditToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_EditToolStripMenuItem != null)
                {
                }

                _EditToolStripMenuItem = value;
                if (_EditToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ScriptToolStripMenuItem;

        internal ToolStripMenuItem ScriptToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ScriptToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ScriptToolStripMenuItem != null)
                {
                }

                _ScriptToolStripMenuItem = value;
                if (_ScriptToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _WindowToolStripMenuItem;

        internal ToolStripMenuItem WindowToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _WindowToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_WindowToolStripMenuItem != null)
                {
                }

                _WindowToolStripMenuItem = value;
                if (_WindowToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _HelpToolStripMenuItem;

        internal ToolStripMenuItem HelpToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HelpToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HelpToolStripMenuItem != null)
                {
                }

                _HelpToolStripMenuItem = value;
                if (_HelpToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ConnectToolStripMenuItem;

        internal ToolStripMenuItem ConnectToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ConnectToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ConnectToolStripMenuItem != null)
                {
                    _ConnectToolStripMenuItem.Click -= ConnectToolStripMenuItem_Click;
                }

                _ConnectToolStripMenuItem = value;
                if (_ConnectToolStripMenuItem != null)
                {
                    _ConnectToolStripMenuItem.Click += ConnectToolStripMenuItem_Click;
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

        private ToolStripMenuItem _ExitToolStripMenuItem;

        internal ToolStripMenuItem ExitToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ExitToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ExitToolStripMenuItem != null)
                {
                    _ExitToolStripMenuItem.Click -= ExitToolStripMenuItem_Click;
                }

                _ExitToolStripMenuItem = value;
                if (_ExitToolStripMenuItem != null)
                {
                    _ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ConfigurationToolStripMenuItem;

        internal ToolStripMenuItem ConfigurationToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ConfigurationToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ConfigurationToolStripMenuItem != null)
                {
                    _ConfigurationToolStripMenuItem.Click -= ConfigurationToolStripMenuItem_Click;
                }

                _ConfigurationToolStripMenuItem = value;
                if (_ConfigurationToolStripMenuItem != null)
                {
                    _ConfigurationToolStripMenuItem.Click += ConfigurationToolStripMenuItem_Click;
                }
            }
        }
        
        internal ComponentRoundtime Castbar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Castbar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Castbar != null)
                {
                }

                _Castbar = value;
                if (_Castbar != null)
                {
                }

            }
            }
        private ComponentRoundtime _oRTControl;

        internal ComponentRoundtime oRTControl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _oRTControl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_oRTControl != null)
                {
                }

                _oRTControl = value;
                if (_oRTControl != null)
                {
                }
            }
        }

                private ToolStripMenuItem _AbortAllScriptsToolStripMenuItem;

        internal ToolStripMenuItem AbortAllScriptsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AbortAllScriptsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AbortAllScriptsToolStripMenuItem != null)
                {
                    _AbortAllScriptsToolStripMenuItem.Click -= AbortAllScriptsToolStripMenuItem_Click;
                }

                _AbortAllScriptsToolStripMenuItem = value;
                if (_AbortAllScriptsToolStripMenuItem != null)
                {
                    _AbortAllScriptsToolStripMenuItem.Click += AbortAllScriptsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _PauseAllScriptsToolStripMenuItem;

        internal ToolStripMenuItem PauseAllScriptsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PauseAllScriptsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PauseAllScriptsToolStripMenuItem != null)
                {
                    _PauseAllScriptsToolStripMenuItem.Click -= PauseAllScriptsToolStripMenuItem_Click;
                }

                _PauseAllScriptsToolStripMenuItem = value;
                if (_PauseAllScriptsToolStripMenuItem != null)
                {
                    _PauseAllScriptsToolStripMenuItem.Click += PauseAllScriptsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ResumeAllScriptsToolStripMenuItem;

        internal ToolStripMenuItem ResumeAllScriptsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ResumeAllScriptsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ResumeAllScriptsToolStripMenuItem != null)
                {
                    _ResumeAllScriptsToolStripMenuItem.Click -= ResumeAllScriptsToolStripMenuItem_Click;
                }

                _ResumeAllScriptsToolStripMenuItem = value;
                if (_ResumeAllScriptsToolStripMenuItem != null)
                {
                    _ResumeAllScriptsToolStripMenuItem.Click += ResumeAllScriptsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripMenuItem3;

        internal ToolStripSeparator ToolStripMenuItem3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem3 != null)
                {
                }

                _ToolStripMenuItem3 = value;
                if (_ToolStripMenuItem3 != null)
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

        private ToolStripMenuItem _ChangelogToolStripMenuItem;

        internal ToolStripMenuItem ChangelogToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ChangelogToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ChangelogToolStripMenuItem != null)
                {
                    _ChangelogToolStripMenuItem.Click -= ChangelogToolStripMenuItem_Click;
                }

                _ChangelogToolStripMenuItem = value;
                if (_ChangelogToolStripMenuItem != null)
                {
                    _ChangelogToolStripMenuItem.Click += ChangelogToolStripMenuItem_Click;
                }
            }
        }

        private Label _LabelRT;

        internal Label LabelRT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelRT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelRT != null)
                {
                }

                _LabelRT = value;
                if (_LabelRT != null)
                {
                }
            }
        }

        private Label _LabelLHC;

        internal Label LabelLHC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelLHC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelLHC != null)
                {
                }

                _LabelLHC = value;
                if (_LabelLHC != null)
                {
                }
            }
        }

        private Label _LabelSpell;

        internal Label LabelSpell
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelSpell;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelSpell != null)
                {
                }

                _LabelSpell = value;
                if (_LabelSpell != null)
                {
                }
            }
        }

        private Label _LabelRH;

        internal Label LabelRH
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelRH;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelRH != null)
                {
                }

                _LabelRH = value;
                if (_LabelRH != null)
                {
                }
            }
        }

        private Label _LabelLH;

        internal Label LabelLH
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelLH;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelLH != null)
                {
                }

                _LabelLH = value;
                if (_LabelLH != null)
                {
                }
            }
        }

        private Label _LabelSpellC;

        internal Label LabelSpellC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelSpellC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelSpellC != null)
                {
                }

                _LabelSpellC = value;
                if (_LabelSpellC != null)
                {
                }
            }
        }

        private Label _LabelRHC;

        internal Label LabelRHC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelRHC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelRHC != null)
                {
                }

                _LabelRHC = value;
                if (_LabelRHC != null)
                {
                }
            }
        }

        private Panel _PanelBars;

        internal Panel PanelBars
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelBars;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelBars != null)
                {
                }

                _PanelBars = value;
                if (_PanelBars != null)
                {
                }
            }
        }

        private TableLayoutPanel _TableLayoutPanelBars;

        internal TableLayoutPanel TableLayoutPanelBars
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TableLayoutPanelBars;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TableLayoutPanelBars != null)
                {
                }

                _TableLayoutPanelBars = value;
                if (_TableLayoutPanelBars != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel1;

        internal ToolStripStatusLabel ToolStripStatusLabel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel1 != null)
                {
                }

                _ToolStripStatusLabel1 = value;
                if (_ToolStripStatusLabel1 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel2;

        internal ToolStripStatusLabel ToolStripStatusLabel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel2 != null)
                {
                }

                _ToolStripStatusLabel2 = value;
                if (_ToolStripStatusLabel2 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel3;

        internal ToolStripStatusLabel ToolStripStatusLabel3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel3 != null)
                {
                }

                _ToolStripStatusLabel3 = value;
                if (_ToolStripStatusLabel3 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel4;

        internal ToolStripStatusLabel ToolStripStatusLabel4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel4 != null)
                {
                }

                _ToolStripStatusLabel4 = value;
                if (_ToolStripStatusLabel4 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel5;

        internal ToolStripStatusLabel ToolStripStatusLabel5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel5 != null)
                {
                }

                _ToolStripStatusLabel5 = value;
                if (_ToolStripStatusLabel5 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel6;

        internal ToolStripStatusLabel ToolStripStatusLabel6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel6 != null)
                {
                }

                _ToolStripStatusLabel6 = value;
                if (_ToolStripStatusLabel6 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel7;

        internal ToolStripStatusLabel ToolStripStatusLabel7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel7 != null)
                {
                }

                _ToolStripStatusLabel7 = value;
                if (_ToolStripStatusLabel7 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel8;

        internal ToolStripStatusLabel ToolStripStatusLabel8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel8 != null)
                {
                }

                _ToolStripStatusLabel8 = value;
                if (_ToolStripStatusLabel8 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel9;

        internal ToolStripStatusLabel ToolStripStatusLabel9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel9 != null)
                {
                }

                _ToolStripStatusLabel9 = value;
                if (_ToolStripStatusLabel9 != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _ToolStripStatusLabel10;

        internal ToolStripStatusLabel ToolStripStatusLabel10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripStatusLabel10 != null)
                {
                }

                _ToolStripStatusLabel10 = value;
                if (_ToolStripStatusLabel10 != null)
                {
                }
            }
        }

        private ComponentIconBar _IconBar;

        internal ComponentIconBar IconBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _IconBar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_IconBar != null)
                {
                }

                _IconBar = value;
                if (_IconBar != null)
                {
                }
            }
        }

        private Panel _PanelStatus;

        internal Panel PanelStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelStatus != null)
                {
                }

                _PanelStatus = value;
                if (_PanelStatus != null)
                {
                }
            }
        }

        private TableLayoutPanel _TableLayoutPanelFlow;

        internal TableLayoutPanel TableLayoutPanelFlow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TableLayoutPanelFlow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TableLayoutPanelFlow != null)
                {
                }

                _TableLayoutPanelFlow = value;
                if (_TableLayoutPanelFlow != null)
                {
                }
            }
        }

        private Panel _PanelFixed;

        internal Panel PanelFixed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelFixed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelFixed != null)
                {
                }

                _PanelFixed = value;
                if (_PanelFixed != null)
                {
                }
            }
        }

        private ToolStrip _ToolStripButtons;

        internal ToolStrip ToolStripButtons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtons != null)
                {
                    _ToolStripButtons.VisibleChanged -= ToolStripButtons_VisibleChanged;
                }

                _ToolStripButtons = value;
                if (_ToolStripButtons != null)
                {
                    _ToolStripButtons.VisibleChanged += ToolStripButtons_VisibleChanged;
                }
            }
        }

        private ContextMenuStrip _ContextMenuStripButtons;

        internal ContextMenuStrip ContextMenuStripButtons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContextMenuStripButtons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContextMenuStripButtons != null)
                {
                }

                _ContextMenuStripButtons = value;
                if (_ContextMenuStripButtons != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItemSpecialPaste;

        internal ToolStripMenuItem ToolStripMenuItemSpecialPaste
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItemSpecialPaste;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItemSpecialPaste != null)
                {
                    _ToolStripMenuItemSpecialPaste.Click -= ToolStripMenuItemSpecialPaste_Click;
                }

                _ToolStripMenuItemSpecialPaste = value;
                if (_ToolStripMenuItemSpecialPaste != null)
                {
                    _ToolStripMenuItemSpecialPaste.Click += ToolStripMenuItemSpecialPaste_Click;
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

        private ToolStripMenuItem _ToolStripMenuItem1;

        internal ToolStripMenuItem ToolStripMenuItem1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem1 != null)
                {
                    _ToolStripMenuItem1.Click -= ToolStripMenuItem1_Click;
                }

                _ToolStripMenuItem1 = value;
                if (_ToolStripMenuItem1 != null)
                {
                    _ToolStripMenuItem1.Click += ToolStripMenuItem1_Click;
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

        private ToolStripMenuItem _ToolStripMenuItemTriggers;

        internal ToolStripMenuItem ToolStripMenuItemTriggers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItemTriggers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItemTriggers != null)
                {
                    _ToolStripMenuItemTriggers.Click -= ToolStripMenuItemTriggers_Click;
                }

                _ToolStripMenuItemTriggers = value;
                if (_ToolStripMenuItemTriggers != null)
                {
                    _ToolStripMenuItemTriggers.Click += ToolStripMenuItemTriggers_Click;
                }
            }
        }

        private ToolStripMenuItem _ToolStripMenuItemShowXML;

        internal ToolStripMenuItem ToolStripMenuItemShowXML
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItemShowXML;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItemShowXML != null)
                {
                    _ToolStripMenuItemShowXML.Click -= ToolStripMenuItemShowXML_Click;
                }

                _ToolStripMenuItemShowXML = value;
                if (_ToolStripMenuItemShowXML != null)
                {
                    _ToolStripMenuItemShowXML.Click += ToolStripMenuItemShowXML_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator8;

        internal ToolStripSeparator ToolStripSeparator8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator8 != null)
                {
                }

                _ToolStripSeparator8 = value;
                if (_ToolStripSeparator8 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _AutoReconnectToolStripMenuItem;

        internal ToolStripMenuItem AutoReconnectToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AutoReconnectToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AutoReconnectToolStripMenuItem != null)
                {
                    _AutoReconnectToolStripMenuItem.Click -= AutoReconnectToolStripMenuItem_Click;
                }

                _AutoReconnectToolStripMenuItem = value;
                if (_AutoReconnectToolStripMenuItem != null)
                {
                    _AutoReconnectToolStripMenuItem.Click += AutoReconnectToolStripMenuItem_Click;
                }
            }
        }

        private Timer _TimerReconnect;

        internal Timer TimerReconnect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TimerReconnect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TimerReconnect != null)
                {
                    _TimerReconnect.Tick -= TimerReconnect_Tick;
                }

                _TimerReconnect = value;
                if (_TimerReconnect != null)
                {
                    _TimerReconnect.Tick += TimerReconnect_Tick;
                }
            }
        }


        private ToolStripMenuItem _ListAllScriptsToolStripMenuItem;

        internal ToolStripMenuItem ListAllScriptsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ListAllScriptsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ListAllScriptsToolStripMenuItem != null)
                {
                    _ListAllScriptsToolStripMenuItem.Click -= ListAllScriptsToolStripMenuItem_Click;
                }

                _ListAllScriptsToolStripMenuItem = value;
                if (_ListAllScriptsToolStripMenuItem != null)
                {
                    _ListAllScriptsToolStripMenuItem.Click += ListAllScriptsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator9;

        internal ToolStripSeparator ToolStripSeparator9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator9 != null)
                {
                }

                _ToolStripSeparator9 = value;
                if (_ToolStripSeparator9 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _TraceAllScriptsToolStripMenuItem;

        internal ToolStripMenuItem TraceAllScriptsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TraceAllScriptsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TraceAllScriptsToolStripMenuItem != null)
                {
                    _TraceAllScriptsToolStripMenuItem.Click -= TraceAllScriptsToolStripMenuItem_Click;
                }

                _TraceAllScriptsToolStripMenuItem = value;
                if (_TraceAllScriptsToolStripMenuItem != null)
                {
                    _TraceAllScriptsToolStripMenuItem.Click += TraceAllScriptsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator10;

        internal ToolStripSeparator ToolStripSeparator10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator10 != null)
                {
                }

                _ToolStripSeparator10 = value;
                if (_ToolStripSeparator10 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _OpenGenieDocsToolStripMenuItem;

        internal ToolStripMenuItem OpenGenieDocsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpenGenieDocsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpenGenieDocsToolStripMenuItem != null)
                {
                    _OpenGenieDocsToolStripMenuItem.Click -= OpenGenieWikiToolStripMenuItem_Click;
                }

                _OpenGenieDocsToolStripMenuItem = value;
                if (_OpenGenieDocsToolStripMenuItem != null)
                {
                    _OpenGenieDocsToolStripMenuItem.Click += OpenGenieWikiToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _LayoutToolStripMenuItem;

        internal ToolStripMenuItem LayoutToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LayoutToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LayoutToolStripMenuItem != null)
                {
                }

                _LayoutToolStripMenuItem = value;
                if (_LayoutToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _BasicToolStripMenuItem;

        internal ToolStripMenuItem BasicToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BasicToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BasicToolStripMenuItem != null)
                {
                    _BasicToolStripMenuItem.Click -= BasicToolStripMenuItem_Click;
                }

                _BasicToolStripMenuItem = value;
                if (_BasicToolStripMenuItem != null)
                {
                    _BasicToolStripMenuItem.Click += BasicToolStripMenuItem_Click;
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

        private ToolStripMenuItem _IconBarToolStripMenuItem;

        internal ToolStripMenuItem IconBarToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _IconBarToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_IconBarToolStripMenuItem != null)
                {
                    _IconBarToolStripMenuItem.Click -= IconBarToolStripMenuItem_Click;
                }

                _IconBarToolStripMenuItem = value;
                if (_IconBarToolStripMenuItem != null)
                {
                    _IconBarToolStripMenuItem.Click += IconBarToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DockTopToolStripMenuItem;

        internal ToolStripMenuItem DockTopToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DockTopToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DockTopToolStripMenuItem != null)
                {
                    _DockTopToolStripMenuItem.Click -= DockTopToolStripMenuItem_Click;
                }

                _DockTopToolStripMenuItem = value;
                if (_DockTopToolStripMenuItem != null)
                {
                    _DockTopToolStripMenuItem.Click += DockTopToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DockBottomToolStripMenuItem;

        internal ToolStripMenuItem DockBottomToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DockBottomToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DockBottomToolStripMenuItem != null)
                {
                    _DockBottomToolStripMenuItem.Click -= DockBottomToolStripMenuItem_Click;
                }

                _DockBottomToolStripMenuItem = value;
                if (_DockBottomToolStripMenuItem != null)
                {
                    _DockBottomToolStripMenuItem.Click += DockBottomToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ShowScriptBarToolStripMenuItem;

        internal ToolStripMenuItem ShowScriptBarToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ShowScriptBarToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ShowScriptBarToolStripMenuItem != null)
                {
                    _ShowScriptBarToolStripMenuItem.Click -= ShowScriptBarToolStripMenuItem_Click;
                }

                _ShowScriptBarToolStripMenuItem = value;
                if (_ShowScriptBarToolStripMenuItem != null)
                {
                    _ShowScriptBarToolStripMenuItem.Click += ShowScriptBarToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DockTopToolStripMenuItem1;

        internal ToolStripMenuItem DockTopToolStripMenuItem1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DockTopToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DockTopToolStripMenuItem1 != null)
                {
                    _DockTopToolStripMenuItem1.Click -= DockTopToolStripMenuItem1_Click;
                }

                _DockTopToolStripMenuItem1 = value;
                if (_DockTopToolStripMenuItem1 != null)
                {
                    _DockTopToolStripMenuItem1.Click += DockTopToolStripMenuItem1_Click;
                }
            }
        }

        private ToolStripMenuItem _DockBottomToolStripMenuItem1;

        internal ToolStripMenuItem DockBottomToolStripMenuItem1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DockBottomToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DockBottomToolStripMenuItem1 != null)
                {
                    _DockBottomToolStripMenuItem1.Click -= DockBottomToolStripMenuItem1_Click;
                }

                _DockBottomToolStripMenuItem1 = value;
                if (_DockBottomToolStripMenuItem1 != null)
                {
                    _DockBottomToolStripMenuItem1.Click += DockBottomToolStripMenuItem1_Click;
                }
            }
        }

        private ToolStripMenuItem _HealthBarToolStripMenuItem;

        internal ToolStripMenuItem HealthBarToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HealthBarToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HealthBarToolStripMenuItem != null)
                {
                    _HealthBarToolStripMenuItem.Click -= HealthBarToolStripMenuItem_Click;
                }

                _HealthBarToolStripMenuItem = value;
                if (_HealthBarToolStripMenuItem != null)
                {
                    _HealthBarToolStripMenuItem.Click += HealthBarToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _DockTopToolStripMenuItem2;

        internal ToolStripMenuItem DockTopToolStripMenuItem2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DockTopToolStripMenuItem2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DockTopToolStripMenuItem2 != null)
                {
                    _DockTopToolStripMenuItem2.Click -= DockTopToolStripMenuItem2_Click;
                }

                _DockTopToolStripMenuItem2 = value;
                if (_DockTopToolStripMenuItem2 != null)
                {
                    _DockTopToolStripMenuItem2.Click += DockTopToolStripMenuItem2_Click;
                }
            }
        }

        private ToolStripMenuItem _DockBottomToolStripMenuItem2;

        internal ToolStripMenuItem DockBottomToolStripMenuItem2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DockBottomToolStripMenuItem2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DockBottomToolStripMenuItem2 != null)
                {
                    _DockBottomToolStripMenuItem2.Click -= DockBottomToolStripMenuItem2_Click;
                }

                _DockBottomToolStripMenuItem2 = value;
                if (_DockBottomToolStripMenuItem2 != null)
                {
                    _DockBottomToolStripMenuItem2.Click += DockBottomToolStripMenuItem2_Click;
                }
            }
        }

        private ToolStripMenuItem _StatusBarToolStripMenuItem;

        internal ToolStripMenuItem StatusBarToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StatusBarToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StatusBarToolStripMenuItem != null)
                {
                    _StatusBarToolStripMenuItem.Click -= StatusBarToolStripMenuItem_Click;
                }

                _StatusBarToolStripMenuItem = value;
                if (_StatusBarToolStripMenuItem != null)
                {
                    _StatusBarToolStripMenuItem.Click += StatusBarToolStripMenuItem_Click;
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

        private ToolStripMenuItem _LoadSettingsToolStripMenuItem;

        internal ToolStripMenuItem LoadSettingsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadSettingsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadSettingsToolStripMenuItem != null)
                {
                    _LoadSettingsToolStripMenuItem.Click -= LoadSettingsToolStripMenuItem_Click;
                }

                _LoadSettingsToolStripMenuItem = value;
                if (_LoadSettingsToolStripMenuItem != null)
                {
                    _LoadSettingsToolStripMenuItem.Click += LoadSettingsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _SaveSettingsToolStripMenuItem;

        internal ToolStripMenuItem SaveSettingsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveSettingsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveSettingsToolStripMenuItem != null)
                {
                    _SaveSettingsToolStripMenuItem.Click -= SaveSettingsToolStripMenuItem_Click;
                }

                _SaveSettingsToolStripMenuItem = value;
                if (_SaveSettingsToolStripMenuItem != null)
                {
                    _SaveSettingsToolStripMenuItem.Click += SaveSettingsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _MagicPanelsToolStripMenuItem;

        internal ToolStripMenuItem MagicPanelsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MagicPanelsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MagicPanelsToolStripMenuItem != null)
                {
                    _MagicPanelsToolStripMenuItem.Click -= MagicPanelsToolStripMenuItem_Click;
                }

                _MagicPanelsToolStripMenuItem = value;
                if (_MagicPanelsToolStripMenuItem != null)
                {
                    _MagicPanelsToolStripMenuItem.Click += MagicPanelsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ScriptExplorerToolStripMenuItem;

        internal ToolStripMenuItem ScriptExplorerToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ScriptExplorerToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ScriptExplorerToolStripMenuItem != null)
                {
                    _ScriptExplorerToolStripMenuItem.Click -= ScriptExplorerToolStripMenuItem_Click;
                }

                _ScriptExplorerToolStripMenuItem = value;
                if (_ScriptExplorerToolStripMenuItem != null)
                {
                    _ScriptExplorerToolStripMenuItem.Click += ScriptExplorerToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator11;

        internal ToolStripSeparator ToolStripSeparator11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator11 != null)
                {
                }

                _ToolStripSeparator11 = value;
                if (_ToolStripSeparator11 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _PluginsToolStripMenuItem;

        internal ToolStripMenuItem PluginsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PluginsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PluginsToolStripMenuItem != null)
                {
                }

                _PluginsToolStripMenuItem = value;
                if (_PluginsToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _NoPluginsLoadedToolStripMenuItem;

        internal ToolStripMenuItem NoPluginsLoadedToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NoPluginsLoadedToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NoPluginsLoadedToolStripMenuItem != null)
                {
                }

                _NoPluginsLoadedToolStripMenuItem = value;
                if (_NoPluginsLoadedToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _AutoLogToolStripMenuItem;

        internal ToolStripMenuItem AutoLogToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AutoLogToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AutoLogToolStripMenuItem != null)
                {
                    _AutoLogToolStripMenuItem.Click -= AutoLogToolStripMenuItem_Click;
                }

                _AutoLogToolStripMenuItem = value;
                if (_AutoLogToolStripMenuItem != null)
                {
                    _AutoLogToolStripMenuItem.Click += AutoLogToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _PluginsEnabledToolStripMenuItem;

        internal ToolStripMenuItem PluginsEnabledToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PluginsEnabledToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PluginsEnabledToolStripMenuItem != null)
                {
                    _PluginsEnabledToolStripMenuItem.Click -= PluginsEnabledToolStripMenuItem_Click;
                }

                _PluginsEnabledToolStripMenuItem = value;
                if (_PluginsEnabledToolStripMenuItem != null)
                {
                    _PluginsEnabledToolStripMenuItem.Click += PluginsEnabledToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _IgnoresEnabledToolStripMenuItem;

        internal ToolStripMenuItem IgnoresEnabledToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _IgnoresEnabledToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_IgnoresEnabledToolStripMenuItem != null)
                {
                    _IgnoresEnabledToolStripMenuItem.Click -= IgnoresEnabledToolStripMenuItem_Click;
                }

                _IgnoresEnabledToolStripMenuItem = value;
                if (_IgnoresEnabledToolStripMenuItem != null)
                {
                    _IgnoresEnabledToolStripMenuItem.Click += IgnoresEnabledToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator12;

        internal ToolStripSeparator ToolStripSeparator12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator12 != null)
                {
                }

                _ToolStripSeparator12 = value;
                if (_ToolStripSeparator12 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _LoadSettingsOpenToolStripMenuItem;

        internal ToolStripMenuItem LoadSettingsOpenToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadSettingsOpenToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadSettingsOpenToolStripMenuItem != null)
                {
                    _LoadSettingsOpenToolStripMenuItem.Click -= LoadSettingsOpenToolStripMenuItem_Click;
                }

                _LoadSettingsOpenToolStripMenuItem = value;
                if (_LoadSettingsOpenToolStripMenuItem != null)
                {
                    _LoadSettingsOpenToolStripMenuItem.Click += LoadSettingsOpenToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _SaveSettingsToolStripMenuItem1;

        internal ToolStripMenuItem SaveSettingsToolStripMenuItem1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveSettingsToolStripMenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveSettingsToolStripMenuItem1 != null)
                {
                    _SaveSettingsToolStripMenuItem1.Click -= SaveSettingsToolStripMenuItem1_Click;
                }

                _SaveSettingsToolStripMenuItem1 = value;
                if (_SaveSettingsToolStripMenuItem1 != null)
                {
                    _SaveSettingsToolStripMenuItem1.Click += SaveSettingsToolStripMenuItem1_Click;
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

        private ToolStripMenuItem _OpenLogInEditorToolStripMenuItem;

        internal ToolStripMenuItem OpenLogInEditorToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpenLogInEditorToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpenLogInEditorToolStripMenuItem != null)
                {
                    _OpenLogInEditorToolStripMenuItem.Click -= OpenLogInEditorToolStripMenuItem_Click;
                }

                _OpenLogInEditorToolStripMenuItem = value;
                if (_OpenLogInEditorToolStripMenuItem != null)
                {
                    _OpenLogInEditorToolStripMenuItem.Click += OpenLogInEditorToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator13;

        internal ToolStripSeparator ToolStripSeparator13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator13 != null)
                {
                }

                _ToolStripSeparator13 = value;
                if (_ToolStripSeparator13 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _MuteSoundsToolStripMenuItem;

        internal ToolStripMenuItem MuteSoundsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MuteSoundsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MuteSoundsToolStripMenuItem != null)
                {
                    _MuteSoundsToolStripMenuItem.Click -= MuteSoundsToolStripMenuItem_Click;
                }

                _MuteSoundsToolStripMenuItem = value;
                if (_MuteSoundsToolStripMenuItem != null)
                {
                    _MuteSoundsToolStripMenuItem.Click += MuteSoundsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _AutoMapperToolStripMenuItem;

        internal ToolStripMenuItem AutoMapperToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AutoMapperToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AutoMapperToolStripMenuItem != null)
                {
                }

                _AutoMapperToolStripMenuItem = value;
                if (_AutoMapperToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ShowWindowToolStripMenuItem;

        internal ToolStripMenuItem ShowWindowToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ShowWindowToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ShowWindowToolStripMenuItem != null)
                {
                    _ShowWindowToolStripMenuItem.Click -= ShowWindowToolStripMenuItem_Click;
                }

                _ShowWindowToolStripMenuItem = value;
                if (_ShowWindowToolStripMenuItem != null)
                {
                    _ShowWindowToolStripMenuItem.Click += ShowWindowToolStripMenuItem_Click;
                }
            }
        }

        private Timer _TimerBgWorker;

        internal Timer TimerBgWorker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TimerBgWorker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TimerBgWorker != null)
                {
                    _TimerBgWorker.Tick -= TimerBgWorker_Tick;
                }

                _TimerBgWorker = value;
                if (_TimerBgWorker != null)
                {
                    _TimerBgWorker.Tick += TimerBgWorker_Tick;
                }
            }
        }

        private ToolStripMenuItem _AutoMapperEnabledToolStripMenuItem;

        internal ToolStripMenuItem AutoMapperEnabledToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AutoMapperEnabledToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AutoMapperEnabledToolStripMenuItem != null)
                {
                    _AutoMapperEnabledToolStripMenuItem.Click -= AutoMapperEnabledToolStripMenuItem_Click;
                }

                _AutoMapperEnabledToolStripMenuItem = value;
                if (_AutoMapperEnabledToolStripMenuItem != null)
                {
                    _AutoMapperEnabledToolStripMenuItem.Click += AutoMapperEnabledToolStripMenuItem_Click;
                }
            }
        }

        private ComponentBars _ComponentBarsSpirit;

        internal ComponentBars ComponentBarsSpirit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComponentBarsSpirit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComponentBarsSpirit != null)
                {
                }

                _ComponentBarsSpirit = value;
                if (_ComponentBarsSpirit != null)
                {
                }
            }
        }

        private ComponentBars _ComponentBarsFatigue;

        internal ComponentBars ComponentBarsFatigue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComponentBarsFatigue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComponentBarsFatigue != null)
                {
                }

                _ComponentBarsFatigue = value;
                if (_ComponentBarsFatigue != null)
                {
                }
            }
        }

        private ComponentBars _ComponentBarsMana;

        internal ComponentBars ComponentBarsMana
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComponentBarsMana;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComponentBarsMana != null)
                {
                }

                _ComponentBarsMana = value;
                if (_ComponentBarsMana != null)
                {
                }
            }
        }

        private ComponentBars _ComponentBarsHealth;

        internal ComponentBars ComponentBarsHealth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComponentBarsHealth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComponentBarsHealth != null)
                {
                }

                _ComponentBarsHealth = value;
                if (_ComponentBarsHealth != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ConnectToolStripMenuItemConnectDialog;

        internal ToolStripMenuItem ConnectToolStripMenuItemConnectDialog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ConnectToolStripMenuItemConnectDialog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ConnectToolStripMenuItemConnectDialog != null)
                {
                    _ConnectToolStripMenuItemConnectDialog.Click -= ConnectToolStripMenuItemConnectDialog_Click;
                }

                _ConnectToolStripMenuItemConnectDialog = value;
                if (_ConnectToolStripMenuItemConnectDialog != null)
                {
                    _ConnectToolStripMenuItemConnectDialog.Click += ConnectToolStripMenuItemConnectDialog_Click;
                }
            }
        }

        private ComponentBars _ComponentBarsConc;

        internal ComponentBars ComponentBarsConc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ComponentBarsConc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ComponentBarsConc != null)
                {
                }

                _ComponentBarsConc = value;
                if (_ComponentBarsConc != null)
                {
                }
            }
        }

        private Panel _PanelInput;

        internal Panel PanelInput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelInput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelInput != null)
                {
                }

                _PanelInput = value;
                if (_PanelInput != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ProfileToolStripMenuItem;

        internal ToolStripMenuItem ProfileToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ProfileToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ProfileToolStripMenuItem != null)
                {
                }

                _ProfileToolStripMenuItem = value;
                if (_ProfileToolStripMenuItem != null)
                {
                }
            }
        }

        private ToolStripMenuItem _LoadProfileToolStripMenuItem;

        internal ToolStripMenuItem LoadProfileToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadProfileToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadProfileToolStripMenuItem != null)
                {
                    _LoadProfileToolStripMenuItem.Click -= LoadProfileToolStripMenuItem_Click;
                }

                _LoadProfileToolStripMenuItem = value;
                if (_LoadProfileToolStripMenuItem != null)
                {
                    _LoadProfileToolStripMenuItem.Click += LoadProfileToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _SaveProfileToolStripMenuItem;

        internal ToolStripMenuItem SaveProfileToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveProfileToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveProfileToolStripMenuItem != null)
                {
                    _SaveProfileToolStripMenuItem.Click -= SaveProfileToolStripMenuItem_Click;
                }

                _SaveProfileToolStripMenuItem = value;
                if (_SaveProfileToolStripMenuItem != null)
                {
                    _SaveProfileToolStripMenuItem.Click += SaveProfileToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripMenuItem2;

        internal ToolStripSeparator ToolStripMenuItem2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem2 != null)
                {
                }

                _ToolStripMenuItem2 = value;
                if (_ToolStripMenuItem2 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _SavePasswordToolStripMenuItem;

        internal ToolStripMenuItem SavePasswordToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SavePasswordToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SavePasswordToolStripMenuItem != null)
                {
                    _SavePasswordToolStripMenuItem.Click -= SavePasswordToolStripMenuItem_Click;
                }

                _SavePasswordToolStripMenuItem = value;
                if (_SavePasswordToolStripMenuItem != null)
                {
                    _SavePasswordToolStripMenuItem.Click += SavePasswordToolStripMenuItem_Click;
                }
            }
        }

        private OpenFileDialog _OpenFileDialogProfile;

        internal OpenFileDialog OpenFileDialogProfile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpenFileDialogProfile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpenFileDialogProfile != null)
                {
                }

                _OpenFileDialogProfile = value;
                if (_OpenFileDialogProfile != null)
                {
                }
            }
        }

        private ToolStripMenuItem _OpenUserDataDirectoryToolStripMenuItem;

        internal ToolStripMenuItem OpenUserDataDirectoryToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpenUserDataDirectoryToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpenUserDataDirectoryToolStripMenuItem != null)
                {
                    _OpenUserDataDirectoryToolStripMenuItem.Click -= OpenUserDataDirectoryToolStripMenuItem_Click;
                }

                _OpenUserDataDirectoryToolStripMenuItem = value;
                if (_OpenUserDataDirectoryToolStripMenuItem != null)
                {
                    _OpenUserDataDirectoryToolStripMenuItem.Click += OpenUserDataDirectoryToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripMenuItem4;

        internal ToolStripSeparator ToolStripMenuItem4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenuItem4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenuItem4 != null)
                {
                }

                _ToolStripMenuItem4 = value;
                if (_ToolStripMenuItem4 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _SaveSizedDefaultLayoutToolStripMenuItem;
        private ToolStripMenuItem OpenGenieGithubToolStripMenuItem;
        private ToolStripMenuItem _OpenGenieDiscordToolStripMenuItem;
        private ComponentRoundtime _Castbar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem playnetToolStripMenuItem;
        private ToolStripMenuItem elanthipediaToolStripMenuItem1;
        private ToolStripMenuItem dRServiceToolStripMenuItem;
        private ToolStripMenuItem lichDiscordToolStripMenuItem;
        private ToolStripMenuItem isharonsGenieSettingsToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripMenuItem forceUpdateToolStripMenuItem;
        private ToolStripMenuItem autoUpdateToolStripMenuItem;
        private ToolStripMenuItem checkUpdatesOnStartupToolStripMenuItem;
        private ToolStripMenuItem loadTestClientToolStripMenuItem;
        private ToolStripMenuItem updateMapsToolStripMenuItem;
        private ToolStripMenuItem updatePluginsToolStripMenuItem;

        internal ToolStripMenuItem SaveSizedDefaultLayoutToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaveSizedDefaultLayoutToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaveSizedDefaultLayoutToolStripMenuItem != null)
                {
                    _SaveSizedDefaultLayoutToolStripMenuItem.Click -= SaveSizedDefaultLayoutToolStripMenuItem_Click;
                }

                _SaveSizedDefaultLayoutToolStripMenuItem = value;
                if (_SaveSizedDefaultLayoutToolStripMenuItem != null)
                {
                    _SaveSizedDefaultLayoutToolStripMenuItem.Click += SaveSizedDefaultLayoutToolStripMenuItem_Click;
                }
            }
        }
    }
}