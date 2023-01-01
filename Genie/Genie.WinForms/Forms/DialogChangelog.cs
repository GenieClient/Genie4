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
            TextBoxInfo.Text = My.MyProject.Application.Info.ProductName + System.Environment.NewLine + string.Format("Version {0}", My.MyProject.Application.Info.Version.ToString()) + System.Environment.NewLine + string.Format("Build Date {0}", Utility.AssemblyBuildDate(Assembly.GetExecutingAssembly())) + System.Environment.NewLine + My.MyProject.Application.Info.Copyright + System.Environment.NewLine + My.MyProject.Application.Info.CompanyName + System.Environment.NewLine + My.MyProject.Application.Info.Description + System.Environment.NewLine;





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