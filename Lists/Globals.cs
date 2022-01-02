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

        public DateTime oSpellTimeStart;
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
            double d = Utility.GetTimeDiffInMilliseconds(oSpellTimeStart, argoDateEnd);
            if (d > 0 & oSpellTimeStart != m_oBlankTimer)
            {
                sText = sText.Replace("@spelltime@", (d / 1000).ToString());
            }
            else
            {
                sText = sText.Replace("@spelltime@", "0");
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
                string argsKey = "roomname";
                string argsColorName = "Yellow,DarkBlue";
                Add(argsKey, argsColorName);
                string argsKey1 = "roomdesc";
                string argsColorName1 = "Silver";
                Add(argsKey1, argsColorName1);
                string argsKey2 = "creatures";
                string argsColorName2 = "Cyan";
                Add(argsKey2, argsColorName2);
                string argsKey3 = "speech";
                string argsColorName3 = "Yellow";
                Add(argsKey3, argsColorName3);
                string argsKey4 = "whispers";
                string argsColorName4 = "Magenta";
                Add(argsKey4, argsColorName4);
                string argsKey5 = "thoughts";
                string argsColorName5 = "Cyan";
                Add(argsKey5, argsColorName5);
                // Add("watching", "0")
                // Add("commands", "0")
                // Add("echo", "0")
                // Add("scriptecho", "0")
                // Add("scriptcommands", "0")
                // Add("scripterrors", "0")
                // Add("scriptdebug", "0")

                // Add("default", "WhiteSmoke")
                // Add("object", "Transparent,#152525")
                // Add("objectnoun", "Cyan,#152525")

                string argsKey6 = "roundtime";
                string argsColorName6 = "MediumBlue,#00004b";
                Add(argsKey6, argsColorName6);
                string argsKey7 = "health";
                string argsColorName7 = "Maroon,#400000";
                Add(argsKey7, argsColorName7);
                string argsKey8 = "mana";
                string argsColorName8 = "Navy,#000040";
                Add(argsKey8, argsColorName8);
                string argsKey9 = "stamina";
                string argsColorName9 = "Green,#004000";
                Add(argsKey9, argsColorName9);
                string argsKey10 = "spirit";
                string argsColorName10 = "Purple,#400040";
                Add(argsKey10, argsColorName10);
                string argsKey11 = "concentration";
                string argsColorName11 = "Navy,#000040";
                Add(argsKey11, argsColorName11);
                string argsKey12 = "inputuser";
                string argsColorName12 = "Yellow";
                Add(argsKey12, argsColorName12);
                string argsKey13 = "inputother";
                string argsColorName13 = "GreenYellow";
                Add(argsKey13, argsColorName13);
                string argsKey14 = "scriptecho";
                string argsColorName14 = "Cyan";
                Add(argsKey14, argsColorName14);
                string argsKey15 = "familiar";
                string argsColorName15 = "PaleGreen";
                Add(argsKey15, argsColorName15);
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
                string argkey = "north";
                string argvalue = "0";
                Add(argkey, argvalue, VariableType.Reserved);
                string argkey1 = "northeast";
                string argvalue1 = "0";
                Add(argkey1, argvalue1, VariableType.Reserved);
                string argkey2 = "east";
                string argvalue2 = "0";
                Add(argkey2, argvalue2, VariableType.Reserved);
                string argkey3 = "southeast";
                string argvalue3 = "0";
                Add(argkey3, argvalue3, VariableType.Reserved);
                string argkey4 = "south";
                string argvalue4 = "0";
                Add(argkey4, argvalue4, VariableType.Reserved);
                string argkey5 = "southwest";
                string argvalue5 = "0";
                Add(argkey5, argvalue5, VariableType.Reserved);
                string argkey6 = "west";
                string argvalue6 = "0";
                Add(argkey6, argvalue6, VariableType.Reserved);
                string argkey7 = "northwest";
                string argvalue7 = "0";
                Add(argkey7, argvalue7, VariableType.Reserved);
                string argkey8 = "up";
                string argvalue8 = "0";
                Add(argkey8, argvalue8, VariableType.Reserved);
                string argkey9 = "down";
                string argvalue9 = "0";
                Add(argkey9, argvalue9, VariableType.Reserved);
                string argkey10 = "out";
                string argvalue10 = "0";
                Add(argkey10, argvalue10, VariableType.Reserved);
                string argkey11 = "roomname";
                string argvalue11 = "";
                Add(argkey11, argvalue11, VariableType.Reserved);
                string argkey12 = "roomdesc";
                string argvalue12 = "";
                Add(argkey12, argvalue12, VariableType.Reserved);
                string argkey13 = "roomobjs";
                string argvalue13 = "";
                Add(argkey13, argvalue13, VariableType.Reserved);
                string argkey14 = "roomplayers";
                string argvalue14 = "";
                Add(argkey14, argvalue14, VariableType.Reserved);
                string argkey15 = "roomexits";
                string argvalue15 = "";
                Add(argkey15, argvalue15, VariableType.Reserved);
                string argkey16 = "concentration";
                string argvalue16 = "100";
                Add(argkey16, argvalue16, VariableType.Reserved);
                string argkey17 = "encumbrance";
                string argvalue17 = "0";
                Add(argkey17, argvalue17, VariableType.Reserved);
                string argkey18 = "health";
                string argvalue18 = "100";
                Add(argkey18, argvalue18, VariableType.Reserved);
                string argkey19 = "mana";
                string argvalue19 = "100";
                Add(argkey19, argvalue19, VariableType.Reserved);
                string argkey20 = "spirit";
                string argvalue20 = "100";
                Add(argkey20, argvalue20, VariableType.Reserved);
                string argkey21 = "stamina";
                string argvalue21 = "100";
                Add(argkey21, argvalue21, VariableType.Reserved);
                string argkey22 = "charactername";
                string argvalue22 = "";
                Add(argkey22, argvalue22, VariableType.Reserved);
                string argkey23 = "gamename";
                string argvalue23 = "";
                Add(argkey23, argvalue23, VariableType.Reserved);
                string argkey24 = "kneeling";
                string argvalue24 = "0";
                Add(argkey24, argvalue24, VariableType.Reserved);
                string argkey25 = "prone";
                string argvalue25 = "0";
                Add(argkey25, argvalue25, VariableType.Reserved);
                string argkey26 = "sitting";
                string argvalue26 = "0";
                Add(argkey26, argvalue26, VariableType.Reserved);
                string argkey27 = "standing";
                string argvalue27 = "0";
                Add(argkey27, argvalue27, VariableType.Reserved);
                string argkey28 = "stunned";
                string argvalue28 = "0";
                Add(argkey28, argvalue28, VariableType.Reserved);
                string argkey29 = "hidden";
                string argvalue29 = "0";
                Add(argkey29, argvalue29, VariableType.Reserved);
                string argkey30 = "invisible";
                string argvalue30 = "0";
                Add(argkey30, argvalue30, VariableType.Reserved);
                string argkey31 = "dead";
                string argvalue31 = "0";
                Add(argkey31, argvalue31, VariableType.Reserved);
                string argkey32 = "joined";
                string argvalue32 = "0";
                Add(argkey32, argvalue32, VariableType.Reserved);
                string argkey33 = "bleeding";
                string argvalue33 = "0";
                Add(argkey33, argvalue33, VariableType.Reserved);
                string argkey34 = "webbed";
                string argvalue34 = "0";
                Add(argkey34, argvalue34, VariableType.Reserved);
                string argkey35 = "roundtime";
                string argvalue35 = "0";
                Add(argkey35, argvalue35, VariableType.Reserved);
                string argkey36 = "preparedspell";
                string argvalue36 = "None";
                Add(argkey36, argvalue36, VariableType.Reserved);
                string argkey37 = "lefthand";
                string argvalue37 = "Empty";
                Add(argkey37, argvalue37, VariableType.Reserved);
                string argkey38 = "lefthandnoun";
                string argvalue38 = "";
                Add(argkey38, argvalue38, VariableType.Reserved);
                string argkey39 = "righthand";
                string argvalue39 = "Empty";
                Add(argkey39, argvalue39, VariableType.Reserved);
                string argkey40 = "righthandnoun";
                string argvalue40 = "";
                Add(argkey40, argvalue40, VariableType.Reserved);
                string argkey41 = "gametime";
                string argvalue41 = "0";
                Add(argkey41, argvalue41, VariableType.Reserved);
                string argkey42 = "poisoned";
                string argvalue42 = "0";
                Add(argkey42, argvalue42, VariableType.Reserved);
                string argkey43 = "diseased";
                string argvalue43 = "0";
                Add(argkey43, argvalue43, VariableType.Reserved);
                string argkey44 = "connected";
                string argvalue44 = "0";
                Add(argkey44, argvalue44, VariableType.Reserved);
                string argkey45 = "version";
                var versionVar = My.MyProject.Application.Info.Version.ToString();
                Add(argkey45, versionVar, VariableType.Reserved);
                string argkey46 = "time";
                string argvalue45 = "@time@";
                Add(argkey46, argvalue45, VariableType.Reserved);
                string argkey47 = "date";
                string argvalue46 = "@date@";
                Add(argkey47, argvalue46, VariableType.Reserved);
                string argkey48 = "datetime";
                string argvalue47 = "@datetime@";
                Add(argkey48, argvalue47, VariableType.Reserved);
                string argkey49 = "spelltime";
                string argvalue48 = "@spelltime@";
                Add(argkey49, argvalue48, VariableType.Reserved);
                string argkey50 = "monstercount";
                string argvalue49 = "0";
                Add(argkey50, argvalue49, VariableType.Reserved);
                string argkey51 = "monsterlist";
                string argvalue50 = "";
                Add(argkey51, argvalue50, VariableType.Reserved);
                string argkey52 = "prompt";
                string argvalue51 = "";
                Add(argkey52, argvalue51, VariableType.Reserved);
                string argkey53 = "lastcommand";
                string argvalue52 = "";
                Add(argkey53, argvalue52, VariableType.Reserved);
                string argkey54 = "zoneid";
                string argvalue53 = "0";
                Add(argkey54, argvalue53, VariableType.Reserved);
                string argkey55 = "zonename";
                string argvalue54 = "0";
                Add(argkey55, argvalue54, VariableType.Reserved);
                string argkey56 = "scriptlist";
                string argvalue55 = "none";
                Add(argkey56, argvalue55, VariableType.Reserved);
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
                    Remove(sTrigger);
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

                    var arg1 = oArgs[1].ToString();
                    var arg2 = oArgs[2].ToString();
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