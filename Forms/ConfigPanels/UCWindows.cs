using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCWindows
    {
        public UCWindows()
        {
            InitializeComponent();
        }

        private FormMain m_FormMain;
        private bool m_ItemChanged = false;

        public FormMain FormParent
        {
            get
            {
                return m_FormMain;
            }

            set
            {
                m_FormMain = value;
            }
        }

        public bool ItemChanged
        {
            get
            {
                return m_ItemChanged;
            }
        }

        public void PopulateList()
        {
            if (!Information.IsNothing(m_FormMain))
            {
                ResetList();
                var li = ListViewBase.Items.Add(m_FormMain.OutputMain.Text);
                li.SubItems.Add(GetFontName(m_FormMain.OutputMain.RichTextBoxOutput.Font));
                li.SubItems.Add(Genie.ColorCode.ColorToString(m_FormMain.OutputMain.RichTextBoxOutput.ForeColor, m_FormMain.OutputMain.RichTextBoxOutput.BackColor));
                li.SubItems.Add(m_FormMain.OutputMain.TimeStamp.ToString());
                li.SubItems.Add(m_FormMain.OutputMain.NameListOnly.ToString());
                li.Tag = m_FormMain.OutputMain;
                var myEnumerator = m_FormMain.FormList.GetEnumerator();
                FormSkin tmpFormSkin;
                while (myEnumerator.MoveNext())
                {
                    tmpFormSkin = (FormSkin)myEnumerator.Current;
                    li = ListViewBase.Items.Add(tmpFormSkin.Text);
                    li.SubItems.Add(GetFontName(tmpFormSkin.RichTextBoxOutput.Font));
                    li.SubItems.Add(Genie.ColorCode.ColorToString(tmpFormSkin.RichTextBoxOutput.ForeColor, tmpFormSkin.RichTextBoxOutput.BackColor));
                    li.SubItems.Add(tmpFormSkin.TimeStamp.ToString());
                    li.SubItems.Add(tmpFormSkin.NameListOnly.ToString());
                    li.Tag = tmpFormSkin;
                }
            }
        }

        private void ResetList()
        {
            ListViewBase.Clear();
            ListViewBase.Columns.Add("Title", 150, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Font", 150, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Colors", 150, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Time Stamp", 75, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Name List Only", 75, HorizontalAlignment.Left);
        }

        private void ToolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            PopulateList();
            UpdateGroupBox();
            UpdateIfClosedBox();
        }

        private bool m_bSelectedChanged = false;

        private void ListViewBase_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_bSelectedChanged == false)
            {
                return;
            }

            UpdateGroupBox();
            UpdateIfClosedBox();
            m_bSelectedChanged = false;
        }

        private void ListViewBase_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bSelectedChanged == false)
            {
                return;
            }

            UpdateGroupBox();
            UpdateIfClosedBox();
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

        private void UpdateIfClosedBox()
        {
            ComboBoxIfClosed.Items.Clear();
            ComboBoxIfClosed.Items.Add("(default)");
            ComboBoxIfClosed.Items.Add("(disabled)");
            foreach (ListViewItem lvi in ListViewBase.Items)
            {
                FormSkin fo = (FormSkin)lvi.Tag;
                ComboBoxIfClosed.Items.Add(fo.ID);
            }

            ComboBoxIfClosed.Enabled = true;
            if (ListViewBase.SelectedItems.Count == 1)
            {
                if (!Information.IsNothing(ListViewBase.SelectedItems[0].Tag))
                {
                    FormSkin fo = (FormSkin)ListViewBase.SelectedItems[0].Tag;
                    if ((fo.ID ?? "") == "main" | (fo.ID ?? "") == "inv" | (fo.ID ?? "") == "inventory" | (fo.ID ?? "") == "room")
                    {
                        ComboBoxIfClosed.Enabled = false;
                    }

                    if (!Information.IsNothing(fo.IfClosed))
                    {
                        if (string.IsNullOrEmpty(fo.IfClosed))
                        {
                            ComboBoxIfClosed.SelectedItem = "(disabled)";
                        }
                        else
                        {
                            ComboBoxIfClosed.SelectedItem = fo.IfClosed;
                        }
                    }
                }
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                ComboBoxIfClosed.Enabled = false;
            }

            if (Information.IsNothing(ComboBoxIfClosed.SelectedItem)) // Stop flickering
            {
                ComboBoxIfClosed.SelectedItem = "(default)";
            }
        }

        private void UpdateGroupBox()
        {
            CheckApplyChanges();
            if (ListViewBase.SelectedItems.Count == 1)
            {
                if (!Information.IsNothing(ListViewBase.SelectedItems[0].Tag))
                {
                    FormSkin fo = (FormSkin)ListViewBase.SelectedItems[0].Tag;
                    if (fo.UserForm == true)
                    {
                        TextBoxTitle.Enabled = true;
                    }
                    else
                    {
                        TextBoxTitle.Enabled = false;
                    }

                    TextBoxTitle.Text = ListViewBase.SelectedItems[0].Text;
                    CheckBoxTimeStamp.Enabled = true;
                    CheckBoxNameListOnly.Enabled = true;
                    TextBoxColor.Enabled = true;
                    TextBoxColor.Text = ListViewBase.SelectedItems[0].SubItems[2].Text;
                    TextBoxColor.Tag = ListViewBase.SelectedItems[0].SubItems[2].Text;
                    UpdateTextBoxColor();
                    TextBoxFont.Text = GetFontName(fo.TextFont);
                    TextBoxFont.Tag = fo.TextFont;
                    CheckBoxTimeStamp.Checked = fo.TimeStamp;
                    CheckBoxNameListOnly.Checked = fo.NameListOnly;
                    GroupBoxBase.Enabled = true;
                    GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                    ToolStripButtonRemove.Enabled = true;
                    RemoveToolStripMenuItem.Enabled = true;
                }
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxTitle.Text = "";
                TextBoxTitle.Enabled = false;
                TextBoxColor.Enabled = true;
                CheckBoxTimeStamp.Checked = false;
                CheckBoxNameListOnly.Checked = false;
                CheckBoxTimeStamp.Enabled = false;
                CheckBoxNameListOnly.Enabled = false;
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
            TextBoxTitle.Text = "";
            TextBoxFont.Text = "";
            TextBoxFont.Tag = null;
            TextBoxColor.Text = "";
            LabelExampleColor.ForeColor = Color.Black;
            LabelExampleColor.BackColor = Color.Black;
            CheckBoxTimeStamp.Checked = false;
            CheckBoxNameListOnly.Checked = false;
            GroupBoxBase.Enabled = false;
            GroupBoxBase.Tag = null;
            ToolStripButtonRemove.Enabled = false;
            RemoveToolStripMenuItem.Enabled = false;
        }

        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            m_ItemChanged = true;
        }

        public bool ApplyChanges()
        {
            if (!Information.IsNothing(GroupBoxBase.Tag))
            {
                foreach (ListViewItem li in (ArrayList)GroupBoxBase.Tag)
                {
                    if (!Information.IsNothing(li.Tag))
                    {
                        FormSkin fo = (FormSkin)li.Tag;
                        if (TextBoxTitle.Enabled == true) // Single edit
                        {
                            li.Text = TextBoxTitle.Text;
                            fo.Text = TextBoxTitle.Text;
                            fo.TimeStamp = CheckBoxTimeStamp.Checked;
                            fo.NameListOnly = CheckBoxNameListOnly.Checked;
                            li.SubItems[3].Text = CheckBoxTimeStamp.Checked.ToString();
                            li.SubItems[4].Text = CheckBoxNameListOnly.Checked.ToString();
                        }

                        if (!Information.IsNothing(TextBoxFont.Tag))
                        {
                            li.SubItems[1].Text = GetFontName((Font)TextBoxFont.Tag);
                            fo.TextFont = (Font)TextBoxFont.Tag;
                        }

                        if (!Information.IsNothing(TextBoxColor.Text))
                        {
                            string sColorName = TextBoxColor.Text;
                            li.SubItems[2].Text = TextBoxColor.Text;
                            if (sColorName.Length > 0)
                            {
                                if (sColorName.Contains(",") == true && sColorName.EndsWith(",") == false)
                                {
                                    string sColor = sColorName.Substring(0, sColorName.IndexOf(",")).Trim();
                                    string sBgColor = sColorName.Substring(sColorName.IndexOf(",") + 1).Trim();
                                    fo.RichTextBoxOutput.ForeColor = Genie.ColorCode.StringToColor(sColor);
                                    fo.RichTextBoxOutput.BackColor = Genie.ColorCode.StringToColor(sBgColor);
                                }
                                else
                                {
                                    fo.RichTextBoxOutput.ForeColor = Genie.ColorCode.StringToColor(sColorName);
                                }
                            }
                        }

                        if (ComboBoxIfClosed.Enabled)
                        {
                            string sIfClosed = null;
                            if (!Information.IsNothing(ComboBoxIfClosed.SelectedItem) && Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(ComboBoxIfClosed.SelectedItem, "(default)", false)))
                            {
                                sIfClosed = Conversions.ToString(ComboBoxIfClosed.SelectedItem);
                                if ((sIfClosed ?? "") == "(disabled)")
                                    sIfClosed = "";
                            }

                            fo.IfClosed = sIfClosed;
                        }
                    }
                }
            }
            else // New
            {
                if (TextBoxTitle.Text.Length == 0)
                {
                    Interaction.MsgBox("Title box can not be empty!", MsgBoxStyle.Critical);
                    TextBoxTitle.Focus();
                    return false;
                }

                string sIfClosed = null;
                if (!Information.IsNothing(ComboBoxIfClosed.SelectedItem) && Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(ComboBoxIfClosed.SelectedItem, "(default)", false)))
                {
                    sIfClosed = Conversions.ToString(ComboBoxIfClosed.SelectedItem);
                    if ((sIfClosed ?? "") == "(disabled)")
                        sIfClosed = "";
                }

                var fo = m_FormMain.SafeCreateOutputForm(TextBoxTitle.Text.ToLower(), TextBoxTitle.Text, sIfClosed, 300, 200, 10, 10, true, (Font)TextBoxFont.Tag, TextBoxColor.Text);
                if (!Information.IsNothing(fo))
                {
                    fo.TimeStamp = CheckBoxTimeStamp.Checked;
                    fo.NameListOnly = CheckBoxNameListOnly.Checked;
                    var li = ListViewBase.Items.Add(TextBoxTitle.Text);
                    li.SubItems.Add(GetFontName(fo.RichTextBoxOutput.Font));
                    li.SubItems.Add(Genie.ColorCode.ColorToString(fo.RichTextBoxOutput.ForeColor, fo.RichTextBoxOutput.BackColor));
                    li.SubItems.Add(fo.TimeStamp.ToString());
                    li.SubItems.Add(fo.NameListOnly.ToString());
                    li.Tag = fo;
                    li.Selected = true;
                    ToolStripButtonRemove.Enabled = true;
                    RemoveToolStripMenuItem.Enabled = true;
                    GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                    m_FormMain.UpdateWindowMenuList();
                    fo.Visible = true;
                }
            }

            return true;
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (ApplyChanges() == true)
            {
                m_ItemChanged = false;
            }
        }

        private void ButtonFont_Click(object sender, EventArgs e)
        {
            if (!Information.IsNothing(TextBoxFont.Tag))
            {
                FontDialogPicker.Font = (Font)TextBoxFont.Tag;
            }

            try
            {
                if (FontDialogPicker.ShowDialog(this) == DialogResult.OK)
                {
                    TextBoxFont.Text = GetFontName(FontDialogPicker.Font);
                    TextBoxFont.Tag = FontDialogPicker.Font;
                    m_ItemChanged = true;
                }
            }
#pragma warning disable CS0168
            catch (Exception exp)
#pragma warning restore CS0168
            {
                TextBoxFont.Text = "";
                TextBoxFont.Tag = null;
                Interaction.MsgBox("Invalid font selected. Please select a TrueType font.", MsgBoxStyle.Critical);
            }
        }

        private string GetFontName(Font f)
        {
            return f.Name.ToString() + ", " + Math.Floor(f.Size).ToString();
        }

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            ListViewBase.SelectedItems.Clear();
            UpdateIfClosedBox();
            GroupBoxBase.Enabled = true;
            GroupBoxBase.Tag = null;
            TextBoxTitle.Text = "";
            TextBoxTitle.Enabled = true;
            TextBoxFont.Text = "";
            TextBoxFont.Tag = null;
            CheckBoxTimeStamp.Checked = false;
            CheckBoxNameListOnly.Checked = false;
            TextBoxTitle.Focus();
        }

        private void CheckBoxTimeStamp_CheckedChanged(object sender, EventArgs e)
        {
            m_ItemChanged = true;
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonAdd_Click(sender, e);
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            CheckApplyChanges();
            bool bTryingToRemoveNonUserForm = false;
            foreach (ListViewItem li in ListViewBase.SelectedItems)
            {
                FormSkin fo = (FormSkin)li.Tag;
                if (fo.UserForm == true)
                {
                    fo.Unload();
                    fo = null;
                    li.Remove();
                }
                else
                {
                    bTryingToRemoveNonUserForm = true;
                }
            }

            m_FormMain.RemoveDisposedForms();
            m_FormMain.UpdateWindowMenuList();
            if (bTryingToRemoveNonUserForm == true)
            {
                Interaction.MsgBox("Standard windows may not be removed.", MsgBoxStyle.OkOnly);
            }

            ListViewBase.SelectedItems.Clear();
            ListWasUnselected();
            m_ItemChanged = false;
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripButtonRemove_Click(sender, e);
        }

        private void CheckBoxNameListOnly_CheckedChanged(object sender, EventArgs e)
        {
            m_ItemChanged = true;
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

        private void TextBoxColor_Leave(object sender, EventArgs e)
        {
            UpdateTextBoxColor();
        }

        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {
            if (!Information.IsNothing(m_FormMain))
            {
                OpenFileDialogLayout.InitialDirectory = System.IO.Path.GetDirectoryName(m_FormMain.LoadedLayout);
                OpenFileDialogLayout.FileName = System.IO.Path.GetFileName(m_FormMain.LoadedLayout);
                if (OpenFileDialogLayout.ShowDialog() == DialogResult.OK)
                {
                    if (!Information.IsNothing(m_FormMain))
                    {
                        m_FormMain.LoadLayout(OpenFileDialogLayout.FileName);
                    }
                }
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (!Information.IsNothing(m_FormMain))
            {
                SaveFileDialogLayout.InitialDirectory = System.IO.Path.GetDirectoryName(m_FormMain.LoadedLayout);
                SaveFileDialogLayout.FileName = System.IO.Path.GetFileName(m_FormMain.LoadedLayout);
                if (SaveFileDialogLayout.ShowDialog() == DialogResult.OK)
                {
                    m_FormMain.SaveLayout(SaveFileDialogLayout.FileName);
                }
            }
        }
    }
}