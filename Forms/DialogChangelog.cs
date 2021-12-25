using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GenieClient
{
    public partial class DialogChangelog
    {
        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public DialogChangelog()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            TextBoxInfo.Text = My.MyProject.Application.Info.ProductName + Constants.vbNewLine + string.Format("Version {0}", My.MyProject.Application.Info.Version.ToString()) + Constants.vbNewLine + string.Format("Build Date {0}", Utility.AssemblyBuildDate(Assembly.GetExecutingAssembly())) + Constants.vbNewLine + My.MyProject.Application.Info.Copyright + Constants.vbNewLine + My.MyProject.Application.Info.CompanyName + Constants.vbNewLine + My.MyProject.Application.Info.Description + Constants.vbNewLine;





            var o = Assembly.GetExecutingAssembly().GetManifestResourceStream("GenieClient.Changelog.txt");
            if (!Information.IsNothing(o))
            {
                var s = new StreamReader(o);
                if (!Information.IsNothing(s))
                {
                    TextBoxInfo.AppendText(s.ReadToEnd());
                }
            }

            // For Each sText As String In GetListOfEmbeddedResources()
            // Me.TextBoxInfo.AppendText(sText & vbNewLine)
            // Next
        }

        public Array GetListOfEmbeddedResources()
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }
    }
}