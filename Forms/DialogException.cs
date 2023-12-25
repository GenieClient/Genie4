using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class DialogException
    {
        public DialogException()
        {
            InitializeComponent();
        }

        const string _whathappened = "There was an unexpected error in Genie. This may be due to a programming bug.";
        public void Show(IWin32Window owner, string details, string whathappened = null, string howaffected = null, string usercando = null)
        {
            const string _howaffected = "Restart Genie, and try repeating your last action. Try alternative methods of performing the same action.";
            const string _usercando = "The action you requested was not performed.";
            ErrorBox.Clear();
            ErrorBox.AppendText(Conversions.ToString(Interaction.IIf(Information.IsNothing(whathappened), _whathappened, whathappened)));
            ScopeBox.Clear();
            ScopeBox.AppendText(Conversions.ToString(Interaction.IIf(Information.IsNothing(howaffected), _howaffected, howaffected)));
            ActionBox.Clear();
            ActionBox.AppendText(Conversions.ToString(Interaction.IIf(Information.IsNothing(usercando), _usercando, usercando)));
            txtMore.Clear();
            txtMore.AppendText(SysInfoToString());
            if (!Information.IsNothing(details))
            {
                txtMore.AppendText(details);
                LogToSystemEventLog(details);
            }
            Show(owner);
        }

        private void LogToSystemEventLog(string details)
        {
            EventLog eventLog = new EventLog();
            //The source was not found, but some or all event logs could not be searched
            eventLog.Source = ".NET Runtime";
            string message = _whathappened + "\r\n\r\n----------------------------\r\n\r\n" + details;
            eventLog.WriteEntry(message, EventLogEntryType.Error, 1000);
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtMore.Text.ToString());
        }

        internal static string SysInfoToString()
        {
            var objStringBuilder = new System.Text.StringBuilder();
            objStringBuilder.Append("Date and Time:         ");
            objStringBuilder.Append(DateTime.Now);
            objStringBuilder.Append(Environment.NewLine);
            objStringBuilder.Append("Machine Name:          ");
            try
            {
                objStringBuilder.Append(Environment.MachineName);
            }
            catch (Exception e)
            {
                objStringBuilder.Append(e.Message);
            }

            objStringBuilder.Append(Environment.NewLine);
            objStringBuilder.Append("Operating System:      ");
            try
            {
                // System.Environment.OSVersion.VersionString
                objStringBuilder.Append(My.MyProject.Computer.Info.OSFullName.Trim());
                if (IntPtr.Size == 8)
                {
                    objStringBuilder.Append(" x64");
                }
                else if (IntPtr.Size == 4)
                {
                    objStringBuilder.Append(" x86");
                }
            }
            catch (Exception e)
            {
                objStringBuilder.Append(e.Message);
            }

            objStringBuilder.Append(Environment.NewLine);
            objStringBuilder.Append("Environment Version:   ");
            try
            {
                objStringBuilder.Append(Environment.Version.ToString());
            }
            catch (Exception e)
            {
                objStringBuilder.Append(e.Message);
            }

            objStringBuilder.Append(Environment.NewLine);
            objStringBuilder.Append("Genie Version:         ");
            try
            {
                objStringBuilder.Append(My.MyProject.Application.Info.Version.ToString());
            }
            catch (Exception e)
            {
                objStringBuilder.Append(e.Message);
            }

            objStringBuilder.Append(Environment.NewLine);
            objStringBuilder.Append("Genie Build Date:      ");
            try
            {
                objStringBuilder.Append(Utility.AssemblyBuildDate(System.Reflection.Assembly.GetExecutingAssembly()));
            }
            catch (Exception e)
            {
                objStringBuilder.Append(e.Message);
            }

            objStringBuilder.Append(Environment.NewLine);
            objStringBuilder.Append(Environment.NewLine);
            return objStringBuilder.ToString();
        }
    }
}