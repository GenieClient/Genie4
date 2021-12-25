using System;
using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCMacros
    {
        public UCMacros()
        {
            InitializeComponent();
        }

        private Genie.Macros m_MacroList;
        private bool m_ItemChanged = false;

        public Genie.Macros MacroList
        {
            get
            {
                return m_MacroList;
            }

            set
            {
                m_MacroList = value;
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
            if (!Information.IsNothing(m_MacroList))
            {
                ResetList();
                foreach (DictionaryEntry de in m_MacroList)
                {
                    var li = ListViewBase.Items.Add(((Keys)Conversions.ToInteger(de.Key)).ToString());
                    li.Tag = ((Keys)Conversions.ToInteger(de.Key)).ToString();
                    li.SubItems.Add(((Genie.Macros.Macro)de.Value).sAction);
                }
            }
        }

        private void ResetList()
        {
            ListViewBase.Clear();
            ListViewBase.Columns.Add("Macro", 100, HorizontalAlignment.Left);
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
                TextBoxMacro.Enabled = true;
                TextBoxMacro.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxAction.Enabled = true;
                TextBoxAction.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxMacro.Enabled = false;
                TextBoxMacro.Text = "";
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
            TextBoxMacro.Text = "";
            TextBoxAction.Text = "";
            GroupBoxBase.Enabled = false;
            GroupBoxBase.Tag = null;
            ToolStripButtonRemove.Enabled = false;
            RemoveToolStripMenuItem.Enabled = false;
        }

        private void TextBoxMacro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            m_ItemChanged = true;
        }

        public bool ApplyChanges()
        {
            if (Information.IsNothing(m_MacroList))
            {
                return false;
            }

            if (TextBoxMacro.Enabled == true & TextBoxMacro.Text.Length == 0)
            {
                Interaction.MsgBox("Macro box can not be empty!", MsgBoxStyle.Critical);
                TextBoxMacro.Focus();
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
                    if (TextBoxMacro.Enabled == true) // Single edit
                    {
                        if (IsDuplicateMacro(TextBoxMacro.Text))
                        {
                            Interaction.MsgBox("Macro already exist!", MsgBoxStyle.Critical);
                            TextBoxMacro.Focus();
                            return false;
                        }

                        li.Text = TextBoxMacro.Text;
                    }
                    else // Multi edit
                    {
                        string argsKey = Conversions.ToString(li.Tag);
                        m_MacroList.Remove(argsKey);
                    }

                    if (TextBoxAction.Enabled == true)
                    {
                        li.SubItems[1].Text = TextBoxAction.Text;
                    }

                    string argsKey1 = li.Text;
                    string argsMacro = TextBoxAction.Text;
                    m_MacroList.Add(argsKey1, argsMacro);
                    li.Tag = li.Text;
                }
            }
            else // New
            {
                if (IsDuplicateMacro(TextBoxMacro.Text))
                {
                    Interaction.MsgBox("Macro already exist!", MsgBoxStyle.Critical);
                    TextBoxMacro.Focus();
                    return false;
                }

                string argsKey2 = TextBoxMacro.Text;
                string argsMacro1 = TextBoxAction.Text;
                m_MacroList.Add(argsKey2, argsMacro1);
                var li = ListViewBase.Items.Add(TextBoxMacro.Text);
                li.SubItems.Add(TextBoxAction.Text);
                li.Tag = TextBoxMacro.Text;
                li.Selected = true;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }

            return true;
        }

        private bool IsDuplicateMacro(string sKey)
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
            TextBoxMacro.Text = "";
            TextBoxMacro.Enabled = true;
            TextBoxAction.Text = "";
            TextBoxAction.Enabled = true;
            TextBoxMacro.Focus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            if (Information.IsNothing(m_MacroList))
            {
                return;
            }

            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                string argsKey = li.Text;
                m_MacroList.Remove(argsKey);
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

        private void TextBoxMacro_KeyDown(object sender, KeyEventArgs e)
        {
            if (Information.IsNothing(m_MacroList))
            {
                return;
            }

            string sKeyText = ((Keys)Conversions.ToInteger(e.KeyValue)).ToString();
            if (e.Shift == true)
            {
                sKeyText += ", Shift";
            }

            if (e.Control == true)
            {
                sKeyText += ", Control";
            }

            if (e.Alt == true)
            {
                sKeyText += ", Alt";
            }

            TextBoxMacro.Text = sKeyText;
            TextBoxMacro.SelectionStart = int.MaxValue;
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_MacroList))
            {
                return;
            }

            m_MacroList.Clear();
            bool bResult = m_MacroList.Load();
            PopulateList();
            UpdateGroupBox();
            if (bResult == false)
            {
                Interaction.MsgBox("Load Failed!", MsgBoxStyle.Critical);
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_MacroList))
            {
                return;
            }

            bool bResult = SaveToFile();
            if (bResult == false)
            {
                Interaction.MsgBox("Macros Saved!", MsgBoxStyle.Information);
            }
        }

        public bool SaveToFile()
        {
            return m_MacroList.Save();
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