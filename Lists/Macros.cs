using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie
{
    public class Macros : Collections.SortedList
    {
        public class Macro
        {
            public string sKey = string.Empty;
            public string sAction = string.Empty;

            public Macro(string sKey, string sMacro)
            {
                this.sKey = sKey;
                sAction = sMacro;
            }
        }

        public bool Add(string sKey, string sMacro)
        {
            Keys oKey;
            oKey = KeyCode.StringToKey(sKey);
            if (oKey == System.Windows.Forms.Keys.None)
            {
                return false;
            }
            else
            {
                if (base.ContainsKey(oKey) == true)
                {
                    base[oKey] = new Macro(sKey, sMacro);
                }
                else
                {
                    object argvalue = new Macro(sKey, sMacro);
                    Add(oKey, argvalue);
                }

                return true;
            }
        }

        public int Remove(string sKey)
        {
            Keys oKey;
            oKey = KeyCode.StringToKey(sKey);
            if (oKey == System.Windows.Forms.Keys.None)
            {
                return -1;
            }
            else if (base.ContainsKey(oKey) == true)
            {
                Remove(oKey);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private string m_FileName = LocalDirectory.Path + @"\Config\" + "macros.cfg";

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
                Keys oKey;
                oKey = KeyCode.StringToKey(oArgs[1].ToString());
                if (oKey != System.Windows.Forms.Keys.None)
                {
                    string argsKey = Conversions.ToString(oKey);
                    Add(argsKey, oArgs[2].ToString());
                }
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
                        foreach (object key in base.Keys)
                            oStreamWriter.WriteLine("#macro {" + ((Keys)Conversions.ToInteger(key)).ToString() + "} {" + ((Macro)base[key]).sAction + "}");
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
}