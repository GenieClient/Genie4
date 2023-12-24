using System;
using System.Windows.Forms;
using GenieClient.Genie;

namespace GenieClient
{
    public partial class DialogDragTarget
    {
        public DialogDragTarget()
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

        public string TargetText
        {
            get
            {
                return TextBoxTarget.Text;
            }

            set
            {
                TextBoxTarget.Text = value;
            }
        }

        public void Recolor(Globals.Presets.Preset window, Globals.Presets.Preset textbox, Globals.Presets.Preset button)
        {
            BackColor = window.BgColor;
            ForeColor = window.FgColor;
            _TextBoxTarget.ForeColor = textbox.FgColor;
            _TextBoxTarget.BackColor = textbox.BgColor;
            OK_Button.ForeColor = button.FgColor;
            OK_Button.BackColor = button.BgColor;
            Cancel_Button.ForeColor = button.FgColor;
            Cancel_Button.BackColor = button.BgColor;
        }
    }

}