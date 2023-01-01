using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GenieClient
{
    public partial class DialogReconnect
    {
        public DialogReconnect()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void AddAttempt(string text)
        {
            TextBoxLog.AppendText(DateTime.Now.ToString() + ": " + text + System.Environment.NewLine);
        }
    }
}