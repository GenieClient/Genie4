using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using GenieClient.Services;
#if WINDOWS
using System.Drawing;
#endif

namespace GenieClient.Genie
{
    public class Names : Collections.SortedList
    {
        private Regex m_oRegexNames = null;

        public Regex RegexNames
        {
            get
            {
                return m_oRegexNames;
            }

            set
            {
                m_oRegexNames = value;
            }
        }

        public class Name
        {
            public GenieColor Foreground;
            public GenieColor Background;
            public string ColorName;

#if WINDOWS
            // Legacy properties for backward compatibility with Windows Forms UI layer
            public Color FgColor
            {
                get => Foreground.ToDrawingColor();
                set => Foreground = value.ToGenieColor();
            }

            public Color BgColor
            {
                get => Background.ToDrawingColor();
                set => Background = value.ToGenieColor();
            }

            public Name(Color oColor, Color oBgColor, string sColorName = "")
            {
                Foreground = oColor.ToGenieColor();
                Background = oBgColor.ToGenieColor();
                ColorName = sColorName;
            }
#endif

            public Name(GenieColor fgColor, GenieColor bgColor, string sColorName = "")
            {
                Foreground = fgColor;
                Background = bgColor;
                ColorName = sColorName;
            }
        }

        public bool Add(string sKey, string sColorName)
        {
            if (sKey.Length == 0)
            {
                return false;
            }
            else
            {
                GenieColor oColor;
                GenieColor oBgcolor;
                if (sColorName.Contains(",") == true && sColorName.EndsWith(",") == false)
                {
                    string sColor = sColorName.Substring(0, sColorName.IndexOf(",")).Trim();
                    string sBgColor = sColorName.Substring(sColorName.IndexOf(",") + 1).Trim();
                    oColor = ColorCode.StringToGenieColor(sColor);
                    oBgcolor = ColorCode.StringToGenieColor(sBgColor);
                }
                else
                {
                    oColor = ColorCode.StringToGenieColor(sColorName);
                    oBgcolor = GenieColor.Transparent;
                }

                if (base.ContainsKey(sKey) == true)
                {
                    base[sKey] = new Name(oColor, oBgcolor, sColorName);
                }
                else
                {
                    object argvalue = new Name(oColor, oBgcolor, sColorName);
                    Add(sKey, argvalue);
                }

                return true;
            }
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

        public void RebuildIndex()
        {
            var al = new ArrayList();
            foreach (string s in base.Keys)
                al.Add(s);
            al.Sort();
            string sList = string.Empty;
            foreach (string s in al)
            {
                if (sList.Length > 0)
                {
                    sList += "|";
                }

                sList += s;
            }

            if (sList.Length > 0)
            {
                sList = @"\b(" + sList + @")\b";
            }

            m_oRegexNames = new Regex(sList, MyRegexOptions.options);
        }

        public bool Load(string sFileName = "names.cfg")
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
                RebuildIndex();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoadRow(string sText)
        {
            var oArgs = Utility.ParseArgs(sText);
            if (oArgs.Count == 3)
            {
                Add(oArgs[2].ToString(), oArgs[1].ToString());
            }
        }

        public bool Save(string sFileName = "names.cfg")
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
                        foreach (string key in base.Keys)
                        {
                            string sColorName = ((Name)base[key]).ColorName;
                            if (sColorName.Length == 0)
                            {
                                sColorName = ColorCode.GenieColorToHex(((Name)base[key]).Foreground) + "," + ColorCode.GenieColorToHex(((Name)base[key]).Background);
                            }

                            oStreamWriter.WriteLine("#name {" + sColorName + "} {" + key + "}");
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
}