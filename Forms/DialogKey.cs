using System;
using System.Windows.Forms;

namespace GenieClient
{
    public partial class DialogKey
    {
        public DialogKey()
        {
            InitializeComponent();
        }

        public string GenieKey = string.Empty;

        private void OK_Button_Click(object sender, EventArgs e)
        {
            GenieKey = TextBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DialogKey_Load(object sender, EventArgs e)
        {
            TextBox1.Text = GenieKey;
        }
    }
}