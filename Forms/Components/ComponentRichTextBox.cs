using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GenieClient.Genie;
using Jint.Debugger;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using static GenieClient.Genie.Globals;

namespace GenieClient
{
    public class ComponentRichTextBox : RichTextBox
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT2_STRUCT
        {
            public uint cbSize;
            public uint dwMask;
            public uint dwEffects;
            public int yHeight;
            public int yOffset;
            public int crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
            public ushort wWeight;
            public ushort sSpacing;
            public int crBackColor;
            // Color.ToArgb() -> int
            public int lcid;
            public int dwReserved;
            public short sStyle;
            public short wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
            public byte bReserved1;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private const int WM_USER = 0x400;
        private const int EM_GETCHARFORMAT = WM_USER + 58;
        private const int EM_SETCHARFORMAT = WM_USER + 68;
        private const int SCF_SELECTION = 0x1;
        private const int SCF_WORD = 0x2;
        private const int SCF_ALL = 0x4;

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private const uint CFE_BOLD = 1;
        private const uint CFE_ITALIC = 2;
        private const uint CFE_UNDERLINE = 4;
        private const uint CFE_STRIKEOUT = 8;
        private const uint CFE_PROTECTED = 16;
        private const uint CFE_LINK = 32;
        private const uint CFE_AUTOCOLOR = 1073741824;
        private const uint CFE_SUBSCRIPT = 65536;
        // Superscript and subscript are 
        private const uint CFE_SUPERSCRIPT = 131072;
        // mutually exclusive 

        private const int CFM_SMALLCAPS = 0x40;
        // (*) 
        private const int CFM_ALLCAPS = 0x80;
        // Displayed by 3.0 
        private const int CFM_HIDDEN = 0x100;
        // Hidden by 3.0 
        private const int CFM_OUTLINE = 0x200;
        // (*) 
        private const int CFM_SHADOW = 0x400;
        // (*) 
        private const int CFM_EMBOSS = 0x800;
        // (*) 
        private const int CFM_IMPRINT = 0x1000;
        // (*) 
        private const int CFM_DISABLED = 0x2000;
        private const int CFM_REVISED = 0x4000;
        private const int CFM_BACKCOLOR = 0x4000000;
        private const int CFM_LCID = 0x2000000;
        private const int CFM_UNDERLINETYPE = 0x800000;
        // Many displayed by 3.0 
        private const int CFM_WEIGHT = 0x400000;
        private const int CFM_SPACING = 0x200000;
        // Displayed by 3.0 
        private const int CFM_KERNING = 0x100000;
        // (*) 
        private const int CFM_STYLE = 0x80000;
        // (*) 
        private const int CFM_ANIMATION = 0x40000;
        // (*) 
        private const int CFM_REVAUTHOR = 0x8000;
        private const uint CFM_BOLD = 1;
        private const uint CFM_ITALIC = 2;
        private const uint CFM_UNDERLINE = 4;
        private const uint CFM_STRIKEOUT = 8;
        private const uint CFM_PROTECTED = 16;
        private const uint CFM_LINK = 32;
        private const uint CFM_SIZE = 134217728;
        private const uint CFM_COLOR = 1073741824;
        private const uint CFM_FACE = 536870912;
        private const uint CFM_OFFSET = 268435456;
        private const uint CFM_CHARSET = 134217728;
        private const uint CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        private const uint CFM_SUPERSCRIPT = CFM_SUBSCRIPT;
        private const byte CFU_UNDERLINENONE = 0;
        private const byte CFU_UNDERLINE = 1;
        private const byte CFU_UNDERLINEWORD = 2;
        // (*) displayed as ordinary underline 
        private const byte CFU_UNDERLINEDOUBLE = 3;
        // (*) displayed as ordinary underline 
        private const byte CFU_UNDERLINEDOTTED = 4;
        private const byte CFU_UNDERLINEDASH = 5;
        private const byte CFU_UNDERLINEDASHDOT = 6;
        private const byte CFU_UNDERLINEDASHDOTDOT = 7;
        private const byte CFU_UNDERLINEWAVE = 8;
        private const byte CFU_UNDERLINETHICK = 9;
        private const byte CFU_UNDERLINEHAIRLINE = 10;
        // (*) displayed as ordinary underline 

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private Win32Utility Win32Utility = new Win32Utility();
        // private int m_iMaxScroll = int.MinValue;
        private int m_iEndLine = int.MinValue;
        private FormSkin m_oParentForm;
        private RichTextBox m_oRichTextBuffer = new RichTextBox();
        private Font m_MonoFont = new Font("Courier New", 9, FontStyle.Regular);
        private bool m_bTimeStamp = false;
        private bool m_bNameListOnly = false;
        private int m_iMaxBufferSize = 500000;
        private bool m_bIsMainWindow = false;
       
        public bool IsMainWindow
        {
            get
            {
                return m_bIsMainWindow;
            }

            set
            {
                m_bIsMainWindow = value;
            }
        }

        public int MaxBufferSize
        {
            get
            {
                return m_iMaxBufferSize;
            }

            set
            {
                m_iMaxBufferSize = value;
            }
        }

        public bool TimeStamp
        {
            get
            {
                return m_bTimeStamp;
            }

            set
            {
                m_bTimeStamp = value;
            }
        }

        public bool NameListOnly
        {
            get
            {
                return m_bNameListOnly;
            }

            set
            {
                m_bNameListOnly = value;
            }
        }

        private string GetTimeString(string sText)
        {
            if (m_bTimeStamp == true)
            {
                if (sText.Trim().Length > 0)
                {
                    if (sText.StartsWith(" "))
                    {
                        return "[" + Strings.FormatDateTime(DateAndTime.Now, DateFormat.ShortTime) + "]";
                    }
                    else
                    {
                        return "[" + Strings.FormatDateTime(DateAndTime.Now, DateFormat.ShortTime) + "] ";
                    }
                }
            }

            return string.Empty;
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
                m_oRichTextBuffer.Font = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
                m_oRichTextBuffer.ForeColor = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
                m_oRichTextBuffer.BackColor = value;
            }
        }

        public Font MonoFont
        {
            get
            {
                return m_MonoFont;
            }

            set
            {
                m_MonoFont = value;
            }
        }

        private bool m_bSuspended = false;
        private bool m_bPendingNewLine = false;
        public delegate void AddImageDelegate(Image image);
        public delegate void AddTextDelegate(string sText, Color oColor, Color oBgColor, bool bNoCache, bool bMono);

        private void InvokeAddText(string sText, Color oColor, Color oBgColor, bool bNoCache, bool bMono)
        {
            if ((sText.Trim() ?? "") == "@suspend@") // Mainly for Room window logic so it's timed right.
            {
                if (IsMainWindow)
                    return;
                if (m_bSuspended == false)
                {
                    BeginUpdate();
                    m_bSuspended = true;
                }

                ClearWindow();
            }
            else if ((sText.Trim() ?? "") == "@resume@")
            {
                if (IsMainWindow)
                    return;
                if (m_bSuspended == true)
                {
                    SelectionStart = int.MaxValue;
                    InvokeEndUpdate();
                    EndUpdate();
                    m_bSuspended = false;
                }
            }
            else
            {
                if (m_bNameListOnly == true)
                {
                    if (!Information.IsNothing(m_oParentForm.Globals.NameList.RegexNames))
                    {
                        Match m = (Match)m_oParentForm.Globals.NameList.RegexNames.Match(sText);
                        if (m.Success == false)
                        {
                            return;
                        }
                    }
                }

                if (m_bPendingNewLine == true)
                {
                    var argoColor = Color.Transparent;
                    var argoBgColor = Color.Transparent;
                    Font argoFont = null;
                    var newLineVar = System.Environment.NewLine;
                    AddToBuffer(newLineVar, argoColor, argoBgColor, false, oFont: argoFont);
                    m_bPendingNewLine = false;
                }

                if (sText.EndsWith(System.Environment.NewLine))
                {
                    if (m_bIsMainWindow == false)
                    {
                        m_bPendingNewLine = true;
                        sText = sText.TrimEnd();
                    }
                }

                string argsText = GetTimeString(sText) + sText;
                Font argoFont1 = null;
                AddToBuffer(argsText, oColor, oBgColor, bMono, oFont: argoFont1);
            }
            if (Conversions.ToBoolean(bNoCache == true | m_oRichTextBuffer.Lines.Length >= m_oParentForm.Globals.Config.iBufferLineSize))
            {
                InvokeEndUpdate();
            }
            SetScrollBars();
        }
        public void AddImage(Image image)
        {
            if (IsDisposed || image == null)
            {
                return;
            }
            if (InvokeRequired == true)
            {
                var parameters = new object[] { image };
                Invoke(new AddImageDelegate(InvokeAddImage), parameters);
            }
            else
            {
                InvokeAddImage(image);
            }
        }

        private void InvokeAddImage(Image image)
        {
            IDataObject obj = Clipboard.GetDataObject();
            Clipboard.Clear();
            Clipboard.SetDataObject(image);
            this.ReadOnly = false;
            this.Select(this.TextLength,0);
            this.Paste(DataFormats.GetFormat(DataFormats.Bitmap));
            this.ReadOnly = true;
            Clipboard.Clear();
            Clipboard.SetDataObject(obj);
        }
        public void AddText(string sText, Color oColor, Color oBgColor, bool bNoCache = true, bool bMono = false)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired == true)
            {
                var parameters = new object[] { sText, oColor, oBgColor, bNoCache, bMono };
                Invoke(new AddTextDelegate(InvokeAddText), parameters);
            }
            else
            {
                InvokeAddText(sText, oColor, oBgColor, bNoCache, bMono);
            }
        }

        private Color m_oEmptyColor = default;

        private void AddToBuffer(string sText, Color oColor, Color oBgColor, bool bMono = false, Font oFont = null)
        {
            m_oRichTextBuffer.SelectionLength = 0;
            m_oRichTextBuffer.SelectionStart = int.MaxValue;
            int startIndex = m_oRichTextBuffer.SelectionStart;
            if (oColor != Color.Transparent & oColor != m_oEmptyColor)
            {
                m_oRichTextBuffer.SelectionColor = oColor;
            }
            else
            {
                m_oRichTextBuffer.SelectionColor = m_oRichTextBuffer.ForeColor;
            }

            if (oBgColor != Color.Transparent & oBgColor != m_oEmptyColor)
            {
                m_oRichTextBuffer.SelectionBackColor = oBgColor;
            }
            else
            {
                m_oRichTextBuffer.SelectionBackColor = m_oRichTextBuffer.BackColor;
            }

            if (!Information.IsNothing(oFont))
            {
                m_oRichTextBuffer.SelectionFont = oFont;
            }
            else if (bMono == true)
            {
                m_oRichTextBuffer.SelectionFont = MonoFont;
            }
            else
            {
                m_oRichTextBuffer.SelectionFont = Font;
            }

            if (sText.Length > 0)
            {
                m_oRichTextBuffer.SelectedText = sText;
            }
        }

        private void ParseLineHighlights(int StartIndex, string Line)
        {
            if (m_oRichTextBuffer.Text.Contains("You also see") && m_oParentForm.Globals.RoomObjects.Count > 0)
            {
                ParseVolatileHighlights(m_oParentForm.Globals.RoomObjects);
            }

            // Presets and Bold
            ParseVolatileHighlights(m_oParentForm.Globals.VolatileHighlights);

            //RegExp
            if (m_oParentForm.Globals.HighlightRegExpList.AcquireReaderLock())
            {
                try
                {
                    foreach (Globals.HighlightRegExp.Highlight oHighlight in m_oParentForm.Globals.HighlightRegExpList.Values)
                    {
                        if (oHighlight.IsActive) ParseRegExpHighlight(oHighlight);
                    }
                }
                finally
                {
                    m_oParentForm.Globals.HighlightRegExpList.ReleaseReaderLock();
                }
            }
            else
            {
                throw new Exception("Unable to aquire reader lock.");
            }
        }

        private void ParseRegExpHighlight(int StartIndex, string Line, Globals.HighlightRegExp.Highlight Highlight)
        {
            int iDiff = Line.Length - Line.TrimStart(Conversions.ToChar(Constants.vbCr)).Length; // RichText does not add both cr+lf
            foreach (Match oMatch in Highlight.HighlightRegex.Matches(Line))
            {
                if (oMatch.Groups.Count > 1)    // () highlighting
                {
                    foreach (Group oGroup in oMatch.Groups)
                    {
                        
                        m_oRichTextBuffer.SelectionStart = StartIndex + oGroup.Index - iDiff;
                        m_oRichTextBuffer.SelectionLength = oGroup.Length;
                        if (Highlight.FgColor != Color.Transparent & Highlight.FgColor != m_oEmptyColor)
                        {
                            m_oRichTextBuffer.SelectionColor = Highlight.FgColor;
                        }
                        if (Highlight.BgColor != Color.Transparent & Highlight.FgColor != m_oEmptyColor)
                        {
                            m_oRichTextBuffer.SelectionBackColor = Highlight.BgColor;
                        }
                    }
                }
                else // highlight the whole match
                {
                    m_oRichTextBuffer.SelectionStart = StartIndex - iDiff;
                    m_oRichTextBuffer.SelectionLength = oMatch.Length;
                    if (Highlight.FgColor != Color.Transparent & Highlight.FgColor != m_oEmptyColor)
                    {
                        m_oRichTextBuffer.SelectionColor = Highlight.FgColor;
                    }

                    if (Highlight.BgColor != Color.Transparent & Highlight.FgColor != m_oEmptyColor)
                    {
                        m_oRichTextBuffer.SelectionBackColor = Highlight.BgColor;
                    }
                }
                if (Conversions.ToBoolean(Highlight.SoundFile.Length > 0 && m_oParentForm.Globals.Config.bPlaySounds))
                    Sound.PlayWaveFile(Highlight.SoundFile);
            }
        }

        private Regex oClickRegex = new Regex("{([^{]*):([^{]*)}", MyRegexOptions.options);
        private List<Link> LinkList = new List<Link>();

        private class Link
        {
            public int Index;
            public int Length;
            public string Command;
        }

        private void ParseRegExpHighlight(HighlightRegExp.Highlight Highlight)
        {
            foreach (Match oMatch in Highlight.HighlightRegex.Matches(m_oRichTextBuffer.Text))
            {
                for (i=1; i < oMatch.Groups.Count; i++)
                {
                    m_oRichTextBuffer.SelectionStart = oMatch.Groups[i].Index;
                    m_oRichTextBuffer.SelectionLength = oMatch.Groups[i].Length;
                    if (Highlight.FgColor != Color.Transparent & Highlight.FgColor != m_oEmptyColor)
                    {
                        m_oRichTextBuffer.SelectionColor = Highlight.FgColor;
                    }
    
                    if (Highlight.BgColor != Color.Transparent & Highlight.FgColor != m_oEmptyColor)
                    {
                        m_oRichTextBuffer.SelectionBackColor = Highlight.BgColor;
                    }
                }
            }
            
        }

        private void ParseVolatileHighlights(List<VolatileHighlight> highlightList)
        {
            foreach (VolatileHighlight highlight in highlightList.ToArray())
            {
                int runningPosition = 0;
                int lineIndex = 0;
                foreach (string line in m_oRichTextBuffer.Text.Split('\n'))
                {
                    int timestampOffset = 0;
                    if (m_bTimeStamp)
                    {
                        timestampOffset += GetTimeString(line).Length;
                    }
                    if (m_oParentForm.Globals.PresetList[highlight.Preset].bHighlightLine && line.Contains(highlight.Text))
                    {
                        int indexOfHighlight = m_oRichTextBuffer.Text.IndexOf(highlight);
                        int lastNewLineIndex = m_oRichTextBuffer.Text.LastIndexOf("\n", indexOfHighlight);
                        int nextNewLineIndex = m_oRichTextBuffer.Text.IndexOf("\n", indexOfHighlight);
                        if (lastNewLineIndex == -1) lastNewLineIndex = 0;
                        if (nextNewLineIndex == -1) nextNewLineIndex = m_oRichTextBuffer.Text.Length;
                        m_oRichTextBuffer.SelectionStart = lastNewLineIndex >= 0 ? lastNewLineIndex : 0;
                        m_oRichTextBuffer.SelectionLength = nextNewLineIndex - lastNewLineIndex;
                    }
                    else if (line.Length >= highlight.EndIndex + timestampOffset
                        && line.Substring(highlight.StartIndex + timestampOffset, highlight.Length) == highlight)
                    {
                        m_oRichTextBuffer.SelectionStart = runningPosition + timestampOffset + highlight.StartIndex;
                        m_oRichTextBuffer.SelectionLength = highlight.Length;
                    }
                    else
                    {
                        m_oRichTextBuffer.SelectionLength = 0;
                    }

                    if (m_oParentForm.Globals.PresetList[highlight.Preset].FgColor != Color.Transparent)
                    {
                        m_oRichTextBuffer.SelectionColor = (Color)m_oParentForm.Globals.PresetList[highlight.Preset].FgColor;
                    }

                    if (m_oParentForm.Globals.PresetList[highlight.Preset].BgColor != Color.Transparent)
                    {
                        m_oRichTextBuffer.SelectionBackColor = (Color)m_oParentForm.Globals.PresetList[highlight.Preset].BgColor;
                    }

                    lineIndex += 1;
                    runningPosition += line.Length + 1; //add 1 to account for the \n characters removed by the split
                }

            }
        }
        private void ParseHighlights()
        {
            MatchCollection oMatchCollection;
            ParseLineHighlights(m_oRichTextBuffer.SelectionStart, m_oRichTextBuffer.Text);
            // Highlight String
            if (!Information.IsNothing(m_oParentForm.Globals.HighlightList.RegexString))
            {
                oMatchCollection = (MatchCollection)m_oParentForm.Globals.HighlightList.RegexString.Matches(m_oRichTextBuffer.Text);
                Highlights.Highlight oHighlightString;
                foreach (Match oMatch in oMatchCollection)
                {
                    if (Conversions.ToBoolean(m_oParentForm.Globals.HighlightList.Contains(oMatch.Value)))
                    {
                        oHighlightString = (Highlights.Highlight)m_oParentForm.Globals.HighlightList[oMatch.Value];
                        m_oRichTextBuffer.SelectionStart = oMatch.Index;
                        m_oRichTextBuffer.SelectionLength = oMatch.Length;
                        if (oHighlightString.FgColor != Color.Transparent & oHighlightString.FgColor != m_oEmptyColor)
                        {
                            m_oRichTextBuffer.SelectionColor = oHighlightString.FgColor;
                        }

                        if (oHighlightString.BgColor != Color.Transparent & oHighlightString.FgColor != m_oEmptyColor)
                        {
                            m_oRichTextBuffer.SelectionBackColor = oHighlightString.BgColor;
                        }

                        if (Conversions.ToBoolean(oHighlightString.SoundFile.Length > 0 && m_oParentForm.Globals.Config.bPlaySounds))
                            Sound.PlayWaveFile(oHighlightString.SoundFile);
                    }
                }
            }

            // Links
            oMatchCollection = oClickRegex.Matches(m_oRichTextBuffer.Text);
            int iOffset = 0;
            foreach (Match oMatch in oMatchCollection)
            {
                m_oRichTextBuffer.SelectionStart = oMatch.Index - iOffset;
                m_oRichTextBuffer.SelectionLength = oMatch.Length;
                string sOldText = m_oRichTextBuffer.SelectedText;
                string sNewText = oMatch.Groups[1].Value;
                string sCommand = oMatch.Groups[2].Value + "!#";
                int iDiff = sOldText.Length - sNewText.Length;
                var link = new Link();
                link.Index = m_oRichTextBuffer.SelectionStart;
                link.Length = sNewText.Length;
                link.Command = sCommand;
                LinkList.Add(link);
                m_oRichTextBuffer.SelectedText = sNewText;
                iOffset += iDiff;
            }

            // Name List
            if (!Information.IsNothing(m_oParentForm.Globals.NameList.RegexNames))
            {
                oMatchCollection = (MatchCollection)m_oParentForm.Globals.NameList.RegexNames.Matches(m_oRichTextBuffer.Text);
                Names.Name oName;
                foreach (Match oMatch in oMatchCollection)
                {
                    if (Conversions.ToBoolean(m_oParentForm.Globals.NameList.Contains(oMatch.Value)))
                    {
                        oName = (Names.Name)m_oParentForm.Globals.NameList[oMatch.Value];
                        m_oRichTextBuffer.SelectionStart = oMatch.Index;
                        m_oRichTextBuffer.SelectionLength = oMatch.Length;
                        if (oName.FgColor != Color.Transparent & oName.FgColor != m_oEmptyColor)
                        {
                            m_oRichTextBuffer.SelectionColor = oName.FgColor;
                        }

                        if (oName.BgColor != Color.Transparent & oName.FgColor != m_oEmptyColor)
                        {
                            m_oRichTextBuffer.SelectionBackColor = oName.BgColor;
                        }
                    }
                }
            }
            
        }

        public FormSkin FormParent
        {
            get
            {
                return m_oParentForm;
            }

            set
            {
                m_oParentForm = value;
            }
        }

        private void AddRTF(string rtf)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired == true)
            {
                var parameters = new[] { rtf };
                Invoke(new InvokeAddRTFDelegate(InvokeAddRTF), parameters);
            }
            else
            {
                InvokeAddRTF(rtf);
            }
        }

        public void EndTextUpdate()
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired == true)
            {
                Invoke(new InvokeEndUpdateDelegate(InvokeEndUpdate));
            }
            else
            {
                InvokeEndUpdate();
            }
        }

        public void ClearWindow()
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired == true)
            {
                Invoke(new InvokeClearWindowDelegate(InvokeClearWindow));
            }
            else
            {
                InvokeClearWindow();
            }
        }

        private bool m_bIsScrolling = false;

        public void BeginUpdate()
        {
            Win32Utility.BeginUpdate((IntPtr)Handle.ToInt32());
        }

        public void EndUpdate()
        {
            Win32Utility.EndUpdate((IntPtr)Handle.ToInt32());
        }

        public delegate void InvokeAddRTFDelegate(string text);

        private void InvokeAddRTF(string text)
        {
            int iSelectionStart = SelectionStart;
            int iSelectionLength = SelectionLength;
            int iFirstLineVisible = Win32Utility.GetFirstLineVisible((IntPtr)Handle.ToInt32());
            bool bIsFlushingBuffer = false;
            if (m_bIsScrolling == true)
            {
                BeginUpdate();
            }
            else if (TextLength > MaxBufferSize) // Flush buffer only when user isn't scrolling.
            {
                bIsFlushingBuffer = true;
                BeginUpdate();
                int iRemoveSize = (int)(TextLength / (double)3);
                SelectionStart = 0;
                SelectionLength = iRemoveSize;
                SelectedText = " ";
            }

            SelectionStart = int.MaxValue;
            SelectionLength = 0;

            if (text != "")
                SelectedRtf = text;

            bool bScroll = true;
            if (iFirstLineVisible + 2 >= m_iEndLine) // +2 extra lines
            {
                bScroll = false;
            }

            m_iEndLine = Win32Utility.GetFirstLineVisible((IntPtr)Handle.ToInt32());
            if (iSelectionLength > 0)
            {
                SelectionStart = iSelectionStart;
                SelectionLength = iSelectionLength;
            }
            else if (bScroll == true) // We are scrolling
            {
                int i = iFirstLineVisible - m_iEndLine;
                Win32Utility.LineScroll((IntPtr)Handle.ToInt32(), i);
            }

            if (m_bIsScrolling == true | bIsFlushingBuffer == true)
            {
                EndUpdate();
            }

            m_bIsScrolling = bScroll;
        }

        public delegate void InvokeEndUpdateDelegate();

        private void InvokeEndUpdate()
        {
            ParseHighlights();
            if (m_bMouseDown == false)
            {
                FlushBuffer();
            }
        }

        private void FlushBuffer()
        {
            m_oRichTextBuffer.SelectionStart = 0;
            m_oRichTextBuffer.SelectionLength = int.MaxValue;
            int start = TextLength;
            AddRTF(m_oRichTextBuffer.SelectedRtf);
            m_oRichTextBuffer.Clear();
            SetLinks(start);
        }

        private void SetLinks(int offset)
        {
            if (LinkList.Count > 0)
            {
                if (m_bIsScrolling == true)
                {
                    BeginUpdate();
                }

                int iFirstLineVisible = Win32Utility.GetFirstLineVisible((IntPtr)Handle.ToInt32());
                int startPosition = SelectionStart;
                int startLength = SelectionLength;
                foreach (Link link in LinkList)
                {
                    InsertLink(link.Command, offset + link.Index, link.Length);
                    offset += link.Command.Length + 1;
                }

                LinkList.Clear();
                bool bScroll = true;
                if (iFirstLineVisible + 2 >= m_iEndLine)	// +2 extra lines
                {
                    bScroll = false;
                }

                m_iEndLine = Win32Utility.GetFirstLineVisible((IntPtr)Handle.ToInt32());
                if (startLength > 0)
                {
                    SelectionStart = startPosition;
                    SelectionLength = startLength;
                }
                else if (bScroll == true) // We are scrolling
                {
                    int i = iFirstLineVisible - m_iEndLine;
                    Win32Utility.LineScroll((IntPtr)Handle.ToInt32(), i);
                }

                if (m_bIsScrolling == true)
                {
                    EndUpdate();
                }

                m_bIsScrolling = bScroll;
            }
        }

        public delegate void InvokeClearWindowDelegate();

        private void InvokeClearWindow()
        {
            Clear();
            m_oRichTextBuffer.Clear();
            m_bPendingNewLine = false;
        }

        public void ComponentRichTextBox_GotFocus(object sender, EventArgs e)
        {
            m_oParentForm.Focus();
        }

        public event EventKeyDownEventHandler EventKeyDown;

        public delegate void EventKeyDownEventHandler(KeyEventArgs e);

        public void ComponentRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyData == Keys.PageUp | e.KeyData == Keys.PageDown))
            {
                EventKeyDown?.Invoke(e);
                e.Handled = true;
            }
        }

        public event EventKeyPressEventHandler EventKeyPress;

        public delegate void EventKeyPressEventHandler(KeyPressEventArgs e);

        public void ComponentRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventKeyPress?.Invoke(e);
            e.Handled = true;
        }

        private bool m_bMouseDown = false;

        public void ComponentRichTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            m_bMouseDown = true;
        }

        public void ComponentRichTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (SelectionLength > 0)
                {
                    string sTemp = SelectedText.ToString();
                    sTemp = sTemp.Replace(Constants.vbLf, System.Environment.NewLine);
                    Clipboard.SetDataObject(sTemp, true);
                    SelectionLength = 0;
                }

                if (m_oRichTextBuffer.TextLength > 0)
                {
                    FlushBuffer();
                }
            }
#pragma warning disable CS0168
            catch (Exception ex)
#pragma warning restore CS0168
            {
            }
            // Ignore
            finally
            {
                m_bMouseDown = false;
            }
        }
        public void InsertLink(string text, string hyperlink)
        {
            text = text.Replace(@"\", @"\\");
            hyperlink = hyperlink.Replace(@"\", @"\\");
            SelectionStart = int.MaxValue;
            InsertLink(text, hyperlink, SelectionStart);
        }

        private void InsertLink(string text, string hyperlink, int position)
        {
            if (position < 0 || position > Text.Length)
            {
                throw new ArgumentOutOfRangeException("position");
            }
            
            SelectionStart = position;
            SelectedRtf = @"{\rtf1\ansi " + text + @"\v #" + hyperlink + @"!#\v0}";
            Select(position, text.Length + hyperlink.Length + 1);
            SetSelectionLink(Handle, true);
            Select(position + text.Length + hyperlink.Length + 1, 0);
            AppendText(System.Environment.NewLine);
        }

        private void InsertLink(string hyperlink, int position, int length)
        {
            if (position < 0 || position > Text.Length)
            {
                throw new ArgumentOutOfRangeException("position");
            }

            SelectionStart = position;
            SelectionLength = length;
            if (SelectionLength > 0)
            {
                SelectedRtf = @"{\rtf1\ansi " + SelectedText + @"\v #" + hyperlink + @"\v0}";
                Select(position, length + hyperlink.Length + 1);
                SetSelectionLink(Handle, true);
                Select(Text.Length, 0); 
            }
        }

        public void SetSelectionLink(IntPtr handle, bool link)
        {
            SetSelectionStyle(handle, CFM_LINK, Conversions.ToUInteger(Interaction.IIf(link, CFE_LINK, 0)));
        }

        private void SetSelectionStyle(IntPtr handle, uint mask, uint effect)
        {
            var cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = Convert.ToUInt32(Marshal.SizeOf(cf));
            cf.dwMask = mask;
            cf.dwEffects = effect;
            var wpar = new IntPtr(SCF_SELECTION);
            var lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);
            var res = SendMessage(handle, EM_SETCHARFORMAT, wpar, lpar);
            Marshal.FreeCoTaskMem(lpar);
        }

        public void SetScrollBars()
        {
            SizeF fontSize = TextRenderer.MeasureText("A", this.Font, this.Size, TextFormatFlags.WordBreak);
            float displayableLines = this.Height / fontSize.Height;

            ScrollBars = Lines.Length > displayableLines ? RichTextBoxScrollBars.Vertical : RichTextBoxScrollBars.None;
        }
    }
}
