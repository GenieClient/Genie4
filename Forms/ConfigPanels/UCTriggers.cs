using System;
using System.Collections;
using System.Windows.Forms;
using GenieClient.Genie;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCTriggers
    {
        public UCTriggers()
        {
            InitializeComponent();
        }

        private Genie.Globals.Triggers m_TriggerList;
        private bool m_ItemChanged = false;
        private Genie.Globals m_Globals;

        public Genie.Globals.Triggers TriggerList
        {
            get
            {
                return m_TriggerList;
            }

            set
            {
                m_TriggerList = value;
            }
        }

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
            if (!Information.IsNothing(m_TriggerList))
            {
                ResetList();
                foreach (DictionaryEntry de in m_TriggerList)
                {
                    var li = ListViewBase.Items.Add(de.Key.ToString());
                    li.Tag = de.Key.ToString();
                    Genie.Globals.Triggers.Trigger trigger = (Genie.Globals.Triggers.Trigger)de.Value;
                    li.SubItems.Add(trigger.sAction);
                    li.SubItems.Add(trigger.bIsEvalTrigger.ToString());
                    li.SubItems.Add(trigger.ClassName);
                }
            }

            PopulateClasses();
        }

        private void PopulateClasses()
        {
            ComboBoxClass.Items.Clear();
            ComboBoxClass.Items.Add("(default)");
            foreach (DictionaryEntry de in m_TriggerList)
                AddClass(((Genie.Globals.Triggers.Trigger)de.Value).ClassName);
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
            ListViewBase.Columns.Add("Trigger", 300, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Action", 150, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Eval", 50, HorizontalAlignment.Left);
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
                TextBoxTrigger.Enabled = true;
                TextBoxTrigger.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxAction.Enabled = true;
                TextBoxAction.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                CheckBoxEval.Enabled = true;
                string argsValue = ListViewBase.SelectedItems[0].SubItems[2].Text;
                CheckBoxEval.Checked = Utility.StringToBoolean(argsValue);
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                if (ListViewBase.SelectedItems[0].SubItems[3].Text.Length > 0)
                {
                    ComboBoxClass.Text = ListViewBase.SelectedItems[0].SubItems[3].Text;
                }
                else
                {
                    ComboBoxClass.Text = "(default)";
                }

                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxTrigger.Enabled = false;
                TextBoxTrigger.Text = "";
                CheckBoxEval.Enabled = false;
                CheckBoxEval.Checked = false;
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
            TextBoxTrigger.Text = "";
            TextBoxAction.Text = "";
            CheckBoxEval.Checked = false;
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
            if (Information.IsNothing(m_TriggerList))
            {
                return false;
            }

            if (TextBoxTrigger.Enabled == true & TextBoxTrigger.Text.Length == 0)
            {
                Interaction.MsgBox("Trigger box can not be empty!", MsgBoxStyle.Critical);
                TextBoxTrigger.Focus();
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
                    if (TextBoxTrigger.Enabled == true) // Single edit
                    {
                        if (IsDuplicateTrigger(TextBoxTrigger.Text))
                        {
                            Interaction.MsgBox("Trigger already exist!", MsgBoxStyle.Critical);
                            TextBoxTrigger.Focus();
                            return false;
                        }

                        li.Text = TextBoxTrigger.Text;
                        string argsTrigger = Conversions.ToString(li.Tag);
                        m_TriggerList.Remove(argsTrigger); // Remove old
                    }
                    else
                    {
                    } // Multi edit

                    if (TextBoxAction.Enabled == true)
                    {
                        li.SubItems[1].Text = TextBoxAction.Text;
                    }

                    if (CheckBoxEval.Enabled == true)
                    {
                        li.SubItems[2].Text = CheckBoxEval.Checked.ToString();
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

                    li.SubItems[3].Text = sClass;
                    string argsTrigger1 = li.Text;
                    string argsAction = TextBoxAction.Text;
                    m_TriggerList.Add(argsTrigger1, argsAction, false, CheckBoxEval.Checked, sClass);
                    li.Tag = li.Text;
                }
            }
            else // New
            {
                if (IsDuplicateTrigger(TextBoxTrigger.Text))
                {
                    Interaction.MsgBox("Trigger already exist!", MsgBoxStyle.Critical);
                    TextBoxTrigger.Focus();
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

                string argsTrigger2 = TextBoxTrigger.Text;
                string argsAction1 = TextBoxAction.Text;
                m_TriggerList.Add(argsTrigger2, argsAction1, false, CheckBoxEval.Checked, sClass);
                var li = ListViewBase.Items.Add(TextBoxTrigger.Text);
                li.SubItems.Add(TextBoxAction.Text);
                li.SubItems.Add(CheckBoxEval.Checked.ToString());
                if ((ComboBoxClass.Text ?? "") == "(default)")
                {
                    li.SubItems.Add("");
                }
                else
                {
                    li.SubItems.Add(ComboBoxClass.Text);
                }

                li.Tag = TextBoxTrigger.Text;
                li.Selected = true;
                ToolStripButtonRemove.Enabled = true;
                RemoveToolStripMenuItem.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }

            return true;
        }

        private bool IsDuplicateTrigger(string sKey)
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
            TextBoxTrigger.Text = "";
            TextBoxTrigger.Enabled = true;
            TextBoxAction.Text = "";
            TextBoxAction.Enabled = true;
            CheckBoxEval.Enabled = true;
            CheckBoxEval.Checked = false;
            TextBoxTrigger.Focus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            if (Information.IsNothing(m_TriggerList))
            {
                return;
            }

            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                string argsTrigger = li.Text;
                m_TriggerList.Remove(argsTrigger);
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
            if (Information.IsNothing(m_TriggerList))
            {
                return;
            }

            m_TriggerList.Clear();
            bool bResult = m_TriggerList.Load();
            PopulateList();
            UpdateGroupBox();
            if (bResult == false)
            {
                Interaction.MsgBox("Load Failed!", MsgBoxStyle.Critical);
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_TriggerList))
            {
                return;
            }

            bool bResult = SaveToFile();
            if (bResult == false)
            {
                Interaction.MsgBox("Triggeres Saved!", MsgBoxStyle.Information);
            }
        }

        public bool SaveToFile()
        {
            return m_TriggerList.Save();
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