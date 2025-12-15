using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using GenieClient.Services;

namespace GenieClient
{
    public partial class UCWindowSettings
    {
        public UCWindowSettings()
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

        public void RefreshSettings()
        {
            if (!Information.IsNothing(m_FormMain))
            {
                // Convert GenieFont to Font for UI display and storage in Tag
                var monoFont = m_FormMain.m_oGlobals.Config.MonoFont.ToDrawingFont();
                var inputFont = m_FormMain.m_oGlobals.Config.InputFont.ToDrawingFont();
                TextBoxMonoFont.Text = GetFontName(monoFont);
                TextBoxMonoFont.Tag = monoFont;
                TextBoxInputFont.Text = GetFontName(inputFont);
                TextBoxInputFont.Tag = inputFont;
            }
        }

        private void ButtonMonoFont_Click(object sender, EventArgs e)
        {
            if (!Information.IsNothing(TextBoxMonoFont.Tag))
            {
                FontDialogPicker.Font = (Font)TextBoxMonoFont.Tag;
            }

            try
            {
                if (FontDialogPicker.ShowDialog(this) == DialogResult.OK)
                {
                    TextBoxMonoFont.Text = GetFontName(FontDialogPicker.Font);
                    TextBoxMonoFont.Tag = FontDialogPicker.Font;
                    m_ItemChanged = true;
                }
            }
#pragma warning disable CS0168
            catch (Exception exp)
#pragma warning restore CS0168
            {
                TextBoxMonoFont.Text = "";
                TextBoxMonoFont.Tag = null;
                Interaction.MsgBox("Invalid font selected. Please select a TrueType font.", MsgBoxStyle.Critical);
            }
        }

        private void ButtonInputFont_Click(object sender, EventArgs e)
        {
            if (!Information.IsNothing(TextBoxInputFont.Tag))
            {
                FontDialogPicker.Font = (Font)TextBoxInputFont.Tag;
            }

            try
            {
                if (FontDialogPicker.ShowDialog(this) == DialogResult.OK)
                {
                    TextBoxInputFont.Text = GetFontName(FontDialogPicker.Font);
                    TextBoxInputFont.Tag = FontDialogPicker.Font;
                    m_ItemChanged = true;
                }
            }
#pragma warning disable CS0168
            catch (Exception exp)
#pragma warning restore CS0168
            {
                TextBoxInputFont.Text = "";
                TextBoxInputFont.Tag = null;
                Interaction.MsgBox("Invalid font selected. Please select a TrueType font.", MsgBoxStyle.Critical);
            }
        }

        private string GetFontName(Font f)
        {
            return f.Name.ToString() + ", " + f.Size.ToString();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        private void ApplyChanges()
        {
            if (!Information.IsNothing(m_FormMain))
            {
                if (!Information.IsNothing(TextBoxMonoFont.Tag))
                {
                    // Convert Font to GenieFont for storage in config
                    m_FormMain.m_oGlobals.Config.MonoFont = ((Font)TextBoxMonoFont.Tag).ToGenieFont();
                }

                if (!Information.IsNothing(TextBoxInputFont.Tag))
                {
                    // Convert Font to GenieFont for storage in config
                    m_FormMain.m_oGlobals.Config.InputFont = ((Font)TextBoxInputFont.Tag).ToGenieFont();
                }
            }
        }

        private void ToolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshSettings();
        }

        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {
            if (!Information.IsNothing(m_FormMain))
            {
                m_FormMain.LoadLayout();
                RefreshSettings();
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        public bool SaveToFile()
        {
            if (!Information.IsNothing(m_FormMain))
            {
                ApplyChanges();
                m_FormMain.SaveLayout();
            }

            return default;
        }
    }
}