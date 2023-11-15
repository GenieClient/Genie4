using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using GenieClient.Genie;
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
        public bool ClassicConnect { get; set; }
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
                _profiles.Visible = !ClassicConnect;
                string[] profiles = Directory.GetFiles(m_sConfigDir + @"\Profiles\", "*.xml");
                ListBoxProfiles.Items.Clear();
                _profiles.Nodes.Clear();
                foreach (string profile in profiles)
                {
                    string fileContents = "";
                    using (StreamReader reader = new StreamReader(profile))
                    {
                        fileContents = reader.ReadToEnd();
                    }
                    if (fileContents.Length > 0)
                    {
                        Genie.XMLConfig xml = new Genie.XMLConfig();
                        xml.LoadXml(fileContents);
                        string game = xml.GetValue("Genie/Profile", "Game", "");
                        string account = xml.GetValue("Genie/Profile", "Account", "");
                        if (string.IsNullOrWhiteSpace(account)) account = "ACCOUNT_UNKNOWN";
                        string note = xml.GetValue("Genie/Profile", "Note", "");
                        if (!_profiles.Nodes.ContainsKey(game)) _profiles.Nodes.Add(game, game);
                        if (!_profiles.Nodes[game].Nodes.ContainsKey(account)) _profiles.Nodes[game].Nodes.Add(account, account);
                        string profileName = Path.GetFileNameWithoutExtension(profile);
                        string profileText = profileName;
                        if (!string.IsNullOrWhiteSpace(note)) profileText += $" - {note}";
                        TreeNode profileNode = new TreeNode();
                        profileNode.Name = profileName;
                        profileNode.Text = profileText;
                        profileNode.Tag = profile;
                        _profiles.Nodes[game].Nodes[account].Nodes.Add(profileNode);
                        ListBoxProfiles.Items.Add(profileName);
                    }
                }
                _profiles.ExpandAll();
                if(_profiles.Nodes.Count > 0) _profiles.Nodes[0].EnsureVisible(); //this will scroll the window to the top of the list

            }



        }
        private string GetValue(string element, string profileContents)
        {
            int start = profileContents.IndexOf(element + "=");
            string returnValue = string.Empty;
            if(start > 0)
            {
                start += element.Length + 2;
                int end = profileContents.IndexOf('"', start);
                returnValue = profileContents.Substring(start, end - start);
            }
            if (string.IsNullOrEmpty(returnValue)) returnValue = $"{element} Missing";
            return returnValue;
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

        private void ToggleView_Click(object sender, EventArgs e)
        {
            _profiles.Visible = !_profiles.Visible;
        }

        private void _profiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                ListBoxProfiles.SelectedItem = e.Node.Name;
            }
        }

        private void _profiles_KeyDown(object sender, KeyEventArgs e)
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

        private void _profiles_DoubleClick(object sender, EventArgs e)
        {
            OK_Close();
        }

        private void EditNote_Click(object sender, EventArgs e)
        {

            if (_profiles.SelectedNode.Level == 2)
            {
                int noteStart = _profiles.SelectedNode.Text.IndexOf(" - ");
                string noteText = "";
                if (noteStart > 0) noteText = _profiles.SelectedNode.Text.Substring(noteStart + 3).Trim();
                My.MyProject.Forms.DialogProfileNote.NoteText = noteText;
                if (My.MyProject.Forms.DialogProfileNote.ShowDialog(Parent) == DialogResult.OK)
                {
                    string note = My.MyProject.Forms.DialogProfileNote.NoteText;
                    string profileText = _profiles.SelectedNode.Name;
                    if (!string.IsNullOrWhiteSpace(note)) profileText += $" - {note}";
                    _profiles.SelectedNode.Text = profileText;
                    Genie.XMLConfig xml = new XMLConfig();
                    xml.LoadFile(_profiles.SelectedNode.Tag.ToString());
                    xml.SetValue("Genie/Profile", "Note", note);
                    xml.SaveToFile(_profiles.SelectedNode.Tag.ToString());
                }
            }
        }
    }
}