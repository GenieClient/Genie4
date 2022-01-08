using System;
using System.Collections;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie
{
    public class Classes : Collections.SortedList
    {
        public void ActivateAll()
        {
            var oList = new ArrayList();
            if (AcquireReaderLock())
            {
                try
                {
                    foreach (object key in base.Keys)
                        oList.Add(key);
                }
                finally
                {
                    ReleaseReaderLock();
                    foreach (object key in oList)
                        base[key] = true;
                }
            }
            else
            {
                throw new Exception("Unable to aquire reader lock.");
            }
        }

        public void InActivateAll()
        {
            var oList = new ArrayList();
            if (AcquireReaderLock())
            {
                try
                {
                    foreach (object key in base.Keys)
                        oList.Add(key);
                }
                finally
                {
                    ReleaseReaderLock();
                    foreach (object key in oList)
                    {
                        if ((key.ToString() ?? "") != "default")
                        {
                            base[key] = false;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Unable to aquire reader lock.");
            }
        }

        public bool GetValue(string sKey)
        {
            if (sKey.Length == 0) // Default
            {
                return Conversions.ToBoolean(base["default"]);
            }
            else if (base.ContainsKey(sKey.ToLower()))
            {
                return Conversions.ToBoolean(base[sKey.ToLower()]);
            }
            else
            {
                object argvalue = true;
                Add(sKey.ToLower(), argvalue);
                return true;
            }
        }

        public new void Clear()
        {
            base.Clear();
            object argvalue = "True";
            Add("default", argvalue);
        }

        public bool Add(string sKey, string sValue)
        {
            bool bActive = false;
            var switchExpr = sValue.ToLower();
            switch (switchExpr)
            {
                case "true":
                case "on":
                case "1":
                    {
                        bActive = true;
                        break;
                    }

                case "false":
                case "off":
                case "0":
                    {
                        bActive = false;
                        break;
                    }
            }

            if (base.ContainsKey(sKey) == true)
            {
                base[sKey] = bActive;
            }
            else
            {
                object argvalue = bActive;
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

        private string m_FileName = LocalDirectory.Path + @"\Config\" + "classes.cfg";

        public bool Load(string sFileName = null)
        {
            try
            {
                if (Information.IsNothing(sFileName))
                {
                    sFileName = m_FileName;
                }

                string argsKey = "default";
                string argsValue = "True";
                Add(argsKey, argsValue);
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
                Add(oArgs[1].ToString(), oArgs[2].ToString().ToLower());
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
                            oStreamWriter.WriteLine("#class {" + Conversions.ToString(key).ToString() + "} {" + Conversions.ToBoolean(base[key]).ToString() + "}");
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