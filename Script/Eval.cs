using System;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie.Script
{
    public class Eval
    {
        private const string SEPARATORS = "!=<>,&|";

        // LINUS: Hade nog gjort såhär (String funkar också)
        // Private aSeparators As Char() = {"!", "=", "<", ">", ",", "&", "|", " "}

        public enum ParseType
        {
            SeparatorType,
            NumberType,
            StringType,
            SectionStartType,
            SectionEndType,
            FunctionType,
            NegateType // NOT
        }

        private ArrayList oSections = new ArrayList();

        private class Sections
        {
            public string sBlock = string.Empty;
            public ParseType BlockType;
            public bool bParsed = false;

            public Sections(string block, ParseType type)
            {
                sBlock = block;
                BlockType = type;
            }
        }

        private Globals m_oGlobals = null;

        public string EvalString(string sText, Globals oGlobals)
        {
            m_oGlobals = oGlobals;
            m_RegExpResultList.Clear();
            string argsText = ReplaceKeyWords(sText);
            Parse(argsText);
            return GetStringResult();
        }

        private string ReplaceKeyWords(string sText)
        {
            string sResult = string.Empty;
            bool bInsideString = false;
            string sTemp = string.Empty;
            foreach (char ch in sText.ToCharArray())
            {
                sTemp += Conversions.ToString(ch);
                if (bInsideString == true)
                {
                    if (ch == '"')
                    {
                        bInsideString = false;
                        sResult += sTemp;
                        sTemp = string.Empty;
                    }
                }
                else if (ch == '"')
                {
                    bInsideString = true;
                    sResult += ReplaceKeyWordsSection(sTemp);
                    sTemp = string.Empty;
                }
            }

            sResult += ReplaceKeyWordsSection(sTemp);
            return sResult;
        }

        private Regex m_KeyRegex = new Regex(@"\b(eq|and|or|not|true|false)\b", RegexOptions.IgnoreCase & MyRegexOptions.options);

        private string ReplaceKeyWordsSection(string sText)
        {
            var m = m_KeyRegex.Match(sText);
            while (m.Success)
            {
                string sMatch = string.Empty;
                string sTemp = string.Empty;
                int iLastPos = 0;
                var switchExpr = m.Groups[1].Value.ToLower();
                switch (switchExpr)
                {
                    case "eq":
                        {
                            sMatch = "=";
                            break;
                        }

                    case "and":
                        {
                            sMatch = "&&";
                            break;
                        }

                    case "or":
                        {
                            sMatch = "||";
                            break;
                        }

                    case "not":
                        {
                            sMatch = "!";
                            break;
                        }

                    case "true":
                        {
                            sMatch = "1";
                            break;
                        }

                    case "false":
                        {
                            sMatch = "0";
                            break;
                        }
                }

                sTemp += sText.Substring(iLastPos, m.Index) + sMatch;
                iLastPos += m.Index + m.Length;
                sTemp += sText.Substring(iLastPos);
                sText = sTemp;
                m = m_KeyRegex.Match(sText);
            }

            return sText;
        }

        // Parse and put each section into oSections array
        private void Parse(string sText)
        {
            oSections.Clear();
            bool bInsideString = false;
            bool bIgnoreNumber = false;
            var cInsideStringChar = default(char);
            var CurrentType = ParseType.SeparatorType;
            char ch;
            int l = 0;
            int sp = 0;
            for (int cp = 0, loopTo = sText.Length - 1; cp <= loopTo; cp++)
            {
                ch = sText[cp];
                if (bInsideString == true)
                {
                    if (ch == cInsideStringChar)
                    {
                        bInsideString = false;
                    }
                }
                else if (ch == '"') // Or ch = "'"c
                {
                    l = cp - sp;
                    if (l > 0)
                    {
                        SectionEnqueue(sText.Substring(sp, l), CurrentType);
                        bIgnoreNumber = false;
                        sp = cp;
                    }

                    CurrentType = ParseType.StringType;
                    bInsideString = true;
                    cInsideStringChar = ch;
                }
                else if (SEPARATORS.IndexOf(ch) > -1)
                {
                    if (CurrentType != ParseType.SeparatorType)
                    {
                        l = cp - sp;
                        if (l > 0)
                        {
                            SectionEnqueue(sText.Substring(sp, l), CurrentType);
                            bIgnoreNumber = false;
                            sp = cp;
                        }

                        CurrentType = ParseType.SeparatorType;
                    }
                }
                else if (bIgnoreNumber == false && Information.IsNumeric(ch) | ch == '.' | ch == '-') // Number
                {
                    if (CurrentType != ParseType.NumberType)
                    {
                        l = cp - sp;
                        if (l > 0)
                        {
                            SectionEnqueue(sText.Substring(sp, l), CurrentType);
                            sp = cp;
                        }

                        CurrentType = ParseType.NumberType;
                    }
                }
                else if (ch == '(')
                {
                    l = cp - sp;
                    if (l > 0)
                    {
                        SectionEnqueue(sText.Substring(sp, l), CurrentType);
                        bIgnoreNumber = false;
                        sp = cp;
                    }

                    CurrentType = ParseType.SectionStartType;
                }
                else if (ch == ')')
                {
                    l = cp - sp;
                    if (l > 0)
                    {
                        SectionEnqueue(sText.Substring(sp, l), CurrentType);
                        bIgnoreNumber = false;
                        sp = cp;
                    }

                    CurrentType = ParseType.SectionEndType;
                }
                else if (ch == ' ' | Conversions.ToString(ch) == Constants.vbTab)
                {
                    if (CurrentType != ParseType.FunctionType)
                    {
                        l = cp - sp;
                        if (l > 0)
                        {
                            SectionEnqueue(sText.Substring(sp, l), CurrentType);
                            sp = cp;
                        }

                        CurrentType = ParseType.SeparatorType;
                    }
                    else
                    {
                        bIgnoreNumber = true;
                    } // For strings without "" that contains numbers
                }
                else if (CurrentType != ParseType.FunctionType) // Function
                {
                    l = cp - sp;
                    if (l > 0)
                    {
                        SectionEnqueue(sText.Substring(sp, l), CurrentType);
                        sp = cp;
                    }

                    CurrentType = ParseType.FunctionType;
                    bIgnoreNumber = true;
                }
            }

            l = sText.Length - sp;
            if (l > 0)
            {
                SectionEnqueue(sText.Substring(sp, l), CurrentType);
            }

            // Parse the oSections object
            ShowQueue();
            ParseQueue();

            // ShowQueue()
        }

        private const string Functions = "|instr|instring|contains|indexof|lastindexof|match|startswith|endswith|replace|tolower|toupper|trim|len|length|substr|substring|matchre|replacere|count|element|def|defined";

        // LINUS: Hade nog gjort såhär
        // Private aFunctions As String() = {"instr", "instring", "contains", "indexof", "lastindexof", "match", "startswith", "endswith", "replace", "tolower", "toupper", "trim", "len", "length", "substr", "substring", "matchre", "replacere", "count", ""}

        // Add section to oSections array
        private void SectionEnqueue(string text, ParseType type)
        {
            text = text.Trim(' ', Conversions.ToChar(Constants.vbTab));
            if (text.Length > 0)
            {
                if (type == ParseType.FunctionType)
                {
                    var switchExpr = text.ToLower();
                    switch (switchExpr)
                    {
                        case "eq":
                            {
                                text = "=";
                                type = ParseType.SeparatorType;
                                break;
                            }

                        case "and":
                            {
                                text = "&&";
                                type = ParseType.SeparatorType;
                                break;
                            }

                        case "or":
                            {
                                text = "||";
                                type = ParseType.SeparatorType;
                                break;
                            }

                        case "not":
                            {
                                text = "!";
                                type = ParseType.NegateType;
                                break;
                            }

                        case "true":
                            {
                                text = "1";
                                type = ParseType.NumberType;
                                break;
                            }

                        case "false":
                            {
                                text = "0";
                                type = ParseType.NumberType;
                                break;
                            }

                        default:
                            {
                                if (Functions.IndexOf("|" + text + "|") == -1) // Assume string
                                {
                                    type = ParseType.StringType;
                                }

                                break;
                            }
                    }
                }
                else if (type == ParseType.SeparatorType)
                {
                    if ((text ?? "") == "!")
                    {
                        type = ParseType.NegateType;
                    }
                }
                else if (type == ParseType.StringType)
                {
                    if (text.Length > 1 & text.StartsWith("\"") & text.EndsWith("\""))
                    {
                        text = text.Substring(1, text.Length - 2); // Remove ""
                    }
                }

                oSections.Add(new Sections(text, type));
            }
        }

        // Parse the Queue after it's been added to array
        private int ParseQueue(int start = 0)
        {
            for (int j = start, loopTo = oSections.Count - 1; j <= loopTo; j++)
            {
                var switchExpr = ((Sections)oSections[j]).BlockType;
                switch (switchExpr)
                {
                    case ParseType.SectionStartType:
                        {
                            j = ParseQueue(j + 1);
                            break;
                        }

                    case ParseType.SectionEndType:
                        {
                            ParseSection(start, j - 1);
                            return j;
                        }
                }
            }

            ParseSection(start, oSections.Count - 1);
            return oSections.Count - 1;
        }

        // Result
        private string GetStringResult()
        {
            string sResult = string.Empty;
            for (int j = 0, loopTo = oSections.Count - 1; j <= loopTo; j++)
            {
                if (((Sections)oSections[j]).bParsed == false)
                {
                    if (((Sections)oSections[j]).BlockType == ParseType.NumberType | ((Sections)oSections[j]).BlockType == ParseType.StringType)
                    {
                        if (sResult.Length > 0)
                        {
                        }
                        // Error in eval
                        else
                        {
                            sResult = ((Sections)oSections[j]).sBlock;
                        }
                    }
                }
            }

            return sResult;
        }

        // Result
        private bool GetBooleanResult()
        {
            bool bResult = false;
            for (int j = 0, loopTo = oSections.Count - 1; j <= loopTo; j++)
            {
                if (((Sections)oSections[j]).bParsed == false)
                {
                    if (((Sections)oSections[j]).BlockType == ParseType.NumberType)
                    {
                        Sections argoSection = (Sections)oSections[j];
                        if (IsSectionTrue(argoSection) == true)
                        {
                            if (bResult == true)
                            {
                            }
                            // Error in eval
                            else
                            {
                                bResult = true;
                            }
                        }
                    }
                    else
                    {
                        // Error in statement
                    }
                }
            }

            return bResult;
        }

        private void ShowQueue()
        {
            foreach (Sections o in oSections)
                Debug.Print("-" + o.bParsed + " " + o.BlockType.ToString() + " " + o.sBlock);
        }

        // Parse Subsection. Typically () pairs
        private void ParseSection(int iStart, int iEnd)
        {
            if (iEnd >= oSections.Count | iStart < 0)
            {
                throw new Exception("Invalid argument to ParseSection()");
            }

            if (iStart >= 2 && ((Sections)oSections[iStart - 2]).BlockType == ParseType.FunctionType)
            {
                ParseFunction(iStart - 2, iEnd);
            }

            int iArgLeft = -1;
            int iArgRight = -1;
            int iComparer = -1;
            bool bNegate = false;

            // Do all = > < etc.
            for (int j = iStart, loopTo = iEnd; j <= loopTo; j++)
            {
                if (((Sections)oSections[j]).bParsed == false)
                {
                    var switchExpr = ((Sections)oSections[j]).BlockType;
                    switch (switchExpr)
                    {
                        case ParseType.NumberType:
                        case ParseType.StringType:
                            {
                                if (iArgLeft > -1 & iComparer > -1)
                                {
                                    iArgRight = j;
                                    if (ParseCompare(iArgLeft, iArgRight, iComparer, true) == true)
                                    {
                                        ((Sections)oSections[iArgRight]).bParsed = true; // Parsed
                                        ((Sections)oSections[iComparer]).bParsed = true; // Parsed
                                        iArgLeft = -1;
                                    }

                                    iComparer = -1;
                                }
                                else
                                {
                                    iArgLeft = j;
                                }

                                break;
                            }

                        case ParseType.SeparatorType:
                            {
                                iComparer = j;
                                break;
                            }
                    }
                }
            }

            // Do "not"
            for (int j = iStart, loopTo1 = iEnd; j <= loopTo1; j++)
            {
                if (((Sections)oSections[j]).bParsed == false)
                {
                    var switchExpr1 = ((Sections)oSections[j]).BlockType;
                    switch (switchExpr1)
                    {
                        case ParseType.NegateType:
                            {
                                ((Sections)oSections[j]).bParsed = true; // Parsed
                                bNegate = true;
                                break;
                            }

                        case ParseType.NumberType:
                        case ParseType.StringType:
                            {
                                if (bNegate == true)
                                {
                                    Sections argoSection = (Sections)oSections[j];
                                    if (IsSectionTrue(argoSection) == true)
                                    {
                                        ((Sections)oSections[j]).sBlock = "0";
                                    }
                                    else
                                    {
                                        ((Sections)oSections[j]).sBlock = "1";
                                    }

                                    bNegate = false;
                                }

                                break;
                            }
                    }
                }
            }

            // Do "and" and "or"
            iArgLeft = -1;
            iArgRight = -1;
            iComparer = -1;
            for (int j = iStart, loopTo2 = iEnd; j <= loopTo2; j++)
            {
                if (((Sections)oSections[j]).bParsed == false)
                {
                    var switchExpr2 = ((Sections)oSections[j]).BlockType;
                    switch (switchExpr2)
                    {
                        case ParseType.NumberType:
                        case ParseType.StringType:
                            {
                                if (iArgLeft > -1 & iComparer > -1)
                                {
                                    iArgRight = j;
                                    if (ParseCompare(iArgLeft, iArgRight, iComparer, false) == true)
                                    {
                                        ((Sections)oSections[iArgRight]).bParsed = true; // Parsed
                                        ((Sections)oSections[iComparer]).bParsed = true; // Parsed
                                                                                         // iArgLeft = -1
                                    }

                                    iComparer = -1;
                                }
                                else
                                {
                                    iArgLeft = j;
                                }

                                break;
                            }

                        case ParseType.SeparatorType:
                            {
                                iComparer = j;
                                break;
                            }
                    }
                }
            }


            // Single object - Return it
            if (iArgRight == -1 & iArgLeft > -1)
            {
                ((Sections)oSections[iArgLeft]).bParsed = false;
            }
        }

        // Compare two sections using comparer
        private bool ParseCompare(int iArgLeft, int iArgRight, int iComparer, bool bSkipAndOr)
        {
            double dLeftValue = -1;
            double dRightValue = -1;
            string sLeftValue = string.Empty;
            string sRightValue = string.Empty;
            bool bNumberCompare = false;
            if (((Sections)oSections[iArgLeft]).BlockType == ParseType.NumberType & ((Sections)oSections[iArgRight]).BlockType == ParseType.NumberType)
            {
                bNumberCompare = true;
                dLeftValue = Utility.StringToDouble(((Sections)oSections[iArgLeft]).sBlock);
                dRightValue = Utility.StringToDouble(((Sections)oSections[iArgRight]).sBlock);
            }
            else
            {
                sLeftValue = ((Sections)oSections[iArgLeft]).sBlock;
                sRightValue = ((Sections)oSections[iArgRight]).sBlock;
                Debug.Print("Compare Left: " + sLeftValue + ", Compare Right: " + sRightValue);
            }

            if (bSkipAndOr == true)
            {
                var switchExpr = ((Sections)oSections[iComparer]).sBlock;
                switch (switchExpr)
                {
                    case "=":
                    case "==":
                        {
                            // ' LINUS: Använd WITH och IIF!!
                            // ' Koden nedan är samma som koden under, bara förenklad
                            // With CType(oSections.Item(iArgLeft), Sections)
                            // .sBlock = IIf(bNumberCompare, IIf(dLeftValue = dRightValue, "1", "0"), IIf(String.Equals(sLeftValue, sRightValue), "1", "0"))
                            // .BlockType = ParseType.NumberType
                            // .bParsed = False ' Unparse
                            // End With

                            if (bNumberCompare == true)
                            {
                                if (dLeftValue == dRightValue)
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "1";
                                }
                                else
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "0";
                                }
                            }
                            else if (string.Equals(sLeftValue, sRightValue) == true)
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "1";
                            }
                            else
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "0";
                            } ((Sections)oSections[iArgLeft]).BlockType = ParseType.NumberType;
                            ((Sections)oSections[iArgLeft]).bParsed = false; // Unparse
                            return true;
                        }

                    case "!=":
                    case "<>":
                        {
                            if (bNumberCompare == true)
                            {
                                if (dLeftValue != dRightValue)
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "1";
                                }
                                else
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "0";
                                }
                            }
                            else if (string.Equals(sLeftValue, sRightValue) == true)
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "0";
                            }
                            else
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "1";
                            } ((Sections)oSections[iArgLeft]).BlockType = ParseType.NumberType;
                            ((Sections)oSections[iArgLeft]).bParsed = false; // Unparse
                            return true;
                        }

                    case ">":
                        {
                            if (bNumberCompare == true)
                            {
                                if (dLeftValue > dRightValue)
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "1";
                                }
                                else
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "0";
                                }
                            }
                            else
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "0";
                            } ((Sections)oSections[iArgLeft]).BlockType = ParseType.NumberType;
                            ((Sections)oSections[iArgLeft]).bParsed = false; // Unparse
                            return true;
                        }

                    case ">=":
                        {
                            if (bNumberCompare == true)
                            {
                                if (dLeftValue >= dRightValue)
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "1";
                                }
                                else
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "0";
                                }
                            }
                            else
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "0";
                            } ((Sections)oSections[iArgLeft]).BlockType = ParseType.NumberType;
                            ((Sections)oSections[iArgLeft]).bParsed = false; // Unparse
                            return true;
                        }

                    case "<":
                        {
                            if (bNumberCompare == true)
                            {
                                if (dLeftValue < dRightValue)
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "1";
                                }
                                else
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "0";
                                }
                            }
                            else
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "0";
                            } ((Sections)oSections[iArgLeft]).BlockType = ParseType.NumberType;
                            ((Sections)oSections[iArgLeft]).bParsed = false; // Unparse
                            return true;
                        }

                    case "<=":
                        {
                            if (bNumberCompare == true)
                            {
                                if (dLeftValue <= dRightValue)
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "1";
                                }
                                else
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "0";
                                }
                            }
                            else
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "0";
                            } ((Sections)oSections[iArgLeft]).BlockType = ParseType.NumberType;
                            ((Sections)oSections[iArgLeft]).bParsed = false; // Unparse
                            return true;
                        }
                }
            }
            else
            {
                var switchExpr1 = ((Sections)oSections[iComparer]).sBlock;
                switch (switchExpr1)
                {
                    case "||":
                        {
                            if (bNumberCompare == true)
                            {
                                if (dLeftValue > 0 | dRightValue > 0)
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "1";
                                }
                                else
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "0";
                                }
                            }
                            else
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "0";
                            } ((Sections)oSections[iArgLeft]).BlockType = ParseType.NumberType;
                            ((Sections)oSections[iArgLeft]).bParsed = false; // Unparse
                            return true;
                        }

                    case "&&":
                        {
                            if (bNumberCompare == true)
                            {
                                if (dLeftValue > 0 & dRightValue > 0)
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "1";
                                }
                                else
                                {
                                    ((Sections)oSections[iArgLeft]).sBlock = "0";
                                }
                            }
                            else
                            {
                                ((Sections)oSections[iArgLeft]).sBlock = "0";
                            } ((Sections)oSections[iArgLeft]).BlockType = ParseType.NumberType;
                            ((Sections)oSections[iArgLeft]).bParsed = false; // Unparse
                            return true;
                        }
                }
            }

            return false;
        }

        private ArrayList m_RegExpResultList = new ArrayList();

        public bool DoEval(string sText, Globals oGlobals)
        {
            m_oGlobals = oGlobals;
            m_RegExpResultList.Clear();
            string argsText = ReplaceKeyWords(sText);
            Parse(argsText);
            return GetBooleanResult();
        }

        public ArrayList ResultList
        {
            get
            {
                return m_RegExpResultList;
            }
        }

        // Parse a function
        private void ParseFunction(int iStart, int iEnd)
        {
            if (iEnd >= oSections.Count | iStart < 0)
            {
                throw new Exception("Invalid argument to ParseFunction()");
            }

            ArrayList args;
            args = BuildArgs(iStart, iEnd);
            var switchExpr = ((Sections)oSections[iStart]).sBlock.ToLower();
            switch (switchExpr)
            {
                case "instr":
                case "instring":
                case "contains":
                    {
                        if (args.Count == 2)
                        {
                            if (((Sections)args[0]).sBlock.Contains(((Sections)args[1]).sBlock) == true)
                            {
                                ((Sections)oSections[iStart]).sBlock = "1";
                            }
                            else
                            {
                                ((Sections)oSections[iStart]).sBlock = "0";
                            } ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "indexof":
                    {
                        if (args.Count == 2)
                        {
                            ((Sections)oSections[iStart]).sBlock = (((Sections)args[0]).sBlock.IndexOf(((Sections)args[1]).sBlock) + 1).ToString();
                            ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "lastindexof":
                    {
                        if (args.Count == 2)
                        {
                            ((Sections)oSections[iStart]).sBlock = (((Sections)args[0]).sBlock.LastIndexOf(((Sections)args[1]).sBlock) + 1).ToString();
                            ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "match":
                    {
                        if (args.Count == 2)
                        {
                            if (string.Equals(((Sections)args[0]).sBlock, ((Sections)args[1]).sBlock) == true)
                            {
                                ((Sections)oSections[iStart]).sBlock = "1";
                            }
                            else
                            {
                                ((Sections)oSections[iStart]).sBlock = "0";
                            } ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "startswith":
                    {
                        if (args.Count == 2)
                        {
                            if (((Sections)args[0]).sBlock.StartsWith(((Sections)args[1]).sBlock) == true)
                            {
                                ((Sections)oSections[iStart]).sBlock = "1";
                            }
                            else
                            {
                                ((Sections)oSections[iStart]).sBlock = "0";
                            } ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "endswith":
                    {
                        if (args.Count == 2)
                        {
                            if (((Sections)args[0]).sBlock.EndsWith(((Sections)args[1]).sBlock) == true)
                            {
                                ((Sections)oSections[iStart]).sBlock = "1";
                            }
                            else
                            {
                                ((Sections)oSections[iStart]).sBlock = "0";
                            } ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "replace":
                    {
                        if (args.Count == 3)
                        {
                            ((Sections)oSections[iStart]).sBlock = ((Sections)args[0]).sBlock.Replace(((Sections)args[1]).sBlock, ((Sections)args[2]).sBlock).ToString();
                            ((Sections)oSections[iStart]).BlockType = ParseType.StringType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "tolower":
                    {
                        if (args.Count == 1)
                        {
                            ((Sections)oSections[iStart]).sBlock = ((Sections)args[0]).sBlock.ToLower();
                            ((Sections)oSections[iStart]).BlockType = ParseType.StringType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "toupper":
                    {
                        if (args.Count == 1)
                        {
                            ((Sections)oSections[iStart]).sBlock = ((Sections)args[0]).sBlock.ToUpper();
                            ((Sections)oSections[iStart]).BlockType = ParseType.StringType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "trim":
                    {
                        if (args.Count == 1)
                        {
                            ((Sections)oSections[iStart]).sBlock = ((Sections)args[0]).sBlock.Trim();
                            ((Sections)oSections[iStart]).BlockType = ParseType.StringType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "len":
                case "length":
                    {
                        if (args.Count == 1)
                        {
                            ((Sections)oSections[iStart]).sBlock = ((Sections)args[0]).sBlock.Length.ToString();
                            ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "substr":
                case "substring":
                    {
                        if (args.Count == 3)
                        {
                            ((Sections)oSections[iStart]).sBlock = ((Sections)args[0]).sBlock.Substring(Conversions.ToInteger(((Sections)args[1]).sBlock), Conversions.ToInteger(((Sections)args[2]).sBlock)).ToString();
                            ((Sections)oSections[iStart]).BlockType = ParseType.StringType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else if (args.Count == 2)
                        {
                            ((Sections)oSections[iStart]).sBlock = ((Sections)args[0]).sBlock.Substring(Conversions.ToInteger(((Sections)args[1]).sBlock)).ToString();
                            ((Sections)oSections[iStart]).BlockType = ParseType.StringType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }

                        break;
                    }

                case "matchre":
                    {
                        if (args.Count == 2)
                        {
                            Match oMatch;
                            oMatch = Regex.Match(((Sections)args[0]).sBlock, ((Sections)args[1]).sBlock);
                            if (oMatch.Success == true)
                            {
                                ((Sections)oSections[iStart]).sBlock = "1";
                                ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                                m_RegExpResultList.Clear();
                                foreach (Group m in oMatch.Groups)
                                    m_RegExpResultList.Add(m.Value);
                            }
                            else
                            {
                                ((Sections)oSections[iStart]).sBlock = "0";
                                ((Sections)oSections[iStart]).BlockType = ParseType.NumberType;
                            } ((Sections)oSections[iStart]).bParsed = false; // Result
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "replacere":
                    {
                        if (args.Count == 3)
                        {
                            ((Sections)oSections[iStart]).sBlock = Regex.Replace(((Sections)args[0]).sBlock, ((Sections)args[1]).sBlock, ((Sections)args[2]).sBlock);
                            ((Sections)oSections[iStart]).BlockType = ParseType.StringType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "count":
                    {
                        if (args.Count == 2)
                        {
                            ((Sections)oSections[iStart]).sBlock = Count(((Sections)args[0]).sBlock, ((Sections)args[1]).sBlock).ToString();
                            ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "element":
                    {
                        if (args.Count == 2)
                        {
                            var oArray = ((Sections)args[0]).sBlock.Replace("(", "").Replace(")", "").Split('|');
                            int iIndex = int.Parse(((Sections)args[1]).sBlock);
                            if (iIndex >= oArray.GetLength(0))
                            {
                                iIndex = oArray.GetLength(0) - 1;
                            }

                            if (iIndex < 0)
                            {
                                iIndex = oArray.GetLength(0) + iIndex;
                            }

                            if (iIndex < 0)
                            {
                                iIndex = 0;
                            } ((Sections)oSections[iStart]).sBlock = oArray[iIndex];
                            ((Sections)oSections[iStart]).BlockType = ParseType.StringType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }
                        else
                        {
                            // Error
                        }

                        break;
                    }

                case "def":
                case "defined":
                    {
                        if (args.Count == 1)
                        {
                            string MyArg = ((Sections)args[0]).sBlock;
                            ((Sections)oSections[iStart]).sBlock = Conversions.ToString(Interaction.IIf(m_oGlobals.VariableList.ContainsKey(MyArg), "1", "0"));
                            ((Sections)oSections[iStart]).BlockType = ParseType.NumberType; // Result
                            ((Sections)oSections[iStart]).bParsed = false;
                        }

                        break;
                    }

                default:
                    {
                        throw new Exception("Invalid function name.");
                    }
            }
        }

        private bool IsSectionTrue(Sections oSection)
        {
            try
            {
                if ((oSection.sBlock ?? "") == "0")
                {
                    return false;
                }
                else if ((oSection.sBlock ?? "") == "1")
                {
                    return true;
                }
                else if (oSection.BlockType == ParseType.NumberType)
                {
                    if (int.Parse(oSection.sBlock) > 0)
                    {
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
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                return false;
            }
        }

        private int Count(string text, string match)
        {
            int c = 0;
            int i;
            i = text.IndexOf(match);
            while (i > -1)
            {
                if (i > -1)
                {
                    i = text.IndexOf(match, i + match.Length);
                    c += 1;
                }
            }

            return c;
        }

        // Builds the argument arraylist for ParseFunction()
        private ArrayList BuildArgs(int iStart, int iEnd)
        {
            var ar = new ArrayList();
            for (int j = iStart, loopTo = iEnd; j <= loopTo; j++)
            {
                if (((Sections)oSections[j]).bParsed == false)
                {
                    if (((Sections)oSections[j]).BlockType == ParseType.StringType | ((Sections)oSections[j]).BlockType == ParseType.NumberType)
                    {
                        ar.Add((Sections)oSections[j]);
                        ((Sections)oSections[j]).bParsed = true; // Block has been parsed
                    }
                }
            }

            return ar;
        }
    }
}