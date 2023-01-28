﻿using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GenieClient.Genie;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCName
    {
        public UCName()
        {
            InitializeComponent();
        }

        private Genie.Names m_NameList;
        private bool m_ItemChanged = false;
        private Genie.Globals m_Globals;

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

        public Genie.Names NameList
        {
            get
            {
                return m_NameList;
            }

            set
            {
                m_NameList = value;
            }
        }

        public bool ItemChanged
        {
            get
            {
                return m_ItemChanged;
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

        private void UCWindows_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateList();
            }
            catch (NullReferenceException)
            {
                // todo
            }
        }

        private void PopulateList()
        {
            ResetList();
            if (!Information.IsNothing(m_NameList))
            {

                foreach (DictionaryEntry de in m_NameList)
                {
                    var li = ListViewBase.Items.Add(de.Key.ToString());
                    li.Tag = de.Key.ToString();
                    Genie.Names.Name oName = (Genie.Names.Name)de.Value;
                    li.SubItems.Add(oName.ColorName);
                    li.ForeColor = oName.FgColor;
                    // MsgBox(li.BackColor.ToString)
                    if (oName.BgColor != Color.Transparent)
                    {
                        li.BackColor = oName.BgColor;
                    }
                    li.SubItems.Add(oName.ClassName);
                }
            }

            PopulateClasses();
        }

        private void PopulateClasses()
        {
            ComboBoxClass.Items.Clear();
            ComboBoxClass.Items.Add("(default)");
            foreach (DictionaryEntry sl in m_NameList)
                AddClass(((Genie.Names.Name)sl.Value).ClassName);
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
            ListViewBase.Columns.Add("Name", 200, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Color", 400, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Class", 100, HorizontalAlignment.Left);
        }

        private void ListViewBase_SortColumnClick(object sender, ColumnClickEventArgs e)
        {
            _ListViewBase.Sorting = System.Windows.Forms.SortOrder.None;

            if (ListViewBase.Tag == null || (int)ListViewBase.Tag > 0)
            {
                ListViewItem[] tmp = ListViewBase.Items.Cast<ListViewItem>().OrderBy(t => t.SubItems[e.Column].Text).ToArray();
                ListViewBase.Items.Clear();
                ListViewBase.Items.AddRange(tmp);

                ListViewBase.Tag = -1;
            }
            else
            {
                ListViewItem[] tmp = ListViewBase.Items.Cast<ListViewItem>().OrderByDescending(t => t.SubItems[e.Column].Text).ToArray();
                ListViewBase.Items.Clear();
                ListViewBase.Items.AddRange(tmp);

                ListViewBase.Tag = +1;
            }
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
                    if (Interaction.MsgBox("Current item has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
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
                TextBoxName.Enabled = true;
                TextBoxName.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxColor.Enabled = true;
                TextBoxColor.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                TextBoxColor.Tag = ListViewBase.SelectedItems[0].SubItems[1].Text;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                LabelExampleColor.ForeColor = ListViewBase.SelectedItems[0].ForeColor;
                LabelExampleColor.BackColor = ListViewBase.SelectedItems[0].BackColor;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                if (ListViewBase.SelectedItems[0].SubItems[2].Text.Length > 0)
                {
                    ComboBoxClass.Text = ListViewBase.SelectedItems[0].SubItems[2].Text;
                }
                else
                {
                    ComboBoxClass.Text = "(default)";
                }
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxName.Enabled = false;
                TextBoxName.Text = "";
                TextBoxColor.Enabled = true;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
            }
            else
            {
                ListWasUnselected();
            }

            m_ItemChanged = false; // Since textchanged event will fire when we change text
        }

        private void ListWasUnselected()
        {
            TextBoxName.Text = "";
            TextBoxColor.Text = "";
            LabelExampleColor.ForeColor = Color.Black;
            LabelExampleColor.BackColor = Color.Black;
            GroupBoxBase.Enabled = false;
            GroupBoxBase.Tag = null;
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
            if (Information.IsNothing(m_NameList))
            {
                return false;
            }

            if (TextBoxName.Enabled == true & TextBoxName.Text.Length == 0)
            {
                Interaction.MsgBox("Name box can not be empty!", MsgBoxStyle.Critical);
                TextBoxName.Focus();
                return false;
            }

            if (TextBoxColor.Text.Length == 0)
            {
                Interaction.MsgBox("Color box can not be empty!", MsgBoxStyle.Critical);
                TextBoxColor.Focus();
                return false;
            }

            if (!Information.IsNothing(GroupBoxBase.Tag))
            {
                foreach (ListViewItem li in (ArrayList)GroupBoxBase.Tag)
                {
                    if (TextBoxName.Enabled == true) // Single edit
                    {
                        li.Text = TextBoxName.Text;
                        string argsKey = Conversions.ToString(li.Tag);
                        m_NameList.Remove(argsKey); // Remove old
                    }
                    else
                    {
                    } // Multi edit

                    if (TextBoxColor.Enabled == true)
                    {
                        li.SubItems[1].Text = TextBoxColor.Text;
                        li.ForeColor = LabelExampleColor.ForeColor;
                        li.BackColor = LabelExampleColor.BackColor;
                    }

                    string sClass = string.Empty;
                    if ((ComboBoxClass.Text ?? "") == "(default)")
                    {
                        sClass = "";
                    }
                    else
                    {
                        sClass = ComboBoxClass.Text;
                    }
                    li.SubItems[2].Text = sClass;
                    string argsKey1 = li.Text;
                    m_NameList.Add(argsKey1, TextBoxColor.Text, sClass);
                    li.Tag = li.Text;
                }
            }
            else // New
            {
                if (IsDuplicateName(TextBoxName.Text))
                {
                    Interaction.MsgBox("Name already exist!", MsgBoxStyle.Critical);
                    TextBoxName.Focus();
                    return false;
                }

                string sClass = string.Empty;
                if ((ComboBoxClass.Text ?? "") == "(default)")
                {
                    sClass = "";
                }
                else
                {
                    sClass = ComboBoxClass.Text;
                }

                string argsKey2 = TextBoxName.Text;
                m_NameList.Add(argsKey2, TextBoxColor.Text);
                var li = ListViewBase.Items.Add(TextBoxName.Text, sClass);

                if ((ComboBoxClass.Text ?? "") == "(default)")
                {
                    li.SubItems.Add("");
                }
                else
                {
                    li.SubItems.Add(ComboBoxClass.Text);
                }

                li.SubItems.Add(TextBoxColor.Text);
                li.Tag = TextBoxName.Text;
                li.ForeColor = LabelExampleColor.ForeColor;
                li.BackColor = LabelExampleColor.BackColor;
                li.Selected = true;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }

            m_NameList.RebuildIndex();
            return true;
        }

        private bool IsDuplicateName(string sKey)
        {
            foreach (ListViewItem li in ListViewBase.Items)
            {
                if (li.Selected == false)
                {
                    if (!Information.IsNothing(li.Tag) && (Conversions.ToString(li.Tag) ?? "") == (sKey ?? ""))
                    {
                        return true;
                    }
                }
            }

            return false;
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
            TextBoxName.Text = "";
            TextBoxName.Enabled = true;
            TextBoxColor.Text = "";
            TextBoxColor.Enabled = true;
            TextBoxName.Focus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            if (Information.IsNothing(m_NameList))
            {
                return;
            }

            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                string argsKey = li.Text;
                m_NameList.Remove(argsKey);
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
            if (Information.IsNothing(m_NameList))
            {
                return;
            }

            m_NameList.Clear();
            bool bResult = m_NameList.Load();
            try
            {
                PopulateList();
            }
            catch (NullReferenceException)
            {
                // todo
            }
            UpdateGroupBox();

            if (bResult == false)
            {
                Interaction.MsgBox("Load Failed!", MsgBoxStyle.Critical);
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_NameList))
            {
                return;
            }

            bool bResult = SaveToFile();
            if (bResult == false)
            {
                Interaction.MsgBox("Saved Failed!", MsgBoxStyle.Information);
            }
        }

        public bool SaveToFile()
        {
            return m_NameList.Save();
        }
    }
}