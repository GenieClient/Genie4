using System;
using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCVariables
    {
        public UCVariables()
        {
            InitializeComponent();
        }

        private Genie.Globals.Variables m_VariableList;
        private bool m_ItemChanged = false;

        public Genie.Globals.Variables VariableList
        {
            get
            {
                return m_VariableList;
            }

            set
            {
                m_VariableList = value;
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
            if (!Information.IsNothing(m_VariableList))
            {
                ResetList();
                foreach (DictionaryEntry de in m_VariableList)
                {
                    var li = ListViewBase.Items.Add(de.Key.ToString());
                    li.Tag = de.Key.ToString();
                    Genie.Globals.Variables.Variable v = (Genie.Globals.Variables.Variable)de.Value;
                    li.SubItems.Add(v.sValue);
                }
            }
        }

        private void ResetList()
        {
            ListViewBase.Clear();
            ListViewBase.Columns.Add("Variable", 200, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Value", 400, HorizontalAlignment.Left);
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
                TextBoxVariable.Enabled = true;
                TextBoxVariable.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxAction.Enabled = true;
                TextBoxAction.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxVariable.Enabled = false;
                TextBoxVariable.Text = "";
                TextBoxAction.Enabled = true;
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
            TextBoxVariable.Text = "";
            TextBoxAction.Text = "";
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
            if (Information.IsNothing(m_VariableList))
            {
                return false;
            }

            if (TextBoxVariable.Enabled == true & TextBoxVariable.Text.Length == 0)
            {
                Interaction.MsgBox("Variable box can not be empty!", MsgBoxStyle.Critical);
                TextBoxVariable.Focus();
                return false;
            }

            if (TextBoxAction.Text.Length == 0)
            {
                Interaction.MsgBox("Value box can not be empty!", MsgBoxStyle.Critical);
                TextBoxAction.Focus();
                return false;
            }

            if (!Information.IsNothing(GroupBoxBase.Tag))
            {
                foreach (ListViewItem li in (ArrayList)GroupBoxBase.Tag)
                {
                    if (TextBoxVariable.Enabled == true) // Single edit
                    {
                        if (IsDuplicateVariable(TextBoxVariable.Text))
                        {
                            Interaction.MsgBox("Variable already exist!", MsgBoxStyle.Critical);
                            TextBoxVariable.Focus();
                            return false;
                        }

                        li.Text = TextBoxVariable.Text;
                        m_VariableList.Remove(li.Tag); // Remove old
                    }
                    else
                    {
                    } // Multi edit

                    if (TextBoxAction.Enabled == true)
                    {
                        li.SubItems[1].Text = TextBoxAction.Text;
                    }

                    string argkey = li.Text;
                    string argvalue = TextBoxAction.Text;
                    m_VariableList.Add(argkey, argvalue);
                    li.Tag = li.Text;
                }
            }
            else // New
            {
                if (IsDuplicateVariable(TextBoxVariable.Text))
                {
                    Interaction.MsgBox("Variable already exist!", MsgBoxStyle.Critical);
                    TextBoxVariable.Focus();
                    return false;
                }

                string argkey1 = TextBoxVariable.Text;
                string argvalue1 = TextBoxAction.Text;
                m_VariableList.Add(argkey1, argvalue1);
                var li = ListViewBase.Items.Add(TextBoxVariable.Text);
                li.SubItems.Add(TextBoxAction.Text);
                li.Tag = TextBoxVariable.Text;
                li.Selected = true;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }

            return true;
        }

        private bool IsDuplicateVariable(string sKey)
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
            TextBoxVariable.Text = "";
            TextBoxVariable.Enabled = true;
            TextBoxAction.Text = "";
            TextBoxAction.Enabled = true;
            TextBoxVariable.Focus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            if (Information.IsNothing(m_VariableList))
            {
                return;
            }

            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                m_VariableList.Remove(li.Text);
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
            if (Information.IsNothing(m_VariableList))
            {
                return;
            }

            m_VariableList.ClearUser();
            bool bResult = m_VariableList.Load();
            PopulateList();
            UpdateGroupBox();
            if (bResult == false)
            {
                Interaction.MsgBox("Load Failed!", MsgBoxStyle.Critical);
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_VariableList))
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
            return m_VariableList.Save();
        }
    }
}