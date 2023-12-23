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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            _Castbar = new ComponentRoundtime();
            _StatusStripMain = new StatusStrip();
            _ToolStripStatusLabel1 = new ToolStripStatusLabel();
            _ToolStripStatusLabel2 = new ToolStripStatusLabel();
            _ToolStripStatusLabel3 = new ToolStripStatusLabel();
            _ToolStripStatusLabel4 = new ToolStripStatusLabel();
            _ToolStripStatusLabel5 = new ToolStripStatusLabel();
            _ToolStripStatusLabel6 = new ToolStripStatusLabel();
            _ToolStripStatusLabel7 = new ToolStripStatusLabel();
            _ToolStripStatusLabel8 = new ToolStripStatusLabel();
            _ToolStripStatusLabel9 = new ToolStripStatusLabel();
            _ToolStripStatusLabel10 = new ToolStripStatusLabel();
            _MenuStripMain = new MenuStrip();
            _FileToolStripMenuItem = new ToolStripMenuItem();
            _ConnectToolStripMenuItem = new ToolStripMenuItem();
            _ConnectToolStripMenuItemConnectDialog = new ToolStripMenuItem();
            _ToolStripSeparator7 = new ToolStripSeparator();
            _OpenUserDataDirectoryToolStripMenuItem = new ToolStripMenuItem();
            genieToolStripMenuItem = new ToolStripMenuItem();
            scriptsToolStripMenuItem = new ToolStripMenuItem();
            mapsToolStripMenuItem = new ToolStripMenuItem();
            pluginsToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            artToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripMenuItem4 = new ToolStripSeparator();
            _AutoLogToolStripMenuItem = new ToolStripMenuItem();
            _OpenLogInEditorToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator13 = new ToolStripSeparator();
            _AutoReconnectToolStripMenuItem = new ToolStripMenuItem();
            ClassicConnectToolStripMenuItem = new ToolStripMenuItem();
            _IgnoresEnabledToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripMenuItemTriggers = new ToolStripMenuItem();
            _PluginsEnabledToolStripMenuItem = new ToolStripMenuItem();
            _AutoMapperEnabledToolStripMenuItem = new ToolStripMenuItem();
            _ImagesEnabledToolStripMenuItem = new ToolStripMenuItem();
            _MuteSoundsToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator8 = new ToolStripSeparator();
            _ToolStripMenuItemShowXML = new ToolStripMenuItem();
            _ToolStripMenuItem1 = new ToolStripMenuItem();
            _ToolStripSeparator1 = new ToolStripSeparator();
            _ExitToolStripMenuItem = new ToolStripMenuItem();
            _EditToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripMenuItemSpecialPaste = new ToolStripMenuItem();
            _ToolStripSeparator6 = new ToolStripSeparator();
            _ConfigurationToolStripMenuItem = new ToolStripMenuItem();
            UpdateImagesToolStripMenuItem = new ToolStripMenuItem();
            _ProfileToolStripMenuItem = new ToolStripMenuItem();
            _LoadProfileToolStripMenuItem = new ToolStripMenuItem();
            _SaveProfileToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripMenuItem2 = new ToolStripSeparator();
            _SavePasswordToolStripMenuItem = new ToolStripMenuItem();
            _LayoutToolStripMenuItem = new ToolStripMenuItem();
            _LoadSettingsOpenToolStripMenuItem = new ToolStripMenuItem();
            _LoadSettingsToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator12 = new ToolStripSeparator();
            _SaveSettingsToolStripMenuItem1 = new ToolStripMenuItem();
            _SaveSettingsToolStripMenuItem = new ToolStripMenuItem();
            _SaveSizedDefaultLayoutToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator5 = new ToolStripSeparator();
            _BasicToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator4 = new ToolStripSeparator();
            _IconBarToolStripMenuItem = new ToolStripMenuItem();
            _DockTopToolStripMenuItem = new ToolStripMenuItem();
            _DockBottomToolStripMenuItem = new ToolStripMenuItem();
            _ShowScriptBarToolStripMenuItem = new ToolStripMenuItem();
            _DockTopToolStripMenuItem1 = new ToolStripMenuItem();
            _DockBottomToolStripMenuItem1 = new ToolStripMenuItem();
            _HealthBarToolStripMenuItem = new ToolStripMenuItem();
            _DockTopToolStripMenuItem2 = new ToolStripMenuItem();
            _DockBottomToolStripMenuItem2 = new ToolStripMenuItem();
            _MagicPanelsToolStripMenuItem = new ToolStripMenuItem();
            _StatusBarToolStripMenuItem = new ToolStripMenuItem();
            alignInputToGameWindowToolStripMenuItem = new ToolStripMenuItem();
            alwaysOnTopToolStripMenuItem = new ToolStripMenuItem();
            _WindowToolStripMenuItem = new ToolStripMenuItem();
            _ScriptToolStripMenuItem = new ToolStripMenuItem();
            _ScriptExplorerToolStripMenuItem = new ToolStripMenuItem();
            updateScriptsToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator11 = new ToolStripSeparator();
            _ListAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _TraceAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator9 = new ToolStripSeparator();
            _PauseAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _ResumeAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripMenuItem3 = new ToolStripSeparator();
            _AbortAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _AutoMapperToolStripMenuItem = new ToolStripMenuItem();
            _ShowWindowToolStripMenuItem = new ToolStripMenuItem();
            updateMapsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            _PluginsToolStripMenuItem = new ToolStripMenuItem();
            _NoPluginsLoadedToolStripMenuItem = new ToolStripMenuItem();
            updatePluginsToolStripMenuItem = new ToolStripMenuItem();
            _HelpToolStripMenuItem = new ToolStripMenuItem();
            checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            forceUpdateToolStripMenuItem = new ToolStripMenuItem();
            loadTestClientToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator3 = new ToolStripSeparator();
            autoUpdateToolStripMenuItem = new ToolStripMenuItem();
            autoUpdateLampToolStripMenuItem = new ToolStripMenuItem();
            checkUpdatesOnStartupToolStripMenuItem = new ToolStripMenuItem();
            _ChangelogToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripSeparator10 = new ToolStripSeparator();
            _OpenGenieDiscordToolStripMenuItem = new ToolStripMenuItem();
            OpenGenieGithubToolStripMenuItem = new ToolStripMenuItem();
            _OpenGenieDocsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem1 = new ToolStripMenuItem();
            playnetToolStripMenuItem = new ToolStripMenuItem();
            elanthipediaToolStripMenuItem1 = new ToolStripMenuItem();
            dRServiceToolStripMenuItem = new ToolStripMenuItem();
            lichDiscordToolStripMenuItem = new ToolStripMenuItem();
            isharonsGenieSettingsToolStripMenuItem = new ToolStripMenuItem();
            _LabelSpellC = new Label();
            _LabelRHC = new Label();
            _LabelLHC = new Label();
            _LabelSpell = new Label();
            _LabelRH = new Label();
            _LabelLH = new Label();
            _LabelRT = new Label();
            _PanelBars = new Panel();
            _TableLayoutPanelBars = new TableLayoutPanel();
            _ComponentBarsConc = new ComponentBars();
            _ComponentBarsFatigue = new ComponentBars();
            _ComponentBarsMana = new ComponentBars();
            _ComponentBarsSpirit = new ComponentBars();
            _ComponentBarsHealth = new ComponentBars();
            _PanelStatus = new Panel();
            _TableLayoutPanelFlow = new TableLayoutPanel();
            _PanelFixed = new Panel();
            _oRTControl = new ComponentRoundtime();
            _IconBar = new ComponentIconBar();
            _ToolStripButtons = new ToolStrip();
            _ContextMenuStripButtons = new ContextMenuStrip(components);
            _TimerReconnect = new Timer(components);
            _OpenFileDialogLayout = new OpenFileDialog();
            _SaveFileDialogLayout = new SaveFileDialog();
            _TimerBgWorker = new Timer(components);
            _PanelInput = new Panel();
            _TextBoxInput = new ComponentTextBox();
            _OpenFileDialogProfile = new OpenFileDialog();
            _StatusStripMain.SuspendLayout();
            _MenuStripMain.SuspendLayout();
            _PanelBars.SuspendLayout();
            _TableLayoutPanelBars.SuspendLayout();
            _PanelStatus.SuspendLayout();
            _TableLayoutPanelFlow.SuspendLayout();
            _PanelFixed.SuspendLayout();
            _PanelInput.SuspendLayout();
            SuspendLayout();
            // 
            // _Castbar
            // 
            _Castbar.BackColor = Color.Black;
            _Castbar.BackgroundColor = Color.Black;
            _Castbar.BackgroundColorRT = Color.FromArgb(0, 0, 75);
            _Castbar.BorderColor = Color.FromArgb(64, 64, 64);
            _Castbar.BorderColorRT = Color.White;
            _Castbar.ForegroundColor = Color.Magenta;
            _Castbar.IsConnected = false;
            _Castbar.Location = new Point(1172, 7);
            _Castbar.Margin = new Padding(5);
            _Castbar.Name = "_Castbar";
            _Castbar.Size = new Size(117, 30);
            _Castbar.TabIndex = 1;
            // 
            // _StatusStripMain
            // 
            _StatusStripMain.BackColor = SystemColors.Control;
            _StatusStripMain.GripStyle = ToolStripGripStyle.Visible;
            _StatusStripMain.Items.AddRange(new ToolStripItem[] { _ToolStripStatusLabel1, _ToolStripStatusLabel2, _ToolStripStatusLabel3, _ToolStripStatusLabel4, _ToolStripStatusLabel5, _ToolStripStatusLabel6, _ToolStripStatusLabel7, _ToolStripStatusLabel8, _ToolStripStatusLabel9, _ToolStripStatusLabel10 });
            _StatusStripMain.Location = new Point(0, 744);
            _StatusStripMain.Name = "_StatusStripMain";
            _StatusStripMain.Padding = new Padding(1, 0, 16, 0);
            _StatusStripMain.Size = new Size(1449, 24);
            _StatusStripMain.TabIndex = 2;
            // 
            // _ToolStripStatusLabel1
            // 
            _ToolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel1.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel1.Name = "_ToolStripStatusLabel1";
            _ToolStripStatusLabel1.Size = new Size(1432, 19);
            _ToolStripStatusLabel1.Spring = true;
            _ToolStripStatusLabel1.Text = "Ready";
            _ToolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _ToolStripStatusLabel2
            // 
            _ToolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel2.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel2.Name = "_ToolStripStatusLabel2";
            _ToolStripStatusLabel2.Size = new Size(4, 19);
            _ToolStripStatusLabel2.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel2.Visible = false;
            // 
            // _ToolStripStatusLabel3
            // 
            _ToolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel3.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel3.Name = "_ToolStripStatusLabel3";
            _ToolStripStatusLabel3.Size = new Size(4, 19);
            _ToolStripStatusLabel3.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel3.Visible = false;
            // 
            // _ToolStripStatusLabel4
            // 
            _ToolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel4.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel4.Name = "_ToolStripStatusLabel4";
            _ToolStripStatusLabel4.Size = new Size(4, 19);
            _ToolStripStatusLabel4.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel4.Visible = false;
            // 
            // _ToolStripStatusLabel5
            // 
            _ToolStripStatusLabel5.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel5.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel5.Name = "_ToolStripStatusLabel5";
            _ToolStripStatusLabel5.Size = new Size(4, 19);
            _ToolStripStatusLabel5.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel5.Visible = false;
            // 
            // _ToolStripStatusLabel6
            // 
            _ToolStripStatusLabel6.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel6.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel6.Name = "_ToolStripStatusLabel6";
            _ToolStripStatusLabel6.Size = new Size(4, 19);
            _ToolStripStatusLabel6.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel6.Visible = false;
            // 
            // _ToolStripStatusLabel7
            // 
            _ToolStripStatusLabel7.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel7.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel7.Name = "_ToolStripStatusLabel7";
            _ToolStripStatusLabel7.Size = new Size(4, 19);
            _ToolStripStatusLabel7.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel7.Visible = false;
            // 
            // _ToolStripStatusLabel8
            // 
            _ToolStripStatusLabel8.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel8.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel8.Name = "_ToolStripStatusLabel8";
            _ToolStripStatusLabel8.Size = new Size(4, 19);
            _ToolStripStatusLabel8.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel8.Visible = false;
            // 
            // _ToolStripStatusLabel9
            // 
            _ToolStripStatusLabel9.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel9.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel9.Name = "_ToolStripStatusLabel9";
            _ToolStripStatusLabel9.Size = new Size(4, 19);
            _ToolStripStatusLabel9.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel9.Visible = false;
            // 
            // _ToolStripStatusLabel10
            // 
            _ToolStripStatusLabel10.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            _ToolStripStatusLabel10.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel10.Name = "_ToolStripStatusLabel10";
            _ToolStripStatusLabel10.Size = new Size(4, 19);
            _ToolStripStatusLabel10.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel10.Visible = false;
            // 
            // _MenuStripMain
            // 
            _MenuStripMain.Items.AddRange(new ToolStripItem[] { _FileToolStripMenuItem, _EditToolStripMenuItem, _ProfileToolStripMenuItem, _LayoutToolStripMenuItem, _WindowToolStripMenuItem, _ScriptToolStripMenuItem, _AutoMapperToolStripMenuItem, _PluginsToolStripMenuItem, _HelpToolStripMenuItem });
            _MenuStripMain.Location = new Point(0, 0);
            _MenuStripMain.Name = "_MenuStripMain";
            _MenuStripMain.Padding = new Padding(7, 2, 0, 2);
            _MenuStripMain.Size = new Size(1449, 24);
            _MenuStripMain.TabIndex = 1;
            _MenuStripMain.Text = "MenuStrip1";
            // 
            // _FileToolStripMenuItem
            // 
            _FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ConnectToolStripMenuItem, _ConnectToolStripMenuItemConnectDialog, _ToolStripSeparator7, _OpenUserDataDirectoryToolStripMenuItem, _ToolStripMenuItem4, _AutoLogToolStripMenuItem, _OpenLogInEditorToolStripMenuItem, _ToolStripSeparator13, _AutoReconnectToolStripMenuItem, ClassicConnectToolStripMenuItem, _IgnoresEnabledToolStripMenuItem, _ToolStripMenuItemTriggers, _PluginsEnabledToolStripMenuItem, _AutoMapperEnabledToolStripMenuItem, _ImagesEnabledToolStripMenuItem, _MuteSoundsToolStripMenuItem, _ToolStripSeparator8, _ToolStripMenuItemShowXML, _ToolStripMenuItem1, _ToolStripSeparator1, _ExitToolStripMenuItem });
            _FileToolStripMenuItem.Name = "_FileToolStripMenuItem";
            _FileToolStripMenuItem.Size = new Size(37, 20);
            _FileToolStripMenuItem.Text = "&File";
            // 
            // _ConnectToolStripMenuItem
            // 
            _ConnectToolStripMenuItem.Name = "_ConnectToolStripMenuItem";
            _ConnectToolStripMenuItem.Size = new Size(205, 22);
            _ConnectToolStripMenuItem.Text = "&Connect...";
            _ConnectToolStripMenuItem.Click += ConnectToolStripMenuItem_Click;
            // 
            // _ConnectToolStripMenuItemConnectDialog
            // 
            _ConnectToolStripMenuItemConnectDialog.Name = "_ConnectToolStripMenuItemConnectDialog";
            _ConnectToolStripMenuItemConnectDialog.Size = new Size(205, 22);
            _ConnectToolStripMenuItemConnectDialog.Text = "Connect &Using Profile...";
            _ConnectToolStripMenuItemConnectDialog.Click += ConnectToolStripMenuItemConnectDialog_Click;
            // 
            // _ToolStripSeparator7
            // 
            _ToolStripSeparator7.Name = "_ToolStripSeparator7";
            _ToolStripSeparator7.Size = new Size(202, 6);
            // 
            // _OpenUserDataDirectoryToolStripMenuItem
            // 
            _OpenUserDataDirectoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { genieToolStripMenuItem, scriptsToolStripMenuItem, mapsToolStripMenuItem, pluginsToolStripMenuItem, logsToolStripMenuItem, artToolStripMenuItem });
            _OpenUserDataDirectoryToolStripMenuItem.Name = "_OpenUserDataDirectoryToolStripMenuItem";
            _OpenUserDataDirectoryToolStripMenuItem.Size = new Size(205, 22);
            _OpenUserDataDirectoryToolStripMenuItem.Text = "Open Directory...";
            _OpenUserDataDirectoryToolStripMenuItem.Click += genieToolStripMenuItem_Click;
            // 
            // genieToolStripMenuItem
            // 
            genieToolStripMenuItem.Name = "genieToolStripMenuItem";
            genieToolStripMenuItem.Size = new Size(113, 22);
            genieToolStripMenuItem.Text = "Genie";
            genieToolStripMenuItem.Click += genieToolStripMenuItem_Click;
            // 
            // scriptsToolStripMenuItem
            // 
            scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            scriptsToolStripMenuItem.Size = new Size(113, 22);
            scriptsToolStripMenuItem.Text = "Scripts";
            scriptsToolStripMenuItem.Click += scriptsToolStripMenuItem_Click;
            // 
            // mapsToolStripMenuItem
            // 
            mapsToolStripMenuItem.Name = "mapsToolStripMenuItem";
            mapsToolStripMenuItem.Size = new Size(113, 22);
            mapsToolStripMenuItem.Text = "Maps";
            mapsToolStripMenuItem.Click += mapsToolStripMenuItem_Click;
            // 
            // pluginsToolStripMenuItem
            // 
            pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            pluginsToolStripMenuItem.Size = new Size(113, 22);
            pluginsToolStripMenuItem.Text = "Plugins";
            pluginsToolStripMenuItem.Click += pluginsToolStripMenuItem_Click;
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(113, 22);
            logsToolStripMenuItem.Text = "Logs";
            logsToolStripMenuItem.Click += logsToolStripMenuItem_Click;
            // 
            // artToolStripMenuItem
            // 
            artToolStripMenuItem.Name = "artToolStripMenuItem";
            artToolStripMenuItem.Size = new Size(113, 22);
            artToolStripMenuItem.Text = "Art";
            artToolStripMenuItem.Click += artToolStripMenuItem_Click;
            // 
            // _ToolStripMenuItem4
            // 
            _ToolStripMenuItem4.Name = "_ToolStripMenuItem4";
            _ToolStripMenuItem4.Size = new Size(202, 6);
            // 
            // _AutoLogToolStripMenuItem
            // 
            _AutoLogToolStripMenuItem.Checked = true;
            _AutoLogToolStripMenuItem.CheckOnClick = true;
            _AutoLogToolStripMenuItem.CheckState = CheckState.Checked;
            _AutoLogToolStripMenuItem.Name = "_AutoLogToolStripMenuItem";
            _AutoLogToolStripMenuItem.Size = new Size(205, 22);
            _AutoLogToolStripMenuItem.Text = "&Auto Log";
            _AutoLogToolStripMenuItem.Click += AutoLogToolStripMenuItem_Click;
            // 
            // _OpenLogInEditorToolStripMenuItem
            // 
            _OpenLogInEditorToolStripMenuItem.Name = "_OpenLogInEditorToolStripMenuItem";
            _OpenLogInEditorToolStripMenuItem.Size = new Size(205, 22);
            _OpenLogInEditorToolStripMenuItem.Text = "&Open Log In Editor";
            _OpenLogInEditorToolStripMenuItem.Click += OpenLogInEditorToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator13
            // 
            _ToolStripSeparator13.Name = "_ToolStripSeparator13";
            _ToolStripSeparator13.Size = new Size(202, 6);
            // 
            // _AutoReconnectToolStripMenuItem
            // 
            _AutoReconnectToolStripMenuItem.Checked = true;
            _AutoReconnectToolStripMenuItem.CheckOnClick = true;
            _AutoReconnectToolStripMenuItem.CheckState = CheckState.Checked;
            _AutoReconnectToolStripMenuItem.Name = "_AutoReconnectToolStripMenuItem";
            _AutoReconnectToolStripMenuItem.Size = new Size(205, 22);
            _AutoReconnectToolStripMenuItem.Text = "Auto &Reconnect";
            _AutoReconnectToolStripMenuItem.Click += AutoReconnectToolStripMenuItem_Click;
            // 
            // ClassicConnectToolStripMenuItem
            // 
            ClassicConnectToolStripMenuItem.Checked = true;
            ClassicConnectToolStripMenuItem.CheckOnClick = true;
            ClassicConnectToolStripMenuItem.CheckState = CheckState.Checked;
            ClassicConnectToolStripMenuItem.Name = "ClassicConnectToolStripMenuItem";
            ClassicConnectToolStripMenuItem.Size = new Size(205, 22);
            ClassicConnectToolStripMenuItem.Text = "Classic Connect Window";
            ClassicConnectToolStripMenuItem.Click += ClassicConnectToolStripMenuItem_Click;
            // 
            // _IgnoresEnabledToolStripMenuItem
            // 
            _IgnoresEnabledToolStripMenuItem.Checked = true;
            _IgnoresEnabledToolStripMenuItem.CheckOnClick = true;
            _IgnoresEnabledToolStripMenuItem.CheckState = CheckState.Checked;
            _IgnoresEnabledToolStripMenuItem.Name = "_IgnoresEnabledToolStripMenuItem";
            _IgnoresEnabledToolStripMenuItem.Size = new Size(205, 22);
            _IgnoresEnabledToolStripMenuItem.Text = "&Ignores/Gags Enabled";
            _IgnoresEnabledToolStripMenuItem.Click += IgnoresEnabledToolStripMenuItem_Click;
            // 
            // _ToolStripMenuItemTriggers
            // 
            _ToolStripMenuItemTriggers.Checked = true;
            _ToolStripMenuItemTriggers.CheckOnClick = true;
            _ToolStripMenuItemTriggers.CheckState = CheckState.Checked;
            _ToolStripMenuItemTriggers.Name = "_ToolStripMenuItemTriggers";
            _ToolStripMenuItemTriggers.Size = new Size(205, 22);
            _ToolStripMenuItemTriggers.Text = "&Triggers Enabled";
            _ToolStripMenuItemTriggers.Click += ToolStripMenuItemTriggers_Click;
            // 
            // _PluginsEnabledToolStripMenuItem
            // 
            _PluginsEnabledToolStripMenuItem.Checked = true;
            _PluginsEnabledToolStripMenuItem.CheckOnClick = true;
            _PluginsEnabledToolStripMenuItem.CheckState = CheckState.Checked;
            _PluginsEnabledToolStripMenuItem.Name = "_PluginsEnabledToolStripMenuItem";
            _PluginsEnabledToolStripMenuItem.Size = new Size(205, 22);
            _PluginsEnabledToolStripMenuItem.Text = "&Plugins Enabled";
            _PluginsEnabledToolStripMenuItem.Click += PluginsEnabledToolStripMenuItem_Click;
            // 
            // _AutoMapperEnabledToolStripMenuItem
            // 
            _AutoMapperEnabledToolStripMenuItem.Checked = true;
            _AutoMapperEnabledToolStripMenuItem.CheckState = CheckState.Checked;
            _AutoMapperEnabledToolStripMenuItem.Name = "_AutoMapperEnabledToolStripMenuItem";
            _AutoMapperEnabledToolStripMenuItem.Size = new Size(205, 22);
            _AutoMapperEnabledToolStripMenuItem.Text = "Auto&Mapper Enabled";
            _AutoMapperEnabledToolStripMenuItem.Click += AutoMapperEnabledToolStripMenuItem_Click;
            // 
            // _ImagesEnabledToolStripMenuItem
            // 
            _ImagesEnabledToolStripMenuItem.Checked = true;
            _ImagesEnabledToolStripMenuItem.CheckState = CheckState.Checked;
            _ImagesEnabledToolStripMenuItem.Name = "_ImagesEnabledToolStripMenuItem";
            _ImagesEnabledToolStripMenuItem.Size = new Size(205, 22);
            _ImagesEnabledToolStripMenuItem.Text = "Images Enabled";
            _ImagesEnabledToolStripMenuItem.Click += _ImagesEnabledToolStripMenuItem_Click;
            // 
            // _MuteSoundsToolStripMenuItem
            // 
            _MuteSoundsToolStripMenuItem.CheckOnClick = true;
            _MuteSoundsToolStripMenuItem.Name = "_MuteSoundsToolStripMenuItem";
            _MuteSoundsToolStripMenuItem.Size = new Size(205, 22);
            _MuteSoundsToolStripMenuItem.Text = "&Mute Sounds";
            _MuteSoundsToolStripMenuItem.Click += MuteSoundsToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator8
            // 
            _ToolStripSeparator8.Name = "_ToolStripSeparator8";
            _ToolStripSeparator8.Size = new Size(202, 6);
            // 
            // _ToolStripMenuItemShowXML
            // 
            _ToolStripMenuItemShowXML.CheckOnClick = true;
            _ToolStripMenuItemShowXML.Name = "_ToolStripMenuItemShowXML";
            _ToolStripMenuItemShowXML.Size = new Size(205, 22);
            _ToolStripMenuItemShowXML.Text = "Show &Raw Data";
            _ToolStripMenuItemShowXML.Click += ToolStripMenuItemShowXML_Click;
            // 
            // _ToolStripMenuItem1
            // 
            _ToolStripMenuItem1.Name = "_ToolStripMenuItem1";
            _ToolStripMenuItem1.Size = new Size(205, 22);
            _ToolStripMenuItem1.Text = "P&erformace Test Parse";
            _ToolStripMenuItem1.Visible = false;
            _ToolStripMenuItem1.Click += ToolStripMenuItem1_Click;
            // 
            // _ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "_ToolStripSeparator1";
            _ToolStripSeparator1.Size = new Size(202, 6);
            // 
            // _ExitToolStripMenuItem
            // 
            _ExitToolStripMenuItem.Name = "_ExitToolStripMenuItem";
            _ExitToolStripMenuItem.Size = new Size(205, 22);
            _ExitToolStripMenuItem.Text = "E&xit";
            _ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // _EditToolStripMenuItem
            // 
            _EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ToolStripMenuItemSpecialPaste, _ToolStripSeparator6, _ConfigurationToolStripMenuItem, UpdateImagesToolStripMenuItem });
            _EditToolStripMenuItem.Name = "_EditToolStripMenuItem";
            _EditToolStripMenuItem.Size = new Size(39, 20);
            _EditToolStripMenuItem.Text = "&Edit";
            // 
            // _ToolStripMenuItemSpecialPaste
            // 
            _ToolStripMenuItemSpecialPaste.Name = "_ToolStripMenuItemSpecialPaste";
            _ToolStripMenuItemSpecialPaste.Size = new Size(158, 22);
            _ToolStripMenuItemSpecialPaste.Text = "Paste &Multi Line";
            _ToolStripMenuItemSpecialPaste.Click += ToolStripMenuItemSpecialPaste_Click;
            // 
            // _ToolStripSeparator6
            // 
            _ToolStripSeparator6.Name = "_ToolStripSeparator6";
            _ToolStripSeparator6.Size = new Size(155, 6);
            // 
            // _ConfigurationToolStripMenuItem
            // 
            _ConfigurationToolStripMenuItem.Name = "_ConfigurationToolStripMenuItem";
            _ConfigurationToolStripMenuItem.Size = new Size(158, 22);
            _ConfigurationToolStripMenuItem.Text = "&Configuration...";
            _ConfigurationToolStripMenuItem.Click += ConfigurationToolStripMenuItem_Click;
            // 
            // UpdateImagesToolStripMenuItem
            // 
            UpdateImagesToolStripMenuItem.Name = "UpdateImagesToolStripMenuItem";
            UpdateImagesToolStripMenuItem.Size = new Size(158, 22);
            UpdateImagesToolStripMenuItem.Text = "Update Images";
            UpdateImagesToolStripMenuItem.Click += UpdateImagesToolStripMenuItem_Click;
            // 
            // _ProfileToolStripMenuItem
            // 
            _ProfileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _LoadProfileToolStripMenuItem, _SaveProfileToolStripMenuItem, _ToolStripMenuItem2, _SavePasswordToolStripMenuItem });
            _ProfileToolStripMenuItem.Name = "_ProfileToolStripMenuItem";
            _ProfileToolStripMenuItem.Size = new Size(53, 20);
            _ProfileToolStripMenuItem.Text = "&Profile";
            // 
            // _LoadProfileToolStripMenuItem
            // 
            _LoadProfileToolStripMenuItem.Name = "_LoadProfileToolStripMenuItem";
            _LoadProfileToolStripMenuItem.Size = new Size(216, 22);
            _LoadProfileToolStripMenuItem.Text = "&Load Profile...";
            _LoadProfileToolStripMenuItem.Click += LoadProfileToolStripMenuItem_Click;
            // 
            // _SaveProfileToolStripMenuItem
            // 
            _SaveProfileToolStripMenuItem.Name = "_SaveProfileToolStripMenuItem";
            _SaveProfileToolStripMenuItem.Size = new Size(216, 22);
            _SaveProfileToolStripMenuItem.Text = "&Save Profile";
            _SaveProfileToolStripMenuItem.Click += SaveProfileToolStripMenuItem_Click;
            // 
            // _ToolStripMenuItem2
            // 
            _ToolStripMenuItem2.Name = "_ToolStripMenuItem2";
            _ToolStripMenuItem2.Size = new Size(213, 6);
            // 
            // _SavePasswordToolStripMenuItem
            // 
            _SavePasswordToolStripMenuItem.CheckOnClick = true;
            _SavePasswordToolStripMenuItem.Name = "_SavePasswordToolStripMenuItem";
            _SavePasswordToolStripMenuItem.Size = new Size(216, 22);
            _SavePasswordToolStripMenuItem.Text = "Include &Password In Profile";
            _SavePasswordToolStripMenuItem.Click += SavePasswordToolStripMenuItem_Click;
            // 
            // _LayoutToolStripMenuItem
            // 
            _LayoutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _LoadSettingsOpenToolStripMenuItem, _LoadSettingsToolStripMenuItem, _ToolStripSeparator12, _SaveSettingsToolStripMenuItem1, _SaveSettingsToolStripMenuItem, _SaveSizedDefaultLayoutToolStripMenuItem, _ToolStripSeparator5, _BasicToolStripMenuItem, _ToolStripSeparator4, _IconBarToolStripMenuItem, _ShowScriptBarToolStripMenuItem, _HealthBarToolStripMenuItem, _MagicPanelsToolStripMenuItem, _StatusBarToolStripMenuItem, alignInputToGameWindowToolStripMenuItem, alwaysOnTopToolStripMenuItem });
            _LayoutToolStripMenuItem.Name = "_LayoutToolStripMenuItem";
            _LayoutToolStripMenuItem.Size = new Size(55, 20);
            _LayoutToolStripMenuItem.Text = "&Layout";
            // 
            // _LoadSettingsOpenToolStripMenuItem
            // 
            _LoadSettingsOpenToolStripMenuItem.Name = "_LoadSettingsOpenToolStripMenuItem";
            _LoadSettingsOpenToolStripMenuItem.Size = new Size(228, 22);
            _LoadSettingsOpenToolStripMenuItem.Text = "Load Layout...";
            _LoadSettingsOpenToolStripMenuItem.Click += LoadSettingsOpenToolStripMenuItem_Click;
            // 
            // _LoadSettingsToolStripMenuItem
            // 
            _LoadSettingsToolStripMenuItem.Name = "_LoadSettingsToolStripMenuItem";
            _LoadSettingsToolStripMenuItem.Size = new Size(228, 22);
            _LoadSettingsToolStripMenuItem.Text = "Load Default Layout";
            _LoadSettingsToolStripMenuItem.Click += LoadSettingsToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator12
            // 
            _ToolStripSeparator12.Name = "_ToolStripSeparator12";
            _ToolStripSeparator12.Size = new Size(225, 6);
            // 
            // _SaveSettingsToolStripMenuItem1
            // 
            _SaveSettingsToolStripMenuItem1.Name = "_SaveSettingsToolStripMenuItem1";
            _SaveSettingsToolStripMenuItem1.Size = new Size(228, 22);
            _SaveSettingsToolStripMenuItem1.Text = "Save Layout As...";
            _SaveSettingsToolStripMenuItem1.Click += SaveSettingsToolStripMenuItem1_Click;
            // 
            // _SaveSettingsToolStripMenuItem
            // 
            _SaveSettingsToolStripMenuItem.Name = "_SaveSettingsToolStripMenuItem";
            _SaveSettingsToolStripMenuItem.Size = new Size(228, 22);
            _SaveSettingsToolStripMenuItem.Text = "Save Default Layout";
            _SaveSettingsToolStripMenuItem.Click += SaveSettingsToolStripMenuItem_Click;
            // 
            // _SaveSizedDefaultLayoutToolStripMenuItem
            // 
            _SaveSizedDefaultLayoutToolStripMenuItem.Name = "_SaveSizedDefaultLayoutToolStripMenuItem";
            _SaveSizedDefaultLayoutToolStripMenuItem.Size = new Size(228, 22);
            _SaveSizedDefaultLayoutToolStripMenuItem.Text = "Save Sized Default Layout";
            _SaveSizedDefaultLayoutToolStripMenuItem.Click += SaveSizedDefaultLayoutToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator5
            // 
            _ToolStripSeparator5.Name = "_ToolStripSeparator5";
            _ToolStripSeparator5.Size = new Size(225, 6);
            // 
            // _BasicToolStripMenuItem
            // 
            _BasicToolStripMenuItem.Name = "_BasicToolStripMenuItem";
            _BasicToolStripMenuItem.Size = new Size(228, 22);
            _BasicToolStripMenuItem.Text = "Basic Layout";
            _BasicToolStripMenuItem.Click += BasicToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator4
            // 
            _ToolStripSeparator4.Name = "_ToolStripSeparator4";
            _ToolStripSeparator4.Size = new Size(225, 6);
            // 
            // _IconBarToolStripMenuItem
            // 
            _IconBarToolStripMenuItem.Checked = true;
            _IconBarToolStripMenuItem.CheckOnClick = true;
            _IconBarToolStripMenuItem.CheckState = CheckState.Checked;
            _IconBarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DockTopToolStripMenuItem, _DockBottomToolStripMenuItem });
            _IconBarToolStripMenuItem.Name = "_IconBarToolStripMenuItem";
            _IconBarToolStripMenuItem.Size = new Size(228, 22);
            _IconBarToolStripMenuItem.Text = "Icon Bar";
            _IconBarToolStripMenuItem.Click += IconBarToolStripMenuItem_Click;
            // 
            // _DockTopToolStripMenuItem
            // 
            _DockTopToolStripMenuItem.Name = "_DockTopToolStripMenuItem";
            _DockTopToolStripMenuItem.Size = new Size(144, 22);
            _DockTopToolStripMenuItem.Text = "Dock Top";
            _DockTopToolStripMenuItem.Click += DockTopToolStripMenuItem_Click;
            // 
            // _DockBottomToolStripMenuItem
            // 
            _DockBottomToolStripMenuItem.Checked = true;
            _DockBottomToolStripMenuItem.CheckState = CheckState.Checked;
            _DockBottomToolStripMenuItem.Name = "_DockBottomToolStripMenuItem";
            _DockBottomToolStripMenuItem.Size = new Size(144, 22);
            _DockBottomToolStripMenuItem.Text = "Dock Bottom";
            _DockBottomToolStripMenuItem.Click += DockBottomToolStripMenuItem_Click;
            // 
            // _ShowScriptBarToolStripMenuItem
            // 
            _ShowScriptBarToolStripMenuItem.Checked = true;
            _ShowScriptBarToolStripMenuItem.CheckOnClick = true;
            _ShowScriptBarToolStripMenuItem.CheckState = CheckState.Checked;
            _ShowScriptBarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DockTopToolStripMenuItem1, _DockBottomToolStripMenuItem1 });
            _ShowScriptBarToolStripMenuItem.Name = "_ShowScriptBarToolStripMenuItem";
            _ShowScriptBarToolStripMenuItem.Size = new Size(228, 22);
            _ShowScriptBarToolStripMenuItem.Text = "Script Bar";
            _ShowScriptBarToolStripMenuItem.Click += ShowScriptBarToolStripMenuItem_Click;
            // 
            // _DockTopToolStripMenuItem1
            // 
            _DockTopToolStripMenuItem1.Name = "_DockTopToolStripMenuItem1";
            _DockTopToolStripMenuItem1.Size = new Size(144, 22);
            _DockTopToolStripMenuItem1.Text = "Dock Top";
            _DockTopToolStripMenuItem1.Click += DockTopToolStripMenuItem1_Click;
            // 
            // _DockBottomToolStripMenuItem1
            // 
            _DockBottomToolStripMenuItem1.Checked = true;
            _DockBottomToolStripMenuItem1.CheckState = CheckState.Checked;
            _DockBottomToolStripMenuItem1.Name = "_DockBottomToolStripMenuItem1";
            _DockBottomToolStripMenuItem1.Size = new Size(144, 22);
            _DockBottomToolStripMenuItem1.Text = "Dock Bottom";
            _DockBottomToolStripMenuItem1.Click += DockBottomToolStripMenuItem1_Click;
            // 
            // _HealthBarToolStripMenuItem
            // 
            _HealthBarToolStripMenuItem.Checked = true;
            _HealthBarToolStripMenuItem.CheckOnClick = true;
            _HealthBarToolStripMenuItem.CheckState = CheckState.Checked;
            _HealthBarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DockTopToolStripMenuItem2, _DockBottomToolStripMenuItem2 });
            _HealthBarToolStripMenuItem.Name = "_HealthBarToolStripMenuItem";
            _HealthBarToolStripMenuItem.Size = new Size(228, 22);
            _HealthBarToolStripMenuItem.Text = "Health Bar";
            _HealthBarToolStripMenuItem.Click += HealthBarToolStripMenuItem_Click;
            // 
            // _DockTopToolStripMenuItem2
            // 
            _DockTopToolStripMenuItem2.Name = "_DockTopToolStripMenuItem2";
            _DockTopToolStripMenuItem2.Size = new Size(144, 22);
            _DockTopToolStripMenuItem2.Text = "Dock Top";
            _DockTopToolStripMenuItem2.Click += DockTopToolStripMenuItem2_Click;
            // 
            // _DockBottomToolStripMenuItem2
            // 
            _DockBottomToolStripMenuItem2.Checked = true;
            _DockBottomToolStripMenuItem2.CheckState = CheckState.Checked;
            _DockBottomToolStripMenuItem2.Name = "_DockBottomToolStripMenuItem2";
            _DockBottomToolStripMenuItem2.Size = new Size(144, 22);
            _DockBottomToolStripMenuItem2.Text = "Dock Bottom";
            _DockBottomToolStripMenuItem2.Click += DockBottomToolStripMenuItem2_Click;
            // 
            // _MagicPanelsToolStripMenuItem
            // 
            _MagicPanelsToolStripMenuItem.Checked = true;
            _MagicPanelsToolStripMenuItem.CheckOnClick = true;
            _MagicPanelsToolStripMenuItem.CheckState = CheckState.Checked;
            _MagicPanelsToolStripMenuItem.Name = "_MagicPanelsToolStripMenuItem";
            _MagicPanelsToolStripMenuItem.Size = new Size(228, 22);
            _MagicPanelsToolStripMenuItem.Text = "Magic Panels";
            _MagicPanelsToolStripMenuItem.Click += MagicPanelsToolStripMenuItem_Click;
            // 
            // _StatusBarToolStripMenuItem
            // 
            _StatusBarToolStripMenuItem.Checked = true;
            _StatusBarToolStripMenuItem.CheckOnClick = true;
            _StatusBarToolStripMenuItem.CheckState = CheckState.Checked;
            _StatusBarToolStripMenuItem.Name = "_StatusBarToolStripMenuItem";
            _StatusBarToolStripMenuItem.Size = new Size(228, 22);
            _StatusBarToolStripMenuItem.Text = "Status Bar";
            _StatusBarToolStripMenuItem.Click += StatusBarToolStripMenuItem_Click;
            // 
            // alignInputToGameWindowToolStripMenuItem
            // 
            alignInputToGameWindowToolStripMenuItem.CheckOnClick = true;
            alignInputToGameWindowToolStripMenuItem.Name = "alignInputToGameWindowToolStripMenuItem";
            alignInputToGameWindowToolStripMenuItem.Size = new Size(228, 22);
            alignInputToGameWindowToolStripMenuItem.Text = "Align Input to Game Window";
            alignInputToGameWindowToolStripMenuItem.CheckedChanged += alignInputToGameWindowToolStripMenuItem_CheckedChanged;
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            alwaysOnTopToolStripMenuItem.Size = new Size(228, 22);
            alwaysOnTopToolStripMenuItem.Text = "Always On Top";
            alwaysOnTopToolStripMenuItem.CheckedChanged += alwaysOnTopToolStripMenuItem_CheckedChanged;
            // 
            // _WindowToolStripMenuItem
            // 
            _WindowToolStripMenuItem.Name = "_WindowToolStripMenuItem";
            _WindowToolStripMenuItem.Size = new Size(68, 20);
            _WindowToolStripMenuItem.Text = "&Windows";
            // 
            // _ScriptToolStripMenuItem
            // 
            _ScriptToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ScriptExplorerToolStripMenuItem, updateScriptsToolStripMenuItem, _ToolStripSeparator11, _ListAllScriptsToolStripMenuItem, _TraceAllScriptsToolStripMenuItem, _ToolStripSeparator9, _PauseAllScriptsToolStripMenuItem, _ResumeAllScriptsToolStripMenuItem, _ToolStripMenuItem3, _AbortAllScriptsToolStripMenuItem });
            _ScriptToolStripMenuItem.Name = "_ScriptToolStripMenuItem";
            _ScriptToolStripMenuItem.Size = new Size(49, 20);
            _ScriptToolStripMenuItem.Text = "&Script";
            // 
            // _ScriptExplorerToolStripMenuItem
            // 
            _ScriptExplorerToolStripMenuItem.Name = "_ScriptExplorerToolStripMenuItem";
            _ScriptExplorerToolStripMenuItem.Size = new Size(177, 22);
            _ScriptExplorerToolStripMenuItem.Text = "Script &Explorer...";
            _ScriptExplorerToolStripMenuItem.Click += ScriptExplorerToolStripMenuItem_Click;
            // 
            // updateScriptsToolStripMenuItem
            // 
            updateScriptsToolStripMenuItem.Name = "updateScriptsToolStripMenuItem";
            updateScriptsToolStripMenuItem.Size = new Size(177, 22);
            updateScriptsToolStripMenuItem.Text = "&Update Scripts";
            updateScriptsToolStripMenuItem.Click += updateScriptsToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator11
            // 
            _ToolStripSeparator11.Name = "_ToolStripSeparator11";
            _ToolStripSeparator11.Size = new Size(174, 6);
            // 
            // _ListAllScriptsToolStripMenuItem
            // 
            _ListAllScriptsToolStripMenuItem.Name = "_ListAllScriptsToolStripMenuItem";
            _ListAllScriptsToolStripMenuItem.Size = new Size(177, 22);
            _ListAllScriptsToolStripMenuItem.Text = "&Show Active Scripts";
            _ListAllScriptsToolStripMenuItem.Click += ListAllScriptsToolStripMenuItem_Click;
            // 
            // _TraceAllScriptsToolStripMenuItem
            // 
            _TraceAllScriptsToolStripMenuItem.Name = "_TraceAllScriptsToolStripMenuItem";
            _TraceAllScriptsToolStripMenuItem.Size = new Size(177, 22);
            _TraceAllScriptsToolStripMenuItem.Text = "&Trace Active Scripts";
            _TraceAllScriptsToolStripMenuItem.Click += TraceAllScriptsToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator9
            // 
            _ToolStripSeparator9.Name = "_ToolStripSeparator9";
            _ToolStripSeparator9.Size = new Size(174, 6);
            // 
            // _PauseAllScriptsToolStripMenuItem
            // 
            _PauseAllScriptsToolStripMenuItem.Name = "_PauseAllScriptsToolStripMenuItem";
            _PauseAllScriptsToolStripMenuItem.Size = new Size(177, 22);
            _PauseAllScriptsToolStripMenuItem.Text = "&Pause All Scripts";
            _PauseAllScriptsToolStripMenuItem.Click += PauseAllScriptsToolStripMenuItem_Click;
            // 
            // _ResumeAllScriptsToolStripMenuItem
            // 
            _ResumeAllScriptsToolStripMenuItem.Name = "_ResumeAllScriptsToolStripMenuItem";
            _ResumeAllScriptsToolStripMenuItem.Size = new Size(177, 22);
            _ResumeAllScriptsToolStripMenuItem.Text = "&Resume All Scripts";
            _ResumeAllScriptsToolStripMenuItem.Click += ResumeAllScriptsToolStripMenuItem_Click;
            // 
            // _ToolStripMenuItem3
            // 
            _ToolStripMenuItem3.Name = "_ToolStripMenuItem3";
            _ToolStripMenuItem3.Size = new Size(174, 6);
            // 
            // _AbortAllScriptsToolStripMenuItem
            // 
            _AbortAllScriptsToolStripMenuItem.Name = "_AbortAllScriptsToolStripMenuItem";
            _AbortAllScriptsToolStripMenuItem.ShortcutKeyDisplayString = "";
            _AbortAllScriptsToolStripMenuItem.Size = new Size(177, 22);
            _AbortAllScriptsToolStripMenuItem.Text = "&Abort All Scripts";
            _AbortAllScriptsToolStripMenuItem.Click += AbortAllScriptsToolStripMenuItem_Click;
            // 
            // _AutoMapperToolStripMenuItem
            // 
            _AutoMapperToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ShowWindowToolStripMenuItem, updateMapsToolStripMenuItem, settingsToolStripMenuItem });
            _AutoMapperToolStripMenuItem.Name = "_AutoMapperToolStripMenuItem";
            _AutoMapperToolStripMenuItem.Size = new Size(86, 20);
            _AutoMapperToolStripMenuItem.Text = "&AutoMapper";
            // 
            // _ShowWindowToolStripMenuItem
            // 
            _ShowWindowToolStripMenuItem.Name = "_ShowWindowToolStripMenuItem";
            _ShowWindowToolStripMenuItem.Size = new Size(150, 22);
            _ShowWindowToolStripMenuItem.Text = "&Show Window";
            _ShowWindowToolStripMenuItem.Click += ShowWindowToolStripMenuItem_Click;
            // 
            // updateMapsToolStripMenuItem
            // 
            updateMapsToolStripMenuItem.Name = "updateMapsToolStripMenuItem";
            updateMapsToolStripMenuItem.Size = new Size(150, 22);
            updateMapsToolStripMenuItem.Text = "&Update Maps";
            updateMapsToolStripMenuItem.Click += updateMapsToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(150, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // _PluginsToolStripMenuItem
            // 
            _PluginsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _NoPluginsLoadedToolStripMenuItem, updatePluginsToolStripMenuItem });
            _PluginsToolStripMenuItem.Name = "_PluginsToolStripMenuItem";
            _PluginsToolStripMenuItem.Size = new Size(58, 20);
            _PluginsToolStripMenuItem.Text = "Pl&ugins";
            // 
            // _NoPluginsLoadedToolStripMenuItem
            // 
            _NoPluginsLoadedToolStripMenuItem.Name = "_NoPluginsLoadedToolStripMenuItem";
            _NoPluginsLoadedToolStripMenuItem.Size = new Size(171, 22);
            _NoPluginsLoadedToolStripMenuItem.Text = "No plugins loaded";
            // 
            // updatePluginsToolStripMenuItem
            // 
            updatePluginsToolStripMenuItem.Name = "updatePluginsToolStripMenuItem";
            updatePluginsToolStripMenuItem.Size = new Size(171, 22);
            updatePluginsToolStripMenuItem.Text = "&Update Plugins";
            updatePluginsToolStripMenuItem.Click += updatePluginsToolStripMenuItem_Click;
            // 
            // _HelpToolStripMenuItem
            // 
            _HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { checkForUpdatesToolStripMenuItem, forceUpdateToolStripMenuItem, loadTestClientToolStripMenuItem, _ToolStripSeparator3, autoUpdateToolStripMenuItem, autoUpdateLampToolStripMenuItem, checkUpdatesOnStartupToolStripMenuItem, _ChangelogToolStripMenuItem, _ToolStripSeparator10, _OpenGenieDiscordToolStripMenuItem, OpenGenieGithubToolStripMenuItem, _OpenGenieDocsToolStripMenuItem, toolStripSeparator1, toolStripMenuItem1 });
            _HelpToolStripMenuItem.Name = "_HelpToolStripMenuItem";
            _HelpToolStripMenuItem.Size = new Size(44, 20);
            _HelpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            checkForUpdatesToolStripMenuItem.Size = new Size(211, 22);
            checkForUpdatesToolStripMenuItem.Text = "Check For &Updates";
            checkForUpdatesToolStripMenuItem.Click += checkForUpdatesToolStripMenuItem_Click;
            // 
            // forceUpdateToolStripMenuItem
            // 
            forceUpdateToolStripMenuItem.Name = "forceUpdateToolStripMenuItem";
            forceUpdateToolStripMenuItem.Size = new Size(211, 22);
            forceUpdateToolStripMenuItem.Text = "&Force Update";
            forceUpdateToolStripMenuItem.Click += forceUpdateToolStripMenuItem_Click;
            // 
            // loadTestClientToolStripMenuItem
            // 
            loadTestClientToolStripMenuItem.Name = "loadTestClientToolStripMenuItem";
            loadTestClientToolStripMenuItem.Size = new Size(211, 22);
            loadTestClientToolStripMenuItem.Text = "Load Test Client";
            loadTestClientToolStripMenuItem.Click += loadTestClientToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator3
            // 
            _ToolStripSeparator3.Name = "_ToolStripSeparator3";
            _ToolStripSeparator3.Size = new Size(208, 6);
            // 
            // autoUpdateToolStripMenuItem
            // 
            autoUpdateToolStripMenuItem.Name = "autoUpdateToolStripMenuItem";
            autoUpdateToolStripMenuItem.Size = new Size(211, 22);
            autoUpdateToolStripMenuItem.Text = "&AutoUpdate";
            autoUpdateToolStripMenuItem.Click += autoUpdateToolStripMenuItem_Click;
            // 
            // autoUpdateLampToolStripMenuItem
            // 
            autoUpdateLampToolStripMenuItem.Checked = true;
            autoUpdateLampToolStripMenuItem.CheckState = CheckState.Checked;
            autoUpdateLampToolStripMenuItem.Name = "autoUpdateLampToolStripMenuItem";
            autoUpdateLampToolStripMenuItem.Size = new Size(211, 22);
            autoUpdateLampToolStripMenuItem.Text = "AutoUpdate Lamp";
            autoUpdateLampToolStripMenuItem.Click += autoUpdateLampToolStripMenuItem_Click;
            // 
            // checkUpdatesOnStartupToolStripMenuItem
            // 
            checkUpdatesOnStartupToolStripMenuItem.Checked = true;
            checkUpdatesOnStartupToolStripMenuItem.CheckState = CheckState.Checked;
            checkUpdatesOnStartupToolStripMenuItem.Name = "checkUpdatesOnStartupToolStripMenuItem";
            checkUpdatesOnStartupToolStripMenuItem.Size = new Size(211, 22);
            checkUpdatesOnStartupToolStripMenuItem.Text = "&Check Updates on Startup";
            checkUpdatesOnStartupToolStripMenuItem.Click += checkUpdatesOnStartupToolStripMenuItem_Click;
            // 
            // _ChangelogToolStripMenuItem
            // 
            _ChangelogToolStripMenuItem.Name = "_ChangelogToolStripMenuItem";
            _ChangelogToolStripMenuItem.Size = new Size(211, 22);
            _ChangelogToolStripMenuItem.Text = "&Latest Release Page";
            _ChangelogToolStripMenuItem.Click += ChangelogToolStripMenuItem_Click;
            // 
            // _ToolStripSeparator10
            // 
            _ToolStripSeparator10.Name = "_ToolStripSeparator10";
            _ToolStripSeparator10.Size = new Size(208, 6);
            // 
            // _OpenGenieDiscordToolStripMenuItem
            // 
            _OpenGenieDiscordToolStripMenuItem.Name = "_OpenGenieDiscordToolStripMenuItem";
            _OpenGenieDiscordToolStripMenuItem.Size = new Size(211, 22);
            _OpenGenieDiscordToolStripMenuItem.Text = "&Discord";
            _OpenGenieDiscordToolStripMenuItem.Click += OpenGenieDiscordToolStripMenuItem_Click;
            // 
            // OpenGenieGithubToolStripMenuItem
            // 
            OpenGenieGithubToolStripMenuItem.Name = "OpenGenieGithubToolStripMenuItem";
            OpenGenieGithubToolStripMenuItem.Size = new Size(211, 22);
            OpenGenieGithubToolStripMenuItem.Text = "GitHub";
            OpenGenieGithubToolStripMenuItem.Click += OpenGenieGithubToolStripMenuItem_Click;
            // 
            // _OpenGenieDocsToolStripMenuItem
            // 
            _OpenGenieDocsToolStripMenuItem.Name = "_OpenGenieDocsToolStripMenuItem";
            _OpenGenieDocsToolStripMenuItem.Size = new Size(211, 22);
            _OpenGenieDocsToolStripMenuItem.Text = "&Wiki";
            _OpenGenieDocsToolStripMenuItem.Click += OpenGenieWikiToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(208, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { playnetToolStripMenuItem, elanthipediaToolStripMenuItem1, dRServiceToolStripMenuItem, lichDiscordToolStripMenuItem, isharonsGenieSettingsToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(211, 22);
            toolStripMenuItem1.Text = "Community Links";
            // 
            // playnetToolStripMenuItem
            // 
            playnetToolStripMenuItem.Name = "playnetToolStripMenuItem";
            playnetToolStripMenuItem.Size = new Size(199, 22);
            playnetToolStripMenuItem.Text = "Play.net";
            playnetToolStripMenuItem.Click += playnetToolStripMenuItem_Click;
            // 
            // elanthipediaToolStripMenuItem1
            // 
            elanthipediaToolStripMenuItem1.Name = "elanthipediaToolStripMenuItem1";
            elanthipediaToolStripMenuItem1.Size = new Size(199, 22);
            elanthipediaToolStripMenuItem1.Text = "Elanthipedia";
            elanthipediaToolStripMenuItem1.Click += elanthipediaToolStripMenuItem1_Click;
            // 
            // dRServiceToolStripMenuItem
            // 
            dRServiceToolStripMenuItem.Name = "dRServiceToolStripMenuItem";
            dRServiceToolStripMenuItem.Size = new Size(199, 22);
            dRServiceToolStripMenuItem.Text = "DR Service";
            dRServiceToolStripMenuItem.Click += dRServiceToolStripMenuItem_Click;
            // 
            // lichDiscordToolStripMenuItem
            // 
            lichDiscordToolStripMenuItem.Name = "lichDiscordToolStripMenuItem";
            lichDiscordToolStripMenuItem.Size = new Size(199, 22);
            lichDiscordToolStripMenuItem.Text = "Lich Discord";
            lichDiscordToolStripMenuItem.Click += lichDiscordToolStripMenuItem_Click;
            // 
            // isharonsGenieSettingsToolStripMenuItem
            // 
            isharonsGenieSettingsToolStripMenuItem.Name = "isharonsGenieSettingsToolStripMenuItem";
            isharonsGenieSettingsToolStripMenuItem.Size = new Size(199, 22);
            isharonsGenieSettingsToolStripMenuItem.Text = "Isharon's Genie Settings";
            isharonsGenieSettingsToolStripMenuItem.Click += isharonsGenieSettingsToolStripMenuItem_Click;
            // 
            // _LabelSpellC
            // 
            _LabelSpellC.Dock = DockStyle.Fill;
            _LabelSpellC.ForeColor = Color.White;
            _LabelSpellC.Location = new Point(925, 0);
            _LabelSpellC.Margin = new Padding(0);
            _LabelSpellC.Name = "_LabelSpellC";
            _LabelSpellC.Size = new Size(242, 43);
            _LabelSpellC.TabIndex = 12;
            _LabelSpellC.Text = "None";
            _LabelSpellC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _LabelRHC
            // 
            _LabelRHC.Dock = DockStyle.Fill;
            _LabelRHC.ForeColor = Color.White;
            _LabelRHC.Location = new Point(673, 0);
            _LabelRHC.Margin = new Padding(0);
            _LabelRHC.Name = "_LabelRHC";
            _LabelRHC.Size = new Size(240, 43);
            _LabelRHC.TabIndex = 11;
            _LabelRHC.Text = "Empty";
            _LabelRHC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _LabelLHC
            // 
            _LabelLHC.Dock = DockStyle.Fill;
            _LabelLHC.ForeColor = Color.White;
            _LabelLHC.Location = new Point(420, 0);
            _LabelLHC.Margin = new Padding(0);
            _LabelLHC.Name = "_LabelLHC";
            _LabelLHC.Size = new Size(241, 43);
            _LabelLHC.TabIndex = 10;
            _LabelLHC.Text = "Empty";
            _LabelLHC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _LabelSpell
            // 
            _LabelSpell.Dock = DockStyle.Fill;
            _LabelSpell.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            _LabelSpell.ForeColor = Color.DimGray;
            _LabelSpell.Location = new Point(913, 0);
            _LabelSpell.Margin = new Padding(0);
            _LabelSpell.Name = "_LabelSpell";
            _LabelSpell.Size = new Size(12, 43);
            _LabelSpell.TabIndex = 9;
            _LabelSpell.Text = "S";
            _LabelSpell.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _LabelRH
            // 
            _LabelRH.Dock = DockStyle.Fill;
            _LabelRH.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            _LabelRH.ForeColor = Color.DimGray;
            _LabelRH.Location = new Point(661, 0);
            _LabelRH.Margin = new Padding(0);
            _LabelRH.Name = "_LabelRH";
            _LabelRH.Size = new Size(12, 43);
            _LabelRH.TabIndex = 8;
            _LabelRH.Text = "R";
            _LabelRH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _LabelLH
            // 
            _LabelLH.Dock = DockStyle.Fill;
            _LabelLH.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            _LabelLH.ForeColor = Color.DimGray;
            _LabelLH.Location = new Point(408, 0);
            _LabelLH.Margin = new Padding(0);
            _LabelLH.Name = "_LabelLH";
            _LabelLH.Size = new Size(12, 43);
            _LabelLH.TabIndex = 7;
            _LabelLH.Text = "L";
            _LabelLH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _LabelRT
            // 
            _LabelRT.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            _LabelRT.ForeColor = Color.DimGray;
            _LabelRT.Location = new Point(1, 0);
            _LabelRT.Margin = new Padding(4, 0, 4, 0);
            _LabelRT.Name = "_LabelRT";
            _LabelRT.Size = new Size(12, 37);
            _LabelRT.TabIndex = 6;
            _LabelRT.Text = "RT";
            _LabelRT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _PanelBars
            // 
            _PanelBars.BackColor = Color.Black;
            _PanelBars.Controls.Add(_TableLayoutPanelBars);
            _PanelBars.Dock = DockStyle.Bottom;
            _PanelBars.Location = new Point(0, 724);
            _PanelBars.Margin = new Padding(4, 3, 4, 3);
            _PanelBars.Name = "_PanelBars";
            _PanelBars.Size = new Size(1449, 20);
            _PanelBars.TabIndex = 10;
            // 
            // _TableLayoutPanelBars
            // 
            _TableLayoutPanelBars.ColumnCount = 5;
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsConc, 1, 0);
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsFatigue, 2, 0);
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsMana, 0, 0);
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsSpirit, 3, 0);
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsHealth, 0, 0);
            _TableLayoutPanelBars.Dock = DockStyle.Fill;
            _TableLayoutPanelBars.Location = new Point(0, 0);
            _TableLayoutPanelBars.Margin = new Padding(0);
            _TableLayoutPanelBars.Name = "_TableLayoutPanelBars";
            _TableLayoutPanelBars.RowCount = 1;
            _TableLayoutPanelBars.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _TableLayoutPanelBars.Size = new Size(1449, 20);
            _TableLayoutPanelBars.TabIndex = 0;
            // 
            // _ComponentBarsConc
            // 
            _ComponentBarsConc.BackColor = Color.Black;
            _ComponentBarsConc.BackgroundColor = Color.FromArgb(0, 64, 64);
            _ComponentBarsConc.BarText = "Concentration";
            _ComponentBarsConc.BorderColor = Color.FromArgb(0, 64, 64);
            _ComponentBarsConc.Dock = DockStyle.Fill;
            _ComponentBarsConc.ForegroundColor = Color.Teal;
            _ComponentBarsConc.IsConnected = false;
            _ComponentBarsConc.Location = new Point(578, 0);
            _ComponentBarsConc.Margin = new Padding(0);
            _ComponentBarsConc.Name = "_ComponentBarsConc";
            _ComponentBarsConc.Size = new Size(289, 20);
            _ComponentBarsConc.TabIndex = 20;
            _ComponentBarsConc.Value = 100;
            // 
            // _ComponentBarsFatigue
            // 
            _ComponentBarsFatigue.BackColor = Color.Black;
            _ComponentBarsFatigue.BackgroundColor = Color.FromArgb(0, 64, 0);
            _ComponentBarsFatigue.BarText = "Stamina";
            _ComponentBarsFatigue.BorderColor = Color.FromArgb(0, 64, 0);
            _ComponentBarsFatigue.Dock = DockStyle.Fill;
            _ComponentBarsFatigue.ForegroundColor = Color.Green;
            _ComponentBarsFatigue.IsConnected = false;
            _ComponentBarsFatigue.Location = new Point(867, 0);
            _ComponentBarsFatigue.Margin = new Padding(0);
            _ComponentBarsFatigue.Name = "_ComponentBarsFatigue";
            _ComponentBarsFatigue.Size = new Size(289, 20);
            _ComponentBarsFatigue.TabIndex = 17;
            _ComponentBarsFatigue.Value = 100;
            // 
            // _ComponentBarsMana
            // 
            _ComponentBarsMana.BackColor = Color.Black;
            _ComponentBarsMana.BackgroundColor = Color.FromArgb(0, 0, 64);
            _ComponentBarsMana.BarText = "Mana";
            _ComponentBarsMana.BorderColor = Color.FromArgb(0, 0, 64);
            _ComponentBarsMana.Dock = DockStyle.Fill;
            _ComponentBarsMana.ForegroundColor = Color.Navy;
            _ComponentBarsMana.IsConnected = false;
            _ComponentBarsMana.Location = new Point(289, 0);
            _ComponentBarsMana.Margin = new Padding(0);
            _ComponentBarsMana.Name = "_ComponentBarsMana";
            _ComponentBarsMana.Size = new Size(289, 20);
            _ComponentBarsMana.TabIndex = 19;
            _ComponentBarsMana.Value = 100;
            // 
            // _ComponentBarsSpirit
            // 
            _ComponentBarsSpirit.BackColor = Color.Black;
            _ComponentBarsSpirit.BackgroundColor = Color.FromArgb(64, 0, 64);
            _ComponentBarsSpirit.BarText = "Spirit";
            _ComponentBarsSpirit.BorderColor = Color.FromArgb(64, 0, 64);
            _ComponentBarsSpirit.Dock = DockStyle.Fill;
            _ComponentBarsSpirit.ForegroundColor = Color.Purple;
            _ComponentBarsSpirit.IsConnected = false;
            _ComponentBarsSpirit.Location = new Point(1156, 0);
            _ComponentBarsSpirit.Margin = new Padding(0);
            _ComponentBarsSpirit.Name = "_ComponentBarsSpirit";
            _ComponentBarsSpirit.Size = new Size(293, 20);
            _ComponentBarsSpirit.TabIndex = 18;
            _ComponentBarsSpirit.Value = 100;
            // 
            // _ComponentBarsHealth
            // 
            _ComponentBarsHealth.BackColor = Color.Black;
            _ComponentBarsHealth.BackgroundColor = Color.FromArgb(64, 0, 0);
            _ComponentBarsHealth.BarText = "Health";
            _ComponentBarsHealth.BorderColor = Color.FromArgb(64, 0, 0);
            _ComponentBarsHealth.Dock = DockStyle.Fill;
            _ComponentBarsHealth.ForegroundColor = Color.Maroon;
            _ComponentBarsHealth.IsConnected = false;
            _ComponentBarsHealth.Location = new Point(0, 0);
            _ComponentBarsHealth.Margin = new Padding(0);
            _ComponentBarsHealth.Name = "_ComponentBarsHealth";
            _ComponentBarsHealth.Size = new Size(289, 20);
            _ComponentBarsHealth.TabIndex = 0;
            _ComponentBarsHealth.Value = 100;
            // 
            // _PanelStatus
            // 
            _PanelStatus.BackColor = Color.Black;
            _PanelStatus.Controls.Add(_Castbar);
            _PanelStatus.Controls.Add(_TableLayoutPanelFlow);
            _PanelStatus.Dock = DockStyle.Bottom;
            _PanelStatus.Location = new Point(0, 658);
            _PanelStatus.Margin = new Padding(0);
            _PanelStatus.Name = "_PanelStatus";
            _PanelStatus.Size = new Size(1449, 43);
            _PanelStatus.TabIndex = 12;
            _PanelStatus.Visible = false;
            // 
            // _TableLayoutPanelFlow
            // 
            _TableLayoutPanelFlow.BackColor = Color.Transparent;
            _TableLayoutPanelFlow.ColumnCount = 7;
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 408F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _TableLayoutPanelFlow.Controls.Add(_LabelSpellC, 6, 0);
            _TableLayoutPanelFlow.Controls.Add(_PanelFixed, 0, 0);
            _TableLayoutPanelFlow.Controls.Add(_LabelSpell, 5, 0);
            _TableLayoutPanelFlow.Controls.Add(_LabelRHC, 4, 0);
            _TableLayoutPanelFlow.Controls.Add(_LabelLH, 1, 0);
            _TableLayoutPanelFlow.Controls.Add(_LabelLHC, 2, 0);
            _TableLayoutPanelFlow.Controls.Add(_LabelRH, 3, 0);
            _TableLayoutPanelFlow.Dock = DockStyle.Fill;
            _TableLayoutPanelFlow.Location = new Point(0, 0);
            _TableLayoutPanelFlow.Margin = new Padding(0);
            _TableLayoutPanelFlow.MaximumSize = new Size(1167, 115);
            _TableLayoutPanelFlow.Name = "_TableLayoutPanelFlow";
            _TableLayoutPanelFlow.RowCount = 1;
            _TableLayoutPanelFlow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _TableLayoutPanelFlow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _TableLayoutPanelFlow.Size = new Size(1167, 43);
            _TableLayoutPanelFlow.TabIndex = 0;
            // 
            // _PanelFixed
            // 
            _PanelFixed.BackColor = Color.Black;
            _PanelFixed.Controls.Add(_oRTControl);
            _PanelFixed.Controls.Add(_IconBar);
            _PanelFixed.Controls.Add(_LabelRT);
            _PanelFixed.Dock = DockStyle.Fill;
            _PanelFixed.Location = new Point(2, 2);
            _PanelFixed.Margin = new Padding(2);
            _PanelFixed.Name = "_PanelFixed";
            _PanelFixed.Size = new Size(404, 39);
            _PanelFixed.TabIndex = 13;
            // 
            // _oRTControl
            // 
            _oRTControl.BackColor = Color.Black;
            _oRTControl.BackgroundColor = Color.Black;
            _oRTControl.BackgroundColorRT = Color.FromArgb(0, 0, 75);
            _oRTControl.BorderColor = Color.FromArgb(64, 64, 64);
            _oRTControl.BorderColorRT = Color.White;
            _oRTControl.ForegroundColor = Color.MediumBlue;
            _oRTControl.IsConnected = false;
            _oRTControl.Location = new Point(16, 3);
            _oRTControl.Margin = new Padding(5);
            _oRTControl.Name = "_oRTControl";
            _oRTControl.Size = new Size(117, 30);
            _oRTControl.TabIndex = 0;
            // 
            // _IconBar
            // 
            _IconBar.BackColor = Color.Transparent;
            _IconBar.Globals = null;
            _IconBar.IsConnected = false;
            _IconBar.Location = new Point(136, 0);
            _IconBar.Margin = new Padding(0);
            _IconBar.Name = "_IconBar";
            _IconBar.Size = new Size(262, 37);
            _IconBar.TabIndex = 0;
            // 
            // _ToolStripButtons
            // 
            _ToolStripButtons.BackColor = SystemColors.Control;
            _ToolStripButtons.ContextMenuStrip = _ContextMenuStripButtons;
            _ToolStripButtons.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripButtons.Location = new Point(0, 24);
            _ToolStripButtons.Name = "_ToolStripButtons";
            _ToolStripButtons.RenderMode = ToolStripRenderMode.System;
            _ToolStripButtons.Size = new Size(1449, 25);
            _ToolStripButtons.TabIndex = 14;
            _ToolStripButtons.VisibleChanged += ToolStripButtons_VisibleChanged;
            // 
            // _ContextMenuStripButtons
            // 
            _ContextMenuStripButtons.Name = "ContextMenuStripButtons";
            _ContextMenuStripButtons.Size = new Size(61, 4);
            // 
            // _TimerReconnect
            // 
            _TimerReconnect.Enabled = true;
            _TimerReconnect.Interval = 1000;
            _TimerReconnect.Tick += TimerReconnect_Tick;
            // 
            // _OpenFileDialogLayout
            // 
            _OpenFileDialogLayout.DefaultExt = "layout";
            _OpenFileDialogLayout.Filter = "Genie Layout|*.layout|All files|*.*";
            _OpenFileDialogLayout.RestoreDirectory = true;
            _OpenFileDialogLayout.Title = "Open Layout";
            // 
            // _SaveFileDialogLayout
            // 
            _SaveFileDialogLayout.DefaultExt = "layout";
            _SaveFileDialogLayout.Filter = "Genie Layout|*.layout|All files|*.*";
            _SaveFileDialogLayout.RestoreDirectory = true;
            _SaveFileDialogLayout.Title = "Save Layout";
            // 
            // _TimerBgWorker
            // 
            _TimerBgWorker.Interval = 10;
            _TimerBgWorker.Tick += TimerBgWorker_Tick;
            // 
            // _PanelInput
            // 
            _PanelInput.BackColor = Color.Transparent;
            _PanelInput.Controls.Add(_TextBoxInput);
            _PanelInput.Dock = DockStyle.Bottom;
            _PanelInput.Location = new Point(0, 701);
            _PanelInput.Margin = new Padding(0);
            _PanelInput.Name = "_PanelInput";
            _PanelInput.Padding = new Padding(4, 2, 0, 0);
            _PanelInput.Size = new Size(1449, 23);
            _PanelInput.TabIndex = 0;
            // 
            // _TextBoxInput
            // 
            _TextBoxInput.AcceptsTab = true;
            _TextBoxInput.BackColor = Color.White;
            _TextBoxInput.BorderStyle = BorderStyle.None;
            _TextBoxInput.Dock = DockStyle.Fill;
            _TextBoxInput.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            _TextBoxInput.HideSelection = false;
            _TextBoxInput.KeepInput = false;
            _TextBoxInput.Location = new Point(4, 2);
            _TextBoxInput.Margin = new Padding(4, 3, 4, 3);
            _TextBoxInput.Multiline = true;
            _TextBoxInput.Name = "_TextBoxInput";
            _TextBoxInput.Size = new Size(1445, 21);
            _TextBoxInput.TabIndex = 0;
            _TextBoxInput.WordWrap = false;
            _TextBoxInput.SendText += TextBoxInput_SendText;
            _TextBoxInput.PageUp += TextBoxInput_PageUp;
            _TextBoxInput.PageDown += TextBoxInput_PageDown;
            _TextBoxInput.CtrlPageUp += TextBoxInput_CtrlPageUp;
            _TextBoxInput.CtrlPageDown += TextBoxInput_CtrlPageDown;
            _TextBoxInput.KeyDown += TextBoxInput_KeyDown;
            // 
            // _OpenFileDialogProfile
            // 
            _OpenFileDialogProfile.DefaultExt = "layout";
            _OpenFileDialogProfile.Filter = "Genie Profile|*.xml|All files|*.*";
            _OpenFileDialogProfile.RestoreDirectory = true;
            _OpenFileDialogProfile.Title = "Open Profile";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1449, 768);
            Controls.Add(_PanelStatus);
            Controls.Add(_PanelInput);
            Controls.Add(_PanelBars);
            Controls.Add(_ToolStripButtons);
            Controls.Add(_StatusStripMain);
            Controls.Add(_MenuStripMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            KeyPreview = true;
            MainMenuStrip = _MenuStripMain;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormMain";
            Text = "Genie";
            WindowState = FormWindowState.Maximized;
            Activated += FormMain_Activated;
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            ResizeEnd += FormMain_SizeChange;
            KeyDown += FormMain_KeyDown;
            Resize += FormMain_SizeChange;
            _StatusStripMain.ResumeLayout(false);
            _StatusStripMain.PerformLayout();
            _MenuStripMain.ResumeLayout(false);
            _MenuStripMain.PerformLayout();
            _PanelBars.ResumeLayout(false);
            _TableLayoutPanelBars.ResumeLayout(false);
            _PanelStatus.ResumeLayout(false);
            _TableLayoutPanelFlow.ResumeLayout(false);
            _PanelFixed.ResumeLayout(false);
            _PanelInput.ResumeLayout(false);
            _PanelInput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem autoUpdateLampToolStripMenuItem;
        private ToolStripMenuItem checkUpdatesOnStartupToolStripMenuItem;
        private ToolStripMenuItem loadTestClientToolStripMenuItem;
        private ToolStripMenuItem updateMapsToolStripMenuItem;
        private ToolStripMenuItem updatePluginsToolStripMenuItem;
        private ToolStripMenuItem updateScriptsToolStripMenuItem;
        private ToolStripMenuItem genieToolStripMenuItem;
        private ToolStripMenuItem scriptsToolStripMenuItem;
        private ToolStripMenuItem mapsToolStripMenuItem;
        private ToolStripMenuItem pluginsToolStripMenuItem;
        private ToolStripMenuItem logsToolStripMenuItem;
        private global::System.Windows.Forms.ToolStripMenuItem ClassicConnectToolStripMenuItem;
        private ToolStripMenuItem _ImagesEnabledToolStripMenuItem;
        private ToolStripMenuItem UpdateImagesToolStripMenuItem;
        private ToolStripMenuItem artToolStripMenuItem;
        private ToolStripMenuItem alignInputToGameWindowToolStripMenuItem;
        private ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;

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
