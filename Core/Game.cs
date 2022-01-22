using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie
{
    public class Game
    {
        public Game()
        {
            m_oSocket = new Connection();
        }

        public Game(ref Globals cl)
        {
            m_oSocket = new Connection();
            m_oGlobals = cl;
        }

        public event EventPrintTextEventHandler EventPrintText;

        public delegate void EventPrintTextEventHandler(string text, Color color, Color bgcolor, WindowTarget targetwindow, string targetwindowstring, bool mono, bool isprompt, bool isinput);

        public event EventPrintErrorEventHandler EventPrintError;

        public delegate void EventPrintErrorEventHandler(string text);

        public event EventClearWindowEventHandler EventClearWindow;

        public delegate void EventClearWindowEventHandler(string sWindow);

        public event EventDataRecieveEndEventHandler EventDataRecieveEnd;

        public delegate void EventDataRecieveEndEventHandler();

        public event EventRoundTimeEventHandler EventRoundTime;

        public delegate void EventRoundTimeEventHandler(int time);

        public event EventCastTimeEventHandler EventCastTime;

        public delegate void EventCastTimeEventHandler();

        public event EventSpellTimeEventHandler EventSpellTime;

        public delegate void EventSpellTimeEventHandler();

        public event EventClearSpellTimeEventHandler EventClearSpellTime;

        public delegate void EventClearSpellTimeEventHandler();

        public event EventTriggerParseEventHandler EventTriggerParse;

        public delegate void EventTriggerParseEventHandler(string text);

        public event EventTriggerMoveEventHandler EventTriggerMove;

        public delegate void EventTriggerMoveEventHandler();

        public event EventTriggerPromptEventHandler EventTriggerPrompt;

        public delegate void EventTriggerPromptEventHandler();

        public event EventStatusBarUpdateEventHandler EventStatusBarUpdate;

        public delegate void EventStatusBarUpdateEventHandler();

        public event EventVariableChangedEventHandler EventVariableChanged;

        public delegate void EventVariableChangedEventHandler(string sVariable);

        public event EventParseXMLEventHandler EventParseXML;

        public delegate void EventParseXMLEventHandler(string xml);

        public event EventStreamWindowEventHandler EventStreamWindow;

        public delegate void EventStreamWindowEventHandler(object sID, object sTitle, object sIfClosed);

        private Connection _m_oSocket;

        private Connection m_oSocket
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_oSocket;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_oSocket != null)
                {
                    _m_oSocket.EventConnected -= GameSocket_EventConnected;
                    _m_oSocket.EventDisconnected -= GameSocket_EventDisconnected;
                    _m_oSocket.EventConnectionLost -= GameSocket_EventConnectionLost;

                    _m_oSocket.EventParseRow -= GameSocket_EventParseRow;
                    _m_oSocket.EventParsePartialRow -= GameSocket_EventParsePartialRow;
                    _m_oSocket.EventDataRecieveEnd -= GameSocket_EventDataRecieveEnd;

                    _m_oSocket.EventPrintText -= GameSocket_EventPrintText;
                    _m_oSocket.EventPrintError -= GameSocket_EventPrintError;
                }

                _m_oSocket = value;
                if (_m_oSocket != null)
                {
                    _m_oSocket.EventConnected += GameSocket_EventConnected;
                    _m_oSocket.EventDisconnected += GameSocket_EventDisconnected;
                    _m_oSocket.EventConnectionLost += GameSocket_EventConnectionLost;
                    _m_oSocket.EventParseRow += GameSocket_EventParseRow;
                    _m_oSocket.EventParsePartialRow += GameSocket_EventParsePartialRow;
                    _m_oSocket.EventDataRecieveEnd += GameSocket_EventDataRecieveEnd;
                    _m_oSocket.EventPrintText += GameSocket_EventPrintText;
                    _m_oSocket.EventPrintError += GameSocket_EventPrintError;
                }
            }
        }

        private Globals _m_oGlobals;

        private Globals m_oGlobals
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
                }

                _m_oGlobals = value;
                if (_m_oGlobals != null)
                {
                    GenieError.EventGenieError += HandleGenieException;
                }
            }
        }

        private bool m_bShowRawOutput = false;
        private string m_sEncryptionKey = string.Empty;
        private string m_sAccountOwner = string.Empty;
        private string m_sLoginKey = string.Empty;
        private string m_sAccountName = string.Empty;
        private string m_sAccountPassword = string.Empty;
        private string m_sAccountCharacter = string.Empty;
        private string m_sAccountGame = "DR"; // DR, DRX, DRF
        private string m_sConnectHost = string.Empty;
        private int m_sConnectPort = 0;
        private string m_sConnectKey = string.Empty;
        private string m_sGenieKey = string.Empty;
        private bool m_bLastRowWasBlank = false;
        private bool m_bBold = false;
        private string m_sStyle = string.Empty;
        private string m_sRoomDesc = string.Empty;
        private string m_sRoomObjs = string.Empty;
        private string m_sRoomPlayers = string.Empty;
        private string m_sRoomExits = string.Empty;
        private int m_iHealth = 100;
        private int m_iMana = 100;
        private int m_iSpirit = 100;
        private int m_iStamina = 100;
        private int m_iConcentration = 100;
        private int m_iEncumbrance = 0;
        private string m_sCharacterName = string.Empty;
        private string m_sGameName = string.Empty;
        private int m_iRoundTime = 0;
        private int m_iGameTime = 0;
        private string m_sTriggerBuffer = string.Empty;
        private bool m_bLastRowWasPrompt = false;
        private bool m_bUpdatingRoom = false;
        private bool m_bUpdateRoomOnStreamEnd = false;
        private string m_sRoomTitle = string.Empty;
        // private Match m_oRegMatch;
        private Hashtable m_oIndicatorHash = new Hashtable();
        private Hashtable m_oCompassHash = new Hashtable();
        private WindowTarget m_oTargetWindow = WindowTarget.Main;
        private string m_sTargetWindow = string.Empty;
        private bool m_bIgnoreXMLDepth = false;
        private ConnectStates m_oConnectState;
        private object m_oThreadLock = new object(); // Thread safety
        private bool m_bFamiliarLineParse = false;
        public bool IsLich = false;

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum WindowTarget
        {
            Unknown,
            Combat,
            Main,
            Inv,
            Familiar,
            Thoughts,
            Logons,
            Death,
            Room,
            Log,
            Raw,
            Debug,
            Other
        }

        private enum ConnectStates
        {
            Disconnected,
            ConnectingKeyServer,
            ConnectingGameServer,
            ConnectedKey,
            ConnectedGameHandshake,
            ConnectedGame
        }

        private enum Indicator
        {
            Kneeling,
            Prone,
            Sitting,
            Standing,
            Stunned,
            Hidden,
            Invisible,
            Dead,
            Webbed,
            Joined,
            Bleeding
        }

        private enum Direction
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest,
            Up,
            Down,
            Out
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private Hashtable m_oBanned = new Hashtable();

        public bool ShowRawOutput
        {
            get
            {
                return m_bShowRawOutput;
            }

            set
            {
                m_bShowRawOutput = value;
            }
        }

        public bool IsConnected
        {
            get
            {
                if (Information.IsNothing(m_oSocket))
                {
                    return false;
                }
                else
                {
                    return m_oSocket.IsConnected;
                }
            }
        }

        public bool LastRowWasPrompt
        {
            get
            {
                return m_bLastRowWasPrompt;
            }

            set
            {
                m_bLastRowWasPrompt = value;
            }
        }

        public DateTime LastServerActivity
        {
            get
            {
                return m_oSocket.LastServerActivity;
            }
        }

        private DateTime m_oLastUserActivity = DateTime.Now;

        public DateTime LastUserActivity
        {
            get
            {
                return m_oLastUserActivity;
            }
        }

        public string AccountName
        {
            get
            {
                return m_sAccountName;
            }

            set
            {
                m_sAccountName = value;
            }
        }

        public string AccountPassword
        {
            get
            {
                return m_sAccountPassword;
            }

            set
            {
                m_sAccountPassword = value;
            }
        }

        public string AccountCharacter
        {
            get
            {
                return m_sAccountCharacter;
            }

            set
            {
                m_sAccountCharacter = value;
            }
        }

        public string AccountGame
        {
            get
            {
                return m_sAccountGame;
            }

            set
            {
                m_sAccountGame = value;
            }
        }

        public void Connect(string sGenieKey, string sAccountName, string sPassword, string sCharacter, string sGame)
        {
            m_sAccountName = sAccountName;
            m_sAccountPassword = sPassword;
            m_sAccountCharacter = sCharacter;
            m_sAccountGame = sGame;
            m_oLastUserActivity = DateTime.Now;
            var accountName = m_sAccountName.ToUpper();

            m_oGlobals.VariableList["charactername"] = sCharacter;
            m_oGlobals.VariableList["game"] = sGame;
            string argsHostName = "eaccess.play.net";
            int argiPort = 7900;
            DoConnect(argsHostName, argiPort);
        }

        public void Disconnect(bool ExitOnDisconnect = false)
        {
            if (m_oSocket.IsConnected)
            {
                m_oSocket.Disconnect(ExitOnDisconnect);
            }
        }

        public void SendText(string sText, bool bUserInput = false, string sOrigin = "")
        {
            string sShowText = sText;
            if (!m_oSocket.IsConnected)
            {
                if (!sText.StartsWith(Conversions.ToString(m_oGlobals.Config.cMyCommandChar)))
                {
                    sShowText = "(" + sShowText + ")";
                }
            }
            else if (sText.StartsWith("qui", StringComparison.CurrentCultureIgnoreCase) | sText.StartsWith("exi", StringComparison.CurrentCultureIgnoreCase))
            {
                m_oReconnectTime = default;
                m_bManualDisconnect = true;
            }
            else if ((sText.ToLower() ?? "") == "set !statusprompt")
            {
                m_bStatusPromptEnabled = false;
            }

            bool bHideOutput = false;
            if (sOrigin.Length > 0)
            {
                // Gag List
                if (m_oGlobals.GagList.AcquireReaderLock())
                {
                    try
                    {
                        foreach (Globals.GagRegExp.Gag sl in m_oGlobals.GagList)
                        {
                            if (!Information.IsNothing(sl.RegexGag))
                            {
                                if (sl.RegexGag.Match(sOrigin).Success == true)
                                {
                                    bHideOutput = true;
                                    break;
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oGlobals.GagList.ReleaseReaderLock();
                    }
                }
                else
                {
                    GenieError.Error("SendText", "Unable to aquire reader lock.");
                }

                sShowText = "[" + sOrigin + "]: " + sShowText;
            }

            // Maybe not needed
            if (sOrigin.Equals("") && sShowText.Equals(""))
                sShowText = sText;

            if (bHideOutput == false)
            {
                Color color;
                Color bgcolor;
                if (bUserInput == true)
                {
                    color = m_oGlobals.PresetList["inputuser"].FgColor;
                    bgcolor = m_oGlobals.PresetList["inputuser"].BgColor;
                }
                else
                {
                    color = m_oGlobals.PresetList["inputother"].FgColor;
                    bgcolor = m_oGlobals.PresetList["inputother"].BgColor;
                }

                string argsText = sShowText + System.Environment.NewLine;
                PrintInputText(argsText, color, bgcolor);
            }

            if (!sText.StartsWith(Conversions.ToString(m_oGlobals.Config.cMyCommandChar))) // Skip user commands
            {
                m_oLastUserActivity = DateTime.Now;
                m_oSocket.Send("<c>" + sText + Constants.vbCrLf);
                m_oGlobals.VariableList["lastcommand"] = sText;
                var lastCommandVar = "lastcommand";
                EventVariableChanged?.Invoke(lastCommandVar);
            }

            if (m_oGlobals.Config.bAutoLog == true)
            {
                m_oGlobals.Log?.LogText(sShowText + System.Environment.NewLine, Conversions.ToString(m_oGlobals.VariableList["charactername"]), Conversions.ToString(m_oGlobals.VariableList["game"]));
            }
        }

        public void SendRaw(string text)
        {
            m_oSocket.Send(text);
        }

        private StringBuilder m_oXMLBuffer = new StringBuilder();

        public void ParseGameRow(string sText)
        {
            var oXMLBuffer = new StringBuilder();
            int iInsideXML = 0;
            bool bEndTagFound = false;
            bool bInsideHTMLTag = false;
            string sHTMLBuffer = string.Empty;
            string sTextBuffer = string.Empty;
            char cPreviousChar = Conversions.ToChar("");
            bool bCombatRow = false;

            // Fix for DR html encoding problems
            if (sText.StartsWith("< "))
            {
                sText = sText.Replace("< ", "&lt; ");
            }

            if (sText.StartsWith("> "))
            {
                sText = sText.Replace("> ", "&gt; ");
            }

            if (m_bShowRawOutput == true)
            {
                PrintTextToWindow(sText, Color.LightGray, Color.Black, WindowTarget.Raw);
            }

            foreach (char c in sText)
            {
                switch (c)
                {
                    case '<':
                        {
                            iInsideXML += 1;
                            oXMLBuffer.Append(c);
                            break;
                        }

                    case '>':
                        {
                            if (Conversions.ToString(cPreviousChar) == "/")	// End tag in same statement
                            {
                                iInsideXML -= 1;
                            }
                            else if (bEndTagFound == true)	// Jump two steps back if we found end tag
                            {
                                iInsideXML -= 2;
                                bEndTagFound = false;
                            }

                            oXMLBuffer.Append(c);
                            if (iInsideXML == 0)
                            {
                                m_oXMLBuffer.Append(oXMLBuffer);
                                string buffer = m_oXMLBuffer.ToString();
                                string sTmp = ProcessXML(buffer);
                                if (m_bBold)
                                {
                                    if (sTextBuffer.StartsWith("< ") | sTextBuffer.StartsWith("> ") | sTextBuffer.StartsWith("* "))
                                    {
                                        m_bBold = false;
                                        string argsText = sTextBuffer + System.Environment.NewLine;
                                        bool argbIsPrompt = false;
                                        WindowTarget argoWindowTarget = 0;
                                        PrintTextWithParse(argsText, bIsPrompt: argbIsPrompt, oWindowTarget: argoWindowTarget);
                                        m_bBold = true;
                                        sTextBuffer = string.Empty;
                                        bCombatRow = true;
                                    }
                                }

                                sTextBuffer += sTmp;
                                m_oXMLBuffer.Clear();
                                oXMLBuffer.Clear();
                            }

                            break;
                        }

                    case '/':
                        {
                            if (Conversions.ToString(cPreviousChar) == "<")	// End tag found
                            {
                                bEndTagFound = true;
                            }

                            if (iInsideXML > 0)
                            {
                                oXMLBuffer.Append(c);
                            }
                            else
                            {
                                sTextBuffer += Conversions.ToString(c);
                            }

                            break;
                        }

                    case '&':
                        {
                            bInsideHTMLTag = true;
                            sHTMLBuffer += Conversions.ToString(c);
                            break;
                        }

                    case ';':
                        {
                            if (bInsideHTMLTag == true)
                            {
                                sHTMLBuffer += Conversions.ToString(c);
                                if (iInsideXML > 0)
                                {
                                    oXMLBuffer.Append(sHTMLBuffer);
                                }
                                else
                                {
                                    sTextBuffer += Utility.TranslateHTMLChar(sHTMLBuffer);
                                }

                                sHTMLBuffer = string.Empty;
                                bInsideHTMLTag = false;
                            }

                            break;
                        }

                    case (char)28: // GSL. Skip rest of line.
                        {
                            break;
                        }

                    default:
                        {
                            if (bInsideHTMLTag == true)
                            {
                                sHTMLBuffer += Conversions.ToString(c);
                                if (sHTMLBuffer.Length > 6) // Abort
                                {
                                    if (iInsideXML > 0)
                                    {
                                        oXMLBuffer.Append(sHTMLBuffer.Replace("&", "&amp;"));
                                    }
                                    else
                                    {
                                        sTextBuffer += sHTMLBuffer;
                                    }

                                    sHTMLBuffer = string.Empty;
                                    bInsideHTMLTag = false;
                                }
                            }
                            else if (iInsideXML > 0)
                            {
                                oXMLBuffer.Append(c);
                            }
                            else
                            {
                                sTextBuffer += Conversions.ToString(c);
                            }

                            break;
                        }
                }

                cPreviousChar = c;
            }

            if (oXMLBuffer.Length > 0)
            {
                if (iInsideXML > 0)
                {
                    m_oXMLBuffer = oXMLBuffer;
                }
                else
                {
                    m_oXMLBuffer.Append(oXMLBuffer);
                    string buffer = m_oXMLBuffer.ToString();
                    sTextBuffer += ProcessXML(buffer);
                    m_oXMLBuffer.Clear();
                    oXMLBuffer.Clear();
                }
            }

            if (sTextBuffer.Length > 0)
            {
                if (bCombatRow == true)
                {
                    m_bBold = true;
                }

                // Fix for broke familiar XML
                if (m_bFamiliarLineParse)
                {
                    if (m_oTargetWindow == WindowTarget.Other)
                    {
                        sTextBuffer = "";
                    }
                    else
                    {
                        if (m_oTargetWindow == WindowTarget.Main)
                        {
                            m_oTargetWindow = WindowTarget.Familiar;
                        }

                        m_bFamiliarLineParse = false;
                    }
                }

                
                bool argbIsPrompt1 = false;
                WindowTarget argoWindowTarget1 = 0;
                PrintTextWithParse(sTextBuffer, bIsPrompt: argbIsPrompt1, oWindowTarget: argoWindowTarget1);
                if (bCombatRow == true)
                {
                    m_bBold = false;
                }
            }
        }

        private bool m_bIsParsingSettings = false;
        private bool m_bIsParsingSettingsStart = false;

        public string ProcessXML(string sXML)
        {
            string sReturn = string.Empty;
            if (sXML.Length == 0)
            {
                return sReturn;
            }

            if (m_bIsParsingSettings)
            {
                if (sXML.Contains("<sentSettings/>"))
                {
                    m_bIsParsingSettings = false;
                }

                if (sXML.Contains("<vars>"))
                {
                    int I = sXML.IndexOf("<vars>") + 6;
                    int J = sXML.IndexOf("</vars>");
                    sXML = sXML.Substring(I, J - I);
                }
                else
                {
                    return sReturn;
                }
            }
            else if (m_bIsParsingSettingsStart)
            {
                if (sXML.Contains("<settings "))
                {
                    m_bIsParsingSettingsStart = false;
                    m_bIsParsingSettings = true;
                    if (sXML.Contains("<vars>"))
                    {
                        int I = sXML.IndexOf("<vars>");
                        int J = sXML.IndexOf("</vars>") + 7;
                        sXML = sXML.Substring(I, J - I);
                        if (sXML.Length == 0)
                            return sReturn;
                    }
                    else
                    {
                        return sReturn;
                    }
                }
            }

            var oDocument = new XmlDocument();
            try
            {
                oDocument.LoadXml("<data>" + sXML + "</data>");
            }
#pragma warning disable CS0168
            catch (XmlException ex)
#pragma warning restore CS0168
            {
                /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                return sReturn;
            }

            XmlNode argoXmlNode = oDocument.DocumentElement;
            sReturn = ProcessXMLData(argoXmlNode);
            EventParseXML?.Invoke(sXML);
            return sReturn;
        }

        public void SetBufferEnd()
        {
            if (Monitor.TryEnter(m_oThreadLock))
            {
                try
                {
                    if (m_bUpdateRoomOnStreamEnd == true)
                    {
                        m_bUpdateRoomOnStreamEnd = false;
                        m_bUpdatingRoom = false;
                        UpdateRoom();
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                GenieError.Error("SetBufferEnd", "Unable to aquire game thread lock.");
            }
        }

        public void UpdateRoom()
        {
            if (Monitor.TryEnter(m_oThreadLock))
            {
                try
                {
                    if (m_bUpdatingRoom == false)
                    {
                        // ClearWindow(WindowTarget.Room)
                        WindowTarget targetRoom = WindowTarget.Room;
                        PrintTextToWindow("@suspend@", Color.Transparent, Color.Transparent, targetRoom, false, true);
                        if (Strings.Len(m_sRoomTitle) > 0)
                        {
                            string argsText = "[" + m_sRoomTitle + "]" + Constants.vbCrLf;
                            bool argbIsRoomOutput = true;
                            PrintTextWithParse(argsText, m_oGlobals.PresetList["roomname"].FgColor, m_oGlobals.PresetList["roomname"].BgColor, false, targetRoom, argbIsRoomOutput);
                        }
                        else
                        {
                            string argsText1 = "[Unknown Room]" + Constants.vbCrLf;
                            bool argbIsRoomOutput1 = true;
                            PrintTextWithParse(argsText1, m_oGlobals.PresetList["roomname"].FgColor, m_oGlobals.PresetList["roomname"].BgColor, false, targetRoom, argbIsRoomOutput1);
                        }

                        if (Strings.Len(m_sRoomDesc) > 0)
                        {
                            string argsText2 = m_sRoomDesc + System.Environment.NewLine;
                            bool argbIsRoomOutput2 = true;
                            PrintTextWithParse(argsText2, m_oGlobals.PresetList["roomdesc"].FgColor, m_oGlobals.PresetList["roomdesc"].BgColor, false, WindowTarget.Room, argbIsRoomOutput2);
                        }

                        if (Strings.Len(m_sRoomObjs) > 0)
                        {
                            string argsText3 = m_sRoomObjs + System.Environment.NewLine;
                            bool argbIsRoomOutput3 = true;
                            PrintTextWithParse(argsText3, default, default, false, targetRoom, argbIsRoomOutput3);
                        }

                        if (Strings.Len(m_sRoomPlayers) > 0)
                        {
                            string argsText4 = m_sRoomPlayers + System.Environment.NewLine;
                            bool argbIsRoomOutput4 = true;
                            PrintTextWithParse(argsText4, default, default, false, targetRoom, argbIsRoomOutput4);
                        }

                        if (Strings.Len(m_sRoomExits) > 0)
                        {
                            if (m_sRoomExits.Trim().EndsWith(":"))
                            {
                                m_sRoomExits = m_sRoomExits.Trim() + " none.";
                            }

                            if (!m_sRoomExits.EndsWith("."))
                            {
                                m_sRoomExits += ".";
                            }

                            string argsText5 = m_sRoomExits + System.Environment.NewLine;
                            bool argbIsRoomOutput5 = true;
                            PrintTextWithParse(argsText5, Color.Transparent, Color.Transparent, false, targetRoom, argbIsRoomOutput5);
                        }

                        PrintTextToWindow("@resume@", Color.Transparent, Color.Transparent, WindowTarget.Room, false, true);
                    }
                    else
                    {
                        m_bUpdateRoomOnStreamEnd = true;
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                GenieError.Error("UpdateRoom", "Unable to aquire game thread lock.");
            }
        }

        private void ParseRow(string sText)
        {
            var switchExpr = m_oConnectState;
            switch (switchExpr)
            {
                case ConnectStates.ConnectedKey:
                    {
                        ParseKeyRow(sText);
                        break;
                    }

                case ConnectStates.ConnectedGame:
                    {
                        ParseGameRow(sText);
                        break;
                    }

                case ConnectStates.ConnectedGameHandshake:
                    {
                        m_oConnectState = ConnectStates.ConnectedGame;
                        Thread.Sleep(1000);
                        m_oSocket.Send(Constants.vbLf + Constants.vbLf);
                        break;
                    }
            }
        }

        private ArrayList _CharacterList = new ArrayList();

        public ArrayList CharacterList
        {
            get
            {
                return _CharacterList;
            }
        }

        private void ParseKeyRow(string sText)
        {
            if (sText.Length == 32 & m_sEncryptionKey.Length == 0)
            {
                m_sEncryptionKey = sText;
                m_oSocket.Send("A" + Constants.vbTab + m_sAccountName.ToUpper() + Constants.vbTab);
                m_oSocket.Send(Utility.EncryptText(m_sEncryptionKey, m_sAccountPassword));
                m_oSocket.Send(System.Environment.NewLine);
            }
            else
            {
                var oData = new ArrayList();
                foreach (string strLine in sText.Split(Conversions.ToChar(Constants.vbTab)))
                    oData.Add(strLine);
                if (oData.Count > 0)
                {
                    var switchExpr = oData[0];
                    switch (switchExpr)
                    {
                        case "?":
                            {
                                string argtext = "Unable to get login key.";
                                PrintError(argtext);
                                m_oSocket.Disconnect();
                                break;
                            }

                        case "A":
                            {
                                var switchExpr1 = oData[2];
                                switch (switchExpr1)
                                {
                                    case "KEY":
                                        {
                                            m_sLoginKey = Conversions.ToString(oData[3]);
                                            m_sAccountOwner = Conversions.ToString(oData[4]);
                                            m_oSocket.Send("G" + Constants.vbTab + m_sAccountGame.ToUpper() + System.Environment.NewLine);
                                            break;
                                        }

                                    case "NORECORD":
                                        {
                                            string argtext1 = "Account does not exist.";
                                            PrintError(argtext1);
                                            m_oSocket.Disconnect();
                                            break;
                                        }

                                    case "PASSWORD":
                                        {
                                            string argtext2 = "Invalid password.";
                                            PrintError(argtext2);
                                            m_oSocket.Disconnect();
                                            break;
                                        }

                                    case "REJECT":
                                        {
                                            string argtext3 = "Access rejected.";
                                            PrintError(argtext3);
                                            m_oSocket.Disconnect();
                                            break;
                                        }
                                }

                                break;
                            }

                        case "G":
                            {
                                m_oSocket.Send("C" + System.Environment.NewLine);
                                break;
                            }

                        case "C":
                            {
                                if (m_sAccountCharacter.Trim().Length == 0)
                                {
                                    string argtext4 = "Listing characters:";
                                    PrintError(argtext4);
                                    string strUserKey = string.Empty;
                                    // bool blnFoundMatch = false;
                                    for (int i = 5, loopTo = oData.Count - 1; i <= loopTo; i++)
                                    {
                                        if (i % 2 == 0)
                                        {
                                            _CharacterList.Clear();
                                            _CharacterList.Add(oData[i].ToString());
                                            var temp = oData[i].ToString();
                                            PrintError(temp);
                                        }
                                        else
                                        {
                                            strUserKey = Conversions.ToString(oData[i]);
                                        }
                                    }

                                    m_oSocket.Disconnect();
                                }
                                else
                                {
                                    string strUserKey = string.Empty;
                                    string strUserKeyTemp = string.Empty;
                                    bool blnFoundMatch = false;
                                    bool bFoundBanned = false;
                                    for (int i = 5, loopTo1 = oData.Count - 1; i <= loopTo1; i++)
                                    {
                                        if (i % 2 == 0)
                                        {
                                            string sChar = oData[i].ToString();
                                            if (sChar.Contains(" "))
                                                sChar = sChar.Substring(0, sChar.IndexOf(' '));
                                            if (m_oBanned.ContainsKey(Utility.GenerateHashSHA256(sChar)))
                                                bFoundBanned = true;
                                            if (sChar.ToUpper().Equals(m_sAccountCharacter.ToUpper()))
                                            {
                                                blnFoundMatch = true;
                                                strUserKey = strUserKeyTemp;
                                            }

                                            if (blnFoundMatch == false)
                                            {
                                                if (sChar.ToUpper().StartsWith(m_sAccountCharacter.ToUpper()))
                                                {
                                                    blnFoundMatch = true;
                                                    strUserKey = strUserKeyTemp;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            strUserKeyTemp = Conversions.ToString(oData[i]);
                                        }
                                    }

                                    if (bFoundBanned)
                                    {
                                        m_oSocket.Disconnect();
                                        return;
                                    }

                                    if (blnFoundMatch)
                                    {
                                        m_oSocket.Send("L" + Constants.vbTab + strUserKey + Constants.vbTab + "STORM" + Constants.vbLf);
                                    }

                                    if (blnFoundMatch == false)
                                    {
                                        string argtext5 = "Character not found.";
                                        PrintError(argtext5);
                                        m_oSocket.Disconnect();
                                    }
                                }

                                break;
                            }

                        case "L":
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(oData[1], "OK", false)))
                                {
                                    foreach (string strRow in oData)
                                    {
                                        if (strRow.IndexOf("GAMEHOST=") > -1)
                                        {
                                            m_sConnectHost = IsLich ? m_oGlobals.Config.LichServer : strRow.Substring(9);
                                        }
                                        else if (strRow.IndexOf("GAMEPORT=") > -1)
                                        {
                                            m_sConnectPort = IsLich ? m_oGlobals.Config.LichPort : int.Parse(strRow.Substring(9));
                                        }
                                        else if (strRow.IndexOf("KEY=") > -1)
                                        {
                                            m_sConnectKey = strRow.Substring(4);
                                        }
                                    }

                                    if (m_sConnectKey.Length > 0)
                                    {
                                        m_oSocket.Disconnect();
                                        m_oConnectState = ConnectStates.ConnectingGameServer;
                                        m_oSocket.Connect(m_sConnectHost, m_sConnectPort);
                                    }
                                }
                                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(oData[1], "PROBLEM", false)))
                                {
                                    string argtext6 = "There is a problem with your account. Log in to play.net website for more information.";
                                    PrintError(argtext6);
                                    m_oSocket.Disconnect();
                                }

                                break;
                            }
                    }
                }
            }
        }

        private bool m_bMonoOutput = false;
        private bool m_bPresetSpeechOutput = false;
        private bool m_bPresetWhisperOutput = false;
        private bool m_bPresetThoughtOutput = false;
        private bool m_bStatusPromptEnabled = false;

        private string ProcessXMLNodeElement(XmlNode oXmlNode)
        {
            string sReturn = string.Empty;
            Debug.WriteLine(oXmlNode.Name);
            if (oXmlNode.NodeType == XmlNodeType.Element)
            {
                var switchExpr = oXmlNode.Name;
                switch (switchExpr)
                {
                    case "a":
                        {
                            // Dim sText As String = "{{" & GetTextFromXML(oXmlNode) & "}}"
                            // Dim sNoun As String = GetAttributeData(oXmlNode, "noun")
                            // If sNoun.Length > 0 Then
                            // sText = sText.Replace(sNoun, "[[" & sNoun & "]]")
                            // End If
                            // sReturn &= sText

                            sReturn += GetTextFromXML(oXmlNode);
                            break;
                        }

                    case "d":
                        {
                            if ((oXmlNode.ParentNode.Name ?? "") != "component")
                            {
                                string sText = GetTextFromXML(oXmlNode);
                                if (m_oGlobals.Config.bShowLinks)
                                {
                                    string argstrAttributeName = "cmd";
                                    string sCmd = GetAttributeData(oXmlNode, argstrAttributeName);
                                    if (sCmd.Length == 0)
                                        sCmd = sText;
                                    sReturn += "{" + sText + ":" + sCmd + "}";
                                }
                                else
                                {
                                    sReturn += sText;
                                }
                            }

                            break;
                        }

                    case "k":
                        {
                            if ((oXmlNode.ParentNode.Name ?? "") == "vars")
                            {
                                string argstrAttributeName1 = "name";
                                string sName = GetAttributeData(oXmlNode, argstrAttributeName1);
                                string argstrAttributeName2 = "value";
                                string sVal = GetAttributeData(oXmlNode, argstrAttributeName2);
                                if (sName.Length > 0)
                                {
                                    m_oGlobals.VariableList.Add(sName, sVal, Globals.Variables.VariableType.Server);
                                    string argsVariable = "$" + sName;
                                    VariableChanged(argsVariable);
                                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                                }
                            }

                            break;
                        }

                    case "output":
                        {
                            string argstrAttributeName3 = "class";
                            var switchExpr1 = GetAttributeData(oXmlNode, argstrAttributeName3);
                            switch (switchExpr1)
                            {
                                case "mono":
                                    {
                                        m_bMonoOutput = true;
                                        break;
                                    }

                                default:
                                    {
                                        m_bMonoOutput = false;
                                        break;
                                    }
                            }

                            break;
                        }

                    case "streamWindow":	// Window Names
                        {
                            string argstrAttributeName5 = "id";
                            var switchExpr2 = GetAttributeData(oXmlNode, argstrAttributeName5);
                            switch (switchExpr2)
                            {
                                case "main":
                                    {
                                        break;
                                    }

                                case "inv":
                                    {
                                        break;
                                    }

                                case "familiar":
                                    {
                                        break;
                                    }

                                case "thoughts":
                                    {
                                        break;
                                    }

                                case "logons":
                                    {
                                        break;
                                    }

                                case "death":
                                    {
                                        break;
                                    }

                                case "whispers":
                                    {
                                        break;
                                    }

                                case "assess":
                                    {
                                        break;
                                    }

                                case "room":
                                    {
                                        string argstrAttributeName4 = "subtitle";
                                        m_sRoomTitle = GetAttributeData(oXmlNode, argstrAttributeName4);
                                        if (m_sRoomTitle.StartsWith(" - "))
                                        {
                                            m_sRoomTitle = m_sRoomTitle.Substring(3);
                                        }

                                        if (m_sRoomTitle.StartsWith("["))
                                        {
                                            m_sRoomTitle = m_sRoomTitle.Substring(1, m_sRoomTitle.Length - 2);
                                        }

                                        m_sRoomTitle = m_sRoomTitle.Trim();
                                        string argkey = "roomname";
                                        m_oGlobals.VariableList.Add(argkey, m_sRoomTitle, Globals.Variables.VariableType.Reserved);
                                        string argsVariable1 = "$roomname";
                                        VariableChanged(argsVariable1);
                                        m_bUpdatingRoom = true;
                                        break;
                                    }

                                default:
                                    {
                                        break;
                                    }
                                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                            }

                            string argstrAttributeName10 = "target";
                            if (!HasAttribute(oXmlNode, argstrAttributeName10))
                            {
                                string argstrAttributeName6 = "id";
                                string sID = GetAttributeData(oXmlNode, argstrAttributeName6);
                                string argstrAttributeName7 = "title";
                                string sTitle = GetAttributeData(oXmlNode, argstrAttributeName7);
                                // ifClosed = '' means ignore
                                // no ifClosed means send to main
                                string sIfClosed = null;
                                string argstrAttributeName9 = "ifClosed";
                                if (HasAttribute(oXmlNode, argstrAttributeName9))
                                {
                                    string argstrAttributeName8 = "ifClosed";
                                    sIfClosed = GetAttributeData(oXmlNode, argstrAttributeName8);
                                }

                                EventStreamWindow?.Invoke(sID, sTitle, sIfClosed);
                            }

                            break;
                        }

                    case "clearStream": // Clear Window
                        {
                            string argstrAttributeName11 = "id";
                            string sWindow = GetAttributeData(oXmlNode, argstrAttributeName11);
                            ClearWindow(sWindow);
                            break;
                        }

                    case "pushStream": // Output to Window
                        {
                            m_sTargetWindow = string.Empty;
                            string argstrAttributeName13 = "id";
                            var switchExpr3 = GetAttributeData(oXmlNode, argstrAttributeName13);
                            switch (switchExpr3)
                            {
                                case "combat":
                                    {
                                        m_oTargetWindow = WindowTarget.Combat;
                                        break;
                                    }
                                case "main":
                                    {
                                        m_oTargetWindow = WindowTarget.Main;
                                        break;
                                    }

                                case "inv":
                                    {
                                        m_oTargetWindow = WindowTarget.Inv;
                                        break;
                                    }

                                case "familiar":
                                    {
                                        m_oTargetWindow = WindowTarget.Familiar;
                                        m_bFamiliarLineParse = true;
                                        break;
                                    }

                                case "thoughts":
                                    {
                                        m_oTargetWindow = WindowTarget.Thoughts;
                                        break;
                                    }

                                case "logons":
                                    {
                                        m_oTargetWindow = WindowTarget.Logons;
                                        break;
                                    }

                                case "death":
                                    {
                                        m_oTargetWindow = WindowTarget.Death;
                                        break;
                                    }

                                case "room":
                                    {
                                        m_oTargetWindow = WindowTarget.Room;
                                        break;
                                    }
                                case "debug":
                                    {
                                        m_oTargetWindow = WindowTarget.Debug;
                                        break;
                                    }

                                default:
                                    {
                                        m_oTargetWindow = WindowTarget.Other;
                                        string argstrAttributeName12 = "id";
                                        m_sTargetWindow = GetAttributeData(oXmlNode, argstrAttributeName12);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "popStream": // Output to Default Window
                        {
                            if (m_oTargetWindow == WindowTarget.Inv)
                            {
                                PrintTextToWindow("@resume@", default, default, WindowTarget.Inv);
                            }

                            m_oTargetWindow = WindowTarget.Main;
                            break;
                        }

                    case "stream":
                        {
                            string argstrAttributeName14 = "id";
                            var switchExpr4 = GetAttributeData(oXmlNode, argstrAttributeName14);
                            switch (switchExpr4)
                            {
                                case "main":
                                    {
                                        break;
                                    }

                                case "inv":
                                    {
                                        break;
                                    }

                                case "familiar":
                                    {
                                        break;
                                    }

                                case "thoughts":
                                    {
                                        // MsgBox(GetTextFromXML(oXmlNode))
                                        // Exception - Thoughts reset back to Main window after one line send.
                                        // m_oTargetWindow = WindowTarget.Thoughts
                                        // sReturn &= Parse(oXmlNode)
                                        string argsText = GetTextFromXML(oXmlNode) + System.Environment.NewLine;
                                        bool argbIsRoomOutput = false;
                                        WindowTarget windowTarget = WindowTarget.Thoughts;
                                        PrintTextWithParse(argsText, m_oGlobals.PresetList["thoughts"].FgColor, m_oGlobals.PresetList["thoughts"].BgColor, false, windowTarget, bIsRoomOutput: argbIsRoomOutput);
                                        break;
                                    }

                                case "logons":
                                    {
                                        break;
                                    }

                                case "death":
                                    {
                                        break;
                                    }

                                case "debug":
                                    {
                                        break;
                                    }

                                case "room":
                                    {
                                        break;
                                    }

                                default:
                                    {
                                        break;
                                    }
                                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                            }

                            break;
                        }

                    case "preset":
                        {
                            string argstrAttributeName16 = "id";
                            var switchExpr5 = GetAttributeData(oXmlNode, argstrAttributeName16);
                            switch (switchExpr5)
                            {
                                case "speech":
                                    {
                                        m_bPresetSpeechOutput = true;
                                        sReturn += GetTextFromXML(oXmlNode);
                                        break;
                                    }

                                case "whisper":
                                    {
                                        m_bPresetWhisperOutput = true;
                                        sReturn += GetTextFromXML(oXmlNode);
                                        break;
                                    }

                                case "thought":
                                    {
                                        m_bPresetThoughtOutput = true;
                                        sReturn += GetTextFromXML(oXmlNode);
                                        break;
                                    }

                                default:
                                    {
                                        string argstrAttributeName15 = "id";
                                        m_sStyle = GetAttributeData(oXmlNode, argstrAttributeName15);
                                        sReturn += GetTextFromXML(oXmlNode);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "compDef":
                    case "component":
                        {
                            string argstrAttributeName17 = "id";
                            var switchExpr6 = GetAttributeData(oXmlNode, argstrAttributeName17);
                            switch (switchExpr6)
                            {
                                case "room desc":
                                    {
                                        EventTriggerMove?.Invoke();
                                        m_sRoomDesc = GetTextFromXML(oXmlNode);
                                        string argkey1 = "roomdesc";
                                        string argvalue = m_sRoomDesc.Replace(Conversions.ToString('"'), "");
                                        m_oGlobals.VariableList.Add(argkey1, argvalue, Globals.Variables.VariableType.Reserved);
                                        string argsVariable2 = "$roomdesc";
                                        VariableChanged(argsVariable2);
                                        string argkey2 = "roomobjs";
                                        string argvalue1 = "";
                                        m_oGlobals.VariableList.Add(argkey2, argvalue1, Globals.Variables.VariableType.Reserved);
                                        string argkey3 = "roomplayers";
                                        string argvalue2 = "";
                                        m_oGlobals.VariableList.Add(argkey3, argvalue2, Globals.Variables.VariableType.Reserved);
                                        string argkey4 = "roomexits";
                                        string argvalue3 = "";
                                        m_oGlobals.VariableList.Add(argkey4, argvalue3, Globals.Variables.VariableType.Reserved);
                                        UpdateRoom();
                                        break;
                                    }

                                case "room objs":
                                    {
                                        m_sRoomObjs = GetTextFromXML(oXmlNode).TrimStart();
                                        string argkey5 = "monstercount";
                                        string argvalue4 = CountMonsters(oXmlNode).ToString();
                                        m_oGlobals.VariableList.Add(argkey5, argvalue4, Globals.Variables.VariableType.Reserved); // $monstercount
                                        string argsVariable3 = "$monstercount";
                                        VariableChanged(argsVariable3);
                                        string argkey6 = "roomobjs";
                                        var roomobjs = m_sRoomObjs.Replace(Conversions.ToString('"'), "").TrimStart();
                                        m_oGlobals.VariableList.Add(argkey6, roomobjs, Globals.Variables.VariableType.Reserved);
                                        string argsVariable4 = "$roomobjs";
                                        VariableChanged(argsVariable4);
                                        UpdateRoom();
                                        break;
                                    }

                                case "room players":
                                    {
                                        m_sRoomPlayers = GetTextFromXML(oXmlNode);
                                        string argkey7 = "roomplayers";
                                        string argvalue5 = m_sRoomPlayers.Replace(Conversions.ToString('"'), "");
                                        m_oGlobals.VariableList.Add(argkey7, argvalue5, Globals.Variables.VariableType.Reserved);
                                        string argsVariable5 = "$roomplayers";
                                        VariableChanged(argsVariable5);
                                        UpdateRoom();
                                        break;
                                    }

                                case "room exits":
                                    {
                                        m_sRoomExits = GetTextFromXML(oXmlNode);
                                        string argkey8 = "roomexits";
                                        string argvalue6 = m_sRoomExits.Replace(Conversions.ToString('"'), "");
                                        m_oGlobals.VariableList.Add(argkey8, argvalue6, Globals.Variables.VariableType.Reserved);
                                        string argsVariable6 = "$roomexits";
                                        VariableChanged(argsVariable6);
                                        UpdateRoom();
                                        break;
                                    }

                                default:
                                    {
                                        m_bIgnoreXMLDepth = true; // Skip any elements inside an unknown component or compDef
                                        break;
                                    }
                                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                            }

                            break;
                        }

                    case "progressBar":
                        {
                            string argstrAttributeName18 = "value";
                            int intValue = int.Parse(GetAttributeData(oXmlNode, argstrAttributeName18));
                            string argstrAttributeName19 = "id";
                            var switchExpr7 = GetAttributeData(oXmlNode, argstrAttributeName19);
                            switch (switchExpr7)
                            {
                                case "health":
                                    {
                                        m_iHealth = intValue;
                                        string argkey9 = "health";
                                        var healthVar = m_iHealth.ToString();
                                        m_oGlobals.VariableList.Add(argkey9, healthVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable7 = "$health";
                                        VariableChanged(argsVariable7);
                                        break;
                                    }

                                case "mana":
                                    {
                                        m_iMana = intValue;
                                        string argkey10 = "mana";
                                        var manaVar = m_iMana.ToString();
                                        m_oGlobals.VariableList.Add(argkey10, manaVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable8 = "$mana";
                                        VariableChanged(argsVariable8);
                                        break;
                                    }

                                case "spirit":
                                    {
                                        m_iSpirit = intValue;
                                        string argkey11 = "spirit";
                                        var spiritVar = m_iSpirit.ToString();
                                        m_oGlobals.VariableList.Add(argkey11, spiritVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable9 = "$spirit";
                                        VariableChanged(argsVariable9);
                                        break;
                                    }

                                case "stamina":
                                    {
                                        m_iStamina = intValue;
                                        string argkey12 = "stamina";
                                        var staminaVar = m_iStamina.ToString();
                                        m_oGlobals.VariableList.Add(argkey12, staminaVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable10 = "$stamina";
                                        VariableChanged(argsVariable10);
                                        break;
                                    }

                                case "conclevel":
                                case "concentration":
                                    {
                                        m_iConcentration = intValue;
                                        string argkey13 = "concentration";
                                        var concentrationVar = m_iConcentration.ToString();
                                        m_oGlobals.VariableList.Add(argkey13, concentrationVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable11 = "$concentration";
                                        VariableChanged(argsVariable11);
                                        break;
                                    }

                                case "encumlevel":
                                case "encumblevel":
                                case "encumbrance":
                                    {
                                        m_iEncumbrance = intValue;
                                        string argkey14 = "encumbrance";
                                        var encumbVar = m_iEncumbrance.ToString();
                                        m_oGlobals.VariableList.Add(argkey14, encumbVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable12 = "$encumbrance";
                                        VariableChanged(argsVariable12);
                                        break;
                                    }

                                default:
                                    {
                                        break;
                                    }
                                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                            }

                            break;
                        }

                    case "spell":
                        {
                            string sSpellName = GetTextFromXML(oXmlNode);
                            if ((sSpellName ?? "") == "ScriptNumber")
                            {
                                sSpellName = "Unknown";
                            }

                            if ((sSpellName ?? "") == "None")
                            {
                                ClearSpellTime();
                            }
                            else
                            {
                                SetSpellTime();
                            }

                            string argkey15 = "preparedspell";
                            m_oGlobals.VariableList.Add(argkey15, sSpellName, Globals.Variables.VariableType.Reserved);
                            string argsVariable13 = "$preparedspell";
                            VariableChanged(argsVariable13);
                            StatusBarUpdate();
                            break;
                        }

                    case "left":
                        {
                            string argkey16 = "lefthand";
                            string argvalue7 = GetTextFromXML(oXmlNode);
                            m_oGlobals.VariableList.Add(argkey16, argvalue7, Globals.Variables.VariableType.Reserved);
                            string lefthandnoun = GetAttributeData(oXmlNode, "noun");
                            string lefthandkey = "lefthandnoun";
                            m_oGlobals.VariableList.Add(lefthandkey, lefthandnoun, Globals.Variables.VariableType.Reserved);
                            string lefthandid = GetAttributeData(oXmlNode, "exist");
                            string lefthandidkey = "lefthandid";
                            m_oGlobals.VariableList.Add(lefthandidkey, lefthandid, Globals.Variables.VariableType.Reserved);
                            string argsVariable14 = "$lefthand";
                            VariableChanged(argsVariable14);
                            string argsVariable15 = "$lefthandnoun";
                            VariableChanged(argsVariable15);
                            string argsVariable16 = "$lefthandid";
                            VariableChanged(argsVariable16);
                            StatusBarUpdate();
                            break;
                        }

                    case "right":
                        {
                            string argkey19 = "righthand";
                            string argvalue10 = GetTextFromXML(oXmlNode);
                            m_oGlobals.VariableList.Add(argkey19, argvalue10, Globals.Variables.VariableType.Reserved);
                            string righthandnoun = GetAttributeData(oXmlNode, "noun");
                            string righthandkey = "righthandnoun";
                            m_oGlobals.VariableList.Add(righthandkey, righthandnoun, Globals.Variables.VariableType.Reserved);
                            string righthandid = GetAttributeData(oXmlNode, "exist");
                            string righthandidkey = "righthandid";
                            m_oGlobals.VariableList.Add(righthandidkey, righthandid, Globals.Variables.VariableType.Reserved);

                            string argsVariable17 = "$righthand";
                            VariableChanged(argsVariable17);
                            string argsVariable18 = "$righthandnoun";
                            VariableChanged(argsVariable18);
                            string argsVariable19 = "$righthandid";
                            VariableChanged(argsVariable19);
                            StatusBarUpdate();
                            break;
                        }

                    case "app":
                        {
                            string argstrAttributeName20 = "char";
                            string sTemp = GetAttributeData(oXmlNode, argstrAttributeName20);
                            if (sTemp.Length > 0)
                            {
                                m_sCharacterName = sTemp;
                                string argkey22 = "charactername";
                                m_oGlobals.VariableList.Add(argkey22, m_sCharacterName, Globals.Variables.VariableType.Reserved);
                                string argsVariable20 = "$charactername";
                                VariableChanged(argsVariable20);
                                if (m_oBanned.ContainsKey(Utility.GenerateHashSHA256(m_sCharacterName)))
                                {
                                    m_oSocket.Disconnect();
                                    m_bManualDisconnect = true;
                                }

                                string argstrAttributeName21 = "game";
                                m_sGameName = GetAttributeData(oXmlNode, argstrAttributeName21);
                                m_sGameName = m_sGameName.Replace(":", "").Replace(" ", "");
                                string argkey23 = "gamename";
                                m_oGlobals.VariableList.Add(argkey23, m_sGameName, Globals.Variables.VariableType.Reserved);
                                string argsVariable21 = "$gamename";
                                VariableChanged(argsVariable21);
                            }

                            break;
                        }

                    case "indicator":
                        {
                            bool blnActive = false;
                            string argstrAttributeName22 = "visible";
                            if ((GetAttributeData(oXmlNode, argstrAttributeName22) ?? "") == "y")
                            {
                                blnActive = true;
                            }

                            string argstrAttributeName23 = "id";
                            var switchExpr8 = GetAttributeData(oXmlNode, argstrAttributeName23);
                            switch (switchExpr8)
                            {
                                case "IconKNEELING":
                                    {
                                        m_oIndicatorHash[Indicator.Kneeling] = blnActive;
                                        string argkey24 = "kneeling";
                                        var kneelingVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey24, kneelingVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable22 = "$kneeling";
                                        VariableChanged(argsVariable22);
                                        break;
                                    }

                                case "IconPRONE":
                                    {
                                        m_oIndicatorHash[Indicator.Prone] = blnActive;
                                        string argkey25 = "prone";
                                        var proneVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey25, proneVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable23 = "$prone";
                                        VariableChanged(argsVariable23);
                                        break;
                                    }

                                case "IconSITTING":
                                    {
                                        m_oIndicatorHash[Indicator.Sitting] = blnActive;
                                        string argkey26 = "sitting";
                                        var sittingVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey26, sittingVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable24 = "$sitting";
                                        VariableChanged(argsVariable24);
                                        break;
                                    }

                                case "IconSTANDING":
                                    {
                                        m_oIndicatorHash[Indicator.Standing] = blnActive;
                                        string argkey27 = "standing";
                                        var standingVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey27, standingVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable25 = "$standing";
                                        VariableChanged(argsVariable25);
                                        break;
                                    }

                                case "IconSTUNNED":
                                    {
                                        m_oIndicatorHash[Indicator.Stunned] = blnActive;
                                        string argkey28 = "stunned";
                                        var stunnedVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey28, stunnedVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable26 = "$stunned";
                                        VariableChanged(argsVariable26);
                                        break;
                                    }

                                case "IconHIDDEN":
                                    {
                                        m_oIndicatorHash[Indicator.Hidden] = blnActive;
                                        string argkey29 = "hidden";
                                        var hiddenVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey29, hiddenVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable27 = "$hidden";
                                        VariableChanged(argsVariable27);
                                        break;
                                    }

                                case "IconINVISIBLE":
                                    {
                                        m_oIndicatorHash[Indicator.Invisible] = blnActive;
                                        string argkey30 = "invisible";
                                        var invisibleVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey30, invisibleVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable28 = "$invisible";
                                        VariableChanged(argsVariable28);
                                        break;
                                    }

                                case "IconDEAD":
                                    {
                                        m_oIndicatorHash[Indicator.Dead] = blnActive;
                                        string argkey31 = "dead";
                                        var deadVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey31, deadVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable29 = "$dead";
                                        VariableChanged(argsVariable29);
                                        break;
                                    }

                                case "IconWEBBED":
                                    {
                                        m_oIndicatorHash[Indicator.Webbed] = blnActive;
                                        string argkey32 = "webbed";
                                        var webbedVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey32, webbedVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable30 = "$webbed";
                                        VariableChanged(argsVariable30);
                                        break;
                                    }

                                case "IconJOINED":
                                    {
                                        m_oIndicatorHash[Indicator.Joined] = blnActive;
                                        string argkey33 = "joined";
                                        var joinedVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey33, joinedVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable31 = "$joined";
                                        VariableChanged(argsVariable31);
                                        break;
                                    }

                                case "IconBLEEDING":
                                    {
                                        m_oIndicatorHash[Indicator.Bleeding] = blnActive;
                                        string argkey34 = "bleeding";
                                        var bleedingVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey34, bleedingVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable32 = "$bleeding";
                                        VariableChanged(argsVariable32);
                                        break;
                                    }

                                case "IconPOISONED":
                                    {
                                        string argkey35 = "poisoned";
                                        var poisonedVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey35, poisonedVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable33 = "$poisoned";
                                        VariableChanged(argsVariable33);
                                        break;
                                    }

                                case "IconDISEASED":
                                    {
                                        string argkey36 = "diseased";
                                        var diseasedVar = Utility.BooleanToInteger(blnActive).ToString();
                                        m_oGlobals.VariableList.Add(argkey36, diseasedVar, Globals.Variables.VariableType.Reserved);
                                        string argsVariable34 = "$diseased";
                                        VariableChanged(argsVariable34);
                                        break;
                                    }

                                default:
                                    {
                                        break;
                                    }
                                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                            }

                            break;
                        }

                    case var @case when @case == "spell":
                        {
                            break;
                        }

                    case var case1 when case1 == "left":
                        {
                            break;
                        }

                    case var case2 when case2 == "right":
                        {
                            break;
                        }

                    case "roundTime":
                        {
                            string argstrAttributeName24 = "value";
                            m_iRoundTime = int.Parse(GetAttributeData(oXmlNode, argstrAttributeName24));
                            break;
                        }

                    case "castTime":
                        {
                            if (m_oGlobals.VariableList.Contains("casttime"))
                            {
                                m_oGlobals.VariableList["casttime"] = GetAttributeData(oXmlNode, "value");
                            }
                            else
                            {
                                m_oGlobals.VariableList.Add("casttime", GetAttributeData(oXmlNode, "value"));
                            }
                            VariableChanged("$casttime");
                            EventCastTime?.Invoke();
                            break;
                        }
                    case "spelltime":
                        {
                            if(m_oGlobals.VariableList["preparedspell"].ToString() == "None")
                            {
                                if (m_oGlobals.VariableList.Contains("spellstarttime"))
                                {
                                    m_oGlobals.VariableList["spellstarttime"] = "0";
                                }
                                else
                                {
                                    m_oGlobals.VariableList.Add("spellstarttime", "0");

                                }
                            }
                            else
                            {
                                if (m_oGlobals.VariableList.Contains("spellstarttime"))
                                {
                                    m_oGlobals.VariableList["spellstarttime"] = GetAttributeData(oXmlNode, "value");
                                }
                                else
                                {
                                    m_oGlobals.VariableList.Add("spellstarttime", GetAttributeData(oXmlNode, "value"));

                                }
                            }
                            VariableChanged("$spellstarttime");
                            break;
                        }
                    case "prompt":
                        {
                            string strBuffer = GetTextFromXML(oXmlNode);
                            if (m_bStatusPromptEnabled == false)
                            {
                                if ((strBuffer ?? "") != ">")
                                {
                                    m_bStatusPromptEnabled = true;

                                    // Fix for Joined and Bleeding
                                    if (strBuffer.Contains("J") == false)
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oGlobals.VariableList["joined"], "1", false)))
                                        {
                                            string argkey37 = "joined";
                                            string argvalue13 = "0";
                                            m_oGlobals.VariableList.Add(argkey37, argvalue13, Globals.Variables.VariableType.Reserved);
                                            string argsVariable35 = "$joined";
                                            VariableChanged(argsVariable35);
                                        }
                                    }

                                    if (strBuffer.Contains("!") == false)
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oGlobals.VariableList["bleeding"], "1", false)))
                                        {
                                            string argkey38 = "bleeding";
                                            string argvalue14 = "0";
                                            m_oGlobals.VariableList.Add(argkey38, argvalue14, Globals.Variables.VariableType.Reserved);
                                            string argsVariable36 = "$bleeding";
                                            VariableChanged(argsVariable36);
                                        }
                                    }
                                }
                                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Dead], true, false)))
                                {
                                    strBuffer += "DEAD";
                                }
                                else
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Kneeling], true, false)))
                                    {
                                        strBuffer += "K";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Sitting], true, false)))
                                    {
                                        strBuffer += "s";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Prone], true, false)))
                                    {
                                        strBuffer += "P";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Stunned], true, false)))
                                    {
                                        strBuffer += "S";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Hidden], true, false)))
                                    {
                                        strBuffer += "H";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Invisible], true, false)))
                                    {
                                        strBuffer += "I";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Webbed], true, false)))
                                    {
                                        strBuffer += "W";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Bleeding], true, false)))
                                    {
                                        strBuffer += "!";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oIndicatorHash[Indicator.Joined], true, false)))
                                    {
                                        strBuffer += "J";
                                    }
                                }
                            }
                            else
                            {
                                // Fix for Joined and Bleeding
                                if (strBuffer.Contains("J") == false)
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oGlobals.VariableList["joined"], "1", false)))
                                    {
                                        string argkey39 = "joined";
                                        string argvalue15 = "0";
                                        m_oGlobals.VariableList.Add(argkey39, argvalue15, Globals.Variables.VariableType.Reserved);
                                        string argsVariable37 = "$joined";
                                        VariableChanged(argsVariable37);
                                    }
                                }

                                if (strBuffer.Contains("!") == false)
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oGlobals.VariableList["bleeding"], "1", false)))
                                    {
                                        string argkey40 = "bleeding";
                                        string argvalue16 = "0";
                                        m_oGlobals.VariableList.Add(argkey40, argvalue16, Globals.Variables.VariableType.Reserved);
                                        string argsVariable38 = "$bleeding";
                                        VariableChanged(argsVariable38);
                                    }
                                }
                            }

                            // Dim strBuffer As String = String.Empty

                            string argstrAttributeName25 = "time";
                            if (int.TryParse(GetAttributeData(oXmlNode, argstrAttributeName25), out m_iGameTime))
                            {
                                string argkey41 = "gametime";
                                string argvalue17 = m_iGameTime.ToString();
                                m_oGlobals.VariableList.Add(argkey41, argvalue17, Globals.Variables.VariableType.Reserved);
                                string argsVariable39 = "$gametime";
                                VariableChanged(argsVariable39);
                                int rt = m_iRoundTime - m_iGameTime;
                                if (rt > 0)
                                {
                                    SetRoundTime(rt);
                                    if (m_bStatusPromptEnabled == false)
                                        strBuffer += "R";
                                    rt += Convert.ToInt32(m_oGlobals.Config.dRTOffset);
                                    var rtString = rt.ToString();
                                    string argkey42 = "roundtime";
                                    m_oGlobals.VariableList.Add(argkey42, rtString, Globals.Variables.VariableType.Reserved);
                                }
                                else
                                {
                                    string argkey43 = "roundtime";
                                    string argvalue18 = "0";
                                    m_oGlobals.VariableList.Add(argkey43, argvalue18, Globals.Variables.VariableType.Reserved);
                                }

                                string argsVariable40 = "$roundtime";
                                VariableChanged(argsVariable40);
                                if (m_oGlobals.Config.sPrompt.Length > 0)
                                {
                                    strBuffer = strBuffer.Replace(">", "");
                                    strBuffer += m_oGlobals.Config.sPrompt;
                                    bool argbIsPrompt = true;
                                    WindowTarget argoWindowTarget = 0;
                                    
                                        PrintTextWithParse(strBuffer, argbIsPrompt, oWindowTarget: argoWindowTarget);
                                    
                                }

                                string argkey44 = "prompt";
                                m_oGlobals.VariableList.Add(argkey44, strBuffer, Globals.Variables.VariableType.Reserved);
                                string argsVariable41 = "$prompt";
                                VariableChanged(argsVariable41);
                                EventTriggerPrompt?.Invoke();
                            }

                            break;
                        }

                    case "style":
                        {
                            string argstrAttributeName26 = "id";
                            string tmpString = GetAttributeData(oXmlNode, argstrAttributeName26);
                            m_sStyle = tmpString;
                            break;
                        }

                    case "compass":
                        {
                            m_oCompassHash[Direction.North] = false;
                            m_oCompassHash[Direction.NorthEast] = false;
                            m_oCompassHash[Direction.East] = false;
                            m_oCompassHash[Direction.SouthEast] = false;
                            m_oCompassHash[Direction.South] = false;
                            m_oCompassHash[Direction.SouthWest] = false;
                            m_oCompassHash[Direction.West] = false;
                            m_oCompassHash[Direction.NorthWest] = false;
                            m_oCompassHash[Direction.Up] = false;
                            m_oCompassHash[Direction.Down] = false;
                            m_oCompassHash[Direction.Out] = false;
                            string argkey45 = "north";
                            string argvalue19 = "0";
                            m_oGlobals.VariableList.Add(argkey45, argvalue19, Globals.Variables.VariableType.Reserved);
                            string argkey46 = "northeast";
                            string argvalue20 = "0";
                            m_oGlobals.VariableList.Add(argkey46, argvalue20, Globals.Variables.VariableType.Reserved);
                            string argkey47 = "east";
                            string argvalue21 = "0";
                            m_oGlobals.VariableList.Add(argkey47, argvalue21, Globals.Variables.VariableType.Reserved);
                            string argkey48 = "southeast";
                            string argvalue22 = "0";
                            m_oGlobals.VariableList.Add(argkey48, argvalue22, Globals.Variables.VariableType.Reserved);
                            string argkey49 = "south";
                            string argvalue23 = "0";
                            m_oGlobals.VariableList.Add(argkey49, argvalue23, Globals.Variables.VariableType.Reserved);
                            string argkey50 = "southwest";
                            string argvalue24 = "0";
                            m_oGlobals.VariableList.Add(argkey50, argvalue24, Globals.Variables.VariableType.Reserved);
                            string argkey51 = "west";
                            string argvalue25 = "0";
                            m_oGlobals.VariableList.Add(argkey51, argvalue25, Globals.Variables.VariableType.Reserved);
                            string argkey52 = "northwest";
                            string argvalue26 = "0";
                            m_oGlobals.VariableList.Add(argkey52, argvalue26, Globals.Variables.VariableType.Reserved);
                            string argkey53 = "up";
                            string argvalue27 = "0";
                            m_oGlobals.VariableList.Add(argkey53, argvalue27, Globals.Variables.VariableType.Reserved);
                            string argkey54 = "down";
                            string argvalue28 = "0";
                            m_oGlobals.VariableList.Add(argkey54, argvalue28, Globals.Variables.VariableType.Reserved);
                            string argkey55 = "out";
                            string argvalue29 = "0";
                            m_oGlobals.VariableList.Add(argkey55, argvalue29, Globals.Variables.VariableType.Reserved);
                            string argsVariable42 = "compass";
                            VariableChanged(argsVariable42);
                            break;
                        }

                    case "dir":
                        {
                            if ((oXmlNode.ParentNode.Name ?? "") == "compass")
                            {
                                string argstrAttributeName27 = "value";
                                var switchExpr9 = GetAttributeData(oXmlNode, argstrAttributeName27);
                                switch (switchExpr9)
                                {
                                    case "n":
                                        {
                                            m_oCompassHash[Direction.North] = true;
                                            string argkey56 = "north";
                                            string argvalue30 = "1";
                                            m_oGlobals.VariableList.Add(argkey56, argvalue30, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "ne":
                                        {
                                            m_oCompassHash[Direction.NorthEast] = true;
                                            string argkey57 = "northeast";
                                            string argvalue31 = "1";
                                            m_oGlobals.VariableList.Add(argkey57, argvalue31, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "e":
                                        {
                                            m_oCompassHash[Direction.East] = true;
                                            string argkey58 = "east";
                                            string argvalue32 = "1";
                                            m_oGlobals.VariableList.Add(argkey58, argvalue32, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "se":
                                        {
                                            m_oCompassHash[Direction.SouthEast] = true;
                                            string argkey59 = "southeast";
                                            string argvalue33 = "1";
                                            m_oGlobals.VariableList.Add(argkey59, argvalue33, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "s":
                                        {
                                            m_oCompassHash[Direction.South] = true;
                                            string argkey60 = "south";
                                            string argvalue34 = "1";
                                            m_oGlobals.VariableList.Add(argkey60, argvalue34, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "sw":
                                        {
                                            m_oCompassHash[Direction.SouthWest] = true;
                                            string argkey61 = "southwest";
                                            string argvalue35 = "1";
                                            m_oGlobals.VariableList.Add(argkey61, argvalue35, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "w":
                                        {
                                            m_oCompassHash[Direction.West] = true;
                                            string argkey62 = "west";
                                            string argvalue36 = "1";
                                            m_oGlobals.VariableList.Add(argkey62, argvalue36, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "nw":
                                        {
                                            m_oCompassHash[Direction.NorthWest] = true;
                                            string argkey63 = "northwest";
                                            string argvalue37 = "1";
                                            m_oGlobals.VariableList.Add(argkey63, argvalue37, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "up":
                                        {
                                            m_oCompassHash[Direction.Up] = true;
                                            string argkey64 = "up";
                                            string argvalue38 = "1";
                                            m_oGlobals.VariableList.Add(argkey64, argvalue38, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "down":
                                        {
                                            m_oCompassHash[Direction.Down] = true;
                                            string argkey65 = "down";
                                            string argvalue39 = "1";
                                            m_oGlobals.VariableList.Add(argkey65, argvalue39, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    case "out":
                                        {
                                            m_oCompassHash[Direction.Out] = true;
                                            string argkey66 = "out";
                                            string argvalue40 = "1";
                                            m_oGlobals.VariableList.Add(argkey66, argvalue40, Globals.Variables.VariableType.Reserved);
                                            break;
                                        }

                                    default:
                                        {
                                            break;
                                        }
                                        /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                                }

                                string argsVariable43 = "compass";
                                VariableChanged(argsVariable43);
                            }

                            break;
                        }

                    case "pushBold":
                        {
                            m_bBold = true;
                            break;
                        }

                    case "popBold":
                        {
                            m_bBold = false;
                            break;
                        }

                    case "b":
                        {
                            sReturn += oXmlNode.InnerText;
                            break;
                        }

                    case "settingsInfo":
                        {
                            if (m_bIsParsingSettings == false)
                            {
                                m_bIsParsingSettingsStart = true;
                                SendRaw("<sendSettings/>" + Constants.vbLf);
                            }

                            break;
                        }
                        /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                }
            }

            return sReturn;
        }

        public void ResetIndicators()
        {
            m_oIndicatorHash[Indicator.Bleeding] = false;
            m_oIndicatorHash[Indicator.Dead] = false;
            m_oIndicatorHash[Indicator.Hidden] = false;
            m_oIndicatorHash[Indicator.Invisible] = false;
            m_oIndicatorHash[Indicator.Joined] = false;
            m_oIndicatorHash[Indicator.Kneeling] = false;
            m_oIndicatorHash[Indicator.Prone] = false;
            m_oIndicatorHash[Indicator.Sitting] = false;
            m_oIndicatorHash[Indicator.Standing] = false;
            m_oIndicatorHash[Indicator.Stunned] = false;
            m_oIndicatorHash[Indicator.Webbed] = false;
        }

        private Regex m_MonsterRegex = new Regex("<pushBold />([^<]*)<popBold />([^,.]*)", MyRegexOptions.options);

        private int CountMonsters(XmlNode oXmlNode)
        {
            int iMonsterCount = 0;
            string sMonsterList = string.Empty;
            m_oGlobals.MonsterList.Clear();
            foreach (Match m in m_MonsterRegex.Matches(oXmlNode.InnerXml.Replace(" and ", ", ").Replace(" and <pushBold />", ", <pushBold />")))
            {
                var sValue = m.Groups[1].Value + m.Groups[2].Value;
                // PrintText(sValue & vbNewLine)

                bool bIgnore = false;
                foreach (string sIgnore in m_oGlobals.Config.sIgnoreMonsterList.Split('|'))
                {
                    if (Conversions.ToBoolean(sValue.Contains(sIgnore)))
                    {
                        bIgnore = true;
                        break;
                    }
                }

                if (bIgnore == false)
                {
                    iMonsterCount += 1;
                    if (sMonsterList.Length > 0)
                    {
                        sMonsterList += ", ";
                    }

                    sMonsterList += sValue.ToString().Trim();
                }

                if (!m_oGlobals.MonsterList.Contains(sValue.ToString().Trim()))
                {
                    m_oGlobals.MonsterList.Add(sValue.ToString().Trim());
                }
            }

            m_oGlobals.UpdateMonsterListRegEx();
            string argkey = "monsterlist";
            m_oGlobals.VariableList.Add(argkey, sMonsterList, Globals.Variables.VariableType.Reserved);
            string argsVariable = "monsterlist";
            VariableChanged(argsVariable);
            return iMonsterCount;
        }

        private string GetTextFromXML(XmlNode oXmlNode)
        {
            return oXmlNode.InnerText;
        }

        private string GetAttributeData(XmlNode oXmlNode, string strAttributeName)
        {
            XmlNode oXmlAttribute;
            oXmlAttribute = oXmlNode.Attributes.GetNamedItem(strAttributeName);
            if (Information.IsNothing(oXmlAttribute) == false)
            {
                return oXmlAttribute.Value.ToString();
            }
            else
            {
                return "";
            }
        }

        private bool HasAttribute(XmlNode oXmlNode, string strAttributeName)
        {
            XmlNode oXmlAttribute;
            oXmlAttribute = oXmlNode.Attributes.GetNamedItem(strAttributeName);
            return !Information.IsNothing(oXmlAttribute);
        }

        private string ProcessXMLData(XmlNode oXmlNode)
        {
            string sReturn = string.Empty;
            if (Information.IsNothing(oXmlNode))
            {
                return sReturn;
            }

            if (oXmlNode.HasChildNodes == false)
            {
                return sReturn;
            }

            foreach (XmlNode oNode in oXmlNode.ChildNodes)
            {
                if (oNode.NodeType == XmlNodeType.Element)
                {
                    var tmpNode = oNode;
                    sReturn += ProcessXMLNodeElement(tmpNode);
                }

                if (!Information.IsNothing(oNode))
                {
                    // Row below is for stream (thoughts)
                    if (oNode.NodeType != XmlNodeType.Element | (oNode.Name ?? "") != "stream")
                    {
                        if (oNode.HasChildNodes == true)
                        {
                            if (m_bIgnoreXMLDepth == false)
                            {
                                var tmpNode = oNode;
                                sReturn += ProcessXMLData(tmpNode);
                            }
                            else
                            {
                                m_bIgnoreXMLDepth = false;
                            }
                        }
                    }
                }
            }

            return sReturn;
        }

        // Confuse decompilers and reverse engineers by having this method in the middle of everything and no string names in it
        private void DoConnect(string sHostName, int iPort)
        {
            var accountVar = m_sAccountName.ToUpper();

            m_sEncryptionKey = string.Empty;
            m_oConnectState = ConnectStates.ConnectingKeyServer;
            m_oSocket.Connect(sHostName, iPort);
        }

        private MatchCollection m_oMatchCollection;

        public void PrintTextWithParse(string sText, [Optional, DefaultParameterValue(false)] bool bIsPrompt, [Optional, DefaultParameterValue(WindowTarget.Unknown)] WindowTarget oWindowTarget)
        {
            bool argbIsRoomOutput = false;
            PrintTextWithParse(sText, default, default, bIsPrompt, oWindowTarget, bIsRoomOutput: argbIsRoomOutput);
        }

        public void PrintTextWithParse(string sText, Color color, Color bgcolor, bool bIsPrompt = false, WindowTarget oWindowTarget = WindowTarget.Unknown, bool bIsRoomOutput = false)
        {
            
            if (sText.Trim().Length > 0)
            {
                if (sText.Contains("You also see"))
                {
                    int I = sText.IndexOf("You also see");
                    if (I > 0)
                    {
                        string argsText = sText.Substring(0, I).Trim() + System.Environment.NewLine;
                        bool argbIsPrompt = false;
                        WindowTarget argoWindowTarget = 0;
                        PrintTextWithParse(argsText, bIsPrompt: argbIsPrompt, oWindowTarget: argoWindowTarget);
                        sText = sText.Substring(I);
                    }
                }

                if (m_sStyle.Length > 0)
                {
                    var switchExpr = m_sStyle;
                    switch (switchExpr)
                    {
                        case "roomName":
                            {
                                color = m_oGlobals.PresetList["roomname"].FgColor;
                                bgcolor = m_oGlobals.PresetList["roomname"].BgColor;
                                m_oLastFgColor = color;
                                break;
                            }

                        case "roomDesc":
                            {
                                color = m_oGlobals.PresetList["roomdesc"].FgColor;
                                bgcolor = m_oGlobals.PresetList["roomdesc"].BgColor;
                                m_oLastFgColor = color;
                                break;
                            }

                        default:
                            {
                                break;
                            }
                            /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    }

                    m_sStyle = string.Empty;
                }

                if (m_bPresetSpeechOutput == true)
                {
                    if (sText.Contains(", \""))
                    {
                        color = m_oGlobals.PresetList["speech"].FgColor;
                        bgcolor = m_oGlobals.PresetList["speech"].BgColor;

                        // Log Window
                        // If m_oTargetWindow = WindowTarget.Other Then
                        // PrintTextToWindow(sText, color, bgcolor, WindowTarget.Log)
                        // End If
                    }

                    m_bPresetSpeechOutput = false;
                }

                if (m_bPresetWhisperOutput == true)
                {
                    if (sText.Contains(", \""))
                    {
                        color = m_oGlobals.PresetList["whispers"].FgColor;
                        bgcolor = m_oGlobals.PresetList["whispers"].BgColor;

                        // Log Window
                        // If m_oTargetWindow = WindowTarget.Other Then
                        // PrintTextToWindow(sText, color, bgcolor, WindowTarget.Log)
                        // End If
                    }

                    m_bPresetWhisperOutput = false;
                }

                if (m_bPresetThoughtOutput == true)
                {
                    color = m_oGlobals.PresetList["thoughts"].FgColor;
                    bgcolor = m_oGlobals.PresetList["thoughts"].BgColor;

                    // If m_oTargetWindow = WindowTarget.Main Then
                    // If sText.Contains(", """) Then
                    // Exit Sub
                    // End If
                    // End If

                    m_bPresetThoughtOutput = false;
                }

                if (m_bBold == true)
                {
                    color = m_oGlobals.PresetList["creatures"].FgColor;
                    bgcolor = m_oGlobals.PresetList["creatures"].BgColor;
                }

                // Line begins with
                if (m_oGlobals.HighlightBeginsWithList.AcquireReaderLock())
                {
                    try
                    {
                        foreach (DictionaryEntry de in m_oGlobals.HighlightBeginsWithList)
                        {
                            Globals.HighlightLineBeginsWith.Highlight o = (Globals.HighlightLineBeginsWith.Highlight)de.Value;
                            if (o.IsActive)
                            {
                                if (sText.StartsWith(o.Text, !o.CaseSensitive, null) == true)
                                {
                                    color = o.FgColor;
                                    bgcolor = o.BgColor;
                                    m_oLastFgColor = color;
                                    if (o.SoundFile.Length > 0 && m_oGlobals.Config.bPlaySounds)
                                        Sound.PlayWaveFile(o.SoundFile);
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oGlobals.HighlightBeginsWithList.ReleaseReaderLock();
                    }
                }
                else
                {
                    GenieError.Error("PrintTextWithParse", "Unable to aquire reader lock.");
                }

                // Line contains
                if (!Information.IsNothing(m_oGlobals.HighlightList.RegexLine))
                {
                    m_oMatchCollection = m_oGlobals.HighlightList.RegexLine.Matches(sText);
                    Highlights.Highlight oHighlightString;
                    foreach (Match oMatch in m_oMatchCollection)
                    {
                        if (m_oGlobals.HighlightList.Contains(oMatch.Value))
                        {
                            oHighlightString = (Highlights.Highlight)m_oGlobals.HighlightList[oMatch.Value];
                            color = oHighlightString.FgColor;
                            bgcolor = oHighlightString.BgColor;
                            m_oLastFgColor = color;
                            if (oHighlightString.SoundFile.Length > 0 && m_oGlobals.Config.bPlaySounds)
                                Sound.PlayWaveFile(oHighlightString.SoundFile);
                        }
                    }
                }
            }

            if (oWindowTarget == WindowTarget.Unknown)
            {
                oWindowTarget = m_oTargetWindow;
            }
            PrintTextToWindow(sText, color, bgcolor, oWindowTarget, bIsPrompt, bIsRoomOutput);
        }

        private Color m_oLastFgColor = default;
        private Color m_oEmptyColor = default;

        private void PrintTextToWindow(string text, Color color, Color bgcolor, WindowTarget targetwindow = WindowTarget.Main, bool isprompt = false, bool isroomoutput = false)
        {
            if (text.Length == 0)
            {
                return;
            }

            string sTargetWindowString = string.Empty;
            var switchExpr = targetwindow;
            switch (switchExpr)
            {
                case WindowTarget.Main:
                    {
                        sTargetWindowString = "main";
                        break;
                    }

                case WindowTarget.Death:
                    {
                        sTargetWindowString = "death";
                        break;
                    }

                case WindowTarget.Combat:
                    {
                        sTargetWindowString = "combat";
                        break;
                    }

                case WindowTarget.Familiar:
                    {
                        sTargetWindowString = "familiar";
                        break;
                    }

                case WindowTarget.Inv:
                    {
                        sTargetWindowString = "inv";
                        break;
                    }

                case WindowTarget.Log:
                    {
                        sTargetWindowString = "log";
                        break;
                    }

                case WindowTarget.Logons:
                    {
                        sTargetWindowString = "logons";
                        break;
                    }

                case WindowTarget.Room:
                    {
                        sTargetWindowString = "room";
                        break;
                    }

                case WindowTarget.Thoughts:
                    {
                        sTargetWindowString = "thoughts";
                        break;
                    }

                case WindowTarget.Raw:
                    {
                        sTargetWindowString = "raw";
                        m_sTargetWindow = "raw";
                        targetwindow = WindowTarget.Other;
                        break;
                    }
                case WindowTarget.Debug:
                    {
                        sTargetWindowString = "debug";
                        break;
                    }

                case WindowTarget.Other:
                    {
                        sTargetWindowString = m_sTargetWindow.ToLower();
                        break;
                    }
            }

            text = ParsePluginText(text, sTargetWindowString);
            if (text.Length == 0)
            {
                return;
            }

            if (targetwindow != WindowTarget.Room & targetwindow != WindowTarget.Inv & targetwindow != WindowTarget.Log & text.Trim().Length > 0)
            {
                if (m_oGlobals.Config.bParseGameOnly == false | targetwindow == WindowTarget.Main)
                {
                    string argsText = Utility.Trim(text);
                    TriggerParse(argsText);
                }
            }

            if (targetwindow == WindowTarget.Room & isroomoutput == false) // Skip all other text to room window
            {
                return;
            }

            if (m_oGlobals.Config.bGagsEnabled == true && targetwindow != WindowTarget.Thoughts)
            {
                // Gag List
                if (m_oGlobals.GagList.AcquireReaderLock())
                {
                    try
                    {
                        foreach (Globals.GagRegExp.Gag sl in m_oGlobals.GagList)
                        {
                            if (sl.IsActive && !Information.IsNothing(sl.RegexGag))
                            {
                                if (sl.RegexGag.Match(Utility.Trim(text)).Success == true)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oGlobals.GagList.ReleaseReaderLock();
                    }
                }
                else
                {
                    GenieError.Error("PrintTextToWindow", "Unable to aquire reader lock.");
                }
            }

            if (text.Trim().Length > 0)
            {
                // Substitute Lists
                if (m_oGlobals.SubstituteList.AcquireReaderLock())
                {
                    try
                    {
                        foreach (Globals.SubstituteRegExp.Substitute sl in m_oGlobals.SubstituteList)
                        {
                            if (sl.IsActive && !Information.IsNothing(sl.SubstituteRegex))
                            {
                                if (sl.SubstituteRegex.Match(Utility.Trim(text)).Success)
                                {
                                    bool bNewLineStart = text.StartsWith(System.Environment.NewLine);
                                    bool bNewLineEnd = text.EndsWith(System.Environment.NewLine);
                                    text = sl.SubstituteRegex.Replace(Utility.Trim(text), sl.sReplaceBy.ToString());
                                    if (bNewLineStart == true)
                                    {
                                        text = System.Environment.NewLine + text;
                                    }

                                    if (bNewLineEnd == true)
                                    {
                                        text += System.Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        m_oGlobals.SubstituteList.ReleaseReaderLock();
                    }
                }
                else
                {
                    GenieError.Error("PrintTextToWindow", "Unable to aquire reader lock.");
                }
            }

            if (targetwindow == WindowTarget.Main)
            {
                if (text.Trim().Length == 0)
                {
                    if (m_bLastRowWasBlank == true || m_bLastRowWasPrompt == true)
                    {
                        return;
                    }

                    m_bLastRowWasBlank = true;
                }
                else if (Regex.IsMatch(text, @"^.*\" + m_oGlobals.Config.sPrompt + "?$"))
                {
                    if (m_bLastRowWasBlank)
                    {
                        return;
                    }
                    m_bLastRowWasPrompt = true;
                }
                else
                {
                    m_bLastRowWasPrompt = false;
                    m_bLastRowWasBlank = false;
                }
                
            }

            if (targetwindow == WindowTarget.Main | targetwindow == WindowTarget.Thoughts | targetwindow == WindowTarget.Combat)
            {
                if (m_oGlobals.Config.bAutoLog == true)
                {
                    m_oGlobals.Log?.LogText(text, Conversions.ToString(m_oGlobals.VariableList["charactername"]), Conversions.ToString(m_oGlobals.VariableList["game"]));
                    //if (m_bLastRowWasPrompt == true)
                    //{
                    //    m_oGlobals.Log?.LogText(text + System.Environment.NewLine, Conversions.ToString(m_oGlobals.VariableList["charactername"]), Conversions.ToString(m_oGlobals.VariableList["game"]));
                    //}

                    //     m_oGlobals.Log.LogText(text, Conversions.ToString(m_oGlobals.VariableList["charactername"]), Conversions.ToString(m_oGlobals.VariableList["game"]));
                }
            }

            if (text.Trim().StartsWith("Invalid login key."))
            {
                m_oReconnectTime = default;
                m_bManualDisconnect = true;
            }

            if (color == m_oEmptyColor | color == Color.Transparent)
            {
                if (m_oLastFgColor != m_oEmptyColor)
                {
                    color = m_oLastFgColor;
                }
            }

            if (text.EndsWith(System.Environment.NewLine) | text.StartsWith(System.Environment.NewLine))
            {
                m_oLastFgColor = default;
            }

            string targetwindowstring = string.Empty;
            if (targetwindow == WindowTarget.Other)
            {
                targetwindowstring = m_sTargetWindow;
            }

            if (targetwindow == WindowTarget.Familiar)
            {
                color = m_oGlobals.PresetList["familiar"].FgColor;
                bgcolor = m_oGlobals.PresetList["familiar"].BgColor;
            }

            var tempVar = false;
            EventPrintText?.Invoke(text, color, bgcolor, targetwindow, targetwindowstring, m_bMonoOutput, isprompt, tempVar);
        }

        private void VariableChanged(string sVariable)
        {
            EventVariableChanged?.Invoke(sVariable);
        }

        private void TriggerParse(string sText)
        {
            if (sText.Trim().Length > 0)
            {
                EventTriggerParse?.Invoke(sText);
            }
        }

        // Skip all blank line/prompt checks and just print it
        private void PrintInputText(string sText, Color oColor, Color oBgColor)
        {
            if (sText.Length == 0)
            {
                return;
            }

            var windowVar = WindowTarget.Main;
            var emptyVar = "";
            var trueVar = true;
            var falseVar = false;

            EventPrintText?.Invoke(sText, oColor, oBgColor, windowVar, emptyVar, m_bMonoOutput, trueVar, falseVar);
        }

        private void ClearWindow(string sWindow)
        {
            EventClearWindow?.Invoke(sWindow);
        }

        // Round Time
        private void SetRoundTime(int iTime)
        {
            EventRoundTime?.Invoke(iTime);
        }

        // Reset Spell Time
        private void SetSpellTime()
        {
            EventSpellTime?.Invoke();
        }

        // Clear Spell Time
        private void ClearSpellTime()
        {
            EventClearSpellTime?.Invoke();
        }

        private void StatusBarUpdate()
        {
            EventStatusBarUpdate?.Invoke();
        }

        private void PrintError(string text)
        {
            // Honor prompt
            if (m_bLastRowWasPrompt)
            {
                m_bLastRowWasPrompt = false;
                var rowVar = System.Environment.NewLine + text;
                EventPrintError?.Invoke(rowVar);
            }
            else
            {
                EventPrintError?.Invoke(text);
            }
        }

        private void HandleGenieException(string section, string message, string description = null)
        {
            GenieError.Error(section, message, description);
        }

        private void GameSocket_EventConnected()
        {
            var switchExpr = m_oConnectState;
            switch (switchExpr)
            {
                case ConnectStates.ConnectingKeyServer:
                    {
                        m_oSocket.Send("K" + System.Environment.NewLine);
                        m_oConnectState = ConnectStates.ConnectedKey;
                        break;
                    }

                case ConnectStates.ConnectingGameServer:
                    {
                        m_oConnectState = ConnectStates.ConnectedGameHandshake;
                        m_iConnectAttempts = 0;
                        m_bManualDisconnect = false;
                        m_oReconnectTime = default;
                        m_oSocket.Send("<c>" + m_sConnectKey + Constants.vbLf + "<c>/FE:WIZARD /VERSION:1.0.1.22 /P:WIN_UNKNOWN /XML" + Constants.vbLf);    // TEMP
                                                                                                                                                            // m_oSocket.Send("<c>" & m_sConnectKey & vbLf & "<c>" & m_oGlobals.Config.sConnectString & vbLf)
                        string argkey = "connected";
                        string argvalue = "1";
                        m_oGlobals.VariableList.Add(argkey, argvalue, Globals.Variables.VariableType.Reserved);
                        string argsVariable = "$connected";
                        VariableChanged(argsVariable);
                        m_bStatusPromptEnabled = false;
                        break;
                    }
            }
        }

        private void GameSocket_EventDisconnected()
        {
            if (m_oConnectState == ConnectStates.ConnectedGame)
            {
                string argkey = "connected";
                string argvalue = "0";
                m_oGlobals.VariableList.Add(argkey, argvalue, Globals.Variables.VariableType.Reserved);
                string argsVariable = "$connected";
                VariableChanged(argsVariable);
                m_bStatusPromptEnabled = false;
            }
        }

        private void GameSocket_EventExit()
        {
            Disconnect(true);
        }
        private void GameSocket_EventParseRow(StringBuilder row)
        {
            var rowVar = row.ToString();
            ParseRow(rowVar);
        }

        private string ParsePluginText(string sText, string sWindow)
        {
            if (m_oGlobals.PluginsEnabled == false)
                return sText;
            foreach (object oPlugin in m_oGlobals.PluginList)
            {
                if(oPlugin is GeniePlugin.Interfaces.IPlugin)
                {
                    if ((oPlugin as GeniePlugin.Interfaces.IPlugin).Enabled)
                    {
                        try
                        {
                            sText = (oPlugin as GeniePlugin.Interfaces.IPlugin).ParseText(sText, sWindow);
                        }
                        /* TODO ERROR: Skipped IfDirectiveTrivia */
                        catch (Exception ex)
                        {
                            GenieError.GeniePluginError((oPlugin as GeniePlugin.Interfaces.IPlugin), "ParseText", ex);
                            (oPlugin as GeniePlugin.Interfaces.IPlugin).Enabled = false;
                            /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                        }
                    }
                }
                else if(oPlugin is GeniePlugin.Plugins.IPlugin)
                {
                    if ((oPlugin as GeniePlugin.Plugins.IPlugin).Enabled)
                    {
                        try
                        {
                            sText = (oPlugin as GeniePlugin.Plugins.IPlugin).ParseText(sText, sWindow);
                        }
                        /* TODO ERROR: Skipped IfDirectiveTrivia */
                        catch (Exception ex)
                        {
                            GenieError.GeniePluginError((oPlugin as GeniePlugin.Plugins.IPlugin), "ParseText", ex);
                            (oPlugin as GeniePlugin.Plugins.IPlugin).Enabled = false;
                            /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                        }
                    }
                }
            }

            return sText;
        }

        private void GameSocket_EventParsePartialRow(string row)
        {
            if (m_oConnectState == ConnectStates.ConnectedKey | m_oConnectState == ConnectStates.ConnectedGameHandshake)
            {
                ParseRow(row);
            }
        }

        private void GameSocket_EventDataRecieveEnd()
        {
            EventDataRecieveEnd?.Invoke();
        }

        private void GameSocket_EventPrintText(string text)
        {
            WindowTarget argoWindowTarget = 0;
            bool argbIsRoomOutput = false;
            PrintTextWithParse(text, Color.White, Color.Transparent, oWindowTarget: argoWindowTarget, bIsRoomOutput: argbIsRoomOutput);
        }

        private void GameSocket_EventPrintError(string text)
        {
            PrintTextToWindow(text, Color.Red, Color.Transparent);
        }

        private bool m_bManualDisconnect = false;
        private DateTime m_oReconnectTime = default;
        private int m_iConnectAttempts = 0;

        public DateTime ReconnectTime
        {
            get
            {
                return m_oReconnectTime;
            }

            set
            {
                m_oReconnectTime = value;
            }
        }

        public int ConnectAttempts
        {
            get
            {
                return m_iConnectAttempts;
            }

            set
            {
                m_iConnectAttempts = value;
            }
        }

        private void GameSocket_EventConnectionLost()
        {
            if (m_oGlobals.Config.bReconnect == true & m_bManualDisconnect == false)
            {
                if (m_iConnectAttempts == 0) // Attempt to connect right away
                {
                    m_oReconnectTime = DateTime.Now;
                    string argtext = Utility.GetTimeStamp() + " Attempting to reconnect.";
                    PrintError(argtext);
                }
                else if (m_iConnectAttempts > 10) // After 10 attempts wait 30 seconds
                {
                    m_oReconnectTime = DateTime.Now.AddSeconds(30);
                    string argtext3 = Utility.GetTimeStamp() + " Attempting to reconnect in 30 seconds.";
                    PrintError(argtext3);
                }
                else if (m_iConnectAttempts > 5) // After 5 attempts wait 15 seconds
                {
                    m_oReconnectTime = DateTime.Now.AddSeconds(15);
                    string argtext2 = Utility.GetTimeStamp() + " Attempting to reconnect in 15 seconds.";
                    PrintError(argtext2);
                }
                else if (m_iConnectAttempts > 0) // After first attempt wait 5 seconds
                {
                    m_oReconnectTime = DateTime.Now.AddSeconds(5);
                    string argtext1 = Utility.GetTimeStamp() + " Attempting to reconnect in 5 seconds.";
                    PrintError(argtext1);
                }
            }

            m_bManualDisconnect = false;
        }
    }
}