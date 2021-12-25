using System;
using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCSubs
    {
        public UCSubs()
        {
            InitializeComponent();
        }

        private Genie.Globals.SubstituteRegExp m_SubstituteList;
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

        public Genie.Globals.SubstituteRegExp SubstituteList
        {
            get
            {
                return m_SubstituteList;
            }

            set
            {
                m_SubstituteList = value;
            }
        }

        public bool ItemChanged
        {
            get
            {
                return m_ItemChanged;
            }
        }

        private void UCWindows_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void PopulateList()
        {
            if (!Information.IsNothing(m_SubstituteList))
            {
                ResetList();
                foreach (Genie.Globals.SubstituteRegExp.Substitute sl in m_SubstituteList)
                {
                    var li = ListViewBase.Items.Add(sl.sText);
                    li.Tag = sl.sText;
                    li.SubItems.Add(sl.sReplaceBy);
                    li.SubItems.Add(sl.ClassName);
                }
            }

            PopulateClasses();
        }

        private void PopulateClasses()
        {
            ComboBoxClass.Items.Clear();
            ComboBoxClass.Items.Add("(default)");
            foreach (Genie.Globals.SubstituteRegExp.Substitute sl in m_SubstituteList)
                AddClass(sl.ClassName);
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
            ListViewBase.Columns.Add("Substitute", 250, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("With", 250, HorizontalAlignment.Left);
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
                TextBoxReplace.Enabled = true;
                TextBoxReplace.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxReplaceWith.Enabled = true;
                TextBoxReplaceWith.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
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
                TextBoxReplace.Enabled = false;
                TextBoxReplace.Text = "";
                TextBoxReplaceWith.Enabled = true;
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
            TextBoxReplace.Text = "";
            TextBoxReplaceWith.Text = "";
            GroupBoxBase.Enabled = false;
            GroupBoxBase.Tag = null;
            ToolStripButtonRemove.Enabled = false;
            RemoveToolStripMenuItem.Enabled = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            m_ItemChanged = true;
        }

        public bool ApplyChanges()
        {
            if (Information.IsNothing(m_SubstituteList))
            {
                return false;
            }

            if (TextBoxReplace.Enabled == true & TextBoxReplace.Text.Length == 0)
            {
                Interaction.MsgBox("Substitute box can not be empty!", MsgBoxStyle.Critical);
                TextBoxReplace.Focus();
                return false;
            }

            if (TextBoxReplaceWith.Text.Length == 0)
            {
                Interaction.MsgBox("Replace With box can not be empty!", MsgBoxStyle.Critical);
                TextBoxReplaceWith.Focus();
                return false;
            }

            if (!Information.IsNothing(GroupBoxBase.Tag))
            {
                foreach (ListViewItem li in (ArrayList)GroupBoxBase.Tag)
                {
                    if (TextBoxReplace.Enabled == true) // Single edit
                    {
                        if (IsDuplicateSubstitute(TextBoxReplace.Text))
                        {
                            Interaction.MsgBox("Substitute already exist!", MsgBoxStyle.Critical);
                            TextBoxReplace.Focus();
                            return false;
                        }

                        li.Text = TextBoxReplace.Text;
                        string argText = Conversions.ToString(li.Tag);
                        m_SubstituteList.Remove(argText); // Remove old
                    }
                    else
                    {
                    } // Multi edit

                    if (TextBoxReplaceWith.Enabled == true)
                    {
                        li.SubItems[1].Text = TextBoxReplaceWith.Text;
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
                    string argsText = li.Text;
                    string argReplaceBy = TextBoxReplaceWith.Text;
                    m_SubstituteList.Add(argsText, argReplaceBy, false, sClass);
                    li.Tag = li.Text;
                }
            }
            else // New
            {
                if (IsDuplicateSubstitute(TextBoxReplace.Text))
                {
                    Interaction.MsgBox("Substitute already exist!", MsgBoxStyle.Critical);
                    TextBoxReplace.Focus();
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

                string argsText1 = TextBoxReplace.Text;
                string argReplaceBy1 = TextBoxReplaceWith.Text;
                m_SubstituteList.Add(argsText1, argReplaceBy1, false, sClass);
                var li = ListViewBase.Items.Add(TextBoxReplace.Text);
                li.SubItems.Add(TextBoxReplaceWith.Text);
                if ((ComboBoxClass.Text ?? "") == "(default)")
                {
                    li.SubItems.Add("");
                }
                else
                {
                    li.SubItems.Add(ComboBoxClass.Text);
                }

                li.Tag = TextBoxReplace.Text;
                li.Selected = true;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }

            return true;
        }

        private bool IsDuplicateSubstitute(string sKey)
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
            TextBoxReplace.Text = "";
            TextBoxReplace.Enabled = true;
            TextBoxReplaceWith.Text = "";
            TextBoxReplaceWith.Enabled = true;
            TextBoxReplace.Focus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            if (Information.IsNothing(m_SubstituteList))
            {
                return;
            }

            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                string argText = li.Text;
                m_SubstituteList.Remove(argText);
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
            if (Information.IsNothing(m_SubstituteList))
            {
                return;
            }

            m_SubstituteList.Clear();
            bool bResult = m_SubstituteList.Load();
            PopulateList();
            UpdateGroupBox();
            if (bResult == false)
            {
                Interaction.MsgBox("Load Failed!", MsgBoxStyle.Critical);
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_SubstituteList))
            {
                return;
            }

            bool bResult = SaveToFile();
            if (bResult == false)
            {
                Interaction.MsgBox("Substitutees Saved!", MsgBoxStyle.Information);
            }
        }

        public bool SaveToFile()
        {
            return m_SubstituteList.Save();
        }
    }
}