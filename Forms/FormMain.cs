using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    // Imports Microsoft.Win32

    public partial class FormMain
    {
        public FormMain()
        {
            m_oGlobals = new Genie.Globals();
            m_oGame = new Genie.Game(ref _m_oGlobals);
            m_oCommand = new Genie.Command(ref _m_oGlobals);
            m_oAutoMapper = new Mapper.AutoMapper(ref _m_oGlobals);
            m_oOutputMain = new FormSkin("main", "Game", ref _m_oGlobals);
            m_oPluginHost = new PluginHost(this, ref _m_oGlobals);
            m_PluginDialog = new FormPlugins(ref _m_oGlobals.PluginList);
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            LocalDirectory.CheckUserDirectory();
            bool bCustomConfigFile = false;
            var al = new ArrayList();
            al = Utility.ParseArgs(Interaction.Command());
            foreach (string cmd in al)
            {
                switch (cmd)
                {
                    case "-l":
                    case "-layout":
                        {
                            bCustomConfigFile = true;
                            break;
                        }

                    case "-n":
                    case "-noupdate":
                        {
                            m_bVersionUpdated = true;
                            break;
                        }

                    case "-d":
                    case "-debug":
                        {
                            m_bDebugPlugin = true;
                            break;
                        }

                    default:
                        {
                            if (bCustomConfigFile == true)
                            {
                                if (m_sConfigFile.Length == 0)
                                {
                                    m_sConfigFile = cmd;
                                    if (m_sConfigFile.ToLower().EndsWith(".layout") == false & m_sConfigFile.ToLower().EndsWith(".xml") == false)
                                    {
                                        m_sConfigFile += ".layout";
                                    }

                                    if (m_sConfigFile.Contains(@"\") == false)
                                    {
                                        m_sConfigFile = m_oGlobals.Config.ConfigDir + @"\Layout\" + m_sConfigFile;
                                    }

                                    bCustomConfigFile = false;
                                }
                            }

                            break;
                        }
                }
            }

            CreateGenieFolders();
            if (bCustomConfigFile == false)
            {
                m_sConfigFile = m_oGlobals.Config.ConfigDir + @"\Layout\" + "default.layout";

                // TEMP MOVE TEMP MOVE TEMP MOVE
                if (File.Exists(m_oGlobals.Config.ConfigDir + @"\Layout\" + "default.layout"))
                {
                }
                // 
                else if (File.Exists(m_oGlobals.Config.ConfigDir + @"\config.xml"))
                {
                    try
                    {
                        File.Move(m_oGlobals.Config.ConfigDir + @"\config.xml", m_sConfigFile);
                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox("Error: Unable to move config.xml to default.layout");
                    }
                }
            }

            IconBar.Globals = m_oGlobals;
            m_oOutputMain.MdiParent = this;
            m_oOutputMain.IsMainWindow = true;
            m_oOutputMain.UserForm = false; // Not an editable window

            // Make sure decimal separator is always "." (For script compability and such)
            if ((Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator ?? "") != ".")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }

            UpdateMainWindowTitle();
        }

        private Genie.Globals _m_oGlobals;

        public Genie.Globals m_oGlobals
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_oGlobals;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_oGlobals != null)
                {
                    GenieError.EventGenieError -= HandleGenieException;
                    _m_oGlobals.ConfigChanged -= Config_ConfigChanged;
                }

                _m_oGlobals = value;
                if (_m_oGlobals != null)
                {
                    GenieError.EventGenieError += HandleGenieException;
                    _m_oGlobals.ConfigChanged += Config_ConfigChanged;
                }
            }
        }

        private Genie.Game _m_oGame;

        public Genie.Game m_oGame
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_oGame;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_oGame != null)
                {
                    _m_oGame.EventParseXML -= Plugin_ParsePluginXML;
                    _m_oGame.EventStreamWindow -= EventStreamWindow;
                    _m_oGame.EventVariableChanged -= ClassCommand_EventVariableChanged;
                    _m_oGame.EventPrintError -= PrintError;

                    // Clear Window
                    _m_oGame.EventClearWindow -= Command_EventClearWindow;

                    // Simutronics Print
                    _m_oGame.EventPrintText -= Simutronics_EventPrintText;

                    // Private Sub Simutronics_EventClearWindow(ByoTargetWindow As Genie.Game.WindowTarget) Handles oGame.EventClearWindow
                    // Try
                    // Dim oFormSkin As FormSkin = Nothing

                    // Select Case oTargetWindow
                    // Case Genie.Game.WindowTarget.Death
                    // oFormSkin = m_oOutputDeath
                    // Case Genie.Game.WindowTarget.Familiar
                    // oFormSkin = m_oOutputFamiliar
                    // Case Genie.Game.WindowTarget.Inv
                    // oFormSkin = m_oOutputInv
                    // Case Genie.Game.WindowTarget.Logons
                    // oFormSkin = m_oOutputLogons
                    // Case Genie.Game.WindowTarget.Room
                    // oFormSkin = m_oOutputRoom
                    // Case Genie.Game.WindowTarget.Thoughts
                    // oFormSkin = m_oOutputThoughts
                    // Case Genie.Game.WindowTarget.Log
                    // oFormSkin = m_oOutputLog
                    // Case Genie.Game.WindowTarget.Main
                    // oFormSkin = m_oOutputMain
                    // End Select

                    // If Not IsNothing(oFormSkin) Then ' Do not clear if window does not exist
                    // SafeClearWindow(oFormSkin)
                    // End If
                    // #If Not Debug Then
                    // Catch ex As Exception
                    // HandleGenieException("Game ClearWindow Exception: " & ex.ToString)
                    // #Else
                    // Finally
                    // #End If
                    // End Try
                    // End Sub

                    _m_oGame.EventDataRecieveEnd -= Simutronics_EventEndUpdate;
                    GenieError.EventGenieError -= HandleGenieException;
                    GenieError.EventGeniePluginError -= HandlePluginException;
                    _m_oGame.EventTriggerParse -= Game_EventTriggerParse;
                    _m_oGame.EventStatusBarUpdate -= Game_EventStatusBarUpdate;
                    _m_oGame.EventClearSpellTime -= Game_EventClearSpellTime;
                    _m_oGame.EventSpellTime -= Game_EventSpellTime;
                    _m_oGame.EventRoundTime -= Game_EventRoundtime;
                    _m_oGame.EventTriggerPrompt -= Game_EventTriggerPrompt;
                    _m_oGame.EventTriggerMove -= Game_EventTriggerMove;
                }

                _m_oGame = value;
                if (_m_oGame != null)
                {
                    _m_oGame.EventParseXML += Plugin_ParsePluginXML;
                    _m_oGame.EventStreamWindow += EventStreamWindow;
                    _m_oGame.EventVariableChanged += ClassCommand_EventVariableChanged;
                    _m_oGame.EventPrintError += PrintError;
                    _m_oGame.EventClearWindow += Command_EventClearWindow;
                    _m_oGame.EventPrintText += Simutronics_EventPrintText;
                    _m_oGame.EventDataRecieveEnd += Simutronics_EventEndUpdate;
                    GenieError.EventGenieError += HandleGenieException;
                    GenieError.EventGeniePluginError += HandlePluginException;
                    _m_oGame.EventTriggerParse += Game_EventTriggerParse;
                    _m_oGame.EventStatusBarUpdate += Game_EventStatusBarUpdate;
                    _m_oGame.EventClearSpellTime += Game_EventClearSpellTime;
                    _m_oGame.EventSpellTime += Game_EventSpellTime;
                    _m_oGame.EventRoundTime += Game_EventRoundtime;
                    _m_oGame.EventTriggerPrompt += Game_EventTriggerPrompt;
                    _m_oGame.EventTriggerMove += Game_EventTriggerMove;
                }
            }
        }

        private Genie.Command _m_oCommand;

        public Genie.Command m_oCommand
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_oCommand;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_oCommand != null)
                {
                    _m_oCommand.ListPlugins -= ListPlugins;
                    _m_oCommand.LoadPlugin -= FormPlugin_LoadPlugin;
                    _m_oCommand.UnloadPlugin -= FormPlugin_UnloadPlugin;
                    _m_oCommand.ReloadPlugins -= FormPlugin_ReloadPlugins;
                    _m_oCommand.DisablePlugin -= FormPlugin_DisablePlugin;
                    _m_oCommand.EnablePlugin -= FormPlugin_EnablePlugin;
                    _m_oCommand.EventEchoText -= ClassCommand_EchoText;
                    _m_oCommand.EventLinkText -= ClassCommand_LinkText;
                    _m_oCommand.EventEchoColorText -= ClassCommand_EchoColorText;
                    _m_oCommand.EventSendRaw -= ClassCommand_SendRaw;
                    _m_oCommand.EventSendText -= ClassCommand_SendText;
                    _m_oCommand.EventListScripts -= Command_EventListScripts;
                    _m_oCommand.EventParseLine -= ClassCommand_ParseText;
                    _m_oCommand.EventRunScript -= ClassCommand_RunScript;
                    _m_oCommand.EventVariableChanged -= ClassCommand_EventVariableChanged;
                    _m_oCommand.EventChangeWindowTitle -= Command_EventChangeWindowTitle;
                    _m_oCommand.EventClearWindow -= Command_EventClearWindow;
                    _m_oCommand.EventScriptVariables -= Command_ScriptVariables;
                    _m_oCommand.EventScriptTrace -= Command_ScriptTrace;
                    _m_oCommand.EventScriptAbort -= Command_ScriptAbort;
                    _m_oCommand.EventScriptPause -= Command_ScriptPause;
                    _m_oCommand.EventScriptPauseOrResume -= Command_ScriptPauseOrResume;
                    _m_oCommand.EventScriptResume -= Command_ScriptResume;
                    _m_oCommand.EventScriptDebug -= Command_ScriptDebugLevel;
                    _m_oCommand.EventStatusBar -= Command_StatusBar;
                    _m_oCommand.EventReconnect -= ReconnectToGame;
                    _m_oCommand.EventConnect -= ConnectToGame;
                    _m_oCommand.EventDisconnect -= DisconnectFromGame;
                    _m_oCommand.EventClassChange -= Command_EventClassChange;
                    _m_oCommand.EventPresetChanged -= ClassCommand_PresetChanged;
                    _m_oCommand.EventShowScriptExplorer -= Command_ShowScriptExplorer;
                    _m_oCommand.EventLoadLayout -= Command_LoadLayout;
                    _m_oCommand.EventSaveLayout -= Command_SaveLayout;
                    _m_oCommand.EventAddWindow -= Command_EventAddWindow;
                    _m_oCommand.EventRemoveWindow -= Command_EventRemoveWindow;
                    _m_oCommand.EventCloseWindow -= Command_EventCloseWindow;
                    _m_oCommand.EventFlashWindow -= Command_FlashWindow;
                    _m_oCommand.EventMapperCommand -= Command_EventMapperCommand;
                    _m_oCommand.EventLoadProfile -= Command_LoadProfile;
                    _m_oCommand.EventSaveProfile -= Command_SaveProfile;
                    _m_oCommand.EventRawToggle -= Command_RawToggle;
                    _m_oCommand.EventChangeIcon -= Command_ChangeIcon;
                }

                _m_oCommand = value;
                if (_m_oCommand != null)
                {
                    _m_oCommand.ListPlugins += ListPlugins;
                    _m_oCommand.LoadPlugin += FormPlugin_LoadPlugin;
                    _m_oCommand.UnloadPlugin += FormPlugin_UnloadPlugin;
                    _m_oCommand.ReloadPlugins += FormPlugin_ReloadPlugins;
                    _m_oCommand.DisablePlugin += FormPlugin_DisablePlugin;
                    _m_oCommand.EnablePlugin += FormPlugin_EnablePlugin;
                    _m_oCommand.EventEchoText += ClassCommand_EchoText;
                    _m_oCommand.EventLinkText += ClassCommand_LinkText;
                    _m_oCommand.EventEchoColorText += ClassCommand_EchoColorText;
                    _m_oCommand.EventSendRaw += ClassCommand_SendRaw;
                    _m_oCommand.EventSendText += ClassCommand_SendText;
                    _m_oCommand.EventListScripts += Command_EventListScripts;
                    _m_oCommand.EventParseLine += ClassCommand_ParseText;
                    _m_oCommand.EventRunScript += ClassCommand_RunScript;
                    _m_oCommand.EventVariableChanged += ClassCommand_EventVariableChanged;
                    _m_oCommand.EventChangeWindowTitle += Command_EventChangeWindowTitle;
                    _m_oCommand.EventClearWindow += Command_EventClearWindow;
                    _m_oCommand.EventScriptVariables += Command_ScriptVariables;
                    _m_oCommand.EventScriptTrace += Command_ScriptTrace;
                    _m_oCommand.EventScriptAbort += Command_ScriptAbort;
                    _m_oCommand.EventScriptPause += Command_ScriptPause;
                    _m_oCommand.EventScriptPauseOrResume += Command_ScriptPauseOrResume;
                    _m_oCommand.EventScriptResume += Command_ScriptResume;
                    _m_oCommand.EventScriptDebug += Command_ScriptDebugLevel;
                    _m_oCommand.EventStatusBar += Command_StatusBar;
                    _m_oCommand.EventReconnect += ReconnectToGame;
                    _m_oCommand.EventConnect += ConnectToGame;
                    _m_oCommand.EventDisconnect += DisconnectFromGame;
                    _m_oCommand.EventClassChange += Command_EventClassChange;
                    _m_oCommand.EventPresetChanged += ClassCommand_PresetChanged;
                    _m_oCommand.EventShowScriptExplorer += Command_ShowScriptExplorer;
                    _m_oCommand.EventLoadLayout += Command_LoadLayout;
                    _m_oCommand.EventSaveLayout += Command_SaveLayout;
                    _m_oCommand.EventAddWindow += Command_EventAddWindow;
                    _m_oCommand.EventRemoveWindow += Command_EventRemoveWindow;
                    _m_oCommand.EventCloseWindow += Command_EventCloseWindow;
                    _m_oCommand.EventFlashWindow += Command_FlashWindow;
                    _m_oCommand.EventMapperCommand += Command_EventMapperCommand;
                    _m_oCommand.EventLoadProfile += Command_LoadProfile;
                    _m_oCommand.EventSaveProfile += Command_SaveProfile;
                    _m_oCommand.EventRawToggle += Command_RawToggle;
                    _m_oCommand.EventChangeIcon += Command_ChangeIcon;
                }
            }
        }

        private Mapper.AutoMapper _m_oAutoMapper;

        public Mapper.AutoMapper m_oAutoMapper
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_oAutoMapper;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_oAutoMapper != null)
                {
                    _m_oAutoMapper.EventEchoText -= Plugin_EventEchoText;
                    _m_oAutoMapper.EventSendText -= Plugin_EventSendText;
                    _m_oAutoMapper.EventVariableChanged -= PluginHost_EventVariableChanged;
                }

                _m_oAutoMapper = value;
                if (_m_oAutoMapper != null)
                {
                    _m_oAutoMapper.EventEchoText += Plugin_EventEchoText;
                    _m_oAutoMapper.EventSendText += Plugin_EventSendText;
                    _m_oAutoMapper.EventVariableChanged += PluginHost_EventVariableChanged;
                }
            }
        }

        private Genie.XMLConfig m_oConfig = new Genie.XMLConfig();
        private FormSkin _m_oOutputMain;

        private FormSkin m_oOutputMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_oOutputMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_oOutputMain != null)
                {
                    _m_oOutputMain.EventLinkClicked -= FormSkin_LinkClicked;
                }

                _m_oOutputMain = value;
                if (_m_oOutputMain != null)
                {
                    _m_oOutputMain.EventLinkClicked += FormSkin_LinkClicked;
                }
            }
        }

        private FormSkin m_oOutputInv;
        private FormSkin m_oOutputFamiliar;
        private FormSkin m_oOutputThoughts;
        private FormSkin m_oOutputLogons;
        private FormSkin m_oOutputDeath;
        private FormSkin m_oOutputRoom;
        private FormSkin m_oOutputLog;
        private ArrayList m_oFormList = new ArrayList();
        private string m_sConfigFile = string.Empty;
        private string m_sUpdateVersion = string.Empty;
        private bool m_bIsUpdateMajor = false;
        private string m_sGenieKey = string.Empty;
        private System.Text.RegularExpressions.Match m_oRegMatch;

        // Private WithEvents m_oWorker As New System.ComponentModel.BackgroundWorker
        // Private m_bRunWorker As Boolean = True

        public ArrayList FormList
        {
            get
            {
                return m_oFormList;
            }
        }

        public FormSkin OutputMain
        {
            get
            {
                return m_oOutputMain;
            }
        }

        private List<PluginServices.AvailablePlugin> m_oPlugins = new List<PluginServices.AvailablePlugin>();
        private Dictionary<string, string> m_oPluginNameToFile = new Dictionary<string, string>();
        private PluginHost _m_oPluginHost;

        private PluginHost m_oPluginHost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_oPluginHost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_oPluginHost != null)
                {
                    _m_oPluginHost.EventEchoText -= Plugin_EventEchoText;
                    _m_oPluginHost.EventSendText -= Plugin_EventSendText;
                    _m_oPluginHost.EventVariableChanged -= PluginHost_EventVariableChanged;
                }

                _m_oPluginHost = value;
                if (_m_oPluginHost != null)
                {
                    _m_oPluginHost.EventEchoText += Plugin_EventEchoText;
                    _m_oPluginHost.EventSendText += Plugin_EventSendText;
                    _m_oPluginHost.EventVariableChanged += PluginHost_EventVariableChanged;
                }
            }
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int LoadPlugins()
        {
            GeniePlugin.Interfaces.IPlugin oPlugin;
            string sPluginPath = Path.Combine(LocalDirectory.Path, "Plugins");
            if (m_bDebugPlugin)
            {
                sPluginPath = Application.StartupPath;
            }

            // Get list of plugins
            var oAvailablePlugins = PluginServices.FindPlugins(sPluginPath, "GeniePlugin.Interfaces.IPlugin");
            m_oPlugins.Clear();
            if (!Information.IsNothing(oAvailablePlugins))
            {
                m_oPlugins.AddRange(oAvailablePlugins);
            }

            if (m_oPlugins.Count == 0)
            {
                UpdatePluginsMenuList();
                return 0;
            }

            m_oGlobals.PluginList.Clear();
            m_oPluginNameToFile.Clear();
            for (int iIndex = 0, loopTo = m_oPlugins.Count - 1; iIndex <= loopTo; iIndex++)
            {
                oPlugin = (GeniePlugin.Interfaces.IPlugin)PluginServices.CreateInstance(m_oPlugins[iIndex]);
                m_oPluginNameToFile.Add(oPlugin.Name, Path.GetFileName(m_oPlugins[iIndex].AssemblyPath));
                string argsText = "Loading Plugin: " + oPlugin.Name + ", Version: " + oPlugin.Version + "...";
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
                VerifyAndLoadPlugin(oPlugin, m_oPlugins[iIndex].Key);
                if (m_oGlobals.PluginList.Contains(oPlugin))
                {
                    string argsText1 = "OK" + Constants.vbNewLine;
                    Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                    AddText(argsText1, oTargetWindow: argoTargetWindow1);
                }
                else if (oPlugin.Description.StartsWith("Premium "))
                {
                    string argsText2 = "Invalid Key! To use this plugin you will need to first purchase a license for it. Visit http://genieclient.com for more information." + Constants.vbNewLine;
                    Genie.Game.WindowTarget argoTargetWindow2 = Genie.Game.WindowTarget.Main;
                    AddText(argsText2, oTargetWindow: argoTargetWindow2);
                }
                else
                {
                    string argsText3 = "Failed" + Constants.vbNewLine;
                    Genie.Game.WindowTarget argoTargetWindow3 = Genie.Game.WindowTarget.Main;
                    AddText(argsText3, oTargetWindow: argoTargetWindow3);
                }

                Application.DoEvents();
            }

            UpdatePluginsMenuList();
            return m_oGlobals.PluginList.Count;
        }

        private void LoadPlugin(string filename)
        {
            if (!filename.Contains(@"\"))
            {
                string sPluginPath = Path.Combine(LocalDirectory.Path, "Plugins");
                if (m_bDebugPlugin)
                {
                    sPluginPath = Application.StartupPath;
                }

                try
                {
                    filename = Path.Combine(sPluginPath, filename);
                }
                catch (ArgumentException ex)
                {
                    AppendText("Plugin not found: " + filename + Constants.vbNewLine);
                    return;
                }
            }

            if (!File.Exists(filename))
            {
                AppendText("Plugin not found: " + filename + Constants.vbNewLine);
                return;
            }

            var oAvalabilePlugin = PluginServices.FindPlugin(filename, "GeniePlugin.Interfaces.IPlugin");
            if (Information.IsNothing(oAvalabilePlugin.Key))
            {
                AppendText("Plugin not found: " + filename + Constants.vbNewLine);
                return;
            }

            AppendText("Plugin loading: " + filename + Constants.vbNewLine);
            GeniePlugin.Interfaces.IPlugin oPlugin = (GeniePlugin.Interfaces.IPlugin)PluginServices.CreateInstance(oAvalabilePlugin);
            string argsText = PluginServices.GetMD5HashFromFile(filename);
            string strKey = Utility.GenerateKeyHash(argsText);
            UnloadPlugin(oPlugin.Name, strKey);
            if (!m_oPluginNameToFile.ContainsKey(oPlugin.Name))
            {
                m_oPluginNameToFile.Add(oPlugin.Name, Path.GetFileName(filename));
            }

            VerifyAndLoadPlugin(oPlugin, strKey);
        }

        private void EnableOrDisablePluginByFilename(string filename, bool value)
        {
            foreach (KeyValuePair<string, string> kvp in m_oPluginNameToFile)
            {
                if ((kvp.Value.ToLower() ?? "") == (filename.ToLower() ?? ""))
                {
                    string argsText = PluginServices.GetMD5HashFromFile(kvp.Value);
                    string strKey = Utility.GenerateKeyHash(argsText);
                    AppendText(Conversions.ToString("Plugin " + Interaction.IIf(value, "enable", "disable") + ": " + kvp.Key + Constants.vbNewLine));
                    EnableOrDisablePlugin(kvp.Key, value);
                }
            }
        }

        private void EnableOrDisablePlugin(string name, bool value)
        {
            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                if ((oPlugin.Name ?? "") == (name ?? ""))
                {
                    oPlugin.Enabled = value;
                }
            }
        }

        private void UnloadPlugin(string filename)
        {
            foreach (KeyValuePair<string, string> kvp in m_oPluginNameToFile)
            {
                if ((kvp.Value.ToLower() ?? "") == (filename.ToLower() ?? ""))
                {
                    string sPluginPath = Path.Combine(LocalDirectory.Path, "Plugins");
                    if (m_bDebugPlugin)
                    {
                        sPluginPath = Application.StartupPath;
                    }

                    string argsText = PluginServices.GetMD5HashFromFile(Path.Combine(sPluginPath, kvp.Value));
                    string strKey = Utility.GenerateKeyHash(argsText);
                    AppendText("Plugin unload: " + kvp.Key + Constants.vbNewLine);
                    if (m_oPluginNameToFile.ContainsKey(kvp.Value))
                    {
                        m_oPluginNameToFile.Remove(kvp.Value);
                    }

                    UnloadPlugin(kvp.Key, strKey);
                }
            }
        }

        private void UnloadPluginByName(string name)
        {
            foreach (KeyValuePair<string, string> kvp in m_oPluginNameToFile)
            {
                if ((kvp.Key.ToLower() ?? "") == (name.ToLower() ?? ""))
                {
                    string sPluginPath = Path.Combine(LocalDirectory.Path, "Plugins");
                    if (m_bDebugPlugin)
                    {
                        sPluginPath = Application.StartupPath;
                    }

                    string argsText = PluginServices.GetMD5HashFromFile(Path.Combine(sPluginPath, kvp.Value));
                    string strKey = Utility.GenerateKeyHash(argsText);
                    AppendText("Plugin unload: " + kvp.Key + Constants.vbNewLine);
                    if (m_oPluginNameToFile.ContainsKey(kvp.Value))
                    {
                        m_oPluginNameToFile.Remove(kvp.Value);
                    }

                    UnloadPlugin(kvp.Key, strKey);
                }
            }
        }

        private string PluginFileName(string name)
        {
            foreach (KeyValuePair<string, string> kvp in m_oPluginNameToFile)
            {
                if ((kvp.Key.ToLower() ?? "") == (name.ToLower() ?? ""))
                {
                    return kvp.Value;
                }
            }

            return null;
        }

        private void UnloadPlugin(string name, string key)
        {
            int RemoveIndex = -1;
            int I = 0;
            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                if ((oPlugin.Name ?? "") == (name ?? ""))
                {
                    oPlugin.ParentClosing();
                    RemoveIndex = I;
                }

                I += 1;
            }

            if (RemoveIndex > -1)
            {
                m_oGlobals.PluginList.RemoveAt(RemoveIndex);
            }

            RemoveIndex = -1;
            I = 0;
            foreach (PluginServices.AvailablePlugin oPlugin in m_oPlugins)
            {
                if ((oPlugin.Key ?? "") == (key ?? ""))
                {
                    RemoveIndex = I;
                }

                I += 1;
            }

            if (RemoveIndex > -1)
            {
                m_oPlugins.RemoveAt(RemoveIndex);
            }
        }

        private void UnloadPlugins()
        {
            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
                oPlugin.ParentClosing();
            m_oGlobals.PluginList.Clear();
            m_oPlugins.Clear();
        }

        private void ListPlugins()
        {
            AppendText("Plugins loaded:" + Constants.vbNewLine);
            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                if (!Information.IsNothing(oPlugin))
                {
                    AppendText(Conversions.ToString(Constants.vbTab + oPlugin.Name + " " + oPlugin.Version + " - " + Interaction.IIf(oPlugin.Enabled, "Enabled", "Disabled") + Constants.vbNewLine));
                    AppendText(Constants.vbTab + Constants.vbTab + m_oPluginNameToFile[oPlugin.Name] + Constants.vbNewLine);
                }
            }

            AppendText(Constants.vbNewLine);
        }

        private void VerifyAndLoadPlugin(GeniePlugin.Interfaces.IPlugin plugin, string pluginkey)
        {
            if (!Information.IsNothing(plugin))
            {
                m_oGlobals.PluginList.Add(plugin);
                try
                {
                    m_oPluginHost.PluginKey = pluginkey;
                    plugin.Initialize(m_oPluginHost);
                }
                catch (Exception ex)
                {
                    ShowDialogPluginException(plugin, "Plugin", ex);
                    if (!Information.IsNothing(plugin))
                        plugin.Enabled = false;
                }
            }
        }

        private void Plugin_EventEchoText(string sText, Color oColor, Color oBgColor)
        {
            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
            string argsTargetWindow = "";
            AddText(sText, oColor, oBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
        }

        private void Plugin_EventSendText(string sText, string sPlugin)
        {
            SafePluginSendText(sText, sPlugin, false);
        }

        public delegate void PluginSendTextDelegate(string sText, string sPlugin, bool bToQueue);

        public void SafePluginSendText(string sText, string sScript, bool bToQueue)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { sText, sScript, false };
                Invoke(new PluginSendTextDelegate(Script_EventSendText), parameters);
            }
            else
            {
                Script_EventSendText(sText, sScript, false);
            }
        }

        // \x and @
        public delegate void ParseInputBoxDelegate(string sText);

        public void SafeParseInputBox(string sText)
        {
            if (InvokeRequired == true)
            {
                var parameters = new[] { sText };
                Invoke(new ParseInputBoxDelegate(ParseInputBox), parameters);
            }
            else
            {
                ParseInputBox(sText);
            }
        }

        private void ParseInputBox(string sText)
        {
            try
            {
                if (sText.Contains(@"\@"))
                    sText = sText.Replace(@"\@", "§#§");
                if (sText.Contains(@"\x"))
                {
                    sText = sText.Replace(@"\x", "");
                    if (sText.Contains("@"))
                    {
                        TextBoxInput.Text = sText.Replace("@", "");
                        TextBoxInput.SelectionLength = 0;
                        TextBoxInput.SelectionStart = sText.IndexOf("@");
                    }
                    else
                    {
                        TextBoxInput.Text = sText;
                        TextBoxInput.SelectionLength = 0;
                        TextBoxInput.SelectionStart = int.MaxValue;
                    }
                }
                else if (sText.Contains("@"))
                {
                    int iLen = TextBoxInput.SelectionStart;
                    TextBoxInput.SelectionLength = 0;
                    TextBoxInput.SelectedText = sText.Replace("@", "");
                    TextBoxInput.SelectionLength = 0;
                    TextBoxInput.SelectionStart = iLen + sText.IndexOf("@");
                }

                if (sText.Contains("§#§"))
                    sText = sText.Replace("§#§", "@");
                TextBoxInput.Focus();
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ParseInputBox", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        public void UpdatePluginsMenuList()
        {
            PluginsToolStripMenuItem.DropDownItems.Clear();
            ToolStripMenuItem ti;
            ti = new ToolStripMenuItem();
            ti.Name = "ToolStripMenuItemPluginDialog";
            ti.Text = "&Plugins...";
            ti.Click += PluginDialogItem_Click;
            PluginsToolStripMenuItem.DropDownItems.Add(ti);
            PluginsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            int I = 1;
            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                if (!Information.IsNothing(oPlugin))
                {
                    ti = new ToolStripMenuItem();
                    ti.Name = "ToolStripMenuItemPlugin" + oPlugin.Name;
                    ti.Text = oPlugin.Name;
                    ti.Tag = oPlugin;
                    // ti.Checked = oPlugin.Enabled
                    ti.Click += PluginMenuItem_Click;
                    PluginsToolStripMenuItem.DropDownItems.Add(ti);
                    I += 1;
                }
            }

            m_PluginDialog.ReloadList();
        }

        private void PluginDialogItem_Click(object sender, EventArgs e)
        {
            m_PluginDialog.MdiParent = this;
            m_PluginDialog.Show();
        }

        private void PluginMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem mi = (ToolStripMenuItem)sender;
                if (!Information.IsNothing(mi.Tag))
                {
                    if (mi.Tag is GeniePlugin.Interfaces.IPlugin)
                    {
                        GeniePlugin.Interfaces.IPlugin oPlugin = (GeniePlugin.Interfaces.IPlugin)mi.Tag;
                        try
                        {
                            oPlugin.Show();
                        }
                        catch (Exception ex)
                        {
                            ShowDialogPluginException(oPlugin, "Show", ex);
                            oPlugin.Enabled = false;
                        }
                    }
                }
            }
        }

        // SafeParsePluginText is for #parse only. Real version is in Game.vb
        public delegate void ParsePluginTextDelegate(string sText, string sWindow);

        public void SafeParsePluginText(string sText, string sWindow)
        {
            if (m_oGlobals.PluginsEnabled == false)
                return;
            if (InvokeRequired == true)
            {
                var parameters = new[] { sText, sWindow };
                Invoke(new ParsePluginTextDelegate(ParsePluginText), parameters);
            }
            else
            {
                ParsePluginText(sText, sWindow);
            }
        }

        private void ParsePluginText(string sText, string sWindow)
        {
            if (m_oGlobals.PluginsEnabled == false)
                return;
            try
            {
                if (m_oGlobals.Config.bAutoMapper)
                    m_oAutoMapper.ParseText(sText);
            }
            catch (Exception ex)
            {
                ShowDialogAutoMapperException("ParseText", ex);
            }

            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                try
                {
                    if (oPlugin.Enabled)
                        oPlugin.ParseText(sText, sWindow);
                }
                /* TODO ERROR: Skipped IfDirectiveTrivia */
                catch (Exception ex)
                {
                    ShowDialogPluginException(oPlugin, "ParseText", ex);
                    oPlugin.Enabled = false;
                    /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                }
            }
        }

        public delegate string ParsePluginInputDelegate(string sText);

        public string SafeParsePluginInput(string sText)
        {
            if (m_oGlobals.PluginsEnabled == false)
                return sText;
            if (InvokeRequired == true)
            {
                var parameters = new[] { sText };
                return Conversions.ToString(Invoke(new ParsePluginInputDelegate(ParsePluginInput), parameters));
            }
            else
            {
                return ParsePluginInput(sText);
            }
        }

        private string ParsePluginInput(string sText)
        {
            if (m_oGlobals.PluginsEnabled == false)
                return sText;
            try
            {
                if (m_oGlobals.Config.bAutoMapper)
                    m_oAutoMapper.ParseInput(sText);
            }
            catch (Exception ex)
            {
                ShowDialogAutoMapperException("ParseInput", ex);
            }

            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                try
                {
                    if (oPlugin.Enabled | sText.StartsWith(Conversions.ToString(m_oGlobals.Config.cMyCommandChar)))
                    {
                        sText = oPlugin.ParseInput(sText);
                    }
                }
                /* TODO ERROR: Skipped IfDirectiveTrivia */
                catch (Exception ex)
                {
                    ShowDialogPluginException(oPlugin, "Input", ex);
                    oPlugin.Enabled = false;
                    /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                }
            }

            return sText;
        }

        public delegate void ParsePluginVariableDelegate(string sVariable);

        public void SafeParsePluginVariable(string sVariable)
        {
            if (m_oGlobals.PluginsEnabled == false)
                return;
            if (InvokeRequired == true)
            {
                var parameters = new[] { sVariable };
                Invoke(new ParsePluginVariableDelegate(ParsePluginVariable), parameters);
            }
            else
            {
                ParsePluginVariable(sVariable);
            }
        }

        private void ParsePluginVariable(string sVariable)
        {
            if (m_oGlobals.PluginsEnabled == false)
                return;
            string sVar = sVariable;
            if (sVar.StartsWith("$"))
            {
                sVar = sVar.Substring(1);
            }

            try
            {
                if (m_oGlobals.Config.bAutoMapper)
                    m_oAutoMapper.VariableChanged(sVar);
            }
            catch (Exception ex)
            {
                ShowDialogAutoMapperException("VariableChanged", ex);
            }

            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                try
                {
                    if (oPlugin.Enabled)
                        oPlugin.VariableChanged(sVar);
                }
                /* TODO ERROR: Skipped IfDirectiveTrivia */
                catch (Exception ex)
                {
                    ShowDialogPluginException(oPlugin, "VariableChanged", ex);
                    oPlugin.Enabled = false;
                    /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                }
            }
        }

        public delegate void ParsePluginXMLDelegate(string sXML);

        public void SafeParseXMLVariable(string sXML)
        {
            if (m_oGlobals.PluginsEnabled == false)
                return;
            if (InvokeRequired == true)
            {
                var parameters = new[] { sXML };
                Invoke(new ParsePluginXMLDelegate(ParsePluginXML), parameters);
            }
            else
            {
                ParsePluginXML(sXML);
            }
        }

        private void ParsePluginXML(string sXML)
        {
            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                try
                {
                    if (oPlugin.Enabled)
                        oPlugin.ParseXML(sXML);
                }
                /* TODO ERROR: Skipped IfDirectiveTrivia */
                catch (Exception ex)
                {
                    ShowDialogPluginException(oPlugin, "ParseXML", ex);
                    oPlugin.Enabled = false;
                    /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                }
            }
        }

        private void Plugin_ParsePluginXML(string xml)
        {
            SafeParseXMLVariable(xml);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public bool bCloseAllDocument = false;
        public bool bCloseNow = false;
        private const int WM_CLOSE = 0x10;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE)
            {
                bCloseAllDocument = true;
                if (!Information.IsNothing(m_oAutoMapper))
                {
                    m_oAutoMapper.IsClosing = true;
                }

                foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
                {
                    try
                    {
                        if (oPlugin.Enabled)
                            oPlugin.ParentClosing();
                    }
                    /* TODO ERROR: Skipped IfDirectiveTrivia */
                    catch (Exception ex)
                    {
                        ShowDialogPluginException(oPlugin, "ParentClosing", ex);
                        oPlugin.Enabled = false;
                        /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    }
                }
            }

            base.WndProc(ref m);
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            TextBoxInput.Focus();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bCloseNow == false)
            {
                if (m_oGame.IsConnected == true & m_oGlobals.Config.bIgnoreCloseAlert == false)
                {
                    if (Interaction.MsgBox("You are connected to the game. Are you sure you want to close?", MsgBoxStyle.YesNo, "Genie") == MsgBoxResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                // If m_oOutputMain.Visible = True Then ' Check so we have windows first.
                // If HasSettingsChanged() = True Then
                // If MsgBox("Your window settings has changed. Do you wish to save them?", MsgBoxStyle.YesNo, "Genie") = MsgBoxResult.Yes Then
                // SaveXMLConfig()
                // End If
                // End If
                // End If
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (My.MyProject.Forms.FormConfig.Visible == false | TextBoxInput.Focused == true)
            {
                if (m_oGlobals.MacroList.Contains(e.KeyData) == true)
                {
                    string argsText = m_oCommand.ParseCommand(((Genie.Macros.Macro)m_oGlobals.MacroList[e.KeyData]).sAction, true, true);
                    var argoColor = Color.Transparent;
                    var argoBgColor = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow = "";
                    AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow); // For some stupid reason we need this. Probably because EndUpdate is fired before we are ready in the other thread.
                    EndUpdate();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private bool m_bLastKeyWasTab = false;

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (TextBoxInput.Text.StartsWith(Conversions.ToString(m_oGlobals.Config.ScriptChar)) == true & TextBoxInput.Text.EndsWith(" ") == false)
                {
                    if (m_bLastKeyWasTab == true)
                    {
                        ListScripts(TextBoxInput.Text.Substring(1) + "*.cmd");
                        m_bLastKeyWasTab = false;
                    }
                    else if (TextBoxInput.Text.Length > 1)
                    {
                        string sTempRow;
                        sTempRow = FindScript(TextBoxInput.Text.Substring(1));
                        if (sTempRow.Length > 0)
                        {
                            TextBoxInput.Text = "." + sTempRow;
                            TextBoxInput.SelectionStart = TextBoxInput.TextLength;
                            if (sTempRow.EndsWith(" ") == false)
                            {
                                m_bLastKeyWasTab = true;
                            }
                            else
                            {
                                Interaction.Beep();
                            } // Sound a tone.
                        }
                        else
                        {
                            m_bLastKeyWasTab = true;
                        }
                    }
                }
                else if (TextBoxInput.Text.ToLower().StartsWith("#edit "))
                {
                    if (m_bLastKeyWasTab == true)
                    {
                        ListScripts(TextBoxInput.Text.Substring(6) + "*.cmd");
                        m_bLastKeyWasTab = false;
                    }
                    else if (TextBoxInput.Text.Length > 1)
                    {
                        string sTempRow;
                        sTempRow = FindScript(TextBoxInput.Text.Substring(6));
                        if (sTempRow.Length > 0)
                        {
                            TextBoxInput.Text = "#edit " + sTempRow;
                            TextBoxInput.SelectionStart = TextBoxInput.TextLength;
                            if (sTempRow.EndsWith(" ") == false)
                            {
                                m_bLastKeyWasTab = true;
                            }
                            else
                            {
                                Interaction.Beep();
                            } // Sound a tone.
                        }
                        else
                        {
                            m_bLastKeyWasTab = true;
                        }
                    }
                }
                else if (TextBoxInput.Text.EndsWith(" ") == false)
                {
                    if (m_bLastKeyWasTab == true)
                    {
                        // Select next
                        if (!Information.IsNothing(TextBoxInput.Tag))
                        {
                            if (m_oGlobals.AliasList.AcquireReaderLock(m_iDefaultTimeout))
                            {
                                try
                                {
                                    var oMatchList = new Genie.Collections.ArrayList();
                                    int I = 0;
                                    int iCurrentId = 0;
                                    foreach (DictionaryEntry de in m_oGlobals.AliasList)
                                    {
                                        if (de.Key.ToString().StartsWith(TextBoxInput.Tag.ToString()))
                                        {
                                            var argvalue = de.Key;
                                            oMatchList.Add(argvalue);
                                            I += 1;
                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(de.Key, TextBoxInput.Text.ToString(), false)))	// Current
                                            {
                                                iCurrentId = I;
                                            }
                                        }
                                    }

                                    if (iCurrentId > oMatchList.Count - 1)
                                    {
                                        iCurrentId = 0; // Restart at 0
                                    }

                                    if (oMatchList.Count > 0)
                                    {
                                        m_bLastKeyWasTab = true;
                                        TextBoxInput.Text = oMatchList[iCurrentId].ToString();
                                        TextBoxInput.SelectionStart = TextBoxInput.TextLength;
                                    }
                                }
                                finally
                                {
                                    m_oGlobals.AliasList.ReleaseReaderLock();
                                }
                            }
                            else
                            {
                                ShowDialogException("Alias KeyDown", "Unable to acquire reader lock.");
                            }
                        }
                    }
                    else if (m_oGlobals.AliasList.AcquireReaderLock(m_iDefaultTimeout))
                    {
                        try
                        {
                            TextBoxInput.Tag = TextBoxInput.Text; // Save match pattern
                            var oMatchList = new Genie.Collections.ArrayList();
                            foreach (DictionaryEntry de in m_oGlobals.AliasList)
                            {
                                if (de.Key.ToString().StartsWith(TextBoxInput.Text))
                                {
                                    var argvalue1 = de.Key;
                                    oMatchList.Add(argvalue1);
                                }
                            }

                            if (oMatchList.Count == 1)
                            {
                                TextBoxInput.Text = oMatchList[0].ToString() + " ";
                                TextBoxInput.SelectionStart = TextBoxInput.TextLength;
                            }
                            else if (oMatchList.Count > 0)
                            {
                                m_bLastKeyWasTab = true;
                                TextBoxInput.Text = oMatchList[0].ToString();
                                TextBoxInput.SelectionStart = TextBoxInput.TextLength;
                            }
                        }
                        finally
                        {
                            m_oGlobals.AliasList.ReleaseReaderLock();
                        }
                    }
                    else
                    {
                        ShowDialogException("Alias KeyDown", "Unable to acquire reader lock.");
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (m_bLastKeyWasTab == true)
            {
                TextBoxInput.Tag = null;
                m_bLastKeyWasTab = false;
            }
        }

        public void ListScripts(string sPattern)
        {
            string sFile;
            int i = 0;

            // Run through all files in a directory
            string argsText = "Scripts matching: " + sPattern + Constants.vbNewLine;
            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
            AddText(argsText, oTargetWindow: argoTargetWindow);
            if (sPattern.IndexOf(@"\") == -1)
            {
                string sLocation = m_oGlobals.Config.ScriptDir;
                if (sLocation.EndsWith(@"\"))
                {
                    sPattern = sLocation + sPattern;
                }
                else
                {
                    sPattern = sLocation + @"\" + sPattern;
                }
            }

            sFile = FileSystem.Dir(sPattern);
            while (!string.IsNullOrEmpty(sFile))
            {
                i += 1;
                string argsText1 = Constants.vbTab + sFile + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                AddText(argsText1, oTargetWindow: argoTargetWindow1);
                sFile = FileSystem.Dir();
            }

            string argsText2 = Constants.vbNewLine + "Found " + i + " files." + Constants.vbNewLine;
            Genie.Game.WindowTarget argoTargetWindow2 = Genie.Game.WindowTarget.Main;
            AddText(argsText2, oTargetWindow: argoTargetWindow2);
        }

        public string FindScript(string sPattern)
        {
            string sDir = string.Empty;
            string sFile = string.Empty;
            string sMin = string.Empty;
            int i = 0;
            if (sPattern.IndexOf(@"\") == -1)
            {
                string sLocation = m_oGlobals.Config.ScriptDir;
                if (sLocation.EndsWith(@"\"))
                {
                    sPattern = sLocation + sPattern;
                }
                else
                {
                    sPattern = sLocation + @"\" + sPattern;
                }
            }

            sDir = FileSystem.Dir(sPattern + "*.cmd", Constants.vbArchive);
            while (!string.IsNullOrEmpty(sDir))
            {
                i += 1;
                sFile = sDir;
                sMin = FindMinString(sMin, sFile);
                sDir = FileSystem.Dir();
            }

            if (i == 1)
            {
                return sFile.ToLower().Replace(".cmd", "") + " ";
            }
            else if (Strings.Len(sMin) > 0)
            {
                return sMin;
            }
            else
            {
                return "";
            }
        }

        private string FindMinString(string s1, string s2)
        {
            long i;
            long iMinLen;
            if (s1.Length == 0) // First loop
            {
                return s2;
            }
            else
            {
                iMinLen = s1.Length;
                if (iMinLen > s2.Length)
                {
                    iMinLen = s2.Length;
                }

                var loopTo = iMinLen - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if (s1[Conversions.ToInteger(i)] != s2[Conversions.ToInteger(i)])
                    {
                        break;
                    }
                }

                if (i > 0)
                {
                    return s1.Substring(0, Conversions.ToInteger(i));
                }
                else
                {
                    return "";
                }
            }
        }

        private FormPlugins _m_PluginDialog;

        private FormPlugins m_PluginDialog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_PluginDialog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_PluginDialog != null)
                {
                    _m_PluginDialog.LoadPlugin -= FormPlugin_LoadPlugin;
                    _m_PluginDialog.UnloadPluginByName -= FormPlugin_UnloadPluginByName;
                    _m_PluginDialog.ReloadPluginByName -= FormPlugin_ReloadPluginByName;
                    _m_PluginDialog.ReloadPlugins -= FormPlugin_ReloadPlugins;
                }

                _m_PluginDialog = value;
                if (_m_PluginDialog != null)
                {
                    _m_PluginDialog.LoadPlugin += FormPlugin_LoadPlugin;
                    _m_PluginDialog.UnloadPluginByName += FormPlugin_UnloadPluginByName;
                    _m_PluginDialog.ReloadPluginByName += FormPlugin_ReloadPluginByName;
                    _m_PluginDialog.ReloadPlugins += FormPlugin_ReloadPlugins;
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            Application.ThreadException += Application_ThreadException;
            /* TODO ERROR: Skipped EndIfDirectiveTrivia */
            // AddHandler SystemEvents.DisplaySettingsChanged, AddressOf FormMain_SizeChange

            foreach (Control ctl in Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = BackColor;
                }
            }

            if (!LoadSizedXMLConfig(m_sConfigFile))
            {
                LoadXMLConfig(m_sConfigFile);
            }

            if (m_bSetDefaultLayout == true)
            {
                PanelStatus.Visible = true;
                PanelBars.Visible = true;
                MagicPanelsToolStripMenuItem.Checked = true;
                SetMagicPanels(true);
                StatusStripMain.Visible = true;
                LayoutBasic();
            }

            ShowForm(m_oOutputMain);
            ShowOutputForms();
            TextBoxInput.Focus();
            Application.DoEvents();

            AppendText("Using Encoding: " + Encoding.Default.EncodingName + Constants.vbNewLine);
            AppendText("Genie User Data Path: " + LocalDirectory.Path + Constants.vbNewLine + Constants.vbNewLine);

            // AppendText(vbNewLine & _
            // "THIS SOFTWARE AND THE ACCOMPANYING FILES ARE SENT ""AS IS"" AND WITHOUT WARRANTY AS TO PERFORMANCE OF MERCHANTABILITY OR ANY OTHER WARRANTIES WHETHER EXPRESSED OR IMPLIED." & vbNewLine & _
            // "The software authors will not be held liable for any damage to your computer system, data files, gaming environment, or for any actions brought against you for using this software. The user must assume the entire risk of running this software." & vbNewLine & _
            // "You may not redistribute this software in any way shape or form without the written permission from the author." & vbNewLine & _
            // vbNewLine & _
            // "BY USING THIS SOFTWARE YOU AGREE TO THE ABOVE STATED TERMS " & vbNewLine & vbNewLine)

            Application.DoEvents();
            AppendText("Loading Settings...");
            m_oGlobals.Config.Load(m_oGlobals.Config.ConfigDir + @"\settings.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Presets...");
            m_oGlobals.PresetList.Load(m_oGlobals.Config.ConfigDir + @"\presets.cfg");
            string argsPreset = "all";
            PresetChanged(argsPreset);
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Global Variables...");
            m_oGlobals.VariableList.Load(m_oGlobals.Config.ConfigDir + @"\variables.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Highlights...");
            m_oGlobals.LoadHighlights(m_oGlobals.Config.ConfigDir + @"\highlights.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Names...");
            m_oGlobals.NameList.Load(m_oGlobals.Config.ConfigDir + @"\names.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Macros...");
            m_oGlobals.MacroList.Load(m_oGlobals.Config.ConfigDir + @"\macros.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Aliases...");
            m_oGlobals.AliasList.Load(m_oGlobals.Config.ConfigDir + @"\aliases.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Substitutes...");
            m_oGlobals.SubstituteList.Load(m_oGlobals.Config.ConfigDir + @"\substitutes.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Gags...");
            m_oGlobals.GagList.Load(m_oGlobals.Config.ConfigDir + @"\gags.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Triggers...");
            m_oGlobals.TriggerList.Load(m_oGlobals.Config.ConfigDir + @"\triggers.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();
            AppendText("Loading Classes...");
            m_oGlobals.ClassList.Load(m_oGlobals.Config.ConfigDir + @"\classes.cfg");
            AppendText("OK" + Constants.vbNewLine);
            Application.DoEvents();

            int I = LoadPlugins();
            Application.DoEvents();

            m_oOutputMain.RichTextBoxOutput.EndTextUpdate();

            // MsgBox("OK")
            // Display RichTextBox
            // ShowOutputBoxes()
            // m_oOutputMain.ShowOutput()

            UpdateLayoutMenu();

            /* TODO ERROR: Skipped IfDirectiveTrivia */
            if (m_bVersionUpdated == true)
            {
                My.MyProject.Forms.DialogChangelog.ShowDialog(this);
            }
            /* TODO ERROR: Skipped EndIfDirectiveTrivia */
            TextBoxInput.Focus();
            InitWorkerThread();
            m_bIsLoading = false;

            // m_oGame.ParseGameRow("*** <pushBold/>BLAH<popBold/> ***")
            m_oOutputMain.RichTextBoxOutput.EndTextUpdate();

            // TEMP TEMP TEMP
            // m_PluginDialog.ShowDialog(Me)

        }

        private void FormPlugin_LoadPlugin(string filename)
        {
            LoadPlugin(filename.Trim());
            UpdatePluginsMenuList();
        }

        private void FormPlugin_UnloadPlugin(string filename)
        {
            UnloadPlugin(filename.Trim());
            UpdatePluginsMenuList();
        }

        private void FormPlugin_UnloadPluginByName(string name)
        {
            UnloadPluginByName(name.Trim());
            UpdatePluginsMenuList();
        }

        private void FormPlugin_ReloadPluginByName(string name)
        {
            string sPluginPath = Path.Combine(LocalDirectory.Path, "Plugins");
            if (m_bDebugPlugin)
            {
                sPluginPath = Application.StartupPath;
            }

            string sFileName = PluginFileName(name);
            if (!Information.IsNothing(sFileName))
            {
                UnloadPluginByName(name.Trim());
                string sTemp = Path.Combine(sPluginPath, sFileName);
                LoadPlugin(sTemp);
                UpdatePluginsMenuList();
            }
        }

        private void FormPlugin_ReloadPlugins()
        {
            AppendText("Reloading plugins ..." + Constants.vbNewLine);
            LoadPlugins();
            m_oOutputMain.RichTextBoxOutput.EndTextUpdate();
        }

        private void FormPlugin_DisablePlugin(string filename)
        {
            EnableOrDisablePluginByFilename(filename, false);
            UpdatePluginsMenuList();
        }

        private void FormPlugin_EnablePlugin(string filename)
        {
            EnableOrDisablePluginByFilename(filename, true);
            UpdatePluginsMenuList();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void CreateGenieFolders()
        {
            Utility.CreateDirectory(LocalDirectory.Path + @"\Config");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Config\Profiles");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Config\Layout");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Config\PluginKeys");
            Utility.MoveLayoutFiles();
            Utility.CreateDirectory(LocalDirectory.Path + @"\Help");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Icons");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Logs");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Scripts");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Sounds");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Plugins");
            Utility.CreateDirectory(LocalDirectory.Path + @"\Maps");
        }

        private bool m_bSetDefaultLayout = false;

        private bool LoadXMLConfig(string sFileName)
        {
            if (Information.IsNothing(sFileName))
            {
                return false;
            }

            if (m_oOutputMain.Visible)
            {
                string argsText = "Layout Loaded: " + sFileName + Constants.vbNewLine;
                var argoColor = Color.WhiteSmoke;
                var argoBgColor = Color.Transparent;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                string argsTargetWindow = "";
                AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
            }

            m_IsChangingLayout = true;

            // Hide all windows
            for (int J = 0, loopTo = MdiChildren.Length - 1; J <= loopTo; J++)
            {
                if (MdiChildren[J] is FormSkin)
                {
                    MdiChildren[J].Tag = false;
                }
            }

            int I = 0;
            string s = string.Empty;
            m_oConfig = new Genie.XMLConfig();
            if (m_oConfig.LoadFile(sFileName) == true)
            {
                I = m_oConfig.GetValue("Genie/Windows/Main", "Width", Width);
                if (I < MinimumSize.Width)
                {
                    I = MinimumSize.Width;
                }

                Width = I;
                I = m_oConfig.GetValue("Genie/Windows/Main", "Height", Height);
                if (I < MinimumSize.Height)
                {
                    I = MinimumSize.Height;
                }

                Height = I;
                I = m_oConfig.GetValue("Genie/Windows/Main", "Left", Left);
                Left = I;
                I = m_oConfig.GetValue("Genie/Windows/Main", "Top", Top);
                Top = I;
                if (m_oConfig.GetValue("Genie/Windows/Main", "Maximized", false) == true)
                {
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                }

                if (m_oConfig.GetValue("Genie/ScriptBar", "Visible", true) == true)
                {
                    ToolStripButtons.Visible = true;
                    ShowScriptBarToolStripMenuItem.Checked = true;
                }
                else
                {
                    ToolStripButtons.Visible = false;
                    ShowScriptBarToolStripMenuItem.Checked = false;
                }

                I = m_oConfig.GetValue("Genie/Windows/Game", "Width", m_oOutputMain.Width);
                if (I < m_oOutputMain.MinimumSize.Width)
                {
                    I = m_oOutputMain.MinimumSize.Width;
                }

                m_oOutputMain.Width = I;
                I = m_oConfig.GetValue("Genie/Windows/Game", "Height", m_oOutputMain.Height);
                if (I < m_oOutputMain.MinimumSize.Height)
                {
                    I = m_oOutputMain.MinimumSize.Height;
                }

                m_oOutputMain.Height = I;
                I = m_oConfig.GetValue("Genie/Windows/Game", "Left", m_oOutputMain.Left);
                if (I < 0)
                {
                    I = 0;
                }

                m_oOutputMain.Left = I;
                I = m_oConfig.GetValue("Genie/Windows/Game", "Top", m_oOutputMain.Top);
                if (I < 0)
                {
                    I = 0;
                }

                bool bTimeStamp = m_oConfig.GetValue("Genie/Windows/Game", "TimeStamp", false);
                m_oOutputMain.TimeStamp = bTimeStamp;
                string sColorName = m_oConfig.GetValue("Genie/Windows/Game", "Colors", string.Empty);
                if (sColorName.Length > 0)
                {
                    if (sColorName.Contains(",") == true && sColorName.EndsWith(",") == false)
                    {
                        string sColor = sColorName.Substring(0, sColorName.IndexOf(",")).Trim();
                        string sBgColor = sColorName.Substring(sColorName.IndexOf(",") + 1).Trim();
                        m_oOutputMain.RichTextBoxOutput.ForeColor = Genie.ColorCode.StringToColor(sColor);
                        m_oOutputMain.RichTextBoxOutput.BackColor = Genie.ColorCode.StringToColor(sBgColor);
                    }
                    else
                    {
                        m_oOutputMain.RichTextBoxOutput.ForeColor = Genie.ColorCode.StringToColor(sColorName);
                    }
                }

                bool bNameListOnly = m_oConfig.GetValue("Genie/Windows/Game", "NameListOnly", false);
                m_oOutputMain.NameListOnly = bNameListOnly;
                string sFontFamily = m_oConfig.GetValue("Genie/Windows/Game/Font", "Family", string.Empty);
                if (sFontFamily.Length > 0)
                {
                    float oFontSize = m_oConfig.GetValueSingle("Genie/Windows/Game/Font", "Size", 9);
                    string sFontStyle = m_oConfig.GetValue("Genie/Windows/Game/Font", "Style", "Regular");
                    FontStyle oFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), sFontStyle, true);
                    m_oOutputMain.TextFont = new Font(sFontFamily, oFontSize, oFontStyle);
                }

                string sMonoFontFamily = m_oConfig.GetValue("Genie/Windows/MonoFont", "Family", string.Empty);
                if (sMonoFontFamily.Length > 0)
                {
                    float oFontSize = m_oConfig.GetValueSingle("Genie/Windows/MonoFont", "Size", 9);
                    string sFontStyle = m_oConfig.GetValue("Genie/Windows/MonoFont", "Style", "Regular");
                    FontStyle oFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), sFontStyle, true);
                    m_oGlobals.Config.MonoFont = new Font(sMonoFontFamily, oFontSize, oFontStyle);
                }

                string sInputFontFamily = m_oConfig.GetValue("Genie/Windows/InputFont", "Family", string.Empty);
                if (sInputFontFamily.Length > 0)
                {
                    float oFontSize = m_oConfig.GetValueSingle("Genie/Windows/InputFont", "Size", 9);
                    string sFontStyle = m_oConfig.GetValue("Genie/Windows/InputFont", "Style", "Regular");
                    FontStyle oFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), sFontStyle, true);
                    m_oGlobals.Config.InputFont = new Font(sInputFontFamily, oFontSize, oFontStyle);
                    UpdateInputFont();
                }

                m_oOutputMain.Top = I;
                I = m_oConfig.GetValue("Genie/Windows", "WindowCount", 0);
                if (I > 0)
                {
                    int j = 0;
                    while (j < I)
                    {
                        j = j + 1;
                        string sName = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Name", "Output");
                        string sID = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "ID", "nothing");
                        if ((sID ?? "") == "nothing")
                        {
                            sID = sName.ToLower();
                            if ((sID ?? "") == "inventory")
                                sID = "inv";
                        }

                        string sIfClosed = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "IfClosed", "nothing");
                        if ((sIfClosed ?? "") == "nothing")
                        {
                            sIfClosed = null;
                        }

                        int iWidth = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Width", 100);
                        int iHeight = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Height", 100);
                        int iTop = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Top", 0);
                        int iLeft = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Left", 0);
                        bool bVisible = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Visible", true);
                        sColorName = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Colors", string.Empty);
                        bTimeStamp = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "TimeStamp", false);
                        bNameListOnly = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "NameListOnly", false);
                        FormSkin oFormTemp = null;
                        sFontFamily = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString() + "/Font", "Family", string.Empty);
                        if (sFontFamily.Length > 0)
                        {
                            float oFontSize = m_oConfig.GetValueSingle("Genie/Windows/Window" + j.ToString() + "/Font", "Size", 9);
                            string sFontStyle = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString() + "/Font", "Style", "Regular");
                            FontStyle oFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), sFontStyle, true);
                            oFormTemp = SafeCreateOutputForm(sID, sName, sIfClosed, iWidth, iHeight, iTop, iLeft, bVisible, new Font(sFontFamily, oFontSize, oFontStyle), sColorName);
                        }
                        else
                        {
                            oFormTemp = SafeCreateOutputForm(sID, sName, sIfClosed, iWidth, iHeight, iTop, iLeft, bVisible, null, sColorName);
                        }

                        if (!Information.IsNothing(oFormTemp))
                        {
                            oFormTemp.TimeStamp = bTimeStamp;
                            oFormTemp.NameListOnly = bNameListOnly;
                        }
                    }
                }

                string sDock = m_oConfig.GetValue("Genie/ScriptBar", "Dock", "Top");
                if ((sDock.ToLower() ?? "") == "top")
                {
                    ToolStripButtons.Dock = DockStyle.Top;
                    DockTopToolStripMenuItem1.Checked = true;
                    DockBottomToolStripMenuItem1.Checked = false;
                }
                else
                {
                    ToolStripButtons.Dock = DockStyle.Bottom;
                    DockTopToolStripMenuItem1.Checked = false;
                    DockBottomToolStripMenuItem1.Checked = true;
                }

                sDock = m_oConfig.GetValue("Genie/IconBar", "Dock", "Bottom");
                if ((sDock.ToLower() ?? "") == "top")
                {
                    PanelStatus.Dock = DockStyle.Top;
                    DockTopToolStripMenuItem.Checked = true;
                    DockBottomToolStripMenuItem.Checked = false;
                }
                else
                {
                    PanelStatus.Dock = DockStyle.Bottom;
                    DockTopToolStripMenuItem.Checked = false;
                    DockBottomToolStripMenuItem.Checked = true;
                }

                sDock = m_oConfig.GetValue("Genie/HealthBar", "Dock", "Bottom");
                if ((sDock.ToLower() ?? "") == "top")
                {
                    PanelBars.Dock = DockStyle.Top;
                    DockTopToolStripMenuItem2.Checked = true;
                    DockBottomToolStripMenuItem2.Checked = false;
                }
                else
                {
                    PanelBars.Dock = DockStyle.Bottom;
                    DockTopToolStripMenuItem2.Checked = false;
                    DockBottomToolStripMenuItem2.Checked = true;
                }

                bool bShow = true;
                bShow = m_oConfig.GetValue("Genie/IconBar", "Visible", true);
                PanelStatus.Visible = bShow;
                bShow = m_oConfig.GetValue("Genie/HealthBar", "Visible", true);
                PanelBars.Visible = bShow;
                bShow = m_oConfig.GetValue("Genie/HealthBar", "Magic", true);
                SetMagicPanels(bShow);
                bShow = m_oConfig.GetValue("Genie/StatusBar", "Visible", true);
                StatusStripMain.Visible = bShow;
                SetDefaultSettings();
                m_IsChangingLayout = false;
                UpdateWindowMenuList();
                return true;
            }
            else
            {
                m_oConfig.LoadXml("<Genie><Windows></Windows><Settings></Settings></Genie>");
                SetDefaultSettings();
                m_bSetDefaultLayout = true;
                m_IsChangingLayout = false;
                UpdateWindowMenuList();
                return false;
            }
        }

        public bool SaveXMLConfig(string filename = null)
        {
            if (m_oConfig.GetValue("Genie/Windows/Game", "Name", string.Empty).Length == 0)
            {
                m_oConfig.LoadXml("<Genie><Windows></Windows><Settings></Settings></Genie>");
            }

            if (WindowState == FormWindowState.Normal)
            {
                m_oConfig.SetValue("Genie/Windows/Main", "Height", Height.ToString());
                m_oConfig.SetValue("Genie/Windows/Main", "Width", Width.ToString());
                m_oConfig.SetValue("Genie/Windows/Main", "Left", Left.ToString());
                m_oConfig.SetValue("Genie/Windows/Main", "Top", Top.ToString());
            }

            m_oConfig.SetValue("Genie/Windows/Main", "Maximized", (WindowState == FormWindowState.Maximized).ToString());
            m_oConfig.SetValue("Genie/ScriptBar", "Visible", ToolStripButtons.Visible.ToString());
            m_oConfig.SetValue("Genie/Windows/MonoFont", "Family", m_oGlobals.Config.MonoFont.Name.ToString());
            m_oConfig.SetValue("Genie/Windows/MonoFont", "Size", m_oGlobals.Config.MonoFont.Size.ToString());
            m_oConfig.SetValue("Genie/Windows/MonoFont", "Style", m_oGlobals.Config.MonoFont.Style.ToString());
            m_oConfig.SetValue("Genie/Windows/InputFont", "Family", m_oGlobals.Config.InputFont.Name.ToString());
            m_oConfig.SetValue("Genie/Windows/InputFont", "Size", m_oGlobals.Config.InputFont.Size.ToString());
            m_oConfig.SetValue("Genie/Windows/InputFont", "Style", m_oGlobals.Config.InputFont.Style.ToString());
            m_oConfig.SetValue("Genie/Windows/Game", "ID", "main");
            m_oConfig.SetValue("Genie/Windows/Game", "Name", m_oOutputMain.Title);
            m_oConfig.SetValue("Genie/Windows/Game", "Height", m_oOutputMain.Height.ToString());
            m_oConfig.SetValue("Genie/Windows/Game", "Width", m_oOutputMain.Width.ToString());
            m_oConfig.SetValue("Genie/Windows/Game", "Left", m_oOutputMain.Left.ToString());
            m_oConfig.SetValue("Genie/Windows/Game", "Top", m_oOutputMain.Top.ToString());
            m_oConfig.SetValue("Genie/Windows/Game", "TimeStamp", m_oOutputMain.TimeStamp.ToString());
            m_oConfig.SetValue("Genie/Windows/Game", "Colors", Genie.ColorCode.ColorToString(m_oOutputMain.RichTextBoxOutput.ForeColor, m_oOutputMain.RichTextBoxOutput.BackColor));
            m_oConfig.SetValue("Genie/Windows/Game", "NameListOnly", m_oOutputMain.NameListOnly.ToString());
            m_oConfig.SetValue("Genie/Windows/Game/Font", "Family", m_oOutputMain.TextFont.Name.ToString());
            m_oConfig.SetValue("Genie/Windows/Game/Font", "Size", m_oOutputMain.TextFont.Size.ToString());
            m_oConfig.SetValue("Genie/Windows/Game/Font", "Style", m_oOutputMain.TextFont.Style.ToString());
            RemoveDisposedForms();
            FormSkin tmpFormSkin;
            var myEnumerator = m_oFormList.GetEnumerator();
            string WindowList = string.Empty;
            int i = 0;
            while (myEnumerator.MoveNext())
            {
                tmpFormSkin = (FormSkin)myEnumerator.Current;
                i = i + 1;
                if (Information.IsNothing(tmpFormSkin.ID))
                {
                    tmpFormSkin.ID = tmpFormSkin.Title.ToLower();
                }

                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "ID", tmpFormSkin.ID);
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "Name", tmpFormSkin.Title);
                if (!Information.IsNothing(tmpFormSkin.IfClosed))
                {
                    m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "IfClosed", tmpFormSkin.IfClosed);
                }

                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "Height", tmpFormSkin.Height.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "Width", tmpFormSkin.Width.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "Left", tmpFormSkin.Left.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "Top", tmpFormSkin.Top.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "Visible", tmpFormSkin.Visible.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "TimeStamp", tmpFormSkin.TimeStamp.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "Colors", Genie.ColorCode.ColorToString(tmpFormSkin.RichTextBoxOutput.ForeColor, tmpFormSkin.RichTextBoxOutput.BackColor));
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString(), "NameListOnly", tmpFormSkin.NameListOnly.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString() + "/Font", "Family", tmpFormSkin.TextFont.Name.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString() + "/Font", "Size", tmpFormSkin.TextFont.Size.ToString());
                m_oConfig.SetValue("Genie/Windows/Window" + i.ToString() + "/Font", "Style", tmpFormSkin.TextFont.Style.ToString());
            }

            m_oConfig.SetValue("Genie/Windows", "WindowCount", i.ToString());
            m_oConfig.SetValue("Genie/IconBar", "Visible", PanelStatus.Visible.ToString());
            m_oConfig.SetValue("Genie/HealthBar", "Visible", PanelBars.Visible.ToString());
            m_oConfig.SetValue("Genie/HealthBar", "Magic", MagicPanelsToolStripMenuItem.Checked.ToString());
            m_oConfig.SetValue("Genie/StatusBar", "Visible", StatusStripMain.Visible.ToString());
            m_oConfig.SetValue("Genie/IconBar", "Dock", PanelStatus.Dock.ToString());
            m_oConfig.SetValue("Genie/HealthBar", "Dock", PanelBars.Dock.ToString());
            m_oConfig.SetValue("Genie/ScriptBar", "Dock", ToolStripButtons.Dock.ToString());
            if (Information.IsNothing(filename))
            {
                return m_oConfig.SaveToFile();
            }
            else
            {
                return m_oConfig.SaveToFile(filename);
            }
        }

        private void EventStreamWindow(object sID, object sTitle, object sIfClosed)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sID, "main", false)))
                return;
            var fo = FindSkinFormByIDOrName(Conversions.ToString(sID), Conversions.ToString(sTitle));
            if (Information.IsNothing(fo))
            {
                SafeCreateOutputForm(Conversions.ToString(sID), Conversions.ToString(sTitle), Conversions.ToString(sIfClosed), 300, 200, 10, 10, false, null, "", true);
                string argsText = Conversions.ToString("Created new window: " + sID + Constants.vbNewLine);
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
            }
            else if (Information.IsNothing(fo.IfClosed) & !Information.IsNothing(sIfClosed))
            {
                fo.IfClosed = Conversions.ToString(sIfClosed);
                string argsText1 = Conversions.ToString("Altered window: " + sID + Constants.vbNewLine);
                Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                AddText(argsText1, oTargetWindow: argoTargetWindow1);
            }
        }

        private bool HasSettingsChanged()
        {
            int I;
            string s = string.Empty;
            if (Information.IsNothing(m_oConfig))
            {
                return true;
            }

            if (m_oConfig.HasData == false)
            {
                return true;
            }

            if (m_oConfig.GetValue("Genie/Windows/Main", "Maximized", false) == true)
            {
                if (WindowState != FormWindowState.Maximized)
                {
                    return true;
                }
            }
            else if (WindowState != FormWindowState.Normal)
            {
                return true;
            }
            else
            {
                I = m_oConfig.GetValue("Genie/Windows/Main", "Width", Width);
                if (I < MinimumSize.Width)
                {
                    I = MinimumSize.Width;
                }

                if (Width != I)
                {
                    return true;
                }

                I = m_oConfig.GetValue("Genie/Windows/Main", "Height", Height);
                if (I < MinimumSize.Height)
                {
                    I = MinimumSize.Height;
                }

                if (Height != I)
                {
                    return true;
                }

                I = m_oConfig.GetValue("Genie/Windows/Main", "Left", Left);
                if (Left != I)
                {
                    return true;
                }

                I = m_oConfig.GetValue("Genie/Windows/Main", "Top", Top);
                if (Top != I)
                {
                    return true;
                }
            }

            I = m_oConfig.GetValue("Genie/Windows/Game", "Width", m_oOutputMain.Width);
            if (I < m_oOutputMain.MinimumSize.Width)
            {
                I = m_oOutputMain.MinimumSize.Width;
            }

            if (m_oOutputMain.Width != I)
            {
                return true;
            }

            I = m_oConfig.GetValue("Genie/Windows/Game", "Height", m_oOutputMain.Height);
            if (I < m_oOutputMain.MinimumSize.Height)
            {
                I = m_oOutputMain.MinimumSize.Height;
            }

            if (m_oOutputMain.Height != I)
            {
                return true;
            }

            I = m_oConfig.GetValue("Genie/Windows/Game", "Left", m_oOutputMain.Left);
            if (I < 0)
            {
                I = 0;
            }

            if (m_oOutputMain.Left != I)
            {
                return true;
            }

            I = m_oConfig.GetValue("Genie/Windows/Game", "Top", m_oOutputMain.Top);
            if (I < 0)
            {
                I = 0;
            }

            if (m_oOutputMain.Top != I)
            {
                return true;
            }

            I = m_oConfig.GetValue("Genie/Windows", "WindowCount", 0);
            if (I > 0)
            {
                int j = 0;
                while (j < I)
                {
                    j = j + 1;
                    string sName = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Name", "Output");
                    int iWidth = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Width", 100);
                    int iHeight = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Height", 100);
                    int iTop = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Top", 0);
                    int iLeft = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Left", 0);
                    bool bVisible = m_oConfig.GetValue("Genie/Windows/Window" + j.ToString(), "Visible", true);
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(HasWindowsChanged(sName, iWidth, iHeight, iTop, iLeft, bVisible), true, false)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private object HasWindowsChanged(string sID, int iWidth, int iHeight, int iTop, int iLeft, bool bIsVisible)
        {
            var oEnumerator = m_oFormList.GetEnumerator();
            FormSkin oOutput;
            while (oEnumerator.MoveNext())
            {
                oOutput = (FormSkin)oEnumerator.Current;
                if ((oOutput.ID ?? "") == (sID ?? ""))
                {
                    if (oOutput.Width != iWidth)
                    {
                        return true;
                    }

                    if (oOutput.Height != iHeight)
                    {
                        return true;
                    }

                    if (oOutput.Top != iTop)
                    {
                        return true;
                    }

                    if (oOutput.Left != iLeft)
                    {
                        return true;
                    }

                    if (oOutput.Visible != bIsVisible)
                    {
                        return true;
                    }

                    return false;
                }
            }

            return true;
        }

        private void SetDefaultSettings()
        {
            if (Information.IsNothing(m_oOutputInv))
            {
                SafeCreateOutputForm("inv", "Inventory", null, 300, 200, 10, 10, false);
            }

            if (Information.IsNothing(m_oOutputFamiliar))
            {
                SafeCreateOutputForm("familiar", "Familiar", "game", 300, 200, 10, 10, false);
            }

            if (Information.IsNothing(m_oOutputThoughts))
            {
                SafeCreateOutputForm("thoughts", "Thoughts", "game", 300, 200, 10, 10, false);
                m_oOutputThoughts.TimeStamp = true;
            }

            if (Information.IsNothing(m_oOutputLogons))
            {
                SafeCreateOutputForm("logons", "Arrivals", "", 300, 200, 10, 10, false);
                m_oOutputLogons.TimeStamp = true;
            }

            if (Information.IsNothing(m_oOutputDeath))
            {
                SafeCreateOutputForm("death", "Deaths", "", 300, 200, 10, 10, false);
                m_oOutputDeath.TimeStamp = true;
            }

            if (Information.IsNothing(m_oOutputLog))
            {
                SafeCreateOutputForm("log", "Log", null, 300, 200, 10, 10, false);
                m_oOutputLog.TimeStamp = true;
            }

            if (Information.IsNothing(m_oOutputRoom))
            {
                SafeCreateOutputForm("room", "Room", null, 300, 200, 10, 10, false);
            }

            if (Information.IsNothing(FindSkinFormByID("talk")))
            {
                SafeCreateOutputForm("talk", "Talk", "conversation", 300, 200, 10, 10, false);
            }

            if (Information.IsNothing(FindSkinFormByID("whispers")))
            {
                SafeCreateOutputForm("whispers", "Whispers", "conversation", 300, 200, 10, 10, false);
            }

            if (Information.IsNothing(FindSkinFormByID("conversation")))
            {
                SafeCreateOutputForm("conversation", "Conversation", "log", 300, 200, 10, 10, false);
            }

            if (Information.IsNothing(FindSkinFormByID("raw")))
            {
                SafeCreateOutputForm("raw", "Raw", "", 300, 200, 10, 10, false);
            }
        }

        public new object ClientSize
        {
            get
            {
                var oSize = base.ClientSize;
                oSize.Height = ClientHeight;
                return oSize;
            }

            set
            {
                base.ClientSize = (Size)value;
            }
        }

        public int ClientHeight
        {
            get
            {
                return Conversions.ToInteger(base.ClientSize.Height - (PanelStatus.Visible ? PanelStatus.Height : 0) - MenuStripMain.Height - (ToolStripButtons.Visible ? ToolStripButtons.Height : 0) - PanelInput.Height - (StatusStripMain.Visible ? StatusStripMain.Height : 0) - (PanelBars.Visible ? PanelBars.Height : 0));
            }
        }

        private void LayoutBasic()
        {
            m_IsChangingLayout = true;
            HideTagOutputForms();
            m_oOutputThoughts.Tag = true;
            m_oOutputRoom.Tag = true;
            m_oOutputLog.Tag = true;
            HideOutputForms();
            m_oOutputMain.Top = 0;
            m_oOutputMain.Left = 0;
            m_oOutputMain.Width = Conversions.ToInteger(Math.Floor(((Size)ClientSize).Width * 0.7));
            m_oOutputMain.Height = Conversions.ToInteger(((Size)ClientSize).Height - SystemInformation.Border3DSize.Height * 2); // - IIf(PanelStatus.Visible, PanelStatus.Height, 0) - MenuStripMain.Height - IIf(ToolStripButtons.Visible, ToolStripButtons.Height, 0) - PanelInput.Height - IIf(StatusStripMain.Visible, StatusStripMain.Height, 0) - IIf(PanelBars.Visible, PanelBars.Height, 0) - iMargin
            int h = Conversions.ToInteger(Math.Floor(m_oOutputMain.Height / (double)3));
            m_oOutputThoughts.Top = 0;
            m_oOutputThoughts.Left = m_oOutputMain.Width;
            m_oOutputThoughts.Width = Conversions.ToInteger(((Size)ClientSize).Width - m_oOutputMain.Width - SystemInformation.Border3DSize.Width * 2);
            m_oOutputThoughts.Height = h;
            m_oOutputRoom.Top = m_oOutputThoughts.Height;
            m_oOutputRoom.Left = m_oOutputMain.Width;
            m_oOutputRoom.Width = m_oOutputThoughts.Width;
            m_oOutputRoom.Height = h; // Math.Floor(h / 2)
            m_oOutputLog.Top = m_oOutputThoughts.Height + m_oOutputRoom.Height;
            m_oOutputLog.Left = m_oOutputMain.Width;
            m_oOutputLog.Width = m_oOutputThoughts.Width;
            m_oOutputLog.Height = m_oOutputMain.Height - m_oOutputLog.Top;
            m_oOutputMain.Visible = true;
            m_oOutputThoughts.Visible = true;
            m_oOutputRoom.Visible = true;
            m_oOutputLog.Visible = true;
            ShowOutputForms();
            ShowForm(m_oOutputMain);
            m_IsChangingLayout = false;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private const int m_iDefaultTimeout = 2500;

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Genie.ScriptList m_oScriptList = new Genie.ScriptList();
        private Genie.ScriptList m_oScriptListNew = new Genie.ScriptList(); // New scripts end up here

        private void TickScripts()
        {
            if (m_oScriptList.AcquireReaderLock())
            {
                try
                {
                    foreach (Script oScript in m_oScriptList)
                        oScript.TickScript();
                }
                finally
                {
                    m_oScriptList.ReleaseReaderLock();
                }
            }
            else // Doesn't matter if we miss a pulse on TickScripts()
            {
                Debug.Print("ScriptList Reader Lock failed in TickScripts");
            }
        }

        public delegate void RemoveExitedScriptsDelegate();

        private void SafeRemoveExitedScripts()
        {
            try
            {
                if (InvokeRequired == true)
                {
                    Invoke(new RemoveExitedScriptsDelegate(RemoveExitedScripts));
                }
                else
                {
                    RemoveExitedScripts();
                }
            }
            catch (Exception ex)
            {
            } // Don't care. Close
        }

        private bool m_bScriptListUpdated = false;

        private void RemoveExitedScripts()
        {
            if (m_oScriptList.AcquireReaderLock())
            {
                var removeList = new List<int>();
                try
                {
                    for (var i = 0; i < m_oScriptList.Count; i++)
                    {
                        if (m_oScriptList[i].ScriptDone)
                        {
                            removeList.Add(i);
                        }
                    }
                }
                finally
                {
                    for (var i = removeList.Count-1; i > -1; i--)
                    {
                        m_oScriptList.RemoveAt(removeList[i]);
                    }

                    m_oScriptList.ReleaseReaderLock();
                }
            }
            else
            {
                Debug.Print("ScriptList Reader Lock failed in RemoveExitedScripts");
            }

            // If ToolStripButtons.Visible = False Then Exit Sub

            // If Monitor.TryEnter(ToolStripButtons.Items) Then
            // Try
            // Dim I As Integer = 0
            // While I <= ToolStripButtons.Items.Count - 1
            // Dim oItem As Object = ToolStripButtons.Items(I)
            // If TypeOf oItem Is ToolStripSplitButton AndAlso IsNothing(oItem.Tag) Then
            // ToolStripButtons.Items.Remove(oItem)
            // ElseIf TypeOf oItem Is ToolStripSplitButton AndAlso TypeOf oItem.Tag Is Script AndAlso DirectCast(oItem.Tag, Script).ScriptDone = True Then
            // ToolStripButtons.Items.Remove(oItem)
            // Else
            // I += 1
            // End If
            // End While
            // 'Catch ex As Exception
            // '    Throw (ex)
            // Finally
            // Monitor.Exit(ToolStripButtons.Items)
            // End Try
            // Else
            // Throw New Exception("Unable to lock toolstrip for removeexitedscripts()")
            // End If
        }

        private void SetScriptDebugLevel(ToolStripSplitButton oButton, int DebugLevel)
        {
            if (oButton.DropDownItems.ContainsKey("Debuglevel"))
            {
                ToolStripMenuItem oDebugItem = (ToolStripMenuItem)oButton.DropDownItems["Debuglevel"];
                foreach (object oItem in oDebugItem.DropDownItems)
                {
                    if (oItem is ToolStripMenuItem)
                    {
                        if (!Information.IsNothing(((ToolStripMenuItem)oItem).Tag) && ((ToolStripMenuItem)oItem).Tag is int)
                        {
                            if ((int)((ToolStripMenuItem)oItem).Tag == DebugLevel)
                            {
                                ((ToolStripMenuItem)oItem).Checked = true;
                            }
                            else
                            {
                                ((ToolStripMenuItem)oItem).Checked = false;
                            }
                        }
                    }
                }
            }
        }

        private void SetScriptName(ToolStripSplitButton oButton)
        {
            if (!Information.IsNothing(oButton.Tag))
            {
                if (oButton.Tag is Script)
                {
                    Script oScriptRef = (Script)oButton.Tag;
                    if (oScriptRef.DebugLevel > 0)
                    {
                        oButton.Text = oScriptRef.ScriptName + " (Debug: " + oScriptRef.DebugLevel + ")";
                    }
                    else
                    {
                        oButton.Text = oScriptRef.ScriptName;
                    }
                }
            }
        }

        private void AddScriptToToolStrip(Script oScript)
        {
            if (ToolStripButtons.Visible == false)
                return;
            if (Monitor.TryEnter(ToolStripButtons.Items))
            {
                try
                {
                    var oScriptButton = new ToolStripSplitButton();
                    oScriptButton.Name = "Script_" + oScript.ScriptID;
                    oScriptButton.Text = "";
                    oScriptButton.Image = My.Resources.Resources.control_play;
                    oScriptButton.Tag = oScript;
                    oScriptButton.ButtonClick += ScriptButton_Click;
                    var oMenuItemResume = new ToolStripMenuItem();
                    oMenuItemResume.Text = "Resume";
                    oMenuItemResume.Image = My.Resources.Resources.control_play;
                    oMenuItemResume.Click += ScriptButtonResume_Click;
                    var oMenuItemPause = new ToolStripMenuItem();
                    oMenuItemPause.Text = "Pause";
                    oMenuItemPause.Image = My.Resources.Resources.control_pause;
                    oMenuItemPause.Click += ScriptButtonPause_Click;
                    var oMenuItemAbort = new ToolStripMenuItem();
                    oMenuItemAbort.Text = "Abort";
                    oMenuItemAbort.Image = My.Resources.Resources.control_stop;
                    oMenuItemAbort.Click += ScriptButtonAbort_Click;
                    var oMenuItemTrace = new ToolStripMenuItem();
                    oMenuItemTrace.Text = "Show Trace";
                    oMenuItemTrace.Click += ScriptButtonTrace_Click;
                    var oMenuItemVars = new ToolStripMenuItem();
                    oMenuItemVars.Text = "Show Vars";
                    oMenuItemVars.Click += ScriptButtonVars_Click;
                    var oMenuItemEdit = new ToolStripMenuItem();
                    oMenuItemEdit.Text = "Edit";
                    oMenuItemEdit.Click += ScriptButtonEdit_Click;
                    var oMenuItemDebug = new ToolStripMenuItem();
                    oMenuItemDebug.Name = "Debuglevel";
                    oMenuItemDebug.Text = "Debug";
                    var oMenuItemDebug0 = new ToolStripMenuItem();
                    oMenuItemDebug0.Text = "0. Debug off (Default)";
                    oMenuItemDebug0.Checked = true;
                    oMenuItemDebug0.Tag = 0;
                    var oMenuItemDebug1 = new ToolStripMenuItem();
                    oMenuItemDebug1.Text = "1. Goto, gosub, return, labels";
                    oMenuItemDebug1.Tag = 1;
                    var oMenuItemDebug2 = new ToolStripMenuItem();
                    oMenuItemDebug2.Text = "2. Pause, wait, waitfor, move";
                    oMenuItemDebug2.Tag = 2;
                    var oMenuItemDebug3 = new ToolStripMenuItem();
                    oMenuItemDebug3.Text = "3. If evaluations";
                    oMenuItemDebug3.Tag = 3;
                    var oMenuItemDebug4 = new ToolStripMenuItem();
                    oMenuItemDebug4.Text = "4. Math, evalmath, counter, variables";
                    oMenuItemDebug4.Tag = 4;
                    var oMenuItemDebug5 = new ToolStripMenuItem();
                    oMenuItemDebug5.Text = "5. Actions";
                    oMenuItemDebug5.Tag = 5;
                    var oMenuItemDebug10 = new ToolStripMenuItem();
                    oMenuItemDebug10.Text = "10. Raw script lines";
                    oMenuItemDebug10.Tag = 10;
                    oMenuItemDebug0.Click += ScriptButtonDebuglevel_Click;
                    oMenuItemDebug1.Click += ScriptButtonDebuglevel_Click;
                    oMenuItemDebug2.Click += ScriptButtonDebuglevel_Click;
                    oMenuItemDebug3.Click += ScriptButtonDebuglevel_Click;
                    oMenuItemDebug4.Click += ScriptButtonDebuglevel_Click;
                    oMenuItemDebug5.Click += ScriptButtonDebuglevel_Click;
                    oMenuItemDebug10.Click += ScriptButtonDebuglevel_Click;
                    oMenuItemDebug.DropDownItems.AddRange(new ToolStripItem[] { oMenuItemDebug0, oMenuItemDebug1, oMenuItemDebug2, oMenuItemDebug3, oMenuItemDebug4, oMenuItemDebug5, oMenuItemDebug10 });
                    oScriptButton.DropDownItems.AddRange(new ToolStripItem[] { oMenuItemResume, oMenuItemPause, oMenuItemAbort, new ToolStripSeparator(), oMenuItemDebug, oMenuItemTrace, oMenuItemVars, oMenuItemEdit });
                    Script oScriptRef = (Script)oScriptButton.Tag;
                    ToolStripButtons.Items.Add(oScriptButton);
                    SetScriptName(oScriptButton);
                    oMenuItemEdit.Text = "Edit " + oScriptRef.FileName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Monitor.Exit(ToolStripButtons.Items);
                }
            }
            else
            {
                throw new Exception("Unable to lock toolstrip for addscripttotoolstrip()");
            }
        }

        private Script LoadScript(string sScriptName, ArrayList oArgList)
        {
            if (m_oGlobals.Config.bAbortDupeScript == true)
            {
                // Dupe check (Only run one script with same name - Replace if it already exists)
                if (m_oScriptList.AcquireReaderLock())
                {
                    try
                    {
                        foreach (Script oThisScript in m_oScriptList)
                        {
                            if ((oThisScript.FileName ?? "") == (sScriptName ?? ""))
                            {
                                oThisScript.AbortScript();
                            }
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                    }
                }
                else
                {
                    Debug.Print("ScriptList Reader Lock failed in LoadScript");
                }
            }

            var argcl = m_oGlobals;
            var oScript = new Script(argcl);
            oScript.EventPrintError += Script_EventPrintError;
            oScript.EventPrintText += Script_EventPrintText;
            oScript.EventSendText += Script_EventSendText;
            GenieError.EventGenieError += HandleGenieException;
            oScript.EventDebugChanged += Script_EventDebugChanged;
            oScript.EventStatusChanged += Script_EventStatusChanged;
            if (oScript.LoadFile(sScriptName, oArgList) == true)
            {
                return oScript;
            }
            else
            {
                return null;
            }
        }

        private void Script_EventDebugChanged(Script sender, int iLevel)
        {
            if (ToolStripButtons.Visible == false)
                return;
            if (Monitor.TryEnter(ToolStripButtons.Items))
            {
                try
                {
                    foreach (object oItem in ToolStripButtons.Items)
                    {
                        if (oItem is ToolStripSplitButton)
                        {
                            if (((ToolStripSplitButton)oItem).Tag is Script && (((Script)((ToolStripSplitButton)oItem).Tag).ScriptID ?? "") == (sender.ScriptID ?? ""))
                            {
                                ToolStripSplitButton argoButton = (ToolStripSplitButton)oItem;
                                SetScriptDebugLevel(argoButton, iLevel);
                                ToolStripSplitButton argoButton1 = (ToolStripSplitButton)oItem;
                                SetScriptName(argoButton1);
                            }
                        }
                    }
                }
                // Catch ex As Exception
                // Throw (ex)
                finally
                {
                    Monitor.Exit(ToolStripButtons.Items);
                }
            }
            else
            {
                throw new Exception("Unable to lock toolstrip for eventdebugchanged()");
            }
        }

        private void Script_EventStatusChanged(Script sender, Script.ScriptState state)
        {
            m_bScriptListUpdated = true;
            if (ToolStripButtons.Visible == false)
                return;
            if (Monitor.TryEnter(ToolStripButtons.Items))
            {
                try
                {
                    foreach (object oItem in ToolStripButtons.Items)
                    {
                        if (oItem is ToolStripSplitButton)
                        {
                            if (((ToolStripSplitButton)oItem).Tag is Script && (((Script)((ToolStripSplitButton)oItem).Tag).ScriptID ?? "") == (sender.ScriptID ?? ""))
                            {
                                if (state == Script.ScriptState.finished)
                                {
                                    ToolStripButtons.Items.Remove((ToolStripSplitButton)oItem);
                                }
                                else if (state == Script.ScriptState.pausing)
                                {
                                    ((ToolStripSplitButton)oItem).Image = My.Resources.Resources.control_pause;
                                }
                                else if (state == Script.ScriptState.running)
                                {
                                    ((ToolStripSplitButton)oItem).Image = My.Resources.Resources.control_play;
                                }

                                break;
                            }
                        }
                    }
                }
                // Catch ex As Exception
                // Throw (ex)
                finally
                {
                    Monitor.Exit(ToolStripButtons.Items);
                }
            }
            else
            {
                throw new Exception("Unable to lock toolstrip for eventdebugchanged()");
            }
        }

        private void ScriptButton_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripSplitButton)
            {
                ToolStripSplitButton oButton = (ToolStripSplitButton)sender;
                if (!Information.IsNothing(oButton.Tag))
                {
                    Script oMyScript = (Script)oButton.Tag;
                    if (oMyScript.ScriptPaused == true)
                    {
                        oMyScript.ResumeScript();
                    }
                    // oButton.Image = Global.Genie.My.Resources.Resources.control_play
                    else
                    {
                        oMyScript.PauseScript();
                        // oButton.Image = Global.Genie.My.Resources.Resources.control_pause
                    }
                }
            }
        }

        private void ScriptButtonDebuglevel_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem oMenuItem = (ToolStripMenuItem)sender;
                if (oMenuItem.OwnerItem is ToolStripMenuItem)
                {
                    int iDebugLevel = 0;
                    if (!Information.IsNothing(oMenuItem.Tag) && oMenuItem.Tag is int)
                    {
                        iDebugLevel = Conversions.ToInteger(oMenuItem.Tag);
                    }

                    oMenuItem = (ToolStripMenuItem)oMenuItem.OwnerItem;
                    if (oMenuItem.OwnerItem is ToolStripSplitButton)
                    {
                        ToolStripSplitButton oButton = (ToolStripSplitButton)oMenuItem.OwnerItem;
                        if (!Information.IsNothing(oButton.Tag))
                        {
                            Script oScript = (Script)oButton.Tag;
                            oScript.DebugLevel = iDebugLevel;
                            string argsText = "[Script debuglevel set to " + iDebugLevel.ToString() + " for script: " + oScript.FileName + "]" + Constants.vbNewLine;
                            var argoColor = Color.White;
                            var argoBgColor = Color.Transparent;
                            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                            string argsTargetWindow = "";
                            AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
                            Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                            AddText(Constants.vbNewLine, oTargetWindow: argoTargetWindow1);
                        }
                    }
                }
            }
        }

        private void ScriptButtonResume_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem oMenuItem = (ToolStripMenuItem)sender;
                if (oMenuItem.OwnerItem is ToolStripSplitButton)
                {
                    ToolStripSplitButton oButton = (ToolStripSplitButton)oMenuItem.OwnerItem;
                    if (!Information.IsNothing(oButton.Tag))
                    {
                        ((Script)oButton.Tag).ResumeScript();
                    }
                }
            }
        }

        private void ScriptButtonPause_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem oMenuItem = (ToolStripMenuItem)sender;
                if (oMenuItem.OwnerItem is ToolStripSplitButton)
                {
                    ToolStripSplitButton oButton = (ToolStripSplitButton)oMenuItem.OwnerItem;
                    if (!Information.IsNothing(oButton.Tag))
                    {
                        ((Script)oButton.Tag).PauseScript();
                    }
                }
            }
        }

        private void ScriptButtonAbort_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem oMenuItem = (ToolStripMenuItem)sender;
                if (oMenuItem.OwnerItem is ToolStripSplitButton)
                {
                    ToolStripSplitButton oButton = (ToolStripSplitButton)oMenuItem.OwnerItem;
                    if (!Information.IsNothing(oButton.Tag))
                    {
                        ((Script)oButton.Tag).AbortScript();
                    }
                }
            }
        }

        private void ScriptButtonEdit_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem oMenuItem = (ToolStripMenuItem)sender;
                if (oMenuItem.OwnerItem is ToolStripSplitButton)
                {
                    ToolStripSplitButton oButton = (ToolStripSplitButton)oMenuItem.OwnerItem;
                    if (!Information.IsNothing(oButton.Tag))
                    {
                        string sTemp = ((Script)oButton.Tag).FileName;
                        if (sTemp.ToLower().EndsWith(".cmd") == false)
                        {
                            sTemp += ".cmd";
                        }

                        if (sTemp.IndexOf(@"\") == -1)
                        {
                            sTemp = LocalDirectory.Path + @"\Scripts\" + sTemp;
                        }

                        Interaction.Shell("\"" + m_oGlobals.Config.sEditor + "\" \"" + sTemp, AppWinStyle.NormalFocus, false);
                    }
                }
            }
        }

        private void ScriptButtonTrace_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem oMenuItem = (ToolStripMenuItem)sender;
                if (oMenuItem.OwnerItem is ToolStripSplitButton)
                {
                    ToolStripSplitButton oButton = (ToolStripSplitButton)oMenuItem.OwnerItem;
                    if (!Information.IsNothing(oButton.Tag))
                    {
                        Script oMyScript = (Script)oButton.Tag;
                        string argsText = Constants.vbNewLine + "Script trace for " + oMyScript.FileName + ":" + Constants.vbNewLine;
                        Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                        AddText(argsText, oTargetWindow: argoTargetWindow);
                        string argsText1 = oMyScript.TraceList;
                        var argoColor = Color.WhiteSmoke;
                        var argoBgColor = Color.Transparent;
                        Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                        string argsTargetWindow = "";
                        AddText(argsText1, argoColor, argoBgColor, oTargetWindow: argoTargetWindow1, sTargetWindow: argsTargetWindow);
                    }
                }
            }
        }

        private void ScriptButtonVars_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem oMenuItem = (ToolStripMenuItem)sender;
                if (oMenuItem.OwnerItem is ToolStripSplitButton)
                {
                    ToolStripSplitButton oButton = (ToolStripSplitButton)oMenuItem.OwnerItem;
                    if (!Information.IsNothing(oButton.Tag))
                    {
                        Script oMyScript = (Script)oButton.Tag;
                        string argsText = Conversions.ToString(oMyScript.ScriptName + Interaction.IIf(oMyScript.ScriptPaused, "(Paused)", "") + ": " + oMyScript.RunTimeSeconds.ToString("#.#0") + " seconds. " + oMyScript.State + " (" + oMyScript.FileName + ")" + Constants.vbNewLine);
                        Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                        AddText(argsText, oTargetWindow: argoTargetWindow);
                        foreach (string sRow in oMyScript.VariableList.Split(Conversions.ToChar(Constants.vbNewLine)))
                        {
                            AddText(sRow, oTargetWindow: argoTargetWindow);
                        }
                    }
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private void InitWorkerThread()
        {
            // m_oWorker.RunWorkerAsync()
            TimerBgWorker.Start();
        }

        // Private Sub BackgroundWorker_OnWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles m_oWorker.DoWork
        // If System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator <> "." Then
        // System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        // End If

        // While m_bRunWorker = True
        // Try
        // RunQueueCommand(oGlobals.Events.Poll(), "Event")

        // Dim iSent As Integer = 0
        // Dim sCommandQueue As String = oGlobals.CommandQueue.Poll(HasRoundtime())
        // While sCommandQueue.Length > 0
        // RunQueueCommand(sCommandQueue, "Queue")
        // iSent += 1

        // If iSent >= oGlobals.Config.iTypeAhead Then
        // oGlobals.CommandQueue.SetNextTime(0.5)
        // Exit While
        // End If

        // sCommandQueue = oGlobals.CommandQueue.Poll(HasRoundtime())
        // End While

        // TickScripts()

        // If oGlobals.Config.bShowSpellTimer = True AndAlso oGlobals.oSpellTimeStart <> System.DateTime.MinValue Then
        // SafeSetStatusBarLabels()
        // End If

        // SafeAddScripts()
        // RemoveExitedScripts()

        // 'SafeRemoveExitedScripts()
        // 'SafeAddScripts()

        // System.Threading.Thread.Sleep(10)
        // #If Not Debug Then
        // Catch ex As Exception
        // HandleGenieException("BackgroundWorker Exception: " & ex.ToString)
        // #Else
        // Finally
        // #End If
        // End Try
        // End While
        // End Sub

        public delegate void AddScriptsDelegate();

        private void SafeAddScripts()
        {
            try
            {
                if (IsDisposed)
                {
                    return;
                }

                if (InvokeRequired == true)
                {
                    Invoke(new AddScriptsDelegate(AddScripts));
                }
                else
                {
                    AddScripts();
                }
            }
            catch (Exception ex)
            {
            } // Don't care
        }
        // Private Sub AddScripts()
        // Try
        // Monitor.Enter(m_oNewScripts)

        // For Each oItem As Object In m_oNewScripts
        // If TypeOf oItem Is Script Then
        // Dim oScriptAs Script = DirectCast(oItem, Script)
        // If oScriptRef.ScriptDone = False Then
        // AddScriptToToolStrip(oScriptRef)
        // End If
        // End If
        // Next

        // m_oNewScripts.Clear()
        // Catch ex As Exception
        // Throw (ex)
        // Finally
        // Monitor.Exit(m_oNewScripts)
        // End Try
        // End Sub

        private void AddScripts()
        {
            if (m_oScriptListNew.Count > 0)
            {
                if (m_oScriptList.AcquireWriterLock(m_iDefaultTimeout))
                {
                    try
                    {
                        if (m_oScriptListNew.AcquireWriterLock(m_iDefaultTimeout))
                        {
                            try
                            {
                                foreach (Script oScript in m_oScriptListNew)
                                {
                                    if (!Information.IsNothing(oScript)) // Add it before running so put #parse and such works.
                                    {
                                        m_oScriptList.Add(oScript);
                                        if (!oScript.ScriptDone) // Don't add to bar if script is done.
                                        {
                                            AddScriptToToolStrip(oScript);
                                        }

                                        m_bScriptListUpdated = true;
                                    }
                                }

                                m_oScriptListNew.Clear();
                            }
                            finally
                            {
                                m_oScriptListNew.ReleaseWriterLock();
                            }
                        }
                        else
                        {
                            HandleGenieException("AddScripts", "Unable to aquire writer lock.");
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseWriterLock();
                    }
                }
                else
                {
                    HandleGenieException("AddScripts", "Unable to aquire writer lock.");
                }
            }
        }

        private void RunQueueCommand(string sAction, string sOrigin)
        {
            if (sAction.Length > 0)
            {
                m_oCommand.ParseCommand(sAction, true, false, sOrigin);
                string argsText = "";
                var argoColor = Color.Transparent;
                var argoBgColor = Color.Transparent;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                string argsTargetWindow = "";
                AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow); // For some stupid reason we need this. Probably because EndUpdate is fired before we are ready in the other thread.
                EndUpdate();
            }
        }

        private void ShowForm(Form oForm)
        {
            if (oForm is null)
            {
                throw new ArgumentNullException("form", "Unable to show null form.");
            }
            else
            {
                if (!oForm.Visible)
                {
                    oForm.Show();
                }

                oForm.BringToFront();
            }
        }

        public void UpdateWindowMenuList()
        {
            WindowToolStripMenuItem.DropDownItems.Clear();
            var ti = new ToolStripMenuItem();
            ti.Name = "ToolStripMenuItemWindowMain";
            ti.Text = "&1. " + m_oOutputMain.Text;
            ti.Tag = m_oOutputMain;
            ti.Click += WindowMenuItem_Click;
            WindowToolStripMenuItem.DropDownItems.Add(ti);
            int I = 2;
            foreach (FormSkin fo in m_oFormList)
            {
                ti = new ToolStripMenuItem();
                ti.Name = "ToolStripMenuItemWindow" + fo.Text;
                ti.Text = "&" + I.ToString() + ". " + fo.Text;
                ti.Tag = fo;
                ti.Click += WindowMenuItem_Click;
                WindowToolStripMenuItem.DropDownItems.Add(ti);
                I += 1;
            }
        }

        private void WindowMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem mi = (ToolStripMenuItem)sender;
                if (!Information.IsNothing(mi.Tag))
                {
                    if (mi.Tag is FormSkin)
                    {
                        ShowForm((FormSkin)mi.Tag);
                    }
                }
            }
        }

        private void ShowOutputForms()
        {
            var myEnumerator = m_oFormList.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                FormSkin oForm = (FormSkin)myEnumerator.Current;
                if (!Information.IsNothing(oForm.Tag))
                {
                    if (Conversions.ToBoolean(oForm.Tag) == true)
                    {
                        ShowForm(oForm);
                    }
                }
            }
        }

        private void HideTagOutputForms()
        {
            var myEnumerator = m_oFormList.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                FormSkin oForm = (FormSkin)myEnumerator.Current;
                oForm.Tag = false;
            }
        }

        private void HideOutputForms()
        {
            var myEnumerator = m_oFormList.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                FormSkin oForm = (FormSkin)myEnumerator.Current;
                if (!Information.IsNothing(oForm.Tag))
                {
                    if (Conversions.ToBoolean(oForm.Tag) == false)
                    {
                        oForm.Visible = false;
                    }
                }
            }
        }

        // Private Sub ShowOutputBoxes()
        // Dim myEnumerator As IEnumerator = m_oFormList.GetEnumerator
        // While myEnumerator.MoveNext
        // Dim oForm As FormSkin = CType(myEnumerator.Current, FormSkin)
        // If Not IsNothing(oForm.Tag) Then
        // If oForm.Visible = True Then
        // oForm.ShowOutput()
        // End If
        // End If
        // End While
        // End Sub

        public delegate FormSkin CreateOutputFormDelegate(string sID, string sName, string sIfClosed, int iWidth, int iHeight, int iTop, int iLeft, bool bIsVisible, Font oFont, string sColorName, bool UpdateFormList);

        public FormSkin SafeCreateOutputForm(string sID, string sName, string sIfClosed, int iWidth, int iHeight, int iTop, int iLeft, bool bIsVisible, Font oFont = null, string sColorName = "", bool UpdateFormList = false)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { sID, sName, sIfClosed, iWidth, iHeight, iTop, iLeft, bIsVisible, oFont, sColorName, UpdateFormList };
                return (FormSkin)Invoke(new CreateOutputFormDelegate(CreateOutputForm), parameters);
            }
            else
            {
                return CreateOutputForm(sID, sName, sIfClosed, iWidth, iHeight, iTop, iLeft, bIsVisible, oFont, sColorName, UpdateFormList);
            }
        }

        public FormSkin CreateOutputForm(string sID, string sName, string sIfClosed, int iWidth, int iHeight, int iTop, int iLeft, bool bIsVisible, Font oFont = null, string sColorName = "", bool UpdateFormList = false)
        {
            FormSkin oForm = null;
            var oEnumerator = m_oFormList.GetEnumerator();
            while (oEnumerator.MoveNext())
            {
                if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sID ?? ""))
                {
                    oForm = (FormSkin)oEnumerator.Current;
                }
            }

            if (Information.IsNothing(oForm))
            {
                var argoGlobal = m_oGlobals;
                oForm = new FormSkin(sID, sName, ref _m_oGlobals);
                oForm.EventLinkClicked += FormSkin_LinkClicked;
                oForm.MdiParent = this;
                m_oFormList.Add(oForm);
            }

            oForm.Name = "FormSkin" + sID;
            oForm.Text = sName;
            oForm.Title = sName;
            oForm.ID = sID;
            oForm.IfClosed = sIfClosed;
            if (!Information.IsNothing(oFont))
            {
                oForm.TextFont = oFont;
            }

            oForm.RichTextBoxOutput.MonoFont = m_oGlobals.Config.MonoFont;
            oForm.Width = iWidth;
            oForm.Height = iHeight;
            oForm.Top = iTop;
            oForm.Left = iLeft;
            oForm.Tag = bIsVisible;
            if (sColorName.Length > 0)
            {
                if (sColorName.Contains(",") == true && sColorName.EndsWith(",") == false)
                {
                    string sColor = sColorName.Substring(0, sColorName.IndexOf(",")).Trim();
                    string sBgColor = sColorName.Substring(sColorName.IndexOf(",") + 1).Trim();
                    oForm.RichTextBoxOutput.ForeColor = Genie.ColorCode.StringToColor(sColor);
                    oForm.RichTextBoxOutput.BackColor = Genie.ColorCode.StringToColor(sBgColor);
                }
                else
                {
                    oForm.RichTextBoxOutput.ForeColor = Genie.ColorCode.StringToColor(sColorName);
                }
            }

            switch (sID)
            {
                case "inv":
                case "inventory":
                    {
                        m_oOutputInv = oForm;
                        oForm.UserForm = false;
                        break;
                    }

                case "familiar":
                    {
                        m_oOutputFamiliar = oForm;
                        oForm.UserForm = false;
                        break;
                    }

                case "thoughts":
                    {
                        m_oOutputThoughts = oForm;
                        oForm.UserForm = false;
                        break;
                    }

                case "logons":
                case "arrivals":
                    {
                        m_oOutputLogons = oForm;
                        oForm.UserForm = false;
                        break;
                    }

                case "deaths":
                case "death":
                    {
                        m_oOutputDeath = oForm;
                        oForm.UserForm = false;
                        break;
                    }

                case "room":
                    {
                        m_oOutputRoom = oForm;
                        oForm.UserForm = false;
                        break;
                    }

                case "log":
                    {
                        m_oOutputLog = oForm;
                        oForm.UserForm = false;
                        break;
                    }
            }

            if (UpdateFormList)
                UpdateWindowMenuList();
            return oForm;
        }

        private bool OutputFormNameExists(string sID)
        {
            var oEnumerator = m_oFormList.GetEnumerator();
            while (oEnumerator.MoveNext())
            {
                if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sID ?? ""))
                {
                    return true;
                }
            }

            return false;
        }

        // Remove Disposed Objects from FormList
        public void RemoveDisposedForms()
        {
            FormSkin oForm;
            var oEnumerator = m_oFormList.GetEnumerator();
            while (oEnumerator.MoveNext())
            {
                oForm = (FormSkin)oEnumerator.Current;
                if (oForm.IsDisposed == true)
                {
                    m_oFormList.Remove(oForm);
                    RemoveDisposedForms();
                    return;
                }
            }
        }

        private void TextBoxInput_SendText(string sText)
        {
            try
            {
                m_CommandSent = true;
                m_oCommand.ParseCommand(sText, true, true);
                string argsText = "";
                var argoColor = Color.Transparent;
                var argoBgColor = Color.Transparent;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                string argsTargetWindow = "";
                AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow); // For some stupid reason we need this. Probably because EndUpdate is fired before we are ready in the other thread.
                EndUpdate();
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("SendText", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void ClassCommand_EchoText(string sText, string sWindow)
        {
            try
            {
                FormSkin oFormSkin = null;
                if (sWindow.Length > 0)
                {
                    if ((sWindow.ToLower() ?? "") != "game" & (sWindow.ToLower() ?? "") != "main")
                    {
                        var oEnumerator = m_oFormList.GetEnumerator();
                        while (oEnumerator.MoveNext())
                        {
                            if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sWindow.ToLower() ?? ""))
                            {
                                oFormSkin = (FormSkin)oEnumerator.Current;
                                break;
                            }
                        }
                    }
                }

                bool bMono = false;
                if (sText.ToLower().StartsWith("mono "))
                {
                    sText = sText.Substring(5);
                    bMono = true;
                }

                if (!Information.IsNothing(oFormSkin))
                {
                    var argoColor = Color.WhiteSmoke;
                    var argoBgColor = Color.Transparent;
                    AddText(sText, argoColor, argoBgColor, oFormSkin, true, bMono);
                }
                else if (sWindow.Length == 0)
                {
                    var argoColor1 = Color.WhiteSmoke;
                    var argoBgColor1 = Color.Transparent;
                    string argsTargetWindow = "";
                    AddText(sText, argoColor1, argoBgColor1, Genie.Game.WindowTarget.Main, argsTargetWindow, true, bMono);
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("EchoText", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void ClassCommand_LinkText(string sText, string sLink, string sWindow)
        {
            try
            {
                FormSkin oFormSkin = null;
                if (sWindow.Length > 0)
                {
                    if ((sWindow.ToLower() ?? "") != "game" & (sWindow.ToLower() ?? "") != "main")
                    {
                        var oEnumerator = m_oFormList.GetEnumerator();
                        while (oEnumerator.MoveNext())
                        {
                            if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sWindow.ToLower() ?? ""))
                            {
                                oFormSkin = (FormSkin)oEnumerator.Current;
                                break;
                            }
                        }
                    }
                }

                if (Information.IsNothing(oFormSkin))
                    oFormSkin = m_oOutputMain;
                SafeLinkText(sText, sLink, oFormSkin);
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("EchoText", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        public delegate void LinkTextDelegate(string sText, string sLink, FormSkin oTargetWindow);

        private void SafeLinkText(string sText, string sLink, FormSkin oTargetWindow)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { sText, sLink, oTargetWindow };
                Invoke(new LinkTextDelegate(LinkText), parameters);
            }
            else
            {
                LinkText(sText, sLink, oTargetWindow);
            }
        }

        private void LinkText(string sText, string sLink, FormSkin oTargetWindow)
        {
            oTargetWindow.RichTextBoxOutput.InsertLink(sText, sLink);
        }

        private void ClassCommand_EchoColorText(string sText, Color oColor, Color oBgColor, string sWindow)
        {
            try
            {
                FormSkin oFormSkin = null;
                if (sWindow.Length > 0)
                {
                    if ((sWindow.ToLower() ?? "") != "game" & (sWindow.ToLower() ?? "") != "main")
                    {
                        var oEnumerator = m_oFormList.GetEnumerator();
                        while (oEnumerator.MoveNext())
                        {
                            if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sWindow.ToLower() ?? ""))
                            {
                                oFormSkin = (FormSkin)oEnumerator.Current;
                                break;
                            }
                        }
                    }
                }

                bool bMono = false;
                if (sText.ToLower().StartsWith("mono "))
                {
                    sText = sText.Substring(5);
                    bMono = true;
                }

                if (!Information.IsNothing(oFormSkin))
                {
                    AddText(sText, oColor, oBgColor, oFormSkin, true, bMono);
                }
                else if (sWindow.Length == 0)
                {
                    string argsTargetWindow = "";
                    AddText(sText, oColor, oBgColor, Genie.Game.WindowTarget.Main, argsTargetWindow, true, bMono);
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("EchoColorText", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void SendTextInputBox(string sText)
        {
            if (sText.Contains(@"\x") | sText.Contains("@"))
            {
                SafeParseInputBox(sText);
            }
        }

        private void ClassCommand_SendRaw(string sText)
        {
            m_oGame.SendRaw(sText);
        }

        private void ClassCommand_SendText(string sText, bool bUserInput, string sOrigin)
        {
            try
            {
                sText = sText.Replace(@"\@", "¤");
                if (sText.Contains(@"\x") | sText.Contains("@"))
                {
                    SendTextInputBox(sText);
                }
                else
                {
                    sText = sText.Replace("¤", "@");
                    sText = SafeParsePluginInput(sText);
                    if (sText.Length > 0)
                    {
                        m_CommandSent = true;
                        m_oGame.SendText(sText, bUserInput, sOrigin);
                        if (m_oGlobals.Config.bTriggerOnInput == true)
                        {
                            ParseTriggers(sText);
                        }
                    }
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("SendText", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        // BufferWait is since script always wait for end of buffer before setting off an action... We don't want this with #parse
        private void ParseTriggers(string sText, bool bBufferWait = true)
        {
            if (m_bTriggersEnabled == true)
            {
                if (sText.Trim().Length > 0)
                {
                    if (m_oGlobals.TriggerList.AcquireReaderLock(m_iDefaultTimeout))
                    {
                        try
                        {
                            foreach (Genie.Globals.Triggers.Trigger oTrigger in m_oGlobals.TriggerList.Values)
                            {
                                if (oTrigger.IsActive)
                                {
                                    if (oTrigger.bIsEvalTrigger == false)
                                    {
                                        if (!Information.IsNothing(oTrigger.oRegexTrigger))
                                        {
                                            m_oRegMatch = oTrigger.oRegexTrigger.Match(sText);
                                            if (m_oRegMatch.Success == true)
                                            {
                                                var RegExpArg = new ArrayList();
                                                if (m_oRegMatch.Groups.Count > 0)
                                                {
                                                    int J;
                                                    var loopTo = m_oRegMatch.Groups.Count - 1;
                                                    for (J = 1; J <= loopTo; J++)
                                                        RegExpArg.Add(m_oRegMatch.Groups[J].Value);
                                                }

                                                TriggerAction(oTrigger.sAction, RegExpArg);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        /* TODO ERROR: Skipped IfDirectiveTrivia */
                        catch (Exception ex)
                        {
                            HandleGenieException("TriggerAction", ex.Message, ex.ToString());
                        }
                        /* TODO ERROR: Skipped EndIfDirectiveTrivia */
                        finally
                        {
                            m_oGlobals.TriggerList.ReleaseReaderLock();
                        }
                    }
                    else
                    {
                        ShowDialogException("TriggerList", "Unable to acquire reader lock.");
                    }

                    // Scripts
                    if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                    {
                        try
                        {
                            foreach (Script oScript in m_oScriptList)
                                oScript.TriggerParse(sText, bBufferWait);
                        }
                        /* TODO ERROR: Skipped IfDirectiveTrivia */
                        catch (Exception ex)
                        {
                            HandleGenieException("TriggerParse", ex.Message, ex.ToString());
                        }
                        /* TODO ERROR: Skipped EndIfDirectiveTrivia */
                        finally
                        {
                            m_oScriptList.ReleaseReaderLock();
                        }
                    }
                    else
                    {
                        ShowDialogException("TriggerParse", "Unable to acquire reader lock.");
                    }
                }
            }
        }

        private void SetScriptListVariable()
        {
            if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
            {
                Debug.Print("ScriptList Lock aquired by SetScriptListVariable()");
                try
                {
                    string sScriptList = string.Empty;
                    foreach (Script oScript in m_oScriptList)
                    {
                        if (!Information.IsNothing(oScript))
                        {
                            if (!oScript.ScriptDone)
                            {
                                if (sScriptList.Length > 0)
                                    sScriptList += "|";
                                sScriptList += oScript.FileName;
                                Debug.Print(oScript.FileName);
                            }
                        }
                    }

                    if (sScriptList.Length == 0)
                        sScriptList = "none";
                    m_oGlobals.VariableList["scriptlist"] = sScriptList;
                    TriggerVariableChanged("scriptlist");
                    m_bScriptListUpdated = false;
                }
                finally
                {
                    m_oScriptList.ReleaseReaderLock();
                    Debug.Print("ScriptList Lock released by SetScriptListVariable()");
                }
            }
        }

        private void Command_EventListScripts(string sFilter)
        {
            try
            {
                if ((sFilter.ToLower() ?? "") == "all")
                {
                    sFilter = string.Empty;
                }

                string argsText = Constants.vbNewLine + "Active scripts: " + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
                int I = 0;
                // Scripts
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    Debug.Print("ScriptList Lock aquired by ListScripts()");
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                        {
                            if (oScript.ScriptName.Length > 0)
                            {
                                if (sFilter.Length == 0 | (oScript.ScriptName ?? "") == (sFilter ?? ""))
                                {
                                    string argsText1 = Conversions.ToString(Conversions.ToString(oScript.ScriptName + Interaction.IIf(oScript.ScriptPaused, "(Paused)", "")) + Interaction.IIf(oScript.DebugLevel > 0, " [Debuglevel: " + oScript.DebugLevel.ToString() + "]", "") + ": " + oScript.RunTimeSeconds.ToString("#.#0") + " seconds. " + oScript.State + " (" + oScript.FileName + ")" + Constants.vbNewLine);
                                    Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                                    AddText(argsText1, oTargetWindow: argoTargetWindow1);
                                    I += 1;
                                }
                            }
                        }

                        if (I == 0)
                        {
                            string argsText2 = "None." + Constants.vbNewLine;
                            Genie.Game.WindowTarget argoTargetWindow2 = Genie.Game.WindowTarget.Main;
                            AddText(argsText2, oTargetWindow: argoTargetWindow2);
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                        Debug.Print("ScriptList Lock released by ListScripts()");
                    }
                }
                else
                {
                    ShowDialogException("ListScripts", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ListScripts", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void TriggerAction(string sAction, ArrayList oArgs)
        {
            if (m_bTriggersEnabled == true)
            {
                if (sAction.Contains("$") == true)
                {
                    for (int i = 0, loopTo = m_oGlobals.Config.iArgumentCount - 1; i <= loopTo; i++)
                    {
                        if (i > oArgs.Count - 1)
                        {
                            sAction = sAction.Replace("$" + (i + 1).ToString(), "");
                        }
                        else
                        {
                            sAction = sAction.Replace("$" + (i + 1).ToString(), oArgs[i].ToString().Replace("\"", ""));
                        }
                    }

                    if (oArgs.Count > 0)
                    {
                        sAction = sAction.Replace("$0", oArgs[0].ToString().Replace("\"", ""));
                    }
                    else
                    {
                        sAction = sAction.Replace("$0", string.Empty);
                    }
                }

                // sAction = oGlobals.ParseGlobalVars(sAction)

                try
                {
                    m_oCommand.ParseCommand(sAction, true, false, "Trigger");
                }
                catch (Exception ex)
                {
                    string argsText = "Trigger action failed: " + sAction;
                    PrintError(argsText);
                }
            }
        }

        private void ClassCommand_ParseText(string sText)
        {
            try
            {
                /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                if (sText.Trim().Length > 0)
                {
                    ParseTriggers(sText, false);
                    SafeParsePluginText(sText, "main");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ParseText", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void ClassCommand_RunScript(string sText)
        {
            try
            {
                var al = new ArrayList();
                al = Utility.ParseArgs(sText, true);
                string ScriptName = Conversions.ToString(al[0].ToString().ToLower().Trim().Substring(1));
                if (ScriptName.EndsWith(".cmd") == false)
                {
                    ScriptName += ".cmd";
                }

                Script oScript = null;
                if (m_oScriptListNew.AcquireWriterLock(m_iDefaultTimeout))
                {
                    try
                    {
                        oScript = LoadScript(ScriptName, al); // Load
                        if (!Information.IsNothing(oScript)) // Add it before running so put #parse and such works.
                        {
                            m_oScriptListNew.Add(oScript);
                        }
                    }
                    finally
                    {
                        m_oScriptListNew.ReleaseWriterLock();
                    }
                }
                else
                {
                    HandleGenieException("RunScript", "Unable to aquire writer lock.");
                }

                if (!Information.IsNothing(oScript))
                {
                    oScript.RunScript(); // Run it
                }
            }

            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("RunScript", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        public void TriggerVariableChanged(string sVariableName) // When variables change
        {
            switch (sVariableName)
            {
                case "$health":
                    {
                        int argiValue = Conversions.ToInteger(m_oGlobals.VariableList["health"]);
                        var argoBar = ComponentBarsHealth;
                        SetBarValue(argiValue, argoBar);
                        break;
                    }

                case "$mana":
                    {
                        int argiValue1 = Conversions.ToInteger(m_oGlobals.VariableList["mana"]);
                        var argoBar1 = ComponentBarsMana;
                        SetBarValue(argiValue1, argoBar1);
                        break;
                    }

                case "$stamina":
                    {
                        int argiValue2 = Conversions.ToInteger(m_oGlobals.VariableList["stamina"]);
                        var argoBar2 = ComponentBarsFatigue;
                        SetBarValue(argiValue2, argoBar2);
                        break;
                    }

                case "$spirit":
                    {
                        int argiValue3 = Conversions.ToInteger(m_oGlobals.VariableList["spirit"]);
                        var argoBar3 = ComponentBarsSpirit;
                        SetBarValue(argiValue3, argoBar3);
                        break;
                    }

                case "$concentration":
                    {
                        int argiValue4 = Conversions.ToInteger(m_oGlobals.VariableList["concentration"]);
                        var argoBar4 = ComponentBarsConc;
                        SetBarValue(argiValue4, argoBar4);
                        break;
                    }

                case "compass":
                case "$north":
                case "$northeast":
                case "$east":
                case "$southeast":
                case "$south":
                case "$southwest":
                case "$west":
                case "$northwest":
                case "$up":
                case "$down":
                case "$out":
                    {
                        IconBar.PictureBoxCompass.Invalidate();
                        return; // Block direction triggers (They clear before changing.)
                    }

                case "$dead":
                case "$standing":
                case "$kneeling":
                case "$sitting":
                case "$prone":
                    {
                        IconBar.UpdateStatusBox();
                        break;
                    }

                case "$stunned":
                    {
                        IconBar.UpdateStunned();
                        break;
                    }

                case "$bleeding":
                    {
                        IconBar.UpdateBleeding();
                        break;
                    }

                case "$invisible":
                    {
                        IconBar.UpdateInvisible();
                        break;
                    }

                case "$hidden":
                    {
                        IconBar.UpdateHidden();
                        break;
                    }

                case "$joined":
                    {
                        IconBar.UpdateJoined();
                        break;
                    }

                case "$webbed":
                    {
                        IconBar.UpdateWebbed();
                        break;
                    }

                case "$connected":
                    {
                        string argsValue = Conversions.ToString(m_oGlobals.VariableList["connected"]);
                        bool bConnected = Utility.StringToBoolean(argsValue);
                        ComponentBarsHealth.IsConnected = bConnected;
                        ComponentBarsMana.IsConnected = bConnected;
                        ComponentBarsFatigue.IsConnected = bConnected;
                        ComponentBarsSpirit.IsConnected = bConnected;
                        ComponentBarsConc.IsConnected = bConnected;
                        IconBar.IsConnected = bConnected;
                        oRTControl.IsConnected = bConnected;
                        SafeUpdateMainWindowTitle();
                        if (bConnected == true)
                        {
                            m_CommandSent = false;
                            m_oGlobals.VariableList["charactername"] = m_oGame.AccountCharacter;
                            m_oGlobals.VariableList["game"] = m_oGame.AccountGame;
                            m_oGame.ResetIndicators();
                            IconBar.UpdateStatusBox();
                            IconBar.UpdateStunned();
                            IconBar.UpdateBleeding();
                            IconBar.UpdateInvisible();
                            IconBar.UpdateHidden();
                            IconBar.UpdateJoined();
                            IconBar.UpdateWebbed();
                        }

                        break;
                    }

                case "$prompt": // Safety
                    {
                        IconBar.UpdateBleeding();
                        break;
                    }

                case "$charactername":
                    {
                        SafeUpdateMainWindowTitle();
                        m_oAutoMapper.CharacterName = m_oGlobals.VariableList["charactername"].ToString();
                        m_oGame.AccountCharacter = m_oGlobals.VariableList["charactername"].ToString();
                        if (m_oGlobals.VariableList["charactername"].ToString().Length > 0)
                        {
                            m_sCurrentProfileName = m_oGame.AccountCharacter + m_oGame.AccountGame + ".xml";
                        }

                        break;
                    }
                /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                case "$gamename":
                    {
                        // SafeLoadProfile(oGlobals.VariableList("charactername").ToString & oGlobals.VariableList("gamename").ToString & ".xml", False)
                        SafeUpdateMainWindowTitle();
                        break;
                    }
            }

            if (m_bTriggersEnabled == true)
            {
                if (m_oGlobals.TriggerList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    try
                    {
                        foreach (Genie.Globals.Triggers.Trigger oTrigger in m_oGlobals.TriggerList.Values)
                        {
                            if (oTrigger.IsActive)
                            {
                                if (oTrigger.bIsEvalTrigger == true)
                                {
                                    if (oTrigger.sTrigger.Contains(sVariableName))
                                    {
                                        string s = "1";
                                        // If the command isn't an eval. Simply trigger it without checking.
                                        if ((oTrigger.sTrigger ?? "") != (sVariableName ?? ""))
                                        {
                                            string argsText = m_oGlobals.ParseGlobalVars(oTrigger.sTrigger);
                                            s = m_oCommand.Eval(argsText);
                                        }

                                        if (s.Length > 0 & (s ?? "") != "0")
                                        {
                                            TriggerAction(oTrigger.sAction, new ArrayList());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oGlobals.TriggerList.ReleaseReaderLock();
                    }
                }
                else
                {
                    ShowDialogException("TriggerList", "Unable to acquire reader lock.");
                }

                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                            oScript.TriggerVariableChanged(sVariableName);
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                    }
                }
                else
                {
                    ShowDialogException("TriggerVariableChanged", "Unable to acquire reader lock.");
                }
            }
        }

        public delegate void UpdateMainWindowTitleDelegate();

        private void SafeUpdateMainWindowTitle()
        {
            if (InvokeRequired == true)
            {
                Invoke(new UpdateMainWindowTitleDelegate(UpdateMainWindowTitle));
            }
            else
            {
                UpdateMainWindowTitle();
            }
        }

        private void UpdateMainWindowTitle()
        {
            string strTitle = string.Empty;
            if (!Information.IsNothing(m_oGlobals.VariableList["gamename"]) && m_oGlobals.VariableList["gamename"].ToString().Length > 0)
            {
                strTitle += m_oGlobals.VariableList["gamename"].ToString() + ": ";
            }

            if (!Information.IsNothing(m_oGlobals.VariableList["charactername"]) && m_oGlobals.VariableList["charactername"].ToString().Length > 0)
            {
                strTitle += m_oGlobals.VariableList["charactername"].ToString() + " ";
            }

            if (m_oGame.IsConnected)
            {
                strTitle += "[Connected]" + " - ";
            }
            else
            {
                strTitle += "[Not connected]" + " - ";
            }

            strTitle += "Genie " + My.MyProject.Application.Info.Version.ToString();
            Text = strTitle;
        }

        private void PluginHost_EventVariableChanged(string sVariable)
        {
            try
            {
                TriggerVariableChanged(sVariable);
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("VariableChanged", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void ClassCommand_EventVariableChanged(string sVariable)
        {
            try
            {
                TriggerVariableChanged(sVariable);
                SafeParsePluginVariable(sVariable);
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("VariableChanged", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void PrintError(string sText)
        {
            string argsText = sText + Constants.vbNewLine;
            var argoColor = Color.Red;
            var argoBgColor = Color.Transparent;
            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
            string argsTargetWindow = "";
            AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
        }

        private void AppendText(string Text)
        {
            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
            AddText(Text, oTargetWindow: argoTargetWindow);
        }

        private void AddText(string sText, [Optional, DefaultParameterValue(Genie.Game.WindowTarget.Main)] Genie.Game.WindowTarget oTargetWindow, bool bNoCache = true, bool bMono = false, bool bPrompt = false, bool bInput = false)
        {
            var argoColor = Color.WhiteSmoke;
            var argoBgColor = Color.Transparent;
            string argsTargetWindow = Conversions.ToString(bNoCache);
            AddText(sText, argoColor, argoBgColor, oTargetWindow, argsTargetWindow, bMono, bPrompt, bInput);
        }

        private void AddText(string sText, Color oColor, Color oBgColor, FormSkin oTargetWindow, bool bNoCache = true, bool bMono = false, bool bPrompt = false, bool bInput = false)
        {
            if (IsDisposed)
            {
                return;
            }

            if (Information.IsNothing(oTargetWindow))
            {
                oTargetWindow = m_oOutputMain;
            }

            if (oTargetWindow.Equals(m_oOutputMain))
            {
                if (bPrompt == true)
                {
                    if (m_oGame.LastRowWasPrompt)
                    {
                        return;
                    }

                    m_oGame.LastRowWasPrompt = true;
                }
                else if (sText.Trim().Length > 0)
                {
                    if (m_oGame.LastRowWasPrompt == true)
                    {
                        if (!bInput)
                        {
                            if (sText.StartsWith(Constants.vbNewLine) == false)
                            {
                                sText = Constants.vbNewLine + sText;
                            }
                        }

                        m_oGame.LastRowWasPrompt = false;
                    }
                }
            }

            if (InvokeRequired == true)
            {
                var parameters = new object[] { sText, oColor, oBgColor, oTargetWindow, bNoCache, bMono };
                Invoke(new AddTextDelegate(InvokeAddText), parameters);
            }
            else
            {
                InvokeAddText(sText, oColor, oBgColor, oTargetWindow, bNoCache, bMono);
            }
        }

        private void AddText(string sText, Color oColor, Color oBgColor, [Optional, DefaultParameterValue(Genie.Game.WindowTarget.Main)] Genie.Game.WindowTarget oTargetWindow, [Optional, DefaultParameterValue("")] string sTargetWindow, bool bNoCache = true, bool bMono = false, bool bPrompt = false, bool bInput = false)
        {
            if (IsDisposed)
            {
                return;
            }

            FormSkin oFormTarget = null;
            if (!Information.IsNothing(m_oOutputMain))
            {
                switch (oTargetWindow)
                {
                    case Genie.Game.WindowTarget.Death:
                        {
                            oFormTarget = m_oOutputDeath;
                            break;
                        }

                    case Genie.Game.WindowTarget.Familiar:
                        {
                            oFormTarget = m_oOutputFamiliar;
                            break;
                        }

                    case Genie.Game.WindowTarget.Inv:
                        {
                            if (!Information.IsNothing(m_oOutputInv) && m_oOutputInv.Visible == true)
                                oFormTarget = m_oOutputInv;
                            break;
                        }

                    case Genie.Game.WindowTarget.Log:
                        {
                            oFormTarget = m_oOutputLog;
                            break;
                        }

                    case Genie.Game.WindowTarget.Logons:
                        {
                            oFormTarget = m_oOutputLogons;
                            break;
                        }

                    case Genie.Game.WindowTarget.Room:
                        {
                            if (!Information.IsNothing(m_oOutputRoom) && m_oOutputRoom.Visible == true)
                                oFormTarget = m_oOutputRoom;
                            break;
                        }

                    case Genie.Game.WindowTarget.Thoughts:
                        {
                            oFormTarget = m_oOutputThoughts;
                            break;
                        }

                    case Genie.Game.WindowTarget.Other:
                        {
                            oFormTarget = FindSkinFormByName(sTargetWindow);
                            break;
                        }

                    default:
                        {
                            oFormTarget = m_oOutputMain;
                            break;
                        }
                }

                if (Information.IsNothing(oFormTarget))
                    return;
                if (oFormTarget.Visible == false)
                {
                    oFormTarget = FindIfClosed(oFormTarget.IfClosed);
                }

                if (Information.IsNothing(oFormTarget))
                    return;
                AddText(sText, oColor, oBgColor, oFormTarget, bNoCache, bMono, bPrompt, bInput);
            }
        }

        private FormSkin FindIfClosed(string IfClosed, int Depth = 0)
        {
            Depth += 1;
            if (Depth > 10)
                return null;

            // Nothing means default = main window
            // "" means ignore output
            if (Information.IsNothing(IfClosed))
                return m_oOutputMain;
            if (string.IsNullOrEmpty(IfClosed))
                return null;
            var oFormSkin = FindSkinFormByID(IfClosed);
            if (!Information.IsNothing(oFormSkin))
            {
                if (oFormSkin.Visible == false)
                {
                    return FindIfClosed(oFormSkin.IfClosed, Depth);
                }
                else
                {
                    return oFormSkin;
                }
            }

            return null;
        }

        public delegate void AddTextDelegate(string sText, Color oColor, Color oBgColor, FormSkin oTargetwindow, bool bNoCache, bool bMono);

        private void InvokeAddText(string sText, Color oColor, Color oBgColor, FormSkin oTargetWindow, bool bNoCache = true, bool bMono = false)
        {
            if (!Information.IsNothing(oTargetWindow))
            {
                oTargetWindow.RichTextBoxOutput.AddText(sText, oColor, oBgColor, bNoCache, bMono);
            }
        }

        public delegate void ClearWindowDelegate(FormSkin oTargetWindow);

        private void SafeClearWindow(FormSkin oTargetWindow)
        {
            if (InvokeRequired == true)
            {
                var parameters = new[] { oTargetWindow };
                Invoke(new ClearWindowDelegate(ClearWindow), parameters);
            }
            else
            {
                ClearWindow(oTargetWindow);
            }
        }

        private void ClearWindow(FormSkin oTargetWindow)
        {
            oTargetWindow.ClearWindow();
        }

        private void Command_EventChangeWindowTitle(string sWindow, string sComment)
        {
            SafeChangeWindowTitle(sWindow, sComment);
        }

        public delegate void ChangeWindowTitleDelegate(string sWindow, string sComment);

        private void SafeChangeWindowTitle(string sWindow, string sComment)
        {
            if (InvokeRequired == true)
            {
                var parameters = new[] { sWindow, sComment };
                Invoke(new ChangeWindowTitleDelegate(ChangeWindowTitle), parameters);
            }
            else
            {
                ChangeWindowTitle(sWindow, sComment);
            }
        }

        private void ChangeWindowTitle(string sWindow, string sComment)
        {
            FormSkin oFormSkin = null;
            if (sWindow.Length > 0)
            {
                if ((sWindow.ToLower() ?? "") == (m_oOutputMain.ID ?? ""))
                {
                    oFormSkin = m_oOutputMain;
                }
                else
                {
                    var oEnumerator = m_oFormList.GetEnumerator();
                    while (oEnumerator.MoveNext())
                    {
                        if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sWindow.ToLower().Trim() ?? ""))
                        {
                            oFormSkin = (FormSkin)oEnumerator.Current;
                            break;
                        }
                    }
                }
            }

            if (!Information.IsNothing(oFormSkin))
            {
                oFormSkin.Comment = sComment;
                oFormSkin.Invalidate();
            }
        }

        private FormSkin FindSkinFormByID(string sID)
        {
            FormSkin oFormSkin = null;
            if (sID.Length > 0)
            {
                if ((sID.ToLower() ?? "") == (m_oOutputMain.ID ?? ""))
                {
                    oFormSkin = m_oOutputMain;
                }
                else
                {
                    var oEnumerator = m_oFormList.GetEnumerator();
                    while (oEnumerator.MoveNext())
                    {
                        if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sID.ToLower().Trim() ?? ""))
                        {
                            oFormSkin = (FormSkin)oEnumerator.Current;
                            break;
                        }
                    }
                }
            }

            return oFormSkin;
        }

        private FormSkin FindSkinFormByIDOrName(string sID, string sWindow)
        {
            FormSkin oFormSkin = null;
            if (sID.Length > 0)
            {
                if ((sID.ToLower() ?? "") == (m_oOutputMain.ID ?? ""))
                {
                    oFormSkin = m_oOutputMain;
                }
                else
                {
                    var oEnumerator = m_oFormList.GetEnumerator();
                    while (oEnumerator.MoveNext())
                    {
                        if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sID.ToLower().Trim() ?? "") | (((FormSkin)oEnumerator.Current).Title.ToLower() ?? "") == (sWindow.ToLower().Trim() ?? ""))
                        {
                            oFormSkin = (FormSkin)oEnumerator.Current;
                            break;
                        }
                    }
                }
            }

            return oFormSkin;
        }

        private FormSkin FindSkinFormByName(string sWindow)
        {
            FormSkin oFormSkin = null;
            if (sWindow.Length > 0)
            {
                if ((sWindow.ToLower() ?? "") == (m_oOutputMain.Name ?? ""))
                {
                    oFormSkin = m_oOutputMain;
                }
                else
                {
                    var oEnumerator = m_oFormList.GetEnumerator();
                    while (oEnumerator.MoveNext())
                    {
                        if ((((FormSkin)oEnumerator.Current).Title.ToLower() ?? "") == (sWindow.ToLower().Trim() ?? ""))
                        {
                            oFormSkin = (FormSkin)oEnumerator.Current;
                            break;
                        }
                    }
                }
            }

            return oFormSkin;
        }

        private void Command_EventClearWindow(string sWindow)
        {
            try
            {
                var oFormSkin = FindSkinFormByIDOrName(sWindow, sWindow);
                if (!Information.IsNothing(oFormSkin)) // Do not clear if window does not exist
                {
                    SafeClearWindow(oFormSkin);
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ClearWindow", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Simutronics_EventPrintText(string sText, Color oColor, Color oBgColor, Genie.Game.WindowTarget oTargetWindow, string sTargetWindow, bool bMono, bool bPrompt, bool bInput)
        {
            try
            {
                AddText(sText, oColor, oBgColor, oTargetWindow, sTargetWindow, false, bMono, bPrompt, bInput); // False = Cache this
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("PrintText", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        // Script Print
        private void Script_EventPrintText(string sText, Color oColor, Color oBgColor)
        {
            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
            string argsTargetWindow = "";
            AddText(sText, oColor, oBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
        }

        private void Simutronics_EventEndUpdate()
        {
            try
            {
                string argsText = "";
                var argoColor = Color.Transparent;
                var argoBgColor = Color.Transparent;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                string argsTargetWindow = "";
                AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow); // For some stupid reason we need this. Probably because EndUpdate is fired before we are ready in the other thread.
                EndUpdate();
                m_oGame.SetBufferEnd();
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                            oScript.SetBufferEnd();
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                    }
                }
                else
                {
                    ShowDialogException("EndUpdate", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("EndUpdate", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void EndUpdate()
        {
            FormSkin oFormSkin;
            var oEnumerator = m_oFormList.GetEnumerator();
            while (oEnumerator.MoveNext())
            {
                oFormSkin = (FormSkin)oEnumerator.Current;
                oFormSkin.RichTextBoxOutput.EndTextUpdate();
            }
        }

        private void Script_EventPrintError(string sText)
        {
            var argoColor = Color.WhiteSmoke;
            var argoBgColor = Color.DarkRed;
            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
            string argsTargetWindow = "";
            AddText(sText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
            // Send these errors to a different window later. For easy monitoring.
        }

        private void Command_ScriptVariables(string sScript, string sFilter)
        {
            try
            {
                if ((sScript.ToLower() ?? "") == "all")
                {
                    sScript = string.Empty;
                }

                // Scripts
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    Debug.Print("ScriptList Lock aquired by ScriptTrace()");
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                        {
                            if (oScript.ScriptName.Length > 0)
                            {
                                if (sScript.Length == 0 | (oScript.ScriptName ?? "") == (sScript ?? ""))
                                {
                                    string argsText = Conversions.ToString(oScript.ScriptName + Interaction.IIf(oScript.ScriptPaused, "(Paused)", "") + ": " + oScript.RunTimeSeconds.ToString("#.#0") + " seconds. " + oScript.State + " (" + oScript.FileName + ")" + Constants.vbNewLine);
                                    Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                                    AddText(argsText, oTargetWindow: argoTargetWindow);
                                    foreach (string sRow in oScript.VariableList.Split(Conversions.ToChar(Constants.vbNewLine)))
                                    {
                                        if (sFilter.Length == 0 | sRow.ToLower().Contains(sFilter.ToLower()))
                                        {
                                            Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                                            AddText(sRow, oTargetWindow: argoTargetWindow1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                        Debug.Print("ScriptList Lock released by ScriptTrace()");
                    }
                }
                else
                {
                    ShowDialogException("ScriptVariables", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ScriptVariables", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Command_ScriptTrace(string sScript)
        {
            try
            {
                if ((sScript.ToLower() ?? "") == "all")
                {
                    sScript = string.Empty;
                }

                // Scripts
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    Debug.Print("ScriptList Lock aquired by ScriptTrace()");
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                        {
                            if (oScript.ScriptName.Length > 0)
                            {
                                if (sScript.Length == 0 | (oScript.ScriptName ?? "") == (sScript ?? ""))
                                {
                                    string argsText = Conversions.ToString(oScript.ScriptName + Interaction.IIf(oScript.ScriptPaused, "(Paused)", "") + ": " + oScript.RunTimeSeconds.ToString("#.#0") + " seconds. " + oScript.State + " (" + oScript.FileName + ")" + Constants.vbNewLine);
                                    Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                                    AddText(argsText, oTargetWindow: argoTargetWindow);
                                    string argsText1 = oScript.TraceList + Constants.vbNewLine;
                                    Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                                    AddText(argsText1, oTargetWindow: argoTargetWindow1);
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                        Debug.Print("ScriptList Lock released by ScriptTrace()");
                    }
                }
                else
                {
                    ShowDialogException("ScriptTrace", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ScriptTrace", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Command_ScriptAbort(string sScript)
        {
            try
            {
                string sExcept = string.Empty;
                int I = sScript.ToLower().IndexOf("except ");
                if (I > 0)
                {
                    sExcept = sScript.Substring(I + 7);
                    sScript = sScript.Substring(0, I).TrimEnd();
                }

                sScript += " ";
                if (sScript.ToLower().StartsWith("all "))
                {
                    sScript = string.Empty;
                }
                else
                {
                    sScript = sScript.Trim();
                }


                // Scripts
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    Debug.Print("ScriptList Lock aquired by ScriptAbort()");
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                        {
                            if (oScript.ScriptName.Length > 0)
                            {
                                if (sScript.Length == 0 | (oScript.ScriptName ?? "") == (sScript ?? ""))
                                {
                                    if (sExcept.Length == 0 | (oScript.ScriptName ?? "") != (sExcept ?? ""))
                                    {
                                        oScript.AbortScript();
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                        Debug.Print("ScriptList Lock released by ScriptAbort()");
                    }
                }
                else
                {
                    ShowDialogException("ScriptAbort", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ScriptAbort", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Command_ScriptPause(string sScript)
        {
            try
            {
                string sExcept = string.Empty;
                int I = sScript.ToLower().IndexOf("except ");
                if (I > 0)
                {
                    sExcept = sScript.Substring(I + 7);
                    sScript = sScript.Substring(0, I).TrimEnd();
                }

                sScript += " ";
                if (sScript.ToLower().StartsWith("all "))
                {
                    sScript = string.Empty;
                }
                else
                {
                    sScript = sScript.Trim();
                }

                // Scripts
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    Debug.Print("ScriptList Lock aquired by ScriptPause(()");
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                        {
                            if (oScript.ScriptName.Length > 0)
                            {
                                if (sScript.Length == 0 | (oScript.ScriptName ?? "") == (sScript ?? ""))
                                {
                                    if (sExcept.Length == 0 | (oScript.ScriptName ?? "") != (sExcept ?? ""))
                                    {
                                        oScript.PauseScript();
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                        Debug.Print("ScriptList Lock released by ScriptPause(()");
                    }
                }
                else
                {
                    ShowDialogException("ScriptPause", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ScriptPause", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Command_ScriptPauseOrResume(string sScript)
        {
            try
            {
                string sExcept = string.Empty;
                int I = sScript.ToLower().IndexOf("except ");
                if (I > 0)
                {
                    sExcept = sScript.Substring(I + 7);
                    sScript = sScript.Substring(0, I).TrimEnd();
                }

                sScript += " ";
                if (sScript.ToLower().StartsWith("all "))
                {
                    sScript = string.Empty;
                }
                else
                {
                    sScript = sScript.Trim();
                }

                // Scripts
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    Debug.Print("ScriptList Lock aquired by ScriptPause(()");
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                        {
                            if (oScript.ScriptName.Length > 0)
                            {
                                if (sScript.Length == 0 | (oScript.ScriptName ?? "") == (sScript ?? ""))
                                {
                                    if (sExcept.Length == 0 | (oScript.ScriptName ?? "") != (sExcept ?? ""))
                                    {
                                        if (oScript.ScriptPaused == true)
                                        {
                                            oScript.ResumeScript();
                                        }
                                        else
                                        {
                                            oScript.PauseScript();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                        Debug.Print("ScriptList Lock released by ScriptPause(()");
                    }
                }
                else
                {
                    ShowDialogException("ScriptPauseOrResume", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ScriptPauseOrResume", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Command_ScriptResume(string sScript)
        {
            try
            {
                string sExcept = string.Empty;
                int I = sScript.ToLower().IndexOf("except ");
                if (I > 0)
                {
                    sExcept = sScript.Substring(I + 7);
                    sScript = sScript.Substring(0, I).TrimEnd();
                }

                sScript += " ";
                if (sScript.ToLower().StartsWith("all "))
                {
                    sScript = string.Empty;
                }
                else
                {
                    sScript = sScript.Trim();
                }

                // Scripts
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    Debug.Print("ScriptList Lock aquired by ScriptResume(()");
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                        {
                            if (oScript.ScriptName.Length > 0)
                            {
                                if (sScript.Length == 0 | (oScript.ScriptName ?? "") == (sScript ?? ""))
                                {
                                    if (sExcept.Length == 0 | (oScript.ScriptName ?? "") != (sExcept ?? ""))
                                    {
                                        oScript.ResumeScript();
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                        Debug.Print("ScriptList Lock released by ScriptResume(()");
                    }
                }
                else
                {
                    ShowDialogException("ScriptResume", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ScriptResume", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Command_ScriptDebugLevel(int iDebugLevel, string sScript)
        {
            try
            {
                if ((sScript.ToLower() ?? "") == "all")
                {
                    sScript = string.Empty;
                }

                // Scripts
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    Debug.Print("ScriptList Lock aquired by ScriptDebugLevel(()");
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                        {
                            if (oScript.ScriptName.Length > 0)
                            {
                                if (sScript.Length == 0 | (oScript.ScriptName ?? "") == (sScript ?? ""))
                                {
                                    oScript.DebugLevel = iDebugLevel;
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                        Debug.Print("ScriptList Lock released by ScriptDebugLevel(()");
                    }
                }
                else
                {
                    ShowDialogException("ScriptDebugLevel", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ScriptDebugLevel", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Command_StatusBar(string sText, int iIndex)
        {
            try
            {
                ToolStripStatusLabel oLabel = null;
                switch (iIndex)
                {
                    case 1:
                        {
                            oLabel = ToolStripStatusLabel1;
                            break;
                        }

                    case 2:
                        {
                            oLabel = ToolStripStatusLabel2;
                            break;
                        }

                    case 3:
                        {
                            oLabel = ToolStripStatusLabel3;
                            break;
                        }

                    case 4:
                        {
                            oLabel = ToolStripStatusLabel4;
                            break;
                        }

                    case 5:
                        {
                            oLabel = ToolStripStatusLabel5;
                            break;
                        }

                    case 6:
                        {
                            oLabel = ToolStripStatusLabel6;
                            break;
                        }

                    case 7:
                        {
                            oLabel = ToolStripStatusLabel7;
                            break;
                        }

                    case 8:
                        {
                            oLabel = ToolStripStatusLabel8;
                            break;
                        }

                    case 9:
                        {
                            oLabel = ToolStripStatusLabel9;
                            break;
                        }

                    case 10:
                        {
                            oLabel = ToolStripStatusLabel10;
                            break;
                        }

                    default:
                        {
                            oLabel = ToolStripStatusLabel1;
                            break;
                        }
                }

                SafeSetStatusBar(sText, oLabel);
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("StatusBar", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (My.MyProject.Forms.DialogConnect.ShowDialog(this) == DialogResult.OK)
            {
                string argsAccountName = My.MyProject.Forms.DialogConnect.AccountName;
                string argsPassword = My.MyProject.Forms.DialogConnect.Password;
                string argsCharacter = My.MyProject.Forms.DialogConnect.Character;
                string argsGame = My.MyProject.Forms.DialogConnect.Game;
                ConnectToGame(argsAccountName, argsPassword, argsCharacter, argsGame);
                SavePasswordToolStripMenuItem.Checked = My.MyProject.Forms.DialogConnect.CheckBoxSavePassword.Checked;
            }
        }

        private static DateTime m_oNullTime = DateTime.Parse("0001-01-01");
        private bool m_CommandSent = false;

        public void CheckReconnect()
        {
            if (!m_oGlobals.Config.bReconnect)
                return;
            if (Information.IsNothing(m_oGame))
                return;
            if (m_oGame.ReconnectTime == m_oNullTime)
                return;
            if (m_CommandSent == false)
            {
                string argsText = "Reconnect aborted! (No user input since last connect.)" + Constants.vbNewLine;
                PrintError(argsText);
                if (m_oGame.IsConnected)
                {
                    m_oGame.Disconnect();
                }

                m_oGame.ReconnectTime = default;
                return;
            }

            if (m_oGame.ReconnectTime < DateTime.Now) // Connect now
            {
                m_oGame.ReconnectTime = default;
                m_oGame.ConnectAttempts += 1;
                if (m_oGlobals.Config.bReconnectWhenDead == false)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oGlobals.VariableList["dead"], 1, false)))
                    {
                        string argsText1 = "Reconnect aborted! (You seem to be dead.)" + Constants.vbNewLine;
                        PrintError(argsText1);
                        return;
                    }
                }

                ReconnectToGame();
            }
        }

        private void ReconnectToGame()
        {
            try
            {
                if (m_oGame.AccountName.Length > 0)
                {
                    m_oGlobals.GenieKey = m_sGenieKey;
                    m_oGlobals.GenieAccount = m_oGame.AccountName;
                    string argsAccountName = m_oGame.AccountName;
                    string argsPassword = m_oGame.AccountPassword;
                    string argsCharacter = m_oGame.AccountCharacter;
                    string argsGame = m_oGame.AccountGame;
                    m_oGame.Connect(m_sGenieKey, argsAccountName, argsPassword, argsCharacter, argsGame);
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ReconnectToGame", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void ConnectToGame(string sAccountName, string sPassword, string sCharacter, string sGame)
        {
            try
            {
                if (sPassword.Length > 0)
                {
                    m_oGame.Connect(m_sGenieKey, sAccountName, sPassword, sCharacter, sGame);
                }
                else
                {
                    // Load profile
                    m_sCurrentProfileFile = string.Empty;
                    SafeLoadProfile(sAccountName.Trim() + ".xml", true);
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ConnectToGame", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void DisconnectFromGame()
        {
            m_oGame.Disconnect();
        }

        private void ConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.FormConfig.MdiParent = this;
            My.MyProject.Forms.FormConfig.Show();
            My.MyProject.Forms.FormConfig.BringToFront();
        }

        public delegate void PrintDialogExceptionDelegate(string section, string message, string description);

        private void HandleGenieException(string section, string message, string description = null)
        {
            if (InvokeRequired == true)
            {
                var parameters = new[] { section, message, description };
                Invoke(new PrintDialogExceptionDelegate(ShowDialogException), parameters);
            }
            else
            {
                ShowDialogException(section, message, description);
            }
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowDialogException("Main", e.Exception.Message, e.Exception.ToString());
        }

        private void ShowDialogException(string section, string message, string description = null)
        {
            if (My.MyProject.Forms.DialogException.Visible == false)
            {
                var sbDetails = new StringBuilder();
                sbDetails.Append("Action:                ");
                sbDetails.Append(section);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(message);
                if (!Information.IsNothing(description))
                {
                    sbDetails.Append(Constants.vbNewLine);
                    sbDetails.Append(Constants.vbNewLine);
                    sbDetails.Append("----------------------------------------------");
                    sbDetails.Append(Constants.vbNewLine);
                    sbDetails.Append(description);
                }

                My.MyProject.Forms.DialogException.Show(this, section + Constants.vbNewLine + message + Constants.vbNewLine + Constants.vbNewLine + description);
            }
        }

        public delegate void PrintDialogPluginExceptionDelegate(GeniePlugin.Interfaces.IPlugin plugin, string section, Exception ex);

        private void HandlePluginException(GeniePlugin.Interfaces.IPlugin plugin, string section, Exception ex)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { plugin, section, ex };
                Invoke(new PrintDialogPluginExceptionDelegate(ShowDialogPluginException), parameters);
            }
            else
            {
                ShowDialogPluginException(plugin, section, ex);
            }
        }

        private void ShowDialogAutoMapperException(string section, Exception ex)
        {
            if (My.MyProject.Forms.DialogException.Visible == false)
            {
                var sbDetails = new StringBuilder();
                sbDetails.Append("AutoMapper Action:     ");
                sbDetails.Append(section);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(ex.Message);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append("----------------------------------------------");
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(ex.ToString());
                My.MyProject.Forms.DialogException.Show(this, sbDetails.ToString(), "There was an unexpected error in the AutoMapper. This may be due to a programming bug.");
            }
        }

        private void ShowDialogPluginException(GeniePlugin.Interfaces.IPlugin plugin, string section, Exception ex)
        {
            if (My.MyProject.Forms.DialogException.Visible == false)
            {
                string sPluginName = "Unknown";
                string sPluginVersion = "Unknown";
                if (!Information.IsNothing(plugin))
                {
                    sPluginName = Conversions.ToString(Interaction.IIf(Information.IsNothing(plugin.Name), "Unknown", plugin.Name));
                    sPluginVersion = Conversions.ToString(Interaction.IIf(Information.IsNothing(plugin.Version), "Unknown", plugin.Version));
                }

                var sbDetails = new StringBuilder();
                sbDetails.Append("Plugin Name:           ");
                sbDetails.Append(sPluginName);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append("Plugin Version         ");
                sbDetails.Append(sPluginVersion);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append("Plugin Action:         ");
                sbDetails.Append(section);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(ex.Message);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append("----------------------------------------------");
                sbDetails.Append(Constants.vbNewLine);
                sbDetails.Append(ex.ToString());
                My.MyProject.Forms.DialogException.Show(this, sbDetails.ToString(), "There was an unexpected error in the plugin " + sPluginName + ". This may be due to a programming bug.", "The plugin has been disabled.", "Please report the details of this error to the plugin author. You may also want to make sure you are running the latest version of this plugin.");
            }
        }

        private void Game_EventTriggerParse(string sText)
        {
            try
            {
                ParseTriggers(sText);
            }
            // SafeParsePluginText(sText)
            // Debug.WriteLine("ClassCommand_SendText)")
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("TriggerParse", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Game_EventStatusBarUpdate()
        {
            try
            {
                SafeSetStatusBarLabels();
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("StatusBarUpdate", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        public delegate void SetStatusBarLabelsDelegate();

        private void SafeSetStatusBarLabels()
        {
            if (InvokeRequired == true)
            {
                Invoke(new SetStatusBarLabelsDelegate(SetStatusBarLabels));
            }
            else
            {
                SetStatusBarLabels();
            }
        }

        private void SetStatusBarLabels()
        {
            LabelLHC.Text = Conversions.ToString(m_oGlobals.VariableList["lefthand"]);
            LabelRHC.Text = Conversions.ToString(m_oGlobals.VariableList["righthand"]);
            if (m_oGlobals.Config.bShowSpellTimer == true && m_oGlobals.oSpellTimeStart != DateTime.MinValue)
            {
                var argoDateEnd = DateTime.Now;
                LabelSpellC.Text = Conversions.ToString("(" + Utility.GetTimeDiffInSeconds(m_oGlobals.oSpellTimeStart, argoDateEnd) + ") " + m_oGlobals.VariableList["preparedspell"]);
            }
            else
            {
                LabelSpellC.Text = Conversions.ToString(m_oGlobals.VariableList["preparedspell"]);
            }
        }

        public delegate void ClearSpellTimeDelegate();

        private void Game_EventClearSpellTime()
        {
            try
            {
                if (InvokeRequired == true)
                {
                    Invoke(new ClearSpellTimeDelegate(ClearSpellTime));
                }
                else
                {
                    ClearSpellTime();
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("ClearSpellTime", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        public delegate void SetSpellTimeDelegate();

        private void Game_EventSpellTime()
        {
            try
            {
                if (InvokeRequired == true)
                {
                    Invoke(new SetSpellTimeDelegate(SetSpellTime));
                }
                else
                {
                    SetSpellTime();
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("SpellTime", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void SetSpellTime()
        {
            m_oGlobals.oSpellTimeStart = DateTime.Now;
        }

        private void ClearSpellTime()
        {
            m_oGlobals.oSpellTimeStart = default;
        }

        public delegate void SetRoundtimeDelegate(int iTime);

        private void Game_EventRoundtime(int iTime)
        {
            try
            {
                if (InvokeRequired == true)
                {
                    Invoke(new SetRoundtimeDelegate(SetRoundTime), iTime);
                }
                else
                {
                    SetRoundTime(iTime);
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("RoundTime", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        public delegate void SetBarValueDelegate(int iValue, ComponentBars oBar);

        private void SetBarValue(int iValue, ComponentBars oBar)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { iValue, oBar };
                Invoke(new SetBarValueDelegate(InvokeSetBarValue), parameters);
            }
            else
            {
                InvokeSetBarValue(iValue, oBar);
            }
        }

        private void InvokeSetBarValue(int iValue, ComponentBars oBar)
        {
            oBar.Value = iValue;
        }

        public delegate void SetStatusBarDelegate(string sText, ToolStripStatusLabel oLabel);

        private void SafeSetStatusBar(string sText, ToolStripStatusLabel oLabel)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { sText, oLabel };
                Invoke(new SetStatusBarDelegate(SetStatusBar), parameters);
            }
            else
            {
                SetStatusBar(sText, oLabel);
            }
        }

        private void SetStatusBar(string sText, ToolStripStatusLabel oLabel)
        {
            if (oLabel.Visible == false)
            {
                oLabel.Visible = true;
            }

            oLabel.Text = sText;
        }

        private void Script_EventSendText(string sText, string sScript, bool bToQueue)
        {
            try
            {
                bool bSendText = true;
                if (sText.StartsWith(Conversions.ToString(m_oGlobals.Config.cCommandChar))) // Don't send text to game that start with #
                {
                    bSendText = false;
                }

                if (bToQueue == false)
                {
                    m_oCommand.ParseCommand(sText, bSendText, false, sScript);
                }

                // If bSendText = True Then
                // If oGlobals.Config.bTriggerOnInput = True Then
                // ParseTriggers(sText)
                // End If
                // End If
                else
                {
                    int iPauseTime = 0;
                    string sNumber = string.Empty;
                    foreach (char c in sText.ToCharArray())
                    {
                        if (Information.IsNumeric(c) | c == '.')
                        {
                            sNumber += Conversions.ToString(c);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (sNumber.Length > 0 & (sNumber ?? "") != ".")
                    {
                        sText = sText.Substring(sNumber.Length).Trim();
                        iPauseTime = int.Parse(sNumber);
                    }

                    double argdDelay = iPauseTime;
                    string argsAction = m_oGlobals.ParseGlobalVars(sText);
                    m_oGlobals.CommandQueue.AddToQueue(argdDelay, true, argsAction);
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("SendText", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Game_EventTriggerPrompt()
        {
            try
            {
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                            oScript.TriggerPrompt();
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                    }
                }
                else
                {
                    ShowDialogException("TriggerPrompt", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("TriggerPrompt", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void Game_EventTriggerMove()
        {
            try
            {
                if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
                {
                    try
                    {
                        foreach (Script oScript in m_oScriptList)
                            oScript.TriggerMove();
                    }
                    finally
                    {
                        m_oScriptList.ReleaseReaderLock();
                    }
                }
                else
                {
                    ShowDialogException("TriggerMove", "Unable to acquire reader lock.");
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("TriggerMove", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private DateTime m_oRoundtimeEnd;

        private bool HasRoundtime
        {
            get
            {
                if (DateTime.Now < m_oRoundtimeEnd)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void SetRoundTime(int iTime)
        {
            if (iTime == 0)
                return;
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(oRTControl.CurrentRT, 0, false) | iTime > oRTControl.CurrentRT + 1))
            {
                oRTControl.SetRT((int)(iTime + m_oGlobals.Config.dRTOffset));
            }

            if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
            {
                try
                {
                    foreach (Script oScript in m_oScriptList)
                        oScript.SetRoundTime(iTime);
                }
                finally
                {
                    m_oScriptList.ReleaseReaderLock();
                }
            }
            else
            {
                ShowDialogException("RoundTime", "Unable to acquire reader lock.");
            }

            m_oRoundtimeEnd = DateTime.Now.AddMilliseconds(iTime * 1000 + m_oGlobals.Config.dRTOffset * 1000);
        }

        public void InputKeyDown(KeyEventArgs e)
        {
            if (bSendingKey == true)
                return;
            bSendingKey = true;
            string sKeyString = string.Empty;
            TextBoxInput.Focus();
            var switchExpr = e.KeyData;
            switch (switchExpr)
            {
                case Keys.Back:
                    {
                        sKeyString = "{BACKSPACE}";
                        break;
                    }

                case Keys.Delete:
                    {
                        sKeyString = "{DELETE}";
                        break;
                    }

                case Keys.Up:
                    {
                        sKeyString = "{UP}";
                        break;
                    }

                case Keys.Down:
                    {
                        sKeyString = "{DOWN}";
                        break;
                    }

                case Keys.Left:
                    {
                        sKeyString = "{LEFT}";
                        break;
                    }

                case Keys.Right:
                    {
                        sKeyString = "{RIGHT}";
                        break;
                    }
            }

            if (sKeyString.Length > 0)
            {
                SendKeys.SendWait(sKeyString);
            }

            bSendingKey = false;
        }

        public void InputKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' | char.IsControl(e.KeyChar) == false & char.IsWhiteSpace(e.KeyChar) == false)
            {
                TextBoxInput.SelectedText = Conversions.ToString(e.KeyChar);
            }

            TextBoxInput.Focus();
        }

        private void EnterGenieKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void AbortAllScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbortAllScripts();
        }

        private void AbortAllScripts()
        {
            if (m_oScriptList.AcquireReaderLock(m_iDefaultTimeout))
            {
                try
                {
                    foreach (Script oScript in m_oScriptList)
                        oScript.AbortScript();
                }
                finally
                {
                    m_oScriptList.ReleaseReaderLock();
                }
            }
            else
            {
                ShowDialogException("AbortAllScripts", "Unable to acquire reader lock.");
            }
        }

        private void PauseAllScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseAllScripts();
        }

        private void PauseAllScripts()
        {
            string argsScript = "";
            Command_ScriptPause(argsScript);
        }

        private void ResumeAllScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResumeAllScripts();
        }

        private void ResumeAllScripts()
        {
            string argsScript = "";
            Command_ScriptResume(argsScript);
        }

        private void ChangelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.DialogChangelog.ShowDialog(this);
        }

        private void BasicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutBasic();
        }

        public bool m_IsChangingLayout = false;

        private void SaveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveXMLConfig(m_sConfigFile))
            {
                if (!Information.IsNothing(m_sConfigFile))
                {
                    if (m_oOutputMain.Visible)
                    {
                        string argsText = "Layout Saved: " + m_sConfigFile + Constants.vbNewLine;
                        var argoColor = Color.WhiteSmoke;
                        var argoBgColor = Color.Transparent;
                        Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                        string argsTargetWindow = "";
                        AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
                    }
                }
            }
        }

        private void ShowScriptBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtons.Visible = ShowScriptBarToolStripMenuItem.Checked;
        }

        private void DockTopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripButtons.Dock = DockStyle.Top;
            if (ShowScriptBarToolStripMenuItem.Checked == false)
            {
                ShowScriptBarToolStripMenuItem.Checked = true;
                ToolStripButtons.Visible = true;
            }

            DockTopToolStripMenuItem1.Checked = true;
            DockBottomToolStripMenuItem1.Checked = false;
        }

        private void DockBottomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripButtons.Dock = DockStyle.Bottom;
            if (ShowScriptBarToolStripMenuItem.Checked == false)
            {
                ShowScriptBarToolStripMenuItem.Checked = true;
                ToolStripButtons.Visible = true;
            }

            DockBottomToolStripMenuItem1.Checked = true;
            DockTopToolStripMenuItem1.Checked = false;
        }

        private void DockTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelStatus.Dock = DockStyle.Top;
            if (IconBarToolStripMenuItem.Checked == false)
            {
                IconBarToolStripMenuItem.Checked = true;
                PanelStatus.Visible = true;
            }

            DockTopToolStripMenuItem.Checked = true;
            DockBottomToolStripMenuItem.Checked = false;
        }

        private void DockBottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelStatus.Dock = DockStyle.Bottom;
            if (IconBarToolStripMenuItem.Checked == false)
            {
                IconBarToolStripMenuItem.Checked = true;
                PanelStatus.Visible = true;
            }

            DockBottomToolStripMenuItem.Checked = true;
            DockTopToolStripMenuItem.Checked = false;
        }

        private void IconBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelStatus.Visible = IconBarToolStripMenuItem.Checked;
        }

        private void HealthBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelBars.Visible = HealthBarToolStripMenuItem.Checked;
        }

        private void DockTopToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PanelBars.Dock = DockStyle.Top;
            if (HealthBarToolStripMenuItem.Checked == false)
            {
                HealthBarToolStripMenuItem.Checked = true;
                PanelBars.Visible = true;
            }

            DockTopToolStripMenuItem2.Checked = true;
            DockBottomToolStripMenuItem2.Checked = false;
        }

        private void DockBottomToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PanelBars.Dock = DockStyle.Bottom;
            if (HealthBarToolStripMenuItem.Checked == false)
            {
                HealthBarToolStripMenuItem.Checked = true;
                PanelBars.Visible = true;
            }

            DockBottomToolStripMenuItem2.Checked = true;
            DockTopToolStripMenuItem2.Checked = false;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusStripMain.Visible = StatusBarToolStripMenuItem.Checked;
        }

        private FormSkin oCurrentActiveForm = null;

        public FormSkin ActiveFormSkin
        {
            get
            {
                return oCurrentActiveForm;
            }

            set
            {
                oCurrentActiveForm = value;
            }
        }

        private bool bSendingKey = false;

        private void TextBoxInput_PageUp()
        {
            if (bSendingKey == true)
                return;
            bSendingKey = true;
            if (!Information.IsNothing(oCurrentActiveForm))
            {
                oCurrentActiveForm.RichTextBoxOutput.Focus();
                SendKeys.SendWait("{PGUP}");
                TextBoxInput.Focus();
            }

            bSendingKey = false;
        }

        private void TextBoxInput_PageDown()
        {
            if (bSendingKey == true)
                return;
            bSendingKey = true;
            if (!Information.IsNothing(oCurrentActiveForm))
            {
                oCurrentActiveForm.RichTextBoxOutput.Focus();
                SendKeys.SendWait("{PGDN}");
                TextBoxInput.Focus();
            }

            bSendingKey = false;
        }

        private void ToolStripMenuItemSpecialPaste_Click(object sender, EventArgs e)
        {
            TextBoxInput.Focus();
            if (Clipboard.ContainsText() == true)
            {
                TextBoxInput.Paste(Clipboard.GetText().Replace(Constants.vbCr, ";").Replace(Constants.vbLf, "").TrimEnd());
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var x = DateTime.Now;
            for (int I = 0; I <= 100; I++)
            {
                string argsText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." + Constants.vbNewLine;
                bool argbIsPrompt = false;
                Genie.Game.WindowTarget argoWindowTarget = 0;
                m_oGame.PrintTextWithParse(argsText, bIsPrompt: argbIsPrompt, oWindowTarget: argoWindowTarget);
                string argsText1 = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." + Constants.vbNewLine + Constants.vbNewLine;
                bool argbIsPrompt1 = false;
                Genie.Game.WindowTarget argoWindowTarget1 = 0;
                m_oGame.PrintTextWithParse(argsText1, bIsPrompt: argbIsPrompt1, oWindowTarget: argoWindowTarget1);
            }

            var y = DateTime.Now;
            var dur = new TimeSpan();
            dur = y - x;
            string argsText2 = "Total duration: " + dur.TotalMilliseconds.ToString() + " milliseconds." + Constants.vbNewLine;
            var argoColor = Color.Green;
            var argoBgColor = Color.Transparent;
            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
            string argsTargetWindow = "";
            AddText(argsText2, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
        }

        private bool m_bTriggersEnabled = true;

        private void ToolStripMenuItemTriggers_Click(object sender, EventArgs e)
        {
            m_bTriggersEnabled = ToolStripMenuItemTriggers.Checked;
        }

        private void ToolStripMenuItemShowXML_Click(object sender, EventArgs e)
        {
            m_oGame.ShowRawOutput = ToolStripMenuItemShowXML.Checked;
            if (m_oGame.ShowRawOutput)
                AddWindow("Raw");
        }

        private bool m_bVersionUpdated = false;
        private bool m_bIsLoading = true;
        private bool m_bDebugPlugin = false;

        public delegate void UpdateMonoFontDelegate();

        private void SafeUpdateMonoFont()
        {
            if (InvokeRequired == true)
            {
                Invoke(new UpdateMonoFontDelegate(UpdateMonoFont));
            }
            else
            {
                UpdateMonoFont();
            }
        }

        private void UpdateMonoFont()
        {
            m_oOutputMain.RichTextBoxOutput.MonoFont = m_oGlobals.Config.MonoFont;
            var oEnumerator = m_oFormList.GetEnumerator();
            while (oEnumerator.MoveNext())
            {
                FormSkin oForm = (FormSkin)oEnumerator.Current;
                oForm.RichTextBoxOutput.MonoFont = m_oGlobals.Config.MonoFont;
            }
        }

        public delegate void UpdateInputFontDelegate();

        private void SafeUpdateInputFont()
        {
            if (InvokeRequired == true)
            {
                Invoke(new UpdateInputFontDelegate(UpdateInputFont));
            }
            else
            {
                UpdateInputFont();
            }
        }

        private void UpdateInputFont()
        {
            TextBoxInput.Font = m_oGlobals.Config.InputFont;
            PanelInput.Height = TextBoxInput.FontHeight + 6;
        }

        private void Config_ConfigChanged(Genie.Config.ConfigFieldUpdated oField)
        {
            switch (oField)
            {
                case Genie.Config.ConfigFieldUpdated.MonoFont:
                    {
                        SafeUpdateMonoFont();
                        break;
                    }

                case Genie.Config.ConfigFieldUpdated.InputFont:
                    {
                        SafeUpdateInputFont();
                        break;
                    }

                case Genie.Config.ConfigFieldUpdated.Autolog:
                    {
                        AutoLogToolStripMenuItem.Checked = m_oGlobals.Config.bAutoLog;
                        break;
                    }

                case Genie.Config.ConfigFieldUpdated.Reconnect:
                    {
                        AutoReconnectToolStripMenuItem.Checked = m_oGlobals.Config.bReconnect;
                        break;
                    }

                case Genie.Config.ConfigFieldUpdated.KeepInput:
                    {
                        TextBoxInput.KeepInput = m_oGlobals.Config.bKeepInput;
                        break;
                    }

                case Genie.Config.ConfigFieldUpdated.Muted:
                    {
                        MuteSoundsToolStripMenuItem.Checked = !m_oGlobals.Config.bPlaySounds;
                        break;
                    }

                case Genie.Config.ConfigFieldUpdated.AutoMapper:
                    {
                        AutoMapperEnabledToolStripMenuItem.Checked = m_oGlobals.Config.bAutoMapper;
                        break;
                    }
            }
        }

        private void Command_EventClassChange()
        {
            var al = new ArrayList();
            if (m_oGlobals.ClassList.AcquireReaderLock())
            {
                try
                {
                    foreach (object key in m_oGlobals.ClassList.Keys)
                        al.Add(key);
                }
                finally
                {
                    m_oGlobals.ClassList.ReleaseReaderLock();
                    foreach (string k in al)
                    {
                        var key = k;

                        // Highlights
                        bool bState = bool.Parse(Conversions.ToString(m_oGlobals.ClassList[key]));
                        if ((key ?? "") == "default")
                            key = "";
                        m_oGlobals.HighlightList.ToggleClass(key, bState);
                        m_oGlobals.HighlightList.RebuildLineIndex();
                        m_oGlobals.HighlightList.RebuildStringIndex();
                        m_oGlobals.HighlightBeginsWithList.ToggleClass(key, bState);
                        m_oGlobals.HighlightRegExpList.ToggleClass(key, bState);

                        // Triggers
                        m_oGlobals.TriggerList.ToggleClass(key, bState);

                        // Subs
                        m_oGlobals.SubstituteList.ToggleClass(key, bState);

                        // Gags
                        m_oGlobals.GagList.ToggleClass(key, bState);
                    }
                }
            }
            else
            {
                throw new Exception("Unable to aquire reader lock.");
            }
        }

        private void LoadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLayout(m_sConfigFile);
        }

        private void AutoReconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_oGlobals.Config.bReconnect = AutoReconnectToolStripMenuItem.Checked;
        }

        private void TimerReconnect_Tick(object sender, EventArgs e)
        {
            CheckReconnect();
            CheckUserIdleTime();
            CheckServerIdleTime();
        }

        private const int ResponseTimeoutServer = 10;
        private const int ResponseTimeoutUser = 60;
        private bool m_bCheckServerResponse = false;
        private bool m_bCheckUserResponse = false;

        private void CheckServerIdleTime()
        {
            if (!m_oGame.IsConnected)
                return;
            if (m_oGlobals.Config.iServerActivityTimeout == 0)
                return;
            var argoDateStart = m_oGame.LastServerActivity;
            var argoDateEnd = DateTime.Now;
            int iDiff = Utility.GetTimeDiffInSeconds(argoDateStart, argoDateEnd);
            if (m_bCheckServerResponse)
            {
                if (iDiff >= m_oGlobals.Config.iServerActivityTimeout)
                {
                    if (iDiff >= m_oGlobals.Config.iServerActivityTimeout + ResponseTimeoutServer)
                    {
                        m_bCheckServerResponse = false;
                        if (m_oGlobals.Config.bReconnect == true)
                        {
                            string argsText = Utility.GetTimeStamp() + " Connection timeout. Attempting to reconnect.";
                            PrintError(argsText);
                            m_oGame.ReconnectTime = DateTime.Now;
                        }
                        else
                        {
                            string argsText1 = Utility.GetTimeStamp() + " Connection timeout.";
                            PrintError(argsText1);
                            m_oGame.Disconnect();
                        }
                    }
                }
                else
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    m_bCheckServerResponse = false;
                }
            }
            else if (iDiff >= m_oGlobals.Config.iServerActivityTimeout)
            {
                /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                m_bCheckServerResponse = true;
                m_oGame.SendRaw(m_oGlobals.Config.sServerActivityCommand + Constants.vbNewLine);
            }
        }

        private void CheckUserIdleTime()
        {
            if (Information.IsNothing(m_oGame))
                return;
            if (!m_oGame.IsConnected)
                return;
            if (m_oGlobals.Config.iUserActivityTimeout == 0)
                return;
            var argoDateStart = m_oGame.LastUserActivity;
            var argoDateEnd = DateTime.Now;
            int iDiff = Utility.GetTimeDiffInSeconds(argoDateStart, argoDateEnd);
            if (m_bCheckUserResponse)
            {
                if (iDiff >= m_oGlobals.Config.iUserActivityTimeout)
                {
                    if (iDiff >= m_oGlobals.Config.iUserActivityTimeout + ResponseTimeoutUser)
                    {
                        m_oGame.SendText(m_oGlobals.Config.sUserActivityCommand, false, "IDLE TIMER");
                    }
                }
                else
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    string argkey = "useridle";
                    string argvalue = "0";
                    m_oGlobals.VariableList.Add(argkey, argvalue, Genie.Globals.Variables.VariableType.Ignore);
                    TriggerVariableChanged("$useridle");
                    m_bCheckUserResponse = false;
                }
            }
            else if (iDiff >= m_oGlobals.Config.iUserActivityTimeout)
            {
                string argsText = Constants.vbNewLine + Utility.GetTimeStamp() + " GENIE HAS FLAGGED YOU AS IDLE. PLEASE RESPOND!";
                PrintError(argsText);
                string argkey1 = "useridle";
                string argvalue1 = "1";
                m_oGlobals.VariableList.Add(argkey1, argvalue1, Genie.Globals.Variables.VariableType.Reserved);
                TriggerVariableChanged("$useridle");
                SafeFlashWindow();
                Interaction.Beep();
                m_bCheckUserResponse = true;
            }
        }

        private void CheckForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ListAllScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Command_EventListScripts("");
        }

        private void TraceAllScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string argsScript = "";
            Command_ScriptTrace(argsScript);
        }

        public delegate void PresetChangedDelegate(string sPreset);

        public void SafePresetChanged(string sPreset)
        {
            if (InvokeRequired == true)
            {
                var parameters = new[] { sPreset };
                Invoke(new PresetChangedDelegate(PresetChanged), parameters);
            }
            else
            {
                PresetChanged(sPreset);
            }
        }

        private void PresetChanged(string sPreset)
        {
            try
            {
                if (!Information.IsNothing(m_oGlobals.PresetList))
                {
                    switch (sPreset)
                    {
                        case "roundtime":
                            {
                                oRTControl.ForegroundColor = m_oGlobals.PresetList["roundtime"].FgColor;
                                oRTControl.BackgroundColorRT = m_oGlobals.PresetList["roundtime"].BgColor;
                                oRTControl.Refresh();
                                break;
                            }

                        case "health":
                            {
                                ComponentBarsHealth.ForegroundColor = m_oGlobals.PresetList["health"].FgColor;
                                ComponentBarsHealth.BackgroundColor = m_oGlobals.PresetList["health"].BgColor;
                                ComponentBarsHealth.BorderColor = m_oGlobals.PresetList["health"].BgColor;
                                ComponentBarsHealth.Refresh();
                                break;
                            }

                        case "mana":
                            {
                                ComponentBarsMana.ForegroundColor = m_oGlobals.PresetList["mana"].FgColor;
                                ComponentBarsMana.BackgroundColor = m_oGlobals.PresetList["mana"].BgColor;
                                ComponentBarsMana.BorderColor = m_oGlobals.PresetList["mana"].BgColor;
                                ComponentBarsMana.Refresh();
                                break;
                            }

                        case "stamina":
                            {
                                ComponentBarsFatigue.ForegroundColor = m_oGlobals.PresetList["stamina"].FgColor;
                                ComponentBarsFatigue.BackgroundColor = m_oGlobals.PresetList["stamina"].BgColor;
                                ComponentBarsFatigue.BorderColor = m_oGlobals.PresetList["stamina"].BgColor;
                                ComponentBarsFatigue.Refresh();
                                break;
                            }

                        case "spirit":
                            {
                                ComponentBarsSpirit.ForegroundColor = m_oGlobals.PresetList["spirit"].FgColor;
                                ComponentBarsSpirit.BackgroundColor = m_oGlobals.PresetList["spirit"].BgColor;
                                ComponentBarsSpirit.BorderColor = m_oGlobals.PresetList["spirit"].BgColor;
                                ComponentBarsSpirit.Refresh();
                                break;
                            }

                        case "concentration":
                            {
                                break;
                            }
                        // ComponentBarsConcentration.ForegroundColor = oGlobals.PresetList.Item("concentration").FgColor
                        // ComponentBarsConcentration.BackgroundColor = oGlobals.PresetList.Item("concentration").BgColor
                        // ComponentBarsConcentration.BorderColor = oGlobals.PresetList.Item("concentration").BgColor
                        // ComponentBarsConcentration.Refresh()
                        case "all":
                            {
                                oRTControl.ForegroundColor = m_oGlobals.PresetList["roundtime"].FgColor;
                                oRTControl.BackgroundColorRT = m_oGlobals.PresetList["roundtime"].BgColor;
                                oRTControl.Refresh();
                                ComponentBarsHealth.ForegroundColor = m_oGlobals.PresetList["health"].FgColor;
                                ComponentBarsHealth.BackgroundColor = m_oGlobals.PresetList["health"].BgColor;
                                ComponentBarsHealth.BorderColor = m_oGlobals.PresetList["health"].BgColor;
                                ComponentBarsHealth.Refresh();
                                ComponentBarsMana.ForegroundColor = m_oGlobals.PresetList["mana"].FgColor;
                                ComponentBarsMana.BackgroundColor = m_oGlobals.PresetList["mana"].BgColor;
                                ComponentBarsMana.BorderColor = m_oGlobals.PresetList["mana"].BgColor;
                                ComponentBarsMana.Refresh();
                                ComponentBarsFatigue.ForegroundColor = m_oGlobals.PresetList["stamina"].FgColor;
                                ComponentBarsFatigue.BackgroundColor = m_oGlobals.PresetList["stamina"].BgColor;
                                ComponentBarsFatigue.BorderColor = m_oGlobals.PresetList["stamina"].BgColor;
                                ComponentBarsFatigue.Refresh();
                                ComponentBarsSpirit.ForegroundColor = m_oGlobals.PresetList["spirit"].FgColor;
                                ComponentBarsSpirit.BackgroundColor = m_oGlobals.PresetList["spirit"].BgColor;
                                ComponentBarsSpirit.BorderColor = m_oGlobals.PresetList["spirit"].BgColor;
                                ComponentBarsSpirit.Refresh();
                                break;
                            }
                            // ComponentBarsConcentration.ForegroundColor = oGlobals.PresetList.Item("concentration").FgColor
                            // ComponentBarsConcentration.BackgroundColor = oGlobals.PresetList.Item("concentration").BgColor
                            // ComponentBarsConcentration.BorderColor = oGlobals.PresetList.Item("concentration").BgColor
                            // ComponentBarsConcentration.Refresh()
                    }
                }
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("PresetChanged", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void ClassCommand_PresetChanged(string sPreset)
        {
            try
            {
                SafePresetChanged(sPreset);
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            catch (Exception ex)
            {
                HandleGenieException("PresetChanged", ex.Message, ex.ToString());
                /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void OpenGenieForumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://genieclient.com/bulletin/");
        }

        private void OpenGenieWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\help.pdf"))
            {
                Process.Start(Application.StartupPath + @"\help.pdf");
            }
            else
            {
                Process.Start("http://genieclient.com/documentation.html");
            }
        }

        private void MagicPanelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMagicPanels(MagicPanelsToolStripMenuItem.Checked);
        }

        private void SetMagicPanels(bool bVisible)
        {
            ComponentBarsMana.Visible = bVisible;
            LabelSpell.Visible = bVisible;
            LabelSpellC.Visible = bVisible;
            if (bVisible == true)
            {
                TableLayoutPanelBars.ColumnCount = 5;
                TableLayoutPanelFlow.ColumnCount = 7;
            }
            else
            {
                TableLayoutPanelBars.ColumnCount = 4;
                TableLayoutPanelFlow.ColumnCount = 5;
            }
        }

        private void ScriptExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Command_ShowScriptExplorer();
        }

        private void Command_ShowScriptExplorer()
        {
            if (My.MyProject.Forms.ScriptExplorer.Visible == false)
            {
                My.MyProject.Forms.ScriptExplorer.MdiParent = this;
                My.MyProject.Forms.ScriptExplorer.Globals = m_oGlobals;
                My.MyProject.Forms.ScriptExplorer.EventRunScript += ClassCommand_RunScript;
                My.MyProject.Forms.ScriptExplorer.Show();
            }

            My.MyProject.Forms.ScriptExplorer.BringToFront();
        }

        private void AutoLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_oGlobals.Config.bAutoLog = AutoLogToolStripMenuItem.Checked;
        }

        private void PluginsEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_oGlobals.PluginsEnabled = PluginsEnabledToolStripMenuItem.Checked;
        }

        private void UpdateLayoutMenu()
        {
            IconBarToolStripMenuItem.Checked = PanelStatus.Visible;
            ShowScriptBarToolStripMenuItem.Checked = ToolStripButtons.Visible;
            HealthBarToolStripMenuItem.Checked = PanelBars.Visible;
            MagicPanelsToolStripMenuItem.Checked = ComponentBarsMana.Visible;
            StatusBarToolStripMenuItem.Checked = StatusStripMain.Visible;
        }

        private void IgnoresEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_oGlobals.Config.bGagsEnabled = IgnoresEnabledToolStripMenuItem.Checked;
        }

        private void LoadSettingsOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialogLayout.InitialDirectory = Path.GetDirectoryName(LoadedLayout);
            OpenFileDialogLayout.FileName = Path.GetFileName(LoadedLayout);
            if (OpenFileDialogLayout.ShowDialog() == DialogResult.OK)
            {
                LoadLayout(OpenFileDialogLayout.FileName);
            }
        }

        public bool LoadLayout(string sFile = "")
        {
            if (Strings.Len(sFile.Trim()) == 0)
            {
                sFile = m_sConfigFile;
            }
            else if (sFile.Contains(@"\") == false)
            {
                if (sFile.ToLower().EndsWith(".xml"))
                    return false;
                sFile = m_oGlobals.Config.ConfigDir + @"\Layout\" + sFile;
                if (sFile.ToLower().EndsWith(".layout") == false)
                {
                    sFile += ".layout";
                }
            }

            if (LoadSizedXMLConfig(sFile) || LoadXMLConfig(sFile))
            {
                UpdateLayoutMenu();
                HideOutputForms();
                ShowOutputForms();
                ShowForm(m_oOutputMain);
                return true;
            }
            else
            {
                UpdateLayoutMenu();
                return false;
            }
        }

        public bool SaveLayout(string file = null)
        {
            if (Information.IsNothing(file))
            {
                file = m_sConfigFile;
            }

            if (SaveXMLConfig(file) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialogLayout.InitialDirectory = Path.GetDirectoryName(LoadedLayout);
            SaveFileDialogLayout.FileName = Path.GetFileName(LoadedLayout);
            if (SaveFileDialogLayout.ShowDialog() == DialogResult.OK)
            {
                if (SaveXMLConfig(SaveFileDialogLayout.FileName))
                {
                    string argsText = "Layout saved: " + SaveFileDialogLayout.FileName + Constants.vbNewLine;
                    var argoColor = Color.WhiteSmoke;
                    var argoBgColor = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow = "";
                    AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
                }
            }
        }

        private void Command_LoadLayout(string sFile)
        {
            if ((sFile ?? "") == "@windowsize@")
            {
                string argsText = "Current layout size: " + Width.ToString() + "x" + Height.ToString() + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
            }
            else if (LoadLayout(sFile) == false)
            {
                string argsText1 = "Loading layout failed: " + sFile + Constants.vbNewLine;
                var argoColor = Color.WhiteSmoke;
                var argoBgColor = Color.Transparent;
                Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                string argsTargetWindow = "";
                AddText(argsText1, argoColor, argoBgColor, oTargetWindow: argoTargetWindow1, sTargetWindow: argsTargetWindow);
            }
        }

        private void Command_SaveLayout(string sFile)
        {
            if (Strings.Len(sFile.Trim()) == 0)
            {
                if (SaveXMLConfig() == true)
                {
                    string argsText = "Layout saved: " + m_sConfigFile + Constants.vbNewLine;
                    var argoColor = Color.WhiteSmoke;
                    var argoBgColor = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow = "";
                    AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
                }
            }
            else if (sFile.Contains(@"\") == false)
            {
                if (sFile.ToLower().EndsWith(".xml"))
                {
                    sFile = m_oGlobals.Config.ConfigDir + @"\" + sFile;
                }
                else
                {
                    sFile = m_oGlobals.Config.ConfigDir + @"\Layout\" + sFile;
                    if (sFile.ToLower().EndsWith(".layout") == false)
                    {
                        sFile += ".layout";
                    }
                }

                if (SaveXMLConfig(sFile) == true)
                {
                    string argsText1 = "Layout Saved: " + sFile + Constants.vbNewLine;
                    var argoColor1 = Color.WhiteSmoke;
                    var argoBgColor1 = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow1 = "";
                    AddText(argsText1, argoColor1, argoBgColor1, oTargetWindow: argoTargetWindow1, sTargetWindow: argsTargetWindow1);
                }
            }
        }

        private void Command_EventAddWindow(string sName)
        {
            AddWindow(sName);
        }

        private void AddWindow(string sName)
        {
            var oEnumerator = m_oFormList.GetEnumerator();
            while (oEnumerator.MoveNext())
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(((FormSkin)oEnumerator.Current).ID, sName.ToLower(), false)))
                {
                    ((FormSkin)oEnumerator.Current).Show();
                    return;
                }
            }

            var fo = SafeCreateOutputForm(Conversions.ToString(sName.ToLower()), Conversions.ToString(sName), null, 300, 200, 10, 10, true, null, "", true);
            if (!Information.IsNothing(fo))
            {
                fo.Visible = true;
            }
        }

        private void Command_EventRemoveWindow(string sName)
        {
            FormSkin oForm = null;
            var oEnumerator = m_oFormList.GetEnumerator();
            while (oEnumerator.MoveNext())
            {
                if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sName.ToLower() ?? ""))
                {
                    oForm = (FormSkin)oEnumerator.Current;
                    break;
                }
            }

            if (!Information.IsNothing(oForm))
            {
                if (oForm.UserForm)
                {
                    oForm.Unload();
                    oForm = null;
                    RemoveDisposedForms();
                    UpdateWindowMenuList();
                }
            }
        }

        private void Command_EventCloseWindow(string sName)
        {
            var oEnumerator = m_oFormList.GetEnumerator();
            while (oEnumerator.MoveNext())
            {
                if ((((FormSkin)oEnumerator.Current).ID ?? "") == (sName.ToLower() ?? ""))
                {
                    ((FormSkin)oEnumerator.Current).Hide();
                    return;
                }
            }
        }

        private void OpenLogInEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Conversions.ToString(Conversions.ToString(LocalDirectory.Path + @"\Logs\" + m_oGlobals.VariableList["charactername"]) + m_oGlobals.VariableList["game"] + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log")))
            {
                Interaction.Shell(Conversions.ToString(Conversions.ToString("\"" + m_oGlobals.Config.sEditor + "\" \"" + LocalDirectory.Path + @"\Logs\" + m_oGlobals.VariableList["charactername"]) + m_oGlobals.VariableList["game"] + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log\""), AppWinStyle.NormalFocus, false);
            }
            else
            {
                Interaction.MsgBox("No active log found.");
            }
        }

        private void MuteSoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_oGlobals.Config.bPlaySounds = !MuteSoundsToolStripMenuItem.Checked;
        }

        private void Command_FlashWindow()
        {
            SafeFlashWindow();
        }

        private void Command_EventMapperCommand(string cmd)
        {
            if (m_oGlobals.Config.bAutoMapper)
            {
                try
                {
                    m_oAutoMapper.ParseCommand(cmd, this);
                }
                catch (Exception ex)
                {
                    ShowDialogAutoMapperException("ParseCommand", ex);
                }
            }
            else
            {
                string argsText = "Mapper is currently disabled. Turn it back on in menu under [File/AutoMapper Enabled]" + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
            }
        }

        public delegate void FlashWindowDelegate();

        private void SafeFlashWindow()
        {
            if (InvokeRequired == true)
            {
                Invoke(new FlashWindowDelegate(FlashWindow));
            }
            else
            {
                FlashWindow();
            }
        }

        private void FlashWindow()
        {
            NativeMethods.FlashWindow(Handle, true);
        }

        private void ShowWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_oGlobals.Config.bAutoMapper)
            {
                m_oAutoMapper.Show(this);
            }
            else
            {
                string argsText = "Mapper is currently disabled. Turn it back on in menu under [File/AutoMapper Enabled]" + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
            }
        }

        private void ToolStripButtons_VisibleChanged(object sender, EventArgs e)
        {
            ToolStripButtons.Items.Clear();
            if (ToolStripButtons.Visible)
            {
                foreach (Script oScript in m_oScriptList)
                {
                    if (!Information.IsNothing(oScript)) // Add it before running so put #parse and such works.
                    {
                        AddScriptToToolStrip(oScript);
                    }
                }
            }
        }

        private void TimerBgWorker_Tick(object sender, EventArgs e)
        {
            // If System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator <> "." Then
            // System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            // End If
            /*
            try
            {*/
                string argsAction = m_oGlobals.Events.Poll();
                RunQueueCommand(argsAction, ""); // , "Event")
                int iSent = 0;
                bool argbInRoundtime = HasRoundtime;
                string sCommandQueue = m_oGlobals.CommandQueue.Poll(argbInRoundtime);
                while (sCommandQueue.Length > 0)
                {
                    RunQueueCommand(sCommandQueue, ""); // , "Queue")
                    iSent += 1;

                    // ' This is broke
                    // If iSent >= m_oGlobals.Config.iTypeAhead Then
                    // m_oGlobals.CommandQueue.SetNextTime(0.5)
                    // Exit While
                    // End If

                    bool argbInRoundtime1 = HasRoundtime;
                    sCommandQueue = m_oGlobals.CommandQueue.Poll(argbInRoundtime1);
                }

                TickScripts();
                if (m_oGlobals.Config.bShowSpellTimer == true && m_oGlobals.oSpellTimeStart != DateTime.MinValue)
                {
                    SafeSetStatusBarLabels();
                }

                SafeAddScripts();
                RemoveExitedScripts();

                if (m_bScriptListUpdated)
                {
                    SetScriptListVariable();
                }
                /*}
                 TODO ERROR: Skipped IfDirectiveTrivia 
                catch (Exception ex)
                {
                    HandleGenieException("BackgroundWorker", ex.Message, ex.ToString());
                    /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
            /*}
            */
        }

        private void AutoMapperEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoMapperEnabledToolStripMenuItem.Checked = !AutoMapperEnabledToolStripMenuItem.Checked;
            m_oGlobals.Config.bAutoMapper = AutoMapperEnabledToolStripMenuItem.Checked;
        }

        // Connect Using Profile
        private void ConnectToolStripMenuItemConnectDialog_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.DialogProfileConnect.ConfigDir = m_oGlobals.Config.ConfigDir;
            if (My.MyProject.Forms.DialogProfileConnect.ShowDialog(this) == DialogResult.OK)
            {
                m_sCurrentProfileFile = string.Empty;
                LoadProfile(My.MyProject.Forms.DialogProfileConnect.ProfileName + ".xml", true);
            }
        }

        private string m_sCurrentProfileFile = string.Empty;
        private Genie.XMLConfig m_oProfile = new Genie.XMLConfig();

        public delegate void LoadProfileDelegate(string FileName, bool DoConnect);

        private void SafeLoadProfile(string FileName, bool DoConnect)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { FileName, DoConnect };
                Invoke(new LoadProfileDelegate(LoadProfile), parameters);
            }
            else
            {
                LoadProfile(FileName, DoConnect);
            }
        }

        private void Command_LoadProfile()
        {
            if (m_oGlobals.VariableList["charactername"].ToString().Length > 0 & m_oGlobals.VariableList["game"].ToString().Length > 0)
            {
                string sFileName = m_oGlobals.VariableList["charactername"].ToString() + m_oGlobals.VariableList["game"].ToString() + ".xml";
                LoadProfile(sFileName);
            }
            else
            {
                string argsText = "Unknown character or game name. Load profile failed." + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
            }
        }

        public string LoadedLayout
        {
            get
            {
                if (m_oConfig.ConfigFile.Length > 0)
                {
                    return m_oConfig.ConfigFile;
                }
                else
                {
                    return m_sConfigFile;
                }
            }
        }

        private void LoadProfile(string FileName, bool DoConnect = false)
        {
            string ShortName = FileName;
            if (FileName.IndexOf(@"\") == -1)
            {
                FileName = m_oGlobals.Config.ConfigDir + @"\Profiles\" + FileName;
            }

            // Only load if profile changed
            // If m_sCurrentProfile <> FileName Then

            if (m_oProfile.LoadFile(FileName) == true)
            {
                string argsText = "Profile \"" + ShortName + "\" loaded." + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
                string sConfig = m_oProfile.GetValue("Genie/Profile/Layout", "FileName", string.Empty);
                if (sConfig.Length > 0 & (sConfig ?? "") != (m_oConfig.ConfigFile ?? ""))
                {
                    LoadLayout(sConfig);
                }

                string sCharacter = m_oProfile.GetValue("Genie/Profile", "Character", string.Empty);
                string sGame = m_oProfile.GetValue("Genie/Profile", "Game", string.Empty);
                if (sCharacter.Length > 0)
                    m_oGame.AccountCharacter = sCharacter;
                if (sGame.Length > 0)
                    m_oGame.AccountGame = sGame;
                string sProfile = string.Empty;
                sProfile = FileName.Substring(FileName.LastIndexOf(@"\") + 1).Replace(".xml", "");
                m_oGlobals.Config.sConfigDirProfile = m_oGlobals.Config.ConfigDir + @"\Profiles\" + sProfile;
                LoadProfileSettings();
                string sAccount = m_oProfile.GetValue("Genie/Profile", "Account", string.Empty);
                string sPassword = m_oProfile.GetValue("Genie/Profile", "Password", string.Empty);
                if (sPassword.Length > 0)
                {
                    string argsPassword = "G3" + sAccount.ToUpper();
                    sPassword = Utility.DecryptString(argsPassword, sPassword);
                    SavePasswordToolStripMenuItem.Checked = true;
                }
                else
                {
                    SavePasswordToolStripMenuItem.Checked = false;
                }

                if (DoConnect == true)
                {
                    if (sAccount.Length > 0 & sPassword.Length > 0)
                    {
                        ConnectToGame(sAccount, sPassword, sCharacter, sGame);
                    }
                    else
                    {
                        My.MyProject.Forms.DialogConnect.AccountName = sAccount;
                        My.MyProject.Forms.DialogConnect.Password = "";
                        My.MyProject.Forms.DialogConnect.Character = sCharacter;
                        My.MyProject.Forms.DialogConnect.Game = sGame;
                        if (My.MyProject.Forms.DialogConnect.ShowDialog(this) == DialogResult.OK)
                        {
                            string argsAccountName = My.MyProject.Forms.DialogConnect.AccountName;
                            string argsPassword1 = My.MyProject.Forms.DialogConnect.Password;
                            string argsCharacter = My.MyProject.Forms.DialogConnect.Character;
                            string argsGame = My.MyProject.Forms.DialogConnect.Game;
                            ConnectToGame(argsAccountName, argsPassword1, argsCharacter, argsGame);
                            SavePasswordToolStripMenuItem.Checked = My.MyProject.Forms.DialogConnect.CheckBoxSavePassword.Checked;
                        }
                    }
                }

                m_sCurrentProfileFile = FileName;
            }
            else if (DoConnect == true)
            {
                // Connect to non existing profile?
                string argsText1 = "Profile \"" + FileName + "\" not found." + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                AddText(argsText1, oTargetWindow: argoTargetWindow1);
            }
            // End If

        }

        private void LoadProfileSettings(bool echo = true)
        {
            if (Utility.CreateDirectory(m_oGlobals.Config.ConfigProfileDir))
            {
                if (echo)
                {
                    string argsText = "Loading Variables...";
                    var argoColor = Color.WhiteSmoke;
                    var argoBgColor = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow = "";
                    AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
                }

                m_oGlobals.VariableList.ClearUser();
                m_oGlobals.VariableList.Load(m_oGlobals.Config.ConfigProfileDir + @"\variables.cfg");
                if (echo)
                {
                    string argsText1 = "OK" + Constants.vbNewLine;
                    var argoColor1 = Color.WhiteSmoke;
                    var argoBgColor1 = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow1 = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow1 = "";
                    AddText(argsText1, argoColor1, argoBgColor1, oTargetWindow: argoTargetWindow1, sTargetWindow: argsTargetWindow1);
                }

                if (echo)
                {
                    string argsText2 = "Loading Macros...";
                    var argoColor2 = Color.WhiteSmoke;
                    var argoBgColor2 = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow2 = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow2 = "";
                    AddText(argsText2, argoColor2, argoBgColor2, oTargetWindow: argoTargetWindow2, sTargetWindow: argsTargetWindow2);
                }

                m_oGlobals.MacroList.Clear();
                m_oGlobals.MacroList.Load(m_oGlobals.Config.ConfigDir + @"\macros.cfg"); // Load default macros
                m_oGlobals.MacroList.Load(m_oGlobals.Config.ConfigProfileDir + @"\macros.cfg");
                if (echo)
                {
                    string argsText3 = "OK" + Constants.vbNewLine;
                    var argoColor3 = Color.WhiteSmoke;
                    var argoBgColor3 = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow3 = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow3 = "";
                    AddText(argsText3, argoColor3, argoBgColor3, oTargetWindow: argoTargetWindow3, sTargetWindow: argsTargetWindow3);
                }

                if (echo)
                {
                    string argsText4 = "Loading Aliases...";
                    var argoColor4 = Color.WhiteSmoke;
                    var argoBgColor4 = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow4 = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow4 = "";
                    AddText(argsText4, argoColor4, argoBgColor4, oTargetWindow: argoTargetWindow4, sTargetWindow: argsTargetWindow4);
                }

                m_oGlobals.AliasList.Clear();
                m_oGlobals.AliasList.Load(m_oGlobals.Config.ConfigDir + @"\aliases.cfg"); // Load default aliases
                m_oGlobals.AliasList.Load(m_oGlobals.Config.ConfigProfileDir + @"\aliases.cfg");
                if (echo)
                {
                    string argsText5 = "OK" + Constants.vbNewLine;
                    var argoColor5 = Color.WhiteSmoke;
                    var argoBgColor5 = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow5 = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow5 = "";
                    AddText(argsText5, argoColor5, argoBgColor5, oTargetWindow: argoTargetWindow5, sTargetWindow: argsTargetWindow5);
                }

                if (echo)
                {
                    string argsText6 = "Loading Classes...";
                    var argoColor6 = Color.WhiteSmoke;
                    var argoBgColor6 = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow6 = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow6 = "";
                    AddText(argsText6, argoColor6, argoBgColor6, oTargetWindow: argoTargetWindow6, sTargetWindow: argsTargetWindow6);
                }

                m_oGlobals.ClassList.Clear();
                m_oGlobals.ClassList.Load(m_oGlobals.Config.ConfigProfileDir + @"\classes.cfg");
                if (m_oGame.AccountCharacter.Length > 0)
                {
                    if (!m_oGlobals.ClassList.ContainsKey(m_oGame.AccountCharacter.ToLower()))
                    {
                        string argsValue = Conversions.ToString(true);
                        m_oGlobals.ClassList.Add(m_oGame.AccountCharacter.ToLower(), argsValue);
                    }
                }

                if (m_oGame.AccountGame.Length > 0)
                {
                    if (!m_oGlobals.ClassList.ContainsKey(m_oGame.AccountGame.ToLower()))
                    {
                        string argsValue1 = Conversions.ToString(true);
                        m_oGlobals.ClassList.Add(m_oGame.AccountGame.ToLower(), argsValue1);
                    }
                }

                if (echo)
                {
                    string argsText7 = "OK" + Constants.vbNewLine;
                    var argoColor7 = Color.WhiteSmoke;
                    var argoBgColor7 = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow7 = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow7 = "";
                    AddText(argsText7, argoColor7, argoBgColor7, oTargetWindow: argoTargetWindow7, sTargetWindow: argsTargetWindow7);
                }
            }
        }

        private string m_sCurrentProfileName = string.Empty;

        private void Command_SaveProfile()
        {
            if (m_sCurrentProfileName.Length > 0)
            {
                SaveProfile(m_sCurrentProfileName);
                string sProfile = m_sCurrentProfileName.Substring(m_sCurrentProfileName.LastIndexOf(@"\") + 1).Replace(".xml", "");
                m_oGlobals.Config.sConfigDirProfile = m_oGlobals.Config.ConfigDir + @"\Profiles\" + sProfile;
                LoadProfileSettings(false);
            }
            else
            {
                string argsText = "Unknown character or game name. Save profile failed." + Constants.vbNewLine;
                Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                AddText(argsText, oTargetWindow: argoTargetWindow);
            }
        }

        private bool SaveProfile(string FileName = null)
        {
            if (m_oProfile.GetValue("Genie/Profile", "Account", string.Empty).Length == 0)
            {
                m_oProfile.LoadXml("<Genie><Profile></Profile></Genie>");
            }

            m_oProfile.SetValue("Genie/Profile", "Account", m_oGame.AccountName);
            if (SavePasswordToolStripMenuItem.Checked == true)
            {
                string argsPassword = "G3" + m_oGame.AccountName.ToUpper();
                string argsText = m_oGame.AccountPassword;
                m_oProfile.SetValue("Genie/Profile", "Password", Utility.EncryptString(argsPassword, argsText));
            }
            else
            {
                m_oProfile.SetValue("Genie/Profile", "Password", "");
            }

            m_oProfile.SetValue("Genie/Profile", "Character", m_oGame.AccountCharacter);
            m_oProfile.SetValue("Genie/Profile", "Game", m_oGame.AccountGame);
            string sLayout = m_oConfig.ConfigFile;
            if (sLayout.Contains(m_oGlobals.Config.ConfigDir))
            {
                sLayout = sLayout.Substring(sLayout.LastIndexOf(@"\") + 1);
            }

            m_oProfile.SetValue("Genie/Profile/Layout", "FileName", sLayout);
            m_sCurrentProfileFile = FileName;
            if (Information.IsNothing(FileName))
            {
                return m_oProfile.SaveToFile();
            }
            else
            {
                if (FileName.IndexOf(@"\") == -1)
                {
                    FileName = m_oGlobals.Config.ConfigDir + @"\Profiles\" + FileName;
                }

                return m_oProfile.SaveToFile(FileName);
            }
        }

        private void LoadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialogProfile.InitialDirectory = LocalDirectory.Path + @"\Config\Profiles";
            if (OpenFileDialogProfile.ShowDialog() == DialogResult.OK)
            {
                m_sCurrentProfileName = OpenFileDialogProfile.FileName;
                LoadProfile(m_sCurrentProfileName);
            }
        }

        private void SaveProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_sCurrentProfileName.Length > 0)
            {
                Command_SaveProfile();
            }
            else
            {
                Interaction.MsgBox("Unknown character and game. Could not save profile.");
            }
        }

        private void SavePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SavePasswordToolStripMenuItem.Checked)
            {
                Interaction.MsgBox("Using this option will save your password so that anyone with access to your computer and/or files may connect to your character.", MsgBoxStyle.Exclamation, "CAUTION!");
            }
        }

        private void FormSkin_LinkClicked(string link)
        {
            if (link.IndexOf("#") > -1)
            {
                string sLink = link.Substring(link.IndexOf("#") + 1);
                TextBoxInput_SendText(m_oGlobals.ParseGlobalVars(sLink));
                TextBoxInput.Focus();
            }
        }

        private void FormMain_SizeChange(object sender, EventArgs e)
        {
            if (m_bIsLoading)
                return;
            if (WindowState == FormWindowState.Maximized)
            {
                if (LoadSizedXMLConfig(m_sConfigFile))
                {
                    UpdateLayoutMenu();
                    HideOutputForms();
                    ShowOutputForms();
                    ShowForm(m_oOutputMain);
                }
            }
        }

        private bool LoadSizedXMLConfig(string filename)
        {
            if (filename.Length > 0)
            {
                string sFile = SetSizeName(filename);
                if (File.Exists(sFile))
                {
                    return LoadXMLConfig(sFile);
                }
            }

            return false;
        }

        public bool SaveSizedXMLConfig(string filename)
        {
            if (filename.Length > 0)
            {
                string sFile = SetSizeName(filename);
                return SaveXMLConfig(sFile);
            }

            return false;
        }

        private bool LoadSizedProfileXMLConfig()
        {
            if (!Information.IsNothing(m_oProfile) && Conversions.ToInteger(m_oProfile.HasData) > 0)
            {
                string sConfig = m_oProfile.GetValue("Genie/Profile/Layout", "FileName", string.Empty);
                return LoadSizedXMLConfig(sConfig);
            }

            return false;
        }

        private string SetSizeName(string filepath)
        {
            int I = filepath.LastIndexOf('.');
            var sb = new StringBuilder();
            if (I > -1)
            {
                sb.Append(filepath.Substring(0, I));
                sb.Append(Width);
                sb.Append("x");
                sb.Append(Height);
                sb.Append(filepath.Substring(I));
            }

            return sb.ToString();
        }

        private void OpenUserDataDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Interaction.Shell("explorer.exe " + LocalDirectory.Path, AppWinStyle.NormalFocus, false);
        }

        private void SaveSizedDefaultLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveSizedXMLConfig(m_sConfigFile))
            {
                if (m_oOutputMain.Visible)
                {
                    string argsText = "Layout Saved: " + SetSizeName(m_sConfigFile) + Constants.vbNewLine;
                    var argoColor = Color.WhiteSmoke;
                    var argoBgColor = Color.Transparent;
                    Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
                    string argsTargetWindow = "";
                    AddText(argsText, argoColor, argoBgColor, oTargetWindow: argoTargetWindow, sTargetWindow: argsTargetWindow);
                }
            }
        }

        private void Command_RawToggle(string sToggle)
        {
            if (string.IsNullOrEmpty(sToggle))
            {
                m_oGame.ShowRawOutput = !m_oGame.ShowRawOutput;
            }
            else if ((sToggle.ToLower().Trim() ?? "") == "off")
            {
                m_oGame.ShowRawOutput = false;
            }
            else if ((sToggle.ToLower().Trim() ?? "") == "on")
            {
                m_oGame.ShowRawOutput = true;
            }

            string argsText = "Show Xml Output = " + m_oGame.ShowRawOutput.ToString() + Constants.vbNewLine;
            Genie.Game.WindowTarget argoTargetWindow = Genie.Game.WindowTarget.Main;
            AddText(argsText, oTargetWindow: argoTargetWindow);
        }

        private void Command_ChangeIcon(string sPath)
        {
            SafeChangeIcon(sPath);
        }

        private void ChangeIcon(string sPath)
        {
            if (!sPath.Contains(@"\"))
            {
                sPath = Path.Combine(LocalDirectory.Path, sPath);
            }

            if (File.Exists(sPath))
            {
                Icon = new Icon(sPath);
            }
        }

        public delegate void ChangeIconDelegate(string sPath);

        public void SafeChangeIcon(string sPath)
        {
            if (InvokeRequired == true)
            {
                var parameters = new[] { sPath };
                Invoke(new ChangeIconDelegate(ChangeIcon), parameters);
            }
            else
            {
                ChangeIcon(sPath);
            }
        }
    }
}