using System;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;

namespace GenieClient.Genie
{
    public class Highlights : Collections.SortedList
    {
        private Regex m_oRegexString = null;
        private Regex m_oRegexLine = null;

        public Regex RegexString
        {
            get
            {
                return m_oRegexString;
            }

            set
            {
                m_oRegexString = value;
            }
        }

        public Regex RegexLine
        {
            get
            {
                return m_oRegexLine;
            }

            set
            {
                m_oRegexLine = value;
            }
        }

        public void ToggleClass(string ClassName, bool Value)
        {
            if (AcquireReaderLock())
            {
                var al = new Genie.Collections.ArrayList();
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

        public class Highlight
        {
            public Color FgColor;
            public Color BgColor;
            public string ColorName = string.Empty;
            public bool HighlightWholeRow = false;
            public bool CaseSensitive = true;
            public string ClassName = string.Empty;
            public bool IsActive = true;
            public string SoundFile = string.Empty;

            public Highlight(Color oColor, string sColorName, Color oBgColor, bool bHighlightWholeRow, bool CaseSensitive = true, string SoundFile = "", string ClassName = "", bool IsActive = true)
            {
                FgColor = oColor;
                BgColor = oBgColor;
                HighlightWholeRow = bHighlightWholeRow;
                ColorName = sColorName;
                this.CaseSensitive = CaseSensitive;
                this.SoundFile = SoundFile;
                this.ClassName = ClassName;
                this.IsActive = IsActive;
            }
        }

        public bool Add(string sKey, bool bHighlightWholeRow, string sColorName, bool bCaseSensitive = true, string SoundFile = "", string ClassName = "", bool IsActive = true)
        {
            if (sKey.Length == 0)
            {
                return false;
            }
            else
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

                if (base.ContainsKey(sKey) == true)
                {
                    base[sKey] = new Highlight(oColor, sColorName, oBgcolor, bHighlightWholeRow, bCaseSensitive, SoundFile, ClassName, IsActive);
                }
                else
                {
                    object argvalue = new Highlight(oColor, sColorName, oBgcolor, bHighlightWholeRow, bCaseSensitive, SoundFile, ClassName, IsActive);
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

        public void RebuildStringIndex()
        {
            if (AcquireReaderLock())
            {
                try
                {
                    var al = new Genie.Collections.ArrayList();
                    foreach (string s in base.Keys)
                    {
                        if (((Highlight)base[s]).IsActive == true)
                        {
                            if (((Highlight)base[s]).HighlightWholeRow == false)
                            {
                                al.Add(s);
                            }
                        }
                    }

                    al.Sort();
                    string sList = string.Empty;
                    foreach (string s in al)
                    {
                        if (sList.Length > 0)
                        {
                            sList += "|";
                        }

                        sList += Regex.Replace(s, @"([^A-Za-z0-9\s])", @"\$1");
                    }

                    if (sList.Length > 0)
                    {
                        sList = "(" + sList + ")";
                    }

                    RegexString = new Regex(sList);
                }
                finally
                {
                    ReleaseReaderLock();
                }
            }
            else
            {
                throw new Exception("Unable to aquire writer lock.");
            }
        }

        public void RebuildLineIndex()
        {
            if (AcquireReaderLock())
            {
                try
                {
                    var al = new Genie.Collections.ArrayList();
                    foreach (string s in base.Keys)
                    {
                        if (((Highlight)base[s]).IsActive == true)
                        {
                            if (((Highlight)base[s]).HighlightWholeRow == true)
                            {
                                al.Add(s);
                            }
                        }
                    }

                    al.Sort();
                    string sList = string.Empty;
                    foreach (string s in al)
                    {
                        if (sList.Length > 0)
                        {
                            sList += "|";
                        }

                        sList += Regex.Replace(s, @"([^A-Za-z0-9\s])", @"\$1");
                    }

                    if (sList.Length > 0)
                    {
                        sList = "(" + sList + ")";
                    }

                    RegexLine = new Regex(sList);
                }
                finally
                {
                    ReleaseReaderLock();
                }
            }
            else
            {
                throw new Exception("Unable to aquire writer lock.");
            }
        }
    }
}