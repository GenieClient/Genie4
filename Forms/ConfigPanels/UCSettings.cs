using System;
using System.Drawing;
using Microsoft.VisualBasic;

namespace GenieClient
{
    public partial class UCSettings
    {
        public UCSettings()
        {
            InitializeComponent();
        }

        private Genie.Config m_Config;
        private bool m_ItemChanged = false;

        public Genie.Config Config
        {
            get
            {
                return m_Config;
            }

            set
            {
                m_Config = value;
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
            if (!Information.IsNothing(m_Config))
            {
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
            if (!Information.IsNothing(m_Config))
            {
            }
        }

        private void ToolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshSettings();
        }

        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {
            if (!Information.IsNothing(m_Config))
            {
                m_Config.Load();
                RefreshSettings();
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        public bool SaveToFile()
        {
            ApplyChanges();
            if (!Information.IsNothing(m_Config))
            {
                m_Config.Save();
            }

            return default;
        }
    }
}