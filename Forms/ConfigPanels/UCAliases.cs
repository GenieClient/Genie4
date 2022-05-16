using System;
using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCAliases
    {
        public UCAliases()
        {
            InitializeComponent();
        }

        private Genie.Aliases m_AliasList;
        private bool m_ItemChanged = false;

        public Genie.Aliases AliasList
        {
            get
            {
                return m_AliasList;
            }

            set
            {
                m_AliasList = value;
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
            if (!Information.IsNothing(m_AliasList))
            {
                ResetList();
                foreach (DictionaryEntry de in m_AliasList)
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
            ListViewBase.Columns.Add("Alias", 100, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Action", 500, HorizontalAlignment.Left);
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
                TextBoxAlias.Enabled = true;
                TextBoxAlias.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxAction.Enabled = true;
                TextBoxAction.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxAlias.Enabled = false;
                TextBoxAlias.Text = "";
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
            TextBoxAlias.Text = "";
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
            if (Information.IsNothing(m_AliasList))
            {
                return false;
            }

            if (TextBoxAlias.Enabled == true & TextBoxAlias.Text.Length == 0)
            {
                Interaction.MsgBox("Alias box can not be empty!", MsgBoxStyle.Critical);
                TextBoxAlias.Focus();
                return false;
            }

            if (TextBoxAction.Text.Length == 0)
            {
                Interaction.MsgBox("Action box can not be empty!", MsgBoxStyle.Critical);
                TextBoxAction.Focus();
                return false;
            }

            if (!Information.IsNothing(GroupBoxBase.Tag))
            {
                foreach (ListViewItem li in (ArrayList)GroupBoxBase.Tag)
                {
                    if (TextBoxAlias.Enabled == true) // Single edit
                    {
                        if (IsDuplicateAlias(TextBoxAlias.Text))
                        {
                            Interaction.MsgBox("Alias already exist!", MsgBoxStyle.Critical);
                            TextBoxAlias.Focus();
                            return false;
                        }

                        li.Text = TextBoxAlias.Text;
                        string argsKey = Conversions.ToString(li.Tag);
                        m_AliasList.Remove(argsKey); // Remove old
                    }
                    else
                    {
                    } // Multi edit

                    if (TextBoxAction.Enabled == true)
                    {
                        li.SubItems[1].Text = TextBoxAction.Text;
                    }

                    string argsKey1 = li.Text;
                    string argsAlias = TextBoxAction.Text;
                    m_AliasList.Add(argsKey1, argsAlias);
                    li.Tag = li.Text;
                }
            }
            else // New
            {
                if (IsDuplicateAlias(TextBoxAlias.Text))
                {
                    Interaction.MsgBox("Alias already exist!", MsgBoxStyle.Critical);
                    TextBoxAlias.Focus();
                    return false;
                }

                string argsKey2 = TextBoxAlias.Text;
                string argsAlias1 = TextBoxAction.Text;
                m_AliasList.Add(argsKey2, argsAlias1);
                var li = ListViewBase.Items.Add(TextBoxAlias.Text);
                li.SubItems.Add(TextBoxAction.Text);
                li.Tag = TextBoxAlias.Text;
                li.Selected = true;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }

            return true;
        }

        private bool IsDuplicateAlias(string sKey)
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
            TextBoxAlias.Text = "";
            TextBoxAlias.Enabled = true;
            TextBoxAction.Text = "";
            TextBoxAction.Enabled = true;
            TextBoxAlias.Focus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            if (Information.IsNothing(m_AliasList))
            {
                return;
            }

            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                string argsKey = li.Text;
                m_AliasList.Remove(argsKey);
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
            if (Information.IsNothing(m_AliasList))
            {
                return;
            }

            m_AliasList.Clear();
            bool bResult = m_AliasList.Load();
            PopulateList();
            UpdateGroupBox();
            if (bResult == false)
            {
                Interaction.MsgBox("Load Failed!", MsgBoxStyle.Critical);
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_AliasList))
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
            return m_AliasList.Save();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.DialogEdit.EditText = TextBoxAction.Text;
            if (My.MyProject.Forms.DialogEdit.ShowDialog() == DialogResult.OK)
            {
                TextBoxAction.Text = My.MyProject.Forms.DialogEdit.EditText;
            }
        }
    }
}