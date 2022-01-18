using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie
{
    public class Globals
    {
        private Config _Config = new Config();
       

        public Config Config
        {

            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Config;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {

                if (_Config != null)
                {
                    _Config.ConfigChanged -= Config_ConfigChanged;
                }

                _Config = value;
                if (_Config != null)
                {
                    _Config.ConfigChanged += Config_ConfigChanged;
                }
            }
        }

        public event ConfigChangedEventHandler ConfigChanged;

        public delegate void ConfigChangedEventHandler(Config.ConfigFieldUpdated oField);

    public Events Events = new Events();
        public CommandQueue CommandQueue = new CommandQueue();
        public Aliases AliasList = new Aliases();
        public Macros MacroList = new Macros();
        public Names NameList = new Names();
        public Classes ClassList = new Classes();
        public Triggers TriggerList = new Triggers();
        public Presets PresetList = new Presets();
        public Variables VariableList = new Variables();
        public Highlights HighlightList = new Highlights();
        public HighlightRegExp HighlightRegExpList = new HighlightRegExp();
        public HighlightLineBeginsWith HighlightBeginsWithList = new HighlightLineBeginsWith();
        public SubstituteRegExp SubstituteList = new SubstituteRegExp();
        public GagRegExp GagList = new GagRegExp();
        public string GenieKey = string.Empty;
        public string GenieAccount = string.Empty;
        public ArrayList PluginList = new ArrayList();
        public bool PluginsEnabled = true;
        public Hashtable PluginVerifiedKeyList = new Hashtable();
        public Hashtable PluginPremiumKeyList = new Hashtable();
        private Log _Log = new Log();

        public Log Log
        {            
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Log;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Log != null)
                {
                    GenieError.EventGenieError -= HandleGenieException;
                }

                _Log = value;
                if (_Log != null)
                {
                    GenieError.EventGenieError += HandleGenieException;
                }
            }
        }

        private void HandleGenieException(string section, string message, string description = null) // Pass it up
        {
            Config.bAutoLog = false;
            GenieError.Error(section, message, description);
        }

        public void Config_ConfigChanged(Config.ConfigFieldUpdated oField)
        {
            if (oField == Config.ConfigFieldUpdated.LogDir)
            {
                Log.LogDirectory = Config.sLogDir;
            }
            else
            {
            //    Config.ConfigChanged(oField);
                ConfigChanged?.Invoke(oField);
            //    Config.ConfigChanged?.Invoke(oField);
            }
        }

        public List<string> MonsterList = new List<string>();
        public Regex MonsterListRegEx;

        public void UpdateMonsterListRegEx()
        {
            var sb = new StringBuilder();
            MonsterList.Sort();
            MonsterList.Reverse();
            foreach (string s in MonsterList)
            {
                if (sb.Length > 0)
                    sb.Append("|");
                sb.Append(Regex.Escape(s));
            }

            if (MonsterList.Count == 0)
            {
                MonsterListRegEx = null;
            }
            else
            {
                MonsterListRegEx = new Regex(@"\b(" + sb.ToString() + @")[\ \,\.]", RegexOptions.IgnoreCase);
                Debug.WriteLine(MonsterListRegEx.ToString());
            }
        }

        public DateTime SpellTimeStart;
        public DateTime RoundTimeEnd;
        private static DateTime m_oBlankTimer = DateTime.Parse("0001-01-01");



        public string ParseGlobalVars(object sVar)
        {
            var sText = sVar.ToString();
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sText.Contains("$"), true, false)))
            {
                sText = sText.Replace(@"\$", @"\¤");
                if (VariableList.AcquireReaderLock())
                {
                    try
                    {
                        // ' Replace global variables
                        // For Each de As DictionaryEntry In VariableList
                        // sText = sText.Replace("$" & de.Key.ToString, CType(de.Value, Variables.Variable).sValue)
                        // Next

                        int p = Conversions.ToInteger(sText.Length - 1);
                        while (p >= 0)
                        {
                            var switchExpr = sText.Substring(p, 1);
                            switch (switchExpr)
                            {
                                case var @case when @case == "$":
                                    {
                                        if (p <= 0 || Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(sText.Substring(p - 1, 1), @"\", false)))
                                        {
                                            sText = sText.Substring(0, p) + ParseVariable(Conversions.ToString(sText.Substring(p)));
                                        }

                                        break;
                                    }
                            }

                            p -= 1;
                        }
                    }
                    finally
                    {
                        VariableList.ReleaseReaderLock();
                    }
                }
                else
                {
                    throw new Exception("Unable to aquire reader lock.");
                }

                sText = sText.Replace(@"\¤", "$");
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sText.Contains("@"), true, false))) // On the fly variables
            {
                sText = ParseSpecialVariables(Conversions.ToString(sText));
            }

            return Conversions.ToString(sText);
        }

        public string ParseSpecialVariables(string sText)
        {
            var argoDateEnd = DateTime.Now;
            double d = Utility.GetTimeDiffInMilliseconds(SpellTimeStart, argoDateEnd);
            if (d > 0 & SpellTimeStart != m_oBlankTimer)
            {
                sText = sText.Replace("@spelltime@", (d / 1000).ToString());
                double spelllength = int.Parse(VariableList["casttime"].ToString()) - int.Parse(VariableList["spellstarttime"].ToString());
                sText = sText.Replace("@spellpreptime@", spelllength.ToString());
                double casttimeremaining = spelllength - (d / 1000);
                sText = sText.Replace("@casttimeremaining@", casttimeremaining > 0 ? casttimeremaining.ToString() : "0");
            }
            else
            {
                sText = sText.Replace("@spelltime@", "0");
                sText = sText.Replace("@casttimeremaining@", "0");
            }
            
            sText = sText.Replace("@time@", DateTime.Now.ToString("hh:mm:ss tt").Trim());
            sText = sText.Replace("@date@", DateTime.Now.ToString("M/d/yyyy").Trim());
            sText = sText.Replace("@datetime@", DateTime.Now.ToString("M/d/yyyy hh:mm:ss tt").Trim());
            return sText;
        }

        public string ParseVariable(string Line)
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
                if (VariableList.ContainsKey(sVar.Substring(0, I)))
                {
                    int idx = 0;
                    if (int.TryParse(sVar.Substring(I + 1, sVar.IndexOf(')') - I - 1), out idx))
                    {
                        string sValue = Conversions.ToString(VariableList[sVar.Substring(0, I)]);
                        var oArr = sValue.Split('|');
                        if (idx >= 0 && Information.UBound(oArr) >= idx)
                        {
                            return oArr[idx] + Line.Substring(Line.IndexOf(')') + 1);
                        }
                        else
                        {
                            // Invalid index - Return empty result and remainder string
                            // Return Line.Substring(Line.IndexOf(")"c) + 1)
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
                        if (VariableList.ContainsKey(sVar.Substring(0, p - 7)))
                        {
                            return (Utility.Count(Conversions.ToString(VariableList[sVar.Substring(0, p - 7)]), "|") + 1).ToString() + Line.Substring(p + 1);
                        }
                    }
                }

                if (VariableList.ContainsKey(sCurrent))
                {
                    return Conversions.ToString(VariableList[sCurrent] + Line.Substring(p + 1));
                }

                p -= 1;
            }

            return Line;
        }

        public class DescendingComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return Comparer.Default.Compare(y, x);
            }
        }

        public class Presets : Collections.SortedList
        {
            public class Preset
            {
                public string sKey;
                public Color FgColor;
                public Color BgColor;
                public string sColorName;
                public bool bSaveToFile = true;

                public Preset(string sKey, Color oColor, Color oBgColor, string sColorName, string _bSaveToFile)
                {
                    this.sKey = sKey;
                    FgColor = oColor;
                    BgColor = oBgColor;
                    this.sColorName = sColorName;
                    bSaveToFile = Conversions.ToBoolean(_bSaveToFile);
                }
            }

            public void Add(string sKey, string sColorName, bool bSaveToFile = true)
            {
                Color oColor;
                Color oBgcolor;
                if (sColorName.Contains(",") == true && sColorName.EndsWith(",") == false)
                {
                    string sColor = sColorName.Substring(0, sColorName.IndexOf(",")).Trim();
                    string sBgColor = sColorName.Substring(sColorName.IndexOf(",") + 1).Trim();
                    oColor = ColorCode.StringToColor(sColor);
                    oBgcolor = ColorCode.StringToColor(sBgColor);
                }
                else
                {
                    oColor = ColorCode.StringToColor(sColorName);
                    oBgcolor = Color.Transparent;
                }

                string arg_bSaveToFile = Conversions.ToString(bSaveToFile);
                var oVar = new Preset(sKey, oColor, oBgcolor, sColorName, arg_bSaveToFile);
                if (base.ContainsKey(sKey.ToLower()) == true)
                {
                    base[sKey.ToLower()] = oVar;
                }
                else
                {
                    object argvalue = oVar;
                    Add(sKey.ToLower(), argvalue);
                }
            }

            // Do not remove built in variables
            public void Remove(string key)
            {
                if (base.ContainsKey(key) == true)
                {
                    if (((Preset)base[key]).bSaveToFile == true)
                    {
                        base.Remove(key);
                    }
                }
            }

            public new void Clear()
            {
                base.Clear();
                SetDefaultPresets();
            }

            public Preset this[string key]
            {
                get
                {
                    if (base.ContainsKey(key) == true)
                    {
                        return (Preset)base[key];
                    }
                    else
                    {
                        return null;
                    }
                }

                set
                {
                    base[key] = value;
                }
            }

            public bool Load(string sFileName = "presets.cfg")
            {
                try
                {
                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        var oStreamReader = new StreamReader(sFileName);
                        string strLine = oStreamReader.ReadLine();
                        while (!Information.IsNothing(strLine))
                        {
                            LoadRow(strLine);
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
                #pragma warning disable CS0168
                catch (Exception Err)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }

            private void LoadRow(string sText)
            {
                var oArgs = Utility.ParseArgs(sText);
                if (oArgs.Count == 3)
                {
                    var arg1 = oArgs[1].ToString();
                    var arg2 = oArgs[2].ToString();
                    Add(arg1, arg2);
                }
            }

            public bool Save(string sFileName = "presets.cfg")
            {
                try
                {
                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        Utility.DeleteFile(sFileName);
                    }

                    if (AcquireReaderLock())
                    {
                        try
                        {
                            var oStreamWriter = new StreamWriter(sFileName, false);
                            foreach (Preset ov in base.Values)
                            {
                                if (ov.bSaveToFile == true)
                                {
                                    oStreamWriter.WriteLine("#preset {" + ov.sKey + "} {" + ov.sColorName + "}");
                                }
                            }

                            oStreamWriter.Close();
                        }
                        finally
                        {
                            ReleaseReaderLock();
                        }
                    }
                    else
                    {
                        throw new Exception("Unable to aquire reader lock.");
                    }

                    return true;
                }
                #pragma warning disable CS0168
                catch (Exception ex)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }

            public void SetDefaultPresets()
            {
                Add("roomname", "Yellow,DarkBlue");
                Add("roomdesc", "Silver");
                Add("creatures", "Cyan");
                Add("speech", "Yellow");
                Add("whispers", "Magenta");
                Add("thoughts", "Cyan");
                Add("roundtime", "MediumBlue");
                Add("health", "Maroon");
                Add("mana", "Navy");
                Add("stamina", "Green");
                Add("spirit", "Purple");
                Add("concentration", "Navy");
                Add("inputuser", "Yellow");
                Add("inputother", "GreenYellow");
                Add("scriptecho", "Cyan");
                Add("familiar", "PaleGreen");
                Add("castbar", "Magenta");
            }

            public Presets()
            {
                SetDefaultPresets();
            }
        }

        public class Variables : Collections.SortedList
        {
            public enum VariableType
            {
                SaveToFile,
                Reserved,
                Server,
                Temporary,
                Ignore
            }

            public class Variable
            {
                public string sKey;
                public string sValue;
                public VariableType oType;
                // Public bSaveToFile As Boolean = True

                public bool bSaveToFile
                {
                    get
                    {
                        if (oType == VariableType.SaveToFile)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    set
                    {
                        if (value == true)
                        {
                            oType = VariableType.SaveToFile;
                        }
                        else
                        {
                            oType = VariableType.Reserved;
                        }
                    }
                }

                public Variable(string _sKey, string _sValue, VariableType _oType)
                {
                    sKey = _sKey;
                    sValue = _sValue;
                    oType = _oType;
                }
            }

            // Public Sub New(Bydc As DescendingComparer)
            // MyBase.New(dc)
            // End Sub

            public void Add(string key, string value, VariableType oType = VariableType.SaveToFile)
            {
                if (base.ContainsKey(key) == true)
                {
                    ((Variable)base[key]).sValue = value;
                    ((Variable)base[key]).oType = oType;
                }
                else
                {
                    var oVar = new Variable(key, value, oType);
                    object argvalue = oVar;
                    Add(key, argvalue);
                }
            }

            // Do not remove built in variables
            public new void Remove(object key)
            {
                if (base.ContainsKey(key) == true)
                {
                    if (((Variable)base[key]).oType != VariableType.Reserved)
                    {
                        base.Remove(key);
                    }
                }
            }

            public new void Clear()
            {
                base.Clear();
                SetDefaultGlobalVars();
            }

            public void ClearUser()
            {
                if (AcquireReaderLock())
                {
                    var al = new ArrayList();
                    try
                    {
                        foreach (string s in base.Keys)
                        {
                            if (((Variable)base[s]).bSaveToFile)
                            {
                                al.Add(s);
                            }
                        }
                    }
                    finally
                    {
                        ReleaseReaderLock();
                        foreach (string s in al)
                            Remove(s);
                    }
                }
                else
                {
                    throw new Exception("Unable to aquire reader lock.");
                }
            }

            public new object this[object key]
            {
                get
                {
                    if (base.ContainsKey(key) == true)
                    {
                        return ((Variable)base[key]).sValue;
                    }
                    else
                    {
                        return null;
                    }
                }

                set
                {
                    if (base.ContainsKey(key))
                    {
                        ((Variable)base[key]).sValue = Conversions.ToString(value);
                    }
                    else
                    {
                        string arg_sKey = Conversions.ToString(key);
                        string arg_sValue = Conversions.ToString(value);
                        var variableType = VariableType.SaveToFile;
                        var oVar = new Variable(arg_sKey, arg_sValue, variableType);
                        object argvalue = oVar;
                        Add(key, argvalue);
                    }
                }
            }

            public Variable get_GetVariable(object key)
            {
                if (base.ContainsKey(key) == true)
                {
                    return (Variable)base[key];
                }
                else
                {
                    return null;
                }
            }

            public void set_GetVariable(object key, Variable value)
            {
                if (base.ContainsKey(key))
                {
                    base[key] = value;
                }
                else
                {
                    object argvalue = value;
                    Add(key, argvalue);
                }
            }

            private string m_FileName = LocalDirectory.Path + @"\Config\" + "variables.cfg";

            public bool Load(string sFileName = null)
            {
                try
                {
                    if (Information.IsNothing(sFileName))
                    {
                        sFileName = m_FileName;
                    }

                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    m_FileName = sFileName;
                    if (File.Exists(sFileName) == true)
                    {
                        var oStreamReader = new StreamReader(sFileName);
                        string strLine = oStreamReader.ReadLine();
                        while (!Information.IsNothing(strLine))
                        {
                            LoadRow(strLine);
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
                #pragma warning disable CS0168
                catch (Exception Err)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }

            private void LoadRow(string sText)
            {
                var oArgs = Utility.ParseArgs(sText);
                if (oArgs.Count == 3)
                {
                    var arg1 = oArgs[1].ToString();
                    var arg2 = oArgs[2].ToString();
                    Add(arg1, arg2);
                }
            }

            public bool Save(string sFileName = null)
            {
                try
                {
                    if (Information.IsNothing(sFileName))
                    {
                        sFileName = m_FileName;
                    }

                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        Utility.DeleteFile(sFileName);
                    }

                    if (AcquireReaderLock())
                    {
                        try
                        {
                            var oStreamWriter = new StreamWriter(sFileName, false);
                            foreach (Variable ov in base.Values)
                            {
                                if (ov.bSaveToFile == true)
                                {
                                    oStreamWriter.WriteLine("#var {" + ov.sKey + "} {" + ov.sValue + "}");
                                }
                            }

                            oStreamWriter.Close();
                        }
                        finally
                        {
                            ReleaseReaderLock();
                        }
                    }
                    else
                    {
                        throw new Exception("Unable to aquire reader lock.");
                    }

                    return true;
                }
                #pragma warning disable CS0168
                catch (Exception ex)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }

            public void SetDefaultGlobalVars()
            {
                Add("north", "0", VariableType.Reserved);
                Add("northeast", "0", VariableType.Reserved);
                Add("east", "0", VariableType.Reserved);
                Add("southeast", "0", VariableType.Reserved);
                Add("south", "0", VariableType.Reserved);
                Add("southwest", "0", VariableType.Reserved);
                Add("west", "0", VariableType.Reserved);
                Add("northwest", "0", VariableType.Reserved);
                Add("up", "0", VariableType.Reserved);
                Add("down", "0", VariableType.Reserved);
                Add("out", "0", VariableType.Reserved);
                
                Add("roomname", "", VariableType.Reserved);
                Add("roomdesc", "", VariableType.Reserved);
                Add("roomobjs", "", VariableType.Reserved);
                Add("roomplayers", "", VariableType.Reserved);
                Add("roomexits", "", VariableType.Reserved);
                
                Add("concentration", "100", VariableType.Reserved);
                Add("encumbrance", "0", VariableType.Reserved);
                Add("health", "100", VariableType.Reserved);
                Add("mana", "100", VariableType.Reserved);
                Add("spirit", "100", VariableType.Reserved);
                Add("stamina", "100", VariableType.Reserved);
                
                Add("charactername", "", VariableType.Reserved);
                Add("gamename", "", VariableType.Reserved);


                Add("kneeling", "0", VariableType.Reserved);
                Add("prone", "0", VariableType.Reserved);
                Add("sitting", "0", VariableType.Reserved);
                Add("standing", "0", VariableType.Reserved);
                Add("stunned", "0", VariableType.Reserved);
                Add("hidden", "0", VariableType.Reserved);
                Add("invisible", "0", VariableType.Reserved);
                Add("dead", "0", VariableType.Reserved);
                Add("joined", "0", VariableType.Reserved);
                Add("bleeding", "0", VariableType.Reserved);
                Add("webbed", "0", VariableType.Reserved);
                Add("roundtime", "0", VariableType.Reserved);
                Add("preparedspell", "None", VariableType.Reserved);
                Add("lefthand", "Empty", VariableType.Reserved);
                Add("lefthandnoun", "", VariableType.Reserved);
                Add("righthand", "Empty", VariableType.Reserved);
                Add("righthandnoun", "", VariableType.Reserved);

                Add("gametime", "0", VariableType.Reserved);
                               

                Add("poisoned", "0", VariableType.Reserved);
                Add("diseased", "0", VariableType.Reserved);
                Add("connected", "0", VariableType.Reserved);
                Add("version", My.MyProject.Application.Info.Version.ToString(), VariableType.Reserved);
                Add("time", "@time@", VariableType.Reserved);
                Add("date", "@date@", VariableType.Reserved);
                Add("datetime", "@datetime@", VariableType.Reserved);
                Add("spelltime", "@spelltime@", VariableType.Reserved);
                Add("spellpreptime", "@spellpreptime@", VariableType.Reserved);
                Add("spellstarttime", "0", VariableType.Reserved);
                Add("casttime", "0", VariableType.Reserved);
                Add("casttimeremaining", "@casttimeremaining@", VariableType.Reserved);
                Add("monstercount", "0", VariableType.Reserved);
                Add("monsterlist", "", VariableType.Reserved);
                Add("prompt", "", VariableType.Reserved);
                Add("lastcommand", "", VariableType.Reserved);
                Add("zoneid", "0", VariableType.Reserved);
                Add("zonename", "0", VariableType.Reserved);
                Add("scriptlist", "none", VariableType.Reserved);
                Add("repeatregex", @"^\.\.\.wait|^Sorry\, you may only type ahead|^You are still stunned|^You can\'t do that while|^You don\'t seem to be able", VariableType.Reserved);
            }
        }

        public bool AddTrigger(string sTrigger, string sAction, bool bIgnoreCase = false, bool bIsEvalTrigger = false, string ClassName = "")
        {
            if (sTrigger.StartsWith("e/") == true)
            {
                bIsEvalTrigger = true;
            }
            else if (sTrigger.ToLower().StartsWith("eval ") == true)
            {
                bIsEvalTrigger = true;
            }

            if (bIsEvalTrigger == false)
            {
                sTrigger = ParseGlobalVars(sTrigger);
            }

            return TriggerList.Add(sTrigger, sAction, bIgnoreCase, bIsEvalTrigger, ClassName);
        }

        public class Triggers : Collections.SortedList
        {
            public class Trigger
            {
                public string sTrigger = string.Empty;
                public string sAction = string.Empty;
                public bool bIgnoreCase = false;
                public bool bIsEvalTrigger = false;
                public Regex oRegexTrigger = null;
                public string ClassName = string.Empty;
                public bool IsActive = true;

                public Trigger(string _sTrigger, string _sAction, bool _bIgnoreCase, bool _bIsEvalTrigger, string _ClassName)
                {
                    sTrigger = _sTrigger;
                    sAction = _sAction;
                    bIgnoreCase = _bIgnoreCase;
                    bIsEvalTrigger = _bIsEvalTrigger;
                    if (_bIsEvalTrigger == false)
                    {
                        if (_bIgnoreCase == true)
                        {
                            oRegexTrigger = new Regex(_sTrigger, MyRegexOptions.options | RegexOptions.IgnoreCase);
                        }
                        else
                        {
                            oRegexTrigger = new Regex(_sTrigger, MyRegexOptions.options);
                        }
                    }

                    ClassName = _ClassName;
                }
            }

            public void ToggleClass(string ClassName, bool Value)
            {
                if (AcquireReaderLock())
                {
                    var al = new ArrayList();
                    try
                    {
                        foreach (string s in base.Keys)
                            al.Add(s);
                    }
                    finally
                    {
                        ReleaseReaderLock();
                        foreach (string s in al)
                        {
                            Trigger tr = (Trigger)base[s];
                            if ((tr.ClassName.ToLower() ?? "") == (ClassName.ToLower() ?? ""))
                            {
                                tr.IsActive = Value;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Unable to aquire reader lock.");
                }
            }

            public bool Add(string sTrigger, string sAction, bool bIgnoreCase = false, bool bIsEvalTrigger = false, string ClassName = "")
            {
                if (sTrigger.StartsWith("e/") == true)
                {
                    sTrigger = sTrigger.Substring(2);
                    bIsEvalTrigger = true;
                }
                else if (sTrigger.ToLower().StartsWith("eval ") == true)
                {
                    sTrigger = sTrigger.Substring(5);
                    bIsEvalTrigger = true;
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

                if (bIsEvalTrigger == false && Utility.ValidateRegExp(sTrigger) == false)
                {
                    return false;
                }

                if (base.ContainsKey(sTrigger) == true)
                {
                    base[sTrigger] = new Trigger(sTrigger, sAction, bIgnoreCase, bIsEvalTrigger, ClassName);
                }
                else
                {
                    object argvalue = new Trigger(sTrigger, sAction, bIgnoreCase, bIsEvalTrigger, ClassName);
                    Add(sTrigger, argvalue);
                }

                return true;
            }

            public void Remove(string sTrigger)
            {
                if (sTrigger.StartsWith("e/") == true)
                {
                    sTrigger = sTrigger.Substring(2);
                }
                else if (sTrigger.ToLower().StartsWith("eval ") == true)
                {
                    sTrigger = sTrigger.Substring(5);
                }
                else if (sTrigger.StartsWith("/") == true)
                {
                    sTrigger = sTrigger.Substring(1);
                }

                if (sTrigger.EndsWith("/i") == true)
                {
                    sTrigger = sTrigger.Substring(0, sTrigger.Length - 2);
                }
                else if (sTrigger.EndsWith("/") == true)
                {
                    sTrigger = sTrigger.Substring(0, sTrigger.Length - 1);
                }

                if (base.ContainsKey(sTrigger) == true)
                {
                    base.Remove(sTrigger);
                }
            }

            public bool Load(string sFileName = "triggers.cfg")
            {
                try
                {
                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        var oStreamReader = new StreamReader(sFileName);
                        string strLine = oStreamReader.ReadLine();
                        while (!Information.IsNothing(strLine))
                        {
                            LoadRow(strLine);
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
                #pragma warning disable CS0168
                catch (Exception ex)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }

            private void LoadRow(string sText)
            {
                var oArgs = Utility.ParseArgs(sText);
                if (oArgs.Count > 2)
                {
                    string sClass = string.Empty;
                    if (oArgs.Count > 3)
                        sClass = oArgs[3].ToString().Trim();

                    var arg1 = oArgs[1].ToString();
                    var arg2 = oArgs[2].ToString();
                    Add(arg1, arg2, false, false, sClass);
                }
            }

            public bool Save(string sFileName = "triggers.cfg")
            {
                try
                {
                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        Utility.DeleteFile(sFileName);
                    }

                    if (AcquireReaderLock())
                    {
                        try
                        {
                            var oStreamWriter = new StreamWriter(sFileName, false);
                            foreach (Trigger ot in base.Values)
                            {
                                string sKey = ot.sTrigger;
                                if (ot.bIsEvalTrigger == true)
                                {
                                    sKey = "e/" + sKey + "/";
                                }
                                else if (ot.bIgnoreCase == true)
                                {
                                    sKey = "/" + sKey + "/i";
                                }

                                string sLine = "#trigger {" + sKey + "} {" + ot.sAction + "}";
                                if (ot.ClassName.Length > 0)
                                {
                                    sLine += " {" + ot.ClassName + "}";
                                }

                                oStreamWriter.WriteLine(sLine);
                            }

                            oStreamWriter.Close();
                        }
                        finally
                        {
                            ReleaseReaderLock();
                        }
                    }
                    else
                    {
                        throw new Exception("Unable to aquire reader lock.");
                    }

                    return true;
                }
                #pragma warning disable CS0168
                catch (Exception ex)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }
        }

        public class HighlightLineBeginsWith : Collections.SortedList
        {
            public class Highlight
            {
                public string Text = string.Empty;
                public string ColorName = string.Empty;
                public Color FgColor;
                public Color BgColor;
                public bool CaseSensitive = true;
                public string ClassName = string.Empty;
                public bool IsActive = true;
                public string SoundFile = string.Empty;

                public Highlight(string Text, string ColorName, Color FgColor, Color BgColor, bool CaseSensitive = true, string SoundFile = "", string ClassName = "", bool IsActive = true)
                {
                    this.Text = Text;
                    this.ColorName = ColorName;
                    this.FgColor = FgColor;
                    this.BgColor = BgColor;
                    this.CaseSensitive = CaseSensitive;
                    this.SoundFile = SoundFile;
                    this.ClassName = ClassName;
                    this.IsActive = IsActive;
                }
            }

            public void ToggleClass(string ClassName, bool Value)
            {
                if (AcquireReaderLock())
                {
                    var al = new ArrayList();
                    try
                    {
                        foreach (string s in base.Keys)
                            al.Add(s);
                    }
                    finally
                    {
                        ReleaseReaderLock();
                        foreach (string s in al)
                        {
                            Highlight hl = (Highlight)base[s];
                            if ((hl.ClassName.ToLower() ?? "") == (ClassName.ToLower() ?? ""))
                            {
                                hl.IsActive = Value;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Unable to aquire reader lock.");
                }
            }

            public bool Add(string sKey, string sColorName, bool CaseSensitive = true, string SoundFile = "", string ClassName = "", bool IsActive = true)
            {
                if (sKey.Length == 0)
                {
                    return false;
                }
                else
                {
                    if (sKey.StartsWith("/") == true)
                    {
                        sKey = sKey.Substring(1);
                    }

                    if (sKey.EndsWith("/i") == true)
                    {
                        CaseSensitive = false;
                        sKey = sKey.Substring(0, sKey.Length - 2);
                    }
                    else if (sKey.EndsWith("/") == true)
                    {
                        sKey = sKey.Substring(0, sKey.Length - 1);
                    }

                    Color oColor;
                    Color oBgcolor;
                    if (sColorName.Contains(",") == true && sColorName.EndsWith(",") == false)
                    {
                        string sColor = sColorName.Substring(0, sColorName.IndexOf(",")).Trim();
                        string sBgColor = sColorName.Substring(sColorName.IndexOf(",") + 1).Trim();
                        oColor = ColorCode.StringToColor(sColor);
                        oBgcolor = ColorCode.StringToColor(sBgColor);
                    }
                    else
                    {
                        oColor = ColorCode.StringToColor(sColorName);
                        oBgcolor = Color.Transparent;
                    }

                    if (base.ContainsKey(sKey) == true)
                    {
                        base[sKey] = new Highlight(sKey, sColorName, oColor, oBgcolor, CaseSensitive, SoundFile, ClassName, IsActive);
                    }
                    else
                    {
                        object argvalue = new Highlight(sKey, sColorName, oColor, oBgcolor, CaseSensitive, SoundFile, ClassName, IsActive);
                        Add(sKey, argvalue);
                    }

                    return true;
                }
            }
        }

        public class HighlightRegExp : Collections.SortedList
        {
            public class Highlight
            {
                public string Text = string.Empty;
                public string ColorName = string.Empty;
                public Color FgColor;
                public Color BgColor;
                public bool CaseSensitive = true;
                public Regex HighlightRegex = null;
                public string ClassName = string.Empty;
                public bool IsActive = true;
                public string SoundFile = string.Empty;

                public Highlight(string text, string ColorName, Color FgColor, Color BgColor, bool CaseSensitive = true, string SoundFile = "", string ClassName = "", bool IsActive = true)
                {
                    Text = text;
                    this.ColorName = ColorName;
                    this.FgColor = FgColor;
                    this.BgColor = BgColor;
                    this.CaseSensitive = CaseSensitive;
                    if (CaseSensitive == false)
                    {
                        HighlightRegex = new Regex(text, MyRegexOptions.options | RegexOptions.IgnoreCase);
                    }
                    else
                    {
                        HighlightRegex = new Regex(text, MyRegexOptions.options);
                    }

                    this.SoundFile = SoundFile;
                    this.ClassName = ClassName;
                    this.IsActive = IsActive;
                }
            }

            public void ToggleClass(string ClassName, bool Value)
            {
                if (AcquireReaderLock())
                {
                    var al = new ArrayList();
                    try
                    {
                        foreach (string s in base.Keys)
                            al.Add(s);
                    }
                    finally
                    {
                        ReleaseReaderLock();
                        foreach (string s in al)
                        {
                            Highlight hl = (Highlight)base[s];
                            if ((hl.ClassName.ToLower() ?? "") == (ClassName.ToLower() ?? ""))
                            {
                                hl.IsActive = Value;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Unable to aquire reader lock.");
                }
            }

            public bool Add(string sKey, string sColorName, bool CaseSensitive = true, string SoundFile = "", string ClassName = "", bool IsActive = true)
            {
                if (sKey.Length == 0)
                {
                    return false;
                }
                else
                {
                    if (sKey.StartsWith("/") == true)
                    {
                        sKey = sKey.Substring(1);
                    }

                    if (sKey.EndsWith("/i") == true)
                    {
                        CaseSensitive = false;
                        sKey = sKey.Substring(0, sKey.Length - 2);
                    }
                    else if (sKey.EndsWith("/") == true)
                    {
                        sKey = sKey.Substring(0, sKey.Length - 1);
                    }

                    Color oColor;
                    Color oBgcolor;
                    if (sColorName.Contains(",") == true && sColorName.EndsWith(",") == false)
                    {
                        string sColor = sColorName.Substring(0, sColorName.IndexOf(",")).Trim();
                        string sBgColor = sColorName.Substring(sColorName.IndexOf(",") + 1).Trim();
                        oColor = ColorCode.StringToColor(sColor);
                        oBgcolor = ColorCode.StringToColor(sBgColor);
                    }
                    else
                    {
                        oColor = ColorCode.StringToColor(sColorName);
                        oBgcolor = Color.Transparent;
                    }

                    if (base.ContainsKey(sKey) == true)
                    {
                        base[sKey] = new Highlight(sKey, sColorName, oColor, oBgcolor, CaseSensitive, SoundFile, ClassName, IsActive);
                    }
                    else
                    {
                        object argvalue = new Highlight(sKey, sColorName, oColor, oBgcolor, CaseSensitive, SoundFile, ClassName, IsActive);
                        Add(sKey, argvalue);
                    }

                    return true;
                }
            }
        }

        public class SubstituteRegExp : Collections.ArrayList
        {
            public class Substitute
            {
                public string sText = string.Empty;
                public string sReplaceBy = string.Empty;
                public bool bIgnoreCase = false;
                public Regex SubstituteRegex = null;
                public string ClassName = string.Empty;
                public bool IsActive = true;

                public Substitute(string Text, string ReplaceBy, bool IgnoreCase = false, string ClassName = "", bool IsActive = true)
                {
                    sText = Text;
                    sReplaceBy = ReplaceBy;
                    bIgnoreCase = IgnoreCase;
                    if (IgnoreCase == true)
                    {
                        SubstituteRegex = new Regex(Text, MyRegexOptions.options | RegexOptions.IgnoreCase);
                    }
                    else
                    {
                        SubstituteRegex = new Regex(Text, MyRegexOptions.options);
                    }

                    this.ClassName = ClassName;
                    this.IsActive = IsActive;
                }
            }

            public bool Add(string sText, string ReplaceBy, bool IgnoreCase = false, string ClassName = "", bool IsActive = true)
            {
                if (sText.StartsWith("/") == true)
                {
                    sText = sText.Substring(1);
                }

                if (sText.EndsWith("/i") == true)
                {
                    IgnoreCase = true;
                    sText = sText.Substring(0, sText.Length - 2);
                }
                else if (sText.EndsWith("/") == true)
                {
                    sText = sText.Substring(0, sText.Length - 1);
                }

                if (Utility.ValidateRegExp(sText) == false)
                {
                    return false;
                }

                int I = Contains(sText);
                if (I > -1)
                {
                    set_Item(I, new Substitute(sText, ReplaceBy, IgnoreCase, ClassName, IsActive));
                }
                else
                {
                    object argvalue = new Substitute(sText, ReplaceBy, IgnoreCase, ClassName, IsActive);
                    Add(argvalue);
                }

                return true;
            }

            public void ToggleClass(string ClassName, bool Value)
            {
                if (AcquireReaderLock())
                {
                    var al = new ArrayList();
                    try
                    {
                        for (int I = 0, loopTo = base.Count - 1; I <= loopTo; I++)
                        {
                            if ((((Substitute)get_Item(I)).ClassName ?? "") == (ClassName ?? ""))
                            {
                                ((Substitute)get_Item(I)).IsActive = Value;
                            }
                        }
                    }
                    finally
                    {
                        ReleaseReaderLock();
                    }
                }
                else
                {
                    throw new Exception("Unable to aquire reader lock.");
                }
            }

            public void Remove(string Text)
            {
                for (int I = 0, loopTo = base.Count - 1; I <= loopTo; I++)
                {
                    if ((((Substitute)get_Item(I)).sText ?? "") == (Text ?? ""))
                    {
                        RemoveAt(I);
                        Remove(Text); // Recursively remove all
                        return;
                    }
                }
            }

            public int Contains(string Text)
            {
                for (int I = 0, loopTo = base.Count - 1; I <= loopTo; I++)
                {
                    if ((((Substitute)get_Item(I)).sText ?? "") == (Text ?? ""))
                    {
                        return I;
                    }
                }

                return -1;
            }

            public bool Load(string sFileName = "substitutes.cfg")
            {
                try
                {
                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        var oStreamReader = new StreamReader(sFileName);
                        string strLine = oStreamReader.ReadLine();
                        while (!Information.IsNothing(strLine))
                        {
                            LoadRow(strLine);
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
                #pragma warning disable CS0168
                catch (Exception Err)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }

            private void LoadRow(string sText)
            {
                var oArgs = Utility.ParseArgs(sText);
                if (oArgs.Count > 2)
                {
                    string sClass = string.Empty;
                    if (oArgs.Count > 3)
                    {
                        sClass = oArgs[3].ToString();
                    }

                    var arg1 = oArgs[1].ToString();
                    var arg2 = oArgs[2].ToString();
                    Add(arg1, arg2, false, sClass);
                }
            }

            public bool Save(string sFileName = "substitutes.cfg")
            {
                try
                {
                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        Utility.DeleteFile(sFileName);
                    }

                    if (AcquireReaderLock())
                    {
                        try
                        {
                            var oStreamWriter = new StreamWriter(sFileName, false);
                            for (int I = 0, loopTo = base.Count - 1; I <= loopTo; I++)
                            {
                                Substitute os = (Substitute)get_Item(I);
                                string sKey = os.sText;
                                if (os.bIgnoreCase == true)
                                {
                                    sKey = "/" + sKey + "/i";
                                }

                                string sLine = "#subs {" + sKey + "} {" + os.sReplaceBy + "}";
                                if (os.ClassName.Length > 0)
                                {
                                    sLine += " {" + os.ClassName + "}";
                                }

                                oStreamWriter.WriteLine(sLine);
                            }

                            oStreamWriter.Close();
                        }
                        finally
                        {
                            ReleaseReaderLock();
                        }
                    }
                    else
                    {
                        throw new Exception("Unable to aquire reader lock.");
                    }

                    return true;
                }
                #pragma warning disable CS0168
                catch (Exception ex)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }
        }

        public class GagRegExp : Collections.ArrayList
        {
            public class Gag
            {
                public string Text = string.Empty;
                public bool bIgnoreCase = false;
                public Regex RegexGag = null;
                public string ClassName = string.Empty;
                public bool IsActive = true;

                public Gag(string Text, bool IgnoreCase = false, string ClassName = "", bool IsActive = true)
                {
                    this.Text = Text;
                    bIgnoreCase = IgnoreCase;
                    if (IgnoreCase == true)
                    {
                        RegexGag = new Regex(Text, MyRegexOptions.options | RegexOptions.IgnoreCase);
                    }
                    else
                    {
                        RegexGag = new Regex(Text, MyRegexOptions.options);
                    }

                    this.ClassName = ClassName;
                    this.IsActive = IsActive;
                }
            }

            public bool Add(string sText, bool IgnoreCase = false, string ClassName = "", bool IsActive = true)
            {
                if (sText.StartsWith("/") == true)
                {
                    sText = sText.Substring(1);
                }

                if (sText.EndsWith("/i") == true)
                {
                    IgnoreCase = true;
                    sText = sText.Substring(0, sText.Length - 2);
                }
                else if (sText.EndsWith("/") == true)
                {
                    sText = sText.Substring(0, sText.Length - 1);
                }

                if (Utility.ValidateRegExp(sText) == false)
                {
                    return false;
                }

                int I = Contains(sText);
                if (I > -1)
                {
                    set_Item(I, new Gag(sText, IgnoreCase, ClassName, true));
                }
                else
                {
                    object argvalue = new Gag(sText, IgnoreCase, ClassName, true);
                    Add(argvalue);
                }

                return true;
            }

            public void ToggleClass(string ClassName, bool Value)
            {
                if (AcquireReaderLock())
                {
                    var al = new ArrayList();
                    try
                    {
                        for (int I = 0, loopTo = base.Count - 1; I <= loopTo; I++)
                        {
                            if ((((Gag)get_Item(I)).ClassName ?? "") == (ClassName ?? ""))
                            {
                                ((Gag)get_Item(I)).IsActive = Value;
                            }
                        }
                    }
                    finally
                    {
                        ReleaseReaderLock();
                    }
                }
                else
                {
                    throw new Exception("Unable to aquire reader lock.");
                }
            }

            public void Remove(string Text)
            {
                for (int I = 0, loopTo = base.Count - 1; I <= loopTo; I++)
                {
                    if ((((Gag)get_Item(I)).Text ?? "") == (Text ?? ""))
                    {
                        RemoveAt(I);
                        Remove(Text); // Recursively remove all
                        return;
                    }
                }
            }

            public int Contains(string Text)
            {
                for (int I = 0, loopTo = base.Count - 1; I <= loopTo; I++)
                {
                    if ((((Gag)get_Item(I)).Text ?? "") == (Text ?? ""))
                    {
                        return I;
                    }
                }

                return -1;
            }

            public bool Load(string sFileName = "gags.cfg")
            {
                try
                {
                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        var oStreamReader = new StreamReader(sFileName);
                        string strLine = oStreamReader.ReadLine();
                        while (!Information.IsNothing(strLine))
                        {
                            LoadRow(strLine);
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
                #pragma warning disable CS0168
                catch (Exception Err)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }

            private void LoadRow(string sText)
            {
                var oArgs = Utility.ParseArgs(sText);
                if (oArgs.Count > 1)
                {
                    string sClass = string.Empty;
                    if (oArgs.Count > 2)
                    {
                        sClass = oArgs[2].ToString();
                    }

                    var arg1 = oArgs[0].ToString();
                    var arg2 = oArgs[1].ToString();
                    Add(arg2, false, sClass);

                }
            }

            public bool Save(string sFileName = "gags.cfg")
            {
                try
                {
                    if (sFileName.IndexOf(@"\") == -1)
                    {
                        sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                    }

                    if (File.Exists(sFileName) == true)
                    {
                        Utility.DeleteFile(sFileName);
                    }

                    if (AcquireReaderLock())
                    {
                        try
                        {
                            var oStreamWriter = new StreamWriter(sFileName, false);
                            for (int I = 0, loopTo = base.Count - 1; I <= loopTo; I++)
                            {
                                Gag os = (Gag)get_Item(I);
                                string sKey = os.Text;
                                if (os.bIgnoreCase == true)
                                {
                                    sKey = "/" + sKey + "/i";
                                }

                                string sLine = "#gag {" + sKey + "}";
                                if (os.ClassName.Length > 0)
                                {
                                    sLine += " {" + os.ClassName + "}";
                                }

                                oStreamWriter.WriteLine(sLine);
                            }

                            oStreamWriter.Close();
                        }
                        finally
                        {
                            ReleaseReaderLock();
                        }
                    }
                    else
                    {
                        throw new Exception("Unable to aquire reader lock.");
                    }

                    return true;
                }
                #pragma warning disable CS0168
                catch (Exception ex)
                #pragma warning restore CS0168
                {
                    return false;
                }
            }
        }

        public Globals()
        {
            VariableList.SetDefaultGlobalVars();
        }

        public bool SaveHighlights(string sFileName = "highlights.cfg")
        {
            // Try
            if (sFileName.IndexOf(@"\") == -1)
            {
                sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
            }

            if (File.Exists(sFileName) == true)
            {
                Utility.DeleteFile(sFileName);
            }

            var oStreamWriter = new StreamWriter(sFileName, false);
            foreach (string sKey in HighlightList.Keys)
            {
                Highlights.Highlight oHighlight = (Highlights.Highlight)HighlightList[sKey];
                string sColorName = oHighlight.ColorName;
                string sText = sKey;
                if (oHighlight.CaseSensitive == false)
                {
                    sText = "/" + sText + "/i";
                }

                string sLine = string.Empty;
                if (oHighlight.HighlightWholeRow == true)
                {
                    sLine = "#highlight {line} {" + sColorName + "} {" + sText + "}";
                }
                else
                {
                    sLine = "#highlight {string} {" + sColorName + "} {" + sText + "}";
                }

                if (oHighlight.ClassName.Length > 0 | oHighlight.SoundFile.Length > 0)
                {
                    sLine += " {" + oHighlight.ClassName + "}";
                }

                if (oHighlight.SoundFile.Length > 0)
                {
                    sLine += " {" + oHighlight.SoundFile + "}";
                }

                oStreamWriter.WriteLine(sLine);
            }

            foreach (string sKey in HighlightBeginsWithList.Keys)
            {
                HighlightLineBeginsWith.Highlight oHighlight = (HighlightLineBeginsWith.Highlight)HighlightBeginsWithList[sKey];
                string sColorName = oHighlight.ColorName;
                string sText = oHighlight.Text;
                if (oHighlight.CaseSensitive == false)
                {
                    sText = "/" + sText + "/i";
                }

                string sLine = "#highlight {beginswith} {" + sColorName + "} {" + sText + "}";
                if (oHighlight.ClassName.Length > 0 | oHighlight.SoundFile.Length > 0)
                {
                    sLine += " {" + oHighlight.ClassName + "}";
                }

                if (oHighlight.SoundFile.Length > 0)
                {
                    sLine += " {" + oHighlight.SoundFile + "}";
                }

                oStreamWriter.WriteLine(sLine);
            }

            foreach (string sKey in HighlightRegExpList.Keys)
            {
                HighlightRegExp.Highlight oHighlight = (HighlightRegExp.Highlight)HighlightRegExpList[sKey];
                string sColorName = oHighlight.ColorName;
                string sText = oHighlight.Text;
                if (oHighlight.CaseSensitive == false)
                {
                    sText = "/" + sText + "/i";
                }

                string sLine = "#highlight {regexp} {" + sColorName + "} {" + sText + "}";
                if (oHighlight.ClassName.Length > 0 | oHighlight.SoundFile.Length > 0)
                {
                    sLine += " {" + oHighlight.ClassName + "}";
                }

                if (oHighlight.SoundFile.Length > 0)
                {
                    sLine += " {" + oHighlight.SoundFile + "}";
                }

                oStreamWriter.WriteLine(sLine);
            }

            oStreamWriter.Close();
            return true;
        }

        public bool LoadHighlights(string sFileName = "highlights.cfg")
        {
            try
            {
                if (sFileName.IndexOf(@"\") == -1)
                {
                    sFileName = LocalDirectory.Path + @"\Config\" + sFileName;
                }

                if (File.Exists(sFileName) == true)
                {
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    var oStreamReader = new StreamReader(sFileName);
                    string strLine = oStreamReader.ReadLine();
                    while (!Information.IsNothing(strLine))
                    {
                        var oArgs = Utility.ParseArgs(strLine);
                        if (oArgs.Count > 3)
                        {
                            AddHighlight(strLine);
                        }

                        strLine = oStreamReader.ReadLine();
                    }

                    oStreamReader.Close();
                    HighlightList.RebuildLineIndex();
                    HighlightList.RebuildStringIndex();
                    /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #pragma warning disable CS0168
            catch (Exception Err)
            #pragma warning restore CS0168
            {
                return false;
            }
        }

        private void AddHighlight(string sLine)
        {
            var oArgs = new ArrayList();
            oArgs = Utility.ParseArgs(sLine);
            if (oArgs.Count > 0)
            {
                if (Conversions.ToString(oArgs[0]).Length > 0)
                {
                    string sClass = string.Empty;
                    string sSound = string.Empty;
                    string sHighlight = oArgs[3].ToString();
                    if (sLine.Contains("{"))
                    {
                        if (oArgs.Count > 4)
                            sClass = oArgs[4].ToString();
                        if (oArgs.Count > 5)
                            sSound = oArgs[5].ToString();
                    }
                    else // Add all args after 3 for highlights added without {} args.
                    {
                        sHighlight = Utility.ArrayToString(oArgs, 3);
                    }

                    var switchExpr = Conversions.ToString(oArgs[0]).Substring(1);
                    switch (switchExpr)
                    {
                        case "highlight":
                        case "highlights":
                            {
                                var switchExpr1 = oArgs[1].ToString().ToLower();
                                switch (switchExpr1)
                                {
                                    case "line":
                                    case "lines":
                                        {
                                            if (oArgs.Count > 3)
                                            {
                                                bool argbHighlightWholeRow = true;
                                                var arg1 = oArgs[1].ToString();
                                                var arg2 = oArgs[2].ToString();
                                                var arg3 = oArgs[3].ToString();
                                                HighlightList.Add(arg3, argbHighlightWholeRow, arg2, true, sSound, sClass);
                                            }

                                            break;
                                        }

                                    case "string":
                                    case "strings":
                                        {
                                            if (oArgs.Count > 3)
                                            {
                                                bool argbHighlightWholeRow1 = false;
                                                var arg1 = oArgs[1].ToString();
                                                var arg2 = oArgs[2].ToString();
                                                var arg3 = oArgs[3].ToString();
                                                HighlightList.Add(arg3, argbHighlightWholeRow1, arg2, true, sSound, sClass);
                                            }

                                            break;
                                        }

                                    case "beginswith":
                                        {
                                            if (oArgs.Count > 3)
                                            {
                                                var arg1 = oArgs[1].ToString();
                                                var arg2 = oArgs[2].ToString();
                                                var arg3 = oArgs[3].ToString();
                                                HighlightBeginsWithList.Add(arg3, arg2, true, sSound, sClass);
                                            }

                                            break;
                                        }

                                    case "regexp":
                                    case "regex":
                                        {
                                            if (oArgs.Count > 3)
                                            {
                                                string argsRegExp = ParseGlobalVars(oArgs[3].ToString());
                                                if (Utility.ValidateRegExp(argsRegExp) == true)
                                                {
                                                    var arg1 = oArgs[1].ToString();
                                                    var arg2 = oArgs[2].ToString();
                                                    var arg3 = oArgs[3].ToString();
                                                    HighlightRegExpList.Add(arg3, arg2, true, sSound, sClass);
                                                }
                                            }

                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }
            }
        }
    }
}