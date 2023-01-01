using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GenieClient
{
    public partial class DialogProfileConnect
    {
        public DialogProfileConnect()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            OK_Close();
        }

        private void OK_Close()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Cancel_Close();
        }

        private void Cancel_Close()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string ProfileName
        {
            get
            {
                if (!Information.IsNothing(ListBoxProfiles.SelectedItem))
                {
                    return ListBoxProfiles.SelectedItem.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private void ListBoxProfiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OK_Close();
        }

        private string m_sConfigDir = string.Empty;

        public string ConfigDir
        {
            get
            {
                return m_sConfigDir;
            }

            set
            {
                m_sConfigDir = value;
            }
        }

        private void DialogProfileConnect_VisibleChanged(object sender, EventArgs e)
        {
            string sFile = string.Empty;
            if (Visible == true)
            {
                ListBoxProfiles.Items.Clear();
                sFile = FileSystem.Dir(m_sConfigDir + @"\Profiles\*.xml");
                while (!string.IsNullOrEmpty(sFile))
                {
                    ListBoxProfiles.Items.Add(sFile.Substring(0, sFile.Length - 4));
                    sFile = FileSystem.Dir();
                }
            }
        }

        private void ListBoxProfiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OK_Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Cancel_Close();
            }
        }
    }
}