using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class ComponentIconBar
    {
        public ComponentIconBar()
        {
            InitializeComponent();
        }

        private Genie.Globals m_Globals = null;
        private object m_Lock = new object();

        public Genie.Globals Globals
        {
            get
            {
                return m_Globals;
            }

            set
            {
                m_Globals = value;
            }
        }

        private bool m_IsConnected = false;

        public bool IsConnected
        {
            get
            {
                return m_IsConnected;
            }

            set
            {
                m_IsConnected = value;
                UpdateStatusIcons();
                PictureBoxCompass.Invalidate();
            }
        }

        private void UpdateStatusIcons()
        {
            var argpb = PictureBoxStatus;
            UpdateImage(argpb);
            var argpb1 = PictureBoxStunned;
            UpdateImage(argpb1);
            var argpb2 = PictureBoxBleeding;
            UpdateImage(argpb2);
            var argpb3 = PictureBoxInvisible;
            UpdateImage(argpb3);
            var argpb4 = PictureBoxHidden;
            UpdateImage(argpb4);
            var argpb5 = PictureBoxJoined;
            UpdateImage(argpb5);
            var argpb6 = PictureBoxWebbed;
            UpdateImage(argpb6);
        }

        private void UpdateImage(PictureBox pb)
        {
            if (m_IsConnected == true)
            {
                if (!Information.IsNothing(pb.Tag) && pb.Tag.ToString().EndsWith("_gray") == true)
                {
                    ShowImage(pb, pb.Tag.ToString().Substring(0, pb.Tag.ToString().Length - 5));
                }
            }
            else if (!Information.IsNothing(pb.Tag) && pb.Tag.ToString().EndsWith("_gray") == false)
            {
                ShowImage(pb, pb.Tag.ToString() + "_gray");
            }
        }

        private void ComponentIconBar_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(LocalDirectory.Path + @"\Icons\"))
            {
                var oFiles = new DirectoryInfo(LocalDirectory.Path + @"\Icons\").GetFiles("*.png");
                foreach (FileInfo fi in oFiles)
                    AddImage(fi.Name);
                var argp = PictureBoxCompass;
                ShowImage(argp, "compass.png");
            }
            else
            {
                /* TODO ERROR: Skipped IfDirectiveTrivia */
                Interaction.MsgBox("Missing icon files in Genie folder.");
                /* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }
        }

        private void AddImage(string sName)
        {
            string sPathName = LocalDirectory.Path + @"\Icons\" + sName;
            if (File.Exists(sPathName))
            {
                ImageListIcons.Images.Add(sName, Image.FromFile(sPathName));
                Bitmap argb = (Bitmap)Image.FromFile(sPathName);
                ImageListIcons.Images.Add(sName + "_gray", ImageToGrayScale(argb));
            }
        }

        private Bitmap ImageToGrayScale(Bitmap b)
        {
            // int iColor = 0;
            var oOutput = new Bitmap(b.Width, b.Height);
            for (int X = 0, loopTo = b.Width - 1; X <= loopTo; X++)
            {
                for (int Y = 0, loopTo1 = b.Height - 1; Y <= loopTo1; Y++)
                    oOutput.SetPixel(X, Y, Genie.ColorCode.ColorToGrayscale(b.GetPixel(X, Y)));
            }

            return oOutput;
        }

        private void AppendImage(Graphics g, string sName)
        {
            if (m_IsConnected == false)
            {
                sName += "_gray";
            }

            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (!Information.IsNothing(ImageListIcons.Images[sName]))
                    {
                        Bitmap b = (Bitmap)ImageListIcons.Images[sName];
                        b.MakeTransparent(Color.Black);
                        g.DrawImage(b, 0, 0);
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        private void ShowImage(PictureBox p, string sName)
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (m_IsConnected == false)
                    {
                        if (sName.EndsWith("_gray") == false)
                        {
                            sName += "_gray";
                        }
                    }

                    SetImage(p, sName);
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        // Threadsafe
        private void SetImage(PictureBox p, string sName)
        {
            if (p.InvokeRequired == true)
            {
                var parameters = new object[] { p, sName };
                Invoke(new InvokeSetImageDelegate(InvokeSetImage), parameters);
            }
            else
            {
                InvokeSetImage(p, sName);
            }
        }

        public delegate void InvokeSetImageDelegate(PictureBox p, string sName);

        private void InvokeSetImage(PictureBox p, string sName)
        {
            if (Monitor.TryEnter(ImageListIcons))
            {
                try
                {
                    if (!Information.IsNothing(ImageListIcons.Images[sName]))
                    {
                        p.Image = ImageListIcons.Images[sName];
                        p.Tag = sName;
                    }
                }
                finally
                {
                    Monitor.Exit(ImageListIcons);
                }
            }
        }

        public void UpdateStatusBox()
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["dead"], 1, false)))
                    {
                        var argp = PictureBoxStatus;
                        ShowImage(argp, "dead.png");
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["standing"], 1, false)))
                    {
                        var argp1 = PictureBoxStatus;
                        ShowImage(argp1, "standing.png");
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["kneeling"], 1, false)))
                    {
                        var argp4 = PictureBoxStatus;
                        ShowImage(argp4, "kneeling.png");
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["sitting"], 1, false)))
                    {
                        var argp3 = PictureBoxStatus;
                        ShowImage(argp3, "sitting.png");
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["prone"], 1, false)))
                    {
                        var argp2 = PictureBoxStatus;
                        ShowImage(argp2, "prone.png");
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        public void UpdateStunned()
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["stunned"], 1, false)))
                    {
                        var argp = PictureBoxStunned;
                        ShowImage(argp, "stunned.png");
                    }
                    else
                    {
                        PictureBoxStunned.Image = null;
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        public void UpdateBleeding()
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["bleeding"], 1, false)))
                    {
                        var argp = PictureBoxBleeding;
                        ShowImage(argp, "bleeding.png");
                    }
                    else
                    {
                        PictureBoxBleeding.Image = null;
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        public void UpdateInvisible()
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["invisible"], 1, false)))
                    {
                        var argp = PictureBoxInvisible;
                        ShowImage(argp, "invisible.png");
                    }
                    else
                    {
                        PictureBoxInvisible.Image = null;
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        public void UpdateHidden()
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["hidden"], 1, false)))
                    {
                        var argp = PictureBoxHidden;
                        ShowImage(argp, "hidden.png");
                    }
                    else
                    {
                        PictureBoxHidden.Image = null;
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        public void UpdateJoined()
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["joined"], 1, false)))
                    {
                        var argp = PictureBoxJoined;
                        ShowImage(argp, "joined.png");
                    }
                    else
                    {
                        PictureBoxJoined.Image = null;
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        public void UpdateWebbed()
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["webbed"], 1, false)))
                    {
                        var argp = PictureBoxWebbed;
                        ShowImage(argp, "webbed.png");
                    }
                    else
                    {
                        PictureBoxWebbed.Image = null;
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }

        private void PictureBoxCompass_Paint(object sender, PaintEventArgs e)
        {
            if (Monitor.TryEnter(m_Lock))
            {
                try
                {
                    if (!Information.IsNothing(m_Globals))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["north"], 1, false)))
                        {
                            var argg = e.Graphics;
                            string argsName = "compass_north.png";
                            AppendImage(argg, argsName);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["northeast"], 1, false)))
                        {
                            var argg1 = e.Graphics;
                            string argsName1 = "compass_northeast.png";
                            AppendImage(argg1, argsName1);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["east"], 1, false)))
                        {
                            var argg2 = e.Graphics;
                            string argsName2 = "compass_east.png";
                            AppendImage(argg2, argsName2);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["southeast"], 1, false)))
                        {
                            var argg3 = e.Graphics;
                            string argsName3 = "compass_southeast.png";
                            AppendImage(argg3, argsName3);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["south"], 1, false)))
                        {
                            var argg4 = e.Graphics;
                            string argsName4 = "compass_south.png";
                            AppendImage(argg4, argsName4);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["southwest"], 1, false)))
                        {
                            var argg5 = e.Graphics;
                            string argsName5 = "compass_southwest.png";
                            AppendImage(argg5, argsName5);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["west"], 1, false)))
                        {
                            var argg6 = e.Graphics;
                            string argsName6 = "compass_west.png";
                            AppendImage(argg6, argsName6);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["northwest"], 1, false)))
                        {
                            var argg7 = e.Graphics;
                            string argsName7 = "compass_northwest.png";
                            AppendImage(argg7, argsName7);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["up"], 1, false)))
                        {
                            var argg8 = e.Graphics;
                            string argsName8 = "compass_up.png";
                            AppendImage(argg8, argsName8);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["down"], 1, false)))
                        {
                            var argg9 = e.Graphics;
                            string argsName9 = "compass_down.png";
                            AppendImage(argg9, argsName9);
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(m_Globals.VariableList["out"], 1, false)))
                        {
                            var argg10 = e.Graphics;
                            string argsName10 = "compass_out.png";
                            AppendImage(argg10, argsName10);
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(m_Lock);
                }
            }
        }
    }
}