using System;
using System.Windows.Forms;
using GenieClient.Genie;
using Microsoft.VisualBasic;

namespace GenieClient
{
    public partial class DialogConnect
    {
        public DialogConnect()
        {
            InitializeComponent();
        }

        public string AccountName
        {
            get
            {
                return TextBoxAccount.Text;
            }

            set
            {
                TextBoxAccount.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return TextBoxPassword.Text;
            }

            set
            {
                TextBoxPassword.Text = value;
            }
        }

        public string Character
        {
            get
            {
                return TextBoxCharacter.Text;
            }

            set
            {
                TextBoxCharacter.Text = value;
            }
        }

        public string Game
        {
            get
            {
                return ComboBoxGame.Text;
            }

            set
            {
                ComboBoxGame.Text = value;
            }
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (TextBoxAccount.Text.Trim().Length == 0)
            {
                Interaction.MsgBox("You need to enter an account name to connect!", MsgBoxStyle.Exclamation);
                TextBoxAccount.Focus();
                return;
            }

            if (TextBoxPassword.Text.Trim().Length == 0)
            {
                Interaction.MsgBox("You need to enter a password to connect!", MsgBoxStyle.Exclamation);
                TextBoxPassword.Focus();
                return;
            }

            if (ComboBoxGame.Text.Trim().Length == 0)
            {
                Interaction.MsgBox("You need the game name to connect!", MsgBoxStyle.Exclamation);
                ComboBoxGame.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DialogConnect_Load(object sender, EventArgs e)
        {
            CheckBoxSavePassword.Checked = false;
        }

        private void DialogConnect_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                if (TextBoxAccount.Text.Length == 0)
                {
                    TextBoxAccount.Select();
                }
                else if (TextBoxPassword.Text.Length == 0)
                {
                    TextBoxPassword.Select();
                }
                else if (TextBoxCharacter.Text.Length == 0)
                {
                    TextBoxCharacter.Select();
                }
                else if (ComboBoxGame.Text.Length == 0)
                {
                    ComboBoxGame.Select();
                }
            }
        }

        private void CheckBoxSavePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxSavePassword.Checked == true)
            {
                Interaction.MsgBox("Using this option will save your password so that anyone with access to your computer and/or files may connect to your character.", MsgBoxStyle.Exclamation, "CAUTION!");
            }
        }
    }
}