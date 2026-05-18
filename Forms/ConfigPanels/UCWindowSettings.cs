using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
                TextBoxMonoFont.Text = GetFontName(m_FormMain.m_oGlobals.Config.MonoFont);
                TextBoxMonoFont.Tag = m_FormMain.m_oGlobals.Config.MonoFont;
                TextBoxInputFont.Text = GetFontName(m_FormMain.m_oGlobals.Config.InputFont);
                TextBoxInputFont.Tag = m_FormMain.m_oGlobals.Config.InputFont;
            }
        }

        private void ButtonMonoFont_Click(object sender, EventArgs e)
        {
            var picked = FontHelper.PickFont(this, TextBoxMonoFont.Tag as Font);
            if (picked != null && !picked.Equals(TextBoxMonoFont.Tag as Font))
            {
                TextBoxMonoFont.Text = GetFontName(picked);
                TextBoxMonoFont.Tag = picked;
                m_ItemChanged = true;
            }
        }

        private void ButtonInputFont_Click(object sender, EventArgs e)
        {
            var picked = FontHelper.PickFont(this, TextBoxInputFont.Tag as Font);
            if (picked != null && !picked.Equals(TextBoxInputFont.Tag as Font))
            {
                TextBoxInputFont.Text = GetFontName(picked);
                TextBoxInputFont.Tag = picked;
                m_ItemChanged = true;
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
                    m_FormMain.m_oGlobals.Config.MonoFont = (Font)TextBoxMonoFont.Tag;
                }

                if (!Information.IsNothing(TextBoxInputFont.Tag))
                {
                    m_FormMain.m_oGlobals.Config.InputFont = (Font)TextBoxInputFont.Tag;
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