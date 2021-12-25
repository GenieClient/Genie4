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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
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
            _ConnectToolStripMenuItem.Click += new EventHandler(ConnectToolStripMenuItem_Click);
            _ConnectToolStripMenuItemConnectDialog = new ToolStripMenuItem();
            _ConnectToolStripMenuItemConnectDialog.Click += new EventHandler(ConnectToolStripMenuItemConnectDialog_Click);
            _ToolStripSeparator7 = new ToolStripSeparator();
            _OpenUserDataDirectoryToolStripMenuItem = new ToolStripMenuItem();
            _OpenUserDataDirectoryToolStripMenuItem.Click += new EventHandler(OpenUserDataDirectoryToolStripMenuItem_Click);
            _ToolStripMenuItem4 = new ToolStripSeparator();
            _AutoLogToolStripMenuItem = new ToolStripMenuItem();
            _AutoLogToolStripMenuItem.Click += new EventHandler(AutoLogToolStripMenuItem_Click);
            _OpenLogInEditorToolStripMenuItem = new ToolStripMenuItem();
            _OpenLogInEditorToolStripMenuItem.Click += new EventHandler(OpenLogInEditorToolStripMenuItem_Click);
            _ToolStripSeparator13 = new ToolStripSeparator();
            _AutoReconnectToolStripMenuItem = new ToolStripMenuItem();
            _AutoReconnectToolStripMenuItem.Click += new EventHandler(AutoReconnectToolStripMenuItem_Click);
            _IgnoresEnabledToolStripMenuItem = new ToolStripMenuItem();
            _IgnoresEnabledToolStripMenuItem.Click += new EventHandler(IgnoresEnabledToolStripMenuItem_Click);
            _ToolStripMenuItemTriggers = new ToolStripMenuItem();
            _ToolStripMenuItemTriggers.Click += new EventHandler(ToolStripMenuItemTriggers_Click);
            _PluginsEnabledToolStripMenuItem = new ToolStripMenuItem();
            _PluginsEnabledToolStripMenuItem.Click += new EventHandler(PluginsEnabledToolStripMenuItem_Click);
            _AutoMapperEnabledToolStripMenuItem = new ToolStripMenuItem();
            _AutoMapperEnabledToolStripMenuItem.Click += new EventHandler(AutoMapperEnabledToolStripMenuItem_Click);
            _MuteSoundsToolStripMenuItem = new ToolStripMenuItem();
            _MuteSoundsToolStripMenuItem.Click += new EventHandler(MuteSoundsToolStripMenuItem_Click);
            _ToolStripSeparator8 = new ToolStripSeparator();
            _ToolStripMenuItemShowXML = new ToolStripMenuItem();
            _ToolStripMenuItemShowXML.Click += new EventHandler(ToolStripMenuItemShowXML_Click);
            _ToolStripMenuItem1 = new ToolStripMenuItem();
            _ToolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click);
            _ToolStripSeparator1 = new ToolStripSeparator();
            _ExitToolStripMenuItem = new ToolStripMenuItem();
            _ExitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem_Click);
            _EditToolStripMenuItem = new ToolStripMenuItem();
            _ToolStripMenuItemSpecialPaste = new ToolStripMenuItem();
            _ToolStripMenuItemSpecialPaste.Click += new EventHandler(ToolStripMenuItemSpecialPaste_Click);
            _ToolStripSeparator6 = new ToolStripSeparator();
            _ConfigurationToolStripMenuItem = new ToolStripMenuItem();
            _ConfigurationToolStripMenuItem.Click += new EventHandler(ConfigurationToolStripMenuItem_Click);
            _ProfileToolStripMenuItem = new ToolStripMenuItem();
            _LoadProfileToolStripMenuItem = new ToolStripMenuItem();
            _LoadProfileToolStripMenuItem.Click += new EventHandler(LoadProfileToolStripMenuItem_Click);
            _SaveProfileToolStripMenuItem = new ToolStripMenuItem();
            _SaveProfileToolStripMenuItem.Click += new EventHandler(SaveProfileToolStripMenuItem_Click);
            _ToolStripMenuItem2 = new ToolStripSeparator();
            _SavePasswordToolStripMenuItem = new ToolStripMenuItem();
            _SavePasswordToolStripMenuItem.Click += new EventHandler(SavePasswordToolStripMenuItem_Click);
            _LayoutToolStripMenuItem = new ToolStripMenuItem();
            _LoadSettingsOpenToolStripMenuItem = new ToolStripMenuItem();
            _LoadSettingsOpenToolStripMenuItem.Click += new EventHandler(LoadSettingsOpenToolStripMenuItem_Click);
            _LoadSettingsToolStripMenuItem = new ToolStripMenuItem();
            _LoadSettingsToolStripMenuItem.Click += new EventHandler(LoadSettingsToolStripMenuItem_Click);
            _ToolStripSeparator12 = new ToolStripSeparator();
            _SaveSettingsToolStripMenuItem1 = new ToolStripMenuItem();
            _SaveSettingsToolStripMenuItem1.Click += new EventHandler(SaveSettingsToolStripMenuItem1_Click);
            _SaveSettingsToolStripMenuItem = new ToolStripMenuItem();
            _SaveSettingsToolStripMenuItem.Click += new EventHandler(SaveSettingsToolStripMenuItem_Click);
            _SaveSizedDefaultLayoutToolStripMenuItem = new ToolStripMenuItem();
            _SaveSizedDefaultLayoutToolStripMenuItem.Click += new EventHandler(SaveSizedDefaultLayoutToolStripMenuItem_Click);
            _ToolStripSeparator5 = new ToolStripSeparator();
            _BasicToolStripMenuItem = new ToolStripMenuItem();
            _BasicToolStripMenuItem.Click += new EventHandler(BasicToolStripMenuItem_Click);
            _ToolStripSeparator4 = new ToolStripSeparator();
            _IconBarToolStripMenuItem = new ToolStripMenuItem();
            _IconBarToolStripMenuItem.Click += new EventHandler(IconBarToolStripMenuItem_Click);
            _DockTopToolStripMenuItem = new ToolStripMenuItem();
            _DockTopToolStripMenuItem.Click += new EventHandler(DockTopToolStripMenuItem_Click);
            _DockBottomToolStripMenuItem = new ToolStripMenuItem();
            _DockBottomToolStripMenuItem.Click += new EventHandler(DockBottomToolStripMenuItem_Click);
            _ShowScriptBarToolStripMenuItem = new ToolStripMenuItem();
            _ShowScriptBarToolStripMenuItem.Click += new EventHandler(ShowScriptBarToolStripMenuItem_Click);
            _DockTopToolStripMenuItem1 = new ToolStripMenuItem();
            _DockTopToolStripMenuItem1.Click += new EventHandler(DockTopToolStripMenuItem1_Click);
            _DockBottomToolStripMenuItem1 = new ToolStripMenuItem();
            _DockBottomToolStripMenuItem1.Click += new EventHandler(DockBottomToolStripMenuItem1_Click);
            _HealthBarToolStripMenuItem = new ToolStripMenuItem();
            _HealthBarToolStripMenuItem.Click += new EventHandler(HealthBarToolStripMenuItem_Click);
            _DockTopToolStripMenuItem2 = new ToolStripMenuItem();
            _DockTopToolStripMenuItem2.Click += new EventHandler(DockTopToolStripMenuItem2_Click);
            _DockBottomToolStripMenuItem2 = new ToolStripMenuItem();
            _DockBottomToolStripMenuItem2.Click += new EventHandler(DockBottomToolStripMenuItem2_Click);
            _MagicPanelsToolStripMenuItem = new ToolStripMenuItem();
            _MagicPanelsToolStripMenuItem.Click += new EventHandler(MagicPanelsToolStripMenuItem_Click);
            _StatusBarToolStripMenuItem = new ToolStripMenuItem();
            _StatusBarToolStripMenuItem.Click += new EventHandler(StatusBarToolStripMenuItem_Click);
            _WindowToolStripMenuItem = new ToolStripMenuItem();
            _ScriptToolStripMenuItem = new ToolStripMenuItem();
            _ScriptExplorerToolStripMenuItem = new ToolStripMenuItem();
            _ScriptExplorerToolStripMenuItem.Click += new EventHandler(ScriptExplorerToolStripMenuItem_Click);
            _ToolStripSeparator11 = new ToolStripSeparator();
            _ListAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _ListAllScriptsToolStripMenuItem.Click += new EventHandler(ListAllScriptsToolStripMenuItem_Click);
            _TraceAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _TraceAllScriptsToolStripMenuItem.Click += new EventHandler(TraceAllScriptsToolStripMenuItem_Click);
            _ToolStripSeparator9 = new ToolStripSeparator();
            _PauseAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _PauseAllScriptsToolStripMenuItem.Click += new EventHandler(PauseAllScriptsToolStripMenuItem_Click);
            _ResumeAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _ResumeAllScriptsToolStripMenuItem.Click += new EventHandler(ResumeAllScriptsToolStripMenuItem_Click);
            _ToolStripMenuItem3 = new ToolStripSeparator();
            _AbortAllScriptsToolStripMenuItem = new ToolStripMenuItem();
            _AbortAllScriptsToolStripMenuItem.Click += new EventHandler(AbortAllScriptsToolStripMenuItem_Click);
            _AutoMapperToolStripMenuItem = new ToolStripMenuItem();
            _ShowWindowToolStripMenuItem = new ToolStripMenuItem();
            _ShowWindowToolStripMenuItem.Click += new EventHandler(ShowWindowToolStripMenuItem_Click);
            _PluginsToolStripMenuItem = new ToolStripMenuItem();
            _NoPluginsLoadedToolStripMenuItem = new ToolStripMenuItem();
            _HelpToolStripMenuItem = new ToolStripMenuItem();
            _EnterGenieKeyToolStripMenuItem = new ToolStripMenuItem();
            _EnterGenieKeyToolStripMenuItem.Click += new EventHandler(EnterGenieKeyToolStripMenuItem_Click);
            _ToolStripSeparator3 = new ToolStripSeparator();
            _CheckForNewVersionToolStripMenuItem = new ToolStripMenuItem();
            _CheckForNewVersionToolStripMenuItem.Click += new EventHandler(CheckForNewVersionToolStripMenuItem_Click);
            _ToolStripSeparator2 = new ToolStripSeparator();
            _ChangelogToolStripMenuItem = new ToolStripMenuItem();
            _ChangelogToolStripMenuItem.Click += new EventHandler(ChangelogToolStripMenuItem_Click);
            _ToolStripSeparator10 = new ToolStripSeparator();
            _OpenGenieForumToolStripMenuItem = new ToolStripMenuItem();
            _OpenGenieForumToolStripMenuItem.Click += new EventHandler(OpenGenieForumToolStripMenuItem_Click);
            _OpenGenieDocsToolStripMenuItem = new ToolStripMenuItem();
            _OpenGenieDocsToolStripMenuItem.Click += new EventHandler(OpenGenieWikiToolStripMenuItem_Click);
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
            _ToolStripButtons.VisibleChanged += new EventHandler(ToolStripButtons_VisibleChanged);
            _ContextMenuStripButtons = new ContextMenuStrip(components);
            _TimerReconnect = new Timer(components);
            _TimerReconnect.Tick += new EventHandler(TimerReconnect_Tick);
            _OpenFileDialogLayout = new OpenFileDialog();
            _SaveFileDialogLayout = new SaveFileDialog();
            _TimerBgWorker = new Timer(components);
            _TimerBgWorker.Tick += new EventHandler(TimerBgWorker_Tick);
            _PanelInput = new Panel();
            _TextBoxInput = new ComponentTextBox();
            _TextBoxInput.KeyDown += new KeyEventHandler(TextBoxInput_KeyDown);
            _TextBoxInput.SendText += new ComponentTextBox.SendTextEventHandler(TextBoxInput_SendText);
            _TextBoxInput.PageUp += new ComponentTextBox.PageUpEventHandler(TextBoxInput_PageUp);
            _TextBoxInput.PageDown += new ComponentTextBox.PageDownEventHandler(TextBoxInput_PageDown);
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
            // StatusStripMain
            // 
            _StatusStripMain.BackColor = SystemColors.Control;
            _StatusStripMain.GripStyle = ToolStripGripStyle.Visible;
            _StatusStripMain.Items.AddRange(new ToolStripItem[] { _ToolStripStatusLabel1, _ToolStripStatusLabel2, _ToolStripStatusLabel3, _ToolStripStatusLabel4, _ToolStripStatusLabel5, _ToolStripStatusLabel6, _ToolStripStatusLabel7, _ToolStripStatusLabel8, _ToolStripStatusLabel9, _ToolStripStatusLabel10 });
            _StatusStripMain.Location = new Point(0, 644);
            _StatusStripMain.Name = "StatusStripMain";
            _StatusStripMain.Size = new Size(985, 22);
            _StatusStripMain.TabIndex = 2;
            // 
            // ToolStripStatusLabel1
            // 
            _ToolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel1.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            _ToolStripStatusLabel1.Size = new Size(970, 17);
            _ToolStripStatusLabel1.Spring = true;
            _ToolStripStatusLabel1.Text = "Ready";
            _ToolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolStripStatusLabel2
            // 
            _ToolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel2.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            _ToolStripStatusLabel2.Size = new Size(4, 19);
            _ToolStripStatusLabel2.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel2.Visible = false;
            // 
            // ToolStripStatusLabel3
            // 
            _ToolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel3.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            _ToolStripStatusLabel3.Size = new Size(4, 17);
            _ToolStripStatusLabel3.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel3.Visible = false;
            // 
            // ToolStripStatusLabel4
            // 
            _ToolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel4.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            _ToolStripStatusLabel4.Size = new Size(4, 17);
            _ToolStripStatusLabel4.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel4.Visible = false;
            // 
            // ToolStripStatusLabel5
            // 
            _ToolStripStatusLabel5.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel5.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            _ToolStripStatusLabel5.Size = new Size(4, 17);
            _ToolStripStatusLabel5.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel5.Visible = false;
            // 
            // ToolStripStatusLabel6
            // 
            _ToolStripStatusLabel6.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel6.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            _ToolStripStatusLabel6.Size = new Size(4, 17);
            _ToolStripStatusLabel6.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel6.Visible = false;
            // 
            // ToolStripStatusLabel7
            // 
            _ToolStripStatusLabel7.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel7.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel7.Name = "ToolStripStatusLabel7";
            _ToolStripStatusLabel7.Size = new Size(4, 17);
            _ToolStripStatusLabel7.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel7.Visible = false;
            // 
            // ToolStripStatusLabel8
            // 
            _ToolStripStatusLabel8.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel8.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel8.Name = "ToolStripStatusLabel8";
            _ToolStripStatusLabel8.Size = new Size(4, 17);
            _ToolStripStatusLabel8.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel8.Visible = false;
            // 
            // ToolStripStatusLabel9
            // 
            _ToolStripStatusLabel9.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel9.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel9.Name = "ToolStripStatusLabel9";
            _ToolStripStatusLabel9.Size = new Size(4, 17);
            _ToolStripStatusLabel9.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel9.Visible = false;
            // 
            // ToolStripStatusLabel10
            // 
            _ToolStripStatusLabel10.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;

            _ToolStripStatusLabel10.BorderStyle = Border3DStyle.SunkenOuter;
            _ToolStripStatusLabel10.Name = "ToolStripStatusLabel10";
            _ToolStripStatusLabel10.Size = new Size(4, 17);
            _ToolStripStatusLabel10.TextAlign = ContentAlignment.MiddleLeft;
            _ToolStripStatusLabel10.Visible = false;
            // 
            // MenuStripMain
            // 
            _MenuStripMain.Items.AddRange(new ToolStripItem[] { _FileToolStripMenuItem, _EditToolStripMenuItem, _ProfileToolStripMenuItem, _LayoutToolStripMenuItem, _WindowToolStripMenuItem, _ScriptToolStripMenuItem, _AutoMapperToolStripMenuItem, _PluginsToolStripMenuItem, _HelpToolStripMenuItem });
            _MenuStripMain.Location = new Point(0, 0);
            _MenuStripMain.Name = "MenuStripMain";
            _MenuStripMain.Size = new Size(985, 24);
            _MenuStripMain.TabIndex = 1;
            _MenuStripMain.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            _FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ConnectToolStripMenuItem, _ConnectToolStripMenuItemConnectDialog, _ToolStripSeparator7, _OpenUserDataDirectoryToolStripMenuItem, _ToolStripMenuItem4, _AutoLogToolStripMenuItem, _OpenLogInEditorToolStripMenuItem, _ToolStripSeparator13, _AutoReconnectToolStripMenuItem, _IgnoresEnabledToolStripMenuItem, _ToolStripMenuItemTriggers, _PluginsEnabledToolStripMenuItem, _AutoMapperEnabledToolStripMenuItem, _MuteSoundsToolStripMenuItem, _ToolStripSeparator8, _ToolStripMenuItemShowXML, _ToolStripMenuItem1, _ToolStripSeparator1, _ExitToolStripMenuItem });
            _FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            _FileToolStripMenuItem.Size = new Size(35, 20);
            _FileToolStripMenuItem.Text = "&File";
            // 
            // ConnectToolStripMenuItem
            // 
            _ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem";
            _ConnectToolStripMenuItem.Size = new Size(210, 22);
            _ConnectToolStripMenuItem.Text = "&Connect...";
            // 
            // ConnectToolStripMenuItemConnectDialog
            // 
            _ConnectToolStripMenuItemConnectDialog.Name = "ConnectToolStripMenuItemConnectDialog";
            _ConnectToolStripMenuItemConnectDialog.Size = new Size(210, 22);
            _ConnectToolStripMenuItemConnectDialog.Text = "Connect &Using Profile...";
            // 
            // ToolStripSeparator7
            // 
            _ToolStripSeparator7.Name = "ToolStripSeparator7";
            _ToolStripSeparator7.Size = new Size(207, 6);
            // 
            // OpenUserDataDirectoryToolStripMenuItem
            // 
            _OpenUserDataDirectoryToolStripMenuItem.Name = "OpenUserDataDirectoryToolStripMenuItem";
            _OpenUserDataDirectoryToolStripMenuItem.Size = new Size(210, 22);
            _OpenUserDataDirectoryToolStripMenuItem.Text = "Open &User Data Directory...";
            // 
            // ToolStripMenuItem4
            // 
            _ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            _ToolStripMenuItem4.Size = new Size(207, 6);
            // 
            // AutoLogToolStripMenuItem
            // 
            _AutoLogToolStripMenuItem.Checked = true;
            _AutoLogToolStripMenuItem.CheckOnClick = true;
            _AutoLogToolStripMenuItem.CheckState = CheckState.Checked;
            _AutoLogToolStripMenuItem.Name = "AutoLogToolStripMenuItem";
            _AutoLogToolStripMenuItem.Size = new Size(210, 22);
            _AutoLogToolStripMenuItem.Text = "&Auto Log";
            // 
            // OpenLogInEditorToolStripMenuItem
            // 
            _OpenLogInEditorToolStripMenuItem.Name = "OpenLogInEditorToolStripMenuItem";
            _OpenLogInEditorToolStripMenuItem.Size = new Size(210, 22);
            _OpenLogInEditorToolStripMenuItem.Text = "&Open Log In Editor";
            // 
            // ToolStripSeparator13
            // 
            _ToolStripSeparator13.Name = "ToolStripSeparator13";
            _ToolStripSeparator13.Size = new Size(207, 6);
            // 
            // AutoReconnectToolStripMenuItem
            // 
            _AutoReconnectToolStripMenuItem.Checked = true;
            _AutoReconnectToolStripMenuItem.CheckOnClick = true;
            _AutoReconnectToolStripMenuItem.CheckState = CheckState.Checked;
            _AutoReconnectToolStripMenuItem.Name = "AutoReconnectToolStripMenuItem";
            _AutoReconnectToolStripMenuItem.Size = new Size(210, 22);
            _AutoReconnectToolStripMenuItem.Text = "Auto &Reconnect";
            // 
            // IgnoresEnabledToolStripMenuItem
            // 
            _IgnoresEnabledToolStripMenuItem.Checked = true;
            _IgnoresEnabledToolStripMenuItem.CheckOnClick = true;
            _IgnoresEnabledToolStripMenuItem.CheckState = CheckState.Checked;
            _IgnoresEnabledToolStripMenuItem.Name = "IgnoresEnabledToolStripMenuItem";
            _IgnoresEnabledToolStripMenuItem.Size = new Size(210, 22);
            _IgnoresEnabledToolStripMenuItem.Text = "&Ignores/Gags Enabled";
            // 
            // ToolStripMenuItemTriggers
            // 
            _ToolStripMenuItemTriggers.Checked = true;
            _ToolStripMenuItemTriggers.CheckOnClick = true;
            _ToolStripMenuItemTriggers.CheckState = CheckState.Checked;
            _ToolStripMenuItemTriggers.Name = "ToolStripMenuItemTriggers";
            _ToolStripMenuItemTriggers.Size = new Size(210, 22);
            _ToolStripMenuItemTriggers.Text = "&Triggers Enabled";
            // 
            // PluginsEnabledToolStripMenuItem
            // 
            _PluginsEnabledToolStripMenuItem.Checked = true;
            _PluginsEnabledToolStripMenuItem.CheckOnClick = true;
            _PluginsEnabledToolStripMenuItem.CheckState = CheckState.Checked;
            _PluginsEnabledToolStripMenuItem.Name = "PluginsEnabledToolStripMenuItem";
            _PluginsEnabledToolStripMenuItem.Size = new Size(210, 22);
            _PluginsEnabledToolStripMenuItem.Text = "&Plugins Enabled";
            // 
            // AutoMapperEnabledToolStripMenuItem
            // 
            _AutoMapperEnabledToolStripMenuItem.Checked = true;
            _AutoMapperEnabledToolStripMenuItem.CheckState = CheckState.Checked;
            _AutoMapperEnabledToolStripMenuItem.Name = "AutoMapperEnabledToolStripMenuItem";
            _AutoMapperEnabledToolStripMenuItem.Size = new Size(210, 22);
            _AutoMapperEnabledToolStripMenuItem.Text = "Auto&Mapper Enabled";
            // 
            // MuteSoundsToolStripMenuItem
            // 
            _MuteSoundsToolStripMenuItem.CheckOnClick = true;
            _MuteSoundsToolStripMenuItem.Name = "MuteSoundsToolStripMenuItem";
            _MuteSoundsToolStripMenuItem.Size = new Size(210, 22);
            _MuteSoundsToolStripMenuItem.Text = "&Mute Sounds";
            // 
            // ToolStripSeparator8
            // 
            _ToolStripSeparator8.Name = "ToolStripSeparator8";
            _ToolStripSeparator8.Size = new Size(207, 6);
            // 
            // ToolStripMenuItemShowXML
            // 
            _ToolStripMenuItemShowXML.CheckOnClick = true;
            _ToolStripMenuItemShowXML.Name = "ToolStripMenuItemShowXML";
            _ToolStripMenuItemShowXML.Size = new Size(210, 22);
            _ToolStripMenuItemShowXML.Text = "Show &Raw Data";
            // 
            // ToolStripMenuItem1
            // 
            _ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            _ToolStripMenuItem1.Size = new Size(210, 22);
            _ToolStripMenuItem1.Text = "P&erformace Test Parse";
            _ToolStripMenuItem1.Visible = false;
            // 
            // ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "ToolStripSeparator1";
            _ToolStripSeparator1.Size = new Size(207, 6);
            // 
            // ExitToolStripMenuItem
            // 
            _ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            _ExitToolStripMenuItem.Size = new Size(210, 22);
            _ExitToolStripMenuItem.Text = "E&xit";
            // 
            // EditToolStripMenuItem
            // 
            _EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ToolStripMenuItemSpecialPaste, _ToolStripSeparator6, _ConfigurationToolStripMenuItem });
            _EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            _EditToolStripMenuItem.Size = new Size(37, 20);
            _EditToolStripMenuItem.Text = "&Edit";
            // 
            // ToolStripMenuItemSpecialPaste
            // 
            _ToolStripMenuItemSpecialPaste.Name = "ToolStripMenuItemSpecialPaste";
            _ToolStripMenuItemSpecialPaste.Size = new Size(151, 22);
            _ToolStripMenuItemSpecialPaste.Text = "Paste &Multi Line";
            // 
            // ToolStripSeparator6
            // 
            _ToolStripSeparator6.Name = "ToolStripSeparator6";
            _ToolStripSeparator6.Size = new Size(148, 6);
            // 
            // ConfigurationToolStripMenuItem
            // 
            _ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem";
            _ConfigurationToolStripMenuItem.Size = new Size(151, 22);
            _ConfigurationToolStripMenuItem.Text = "&Configuration...";
            // 
            // ProfileToolStripMenuItem
            // 
            _ProfileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _LoadProfileToolStripMenuItem, _SaveProfileToolStripMenuItem, _ToolStripMenuItem2, _SavePasswordToolStripMenuItem });
            _ProfileToolStripMenuItem.Name = "ProfileToolStripMenuItem";
            _ProfileToolStripMenuItem.Size = new Size(49, 20);
            _ProfileToolStripMenuItem.Text = "&Profile";
            // 
            // LoadProfileToolStripMenuItem
            // 
            _LoadProfileToolStripMenuItem.Name = "LoadProfileToolStripMenuItem";
            _LoadProfileToolStripMenuItem.Size = new Size(204, 22);
            _LoadProfileToolStripMenuItem.Text = "&Load Profile...";
            // 
            // SaveProfileToolStripMenuItem
            // 
            _SaveProfileToolStripMenuItem.Name = "SaveProfileToolStripMenuItem";
            _SaveProfileToolStripMenuItem.Size = new Size(204, 22);
            _SaveProfileToolStripMenuItem.Text = "&Save Profile";
            // 
            // ToolStripMenuItem2
            // 
            _ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            _ToolStripMenuItem2.Size = new Size(201, 6);
            // 
            // SavePasswordToolStripMenuItem
            // 
            _SavePasswordToolStripMenuItem.CheckOnClick = true;
            _SavePasswordToolStripMenuItem.Name = "SavePasswordToolStripMenuItem";
            _SavePasswordToolStripMenuItem.Size = new Size(204, 22);
            _SavePasswordToolStripMenuItem.Text = "Include &Password In Profile";
            // 
            // LayoutToolStripMenuItem
            // 
            _LayoutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _LoadSettingsOpenToolStripMenuItem, _LoadSettingsToolStripMenuItem, _ToolStripSeparator12, _SaveSettingsToolStripMenuItem1, _SaveSettingsToolStripMenuItem, _SaveSizedDefaultLayoutToolStripMenuItem, _ToolStripSeparator5, _BasicToolStripMenuItem, _ToolStripSeparator4, _IconBarToolStripMenuItem, _ShowScriptBarToolStripMenuItem, _HealthBarToolStripMenuItem, _MagicPanelsToolStripMenuItem, _StatusBarToolStripMenuItem });
            _LayoutToolStripMenuItem.Name = "LayoutToolStripMenuItem";
            _LayoutToolStripMenuItem.Size = new Size(52, 20);
            _LayoutToolStripMenuItem.Text = "&Layout";
            // 
            // LoadSettingsOpenToolStripMenuItem
            // 
            _LoadSettingsOpenToolStripMenuItem.Name = "LoadSettingsOpenToolStripMenuItem";
            _LoadSettingsOpenToolStripMenuItem.Size = new Size(200, 22);
            _LoadSettingsOpenToolStripMenuItem.Text = "Load Layout...";
            // 
            // LoadSettingsToolStripMenuItem
            // 
            _LoadSettingsToolStripMenuItem.Name = "LoadSettingsToolStripMenuItem";
            _LoadSettingsToolStripMenuItem.Size = new Size(200, 22);
            _LoadSettingsToolStripMenuItem.Text = "Load Default Layout";
            // 
            // ToolStripSeparator12
            // 
            _ToolStripSeparator12.Name = "ToolStripSeparator12";
            _ToolStripSeparator12.Size = new Size(197, 6);
            // 
            // SaveSettingsToolStripMenuItem1
            // 
            _SaveSettingsToolStripMenuItem1.Name = "SaveSettingsToolStripMenuItem1";
            _SaveSettingsToolStripMenuItem1.Size = new Size(200, 22);
            _SaveSettingsToolStripMenuItem1.Text = "Save Layout As...";
            // 
            // SaveSettingsToolStripMenuItem
            // 
            _SaveSettingsToolStripMenuItem.Name = "SaveSettingsToolStripMenuItem";
            _SaveSettingsToolStripMenuItem.Size = new Size(200, 22);
            _SaveSettingsToolStripMenuItem.Text = "Save Default Layout";
            // 
            // SaveSizedDefaultLayoutToolStripMenuItem
            // 
            _SaveSizedDefaultLayoutToolStripMenuItem.Name = "SaveSizedDefaultLayoutToolStripMenuItem";
            _SaveSizedDefaultLayoutToolStripMenuItem.Size = new Size(200, 22);
            _SaveSizedDefaultLayoutToolStripMenuItem.Text = "Save Sized Default Layout";
            // 
            // ToolStripSeparator5
            // 
            _ToolStripSeparator5.Name = "ToolStripSeparator5";
            _ToolStripSeparator5.Size = new Size(197, 6);
            // 
            // BasicToolStripMenuItem
            // 
            _BasicToolStripMenuItem.Name = "BasicToolStripMenuItem";
            _BasicToolStripMenuItem.Size = new Size(200, 22);
            _BasicToolStripMenuItem.Text = "Basic Layout";
            // 
            // ToolStripSeparator4
            // 
            _ToolStripSeparator4.Name = "ToolStripSeparator4";
            _ToolStripSeparator4.Size = new Size(197, 6);
            // 
            // IconBarToolStripMenuItem
            // 
            _IconBarToolStripMenuItem.Checked = true;
            _IconBarToolStripMenuItem.CheckOnClick = true;
            _IconBarToolStripMenuItem.CheckState = CheckState.Checked;
            _IconBarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DockTopToolStripMenuItem, _DockBottomToolStripMenuItem });
            _IconBarToolStripMenuItem.Name = "IconBarToolStripMenuItem";
            _IconBarToolStripMenuItem.Size = new Size(200, 22);
            _IconBarToolStripMenuItem.Text = "Icon Bar";
            // 
            // DockTopToolStripMenuItem
            // 
            _DockTopToolStripMenuItem.Name = "DockTopToolStripMenuItem";
            _DockTopToolStripMenuItem.Size = new Size(134, 22);
            _DockTopToolStripMenuItem.Text = "Dock Top";
            // 
            // DockBottomToolStripMenuItem
            // 
            _DockBottomToolStripMenuItem.Checked = true;
            _DockBottomToolStripMenuItem.CheckState = CheckState.Checked;
            _DockBottomToolStripMenuItem.Name = "DockBottomToolStripMenuItem";
            _DockBottomToolStripMenuItem.Size = new Size(134, 22);
            _DockBottomToolStripMenuItem.Text = "Dock Bottom";
            // 
            // ShowScriptBarToolStripMenuItem
            // 
            _ShowScriptBarToolStripMenuItem.Checked = true;
            _ShowScriptBarToolStripMenuItem.CheckOnClick = true;
            _ShowScriptBarToolStripMenuItem.CheckState = CheckState.Checked;
            _ShowScriptBarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DockTopToolStripMenuItem1, _DockBottomToolStripMenuItem1 });
            _ShowScriptBarToolStripMenuItem.Name = "ShowScriptBarToolStripMenuItem";
            _ShowScriptBarToolStripMenuItem.Size = new Size(200, 22);
            _ShowScriptBarToolStripMenuItem.Text = "Script Bar";
            // 
            // DockTopToolStripMenuItem1
            // 
            _DockTopToolStripMenuItem1.Name = "DockTopToolStripMenuItem1";
            _DockTopToolStripMenuItem1.Size = new Size(134, 22);
            _DockTopToolStripMenuItem1.Text = "Dock Top";
            // 
            // DockBottomToolStripMenuItem1
            // 
            _DockBottomToolStripMenuItem1.Checked = true;
            _DockBottomToolStripMenuItem1.CheckState = CheckState.Checked;
            _DockBottomToolStripMenuItem1.Name = "DockBottomToolStripMenuItem1";
            _DockBottomToolStripMenuItem1.Size = new Size(134, 22);
            _DockBottomToolStripMenuItem1.Text = "Dock Bottom";
            // 
            // HealthBarToolStripMenuItem
            // 
            _HealthBarToolStripMenuItem.Checked = true;
            _HealthBarToolStripMenuItem.CheckOnClick = true;
            _HealthBarToolStripMenuItem.CheckState = CheckState.Checked;
            _HealthBarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _DockTopToolStripMenuItem2, _DockBottomToolStripMenuItem2 });
            _HealthBarToolStripMenuItem.Name = "HealthBarToolStripMenuItem";
            _HealthBarToolStripMenuItem.Size = new Size(200, 22);
            _HealthBarToolStripMenuItem.Text = "Health Bar";
            // 
            // DockTopToolStripMenuItem2
            // 
            _DockTopToolStripMenuItem2.Name = "DockTopToolStripMenuItem2";
            _DockTopToolStripMenuItem2.Size = new Size(134, 22);
            _DockTopToolStripMenuItem2.Text = "Dock Top";
            // 
            // DockBottomToolStripMenuItem2
            // 
            _DockBottomToolStripMenuItem2.Checked = true;
            _DockBottomToolStripMenuItem2.CheckState = CheckState.Checked;
            _DockBottomToolStripMenuItem2.Name = "DockBottomToolStripMenuItem2";
            _DockBottomToolStripMenuItem2.Size = new Size(134, 22);
            _DockBottomToolStripMenuItem2.Text = "Dock Bottom";
            // 
            // MagicPanelsToolStripMenuItem
            // 
            _MagicPanelsToolStripMenuItem.Checked = true;
            _MagicPanelsToolStripMenuItem.CheckOnClick = true;
            _MagicPanelsToolStripMenuItem.CheckState = CheckState.Checked;
            _MagicPanelsToolStripMenuItem.Name = "MagicPanelsToolStripMenuItem";
            _MagicPanelsToolStripMenuItem.Size = new Size(200, 22);
            _MagicPanelsToolStripMenuItem.Text = "Magic Panels";
            // 
            // StatusBarToolStripMenuItem
            // 
            _StatusBarToolStripMenuItem.Checked = true;
            _StatusBarToolStripMenuItem.CheckOnClick = true;
            _StatusBarToolStripMenuItem.CheckState = CheckState.Checked;
            _StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem";
            _StatusBarToolStripMenuItem.Size = new Size(200, 22);
            _StatusBarToolStripMenuItem.Text = "Status Bar";
            // 
            // WindowToolStripMenuItem
            // 
            _WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            _WindowToolStripMenuItem.Size = new Size(62, 20);
            _WindowToolStripMenuItem.Text = "&Windows";
            // 
            // ScriptToolStripMenuItem
            // 
            _ScriptToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ScriptExplorerToolStripMenuItem, _ToolStripSeparator11, _ListAllScriptsToolStripMenuItem, _TraceAllScriptsToolStripMenuItem, _ToolStripSeparator9, _PauseAllScriptsToolStripMenuItem, _ResumeAllScriptsToolStripMenuItem, _ToolStripMenuItem3, _AbortAllScriptsToolStripMenuItem });
            _ScriptToolStripMenuItem.Name = "ScriptToolStripMenuItem";
            _ScriptToolStripMenuItem.Size = new Size(46, 20);
            _ScriptToolStripMenuItem.Text = "&Script";
            // 
            // ScriptExplorerToolStripMenuItem
            // 
            _ScriptExplorerToolStripMenuItem.Name = "ScriptExplorerToolStripMenuItem";
            _ScriptExplorerToolStripMenuItem.Size = new Size(169, 22);
            _ScriptExplorerToolStripMenuItem.Text = "Script &Explorer...";
            // 
            // ToolStripSeparator11
            // 
            _ToolStripSeparator11.Name = "ToolStripSeparator11";
            _ToolStripSeparator11.Size = new Size(166, 6);
            // 
            // ListAllScriptsToolStripMenuItem
            // 
            _ListAllScriptsToolStripMenuItem.Name = "ListAllScriptsToolStripMenuItem";
            _ListAllScriptsToolStripMenuItem.Size = new Size(169, 22);
            _ListAllScriptsToolStripMenuItem.Text = "&Show Active Scripts";
            // 
            // TraceAllScriptsToolStripMenuItem
            // 
            _TraceAllScriptsToolStripMenuItem.Name = "TraceAllScriptsToolStripMenuItem";
            _TraceAllScriptsToolStripMenuItem.Size = new Size(169, 22);
            _TraceAllScriptsToolStripMenuItem.Text = "&Trace Active Scripts";
            // 
            // ToolStripSeparator9
            // 
            _ToolStripSeparator9.Name = "ToolStripSeparator9";
            _ToolStripSeparator9.Size = new Size(166, 6);
            // 
            // PauseAllScriptsToolStripMenuItem
            // 
            _PauseAllScriptsToolStripMenuItem.Name = "PauseAllScriptsToolStripMenuItem";
            _PauseAllScriptsToolStripMenuItem.Size = new Size(169, 22);
            _PauseAllScriptsToolStripMenuItem.Text = "&Pause All Scripts";
            // 
            // ResumeAllScriptsToolStripMenuItem
            // 
            _ResumeAllScriptsToolStripMenuItem.Name = "ResumeAllScriptsToolStripMenuItem";
            _ResumeAllScriptsToolStripMenuItem.Size = new Size(169, 22);
            _ResumeAllScriptsToolStripMenuItem.Text = "&Resume All Scripts";
            // 
            // ToolStripMenuItem3
            // 
            _ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            _ToolStripMenuItem3.Size = new Size(166, 6);
            // 
            // AbortAllScriptsToolStripMenuItem
            // 
            _AbortAllScriptsToolStripMenuItem.Name = "AbortAllScriptsToolStripMenuItem";
            _AbortAllScriptsToolStripMenuItem.ShortcutKeyDisplayString = "";
            _AbortAllScriptsToolStripMenuItem.Size = new Size(169, 22);
            _AbortAllScriptsToolStripMenuItem.Text = "&Abort All Scripts";
            // 
            // AutoMapperToolStripMenuItem
            // 
            _AutoMapperToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _ShowWindowToolStripMenuItem });
            _AutoMapperToolStripMenuItem.Name = "AutoMapperToolStripMenuItem";
            _AutoMapperToolStripMenuItem.Size = new Size(78, 20);
            _AutoMapperToolStripMenuItem.Text = "&AutoMapper";
            // 
            // ShowWindowToolStripMenuItem
            // 
            _ShowWindowToolStripMenuItem.Name = "ShowWindowToolStripMenuItem";
            _ShowWindowToolStripMenuItem.Size = new Size(141, 22);
            _ShowWindowToolStripMenuItem.Text = "&Show Window";
            // 
            // PluginsToolStripMenuItem
            // 
            _PluginsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _NoPluginsLoadedToolStripMenuItem });
            _PluginsToolStripMenuItem.Name = "PluginsToolStripMenuItem";
            _PluginsToolStripMenuItem.Size = new Size(52, 20);
            _PluginsToolStripMenuItem.Text = "Pl&ugins";
            // 
            // NoPluginsLoadedToolStripMenuItem
            // 
            _NoPluginsLoadedToolStripMenuItem.Name = "NoPluginsLoadedToolStripMenuItem";
            _NoPluginsLoadedToolStripMenuItem.Size = new Size(158, 22);
            _NoPluginsLoadedToolStripMenuItem.Text = "No plugins loaded";
            // 
            // HelpToolStripMenuItem
            // 
            _HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _EnterGenieKeyToolStripMenuItem, _ToolStripSeparator3, _CheckForNewVersionToolStripMenuItem, _ToolStripSeparator2, _ChangelogToolStripMenuItem, _ToolStripSeparator10, _OpenGenieForumToolStripMenuItem, _OpenGenieDocsToolStripMenuItem });
            _HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            _HelpToolStripMenuItem.Size = new Size(40, 20);
            _HelpToolStripMenuItem.Text = "&Help";
            // 
            // EnterGenieKeyToolStripMenuItem
            // 
            _EnterGenieKeyToolStripMenuItem.Name = "EnterGenieKeyToolStripMenuItem";
            _EnterGenieKeyToolStripMenuItem.Size = new Size(226, 22);
            _EnterGenieKeyToolStripMenuItem.Text = "&Enter Genie Key...";
            // 
            // ToolStripSeparator3
            // 
            _ToolStripSeparator3.Name = "ToolStripSeparator3";
            _ToolStripSeparator3.Size = new Size(223, 6);
            // 
            // CheckForNewVersionToolStripMenuItem
            // 
            _CheckForNewVersionToolStripMenuItem.Name = "CheckForNewVersionToolStripMenuItem";
            _CheckForNewVersionToolStripMenuItem.Size = new Size(226, 22);
            _CheckForNewVersionToolStripMenuItem.Text = "Check For New Genie &Version...";
            // 
            // ToolStripSeparator2
            // 
            _ToolStripSeparator2.Name = "ToolStripSeparator2";
            _ToolStripSeparator2.Size = new Size(223, 6);
            // 
            // ChangelogToolStripMenuItem
            // 
            _ChangelogToolStripMenuItem.Name = "ChangelogToolStripMenuItem";
            _ChangelogToolStripMenuItem.Size = new Size(226, 22);
            _ChangelogToolStripMenuItem.Text = "&Changelog";
            // 
            // ToolStripSeparator10
            // 
            _ToolStripSeparator10.Name = "ToolStripSeparator10";
            _ToolStripSeparator10.Size = new Size(223, 6);
            // 
            // OpenGenieForumToolStripMenuItem
            // 
            _OpenGenieForumToolStripMenuItem.Name = "OpenGenieForumToolStripMenuItem";
            _OpenGenieForumToolStripMenuItem.Size = new Size(226, 22);
            _OpenGenieForumToolStripMenuItem.Text = "Open Genie &Forum";
            // 
            // OpenGenieDocsToolStripMenuItem
            // 
            _OpenGenieDocsToolStripMenuItem.Name = "OpenGenieDocsToolStripMenuItem";
            _OpenGenieDocsToolStripMenuItem.Size = new Size(226, 22);
            _OpenGenieDocsToolStripMenuItem.Text = "Open Genie &Documentation";
            // 
            // LabelSpellC
            // 
            _LabelSpellC.Dock = DockStyle.Fill;
            _LabelSpellC.ForeColor = Color.White;
            _LabelSpellC.Location = new Point(782, 0);
            _LabelSpellC.Margin = new Padding(0);
            _LabelSpellC.Name = "LabelSpellC";
            _LabelSpellC.Size = new Size(203, 37);
            _LabelSpellC.TabIndex = 12;
            _LabelSpellC.Text = "None";
            _LabelSpellC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelRHC
            // 
            _LabelRHC.Dock = DockStyle.Fill;
            _LabelRHC.ForeColor = Color.White;
            _LabelRHC.Location = new Point(571, 0);
            _LabelRHC.Margin = new Padding(0);
            _LabelRHC.Name = "LabelRHC";
            _LabelRHC.Size = new Size(201, 37);
            _LabelRHC.TabIndex = 11;
            _LabelRHC.Text = "Empty";
            _LabelRHC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelLHC
            // 
            _LabelLHC.Dock = DockStyle.Fill;
            _LabelLHC.ForeColor = Color.White;
            _LabelLHC.Location = new Point(360, 0);
            _LabelLHC.Margin = new Padding(0);
            _LabelLHC.Name = "LabelLHC";
            _LabelLHC.Size = new Size(201, 37);
            _LabelLHC.TabIndex = 10;
            _LabelLHC.Text = "Empty";
            _LabelLHC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelSpell
            // 
            _LabelSpell.Dock = DockStyle.Fill;
            _LabelSpell.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelSpell.ForeColor = Color.DimGray;
            _LabelSpell.Location = new Point(772, 0);
            _LabelSpell.Margin = new Padding(0);
            _LabelSpell.Name = "LabelSpell";
            _LabelSpell.Size = new Size(10, 37);
            _LabelSpell.TabIndex = 9;
            _LabelSpell.Text = "S";
            _LabelSpell.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelRH
            // 
            _LabelRH.Dock = DockStyle.Fill;
            _LabelRH.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelRH.ForeColor = Color.DimGray;
            _LabelRH.Location = new Point(561, 0);
            _LabelRH.Margin = new Padding(0);
            _LabelRH.Name = "LabelRH";
            _LabelRH.Size = new Size(10, 37);
            _LabelRH.TabIndex = 8;
            _LabelRH.Text = "R";
            _LabelRH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelLH
            // 
            _LabelLH.Dock = DockStyle.Fill;
            _LabelLH.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelLH.ForeColor = Color.DimGray;
            _LabelLH.Location = new Point(350, 0);
            _LabelLH.Margin = new Padding(0);
            _LabelLH.Name = "LabelLH";
            _LabelLH.Size = new Size(10, 37);
            _LabelLH.TabIndex = 7;
            _LabelLH.Text = "L";
            _LabelLH.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelRT
            // 
            _LabelRT.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelRT.ForeColor = Color.DimGray;
            _LabelRT.Location = new Point(1, 0);
            _LabelRT.Name = "LabelRT";
            _LabelRT.Size = new Size(10, 32);
            _LabelRT.TabIndex = 6;
            _LabelRT.Text = "RT";
            _LabelRT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PanelBars
            // 
            _PanelBars.BackColor = Color.Black;
            _PanelBars.Controls.Add(_TableLayoutPanelBars);
            _PanelBars.Dock = DockStyle.Bottom;
            _PanelBars.Location = new Point(0, 627);
            _PanelBars.Name = "PanelBars";
            _PanelBars.Size = new Size(985, 17);
            _PanelBars.TabIndex = 10;
            // 
            // TableLayoutPanelBars
            // 
            _TableLayoutPanelBars.ColumnCount = 5;
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0F));
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0F));
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0F));
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0F));
            _TableLayoutPanelBars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0F));
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsConc, 1, 0);
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsFatigue, 2, 0);
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsMana, 0, 0);
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsSpirit, 3, 0);
            _TableLayoutPanelBars.Controls.Add(_ComponentBarsHealth, 0, 0);
            _TableLayoutPanelBars.Dock = DockStyle.Fill;
            _TableLayoutPanelBars.Location = new Point(0, 0);
            _TableLayoutPanelBars.Margin = new Padding(0);
            _TableLayoutPanelBars.Name = "TableLayoutPanelBars";
            _TableLayoutPanelBars.RowCount = 1;
            _TableLayoutPanelBars.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0F));
            _TableLayoutPanelBars.Size = new Size(985, 17);
            _TableLayoutPanelBars.TabIndex = 0;
            // 
            // ComponentBarsConc
            // 
            _ComponentBarsConc.BackColor = Color.Black;
            _ComponentBarsConc.BackgroundColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _ComponentBarsConc.BarText = "Concentration";
            _ComponentBarsConc.BorderColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _ComponentBarsConc.Dock = DockStyle.Fill;
            _ComponentBarsConc.ForegroundColor = Color.Teal;
            _ComponentBarsConc.IsConnected = false;
            _ComponentBarsConc.Location = new Point(394, 0);
            _ComponentBarsConc.Margin = new Padding(0);
            _ComponentBarsConc.Name = "ComponentBarsConc";
            _ComponentBarsConc.Size = new Size(197, 17);
            _ComponentBarsConc.TabIndex = 20;
            _ComponentBarsConc.Value = 100;
            // 
            // ComponentBarsFatigue
            // 
            _ComponentBarsFatigue.BackColor = Color.Black;
            _ComponentBarsFatigue.BackgroundColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(0)));
            _ComponentBarsFatigue.BarText = "Stamina";
            _ComponentBarsFatigue.BorderColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(0)));
            _ComponentBarsFatigue.Dock = DockStyle.Fill;
            _ComponentBarsFatigue.ForegroundColor = Color.Green;
            _ComponentBarsFatigue.IsConnected = false;
            _ComponentBarsFatigue.Location = new Point(591, 0);
            _ComponentBarsFatigue.Margin = new Padding(0);
            _ComponentBarsFatigue.Name = "ComponentBarsFatigue";
            _ComponentBarsFatigue.Size = new Size(197, 17);
            _ComponentBarsFatigue.TabIndex = 17;
            _ComponentBarsFatigue.Value = 100;
            // 
            // ComponentBarsMana
            // 
            _ComponentBarsMana.BackColor = Color.Black;
            _ComponentBarsMana.BackgroundColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(64)));
            _ComponentBarsMana.BarText = "Mana";
            _ComponentBarsMana.BorderColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(64)));
            _ComponentBarsMana.Dock = DockStyle.Fill;
            _ComponentBarsMana.ForegroundColor = Color.Navy;
            _ComponentBarsMana.IsConnected = false;
            _ComponentBarsMana.Location = new Point(197, 0);
            _ComponentBarsMana.Margin = new Padding(0);
            _ComponentBarsMana.Name = "ComponentBarsMana";
            _ComponentBarsMana.Size = new Size(197, 17);
            _ComponentBarsMana.TabIndex = 19;
            _ComponentBarsMana.Value = 100;
            // 
            // ComponentBarsSpirit
            // 
            _ComponentBarsSpirit.BackColor = Color.Black;
            _ComponentBarsSpirit.BackgroundColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(64)));
            _ComponentBarsSpirit.BarText = "Spirit";
            _ComponentBarsSpirit.BorderColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(64)));
            _ComponentBarsSpirit.Dock = DockStyle.Fill;
            _ComponentBarsSpirit.ForegroundColor = Color.Purple;
            _ComponentBarsSpirit.IsConnected = false;
            _ComponentBarsSpirit.Location = new Point(788, 0);
            _ComponentBarsSpirit.Margin = new Padding(0);
            _ComponentBarsSpirit.Name = "ComponentBarsSpirit";
            _ComponentBarsSpirit.Size = new Size(197, 17);
            _ComponentBarsSpirit.TabIndex = 18;
            _ComponentBarsSpirit.Value = 100;
            // 
            // ComponentBarsHealth
            // 
            _ComponentBarsHealth.BackColor = Color.Black;
            _ComponentBarsHealth.BackgroundColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)));
            _ComponentBarsHealth.BarText = "Health";
            _ComponentBarsHealth.BorderColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)));
            _ComponentBarsHealth.Dock = DockStyle.Fill;
            _ComponentBarsHealth.ForegroundColor = Color.Maroon;
            _ComponentBarsHealth.IsConnected = false;
            _ComponentBarsHealth.Location = new Point(0, 0);
            _ComponentBarsHealth.Margin = new Padding(0);
            _ComponentBarsHealth.Name = "ComponentBarsHealth";
            _ComponentBarsHealth.Size = new Size(197, 17);
            _ComponentBarsHealth.TabIndex = 0;
            _ComponentBarsHealth.Value = 100;
            // 
            // PanelStatus
            // 
            _PanelStatus.BackColor = Color.Black;
            _PanelStatus.Controls.Add(_TableLayoutPanelFlow);
            _PanelStatus.Dock = DockStyle.Bottom;
            _PanelStatus.Location = new Point(0, 570);
            _PanelStatus.Margin = new Padding(0);
            _PanelStatus.Name = "PanelStatus";
            _PanelStatus.Size = new Size(985, 37);
            _PanelStatus.TabIndex = 12;
            _PanelStatus.Visible = false;
            // 
            // TableLayoutPanelFlow
            // 
            _TableLayoutPanelFlow.BackColor = Color.Transparent;
            _TableLayoutPanelFlow.ColumnCount = 7;
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350.0F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10.0F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10.0F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _TableLayoutPanelFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10.0F));
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
            _TableLayoutPanelFlow.MaximumSize = new Size(1000, 100);
            _TableLayoutPanelFlow.Name = "TableLayoutPanelFlow";
            _TableLayoutPanelFlow.RowCount = 1;
            _TableLayoutPanelFlow.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0F));
            _TableLayoutPanelFlow.Size = new Size(985, 37);
            _TableLayoutPanelFlow.TabIndex = 0;
            // 
            // PanelFixed
            // 
            _PanelFixed.BackColor = Color.Black;
            _PanelFixed.Controls.Add(_oRTControl);
            _PanelFixed.Controls.Add(_IconBar);
            _PanelFixed.Controls.Add(_LabelRT);
            _PanelFixed.Dock = DockStyle.Fill;
            _PanelFixed.Location = new Point(2, 2);
            _PanelFixed.Margin = new Padding(2);
            _PanelFixed.Name = "PanelFixed";
            _PanelFixed.Size = new Size(346, 33);
            _PanelFixed.TabIndex = 13;
            // 
            // oRTControl
            // 
            _oRTControl.BackColor = Color.Black;
            _oRTControl.BackgroundColor = Color.Black;
            _oRTControl.BackgroundColorRT = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(75)));
            _oRTControl.BorderColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _oRTControl.BorderColorRT = Color.White;
            _oRTControl.ForegroundColor = Color.MediumBlue;
            _oRTControl.IsConnected = false;
            _oRTControl.Location = new Point(14, 3);
            _oRTControl.Margin = new Padding(4);
            _oRTControl.Name = "oRTControl";
            _oRTControl.Size = new Size(100, 26);
            _oRTControl.TabIndex = 0;
            // 
            // IconBar
            // 
            _IconBar.BackColor = Color.Transparent;
            _IconBar.Globals = null;
            _IconBar.IsConnected = false;
            _IconBar.Location = new Point(117, 0);
            _IconBar.Margin = new Padding(0);
            _IconBar.Name = "IconBar";
            _IconBar.Size = new Size(225, 32);
            _IconBar.TabIndex = 0;
            // 
            // ToolStripButtons
            // 
            _ToolStripButtons.BackColor = SystemColors.Control;
            _ToolStripButtons.ContextMenuStrip = _ContextMenuStripButtons;
            _ToolStripButtons.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripButtons.Location = new Point(0, 24);
            _ToolStripButtons.Name = "ToolStripButtons";
            _ToolStripButtons.RenderMode = ToolStripRenderMode.System;
            _ToolStripButtons.Size = new Size(985, 25);
            _ToolStripButtons.TabIndex = 14;
            // 
            // ContextMenuStripButtons
            // 
            _ContextMenuStripButtons.Name = "ContextMenuStripButtons";
            _ContextMenuStripButtons.Size = new Size(61, 4);
            // 
            // TimerReconnect
            // 
            _TimerReconnect.Enabled = true;
            _TimerReconnect.Interval = 1000;
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
            // TimerBgWorker
            // 
            _TimerBgWorker.Interval = 10;
            // 
            // PanelInput
            // 
            _PanelInput.BackColor = Color.White;
            _PanelInput.Controls.Add(_TextBoxInput);
            _PanelInput.Dock = DockStyle.Bottom;
            _PanelInput.Location = new Point(0, 607);
            _PanelInput.Margin = new Padding(0);
            _PanelInput.Name = "PanelInput";
            _PanelInput.Padding = new Padding(3, 2, 0, 0);
            _PanelInput.Size = new Size(985, 20);
            _PanelInput.TabIndex = 0;
            // 
            // TextBoxInput
            // 
            _TextBoxInput.AcceptsTab = true;
            _TextBoxInput.BackColor = Color.White;
            _TextBoxInput.BorderStyle = BorderStyle.None;
            _TextBoxInput.Dock = DockStyle.Fill;
            _TextBoxInput.Font = new Font("Courier New", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _TextBoxInput.HideSelection = false;
            _TextBoxInput.KeepInput = false;
            _TextBoxInput.Location = new Point(3, 2);
            _TextBoxInput.Multiline = true;
            _TextBoxInput.Name = "TextBoxInput";
            _TextBoxInput.Size = new Size(982, 18);
            _TextBoxInput.TabIndex = 0;
            _TextBoxInput.WordWrap = false;
            // 
            // OpenFileDialogProfile
            // 
            _OpenFileDialogProfile.DefaultExt = "layout";
            _OpenFileDialogProfile.Filter = "Genie Profile|*.xml|All files|*.*";
            _OpenFileDialogProfile.RestoreDirectory = true;
            _OpenFileDialogProfile.Title = "Open Profile";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(985, 666);
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
            Name = "FormMain";
            Text = "Genie";
            WindowState = FormWindowState.Maximized;
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
            Activated += new EventHandler(FormMain_Activated);
            FormClosing += new FormClosingEventHandler(FormMain_FormClosing);
            KeyDown += new KeyEventHandler(FormMain_KeyDown);
            Load += new EventHandler(FormMain_Load);
            ResizeEnd += new EventHandler(FormMain_SizeChange);
            Resize += new EventHandler(FormMain_SizeChange);
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

        private ToolStripMenuItem _EnterGenieKeyToolStripMenuItem;

        internal ToolStripMenuItem EnterGenieKeyToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _EnterGenieKeyToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_EnterGenieKeyToolStripMenuItem != null)
                {
                    _EnterGenieKeyToolStripMenuItem.Click -= EnterGenieKeyToolStripMenuItem_Click;
                }

                _EnterGenieKeyToolStripMenuItem = value;
                if (_EnterGenieKeyToolStripMenuItem != null)
                {
                    _EnterGenieKeyToolStripMenuItem.Click += EnterGenieKeyToolStripMenuItem_Click;
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

        private ToolStripMenuItem _CheckForNewVersionToolStripMenuItem;

        internal ToolStripMenuItem CheckForNewVersionToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckForNewVersionToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckForNewVersionToolStripMenuItem != null)
                {
                    _CheckForNewVersionToolStripMenuItem.Click -= CheckForNewVersionToolStripMenuItem_Click;
                }

                _CheckForNewVersionToolStripMenuItem = value;
                if (_CheckForNewVersionToolStripMenuItem != null)
                {
                    _CheckForNewVersionToolStripMenuItem.Click += CheckForNewVersionToolStripMenuItem_Click;
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

        private ToolStripMenuItem _OpenGenieForumToolStripMenuItem;

        internal ToolStripMenuItem OpenGenieForumToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpenGenieForumToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpenGenieForumToolStripMenuItem != null)
                {
                    _OpenGenieForumToolStripMenuItem.Click -= OpenGenieForumToolStripMenuItem_Click;
                }

                _OpenGenieForumToolStripMenuItem = value;
                if (_OpenGenieForumToolStripMenuItem != null)
                {
                    _OpenGenieForumToolStripMenuItem.Click += OpenGenieForumToolStripMenuItem_Click;
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