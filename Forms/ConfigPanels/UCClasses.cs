using System;
using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCClasses
    {
        public UCClasses()
        {
            InitializeComponent();
        }

        private Genie.Classes m_ClassList;
        private bool m_ItemChanged = false;

        public Genie.Classes ClassList
        {
            get
            {
                return m_ClassList;
            }

            set
            {
                m_ClassList = value;
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
            if (!Information.IsNothing(m_ClassList))
            {
                ResetList();
                foreach (DictionaryEntry de in m_ClassList)
                {
                    var li = ListViewBase.Items.Add(de.Key.ToString());
                    li.Tag = de.Key.ToString();
                    li.SubItems.Add(de.Value.ToString());
                }
            }
        }

        private void ResetList()
        {
            ListViewBase.Clear();
            ListViewBase.Columns.Add("Class", 200, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Enabled", 400, HorizontalAlignment.Left);
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
                TextBoxClass.Enabled = true;
                TextBoxClass.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxAction.Enabled = true;
                TextBoxAction.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxClass.Enabled = false;
                TextBoxClass.Text = "";
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
            TextBoxClass.Text = "";
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
            if (Information.IsNothing(m_ClassList))
            {
                return false;
            }

            if (TextBoxClass.Enabled == true & TextBoxClass.Text.Length == 0)
            {
                Interaction.MsgBox("Class box can not be empty!", MsgBoxStyle.Critical);
                TextBoxClass.Focus();
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
                    if (TextBoxClass.Enabled == true) // Single edit
                    {
                        if (IsDuplicateClass(TextBoxClass.Text))
                        {
                            Interaction.MsgBox("Class already exist!", MsgBoxStyle.Critical);
                            TextBoxClass.Focus();
                            return false;
                        }

                        li.Text = TextBoxClass.Text;
                        string argsKey = Conversions.ToString(li.Tag);
                        m_ClassList.Remove(argsKey); // Remove old
                    }
                    else
                    {
                    } // Multi edit

                    if (TextBoxAction.Enabled == true)
                    {
                        li.SubItems[1].Text = TextBoxAction.Text;
                    }

                    string argsKey1 = li.Text;
                    string argsValue = TextBoxAction.Text;
                    m_ClassList.Add(argsKey1, argsValue);
                    li.Tag = li.Text;
                }
            }
            else // New
            {
                if (IsDuplicateClass(TextBoxClass.Text))
                {
                    Interaction.MsgBox("Class already exist!", MsgBoxStyle.Critical);
                    TextBoxClass.Focus();
                    return false;
                }

                string argsKey2 = TextBoxClass.Text;
                string argsValue1 = TextBoxAction.Text;
                m_ClassList.Add(argsKey2, argsValue1);
                var li = ListViewBase.Items.Add(TextBoxClass.Text);
                li.SubItems.Add(TextBoxAction.Text);
                li.Tag = TextBoxClass.Text;
                li.Selected = true;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }

            return true;
        }

        private bool IsDuplicateClass(string sKey)
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
            TextBoxClass.Text = "";
            TextBoxClass.Enabled = true;
            TextBoxAction.Text = "";
            TextBoxAction.Enabled = true;
            TextBoxClass.Focus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            if (Information.IsNothing(m_ClassList))
            {
                return;
            }

            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                string argsKey = li.Text;
                m_ClassList.Remove(argsKey);
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
            if (Information.IsNothing(m_ClassList))
            {
                return;
            }

            m_ClassList.Clear();
            bool bResult = m_ClassList.Load();
            PopulateList();
            UpdateGroupBox();
            if (bResult == false)
            {
                Interaction.MsgBox("Load Failed!", MsgBoxStyle.Critical);
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_ClassList))
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
            return m_ClassList.Save();
        }
    }
}