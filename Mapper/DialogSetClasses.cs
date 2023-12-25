using System;
using System.Windows.Forms;
using GenieClient.Genie;

namespace GenieClient
{
    public partial class DialogSetClasses
    {
        public DialogSetClasses()
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

        public string ClassText
        {
            get
            {
                return _TextboxClasses.Text;
            }

            set
            {
                _TextboxClasses.Text = value;
            }
        }

        public void Recolor(Globals.Presets.Preset window, Globals.Presets.Preset textbox, Globals.Presets.Preset button)
        {
            BackColor = window.BgColor;
            ForeColor = window.FgColor;
            _TextboxClasses.ForeColor = textbox.FgColor;
            _TextboxClasses.BackColor = textbox.BgColor;
            OK_Button.ForeColor = button.FgColor;
            OK_Button.BackColor = button.BgColor;
            Cancel_Button.ForeColor = button.FgColor;
            Cancel_Button.BackColor = button.BgColor;
        }
    }
}