using System;
using System.Windows.Forms;

namespace GenieClient
{
    public partial class DialogProfileNote
    {
        public DialogProfileNote()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string NoteText
        {
            get
            {
                return TextBoxNote.Text;
            }

            set
            {
                TextBoxNote.Text = value;
            }
        }
    }
}