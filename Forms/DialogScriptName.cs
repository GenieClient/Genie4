using System;
using System.Windows.Forms;

namespace GenieClient
{
    public partial class DialogScriptName
    {
        public DialogScriptName()
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

        public string ScriptName
        {
            get
            {
                if (TextBoxName.Text.ToLower().EndsWith(".cmd") | TextBoxName.Text.ToLower().EndsWith(".inc"))
                {
                    return TextBoxName.Text;
                }
                else
                {
                    return TextBoxName.Text + ".cmd";
                }
            }

            set
            {
                TextBoxName.Text = value;
            }
        }
    }
}