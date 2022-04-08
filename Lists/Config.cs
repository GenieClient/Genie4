using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie
{
    public class Config
    {
        public char m_cScriptChar = '.';
        public char cSeparatorChar = ';';
        public char cCommandChar = '#';
        public char cQuickSendChar = '-';
        public int iTypeAhead = 2;
        public char cMyCommandChar = '/'; // For trigger systems and such. Will be parsed but not sent to game.
        public int iArgumentCount = 15;
        public bool bTriggerOnInput = true;
        public int iBufferLineSize = 5;
        public bool bShowSpellTimer = true;
        public bool bAutoLog = true;
        public string sEditor = "notepad.exe";
        public string sPrompt = "> ";
        public string sIgnoreMonsterList = "appears dead|(dead)";
        public int iScriptTimeout = 5000;
        public int iMaxGoSubDepth = 50;
        public bool bReconnect = true;
        public bool bReconnectWhenDead = false;
        public bool bIgnoreScriptWarnings = false;
        public bool bIgnoreCloseAlert = false;
        public bool bGagsEnabled = true;
        public bool bKeepInput = false;
        public bool bPlaySounds = true;
        public bool bAbortDupeScript = true;
        public bool bParseGameOnly = false;
        public bool bAutoMapper = true;
        public int iServerActivityTimeout = 180;
        public string sServerActivityCommand = "fatigue";
        public int iUserActivityTimeout = 300;
        public string sUserActivityCommand = "quit";
        public double dRTOffset = 0;
        public string sScriptDir = "Scripts";
        public string sPluginDir = "Plugins";
        public string sMapDir = "Maps";
        public string sConfigDir = "Config";
        public string sConfigDirProfile = "Config";
        public bool bShowLinks = false;
        public string sLogDir = "Logs";

        public bool PromptBreak { get; set; } = true;
        public bool PromptForce { get; set; } = false;
        public bool Condensed { get; set; } = false;
        public bool CheckForUpdates { get; set; } = true;
        public bool AutoUpdate { get; set; } = false;

        public string sConnectString = "FE:GENIE /VERSION:" + My.MyProject.Application.Info.Version.ToString() + " /P:WIN_XP /XML";
        public int[] iPickerColors = new int[17];
        public string RubyPath { get; set; } = @"C:\ruby4lich\bin\ruby.exe";
        public string CmdPath { get; set; } = @"C:\Windows\System32\cmd.exe";
        public string LichPath { get; set; } = @"c:\ruby4lich\lich\lich.rbw";
        public string LichArguments { get; set; } = @"--genie --dragonrealms";
        public string LichServer { get; set; } = "localhost";
        public int LichPort { get; set; } = 11024;
        public int LichStartPause { get; set; } = 5;
        public string ConnectScript { get; set; } = string.Empty;

        public string ScriptDir
        {
            get
            {
                string sLocation = string.Empty;
                if (sScriptDir.Contains(":"))
                {
                    sLocation = sScriptDir;
                }
                else
                {
                    sLocation = LocalDirectory.Path;
                    if (sScriptDir.StartsWith(@"\") || sLocation.EndsWith(@"\"))
                    {
                        sLocation += sScriptDir;
                    }
                    else
                    {
                        sLocation += @"\" + sScriptDir;
                    }
                }

                return sLocation;
            }

            set
            {
                if (value.EndsWith(@"\"))
                {
                    value = value.Substring(0, value.Length - 1);
                }

                sScriptDir = value;
            }
        }

        public string MapDir
        {
            get
            {
                string sLocation = string.Empty;
                if (sMapDir.Contains(":"))
                {
                    sLocation = sMapDir;
                }
                else
                {
                    sLocation = LocalDirectory.Path;
                    if (sMapDir.StartsWith(@"\") || sLocation.EndsWith(@"\"))
                    {
                        sLocation += sMapDir;
                    }
                    else
                    {
                        sLocation += @"\" + sMapDir;
                    }
                }

                return sLocation;
            }

            set
            {
                if (value.EndsWith(@"\"))
                {
                    value = value.Substring(0, value.Length - 1);
                }

                sMapDir = value;
            }
        }

        public string PluginDir
        {
            get
            {
                string sLocation = string.Empty;
                if (sPluginDir.Contains(":"))
                {
                    sLocation = sPluginDir;
                }
                else
                {
                    sLocation = LocalDirectory.Path;
                    if (sPluginDir.StartsWith(@"\") || sLocation.EndsWith(@"\"))
                    {
                        sLocation += sPluginDir;
                    }
                    else
                    {
                        sLocation += @"\" + sPluginDir;
                    }
                }

                return sLocation;
            }

            set
            {
                if (value.EndsWith(@"\"))
                {
                    value = value.Substring(0, value.Length - 1);
                }

                sPluginDir = value;
            }
        }

        public int[] PickerColors
        {
            get
            {
                if (iPickerColors[0] == 0)
                {
                    iPickerColors[0] = ColorCode.ColorToColorref(Color.DimGray);
                    iPickerColors[1] = ColorCode.ColorToColorref(Color.DarkRed);
                    iPickerColors[2] = ColorCode.ColorToColorref(Color.Green);
                    iPickerColors[3] = ColorCode.ColorToColorref(Color.Olive);
                    iPickerColors[4] = ColorCode.ColorToColorref(Color.DarkBlue);
                    iPickerColors[5] = ColorCode.ColorToColorref(Color.Purple);
                    iPickerColors[6] = ColorCode.ColorToColorref(Color.DarkCyan);
                    iPickerColors[7] = ColorCode.ColorToColorref(Color.Silver);
                    iPickerColors[8] = ColorCode.ColorToColorref(Color.Gray);
                    iPickerColors[9] = ColorCode.ColorToColorref(Color.Red);
                    iPickerColors[10] = ColorCode.ColorToColorref(Color.Lime);
                    iPickerColors[11] = ColorCode.ColorToColorref(Color.Yellow);
                    iPickerColors[12] = ColorCode.ColorToColorref(Color.Blue);
                    iPickerColors[13] = ColorCode.ColorToColorref(Color.Magenta);
                    iPickerColors[14] = ColorCode.ColorToColorref(Color.Cyan);
                    iPickerColors[15] = ColorCode.ColorToColorref(Color.WhiteSmoke);
                }

                return iPickerColors;
            }

            set
            {
                iPickerColors = value;
            }
        }

        public string ConfigDir
        {
            get
            {
                string sLocation = string.Empty;
                if (sConfigDir.Contains(":"))
                {
                    sLocation = sConfigDir;
                }
                else
                {
                    sLocation = LocalDirectory.Path;
                    if (sConfigDir.StartsWith(@"\") || sLocation.EndsWith(@"\"))
                    {
                        sLocation += sConfigDir;
                    }
                    else
                    {
                        sLocation += @"\" + sConfigDir;
                    }
                }

                return sLocation;
            }

            set
            {
                if (value.EndsWith(@"\"))
                {
                    value = value.Substring(0, value.Length - 1);
                }

                sConfigDir = value;
            }
        }

        public string ConfigProfileDir
        {
            get
            {
                string sLocation = string.Empty;
                if (sConfigDirProfile.Contains(":"))
                {
                    sLocation = sConfigDirProfile;
                }
                else
                {
                    sLocation = LocalDirectory.Path;
                    if (sConfigDirProfile.StartsWith(@"\") || sLocation.EndsWith(@"\"))
                    {
                        sLocation += sConfigDirProfile;
                    }
                    else
                    {
                        sLocation += @"\" + sConfigDirProfile;
                    }
                }

                return sLocation;
            }
        }

        public char ScriptChar
        {
            get
            {
                return m_cScriptChar;
            }

            set
            {
                m_cScriptChar = value;
            }
        }

        public Font m_oMonoFont = new Font("Courier New", 9, FontStyle.Regular);
        public Font m_oInputFont = new Font("Courier New", 9, FontStyle.Regular);

        public event ConfigChangedEventHandler ConfigChanged;

        public delegate void ConfigChangedEventHandler(ConfigFieldUpdated oField);

        public enum ConfigFieldUpdated
        {
            MonoFont,
            InputFont,
            Reconnect,
            Autolog,
            KeepInput,
            Muted,
            AutoMapper,
            LogDir,
            CheckForUpdates,
            AutoUpdate
        }

        public Font MonoFont
        {
            get
            {
                return m_oMonoFont;
            }

            set
            {
                m_oMonoFont = value;
                ConfigChanged?.Invoke(ConfigFieldUpdated.MonoFont);
            }
        }

        public Font InputFont
        {
            get
            {
                return m_oInputFont;
            }

            set
            {
                m_oInputFont = value;
                ConfigChanged?.Invoke(ConfigFieldUpdated.InputFont);
            }
        }

        public bool Save(string sFileName = "settings.cfg")
        {
            try
            {
                if (sFileName.IndexOf(@"\") == -1)
                {
                    sFileName = ConfigDir + @"\" + sFileName;
                }

                if (File.Exists(sFileName))
                {
                    Utility.DeleteFile(sFileName);
                }

                var oStreamWriter = new StreamWriter(sFileName, false);
                oStreamWriter.WriteLine("#config {scriptchar} {" + ScriptChar + "}");
                oStreamWriter.WriteLine("#config {separatorchar} {" + cSeparatorChar + "}");
                oStreamWriter.WriteLine("#config {commandchar} {" + cCommandChar + "}");
                oStreamWriter.WriteLine("#config {mycommandchar} {" + cMyCommandChar + "}");
                oStreamWriter.WriteLine("#config {triggeroninput} {" + bTriggerOnInput.ToString() + "}");
                oStreamWriter.WriteLine("#config {maxrowbuffer} {" + iBufferLineSize + "}");
                oStreamWriter.WriteLine("#config {spelltimer} {" + bShowSpellTimer + "}");
                oStreamWriter.WriteLine("#config {autolog} {" + bAutoLog + "}");
                oStreamWriter.WriteLine("#config {editor} {" + sEditor + "}");
                oStreamWriter.WriteLine("#config {prompt} {" + sPrompt + "}");
                oStreamWriter.WriteLine("#config {promptbreak} {" + PromptBreak + "}");
                oStreamWriter.WriteLine("#config {promptforce} {" + PromptForce + "}");
                oStreamWriter.WriteLine("#config {condensed} {" + Condensed + "}");
                oStreamWriter.WriteLine("#config {monstercountignorelist} {" + sIgnoreMonsterList + "}");
                oStreamWriter.WriteLine("#config {scripttimeout} {" + iScriptTimeout + "}");
                oStreamWriter.WriteLine("#config {maxgosubdepth} {" + iMaxGoSubDepth + "}");
                oStreamWriter.WriteLine("#config {ignorescriptwarnings} {" + bIgnoreScriptWarnings + "}");
                oStreamWriter.WriteLine("#config {roundtimeoffset} {" + dRTOffset + "}");
                oStreamWriter.WriteLine("#config {scriptdir} {" + sScriptDir + "}");
                oStreamWriter.WriteLine("#config {mapdir} {" + sMapDir + "}");
                oStreamWriter.WriteLine("#config {plugindir} {" + sPluginDir + "}");
                oStreamWriter.WriteLine("#config {configdir} {" + sConfigDir + "}");
                oStreamWriter.WriteLine("#config {logdir} {" + sLogDir + "}");
                oStreamWriter.WriteLine("#config {reconnect} {" + bReconnect + "}");
                oStreamWriter.WriteLine("#config {ignoreclosealert} {" + bIgnoreCloseAlert + "}");
                oStreamWriter.WriteLine("#config {keepinputtext} {" + bKeepInput + "}");
                oStreamWriter.WriteLine("#config {muted} {" + !bPlaySounds + "}");
                oStreamWriter.WriteLine("#config {abortdupescript} {" + bAbortDupeScript + "}");
                oStreamWriter.WriteLine("#config {parsegameonly} {" + bParseGameOnly + "}");
                oStreamWriter.WriteLine("#config {connectstring} {" + sConnectString + "}");
                oStreamWriter.WriteLine("#config {servertimeout} {" + iServerActivityTimeout + "}");
                oStreamWriter.WriteLine("#config {servertimeoutcommand} {" + sServerActivityCommand + "}");
                oStreamWriter.WriteLine("#config {usertimeout} {" + iUserActivityTimeout + "}");
                oStreamWriter.WriteLine("#config {usertimeoutcommand} {" + sUserActivityCommand + "}");
                oStreamWriter.WriteLine("#config {showlinks} {" + bShowLinks + "}");
                oStreamWriter.WriteLine($"#config {{rubypath}} {{{RubyPath}}}");
                oStreamWriter.WriteLine($"#config {{cmdpath}} {{{CmdPath}}}");
                oStreamWriter.WriteLine($"#config {{lichpath}} {{{LichPath}}}");
                oStreamWriter.WriteLine($"#config {{licharguments}} {{{LichArguments}}}");
                oStreamWriter.WriteLine($"#config {{lichserver}} {{{LichServer}}}");
                oStreamWriter.WriteLine($"#config {{lichport}} {{{LichPort}}}");
                oStreamWriter.WriteLine($"#config {{lichstartpause}} {{{LichStartPause}}}");
                oStreamWriter.WriteLine($"#config {{connectscript}} {{{ConnectScript}}}");
                oStreamWriter.WriteLine($"#config {{autoupdate}} {{{AutoUpdate}}}");
                oStreamWriter.WriteLine($"#config {{checkforupdates}} {{{CheckForUpdates}}}");
                oStreamWriter.Close();
                return true;
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                return false;
            }
        }

        public bool Load(string sFileName = "settings.cfg")
        {
            if (sFileName.IndexOf(@"\") == -1)
            {
                sFileName = ConfigDir + @"\" + sFileName;
            }

            if (File.Exists(sFileName) == true)
            {
                var oStreamReader = new StreamReader(sFileName);
                string strLine = oStreamReader.ReadLine();
                while (!Information.IsNothing(strLine))
                {
                    var oArgs = Utility.ParseArgs(strLine);
                    if (oArgs.Count == 3)
                    {
                        try
                        {
                            SetSetting(oArgs[1].ToString(), oArgs[2].ToString(), false);
                        }
                        catch
                        {
                           //Settings! We got bad settings here! See? No one cares.
                        }
                    }

                    strLine = oStreamReader.ReadLine();
                }

                oStreamReader.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> SetSetting(string sKey, string sValue = "", bool bShowException = true)
        {
            try 
            { 
                List<string> messages = new List<string>();
                if (sKey.Length > 0)
                {
                    var switchExpr = sKey.ToLower();
                    switch (switchExpr)
                    {
                        case "scriptchar":
                            {
                                if (sValue.Length > 0)
                                {
                                    ScriptChar = Conversions.ToChar(sValue.ToCharArray().GetValue(0));
                                }

                                break;
                            }

                        case "triggeroninput":
                            {
                                var switchExpr1 = sValue.ToLower();
                                switch (switchExpr1)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bTriggerOnInput = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bTriggerOnInput = false;
                                            break;
                                        }
                                }

                                break;
                            }

                        case "separatorchar":
                            {
                                if (sValue.Length > 0)
                                {
                                    cSeparatorChar = Conversions.ToChar(sValue.ToCharArray().GetValue(0));
                                }

                                break;
                            }

                        case "commandchar":
                            {
                                if (sValue.Length > 0)
                                {
                                    cCommandChar = Conversions.ToChar(sValue.ToCharArray().GetValue(0));
                                }

                                break;
                            }

                        case "mycommandchar":
                            {
                                if (sValue.Length > 0)
                                {
                                    cMyCommandChar = Conversions.ToChar(sValue.ToCharArray().GetValue(0));
                                }

                                break;
                            }

                        case "maxrowbuffer":
                            {
                                if (sValue.Length > 0)
                                {
                                    iBufferLineSize = Utility.StringToInteger(sValue);
                                }

                                break;
                            }

                        case "spelltimer":
                            {
                                var switchExpr2 = sValue.ToLower();
                                switch (switchExpr2)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bShowSpellTimer = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bShowSpellTimer = false;
                                            break;
                                        }
                                }

                                break;
                            }

                        case "autolog":
                            {
                                var switchExpr3 = sValue.ToLower();
                                switch (switchExpr3)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bAutoLog = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bAutoLog = false;
                                            break;
                                        }
                                }

                                ConfigChanged?.Invoke(ConfigFieldUpdated.Autolog);
                                break;
                            }

                        case "editor":
                            {
                                if (File.Exists(sValue) == true)
                                {
                                    sEditor = sValue;
                                }
                                else if (bShowException)
                                {
                                    throw new Exception("Directory does not exist: " + sValue);
                                }

                                break;
                            }

                        case "scripttimeout":
                            {
                                if (sValue.Length > 0)
                                {
                                    iScriptTimeout = Conversions.ToInteger(Utility.StringToDouble(sValue));
                                }

                                break;
                            }

                        case "servertimeout":
                            {
                                if (sValue.Length > 0)
                                {
                                    iServerActivityTimeout = Conversions.ToInteger(Utility.StringToDouble(sValue));
                                }

                                break;
                            }

                        case "usertimeout":
                            {
                                if (sValue.Length > 0)
                                {
                                    iUserActivityTimeout = Conversions.ToInteger(Utility.StringToDouble(sValue));
                                }

                                break;
                            }

                        case "servertimeoutcommand":
                            {
                                if (sValue.Length > 0)
                                {
                                    sServerActivityCommand = sValue;
                                }

                                break;
                            }

                        case "usertimeoutcommand":
                            {
                                if (sValue.Length > 0)
                                {
                                    sUserActivityCommand = sValue;
                                }

                                break;
                            }

                        case "prompt":
                            {
                                var switchExpr4 = sValue.ToLower();
                                switch (switchExpr4)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            sPrompt = "> ";
                                            break;
                                        }

                                    case "off":
                                    case "false":
                                    case "0":
                                        {
                                            sPrompt = string.Empty;
                                            break;
                                        }

                                    default:
                                        {
                                            sPrompt = sValue;
                                            break;
                                        }
                                }

                                break;
                            }

                        case "promptbreak":
                            {
                                switch (sValue.ToLower())
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            PromptBreak = true;
                                            break;
                                        }

                                    default:
                                        {
                                            PromptBreak = false;
                                            break;
                                        }
                                }
                                break;
                            }
                        case "promptforce":
                            {
                                switch (sValue.ToLower())
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            PromptForce = true;
                                            break;
                                        }

                                    default:
                                        {
                                            PromptForce = false;
                                            break;
                                        }
                                }
                                break;
                            }
                        case "condensed":
                            {
                                switch (sValue.ToLower())
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            Condensed = true;
                                            break;
                                        }

                                    default:
                                        {
                                            Condensed = false;
                                            break;
                                        }
                                }
                                break;
                            }

                        case "monstercountignorelist":
                            {
                                if (sValue.Length > 0)
                                {
                                    sIgnoreMonsterList = sValue;
                                }

                                break;
                            }

                        case "maxgosubdepth":
                            {
                                if (sValue.Length > 0)
                                {
                                    iMaxGoSubDepth = Conversions.ToInteger(sValue);
                                }

                                break;
                            }

                        case "roundtimeoffset":
                            {
                                if (sValue.Length > 0)
                                {
                                    dRTOffset = Utility.StringToDouble(sValue);
                                }

                                break;
                            }

                        case "scriptdir":
                            {

                                messages.Add(LocalDirectory.ValidateDirectory(sValue));
                                ScriptDir = sValue;
                                break;
                            }

                        case "mapdir":
                            {
                                messages.Add(LocalDirectory.ValidateDirectory(sValue));
                                MapDir = sValue;
                                break;
                            }

                        case "plugindir":
                            {
                                messages.Add(LocalDirectory.ValidateDirectory(sValue));
                                PluginDir = sValue;
                                break;
                            }

                        case "configdir":
                            {
                                messages.Add(LocalDirectory.ValidateDirectory(sValue));
                                ConfigDir = sValue;
                                break;
                            }

                        case "logdir":
                            {
                                messages.Add(LocalDirectory.ValidateDirectory(sValue));
                                sLogDir = sValue;

                                ConfigChanged?.Invoke(ConfigFieldUpdated.LogDir);
                                break;
                            }

                        case "ignorescriptwarnings":
                            {
                                var switchExpr5 = sValue.ToLower();
                                switch (switchExpr5)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bIgnoreScriptWarnings = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bIgnoreScriptWarnings = false;
                                            break;
                                        }
                                }

                                break;
                            }

                        case "reconnect":
                            {
                                var switchExpr6 = sValue.ToLower();
                                switch (switchExpr6)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bReconnect = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bReconnect = false;
                                            break;
                                        }
                                }

                                ConfigChanged?.Invoke(ConfigFieldUpdated.Reconnect);
                                break;
                            }

                        case "ignoreclosealert":
                            {
                                var switchExpr7 = sValue.ToLower();
                                switch (switchExpr7)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bIgnoreCloseAlert = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bIgnoreCloseAlert = false;
                                            break;
                                        }
                                }

                                break;
                            }

                        case "muted":
                            {
                                var switchExpr8 = sValue.ToLower();
                                switch (switchExpr8)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bPlaySounds = false;
                                            break;
                                        }

                                    default:
                                        {
                                            bPlaySounds = true;
                                            break;
                                        }
                                }

                                ConfigChanged?.Invoke(ConfigFieldUpdated.Muted);
                                break;
                            }

                        case "keepinputtext":
                            {
                                var switchExpr9 = sValue.ToLower();
                                switch (switchExpr9)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bKeepInput = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bKeepInput = false;
                                            break;
                                        }
                                }

                                ConfigChanged?.Invoke(ConfigFieldUpdated.KeepInput);
                                break;
                            }

                        case "abortdupescript":
                            {
                                var switchExpr10 = sValue.ToLower();
                                switch (switchExpr10)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bAbortDupeScript = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bAbortDupeScript = false;
                                            break;
                                        }
                                }

                                break;
                            }

                        case "parsegameonly":
                            {
                                var switchExpr11 = sValue.ToLower();
                                switch (switchExpr11)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bParseGameOnly = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bParseGameOnly = false;
                                            break;
                                        }
                                }

                                break;
                            }

                        case "autoupdate":
                            {
                                var expression = sValue.ToLower();
                                switch (expression)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            AutoUpdate = true;
                                            break;
                                        }

                                    default:
                                        {
                                            AutoUpdate = false;
                                            break;
                                        }
                                }
                                ConfigChanged?.Invoke(ConfigFieldUpdated.AutoUpdate);
                                break;
                            }

                        case "checkforupdates":
                            {
                                var expression = sValue.ToLower();
                                switch (expression)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            CheckForUpdates = true;
                                            break;
                                        }

                                    default:
                                        {
                                            CheckForUpdates = false;
                                            break;
                                        }
                                }
                                ConfigChanged?.Invoke(ConfigFieldUpdated.CheckForUpdates);
                                break;
                            }

                        case "connectstring":
                            {
                                if (sValue.Length > 0)
                                {
                                    // sConnectString = sValue
                                }

                                break;
                            }

                        case "cmdpath":
                            {
                                if (!string.IsNullOrEmpty(sValue)) CmdPath = @$"{sValue}";
                                break;
                            }

                        case "rubypath":
                            {
                                if (!string.IsNullOrEmpty(sValue)) RubyPath = @$"{sValue}";
                                break;
                            }

                        case "lichpath":
                            {
                                if (!string.IsNullOrEmpty(sValue)) LichPath = @$"{sValue}";
                                break;
                            }

                        case "licharguments":
                            {
                                if (!string.IsNullOrEmpty(sValue)) LichArguments = @$"{sValue}";
                                break;
                            }

                        case "lichstartpause":
                            {
                                if (!string.IsNullOrEmpty(sValue)) LichStartPause = Convert.ToInt32(sValue);
                                break;
                            }

                        case "lichserver":
                            {
                                if (!string.IsNullOrEmpty(sValue)) LichServer = @$"{sValue}";
                                break;
                            }

                        case "lichport":
                            {
                                if (!string.IsNullOrEmpty(sValue)) LichPort = Convert.ToInt32(sValue);
                                break;
                            }

                        case "connectscript":
                            {
                                ConnectScript = sValue.ToString();
                                break;
                            }
                        case "automapper":
                            {
                                var switchExpr12 = sValue.ToLower();
                                switch (switchExpr12)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bAutoMapper = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bAutoMapper = false;
                                            break;
                                        }
                                }

                                ConfigChanged?.Invoke(ConfigFieldUpdated.AutoMapper);
                                break;
                            }

                        case "showlinks":
                            {
                                var switchExpr13 = sValue.ToLower();
                                switch (switchExpr13)
                                {
                                    case "on":
                                    case "true":
                                    case "1":
                                        {
                                            bShowLinks = true;
                                            break;
                                        }

                                    default:
                                        {
                                            bShowLinks = false;
                                            break;
                                        }
                                }

                                break;
                            }
                        default:
                            throw new Exception($"Config {switchExpr} was not recognized.");
                    }
                    messages.Add($"Set {switchExpr}: {sValue}");
                    messages.Add("Don't forget to #save config");
                }
                return messages;
            }
            catch(Exception up)
            {
                throw up;
            }
        }
    }
}