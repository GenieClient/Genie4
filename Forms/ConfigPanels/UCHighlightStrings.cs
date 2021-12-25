using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCHighlightStrings
    {
        public UCHighlightStrings()
        {
            InitializeComponent();
        }

        private Genie.Highlights m_HighlightList;
        private Genie.Globals.HighlightLineBeginsWith m_HighlightLineBeginsWith;
        private Genie.Globals.HighlightRegExp m_HighlightRegExp;
        private Genie.Globals m_Globals;
        private bool m_ItemChanged = false;

        public Genie.Globals Globals
        {
            get
            {
                return m_Globals;
            }

            set
            {
                m_Globals = value;
            }
        }

        public Genie.Highlights HighlightList
        {
            get
            {
                return m_HighlightList;
            }

            set
            {
                m_HighlightList = value;
            }
        }

        public Genie.Globals.HighlightLineBeginsWith HighlightLineBeginsWith
        {
            get
            {
                return m_HighlightLineBeginsWith;
            }

            set
            {
                m_HighlightLineBeginsWith = value;
            }
        }

        public Genie.Globals.HighlightRegExp HighlightRegExp
        {
            get
            {
                return m_HighlightRegExp;
            }

            set
            {
                m_HighlightRegExp = value;
            }
        }

        private void ButtonColorFg_Click(object sender, EventArgs e)
        {
            ColorDialogPicker.Color = LabelExampleColor.ForeColor;
            if (ColorDialogPicker.ShowDialog(this) == DialogResult.OK)
            {
                LabelExampleColor.ForeColor = ColorDialogPicker.Color;
                if (LabelExampleColor.BackColor != Color.Black)
                {
                    TextBoxColor.Text = Genie.ColorCode.ColorToString(LabelExampleColor.ForeColor) + ", " + Genie.ColorCode.ColorToString(LabelExampleColor.BackColor);
                }
                else
                {
                    TextBoxColor.Text = Genie.ColorCode.ColorToString(LabelExampleColor.ForeColor);
                }
            }
        }

        private void ButtonColorBg_Click(object sender, EventArgs e)
        {
            ColorDialogPicker.Color = LabelExampleColor.BackColor;
            if (ColorDialogPicker.ShowDialog(this) == DialogResult.OK)
            {
                LabelExampleColor.BackColor = ColorDialogPicker.Color;
                TextBoxColor.Text = Genie.ColorCode.ColorToString(LabelExampleColor.ForeColor) + ", " + Genie.ColorCode.ColorToString(LabelExampleColor.BackColor);
            }
            else
            {
                LabelExampleColor.BackColor = Color.Black;
                TextBoxColor.Text = Genie.ColorCode.ColorToString(LabelExampleColor.ForeColor);
            }
        }

        private void TextBoxColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTextBoxColor();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (!Information.IsNothing(TextBoxColor.Tag))
                {
                    TextBoxColor.Text = Conversions.ToString(TextBoxColor.Tag);
                    UpdateTextBoxColor();
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void UpdateTextBoxColor()
        {
            if (TextBoxColor.Text.Trim().Length > 0)
            {
                if (TextBoxColor.Text.Contains(",") == true && TextBoxColor.Text.EndsWith(",") == false)
                {
                    string sColor = TextBoxColor.Text.Substring(0, TextBoxColor.Text.IndexOf(",")).Trim();
                    string sBgColor = TextBoxColor.Text.Substring(TextBoxColor.Text.IndexOf(",") + 1).Trim();
                    LabelExampleColor.ForeColor = Genie.ColorCode.StringToColor(sColor);
                    LabelExampleColor.BackColor = Genie.ColorCode.StringToColor(sBgColor);
                    string sText = Genie.ColorCode.ColorToString(LabelExampleColor.ForeColor) + ", " + Genie.ColorCode.ColorToString(LabelExampleColor.BackColor);
                    if (sText.Contains("ControlText"))
                    {
                        sText = "";
                    }

                    TextBoxColor.Text = sText;
                }
                else
                {
                    LabelExampleColor.ForeColor = Genie.ColorCode.StringToColor(TextBoxColor.Text);
                    LabelExampleColor.BackColor = Color.Black;
                    string sText = Genie.ColorCode.ColorToString(LabelExampleColor.ForeColor);
                    if (sText.Contains("ControlText"))
                    {
                        sText = "";
                    }

                    TextBoxColor.Text = sText;
                }

                if (TextBoxColor.Text.Trim().Length > 0)
                {
                    TextBoxColor.Tag = TextBoxColor.Text; // Save it
                }

                TextBoxColor.SelectionStart = int.MaxValue;
            }
        }

        public bool ItemChanged
        {
            get
            {
                return m_ItemChanged;
            }

            set
            {
                m_ItemChanged = value;
            }
        }

        private void UCWindows_Load(object sender, EventArgs e)
        {
            PopulateList();
            m_ItemChanged = false;
        }

        private void PopulateList()
        {
            ResetList();
            if (!Information.IsNothing(m_HighlightList))
            {
                foreach (DictionaryEntry de in m_HighlightList)
                {
                    var li = ListViewBase.Items.Add(de.Key.ToString());
                    li.Tag = de.Key.ToString();
                    Genie.Highlights.Highlight oHighlight = (Genie.Highlights.Highlight)de.Value;
                    if (oHighlight.HighlightWholeRow == true)
                    {
                        li.SubItems.Add("Line");
                    }
                    else
                    {
                        li.SubItems.Add("String");
                    }

                    li.SubItems.Add(oHighlight.ColorName);
                    li.SubItems.Add(oHighlight.CaseSensitive.ToString()); // Case Sensitive
                    li.ForeColor = oHighlight.FgColor;
                    if (oHighlight.BgColor != Color.Transparent)
                    {
                        li.BackColor = oHighlight.BgColor;
                    }

                    li.SubItems.Add(oHighlight.SoundFile);
                    li.SubItems.Add(oHighlight.ClassName);
                }
            }

            if (!Information.IsNothing(m_HighlightLineBeginsWith))
            {
                foreach (DictionaryEntry de in m_HighlightLineBeginsWith)
                {
                    var li = ListViewBase.Items.Add(de.Key.ToString());
                    li.Tag = de.Key.ToString();
                    Genie.Globals.HighlightLineBeginsWith.Highlight oHighlight = (Genie.Globals.HighlightLineBeginsWith.Highlight)de.Value;
                    li.SubItems.Add("BeginsWith");
                    li.SubItems.Add(oHighlight.ColorName);
                    li.SubItems.Add(oHighlight.CaseSensitive.ToString());
                    li.ForeColor = oHighlight.FgColor;
                    if (oHighlight.BgColor != Color.Transparent)
                    {
                        li.BackColor = oHighlight.BgColor;
                    }

                    li.SubItems.Add(oHighlight.SoundFile);
                    li.SubItems.Add(oHighlight.ClassName);
                }
            }

            if (!Information.IsNothing(m_HighlightRegExp))
            {
                foreach (DictionaryEntry de in m_HighlightRegExp)
                {
                    var li = ListViewBase.Items.Add(de.Key.ToString());
                    li.Tag = de.Key.ToString();
                    Genie.Globals.HighlightRegExp.Highlight oHighlight = (Genie.Globals.HighlightRegExp.Highlight)de.Value;
                    li.SubItems.Add("RegExp");
                    li.SubItems.Add(oHighlight.ColorName);
                    li.SubItems.Add(oHighlight.CaseSensitive.ToString());
                    li.ForeColor = oHighlight.FgColor;
                    if (oHighlight.BgColor != Color.Transparent)
                    {
                        li.BackColor = oHighlight.BgColor;
                    }

                    li.SubItems.Add(oHighlight.SoundFile);
                    li.SubItems.Add(oHighlight.ClassName);
                }
            }

            PopulateClasses();
        }

        private void PopulateClasses()
        {
            ComboBoxClass.Items.Clear();
            ComboBoxClass.Items.Add("(default)");
            foreach (DictionaryEntry de in m_HighlightList)
                AddClass(((Genie.Highlights.Highlight)de.Value).ClassName);
            foreach (DictionaryEntry de in Globals.ClassList)
                AddClass(Conversions.ToString(de.Key));
        }

        private void AddClass(string ClassName)
        {
            if ((ClassName ?? "") == "default")
                return;
            if (ClassName.Length > 0)
            {
                if (ComboBoxClass.Items.Contains(ClassName.ToLower()) == false)
                {
                    ComboBoxClass.Items.Add(ClassName.ToLower());
                }
            }
        }

        private void ResetList()
        {
            ListViewBase.Clear();
            ListViewBase.Columns.Add("Highlight", 100, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Type", 100, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Color", 100, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Case Sensitive", 100, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Sound", 100, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Class", 100, HorizontalAlignment.Left);
        }

        private void ToolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            PopulateList();
            UpdateGroupBox();
        }

        private bool m_bSelectedChanged = false;

        private void ListViewBase_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_bSelectedChanged == false)
            {
                return;
            }

            UpdateGroupBox();
            m_bSelectedChanged = false;
        }

        private void ListViewBase_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bSelectedChanged == false)
            {
                return;
            }

            UpdateGroupBox();
            m_bSelectedChanged = false;
        }

        private void ListViewBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_bSelectedChanged = true;
        }

        private void CheckApplyChanges()
        {
            if (m_ItemChanged == true)
            {
                if (ListViewBase.SelectedItems.Count < 2)
                {
                    if (CheckBoxAutoApply.Checked == true)
                    {
                        ApplyChanges();
                    }
                    else if (Interaction.MsgBox("Current highlight item has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                    {
                        ApplyChanges();
                    }
                }
            }
        }

        private void UpdateGroupBox()
        {
            CheckApplyChanges();
            if (ListViewBase.SelectedItems.Count == 1)
            {
                TextBoxHighlight.Enabled = true;
                TextBoxHighlight.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxColor.Enabled = true;
                TextBoxColor.Text = ListViewBase.SelectedItems[0].SubItems[2].Text;
                TextBoxColor.Tag = ListViewBase.SelectedItems[0].SubItems[2].Text;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                LabelExampleColor.ForeColor = ListViewBase.SelectedItems[0].ForeColor;
                LabelExampleColor.BackColor = ListViewBase.SelectedItems[0].BackColor;
                RadioButtonString.Enabled = true;
                RadioButtonLine.Enabled = true;
                RadioButtonBeginsWith.Enabled = true;
                RadioButtonRegExp.Enabled = true;
                CheckBoxCaseSensitive.Enabled = true;
                var switchExpr = ListViewBase.SelectedItems[0].SubItems[1].Text;
                switch (switchExpr)
                {
                    case "String":
                        {
                            RadioButtonString.Checked = true;
                            RadioButtonString.Tag = "String";
                            break;
                        }

                    case "Line":
                        {
                            RadioButtonLine.Checked = true;
                            RadioButtonString.Tag = "Line";
                            break;
                        }

                    case "BeginsWith":
                        {
                            RadioButtonBeginsWith.Checked = true;
                            RadioButtonString.Tag = "BeginsWith";
                            break;
                        }

                    case "RegExp":
                        {
                            RadioButtonRegExp.Checked = true;
                            RadioButtonString.Tag = "RegExp";
                            break;
                        }
                }

                CheckBoxCaseSensitive.Checked = StringToBoolean(ListViewBase.SelectedItems[0].SubItems[3].Text);
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                TextBoxSound.Text = ListViewBase.SelectedItems[0].SubItems[4].Text;
                if (ListViewBase.SelectedItems[0].SubItems[5].Text.Length > 0)
                {
                    ComboBoxClass.Text = ListViewBase.SelectedItems[0].SubItems[5].Text;
                }
                else
                {
                    ComboBoxClass.Text = "(default)";
                }
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxHighlight.Enabled = false;
                TextBoxHighlight.Text = "";
                TextBoxColor.Enabled = true;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                RadioButtonString.Enabled = false;
                RadioButtonLine.Enabled = false;
                RadioButtonBeginsWith.Enabled = false;
                RadioButtonRegExp.Enabled = false;
                RadioButtonString.Tag = "";
                CheckBoxCaseSensitive.Enabled = false;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
            }
            else
            {
                ListWasUnselected();
            }

            m_ItemChanged = false; // Since textchanged event will fire when we change text
        }

        private bool StringToBoolean(string sData)
        {
            var switchExpr = ListViewBase.SelectedItems[0].SubItems[3].Text.ToLower();
            switch (switchExpr)
            {
                case "true":
                case "on":
                case "1":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private void ListWasUnselected()
        {
            TextBoxHighlight.Text = "";
            TextBoxColor.Text = "";
            LabelExampleColor.ForeColor = Color.Black;
            LabelExampleColor.BackColor = Color.Black;
            GroupBoxBase.Enabled = false;
            GroupBoxBase.Tag = null;
            RadioButtonString.Checked = true;
            RadioButtonString.Tag = "String";
            CheckBoxCaseSensitive.Checked = true;
            ToolStripButtonRemove.Enabled = false;
            RemoveToolStripMenuItem.Enabled = false;
        }

        private void TextBoxColor_Leave(object sender, EventArgs e)
        {
            UpdateTextBoxColor();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            m_ItemChanged = true;
        }

        public bool ApplyChanges()
        {
            if (Information.IsNothing(m_HighlightList))
            {
                return false;
            }

            if (TextBoxHighlight.Enabled == true & TextBoxHighlight.Text.Length == 0)
            {
                Interaction.MsgBox("Highlight box can not be empty!", MsgBoxStyle.Critical);
                TextBoxHighlight.Focus();
                return false;
            }

            if (TextBoxColor.Text.Length == 0)
            {
                Interaction.MsgBox("Color box can not be empty!", MsgBoxStyle.Critical);
                TextBoxColor.Focus();
                return false;
            }

            if (RadioButtonRegExp.Checked == true)
            {
                string argsRegExp = TextBoxHighlight.Text;
                if (TextBoxHighlight.Enabled == true & Utility.ValidateRegExp(argsRegExp) == false)
                {
                    Interaction.MsgBox("Invalid Highlight RegEx!", MsgBoxStyle.Critical);
                    TextBoxHighlight.Focus();
                    return false;
                }
            }

            if (!Information.IsNothing(GroupBoxBase.Tag))
            {
                string sOldHighlightType = string.Empty;
                if (!Information.IsNothing(RadioButtonString.Tag))
                {
                    sOldHighlightType = Conversions.ToString(RadioButtonString.Tag);
                }

                foreach (ListViewItem li in (ArrayList)GroupBoxBase.Tag)
                {
                    string sNewHighlightType = string.Empty;
                    if (TextBoxHighlight.Enabled == true) // Single Edit
                    {
                        if (RadioButtonString.Checked == true)
                        {
                            sNewHighlightType = "String";
                        }
                        else if (RadioButtonLine.Checked == true)
                        {
                            sNewHighlightType = "Line";
                        }
                        else if (RadioButtonBeginsWith.Checked == true)
                        {
                            sNewHighlightType = "BeginsWith";
                        }
                        else if (RadioButtonRegExp.Checked == true)
                        {
                            sNewHighlightType = "RegExp";
                        }

                        li.Text = TextBoxHighlight.Text;
                        switch (sOldHighlightType)
                        {
                            case "String":
                            case "Line":
                                {
                                    string argsKey = Conversions.ToString(li.Tag);
                                    m_HighlightList.Remove(argsKey);
                                    break;
                                }

                            case "BeginsWith":
                                {
                                    m_HighlightLineBeginsWith.Remove(li.Tag);
                                    break;
                                }

                            case "RegExp":
                                {
                                    m_HighlightRegExp.Remove(li.Tag);
                                    break;
                                }
                        }

                        li.SubItems[1].Text = sNewHighlightType;
                        li.SubItems[3].Text = Conversions.ToString(CheckBoxCaseSensitive.Checked);
                        li.SubItems[4].Text = TextBoxSound.Text;
                        li.Tag = li.Text;
                    }
                    else
                    {
                        sNewHighlightType = li.SubItems[1].Text;
                    }

                    if ((ComboBoxClass.Text ?? "") == "(default)")
                    {
                        li.SubItems[5].Text = "";
                    }
                    else
                    {
                        li.SubItems[5].Text = ComboBoxClass.Text;
                    }

                    bool bIsActive = Globals.ClassList.GetValue(li.SubItems[5].Text);
                    switch (sNewHighlightType)
                    {
                        case "String":
                            {
                                string argsKey1 = li.Text;
                                bool argbHighlightWholeRow = false;
                                m_HighlightList.Add(argsKey1, argbHighlightWholeRow, TextBoxColor.Text, StringToBoolean(li.SubItems[3].Text), li.SubItems[4].Text, li.SubItems[5].Text, bIsActive);
                                RadioButtonString.Tag = "String";
                                break;
                            }

                        case "Line":
                            {
                                string argsKey2 = li.Text;
                                bool argbHighlightWholeRow1 = true;
                                m_HighlightList.Add(argsKey2, argbHighlightWholeRow1, TextBoxColor.Text, StringToBoolean(li.SubItems[3].Text), li.SubItems[4].Text, li.SubItems[5].Text, bIsActive);
                                RadioButtonString.Tag = "Line";
                                break;
                            }

                        case "BeginsWith":
                            {
                                string argsKey3 = li.Text;
                                string argsColorName = TextBoxColor.Text;
                                m_HighlightLineBeginsWith.Add(argsKey3, argsColorName, StringToBoolean(li.SubItems[3].Text), li.SubItems[4].Text, li.SubItems[5].Text, bIsActive);
                                RadioButtonString.Tag = "BeginsWith";
                                break;
                            }

                        case "RegExp":
                            {
                                string argsKey4 = li.Text;
                                string argsColorName1 = TextBoxColor.Text;
                                m_HighlightRegExp.Add(argsKey4, argsColorName1, StringToBoolean(li.SubItems[3].Text), li.SubItems[4].Text, li.SubItems[5].Text, bIsActive);
                                RadioButtonString.Tag = "RegExp";
                                break;
                            }
                    }

                    li.SubItems[2].Text = TextBoxColor.Text;
                    li.ForeColor = LabelExampleColor.ForeColor;
                    li.BackColor = LabelExampleColor.BackColor;
                }
            }
            else // New
            {
                string sHighlightType = string.Empty;
                if (RadioButtonString.Checked == true)
                {
                    sHighlightType = "String";
                }
                else if (RadioButtonLine.Checked == true)
                {
                    sHighlightType = "Line";
                }
                else if (RadioButtonBeginsWith.Checked == true)
                {
                    sHighlightType = "BeginsWith";
                }
                else if (RadioButtonRegExp.Checked == true)
                {
                    sHighlightType = "RegExp";
                }

                if (IsDuplicateHighlight(TextBoxHighlight.Text, sHighlightType))
                {
                    Interaction.MsgBox("Highlight already exist!", MsgBoxStyle.Critical);
                    TextBoxHighlight.Focus();
                    return false;
                }

                RadioButtonString.Tag = sHighlightType; // Probably not needed since we select the node afterwards.
                string sClass = string.Empty;
                if ((ComboBoxClass.Text ?? "") != "(default)")
                {
                    sClass = ComboBoxClass.Text;
                }

                bool bIsActive = Globals.ClassList.GetValue(sClass);
                var switchExpr = sHighlightType;
                switch (switchExpr)
                {
                    case "String":
                        {
                            string argsKey5 = TextBoxHighlight.Text;
                            bool argbHighlightWholeRow2 = false;
                            m_HighlightList.Add(argsKey5, argbHighlightWholeRow2, TextBoxColor.Text, CheckBoxCaseSensitive.Checked, TextBoxSound.Text, sClass, bIsActive);
                            break;
                        }

                    case "Line":
                        {
                            string argsKey6 = TextBoxHighlight.Text;
                            bool argbHighlightWholeRow3 = true;
                            m_HighlightList.Add(argsKey6, argbHighlightWholeRow3, TextBoxColor.Text, CheckBoxCaseSensitive.Checked, TextBoxSound.Text, sClass, bIsActive);
                            break;
                        }

                    case "BeginsWith":
                        {
                            string argsKey7 = TextBoxHighlight.Text;
                            string argsColorName2 = TextBoxColor.Text;
                            m_HighlightLineBeginsWith.Add(argsKey7, argsColorName2, CheckBoxCaseSensitive.Checked, TextBoxSound.Text, sClass, bIsActive);
                            break;
                        }

                    case "RegExp":
                        {
                            string argsKey8 = TextBoxHighlight.Text;
                            string argsColorName3 = TextBoxColor.Text;
                            m_HighlightRegExp.Add(argsKey8, argsColorName3, CheckBoxCaseSensitive.Checked, TextBoxSound.Text, sClass, bIsActive);
                            break;
                        }
                }

                var li = ListViewBase.Items.Add(TextBoxHighlight.Text);
                li.SubItems.Add(sHighlightType);
                li.SubItems.Add(TextBoxColor.Text);
                li.SubItems.Add(CheckBoxCaseSensitive.Checked.ToString());
                li.SubItems.Add(TextBoxSound.Text);
                if ((ComboBoxClass.Text ?? "") == "(default)")
                {
                    li.SubItems.Add("");
                }
                else
                {
                    li.SubItems.Add(ComboBoxClass.Text);
                }

                li.Tag = TextBoxHighlight.Text;
                li.ForeColor = LabelExampleColor.ForeColor;
                li.BackColor = LabelExampleColor.BackColor;
                li.Selected = true;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }

            m_HighlightList.RebuildLineIndex();
            m_HighlightList.RebuildStringIndex();
            return true;
        }

        private bool IsDuplicateHighlight(string sKey, string sType)
        {
            switch (sType)
            {
                case "String":
                case "Line":
                    {
                        return m_HighlightList.ContainsKey(sKey);
                    }

                case "BeginsWith":
                    {
                        return m_HighlightLineBeginsWith.ContainsKey(sKey);
                    }

                case "RegExp":
                    {
                        return m_HighlightRegExp.ContainsKey(sKey);
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (ApplyChanges() == true)
            {
                m_ItemChanged = false;
            }
        }

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            ListViewBase.SelectedItems.Clear();
            GroupBoxBase.Enabled = true;
            GroupBoxBase.Tag = null;
            TextBoxHighlight.Text = "";
            TextBoxHighlight.Enabled = true;
            TextBoxColor.Text = "";
            TextBoxColor.Enabled = true;
            RadioButtonString.Checked = true;
            RadioButtonString.Tag = "String";
            RadioButtonString.Enabled = true;
            RadioButtonLine.Enabled = true;
            RadioButtonBeginsWith.Enabled = true;
            RadioButtonRegExp.Enabled = true;
            CheckBoxCaseSensitive.Enabled = true;
            CheckBoxCaseSensitive.Checked = true;
            TextBoxHighlight.Focus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            if (Information.IsNothing(m_HighlightList))
            {
                return;
            }

            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                var switchExpr = li.SubItems[1].Text;
                switch (switchExpr)
                {
                    case "String":
                    case "Line":
                        {
                            string argsKey = li.Text;
                            m_HighlightList.Remove(argsKey);
                            break;
                        }

                    case "BeginsWith":
                        {
                            m_HighlightLineBeginsWith.Remove(li.Text);
                            break;
                        }

                    case "RegExp":
                        {
                            m_HighlightRegExp.Remove(li.Text);
                            break;
                        }
                }

                li.Remove();
            }

            ListViewBase.SelectedItems.Clear();
            ListWasUnselected();
            m_ItemChanged = false;
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonRemove_Click(sender, e);
        }

        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_Globals) | Information.IsNothing(m_HighlightList) | Information.IsNothing(m_HighlightLineBeginsWith) | Information.IsNothing(m_HighlightRegExp))
            {
                return;
            }

            Globals.LoadHighlights();
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        public bool SaveToFile()
        {
            if (Information.IsNothing(m_Globals) | Information.IsNothing(m_HighlightList) | Information.IsNothing(m_HighlightLineBeginsWith) | Information.IsNothing(m_HighlightRegExp))
            {
                return default;
            }

            Globals.SaveHighlights();
            return default;
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            Genie.Sound.PlayWaveFile(TextBoxSound.Text);
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialogSound.InitialDirectory = LocalDirectory.Path + @"\Sounds";
            if (OpenFileDialogSound.ShowDialog() == DialogResult.OK)
            {
                string sPath = OpenFileDialogSound.FileName;
                if (sPath.StartsWith(LocalDirectory.Path + @"\Sounds"))
                {
                    sPath = sPath.Substring(LocalDirectory.Path.Length + 8);
                }

                TextBoxSound.Text = sPath;
            }
        }
    }
}