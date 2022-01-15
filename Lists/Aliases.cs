using System;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie
{
    public class Aliases : Collections.SortedList
    {
        public bool Add(string sKey, string sAlias)
        {
            if (base.ContainsKey(sKey) == true)
            {
                base[sKey] = sAlias;
            }
            else
            {
                object argvalue = sAlias;
                Add(sKey, argvalue);
            }

            return true;
        }

        public int Remove(string sKey)
        {
            if (base.ContainsKey(sKey) == true)
            {
                base.Remove(sKey);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private string m_FileName = LocalDirectory.Path + @"\Config\" + "aliases.cfg";

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
                Add(oArgs[1].ToString(), oArgs[2].ToString());
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
                            oStreamWriter.WriteLine("#alias {" + Conversions.ToString(key).ToString() + "} {" + base[key].ToString() + "}");
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