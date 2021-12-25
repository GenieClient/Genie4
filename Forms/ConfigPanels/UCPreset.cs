using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class UCPreset
    {
        public UCPreset()
        {
            InitializeComponent();
        }

        private Genie.Globals.Presets m_PresetList;
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

        public Genie.Globals.Presets PresetList
        {
            get
            {
                return m_PresetList;
            }

            set
            {
                m_PresetList = value;
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
            if (!Information.IsNothing(m_PresetList))
            {
                ResetList();
                foreach (DictionaryEntry de in m_PresetList)
                {
                    var li = ListViewBase.Items.Add(de.Key.ToString());
                    li.Tag = de.Key.ToString();
                    Genie.Globals.Presets.Preset oPreset = (Genie.Globals.Presets.Preset)de.Value;
                    li.SubItems.Add(oPreset.sColorName);
                    li.ForeColor = oPreset.FgColor;
                    // MsgBox(li.BackColor.ToString)
                    if (oPreset.BgColor != Color.Transparent)
                    {
                        li.BackColor = oPreset.BgColor;
                    }
                }
            }
        }

        private void ResetList()
        {
            ListViewBase.Clear();
            ListViewBase.Columns.Add("Preset", 200, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Color", 400, HorizontalAlignment.Left);
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
                    if (!(TextBoxPreset.Text.Length == 0 & TextBoxColor.Text.Length == 0)) // If we add a new one and just click away - Ignore it
                    {
                        if (Interaction.MsgBox("Current item has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                        {
                            ApplyChanges();
                        }
                    }
                }
            }
        }

        private void UpdateGroupBox()
        {
            CheckApplyChanges();
            if (ListViewBase.SelectedItems.Count == 1)
            {
                TextBoxPreset.Enabled = true;
                TextBoxPreset.Text = ListViewBase.SelectedItems[0].Text;
                TextBoxColor.Enabled = true;
                TextBoxColor.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                TextBoxColor.Tag = ListViewBase.SelectedItems[0].SubItems[1].Text;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
                LabelExampleColor.ForeColor = ListViewBase.SelectedItems[0].ForeColor;
                LabelExampleColor.BackColor = ListViewBase.SelectedItems[0].BackColor;
            }
            else if (ListViewBase.SelectedItems.Count > 1) // Can only edit properties that are same for all
            {
                TextBoxPreset.Enabled = false;
                TextBoxPreset.Text = "";
                TextBoxColor.Enabled = true;
                GroupBoxBase.Enabled = true;
                GroupBoxBase.Tag = new ArrayList(ListViewBase.SelectedItems);
            }
            else
            {
                ListWasUnselected();
            }

            m_ItemChanged = false; // Since textchanged event will fire when we change text
        }

        private void ListWasUnselected()
        {
            TextBoxPreset.Text = "";
            TextBoxColor.Text = "";
            LabelExampleColor.ForeColor = Color.Black;
            LabelExampleColor.BackColor = Color.Black;
            GroupBoxBase.Enabled = false;
            GroupBoxBase.Tag = null;
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
            if (Information.IsNothing(m_PresetList))
            {
                return false;
            }

            if (TextBoxPreset.Enabled == true & TextBoxPreset.Text.Length == 0)
            {
                Interaction.MsgBox("Preset box can not be empty!", MsgBoxStyle.Critical);
                TextBoxPreset.Focus();
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
                    if (TextBoxPreset.Enabled == true) // Single edit
                    {
                        li.Text = TextBoxPreset.Text;
                    }
                    // m_PresetList.Remove(li.Tag) ' Remove old
                    else
                    {
                    } // Multi edit

                    if (TextBoxColor.Enabled == true)
                    {
                        li.SubItems[1].Text = TextBoxColor.Text;
                        li.ForeColor = LabelExampleColor.ForeColor;
                        li.BackColor = LabelExampleColor.BackColor;
                    }

                    string argsKey = li.Text;
                    string argsColorName = TextBoxColor.Text;
                    m_PresetList.Add(argsKey, argsColorName);
                    m_FormMain.SafePresetChanged(li.Text.ToLower());
                    li.Tag = li.Text;
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

        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_PresetList))
            {
                return;
            }

            m_PresetList.Clear();
            bool bResult = m_PresetList.Load();
            string argsPreset = "all";
            m_FormMain.SafePresetChanged(argsPreset);
            PopulateList();
            UpdateGroupBox();
            if (bResult == false)
            {
                Interaction.MsgBox("Load Failed!", MsgBoxStyle.Critical);
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(m_PresetList))
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
            return m_PresetList.Save();
        }
    }
}