using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class DialogDownload
    {
        public DialogDownload()
        {
            myWebClient = new WebClient();
            InitializeComponent();
        }

        private WebClient _myWebClient;

        private WebClient myWebClient
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _myWebClient;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_myWebClient != null)
                {
                    _myWebClient.DownloadProgressChanged -= UpdateDl;
                    _myWebClient.DownloadFileCompleted -= UpdateDlFinished;
                }

                _myWebClient = value;
                if (_myWebClient != null)
                {
                    _myWebClient.DownloadProgressChanged += UpdateDl;
                    _myWebClient.DownloadFileCompleted += UpdateDlFinished;
                }
            }
        }

        private DateTime myStartTime = new DateTime();
        private bool DownloadCancelled = false;
        private string strUpdateString = string.Empty;

        public object UpdateToString
        {
            get
            {
                return strUpdateString;
            }

            set
            {
                strUpdateString = Conversions.ToString(value);
            }
        }

        public bool MajorUpdate = false;

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            myWebClient.CancelAsync();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void DownloadFile(string URL, string strFileName)
        {
            myWebClient.DownloadFileAsync(new Uri(URL), LocalDirectory.Path + @"\" + strFileName);
            myStartTime = DateTime.Now;
            LabelFile.Text = "Downloading to: " + strFileName;
            LabelFile.Tag = "Downloading to: " + strFileName;
            LabelSpeed.Text = "0 of 0 kb received. (0 kb/s)";
        }

        private void UpdateDl(object sender, DownloadProgressChangedEventArgs e)
        {
            var argbar = ProgressBar1;
            int argpercent = e.ProgressPercentage;
            UpdateProgressBar(argbar, argpercent);
            var arglabel = LabelFile;
            string argtext = " (" + e.ProgressPercentage + "%)";
            UpdateLabelText(arglabel, argtext);
            var arglabel1 = LabelSpeed;
            string argtext1 = Math.Round(e.BytesReceived / (double)1024, 0) + " of " + Math.Round(e.TotalBytesToReceive / (double)1024, 0) + " kb received. (" + CurrentSpeed(Conversions.ToInteger(e.BytesReceived), myStartTime, DateTime.Now) + ")";
            UpdateLabelText(arglabel1, argtext1);
        }

        private bool bRelaunch = false;

        private void UpdateDlFinished(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (DownloadCancelled == true)
            {
                var arglabel = LabelSpeed;
                string argtext = "Aborted.";
                UpdateLabelText(arglabel, argtext);
                var argbar = ProgressBar1;
                int argpercent = 0;
                UpdateProgressBar(argbar, argpercent);
            }
            else
            {
                var arglabel1 = LabelSpeed;
                string argtext1 = "Finished.";
                UpdateLabelText(arglabel1, argtext1);
                OK_Button.Enabled = true;
                ButtonDownload.Enabled = false;
                bRelaunch = true;
            }

            DownloadCancelled = false;
        }

        public string CurrentSpeed(int bytesReceived, DateTime startTime, DateTime endTime)
        {
            var span = endTime - startTime;
            double duration = span.TotalMilliseconds;
            long speed = Conversions.ToLong(Math.Round(bytesReceived / duration, 0));
            return Math.Round(speed * 1000 / (double)1024, 0) + " kb/s";
        }

        // Private strExeName As String = String.Empty

        private void DialogDownload_Load(object sender, EventArgs e)
        {
            ButtonDownload.Tag = true;
            LabelFile.Text = "";
            LabelSpeed.Text = "";
            LabelNewVersion.Text = "An update is available for Genie!" + System.Environment.NewLine + System.Environment.NewLine + "Your Version: " + My.MyProject.Application.Info.Version.ToString() + System.Environment.NewLine + "Update Version: " + strUpdateString + System.Environment.NewLine;



            // strExeName = Application.ExecutablePath.Substring(Application.ExecutablePath.LastIndexOf("\") + 1)
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ButtonDownload.Tag, true, false)))
            {
                ButtonDownload.Tag = false;
                ButtonDownload.Text = "Cancel";
                DownloadFile("http://d23oq4rykk2wza.cloudfront.net/update.exe", "update.exe");
            }
            else
            {
                ButtonDownload.Tag = true;
                DownloadCancelled = true;
                myWebClient.CancelAsync();
                ButtonDownload.Text = "Download";
            }
        }

        public delegate void UpdateLabelTextDelegate(Label label, string text);

        private void UpdateLabelText(Label label, string text)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { label, text };
                Invoke(new UpdateLabelTextDelegate(UpdateLabelTextMethod), parameters);
            }
            else
            {
                UpdateLabelTextMethod(label, text);
            }
        }

        private void UpdateLabelTextMethod(Label label, string text)
        {
            if (Information.IsNothing(label))
            {
                return;
            }

            if (label.IsDisposed == true)
            {
                return;
            }

            label.Text = Conversions.ToString(label.Tag + text);
        }

        public delegate void UpdateProgressBarDelegate(ProgressBar bar, int percent);

        private void UpdateProgressBar(ProgressBar bar, int percent)
        {
            if (InvokeRequired == true)
            {
                var parameters = new object[] { bar, percent };
                Invoke(new UpdateLabelTextDelegate(UpdateLabelTextMethod), parameters);
            }
            else
            {
                UpdateProgressBarMethod(bar, percent);
            }
        }

        private void UpdateProgressBarMethod(ProgressBar bar, int percent)
        {
            if (Information.IsNothing(bar))
            {
                return;
            }

            if (bar.IsDisposed == true)
            {
                return;
            }

            bar.Value = percent;
        }

        private void DialogDownload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MajorUpdate == true)
                {
                    if (!bRelaunch)
                    {
                        Interaction.MsgBox("This is a major update of Genie. You will need to update to play.");
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}