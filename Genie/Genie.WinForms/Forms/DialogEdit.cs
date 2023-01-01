using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class DialogEdit
    {
        public DialogEdit()
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

        public string EditText
        {
            get
            {
                return RichTextBoxEdit.Text.Trim().Replace(Constants.vbLf, Conversions.ToString(';')).Replace(Constants.vbCr, "");
            }

            set
            {
                RichTextBoxEdit.Text = FixLines(value) + Constants.vbLf;
            }
        }

        private string FixLines(string text)
        {
            var sb = new StringBuilder();
            int depth = 0;
            foreach (char c in text.ToCharArray())
            {
                var switchExpr = c;
                switch (switchExpr)
                {
                    case '{':
                        {
                            depth += 1;
                            break;
                        }

                    case '}':
                        {
                            depth -= 1;
                            break;
                        }

                    case ';':
                        {
                            if (depth == 0)
                            {
                                switchExpr = Conversions.ToChar(Constants.vbLf);
                            }

                            break;
                        }
                }

                sb.Append(switchExpr);
            }

            return sb.ToString();
        }
    }
}