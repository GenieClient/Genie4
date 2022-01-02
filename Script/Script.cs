using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using Jint;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public class Script
    {
        private const int m_iDefaultTimeout = 3500;

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private class ScriptLine
        {
            public int iFileId = 0;
            public int iFileRow = 0;
            public string sRowContent = string.Empty;
            public ScriptFunctions oFunction = ScriptFunctions.empty;
        }

        private class CurrentLine
        {
            private class Line
            {
                public int iIndex = 0;
                public bool bSkipBlock = false;
                public int iBlockDepth = 0;
                public ArrayList oBlockList = new ArrayList();
                public ArrayList oArgList = new ArrayList();
                public bool bLastRowWasEvaluation = false;
            }

            private ArrayList oLineList = new ArrayList();

            public enum BlockState
            {
                noeval,
                evaltrue,
                evalfalse,
                evalwhiletrue,
                evalwhilefalse
            }

            public bool AddBlock(BlockState oBlockState = BlockState.noeval)
            {
                Line oLine = (Line)oLineList[oLineList.Count - 1];
                oLine.oBlockList.Add(oBlockState);
                return default;
            }

            public bool RemoveBlock()
            {
                if (oLineList.Count > 0)
                {
                    Line oLine = (Line)oLineList[oLineList.Count - 1];
                    if (oLine.oBlockList.Count > 0)
                    {
                        oLine.oBlockList.RemoveAt(oLine.oBlockList.Count - 1);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            public ArrayList ArgList
            {
                get
                {
                    Line oLine = (Line)oLineList[oLineList.Count - 1];
                    return oLine.oArgList;
                }

                set
                {
                    Line oLine = (Line)oLineList[oLineList.Count - 1];
                    oLine.oArgList = value;
                }
            }

            public int BlockCount
            {
                get
                {
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        return oLine.oBlockList.Count;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public int Count
            {
                get
                {
                    return oLineList.Count;
                }
            }

            public BlockState BlockValue
            {
                get
                {
                    BlockState BlockValueRet = default;
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        if (oLine.oBlockList.Count > 0)
                        {
                            BlockValueRet = (BlockState)oLine.oBlockList[oLine.oBlockList.Count - 1];
                        }
                        else
                        {
                            BlockValueRet = 0;
                        }
                    }
                    else
                    {
                        BlockValueRet = 0;
                    }

                    return BlockValueRet;
                }

                set
                {
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        if (oLine.oBlockList.Count > 0)
                        {
                            oLine.oBlockList[oLine.oBlockList.Count - 1] = value;
                        }
                        else
                        {
                            AddBlock(value);
                        }
                    }
                }
            }

            public void Clear()
            {
                oLineList.Clear();
            }

            public void ClearBlocks()
            {
                if (oLineList.Count > 0)
                {
                    Line oLine = (Line)oLineList[oLineList.Count - 1];
                    oLine.oBlockList.Clear();
                }
            }

            public int AddJump(int iIndex = 0, string sArgument = "")
            {
                var oLine = new Line();
                oLine.iIndex = iIndex;
                if (sArgument.Length > 0)
                {
                    oLine.oArgList.Clear();
                    oLine.oArgList.Add(sArgument);
                    foreach (string s in Utility.ParseArgs(sArgument))
                        oLine.oArgList.Add(s);
                }

                return oLineList.Add(oLine);
            }

            public bool RemoveJump()
            {
                if (oLineList.Count > 1) // Do not remove last one. We always need one object for loop to work.
                {
                    oLineList.RemoveAt(oLineList.Count - 1);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int TargetBlockDepthValue
            {
                get
                {
                    int TargetBlockDepthValueRet = default;
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        TargetBlockDepthValueRet = oLine.iBlockDepth;
                    }
                    else
                    {
                        TargetBlockDepthValueRet = 0;
                    }

                    return TargetBlockDepthValueRet;
                }

                set
                {
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        oLine.iBlockDepth = value;
                        oLineList[oLineList.Count - 1] = oLine;
                    }
                }
            }

            public bool SkipBlock
            {
                get
                {
                    bool SkipBlockRet = default;
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        SkipBlockRet = oLine.bSkipBlock;
                    }
                    else
                    {
                        SkipBlockRet = Conversions.ToBoolean(0);
                    }

                    return SkipBlockRet;
                }

                set
                {
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        oLine.bSkipBlock = value;
                        oLineList[oLineList.Count - 1] = oLine;
                    }
                }
            }

            public bool LastRowWasEvaluation
            {
                get
                {
                    bool LastRowWasEvaluationRet = default;
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        LastRowWasEvaluationRet = oLine.bLastRowWasEvaluation;
                    }
                    else
                    {
                        LastRowWasEvaluationRet = Conversions.ToBoolean(0);
                    }

                    return LastRowWasEvaluationRet;
                }

                set
                {
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        oLine.bLastRowWasEvaluation = value;
                        oLineList[oLineList.Count - 1] = oLine;
                    }
                }
            }

            public int LineValue
            {
                get
                {
                    int LineValueRet = default;
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        LineValueRet = oLine.iIndex;
                    }
                    else
                    {
                        LineValueRet = 0;
                    }

                    return LineValueRet;
                }

                set
                {
                    if (oLineList.Count > 0)
                    {
                        Line oLine = (Line)oLineList[oLineList.Count - 1];
                        oLine.iIndex = value;
                        oLineList[oLineList.Count - 1] = oLine;
                    }
                    else
                    {
                        AddJump(value);
                    }
                }
            }
        }

        public class ClassActionList : SortedList
        {
            private Hashtable ClassList = new Hashtable();

            public class Action
            {
                public string action = string.Empty;
                public bool IgnoreCase = false;
                public bool IsEvalAction = false;
                public int iFileId = 0;
                public int iFileRow = 0;
                public Regex oRegExp = null;
                public string sClass = string.Empty;
                public bool IsActive = true;
                public bool IsInstant = false;

                public Action(string sTrigger, string sAction, int iFileId, int iFileRow, bool bIgnoreCase, bool bIsEvalAction, string sClass, bool bIsActive, bool bIsInstant)
                {
                    action = sAction;
                    this.iFileId = iFileId;
                    this.iFileRow = iFileRow;
                    IgnoreCase = bIgnoreCase;
                    IsEvalAction = bIsEvalAction;
                    this.sClass = sClass;
                    IsActive = bIsActive;
                    IsInstant = bIsInstant;
                    if (bIsEvalAction == false)
                    {
                        if (bIgnoreCase == true)
                        {
                            oRegExp = new Regex(sTrigger, MyRegexOptions.options | RegexOptions.IgnoreCase);
                        }
                        else
                        {
                            oRegExp = new Regex(sTrigger, MyRegexOptions.options);
                        }
                    }
                }
            }

            public bool Add(string sTrigger, string sAction, int iFileId, int iFileRow, bool bIgnoreCase = false, bool bIsEvalAction = false, bool bIsInstant = false)
            {
                if (sTrigger.StartsWith("e/") == true)
                {
                    sTrigger = sTrigger.Substring(2);
                    bIsEvalAction = true;
                }
                else if (sTrigger.ToLower().StartsWith("eval ") == true)
                {
                    sTrigger = sTrigger.Substring(5);
                    bIsEvalAction = true;
                }
                else if (sTrigger.StartsWith("/") == true)
                {
                    sTrigger = sTrigger.Substring(1);
                }

                if (sTrigger.EndsWith("/i") == true)
                {
                    bIgnoreCase = true;
                    sTrigger = sTrigger.Substring(0, sTrigger.Length - 2);
                }
                else if (sTrigger.EndsWith("/") == true)
                {
                    sTrigger = sTrigger.Substring(0, sTrigger.Length - 1);
                }

                if (bIsEvalAction == false)
                {
                    if (Utility.ValidateRegExp(sTrigger) == false)
                    {
                        return false;
                    }
                }

                bool bIsActive = true;
                string sClass = string.Empty;
                if (sAction.StartsWith("("))
                {
                    int I = sAction.IndexOf(")");
                    if (I > -1)
                    {
                        sClass = sAction.Substring(1, I - 1).ToLower().Trim();
                        sAction = sAction.Substring(I + 1).Trim();
                        if (ClassList.ContainsKey(sClass))
                        {
                            if (Conversions.ToBoolean(ClassList[sClass]) == false)
                            {
                                bIsActive = false;
                            }
                        }
                        else
                        {
                            ClassList.Add(sClass, true);
                        }
                    }
                }

                if (base.ContainsKey(sTrigger) == true)
                {
                    base[sTrigger] = new Action(sTrigger, sAction, iFileId, iFileRow, bIgnoreCase, bIsEvalAction, sClass, bIsActive, bIsInstant);
                }
                else
                {
                    base.Add(sTrigger, new Action(sTrigger, sAction, iFileId, iFileRow, bIgnoreCase, bIsEvalAction, sClass, bIsActive, bIsInstant));
                }

                return true;
            }

            public void Remove(string sText)
            {
                if (sText.StartsWith("e/") == true)
                {
                    sText = sText.Substring(2);
                }
                else if (sText.ToLower().StartsWith("eval ") == true)
                {
                    sText = sText.Substring(5);
                }
                else if (sText.StartsWith("/") == true)
                {
                    sText = sText.Substring(1);
                }

                if (sText.EndsWith("/i") == true)
                {
                    sText = sText.Substring(0, sText.Length - 2);
                }
                else if (sText.EndsWith("/") == true)
                {
                    sText = sText.Substring(0, sText.Length - 1);
                }

                if (base.ContainsKey(sText) == true)
                {
                    base.Remove(sText);
                }
            }

            public void SetClass(string name, bool status)
            {
                name = name.ToLower().Trim();
                if (!ClassList.ContainsKey(name))
                {
                    ClassList.Add(name, status);
                }

                foreach (Action a in Values)
                {
                    if ((a.sClass ?? "") == (name ?? ""))
                    {
                        a.IsActive = status;
                    }
                }
            }
        }

        public class ClassMatchList : ArrayList
        {
            public class Match
            {
                public string Text = string.Empty;
                public string Label = string.Empty;
                public bool IgnoreCase = false;
                public bool IsRegExp = false;
                public Regex RegexMatch = null;

                public Match(string sText, string sLabel, bool bIsRegExp, bool bIgnoreCase)
                {
                    Text = sText;
                    Label = sLabel;
                    IgnoreCase = bIgnoreCase;
                    IsRegExp = bIsRegExp;
                    if (IsRegExp == true)
                    {
                        if (bIgnoreCase == true)
                        {
                            RegexMatch = new Regex(sText, MyRegexOptions.options | RegexOptions.IgnoreCase);
                        }
                        else
                        {
                            RegexMatch = new Regex(sText, MyRegexOptions.options);
                        }
                    }
                }
            }

            public int Add(string sText, string sLabel, bool bIsRegExp = false, bool bIgnoreCase = false)
            {
                if (bIsRegExp)
                {
                    if (sText.StartsWith("/") == true)
                    {
                        sText = sText.Substring(1);
                    }

                    if (sText.EndsWith("/i") == true)
                    {
                        bIgnoreCase = true;
                        sText = sText.Substring(0, sText.Length - 2);
                    }
                    else if (sText.EndsWith("/") == true)
                    {
                        sText = sText.Substring(0, sText.Length - 1);
                    }
                }

                return base.Add(new Match(sText, sLabel, bIsRegExp, bIgnoreCase));
            }
        }

        public class ClassVariableList : SortedList
        {
            public void Add(string key, string value)
            {
                if (base.ContainsKey(key) == true)
                {
                    base[key] = value;
                }
                else
                {
                    base.Add(key, value);
                }
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private enum ScriptFunctions
        {
            action,
            blockend,
            blockstart,
            counter,
            delay,
            deletevariable,
            echo,
            elsefunc,
            elseiffunc,
            empty,
            eval,
            evalmath,
            exitfunc,
            gosubfunc,
            gotofunc,
            if_x,
            iffunc,
            include,
            label,
            match,
            matchre,
            matchwait,
            mathfunc,
            move,
            nextroom,
            pause,
            put,
            send,
            random,
            returnfunc,
            save,
            setvariable,
            shift,
            timer,
            wait,
            waitfor,
            waitforre,
            waiteval,
            whilefunc,
            debuglevel,
            js,
            jscall,
            jsblock,
            jsblockend,
            plugin,
            pluginscript
        }

        public enum ScriptState
        {
            finished,
            running,
            pausing,
            delayed,
            wait,
            waitfor,
            waiteval,
            move,
            matchwait,
            actionwait,
            actioninstant,
            scripterror
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        public event EventPrintErrorEventHandler EventPrintError;

        public delegate void EventPrintErrorEventHandler(string sText);

        public event EventPrintTextEventHandler EventPrintText;

        public delegate void EventPrintTextEventHandler(string sText, Color oColor, Color oBgColor);

        public event EventSendTextEventHandler EventSendText;

        public delegate void EventSendTextEventHandler(string sText, string sScript, bool bToQueue);

        public event EventDebugChangedEventHandler EventDebugChanged;

        public delegate void EventDebugChangedEventHandler(Script sender, int iLevel);

        public event EventStatusChangedEventHandler EventStatusChanged;

        public delegate void EventStatusChangedEventHandler(Script sender, ScriptState state);

        private Genie.Script.Eval m_oEval = new Genie.Script.Eval();
        private Genie.Script.MathEval m_oEvalMath = new Genie.Script.MathEval();
        private ArrayList m_oScript = new ArrayList();
        private ArrayList m_oScriptFiles = new ArrayList();
        private Hashtable m_oScriptLabels = new Hashtable();
        private CurrentLine m_oCurrentLine = new CurrentLine();
        private ClassVariableList m_oLocalVarList = new ClassVariableList();
        private ClassActionList m_oActions = new ClassActionList();
        private ClassMatchList m_oMatchList = new ClassMatchList();
        private ScriptState m_CurrentState = ScriptState.running;
        private string m_sFileName = string.Empty;
        private DateTime m_oPauseEnd;
        private bool m_bWaitForStringResume = true;
        private bool m_bWaitForStringIsRegExp = false;
        // private bool m_bWaitForStringIgnoreCase = false;
        private string m_sWaitForStringText = string.Empty;
        private Regex m_oWaitForRegex = null;
        private bool m_bWaitForMove = true;
        private bool m_bWaitForPrompt = true;
        private bool m_bWaitForMatch = true;
        private string m_sWaitForMatchLabel = string.Empty;
        private string m_sWaitForEventText = string.Empty;
        private bool m_bWaitForEvent = true;
        private DateTime m_oMatchTimeout;
        private bool m_bMatchTimeoutState = false;
        private DateTime m_oDelayEnd;
        private DateTime m_oWaitEnd;
        private static DateTime m_oBlankTimer = DateTime.Parse("0001-01-01");
        private DateTime m_oTimerStart = default;
        private DateTime m_oScriptStart = default;
        private double m_dTimerLastTime = 0;
        private bool m_bStopRunning = false;
        private bool m_bScriptDone = false;
        private bool m_bScriptPaused = false;
        private Genie.Globals m_oGlobals; // Global Values
        private object m_oThreadLock = new object(); // Thread safety
        private Genie.Script.Trace m_oTraceList = new Genie.Script.Trace();
        private DateTime m_oRoundTimeEnd = default;
        private int m_iDebugLevel = 0; // High number = More messages
        private bool m_bBufferEnd = true;
        private JintEngine m_JintEngine = null;

        // Allocating and unallocating is slow.
        private Match m_oRegMatch;

        public delegate void JsEchoDelegate(object oOut);

        public delegate void JsPutDelegate(object oText);

        public delegate object JsGetVariableDelegate(string sVar);

        public delegate void JsSetVariableDelegate(string sVar, object sVal);

        public void InitJintEngine()
        {
            if (Information.IsNothing(m_JintEngine))
            {
                m_JintEngine = new JintEngine();
                m_JintEngine.SetFunction("echo", new JsEchoDelegate(JsEchoText));
                m_JintEngine.SetFunction("put", new JsPutDelegate(JsSendText));
                m_JintEngine.SetFunction("getGlobal", new JsGetVariableDelegate(JsGetGlobalVariable));
                m_JintEngine.SetFunction("getVar", new JsGetVariableDelegate(JsGetVariable));
                m_JintEngine.SetFunction("setGlobal", new JsSetVariableDelegate(JsSetGlobalVariable));
                m_JintEngine.SetFunction("setVar", new JsSetVariableDelegate(JsSetVariable));
            }
        }

        private void JsEchoText(object o)
        {
            if (Information.IsNothing(o))
            {
                PrintEcho("undefined");
            }
            else
            {
                string str = o.GetType().ToString();
                PrintEcho(o.ToString());
            }
        }

        private void JsSendText(object o)
        {
            if (!Information.IsNothing(o))
            {
                SendText(o.ToString());
            }
        }

        private string JsGetGlobalVariable(string sVar)
        {
            if (Information.IsNothing(sVar))
            {
                return "undefined";
            }

            return GetVariable(sVar).ToString();
        }

        private string JsGetVariable(string sVar)
        {
            if (Information.IsNothing(sVar))
            {
                return "undefined";
            }

            if (m_oLocalVarList.ContainsKey(sVar))
            {
                return m_oLocalVarList[sVar].ToString();
            }

            return "undefined";
        }

        private void JsSetGlobalVariable(string sVar, object sVal)
        {
            if (!Information.IsNothing(sVar) & !Information.IsNothing(sVal))
            {
                if (m_oGlobals.VariableList.ContainsKey(sVar))
                {
                    m_oGlobals.VariableList[sVar] = sVal;
                }
                else
                {
                    string argvalue = Conversions.ToString(sVal);
                    m_oGlobals.VariableList.Add(sVar, argvalue);
                }
            }
        }

        private void JsSetVariable(string sVar, object sVal)
        {
            if (!Information.IsNothing(sVar) & !Information.IsNothing(sVal))
            {
                AddLocalVariable(sVar, Conversions.ToString(sVal));
            }
        }

        private void JsPause(double dPauseMS)
        {
            EvalPauseScript(dPauseMS);
        }

        public int DebugLevel
        {
            get
            {
                return m_iDebugLevel;
            }

            set
            {
                m_iDebugLevel = value;
                var script = this;
                EventDebugChanged?.Invoke(script, value);
            }
        }

        public bool ScriptPaused
        {
            get
            {
                return m_bScriptPaused;
            }

            set
            {
                m_bScriptPaused = value;
            }
        }

        public bool ScriptDone
        {
            get
            {
                return m_bScriptDone;
            }

            set
            {
                m_bScriptDone = value;
            }
        }

        public string State
        {
            get
            {
                var switchExpr = m_CurrentState;
                switch (switchExpr)
                {
                    case ScriptState.actionwait:
                    case ScriptState.actioninstant:
                        {
                            return "ActionWait";
                        }

                    case ScriptState.delayed:
                        {
                            return "Delayed";
                        }

                    case ScriptState.finished:
                        {
                            return "Finished";
                        }

                    case ScriptState.matchwait:
                        {
                            return "MatchWait";
                        }

                    case ScriptState.move:
                        {
                            return "Move";
                        }

                    case ScriptState.pausing:
                        {
                            return "Pausing";
                        }

                    case ScriptState.running:
                        {
                            return "Running";
                        }

                    case ScriptState.scripterror:
                        {
                            return "ScriptError";
                        }

                    case ScriptState.wait:
                        {
                            return "Wait";
                        }

                    case ScriptState.waitfor:
                        {
                            return "WaitFor";
                        }

                    case ScriptState.waiteval:
                        {
                            return "WaitForEvent";
                        }

                    default:
                        {
                            return "Unknown";
                        }
                }
            }
        }

        public ScriptState StateType
        {
            get
            {
                return m_CurrentState;
            }
        }

        public string ScriptName
        {
            get
            {
                if (m_oLocalVarList.ContainsKey("scriptname"))
                {
                    return Conversions.ToString(m_oLocalVarList["scriptname"]);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string TraceList
        {
            get
            {
                return m_oTraceList.ToString();
            }
        }

        public string VariableList
        {
            get
            {
                string sVariableList = string.Empty;
                foreach (DictionaryEntry de in m_oLocalVarList)
                    sVariableList += de.Key.ToString() + "=" + de.Value.ToString() + Constants.vbNewLine;
                return sVariableList;
            }
        }

        public string FileName
        {
            get
            {
                return m_sFileName;
            }
        }

        public string ScriptID
        {
            get
            {
                return m_sScriptID;
            }

            set
            {
                m_sScriptID = value;
            }
        }

        public double RunTimeSeconds
        {
            get
            {
                var argoDateEnd = DateTime.Now;
                return Utility.GetTimeDiffInMilliseconds(m_oScriptStart, argoDateEnd) / 1000;
            }
        }

        private string m_sScriptID = string.Empty;

        public Script(Genie.Globals cl)
        {
            m_oGlobals = cl;
            ScriptID = Guid.NewGuid().ToString();
        }

        // Public Shared Operator =(ByVal lsc As ClassScript, ByVal rsc As ClassScript) As Boolean
        // If lsc.ScriptID = rsc.ScriptID Then
        // Return True
        // Else
        // Return False
        // End If
        // End Operator
        // Public Shared Operator <>(ByVal lsc As ClassScript, ByVal rsc As ClassScript) As Boolean
        // If lsc.ScriptID <> rsc.ScriptID Then
        // Return True
        // Else
        // Return False
        // End If
        // End Operator

        public void SetRoundTime(int iTime)
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (iTime > 0)
                    {
                        m_oRoundTimeEnd = DateTime.Now.AddMilliseconds(iTime * 1000 + m_oGlobals.Config.dRTOffset * 1000);
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        public void SetBufferEnd()
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (m_bBufferEnd == false)
                    {
                        m_bBufferEnd = true;
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        public void PauseScript()
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (ScriptPaused == false)
                    {
                        m_bScriptPaused = true;
                        PrintText("[Script paused: " + m_sFileName + "]");
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }

            EventStatusChanged?.Invoke(this, ScriptState.pausing);
        }

        public void ResumeScript()
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (m_bScriptPaused == true)
                    {
                        PrintText("[Script resumed: " + m_sFileName + "]");
                        m_bScriptPaused = false;
                        if (m_CurrentState == ScriptState.running)
                        {
                            RunScript();
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }

            EventStatusChanged?.Invoke(this, ScriptState.running);
        }

        public void AbortOnScriptError()
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (m_CurrentState != ScriptState.scripterror & m_oScriptLabels.Contains("scripterror") == true)
                    {
                        PrintText("[Script moving to scripterror label (" + m_sFileName + ")]");
                        m_oCurrentLine.ClearBlocks(); // Remove all {} depth on goto
                        m_CurrentState = ScriptState.scripterror;
                    }
                    else
                    {
                        AbortScript();
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        public void AbortScript()
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (m_CurrentState != ScriptState.finished)
                    {
                        if (m_sFileName.Length > 0)
                        {
                            string sRunTime = string.Empty;
                            if (RunTimeSeconds < 10)
                            {
                                sRunTime = string.Format("{0:F2}", RunTimeSeconds);
                            }
                            else
                            {
                                sRunTime = string.Format("{0:F0}", RunTimeSeconds);
                            }

                            PrintText("[Script aborted! (Run time: " + sRunTime + " seconds): " + m_sFileName + "]");
                        }

                        ScriptDone = true;
                        ClearScript();
                        m_CurrentState = ScriptState.finished;
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }

            EventStatusChanged?.Invoke(this, ScriptState.finished);
        }

        public void TriggerParse(string text, bool bBufferWait = true)
        {
            if (ScriptPaused == true | ScriptDone == true)
            {
                return;
            }

            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (text.Trim().Length == 0)
                    {
                        return;
                    }

                    try
                    {
                        if (m_bWaitForStringResume == false)
                        {
                            if (m_bWaitForStringIsRegExp == false)
                            {
                                if (text.Contains(m_sWaitForStringText))
                                {
                                    m_bWaitForStringResume = true;
                                    if (bBufferWait)
                                        SetBufferWait();
                                }
                            }
                            else if (!Information.IsNothing(m_oWaitForRegex))
                            {
                                m_oRegMatch = m_oWaitForRegex.Match(text.Trim());
                                if (m_oRegMatch.Success == true)
                                {
                                    if (m_oRegMatch.Groups.Count > 0)
                                    {
                                        m_oCurrentLine.ArgList.Clear();
                                        int J;
                                        var loopTo = m_oRegMatch.Groups.Count - 1;
                                        for (J = 0; J <= loopTo; J++)
                                            m_oCurrentLine.ArgList.Add(m_oRegMatch.Groups[J].Value);
                                    }

                                    m_bWaitForStringResume = true;
                                    if (bBufferWait)
                                        SetBufferWait();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        GenieError.Error("Script WaitFor", ex.Message, ex.ToString());
                    }

                    try
                    {
                        if (m_CurrentState == ScriptState.matchwait)
                        {
                            foreach (ClassMatchList.Match ml in m_oMatchList)
                            {
                                if (ml.IsRegExp == false)
                                {
                                    if (text.Contains(ml.Text) == true)
                                    {
                                        m_sWaitForMatchLabel = ml.Label.ToLower();
                                        m_bWaitForMatch = true;
                                        if (bBufferWait)
                                            SetBufferWait();
                                        m_oMatchList.Clear();
                                        break;
                                    }
                                }
                                else if (!Information.IsNothing(ml.RegexMatch))
                                {
                                    m_oRegMatch = ml.RegexMatch.Match(text.Trim());
                                    if (m_oRegMatch.Success == true)
                                    {
                                        if (m_oRegMatch.Groups.Count > 0)
                                        {
                                            m_oCurrentLine.ArgList.Clear();
                                            int J;
                                            var loopTo1 = m_oRegMatch.Groups.Count - 1;
                                            for (J = 0; J <= loopTo1; J++)
                                                m_oCurrentLine.ArgList.Add(m_oRegMatch.Groups[J].Value);
                                        }

                                        m_sWaitForMatchLabel = ml.Label.ToLower();
                                        m_bWaitForMatch = true;
                                        if (bBufferWait)
                                            SetBufferWait();
                                        m_oMatchList.Clear();
                                        break;
                                    }
                                }

                                if (ScriptDone == true)
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        GenieError.Error("Script MatchWait", ex.Message, ex.ToString());
                    }

                    try
                    {
                        foreach (DictionaryEntry de in m_oActions)
                        {
                            if (((ClassActionList.Action)de.Value).IsActive == true)
                            {
                                if (((ClassActionList.Action)de.Value).IsEvalAction == false)
                                {
                                    m_oRegMatch = ((ClassActionList.Action)de.Value).oRegExp.Match(text);
                                    if (m_oRegMatch.Success == true)
                                    {
                                        var ActionRegExpArg = new ArrayList();
                                        if (m_oRegMatch.Groups.Count > 0)
                                        {
                                            int J;
                                            var loopTo2 = m_oRegMatch.Groups.Count - 1;
                                            for (J = 1; J <= loopTo2; J++)
                                                ActionRegExpArg.Add(m_oRegMatch.Groups[J].Value);
                                        }

                                        ParseAction(de.Key.ToString(), ActionRegExpArg, text);
                                    }
                                }
                            }

                            if (ScriptDone == true)
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        GenieError.Error("Script Action", ex.Message, ex.ToString());
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        private string EvalString(string sText, Genie.Globals oGlobals, [Optional, DefaultParameterValue(0)] int iFileId, [Optional, DefaultParameterValue(0)] int iFileRow)
        {
            if (DebugLevel > 0 & m_oGlobals.Config.bIgnoreScriptWarnings == false)
            {
                if (sText.Contains("%"))
                {
                    PrintError("Eval (" + sText + ") contains variable character '%'. Did you use an unassigned variable?", iFileId, iFileRow);
                }
                else if (sText.Contains("$"))
                {
                    PrintError("Eval (" + sText + ") contains variable character '$'. Did you use an unassigned variable?", iFileId, iFileRow);
                }
            }

            return m_oEval.EvalString(sText, oGlobals);
        }

        private bool Eval(string sText, Genie.Globals oGlobals, [Optional, DefaultParameterValue(0)] int iFileId, [Optional, DefaultParameterValue(0)] int iFileRow)
        {
            if (DebugLevel > 0 & m_oGlobals.Config.bIgnoreScriptWarnings == false)
            {
                if (sText.Contains("%"))
                {
                    PrintError("Eval (" + sText + ") contains variable character '%'. Did you use an unassigned variable?", iFileId, iFileRow);
                }
                else if (sText.Contains("$"))
                {
                    PrintError("Eval (" + sText + ") contains variable character '$'. Did you use an unassigned variable?", iFileId, iFileRow);
                }
            }

            return m_oEval.DoEval(sText, oGlobals);
        }

        public void TriggerVariableChanged(string sVariableName) // When variables change
        {
            if (ScriptPaused == true)
            {
                return;
            }

            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    foreach (DictionaryEntry de in m_oActions)
                    {
                        if (((ClassActionList.Action)de.Value).IsEvalAction == true)
                        {
                            if (((ClassActionList.Action)de.Value).IsActive == true)
                            {
                                if (de.Key.ToString().Contains(sVariableName))
                                {
                                    string s = "1";
                                    // If the command isn't an eval. Simply trigger it without checking.
                                    if ((de.Key.ToString() ?? "") != (sVariableName ?? ""))
                                    {
                                        int argiFileId = 0;
                                        int argiFileRow = 0;
                                        s = EvalString(ParseVariables(de.Key.ToString()), m_oGlobals, iFileId: argiFileId, iFileRow: argiFileRow);
                                    }

                                    if (s.Length > 0 & (s ?? "") != "0")
                                    {
                                        ParseAction(de.Key.ToString(), new ArrayList(), sVariableName);
                                        if (m_oActions.Count == 0) // Script Aborted
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        if (ScriptDone == true)
                            break;
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }

                if (m_bWaitForEvent == false)
                {
                    if (m_sWaitForEventText.Contains(sVariableName))
                    {
                        string s = "1";
                        // If the command isn't an eval. Simply trigger it without checking.
                        if ((m_sWaitForEventText ?? "") != (sVariableName ?? ""))
                        {
                            int argiFileId1 = 0;
                            int argiFileRow1 = 0;
                            s = EvalString(ParseVariables(m_sWaitForEventText), m_oGlobals, iFileId: argiFileId1, iFileRow: argiFileRow1);
                        }

                        if (s.Length > 0 & (s ?? "") != "0")
                        {
                            m_bWaitForEvent = true;
                        }
                    }
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        public void TriggerMove()
        {
            if (ScriptPaused == true)
            {
                return;
            }

            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (m_bWaitForMove == false)
                    {
                        m_bWaitForMove = true;
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        public void TriggerPrompt()
        {
            if (ScriptPaused == true)
            {
                return;
            }

            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (m_bWaitForPrompt == false)
                    {
                        m_bWaitForPrompt = true;
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        public void TickScript() // Called every X milliseconds in a separate thread
        {
            if (ScriptPaused == true | ScriptDone == true)
            {
                return;
            }

            if (Monitor.TryEnter(m_oThreadLock))
            {
                try
                {
                    if (m_CurrentState == ScriptState.scripterror)
                    {
                        m_CurrentState = ScriptState.running;
                        RunScript(Conversions.ToInteger(m_oScriptLabels["scripterror"]));
                        return;
                    }

                    if (m_CurrentState != ScriptState.delayed & m_CurrentState != ScriptState.actioninstant)
                    {
                        if (DateTime.Now < m_oRoundTimeEnd)
                        {
                            return;
                        }
                    }

                    if (m_CurrentState == ScriptState.pausing)
                    {
                        if (DateTime.Now >= m_oPauseEnd)
                        {
                            int argiLevel = 20;
                            string argsText = "Resume ScriptState.Pausing";
                            int argiFileId = 0;
                            int argiFileRow = 0;
                            PrintDebug(argiLevel, argsText, iFileId: argiFileId, iFileRow: argiFileRow);
                            RunScript();
                        }
                    }
                    else if (m_CurrentState == ScriptState.delayed)
                    {
                        if (DateTime.Now >= m_oDelayEnd)
                        {
                            int argiLevel9 = 20;
                            string argsText9 = "Resume ScriptState.Delayed";
                            int argiFileId10 = 0;
                            int argiFileRow10 = 0;
                            PrintDebug(argiLevel9, argsText9, iFileId: argiFileId10, iFileRow: argiFileRow10);
                            RunScript();
                        }
                    }
                    else if (m_CurrentState == ScriptState.wait)
                    {
                        if (m_bWaitForPrompt == true & DateTime.Now >= m_oWaitEnd)
                        {
                            int argiLevel8 = 20;
                            string argsText8 = "Resume ScriptState.Wait";
                            int argiFileId9 = 0;
                            int argiFileRow9 = 0;
                            PrintDebug(argiLevel8, argsText8, iFileId: argiFileId9, iFileRow: argiFileRow9);
                            RunScript();
                        }
                    }
                    else if (m_CurrentState == ScriptState.waitfor)
                    {
                        if (m_bWaitForStringResume == true & m_bBufferEnd == true)
                        {
                            int argiLevel7 = 20;
                            string argsText7 = "Resume ScriptState.WaitFor";
                            int argiFileId8 = 0;
                            int argiFileRow8 = 0;
                            PrintDebug(argiLevel7, argsText7, iFileId: argiFileId8, iFileRow: argiFileRow8);
                            RunScript();
                        }
                    }
                    else if (m_CurrentState == ScriptState.waiteval)
                    {
                        if (m_bWaitForEvent == true)
                        {
                            int argiLevel6 = 20;
                            string argsText6 = "Resume ScriptState.WaitForEvent";
                            int argiFileId7 = 0;
                            int argiFileRow7 = 0;
                            PrintDebug(argiLevel6, argsText6, iFileId: argiFileId7, iFileRow: argiFileRow7);
                            RunScript();
                        }
                    }
                    else if (m_CurrentState == ScriptState.move)
                    {
                        if (m_bWaitForMove == true)
                        {
                            int argiLevel5 = 20;
                            string argsText5 = "Resume ScriptState.Move";
                            int argiFileId6 = 0;
                            int argiFileRow6 = 0;
                            PrintDebug(argiLevel5, argsText5, iFileId: argiFileId6, iFileRow: argiFileRow6);
                            RunScript();
                            m_bWaitForMove = false;
                        }
                    }
                    else if (m_CurrentState == ScriptState.matchwait)
                    {
                        if (m_bWaitForMatch == true & m_bBufferEnd == true)
                        {
                            m_oMatchList.Clear();
                            if (m_oScriptLabels.ContainsKey(m_sWaitForMatchLabel) == true)
                            {
                                int argiLevel2 = 20;
                                string argsText2 = "Resume ScriptState.MatchWait";
                                int argiFileId2 = 0;
                                int argiFileRow2 = 0;
                                PrintDebug(argiLevel2, argsText2, iFileId: argiFileId2, iFileRow: argiFileRow2);
                                m_oLocalVarList.Add("lastlabel", m_sWaitForMatchLabel);
                                TriggerVariableChanged("%lastlabel");
                                m_oTraceList.Add("match " + m_sWaitForMatchLabel, GetFileName());
                                int argiLevel3 = 2;
                                string argsText3 = "match goto " + m_sWaitForMatchLabel;
                                int argiFileId3 = 0;
                                int argiFileRow3 = 0;
                                PrintDebug(argiLevel3, argsText3, iFileId: argiFileId3, iFileRow: argiFileRow3);
                                m_oCurrentLine.ClearBlocks(); // Remove all {} depth on goto
                                RunScript(Conversions.ToInteger(m_oScriptLabels[m_sWaitForMatchLabel]));
                            }
                            else
                            {
                                int argiFileId4 = 0;
                                int argiFileRow4 = 0;
                                PrintError("Unknown label from MATCH command: " + m_sWaitForMatchLabel, iFileId: argiFileId4, iFileRow: argiFileRow4);
                                AbortOnScriptError();
                            }

                            m_bWaitForMatch = false;
                        }
                        else if (m_bMatchTimeoutState == true)
                        {
                            if (DateTime.Now >= m_oMatchTimeout) // We have a timeout
                            {
                                int argiLevel4 = 2;
                                string argsText4 = "matchwait TIMEOUT!";
                                int argiFileId5 = 0;
                                int argiFileRow5 = 0;
                                PrintDebug(argiLevel4, argsText4, iFileId: argiFileId5, iFileRow: argiFileRow5);
                                m_oTraceList.Add("matchwait timeout", GetFileName());
                                // PrintText("MatchWait Timeout")
                                m_oMatchList.Clear();
                                m_bMatchTimeoutState = false;
                                RunScript();
                            }
                        }
                    }
                    else if (m_CurrentState == ScriptState.actionwait | m_CurrentState == ScriptState.actioninstant) // So PUT #parse works
                    {
                        int argiLevel1 = 20;
                        string argsText1 = "Resume ScriptState.ActionWait";
                        int argiFileId1 = 0;
                        int argiFileRow1 = 0;
                        PrintDebug(argiLevel1, argsText1, iFileId: argiFileId1, iFileRow: argiFileRow1);
                        m_bStopRunning = false;
                        RunScript();
                    }
                }
                /* TODO ERROR: Skipped IfDirectiveTrivia */
                catch (Exception ex)
                {
                    GenieError.Error("TickScript", ex.Message, ex.ToString());
                }
                /* TODO ERROR: Skipped EndIfDirectiveTrivia */
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
        }

        public void PrintScript() // Not in use
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    foreach (ScriptLine oLine in m_oScript)
                        PrintText(oLine.iFileId + "(" + oLine.iFileRow + "): " + oLine.sRowContent);
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        public string GetFileAndRow(int iFileId, int iFileRow)
        {
            return m_oScriptFiles[iFileId].ToString() + "(" + iFileRow.ToString() + ")";
        }

        private bool bJSBlock = false;
        private string sJSBlockContent = string.Empty;
        private int iJsBlockLine = 0;
        private int iJsFileId = 0;

        public void RunScript(int iArrayIndex = -1)
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    var oTimerStart = DateTime.Now;
                    if (m_CurrentState != ScriptState.scripterror)
                    {
                        m_CurrentState = ScriptState.running;
                    }

                    if (iArrayIndex == -1)
                    {
                        iArrayIndex = m_oCurrentLine.LineValue;
                    }

                    for (int I = iArrayIndex, loopTo = m_oScript.Count; I <= loopTo; I++)
                    {
                        m_oCurrentLine.LineValue = I;
                        if (m_CurrentState != ScriptState.running)
                        {
                            break;
                        }
                        else if (ScriptPaused == true) // Running and paused
                        {
                            break;
                        }

                        if (I >= m_oScript.Count)
                        {
                            if (bJSBlock)
                            {
                                try
                                {
                                    RunJsblock(sJSBlockContent);
                                }
                                catch (JintException ex)
                                {
                                    PrintJSError(ex.Message, iJsFileId, iJsBlockLine);
                                    m_JintEngine = null;
                                    AbortOnScriptError();
                                    break;
                                }
                            }

                            string sRunTime = string.Empty;
                            if (RunTimeSeconds < 10)
                            {
                                sRunTime = string.Format("{0:F2}", RunTimeSeconds);
                            }
                            else
                            {
                                sRunTime = string.Format("{0:F0}", RunTimeSeconds);
                            }

                            PrintText("[Script finished (In " + sRunTime + " seconds): " + m_sFileName + "]");
                            ScriptDone = true;
                            ClearScript();
                            m_CurrentState = ScriptState.finished;
                            EventStatusChanged?.Invoke(this, ScriptState.finished);
                            break;
                        }

                        ScriptLine oLine = (ScriptLine)m_oScript[I];
                        int argiLevel = 15;
                        string argsText = oLine.sRowContent + " (" + oLine.oFunction.ToString() + ")";
                        int argiFileId = 0;
                        int argiFileRow = 0;
                        PrintDebug(argiLevel, argsText, iFileId: argiFileId, iFileRow: argiFileRow);
                        if (bJSBlock)
                        {
                            if (oLine.oFunction != ScriptFunctions.jsblock)
                            {
                                bJSBlock = false;
                                if (m_oCurrentLine.SkipBlock == false)
                                {
                                    try
                                    {
                                        if (sJSBlockContent.Length > 0)
                                        {
                                            RunJsblock(sJSBlockContent);
                                        }
                                    }
                                    catch (JintException ex)
                                    {
                                        PrintJSError(ex.Message, iJsFileId, iJsBlockLine);
                                        m_JintEngine = null;
                                        AbortOnScriptError();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                sJSBlockContent += oLine.sRowContent + Constants.vbNewLine;
                            }
                        }
                        else if (oLine.oFunction == ScriptFunctions.jsblock)
                        {
                            if (m_oCurrentLine.SkipBlock == false)
                            {
                                sJSBlockContent = oLine.sRowContent + Constants.vbNewLine;
                                iJsBlockLine = oLine.iFileRow;
                                iJsFileId = oLine.iFileId;
                            }

                            bJSBlock = true;
                        }

                        // Normal script row
                        if (oLine.oFunction != ScriptFunctions.jsblock)
                        {
                            var argoDateEnd = DateTime.Now;
                            if (Utility.GetTimeDiffInMilliseconds(oTimerStart, argoDateEnd) > m_oGlobals.Config.iScriptTimeout)
                            {
                                PrintText("[Script timeout in " + GetFileAndRow(oLine.iFileId, oLine.iFileRow) + ": Possible infinite loop.]");
                                PrintTrace();
                                ScriptDone = true;
                                ClearScript();
                                m_CurrentState = ScriptState.finished;
                                EventStatusChanged?.Invoke(this, ScriptState.finished);
                                break;
                            }

                            if (oLine.oFunction == ScriptFunctions.blockstart)
                            {
                                if (m_oCurrentLine.SkipBlock == true)
                                {
                                    if (m_oCurrentLine.TargetBlockDepthValue <= 0)
                                    {
                                        m_oCurrentLine.TargetBlockDepthValue = m_oCurrentLine.BlockCount;
                                    }
                                }

                                m_oCurrentLine.AddBlock();
                                m_oCurrentLine.LastRowWasEvaluation = false;
                            }
                            else if (oLine.oFunction == ScriptFunctions.blockend)
                            {
                                m_oCurrentLine.RemoveBlock();
                                if (m_oCurrentLine.SkipBlock == true)
                                {
                                    if (m_oCurrentLine.TargetBlockDepthValue >= m_oCurrentLine.BlockCount)
                                    {
                                        m_oCurrentLine.SkipBlock = false;
                                        m_oCurrentLine.TargetBlockDepthValue = 0;
                                    }
                                }
                            }

                            if (m_oCurrentLine.SkipBlock == false)
                            {
                                I = RunScriptRow(oLine, I);
                                if (m_bStopRunning == true) // Action altered this
                                {
                                    int argiLevel1 = 30;
                                    string argsText1 = "Aborting previous thread: " + oLine.sRowContent;
                                    int argiFileId1 = 0;
                                    int argiFileRow1 = 0;
                                    PrintDebug(argiLevel1, argsText1, iFileId: argiFileId1, iFileRow: argiFileRow1);
                                    m_bStopRunning = false;
                                    return;
                                }
                            }
                            // Just skip one line if no block was created
                            else if (m_oCurrentLine.LastRowWasEvaluation == true)
                            {
                                if (oLine.oFunction != ScriptFunctions.iffunc)
                                {
                                    m_oCurrentLine.SkipBlock = false;
                                }
                            }
                        }
                    }
                }

                /* TODO ERROR: Skipped IfDirectiveTrivia */
                catch (Exception ex)
                {
                    GenieError.Error("RunScript", ex.Message, ex.ToString());
                }
                /* TODO ERROR: Skipped EndIfDirectiveTrivia */
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }
        }

        private void PrintTrace()
        {
            PrintText("Trace follows:" + Constants.vbNewLine);
            PrintText(TraceList);
        }

        public bool LoadFile(string sFile, bool bClear = true)
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    if (bClear == true)
                    {
                        ClearScript();
                    }

                    m_sFileName = "";
                    if (AppendFile(sFile) == true)
                    {
                        m_sFileName = sFile;
                        if (m_sFileName.ToLower().EndsWith(".cmd"))
                        {
                            m_oLocalVarList["scriptname"] = m_sFileName.Substring(0, m_sFileName.Length - 4);
                        }
                        else
                        {
                            m_oLocalVarList["scriptname"] = m_sFileName;
                        }

                        PrintText("[Script loaded: " + m_sFileName + "]");
                        m_oScriptStart = DateTime.Now;
                        m_oTraceList.Clear();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }

            return default;
        }

        public bool LoadFile(string strFile, ArrayList al)
        {
            if (Monitor.TryEnter(m_oThreadLock, m_iDefaultTimeout))
            {
                try
                {
                    ClearScript();
                    string strAllArgs = string.Empty;
                    for (int i = 1, loopTo = al.Count - 1; i <= loopTo; i++)
                    {
                        m_oLocalVarList.Add(i.ToString(), al[i].ToString());
                        strAllArgs += al[i].ToString() + " ";
                    }

                    // Add empty values for non existing arguments up to 9
                    for (int i = al.Count; i <= 9; i++)
                        m_oLocalVarList.Add(i.ToString(), "");
                    m_oLocalVarList.Add("0", strAllArgs.TrimEnd());
                    m_oLocalVarList.Add("argcount", (al.Count - 1).ToString());
                    return LoadFile(strFile, false);
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // GenieError("Unable to aquire script thread lock.")
            }

            return default;
        }

        private void SetBufferWait()
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_oGlobals.VariableList["connected"], 1, false)))
            {
                m_bBufferEnd = false;
            }
        }

        private string GetFileName(int index = 0)
        {
            if (m_oScriptFiles.Count > 0)
            {
                if (index > 0 & (m_oScriptFiles[index].ToString() ?? "") != (m_sFileName ?? ""))
                {
                    return Conversions.ToString(m_oScriptFiles[index]);
                }
            }

            return string.Empty;
        }

        private void ParseAction(string sKey, ArrayList oArgs, string sTriggerText)
        {
            if (m_oActions.ContainsKey(sKey) == false)
            {
                throw new Exception("Invalid Key in ParseAction()");
            }

            int iFileId = ((ClassActionList.Action)m_oActions[sKey]).iFileId;
            int iFileRow = ((ClassActionList.Action)m_oActions[sKey]).iFileRow;
            bool bInstant = ((ClassActionList.Action)m_oActions[sKey]).IsInstant;
            int argiLevel = 5;
            string argsText = "action triggered: " + sKey;
            PrintDebug(argiLevel, argsText, iFileId, iFileRow);
            int argiLevel1 = 5;
            string argsText1 = "action commands: " + ((ClassActionList.Action)m_oActions[sKey]).action.ToString();
            PrintDebug(argiLevel1, argsText1, iFileId, iFileRow);
            foreach (string row in Utility.SafeSplit(((ClassActionList.Action)m_oActions[sKey]).action, m_oGlobals.Config.cSeparatorChar))
            {
                var sRow = row;
                if (sRow.StartsWith("%"))
                {
                    sRow = "setvariable " + sRow.Substring(1);
                    if (sRow.Contains(" = "))
                        sRow = sRow.Replace(" = ", " ");
                }

                if (sRow.StartsWith("$"))
                {
                    sRow = "put #var " + sRow.Substring(1);
                    if (sRow.Contains(" = "))
                        sRow = sRow.Replace(" = ", " ");
                }

                var oLine = new ScriptLine();
                oLine.iFileId = iFileId;
                oLine.iFileRow = iFileRow;
                oLine.oFunction = GetFunctionType(Utility.GetKeywordString(sRow));
                if (sRow.Contains("$") == true)
                {
                    sRow = sRow.Replace(@"\$", @"\¤");
                    for (int i = 0, loopTo = m_oGlobals.Config.iArgumentCount - 1; i <= loopTo; i++)
                    {
                        if (i > oArgs.Count - 1)
                        {
                            sRow = sRow.Replace("$" + (i + 1).ToString(), "");
                        }
                        else
                        {
                            sRow = sRow.Replace("$" + (i + 1).ToString(), oArgs[i].ToString().Replace("\"", ""));
                        }
                    }

                    sRow = sRow.Replace("$0", sTriggerText.Replace("\"", ""));
                    sRow = sRow.Replace(@"\¤", @"\$");
                }

                oLine.sRowContent = sRow;
                var switchExpr = oLine.oFunction;
                switch (switchExpr)
                {
                    case ScriptFunctions.iffunc:
                        {
                            int i = oLine.sRowContent.ToLower().IndexOf(" then ");
                            if (i == 0)
                            {
                                continue;
                            }

                            if (oLine.sRowContent.Length < 6)
                            {
                                continue;
                            }

                            string sEval = ParseVariables(oLine.sRowContent.Substring(0, i));
                            string sArgument = oLine.sRowContent.Substring(i + 6);
                            if (EvalIfStatement(Utility.GetArgumentString(sEval), iFileId, iFileRow) == true)
                            {
                                oLine.oFunction = GetFunctionType(Utility.GetKeywordString(sArgument));
                                oLine.sRowContent = sArgument;
                            }
                            else
                            {
                                continue;
                            }

                            break;
                        }

                    case ScriptFunctions.gosubfunc:
                        {
                            int argiFileId = 0;
                            int argiFileRow = 0;
                            PrintError("GOSUB is not allowed from an ACTION command!", iFileId: argiFileId, iFileRow: argiFileRow);
                            AbortOnScriptError();
                            return;
                        }

                    case ScriptFunctions.blockstart:
                        {
                            int argiFileId1 = 0;
                            int argiFileRow1 = 0;
                            PrintError("BLOCK START is not allowed from an ACTION command!", iFileId: argiFileId1, iFileRow: argiFileRow1);
                            AbortOnScriptError();
                            return;
                        }

                    case ScriptFunctions.blockend:
                        {
                            int argiFileId2 = 0;
                            int argiFileRow2 = 0;
                            PrintError("BLOCK END is not allowed from an ACTION command!", iFileId: argiFileId2, iFileRow: argiFileRow2);
                            AbortOnScriptError();
                            return;
                        }

                    case ScriptFunctions.returnfunc:
                        {
                            int argiFileId3 = 0;
                            int argiFileRow3 = 0;
                            PrintError("RETURN is not allowed from an ACTION command!", iFileId: argiFileId3, iFileRow: argiFileRow3);
                            AbortOnScriptError();
                            return;
                        }
                        // Case ScriptFunctions.gotofunc ' Do not wait for RT on action GOTO
                        // m_CurrentState = ScriptState.delayed
                }

                int iResult = RunScriptRow(oLine, -1);
                if (iResult > -1) // Goto
                {
                    int argiLevel2 = 1;
                    string argsText2 = "action goto: " + sKey;
                    PrintDebug(argiLevel2, argsText2, oLine.iFileId, oLine.iFileRow);
                    m_oTraceList.Add("action goto", GetFileName(oLine.iFileId), oLine.iFileRow);
                    m_bStopRunning = true;
                    if (bInstant)
                    {
                        m_CurrentState = ScriptState.actioninstant; // So we can abort previous script thread if any
                    }
                    else
                    {
                        m_CurrentState = ScriptState.actionwait;
                    } // So we can abort previous script thread if any
                      // Reset all depth in blocks
                    m_oCurrentLine.Clear();
                    m_oMatchList.Clear();
                    m_oCurrentLine.LineValue = iResult;
                    return;
                }
            }
        }

        private string GetVariable(string sVar)
        {
            if (m_oGlobals.VariableList.ContainsKey(sVar))
            {
                return Conversions.ToString(m_oGlobals.VariableList[sVar]);
            }

            return string.Empty;
        }

        private string ParseVariables(string sText)
        {
            if (sText.Contains("$") == true)
            {
                sText = sText.Replace(@"\$", @"\¤");
                for (int i = 0, loopTo = m_oGlobals.Config.iArgumentCount - 1; i <= loopTo; i++)
                {
                    if (i >= m_oCurrentLine.ArgList.Count)
                    {
                        sText = sText.Replace("$" + i.ToString(), "");
                    }
                    else
                    {
                        sText = sText.Replace("$" + i.ToString(), m_oCurrentLine.ArgList[i].ToString());
                    }
                }

                sText = sText.Replace("$argcount", (m_oCurrentLine.ArgList.Count - 1).ToString());
                sText = sText.Replace(@"\¤", "$");
            }

            if (sText.Contains("%") == true)
            {
                sText = sText.Replace(@"\%", @"\¤");
                sText = sText.Replace(@"\$", "/¤");

                // For Each de As DictionaryEntry In m_oLocalVarList
                // sText = sText.Replace("%" & de.Key.ToString, de.Value.ToString)
                // Next

                int p = sText.Length - 1;
                while (p >= 0)
                {
                    var switchExpr = sText.Substring(p, 1);
                    switch (switchExpr)
                    {
                        case "%":
                            {
                                if (p <= 0 || (sText.Substring(p - 1, 1) ?? "") != @"\")
                                {
                                    sText = sText.Substring(0, p) + ParseVariable(sText.Substring(p));
                                }

                                break;
                            }

                        case "$":
                            {
                                if (p <= 0 || (sText.Substring(p - 1, 1) ?? "") != @"\")
                                {
                                    sText = sText.Substring(0, p) + m_oGlobals.ParseVariable(sText.Substring(p));
                                }

                                break;
                            }
                    }

                    p -= 1;
                }

                sText = sText.Replace(@"\¤", "%");
                sText = sText.Replace("/¤", "$");
            }
            else
            {
                sText = m_oGlobals.ParseGlobalVars(sText);
            }

            if (sText.Contains("@") == true) // On the fly variables and RegExpArgs
            {
                var argoDateEnd = DateTime.Now;
                double d = Utility.GetTimeDiffInMilliseconds(m_oTimerStart, argoDateEnd);
                if (d > 0)
                {
                    sText = sText.Replace("@timer@", (d / 1000).ToString());
                }
                else
                {
                    sText = sText.Replace("@timer@", "0");
                }

                sText = m_oGlobals.ParseSpecialVariables(sText);
            }

            return sText;
        }

        private string ParseVariable(string Line)
        {
            if (Line.Length <= 1)
                return Line;

            // Remove first char ($)
            string sVar = Line.Substring(1);

            // Trim down string if there is a space
            int I = sVar.IndexOf(' ');
            if (I > -1)
            {
                sVar = sVar.Substring(0, I);
            }

            // Check if it's an array
            I = sVar.IndexOf('(');
            if (I > -1 && sVar.IndexOf(')') > -1)
            {
                if (m_oLocalVarList.ContainsKey(sVar.Substring(0, I)))
                {
                    int idx = 0;
                    if (int.TryParse(sVar.Substring(I + 1, sVar.IndexOf(')') - I - 1), out idx))
                    {
                        string sValue = Conversions.ToString(m_oLocalVarList[sVar.Substring(0, I)]);
                        var oArr = sValue.Split('|');
                        if (idx >= 0 && Information.UBound(oArr) >= idx)
                        {
                            return oArr[idx] + Line.Substring(Line.IndexOf(')') + 1);
                        }
                        else
                        {
                            // Invalid index - Return empty result and remainder string
                            return Line.Substring(Line.IndexOf(')') + 1);
                        }
                    }
                }
            }

            // Loop trough hashtable of variables starting with the longer words
            int p = sVar.Length;
            string sCurrent = string.Empty;
            while (p > 0)
            {
                sCurrent = sVar.Substring(0, p);
                if (sCurrent.Contains(Conversions.ToString('.')))
                {
                    if (sCurrent.ToLower().EndsWith(".length"))
                    {
                        if (m_oLocalVarList.ContainsKey(sVar.Substring(0, p - 7)))
                        {
                            return (Utility.Count(Conversions.ToString(m_oLocalVarList[sVar.Substring(0, p - 7)]), "|") + 1).ToString() + Line.Substring(p + 1);
                        }
                    }
                }

                if (m_oLocalVarList.ContainsKey(sCurrent))
                {
                    return Conversions.ToString(m_oLocalVarList[sCurrent] + Line.Substring(p + 1));
                }

                p -= 1;
            }

            return Line;
        }

        private int RunScriptRow(ScriptLine oLine, int iRowIndex)
        {
            string ParsedLine = ParseVariables(oLine.sRowContent);
            int argiLevel = 10;
            string argsText = "[" + ParsedLine + "]";
            PrintDebug(argiLevel, argsText, oLine.iFileId, oLine.iFileRow); // SHOW ALL LINES at 10
            var switchExpr = oLine.oFunction;
            switch (switchExpr)
            {
                case ScriptFunctions.echo:
                    {
                        PrintEcho(Utility.GetArgumentString(ParsedLine));
                        break;
                    }

                case ScriptFunctions.gotofunc:
                    {
                        int argiLevel1 = 1;
                        string argsText1 = "goto " + Utility.GetArgumentString(ParsedLine);
                        PrintDebug(argiLevel1, argsText1, oLine.iFileId, oLine.iFileRow);
                        string strLabel = Utility.GetArgumentString(ParsedLine).ToLower();
                        if (m_oScriptLabels.ContainsKey(strLabel) == true)
                        {
                            iRowIndex = Conversions.ToInteger(m_oScriptLabels[strLabel]);
                            m_oLocalVarList.Add("lastlabel", strLabel);
                            TriggerVariableChanged("%lastlabel");
                            m_oCurrentLine.ClearBlocks(); // Remove all {} depth on goto
                            m_oTraceList.Add("goto " + strLabel, GetFileName(oLine.iFileId), oLine.iFileRow);
                        }
                        else
                        {
                            PrintError("Unknown label from GOTO: " + strLabel, oLine.iFileId, oLine.iFileRow);
                            AbortOnScriptError();
                            return default;
                        }

                        break;
                    }

                case ScriptFunctions.gosubfunc:
                    {
                        int argiLevel2 = 1;
                        string argsText2 = "gosub " + Utility.GetArgumentString(ParsedLine);
                        PrintDebug(argiLevel2, argsText2, oLine.iFileId, oLine.iFileRow);
                        string strLabel = Utility.GetKeywordString(Utility.GetArgumentString(ParsedLine)).ToLower();
                        if ((strLabel ?? "") == "clear")
                        {
                            m_oCurrentLine.Clear();
                        }
                        else if (m_oScriptLabels.ContainsKey(strLabel) == true)
                        {
                            m_oTraceList.Add("gosub " + strLabel, GetFileName(oLine.iFileId), oLine.iFileRow);
                            m_oCurrentLine.AddJump(iRowIndex, Utility.GetArgumentString(Utility.GetArgumentString(ParsedLine)));
                            int argiLevel3 = 40;
                            string argsText3 = "Add jump (count = " + m_oCurrentLine.Count + ")";
                            PrintDebug(argiLevel3, argsText3, oLine.iFileId, oLine.iFileRow);
                            if (m_oCurrentLine.Count > m_oGlobals.Config.iMaxGoSubDepth)
                            {
                                PrintError("Maximum GOSUB depth (" + m_oGlobals.Config.iMaxGoSubDepth.ToString() + ") on: " + strLabel, oLine.iFileId, oLine.iFileRow);
                                PrintTrace();
                                AbortOnScriptError();
                                return default;
                            }

                            iRowIndex = Conversions.ToInteger(m_oScriptLabels[strLabel]);
                        }
                        else
                        {
                            PrintError("Unknown label from GOSUB: " + strLabel, oLine.iFileId, oLine.iFileRow);
                            AbortOnScriptError();
                            return default;
                        }

                        break;
                    }

                case ScriptFunctions.returnfunc:
                    {
                        if (m_oCurrentLine.RemoveJump() == true)
                        {
                            m_oTraceList.Add("return", GetFileName(oLine.iFileId), oLine.iFileRow);
                            int argiLevel4 = 1;
                            string argsText4 = "return";
                            PrintDebug(argiLevel4, argsText4, oLine.iFileId, oLine.iFileRow);
                            int argiLevel5 = 40;
                            string argsText5 = "Remove jump (count = " + m_oCurrentLine.Count + ")";
                            PrintDebug(argiLevel5, argsText5, oLine.iFileId, oLine.iFileRow);
                            iRowIndex = m_oCurrentLine.LineValue;
                        }
                        else
                        {
                            // Failed return
                            PrintError("RETURN command failed. There are no more gosub bookmarks to return to!", oLine.iFileId, oLine.iFileRow);
                            PrintTrace();
                            AbortOnScriptError();
                            return default;
                        }

                        break;
                    }

                case ScriptFunctions.label:
                    {
                        string sLabelName = Conversions.ToString(Interaction.IIf(oLine.sRowContent.Trim().EndsWith(":"), oLine.sRowContent.Trim().Substring(0, oLine.sRowContent.Trim().Length - 1), oLine.sRowContent.Trim()));
                        m_oTraceList.Add("passing label " + sLabelName, GetFileName(oLine.iFileId), oLine.iFileRow);
                        int argiLevel6 = 1;
                        string argsText6 = "passing label: " + sLabelName;
                        PrintDebug(argiLevel6, argsText6, oLine.iFileId, oLine.iFileRow);
                        if (m_oCurrentLine.BlockCount > 1)
                        {
                            PrintError("Passing a LABEL from within a script block is not allowed: " + sLabelName, oLine.iFileId, oLine.iFileRow);
                            AbortOnScriptError();
                            return default;
                        }

                        break;
                    }

                case ScriptFunctions.exitfunc:
                    {
                        iRowIndex = m_oScript.Count; // End Script
                        var argoDateEnd = DateTime.Now;
                        PrintText("[Script finished (In " + (Utility.GetTimeDiffInMilliseconds(m_oScriptStart, argoDateEnd) / 1000).ToString() + " seconds): " + GetFileAndRow(oLine.iFileId, oLine.iFileRow) + "]");
                        m_oTraceList.Add("exit", GetFileName(oLine.iFileId), oLine.iFileRow);
                        ScriptDone = true;
                        ClearScript();
                        m_CurrentState = ScriptState.finished;
                        EventStatusChanged?.Invoke(this, ScriptState.finished);
                        break;
                    }

                case ScriptFunctions.iffunc:
                    {
                        if (oLine.sRowContent.Trim().ToLower().EndsWith(" then") == true)
                        {
                            m_oCurrentLine.LastRowWasEvaluation = true;
                        }

                        if (EvalIfStatement(Utility.GetArgumentString(ParsedLine), oLine.iFileId, oLine.iFileRow) == true)
                        {
                            // Run "block"
                            m_oCurrentLine.BlockValue = CurrentLine.BlockState.evaltrue;
                        }
                        else
                        {
                            // Skip "block"
                            m_oCurrentLine.BlockValue = CurrentLine.BlockState.evalfalse;
                            m_oCurrentLine.SkipBlock = true;
                        }

                        break;
                    }

                case ScriptFunctions.whilefunc:
                    {
                        if (oLine.sRowContent.ToLower().EndsWith("do") == true)
                        {
                            m_oCurrentLine.LastRowWasEvaluation = true;
                        }

                        if (EvalWhileStatement(Utility.GetArgumentString(ParsedLine), oLine.iFileId, oLine.iFileRow) == true)
                        {
                            // Run "block"
                            m_oCurrentLine.BlockValue = CurrentLine.BlockState.evalwhiletrue;
                        }
                        else
                        {
                            // Skip "block"
                            m_oCurrentLine.BlockValue = CurrentLine.BlockState.evalwhilefalse;
                            m_oCurrentLine.SkipBlock = true;
                        }

                        break;
                    }

                case ScriptFunctions.elsefunc:
                    {
                        if (oLine.sRowContent.ToLower().EndsWith("else") == true)
                        {
                            m_oCurrentLine.LastRowWasEvaluation = true;
                        }

                        if (m_oCurrentLine.BlockValue == CurrentLine.BlockState.evaltrue)
                        {
                            // Skip "block"
                            m_oCurrentLine.SkipBlock = true;
                        }

                        m_oCurrentLine.BlockValue = CurrentLine.BlockState.noeval;
                        break;
                    }

                case ScriptFunctions.pause:
                    {
                        int argiLevel7 = 2;
                        string argsText7 = "pause " + Utility.GetArgumentString(ParsedLine);
                        PrintDebug(argiLevel7, argsText7, oLine.iFileId, oLine.iFileRow);
                        EvalPauseScript(Utility.EvalDoubleTime(Utility.GetArgumentString(ParsedLine)));
                        break;
                    }

                case ScriptFunctions.delay:
                    {
                        int argiLevel8 = 2;
                        string argsText8 = "delay " + Utility.GetArgumentString(ParsedLine);
                        PrintDebug(argiLevel8, argsText8, oLine.iFileId, oLine.iFileRow);
                        EvalDelayScript(Utility.EvalDoubleTime(Utility.GetArgumentString(ParsedLine)));
                        break;
                    }

                case ScriptFunctions.wait:
                    {
                        int argiLevel9 = 2;
                        string argsText9 = "wait " + Utility.GetArgumentString(ParsedLine);
                        PrintDebug(argiLevel9, argsText9, oLine.iFileId, oLine.iFileRow);
                        EvalWait(Utility.EvalDoubleTime(Utility.GetArgumentString(ParsedLine)));
                        break;
                    }

                case ScriptFunctions.waitfor:
                    {
                        int argiLevel10 = 2;
                        string argsText10 = "waitfor " + Utility.GetArgumentString(ParsedLine);
                        PrintDebug(argiLevel10, argsText10, oLine.iFileId, oLine.iFileRow);
                        EvalWaitString(Utility.GetArgumentString(ParsedLine));
                        break;
                    }

                case ScriptFunctions.waiteval:
                    {
                        int argiLevel11 = 2;
                        string argsText11 = "waiteval " + Utility.GetArgumentString(oLine.sRowContent);
                        PrintDebug(argiLevel11, argsText11, oLine.iFileId, oLine.iFileRow);
                        EvalWaitEval(Utility.GetArgumentString(oLine.sRowContent));
                        break;
                    }

                case ScriptFunctions.waitforre:
                    {
                        int argiLevel12 = 2;
                        string argsText12 = "waitforre " + Utility.GetArgumentString(ParsedLine);
                        PrintDebug(argiLevel12, argsText12, oLine.iFileId, oLine.iFileRow);
                        if (EvalWaitString(Utility.GetArgumentString(ParsedLine), true) == false)
                        {
                            PrintError("Invalid RegExp in waitforre: " + Utility.GetArgumentString(ParsedLine), oLine.iFileId, oLine.iFileRow);
                            AbortOnScriptError();
                        }

                        break;
                    }

                case ScriptFunctions.move:
                    {
                        int argiLevel13 = 2;
                        string argsText13 = "waitformove " + Utility.GetArgumentString(ParsedLine);
                        PrintDebug(argiLevel13, argsText13, oLine.iFileId, oLine.iFileRow);
                        EvalMove(Utility.GetArgumentString(ParsedLine));
                        break;
                    }

                case ScriptFunctions.nextroom:
                    {
                        int argiLevel14 = 2;
                        string argsText14 = "nextroom";
                        PrintDebug(argiLevel14, argsText14, oLine.iFileId, oLine.iFileRow);
                        EvalMove(string.Empty);
                        break;
                    }

                case ScriptFunctions.put:
                    {
                        EvalPut(Utility.GetArgumentString(ParsedLine));
                        break;
                    }

                case ScriptFunctions.send:
                    {
                        EvalSend(Utility.GetArgumentString(ParsedLine));
                        break;
                    }

                case ScriptFunctions.save:
                    {
                        EvalSetvariableSave(Utility.GetArgumentString(ParsedLine));
                        break;
                    }

                case ScriptFunctions.setvariable:
                    {
                        EvalSetvariable(Utility.GetArgumentString(ParsedLine), oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.deletevariable:
                    {
                        EvalDeletevariable(Utility.GetArgumentString(ParsedLine), oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.match:
                    {
                        EvalMatch(Utility.GetArgumentString(ParsedLine));
                        break;
                    }

                case ScriptFunctions.matchre:
                    {
                        if (EvalMatch(Utility.GetArgumentString(ParsedLine), true) == false)
                        {
                            PrintError("Invalid RegExp in matchre: " + Utility.GetArgumentString(ParsedLine), oLine.iFileId, oLine.iFileRow);
                            AbortOnScriptError();
                        }

                        break;
                    }

                case ScriptFunctions.matchwait:
                    {
                        int argiLevel15 = 2;
                        string argsText15 = "matchwait";
                        PrintDebug(argiLevel15, argsText15, oLine.iFileId, oLine.iFileRow);
                        EvalMatchWait(Utility.EvalDoubleTime(Utility.GetArgumentString(ParsedLine), 0));
                        break;
                    }

                case ScriptFunctions.counter:
                    {
                        string argsText16 = Utility.GetArgumentString(ParsedLine);
                        EvalCounter(argsText16, oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.mathfunc:
                    {
                        string argsText17 = Utility.GetArgumentString(ParsedLine);
                        EvalMath(argsText17, oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.eval:
                    {
                        string argsText18 = Utility.GetArgumentString(ParsedLine);
                        EvalEval(argsText18, oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.evalmath:
                    {
                        string argsText19 = Utility.GetArgumentString(ParsedLine);
                        EvalEvalMath(argsText19, oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.action:
                    {
                        EvalAction(Utility.GetArgumentString(oLine.sRowContent), oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.random:
                    {
                        EvalRandom(Utility.GetKeywordString(Utility.GetArgumentString(ParsedLine)), Utility.GetKeywordString(Utility.GetArgumentString(Utility.GetArgumentString(ParsedLine))));
                        break;
                    }

                case ScriptFunctions.timer:
                    {
                        string argsText20 = Utility.GetArgumentString(oLine.sRowContent);
                        EvalTimer(argsText20, oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.shift:
                    {
                        EvalShift();
                        break;
                    }

                case ScriptFunctions.debuglevel:
                    {
                        string argsText21 = Utility.GetArgumentString(oLine.sRowContent);
                        EvalSetDebugLevel(argsText21, oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.js:
                    {
                        string argsText22 = Utility.GetArgumentString(oLine.sRowContent);
                        EvalJS(argsText22, oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.jscall:
                    {
                        string argsText23 = Utility.GetArgumentString(Utility.GetArgumentString(oLine.sRowContent));
                        string sResult = EvalJS(argsText23, oLine.iFileId, oLine.iFileRow);
                        EvalSetvariable(Utility.GetKeywordString(Utility.GetArgumentString(oLine.sRowContent)) + " " + sResult, oLine.iFileId, oLine.iFileRow);
                        break;
                    }

                case ScriptFunctions.plugin:
                    {
                        string argsText24 = Utility.GetArgumentString(Utility.GetArgumentString(oLine.sRowContent));
                        string sResult = EvalPlugin(argsText24, oLine.iFileId, oLine.iFileRow);
                        EvalSetvariable(Utility.GetKeywordString(Utility.GetArgumentString(oLine.sRowContent)) + " " + sResult, oLine.iFileId, oLine.iFileRow);
                        break;
                    }
            }

            return iRowIndex;
        }

        private string EvalJS(string sText, int iFileId, int iFileRow)
        {
            string sResult = "undefined";
            InitJintEngine();
            try
            {
                m_JintEngine.AllowClr = false;
                var oResult = m_JintEngine.Run(sText);
                if (!Information.IsNothing(oResult))
                {
                    sResult = oResult.ToString();
                }
            }
            catch (JintException ex)
            {
                PrintError(ex.Message, iFileId, iFileRow);
            }

            return sResult;
        }

        private string EvalPlugin(string sText, int iFileId, int iFileRow)
        {
            string sResult;
            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                if (oPlugin.Enabled)
                {
                    sResult = oPlugin.ParseInput("@script " + sText);
                    if ((sResult ?? "") != (sText ?? ""))
                        return sResult;
                }
            }

            return "undefined";
        }

        private string EvalPluginScript(string sText, int iFileId, int iFileRow)
        {
            string sResult;
            foreach (GeniePlugin.Interfaces.IPlugin oPlugin in m_oGlobals.PluginList)
            {
                if (oPlugin.Enabled)
                {
                    sResult = oPlugin.ParseText(sText, "PluginScript");
                    if ((sResult ?? "") != (sText ?? ""))
                        return sResult;
                }
            }

            return string.Empty;
        }

        private void EvalShift()
        {
            int I = Conversions.ToInteger(m_oLocalVarList["argcount"]);
            if (I > 0)
            {
                m_oLocalVarList["argcount"] = (I - 1).ToString();
                string sTemp = string.Empty;
                string sPrevious = "";
                string sPreviousTemp = "";
                while (I > 0)
                {
                    if (sPrevious.Length > 0)
                    {
                        sTemp = sPrevious + " " + sTemp;
                    }

                    sPreviousTemp = Conversions.ToString(m_oLocalVarList[I.ToString()]);
                    m_oLocalVarList[I.ToString()] = sPrevious;
                    sPrevious = sPreviousTemp;
                    I -= 1;
                }

                m_oLocalVarList["0"] = sTemp.Trim();
            }
        }

        private void EvalSetDebugLevel(string sText, int iFileId, int iFileRow)
        {
            DebugLevel = Utility.StringToInteger(sText);
        }

        private void EvalTimer(string sText, int iFileId, int iFileRow)
        {
            var switchExpr = Utility.GetKeywordString(sText).ToLower();
            switch (switchExpr)
            {
                case "start":
                    {
                        if (m_oTimerStart == m_oBlankTimer)
                        {
                            m_oTimerStart = DateTime.Now;
                            if (m_dTimerLastTime > 0)
                            {
                                m_oTimerStart = m_oTimerStart.AddMilliseconds(-m_dTimerLastTime);
                            }

                            m_oLocalVarList.Add("t", "@timer@");
                        }

                        break;
                    }

                case "stop":
                    {
                        if (m_oTimerStart != m_oBlankTimer)
                        {
                            var argoDateEnd = DateTime.Now;
                            m_dTimerLastTime = Utility.GetTimeDiffInMilliseconds(m_oTimerStart, argoDateEnd);
                            m_oTimerStart = default;
                            if (m_dTimerLastTime > 0)
                            {
                                m_oLocalVarList.Add("t", (m_dTimerLastTime / 1000).ToString());
                            }
                            else
                            {
                                m_oLocalVarList.Add("t", "0");
                            }
                        }
                        else
                        {
                            m_oLocalVarList.Add("t", "0");
                        }

                        break;
                    }

                case "setstart":
                    {
                        try
                        {
                            m_oTimerStart = DateTime.Parse(Utility.GetArgumentString(sText));
                            m_oLocalVarList.Add("t", "@timer@"); // set automatically "start" timer
                        }
                        #pragma warning disable CS0168
                        catch (Exception ex)
                        #pragma warning restore CS0168
                        {
                            PrintError("Invalid datetime format in TIMER SETSTART command: " + Utility.GetArgumentString(sText), iFileId, iFileRow);
                            AbortOnScriptError();
                        }

                        break;
                    }

                case "clear":
                    {
                        m_oTimerStart = default;
                        m_dTimerLastTime = 0;
                        m_oLocalVarList.Add("t", "0");
                        break;
                    }
            }
        }

        private void EvalRandom(string sMin, string sMax)
        {
            if (sMin.Length == 0)
            {
                sMin = "1";
            }

            if (sMax.Length == 0)
            {
                sMax = "10";
            }

            m_oLocalVarList.Add("r", Utility.RandomNumber(Utility.StringToInteger(sMin), Utility.StringToInteger(sMax)).ToString());
        }

        private void EvalAction(string sText, int iFileId, int iFileRow)
        {
            int i = -1;
            string key = string.Empty;
            if (sText.StartsWith("("))
            {
                i = sText.IndexOf(")");
                if (i > -1)
                {
                    string sClass = sText.Substring(1, i - 1).ToLower().Trim();
                    key = Utility.GetKeywordString(sText.Substring(i + 1).Trim());
                    var switchExpr = key.ToLower();
                    switch (switchExpr)
                    {
                        case "0":
                        case "off":
                        case "false":
                        case "inactivate":
                            {
                                m_oActions.SetClass(sClass, false);
                                int argiLevel = 4;
                                string argsText = "class off: " + sClass;
                                PrintDebug(argiLevel, argsText, iFileId, iFileRow);
                                return;
                            }

                        case "1":
                        case "on":
                        case "true":
                        case "activate":
                            {
                                m_oActions.SetClass(sClass, true);
                                int argiLevel1 = 4;
                                string argsText1 = "class on: " + sClass;
                                PrintDebug(argiLevel1, argsText1, iFileId, iFileRow);
                                return;
                            }
                    }
                }
            }

            bool bInstant = false;
            key = Utility.GetKeywordString(sText);
            var switchExpr1 = key.ToLower();
            switch (switchExpr1)
            {
                case "remove":
                    {
                        string argsText2 = Utility.GetArgumentString(sText);
                        m_oActions.Remove(argsText2);
                        return;
                    }

                case "clear":
                    {
                        m_oActions.Clear();
                        return;
                    }

                case "add":
                    {
                        sText = Utility.GetArgumentString(sText);
                        break;
                    }

                case "instant":
                    {
                        bInstant = true;
                        sText = Utility.GetArgumentString(sText);
                        break;
                    }
            }

            i = sText.ToLower().IndexOf(" when ");
            if (i > -1)
            {
                string sTrigger = sText.Substring(i + 6).Trim();
                if (sTrigger.ToLower().StartsWith("eval ") == false)
                {
                    sTrigger = ParseVariables(sTrigger);
                }

                string argsAction = sText.Substring(0, i);
                if (m_oActions.Add(sTrigger, argsAction, iFileId, iFileRow, false, false, bInstant) == false)
                {
                    PrintError("Invalid RegExp in action: " + sText, iFileId, iFileRow);
                    AbortOnScriptError();
                }
            }
            else
            {
                PrintError("Invalid ACTION command: " + sText, iFileId, iFileRow);
                AbortOnScriptError();
            }
        }

        private void EvalEvalMath(string sText, int iFileId, int iFileRow)
        {
            if ((Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator ?? "") != ".")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }

            string sVar = Utility.GetKeywordString(sText);
            if (sVar.Trim().Length == 0)
            {
                return;
            }

            double d = m_oEvalMath.Evaluate(Utility.GetArgumentString(sText));
            int argiLevel = 4;
            string argsText = "evalmath: " + sText;
            PrintDebug(argiLevel, argsText, iFileId, iFileRow);
            int argiLevel1 = 4;
            string argsText1 = "evalmath result: " + sVar + "=" + d.ToString();
            PrintDebug(argiLevel1, argsText1, iFileId, iFileRow);
            m_oLocalVarList.Add(sVar, d.ToString());
            TriggerVariableChanged("%" + sVar);
        }

        private void EvalEval(string sText, int iFileId, int iFileRow)
        {
            string sVar = Utility.GetKeywordString(sText);
            if (sVar.Trim().Length == 0)
            {
                return;
            }

            string s = EvalString(Utility.GetArgumentString(sText), m_oGlobals, iFileId, iFileRow);
            if (m_oEval.ResultList.Count > 0)
            {
                m_oCurrentLine.ArgList = m_oEval.ResultList;
            }

            int argiLevel = 4;
            string argsText = "eval: " + sText;
            PrintDebug(argiLevel, argsText, iFileId, iFileRow);
            int argiLevel1 = 4;
            string argsText1 = "eval result: " + sVar + "=" + s;
            PrintDebug(argiLevel1, argsText1, iFileId, iFileRow);
            m_oLocalVarList.Add(sVar, s);
            TriggerVariableChanged("%" + sVar);
        }

        private void EvalMath(string sText, int iFileId, int iFileRow)
        {
            string sVar = Utility.GetKeywordString(sText);
            if (sVar.Trim().Length == 0)
            {
                return;
            }

            int argiLevel = 4;
            string argsText = "math: " + sText;
            PrintDebug(argiLevel, argsText, iFileId, iFileRow);
            string argsText1 = Utility.GetArgumentString(sText);
            DoMath(sVar, argsText1, iFileId, iFileRow);
        }

        private void DoMath(string sVar, string sText, int iFileId, int iFileRow)
        {
            double d = 0;
            if (m_oLocalVarList.ContainsKey(sVar) == true)
            {
                string argsValue = Conversions.ToString(m_oLocalVarList[sVar]);
                d = Utility.StringToDouble(argsValue);
            }

            d = DoMathCalc(d, sText, iFileId, iFileRow);
            int argiLevel = 4;
            string argsText = "math result: " + sVar + "=" + d.ToString();
            PrintDebug(argiLevel, argsText, iFileId, iFileRow);
            m_oLocalVarList.Add(sVar, d.ToString());
            TriggerVariableChanged("%" + sVar);
        }

        private void EvalCounter(string sText, int iFileId, int iFileRow)
        {
            int argiLevel = 4;
            string argsText = "counter: " + sText;
            PrintDebug(argiLevel, argsText, iFileId, iFileRow);
            string argsVar = "c";
            DoMath(argsVar, sText, iFileId, iFileRow);
        }

        private double DoMathCalc(double dValue, string sExpression, int iFileId, int iFileRow)
        {
            try
            {
                return Utility.MathCalc(dValue, sExpression);
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                PrintError("Invalid MATH expression: " + sExpression, iFileId, iFileRow);
                AbortOnScriptError();
                return 0;
            }
        }

        private void EvalMatchWait(double dPauseMS)
        {
            if (dPauseMS > 0) // Timeout Value Supplied
            {
                m_oMatchTimeout = DateTime.Now.AddMilliseconds(dPauseMS);
                m_bMatchTimeoutState = true;
            }
            else
            {
                m_bMatchTimeoutState = false;
            }

            m_bWaitForMatch = false;
            m_CurrentState = ScriptState.matchwait;
        }

        private bool EvalMatch(string sText, bool bIsRegExp = false)
        {
            if ((sText.ToLower() ?? "") == "clear")
            {
                m_oMatchList.Clear();
                return true;
            }

            if (bIsRegExp == true && Utility.ValidateRegExp(sText) == false)
            {
                return false;
            }

            m_oMatchList.Add(Utility.GetArgumentString(sText).Trim(), Utility.GetKeywordString(sText).Trim(), bIsRegExp);
            return true;
        }

        private void EvalPauseScript(double dPauseMS)
        {
            m_CurrentState = ScriptState.pausing;
            m_oPauseEnd = DateTime.Now.AddMilliseconds(dPauseMS);
        }

        private void EvalDelayScript(double dPauseMS)
        {
            m_CurrentState = ScriptState.delayed;
            m_oDelayEnd = DateTime.Now.AddMilliseconds(dPauseMS);
        }

        private void EvalWait(double dPauseMS)
        {
            m_bWaitForPrompt = false;
            m_CurrentState = ScriptState.wait;
            if (dPauseMS > 0)
            {
                m_oWaitEnd = DateTime.Now.AddMilliseconds(dPauseMS);
            }
            else
            {
                m_oWaitEnd = DateTime.Now;
            }
        }

        private bool EvalWaitString(string sText, bool bIsRegExp = false)
        {
            if (sText.Trim().Length > 0)
            {
                m_bWaitForStringIsRegExp = bIsRegExp;
                // m_bWaitForStringIgnoreCase = false;
                if (m_bWaitForStringIsRegExp == true)
                {
                    if (sText.StartsWith("/") == true)
                    {
                        sText = sText.Substring(1);
                    }

                    if (sText.EndsWith("/i") == true)
                    {
                        // m_bWaitForStringIgnoreCase = true;
                        sText = sText.Substring(0, sText.Length - 2);
                    }
                    else if (sText.EndsWith("/") == true)
                    {
                        sText = sText.Substring(0, sText.Length - 1);
                    }
                }

                m_oWaitForRegex = null;
                if (bIsRegExp == true)
                {
                    if (Utility.ValidateRegExp(sText) == false)
                    {
                        return false;
                    }

                    m_oWaitForRegex = new Regex(sText, MyRegexOptions.options);
                }

                m_sWaitForStringText = sText;
                m_bWaitForStringResume = false;
                m_CurrentState = ScriptState.waitfor;
                return true;
            }

            return default;
        }

        private bool EvalWaitEval(string sText)
        {
            m_bWaitForEvent = false;
            m_sWaitForEventText = sText;
            m_CurrentState = ScriptState.waiteval;
            return default;
        }

        private void EvalMove(string sText)
        {
            if (sText.Trim().Length > 0)
            {
                m_bWaitForMove = false;
                m_CurrentState = ScriptState.move;
                if (sText.Length > 0)
                {
                    SendText(sText);
                }
            }
        }

        private void EvalPut(string sText)
        {
            if (sText.Trim().Length > 0)
            {
                SendText(sText);
                AddLocalVariable("lastcommand", sText);
            }
        }

        private void EvalSend(string sText)
        {
            if (sText.Trim().Length > 0)
            {
                SendText(sText, true);
            }
        }

        private void EvalSetvariableSave(string sText)
        {
            AddLocalVariable("s", sText);
        }

        private void EvalSetvariable(string sText, int iFileId, int iFileRow)
        {
            int argiLevel = 4;
            string argsText = "setvariable " + sText;
            PrintDebug(argiLevel, argsText, iFileId, iFileRow);
            AddLocalVariable(Utility.GetKeywordString(sText), Utility.GetArgumentString(sText));
        }

        private void EvalDeletevariable(string sText, int iFileId, int iFileRow)
        {
            int argiLevel = 4;
            string argsText = "deletevariable " + sText;
            PrintDebug(argiLevel, argsText, iFileId, iFileRow);
            m_oLocalVarList.Remove(Utility.GetKeywordString(sText));
        }

        private void AddLocalVariable(string sKey, string sValue)
        {
            m_oLocalVarList.Add(sKey, sValue);
            TriggerVariableChanged("%" + sKey);
        }

        private bool EvalIfStatement(string sExpression, int iFileId, int iFileRow)
        {
            int i = sExpression.ToLower().IndexOf(" then");
            if (i > -1)
            {
                sExpression = sExpression.Substring(0, i);
            }

            bool bResult = Eval(sExpression, m_oGlobals, iFileId, iFileRow);
            if (m_oEval.ResultList.Count > 0)
            {
                m_oCurrentLine.ArgList = m_oEval.ResultList;
            }

            int argiLevel = 3;
            string argsText = "if evaluate: " + sExpression;
            int argiFileId = 0;
            int argiFileRow = 0;
            PrintDebug(argiLevel, argsText, iFileId: argiFileId, iFileRow: argiFileRow);
            int argiLevel1 = 3;
            string argsText1 = "if returned: " + bResult.ToString();
            int argiFileId1 = 0;
            int argiFileRow1 = 0;
            PrintDebug(argiLevel1, argsText1, iFileId: argiFileId1, iFileRow: argiFileRow1);
            return bResult;
        }

        private bool EvalWhileStatement(string sExpression, int iFileId, int iFileRow)
        {
            return Eval(sExpression, m_oGlobals, iFileId, iFileRow);
        }

        private void ClearScript()
        {
            try
            {
                m_CurrentState = ScriptState.running;
                m_oLocalVarList.Clear();
                m_oScript.Clear();
                m_oScriptLabels.Clear();
                m_oScriptFiles.Clear();
                m_oCurrentLine.Clear();
                m_oActions.Clear();
                m_oMatchList.Clear();
                m_oTimerStart = default;
                m_dTimerLastTime = 0;
                m_bWaitForEvent = true;
            }
            catch (Exception ex)
            {
                GenieError.Error("ClearScript", ex.Message, ex.ToString());
            }
        }

        private bool RunJsblock(string sBlock)
        {
            InitJintEngine();
            m_JintEngine.Run(sBlock);
            return default;
        }

        private bool RunJSFile(string sFile)
        {
            string sFriendlyName = sFile;
            if (sFile.IndexOf(@"\") == -1)
            {
                string sLocation = m_oGlobals.Config.ScriptDir;
                if (sLocation.EndsWith(@"\"))
                {
                    sFile = sLocation + sFile;
                }
                else
                {
                    sFile = sLocation + @"\" + sFile;
                }
            }

            int argiLevel = 1;
            string argsText = "Loading JS file: " + sFriendlyName;
            int argiFileId = 0;
            int argiFileRow = 0;
            PrintDebug(argiLevel, argsText, iFileId: argiFileId, iFileRow: argiFileRow);
            try
            {
                var fi = new FileInfo(sFile);
                if (fi.Exists & fi.Length > 0)
                {
                    var objFile = new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    var objReader = new StreamReader(objFile);
                    object strContent = objReader.ReadToEnd();
                    RunJsblock(Conversions.ToString(strContent));
                    objReader.Close();
                    objFile.Close();
                }
                else
                {
                    int argiFileId1 = 0;
                    int argiFileRow1 = 0;
                    PrintError("Unable to load JS file: " + sFriendlyName, iFileId: argiFileId1, iFileRow: argiFileRow1);
                    AbortScript();
                    return false;
                }
            }
            #pragma warning disable CS0168
            catch (FileNotFoundException ex)
            #pragma warning restore CS0168
            {
                PrintError("File not found: " + sFriendlyName, iFileId: argiFileId, iFileRow: argiFileRow);
                AbortScript();
                return false;
            }
            #pragma warning disable CS0168
            catch (FileLoadException ex)
            #pragma warning restore CS0168
            {
                PrintError("File load exception: " + sFriendlyName, iFileId: argiFileId, iFileRow: argiFileRow);
                AbortScript();
                return false;
            }

            return true;
        }

        private bool AppendFile(string sFile, bool bJSBlock = false)
        {
            string sFriendlyName = sFile;
            if (sFile.IndexOf(@"\") == -1)
            {
                string sLocation = m_oGlobals.Config.ScriptDir;
                if (sLocation.EndsWith(@"\"))
                {
                    sFile = sLocation + sFile;
                }
                else
                {
                    sFile = sLocation + @"\" + sFile;
                }
            }

            int intFileId = m_oScriptFiles.Count;
            m_oScriptFiles.Add(sFriendlyName);
            int argiLevel = 1;
            string argsText = "Loading file: " + sFriendlyName;
            int argiFileId = 0;
            int argiFileRow = 0;
            PrintDebug(argiLevel, argsText, iFileId: argiFileId, iFileRow: argiFileRow);
            try
            {
                var fi = new FileInfo(sFile);
                if (fi.Exists & fi.Length > 0)
                {
                    var objFile = new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    var objReader = new StreamReader(objFile);
                    string sJSBlockContent = string.Empty;
                    bool bInsideJSBlock = false;
                    int I = 0;
                    string strLine = string.Empty;
                    while (objReader.Peek() > -1)
                    {
                        I += 1;
                        strLine = objReader.ReadLine().TrimStart();
                        if (strLine.Length > 0)
                        {
                            if (bJSBlock)
                            {
                                AddLine(I, strLine, intFileId, true);
                            }
                            else if (bInsideJSBlock)
                            {
                                if (strLine.EndsWith("%>"))
                                {
                                    AddLine(I, strLine.Substring(0, strLine.Length - 2), intFileId, true);
                                    bInsideJSBlock = false;
                                }
                                else
                                {
                                    AddLine(I, strLine, intFileId, true);
                                }
                            }
                            else if (strLine.StartsWith("<%"))
                            {
                                if (strLine.Substring(2).Trim().Length > 0)
                                {
                                    AddLine(I, strLine.Substring(2), intFileId, true);
                                }

                                bInsideJSBlock = true;
                            }
                            else if (strLine.StartsWith("#") == false)
                            {
                                if (AddLine(I, strLine, intFileId) == false)
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    objReader.Close();
                    objFile.Close();

                    // Add block end after include
                    if (bJSBlock)
                    {
                        var sr = new ScriptLine();
                        sr.iFileRow = -1;
                        sr.iFileId = intFileId;
                        sr.oFunction = ScriptFunctions.jsblockend;
                        m_oScript.Add(sr);
                    }
                }
                else
                {
                    int argiFileId1 = 0;
                    int argiFileRow1 = 0;
                    PrintError("Unable to load file: " + sFriendlyName, iFileId: argiFileId1, iFileRow: argiFileRow1);
                    AbortScript();
                    return false;
                }
            }
            #pragma warning disable CS0168
            catch (FileNotFoundException ex)
            #pragma warning restore CS0168
            {
                PrintError("File not found: " + sFriendlyName, iFileId: argiFileId, iFileRow: argiFileRow);
                AbortScript();
                return false;
            }
            #pragma warning disable CS0168
            catch (FileLoadException ex)
            #pragma warning restore CS0168
            {
                PrintError("File load exception: " + sFriendlyName, iFileId: argiFileId, iFileRow: argiFileRow);
                AbortScript();
                return false;
            }

            return true;
        }

        private void AppendString(string sText)
        {
            int intFileId = m_oScriptFiles.Count;
            m_oScriptFiles.Add("genie");
            int i = 1;
            foreach (string row in sText.Split(Conversions.ToChar(Constants.vbCr)))
            {
                var sRow = row;
                if (sRow.Trim().Length == 0)
                {
                    continue; // Skip blank lines
                }

                sRow = sRow.Trim();
                AddLine(i, sRow, intFileId);
                i = i + 1;
            }
        }

        private bool AddLine(int iFileRow, string sText, int iFileId, bool bJSBlock = false)
        {
            var sr = new ScriptLine();
            sr.iFileRow = iFileRow;
            sr.iFileId = iFileId;
            if (bJSBlock)
            {
                sr.oFunction = ScriptFunctions.jsblock;
                sr.sRowContent = sText;
                m_oScript.Add(sr);
                return true;
            }

            foreach (string row in sText.Split('¤')) // Handle ¤ as if it was a new line
            {
                var sRow = row;
                if (sRow.Trim().Length == 0)
                {
                    continue; // Skip blank lines
                }

                if (sRow.StartsWith("%"))
                {
                    sRow = "setvariable " + sRow.Substring(1);
                    if (sRow.Contains(" = "))
                        sRow = sRow.Replace(" = ", " ");
                }

                if (sRow.StartsWith("$"))
                {
                    sRow = "put #var " + sRow.Substring(1);
                    if (sRow.Contains(" = "))
                        sRow = sRow.Replace(" = ", " ");
                }

                sr.sRowContent = sRow;
                if (sRow.TrimEnd().EndsWith(":") == true & sRow.Trim().IndexOf(" ") == -1)
                {
                    sRow = sRow.TrimEnd();
                    AddLabel(sRow.Substring(0, sRow.Length - 1), m_oScript.Count, iFileId, iFileRow);
                    sr.oFunction = ScriptFunctions.label;
                }
                else
                {
                    string strKeyword = Utility.GetKeywordString(sRow).ToLower();
                    string strArgument = Utility.GetArgumentString(sRow);
                    if (strKeyword.StartsWith("if_") == true)
                    {
                        // if %argcount >= x then
                        if (strArgument.ToLower().StartsWith("then") == true)
                        {
                            sr.sRowContent = "if %argcount >= " + strKeyword.Substring(3) + " " + strArgument;
                        }
                        else
                        {
                            sr.sRowContent = "if %argcount >= " + strKeyword.Substring(3) + " then " + strArgument;
                        }

                        strKeyword = "if";
                        strArgument = Utility.GetArgumentString(sr.sRowContent);
                    }

                    sr.oFunction = GetFunctionType(strKeyword);
                    var switchExpr = sr.oFunction;
                    switch (switchExpr)
                    {
                        case ScriptFunctions.include:
                            {
                                if (strArgument.ToLower().EndsWith(".js"))
                                {
                                    if (AppendFile(strArgument, true) == false)
                                    {
                                        return false;
                                    }
                                }
                                else if (AppendFile(strArgument) == false)
                                {
                                    return false;
                                }
                                continue;
                            }

                        case ScriptFunctions.pluginscript:
                            {
                                string strScript = EvalPluginScript(strArgument, iFileId, iFileRow);
                                if (strScript.Length > 0)
                                {
                                    AppendString(strScript);
                                }
                                continue;
                            }

                        case ScriptFunctions.iffunc:
                            {
                                if (strArgument.TrimEnd().ToLower().EndsWith(" then") == false)
                                {
                                    int I = strArgument.ToLower().IndexOf(" then ") + 6;
                                    if (I - 6 >= 0)
                                    {
                                        if (strArgument.Length > I)
                                        {
                                            int J = sr.sRowContent.ToLower().IndexOf(" then ") + 6;
                                            if (J < sr.sRowContent.Length)
                                            {
                                                sr.sRowContent = sr.sRowContent.Substring(0, J).Trim();
                                                m_oScript.Add(sr);
                                                // PrintText("Adding virtual line: " & strArgument.Substring(I).Trim())
                                                if (AddLine(iFileRow, strArgument.Substring(I).Trim(), iFileId) == false)
                                                {
                                                    return false;
                                                }

                                                continue;
                                            }
                                            else
                                            {
                                                PrintError("Invalid IF statement: " + sRow, iFileId, iFileRow);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            PrintError("Invalid IF statement: " + sRow, iFileId, iFileRow);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        PrintError("Invalid IF statement: " + sRow, iFileId, iFileRow);
                                        return false;
                                    }
                                }

                                break;
                            }

                        case ScriptFunctions.whilefunc:
                            {
                                if (strArgument.TrimEnd().ToLower().EndsWith(" do") == false)
                                {
                                    int I = strArgument.IndexOf(" do ") + 4;
                                    if (I - 4 >= 0)
                                    {
                                        if (strArgument.Length > I)
                                        {
                                            int J = sr.sRowContent.ToLower().IndexOf(" do ") + 4;
                                            if (J < sr.sRowContent.Length)
                                            {
                                                sr.sRowContent = sr.sRowContent.ToLower().Substring(0, J).Trim();
                                                m_oScript.Add(sr);
                                                // PrintError("Adding virtual line: " & strArgument.Substring(I).Trim())
                                                if (AddLine(iFileRow, strArgument.Substring(I).Trim(), iFileId) == false)
                                                {
                                                    return false;
                                                }

                                                continue;
                                            }
                                            else
                                            {
                                                PrintError("Invalid WHILE statement: " + sRow, iFileId, iFileRow);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            PrintError("Invalid WHILE statement: " + sRow, iFileId, iFileRow);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        PrintError("Invalid WHILE statement: " + sRow, iFileId, iFileRow);
                                        return false;
                                    }
                                }

                                break;
                            }

                        case ScriptFunctions.elsefunc:
                            {
                                if (strArgument.Length > 0)
                                {
                                    sr.sRowContent = "else";
                                    m_oScript.Add(sr);
                                    if (AddLine(iFileRow, strArgument.Trim(), iFileId) == false)
                                    {
                                        return false;
                                    }

                                    continue;
                                }

                                break;
                            }

                        case ScriptFunctions.elseiffunc: // "elseif"
                            {
                                if (strArgument.Length > 0)
                                {
                                    sr.sRowContent = "else";
                                    sr.oFunction = ScriptFunctions.elsefunc;
                                    m_oScript.Add(sr);
                                    if (AddLine(iFileRow, "if " + strArgument.Trim(), iFileId) == false)
                                    {
                                        return false;
                                    }

                                    continue;
                                }

                                break;
                            }

                        case ScriptFunctions.blockstart:
                            {
                                sr.oFunction = ScriptFunctions.blockstart;
                                int argiLevel = 50;
                                string argsText = "Block start: " + sRow;
                                PrintDebug(argiLevel, argsText, iFileId, iFileRow);
                                break;
                            }

                        case ScriptFunctions.blockend:
                            {
                                sr.oFunction = ScriptFunctions.blockend;
                                int argiLevel1 = 50;
                                string argsText1 = "Block end: " + sRow;
                                PrintDebug(argiLevel1, argsText1, iFileId, iFileRow);
                                if (strArgument.Length > 0)
                                {
                                    sr.sRowContent = "}";
                                    m_oScript.Add(sr);
                                    if (AddLine(iFileRow, strArgument.Trim(), iFileId) == false)
                                    {
                                        return false;
                                    }

                                    continue;
                                }
                                break;
                            }

                        case ScriptFunctions.empty:
                            {
                                if (m_oGlobals.Config.bIgnoreScriptWarnings == false)
                                {
                                    PrintError("Unknown script command: " + sRow, iFileId, iFileRow);
                                    return false;
                                }
                                continue;
                            }
                    }
                }

                // If we made it this far, add it to our list
                m_oScript.Add(sr);
            }

            return true;
        }

        private ScriptFunctions GetFunctionType(string strKeyword)
        {
            switch (strKeyword)
            {
                case "action":
                    {
                        return ScriptFunctions.action;
                    }

                case "include":
                    {
                        return ScriptFunctions.include;
                    }

                case "echo":
                    {
                        return ScriptFunctions.echo;
                    }

                case "put":
                    {
                        return ScriptFunctions.put;
                    }

                case "send":
                    {
                        return ScriptFunctions.send;
                    }

                case "exit":
                    {
                        return ScriptFunctions.exitfunc;
                    }

                case "goto":
                    {
                        return ScriptFunctions.gotofunc;
                    }

                case "save":
                    {
                        return ScriptFunctions.save;
                    }

                case "var":
                case "vars":
                case "variable":
                case "setvar":
                case "setvariable":
                    {
                        return ScriptFunctions.setvariable;
                    }

                case "unvar":
                case "unvariable":
                case "unsetvar":
                case "unsetvariable":
                    {
                        return ScriptFunctions.deletevariable;
                    }

                case "counter":
                    {
                        return ScriptFunctions.counter;
                    }

                case "shift":
                    {
                        return ScriptFunctions.shift;
                    }

                case "pause":
                    {
                        return ScriptFunctions.pause;
                    }

                case "delay":
                    {
                        return ScriptFunctions.delay;
                    }

                case "waitfor":
                    {
                        return ScriptFunctions.waitfor;
                    }

                case "waiteval":
                    {
                        return ScriptFunctions.waiteval;
                    }

                case "match":
                    {
                        return ScriptFunctions.match;
                    }

                case "matchwait":
                    {
                        return ScriptFunctions.matchwait;
                    }

                case "wait":
                    {
                        return ScriptFunctions.wait;
                    }

                case "move":
                    {
                        return ScriptFunctions.move;
                    }

                case "nextroom":
                    {
                        return ScriptFunctions.nextroom;
                    }

                case "matchre":
                    {
                        return ScriptFunctions.matchre;
                    }

                case "waitforre":
                    {
                        return ScriptFunctions.waitforre;
                    }

                case "gosub":
                    {
                        return ScriptFunctions.gosubfunc;
                    }

                case "return":
                    {
                        return ScriptFunctions.returnfunc;
                    }

                case "if":
                    {
                        return ScriptFunctions.iffunc;
                    }

                case "while":
                    {
                        return ScriptFunctions.whilefunc;
                    }

                case "timer":
                    {
                        return ScriptFunctions.timer;
                    }

                case "random":
                    {
                        return ScriptFunctions.random;
                    }

                case "math":
                    {
                        return ScriptFunctions.mathfunc;
                    }

                case "eval":
                case "evaluate":
                    {
                        return ScriptFunctions.eval;
                    }

                case "evalmath":
                case "evaluatemath":
                    {
                        return ScriptFunctions.evalmath;
                    }

                case "debug":
                case "debuglevel":
                    {
                        return ScriptFunctions.debuglevel;
                    }

                case "js":
                case "javascript":
                    {
                        return ScriptFunctions.js;
                    }

                case "plugin":
                    {
                        return ScriptFunctions.plugin;
                    }

                case "pluginscript":
                    {
                        return ScriptFunctions.pluginscript;
                    }

                case "jscall":
                    {
                        return ScriptFunctions.jscall;
                    }

                case "else":
                    {
                        return ScriptFunctions.elsefunc;
                    }

                case "elseif":
                    {
                        return ScriptFunctions.elseiffunc;
                    }

                case "{":
                case "begin":
                    {
                        return ScriptFunctions.blockstart;
                    }

                case "}":
                case "end":
                    {
                        return ScriptFunctions.blockend;
                    }

                default:
                    {
                        return ScriptFunctions.empty;
                    }
            }
        }

        private void AddLabel(string strLabel, int intArrayIndex, int iFileId, int iFileRow)
        {
            strLabel = strLabel.ToLower().Trim();
            if (m_oScriptLabels.ContainsKey(strLabel) == true)
            {
                if (m_oGlobals.Config.bIgnoreScriptWarnings == false)
                {
                    PrintError("Replacing duplicate label: " + strLabel, iFileId, iFileRow);
                }

                m_oScriptLabels[strLabel] = intArrayIndex;
            }
            else
            {
                m_oScriptLabels.Add(strLabel, intArrayIndex);
            }
        }

        private void PrintError(string sText, [Optional, DefaultParameterValue(0)] int iFileId, [Optional, DefaultParameterValue(0)] int iFileRow)
        {
            m_oLocalVarList.Add("lastscripterror", sText);
            string sErrorMessage = "[Script error";
            if (m_sFileName.Length > 0)
            {
                sErrorMessage += " in " + m_sFileName;
            }

            if (iFileId > 0 & (m_oScriptFiles[iFileId].ToString() ?? "") != (m_sFileName ?? ""))
            {
                sErrorMessage += ", " + m_oScriptFiles[iFileId];
            }

            if (iFileRow > 0)
            {
                sErrorMessage += "(" + iFileRow.ToString() + ")";
            }

            EventPrintError?.Invoke(sErrorMessage + ": " + sText + "]" + Constants.vbNewLine);
        }

        private void PrintJSError(string sText, [Optional, DefaultParameterValue(0)] int iFileId, [Optional, DefaultParameterValue(0)] int iFileRow)
        {
            if (sText.Contains(" at line "))
            {
                sText = sText.Substring(0, sText.IndexOf(" at line "));
            }

            string sErrorMessage = "[Javascript error";
            if (m_sFileName.Length > 0)
            {
                sErrorMessage += " in " + m_sFileName;
            }

            if (iFileId > 0 & (m_oScriptFiles[iFileId].ToString() ?? "") != (m_sFileName ?? ""))
            {
                sErrorMessage += ", " + m_oScriptFiles[iFileId];
            }

            if (iFileRow > 0)
            {
                sErrorMessage += "(" + iFileRow.ToString() + ")";
            }

            EventPrintError?.Invoke(sErrorMessage + ": " + sText + "]" + Constants.vbNewLine);
        }

        private void PrintDebug(int iLevel, string sText, [Optional, DefaultParameterValue(0)] int iFileId, [Optional, DefaultParameterValue(0)] int iFileRow)
        {
            if ((m_oScriptFiles[iFileId].ToString() ?? "") == "genie")
                return;
            string sDebugMessage = string.Empty;
            if (m_sFileName.Length > 0)
            {
                sDebugMessage += m_sFileName;
            }

            if (m_oScriptFiles.Count > 0)
            {
                if (iFileId > 0 & (m_oScriptFiles[iFileId].ToString() ?? "") != (m_sFileName ?? ""))
                {
                    sDebugMessage += ", " + m_oScriptFiles[iFileId];
                }
            }

            if (iFileRow > 0)
            {
                sDebugMessage += "(" + iFileRow.ToString() + ")";
            }

            if (sDebugMessage.Length > 0)
            {
                sDebugMessage += ": ";
            }

            // 10 = actual script rows
            // Everything above 9 has to be an exact match to show
            if (DebugLevel > 9 & DebugLevel == iLevel)
            {
                EventPrintText?.Invoke(sDebugMessage + sText + Constants.vbNewLine, Color.RoyalBlue, Color.Transparent);
            }
            else if (DebugLevel <= 9 & DebugLevel >= iLevel)
            {
                EventPrintText?.Invoke(sDebugMessage + sText + Constants.vbNewLine, Color.RoyalBlue, Color.Transparent);
            }
        }

        private void PrintText(string sText)
        {
            EventPrintText?.Invoke(sText + Constants.vbNewLine, Color.White, Color.Transparent);
        }

        private void PrintEcho(string sText)
        {
            EventPrintText?.Invoke(sText + Constants.vbNewLine, m_oGlobals.PresetList["scriptecho"].FgColor, Color.Transparent);
        }

        private void SendText(string text, bool queue = false)
        {
            EventSendText?.Invoke(text, ScriptName, queue);
        }
    }
}