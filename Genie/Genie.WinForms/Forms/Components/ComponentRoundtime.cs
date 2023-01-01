using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GenieClient
{
    public partial class ComponentRoundtime
    {
        public ComponentRoundtime()
        {
            InitializeComponent();
        }

        private int RT = 0;
        private int StartRT = 0;
        private Color m_BackgroundColor = Color.Black;
        private Color m_ForegroundColor = Color.Gray;
        private Pen m_BorderColor = Pens.Gray;
        private Pen m_BorderColorGrayScale = Pens.Gray;
        private Color m_BackgroundColorRT = Color.Black;
        private Pen m_BorderColorRT = Pens.Gray;
        private Pen m_BorderColorRTGrayScale = Pens.Gray;
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
                Invalidate();
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return m_BackgroundColor;
            }

            set
            {
                m_BackgroundColor = value;
                Invalidate();
            }
        }

        public Color BackgroundColorRT
        {
            get
            {
                return m_BackgroundColorRT;
            }

            set
            {
                m_BackgroundColorRT = value;
                Invalidate();
            }
        }

        public Color ForegroundColor
        {
            get
            {
                return m_ForegroundColor;
            }

            set
            {
                m_ForegroundColor = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return m_BorderColor.Color;
            }

            set
            {
                m_BorderColor = new Pen(value);
                m_BorderColorGrayScale = new Pen(Genie.ColorCode.ColorToGrayscale(value));
                Invalidate();
            }
        }

        public Color BorderColorRT
        {
            get
            {
                return m_BorderColorRT.Color;
            }

            set
            {
                m_BorderColorRT = new Pen(value);
                m_BorderColorRTGrayScale = new Pen(Genie.ColorCode.ColorToGrayscale(value));
                Invalidate();
            }
        }

        // Private myImage As Image = Image.FromFile("RT.bmp")
        private void PanelRT_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            int w;
            g = e.Graphics;
            // Dim myTextureBrush As New TextureBrush(myImage)

            if (RT > 0 & StartRT > 0)
            {
                var myTextureBrush = new SolidBrush((Color)Interaction.IIf(m_IsConnected, m_ForegroundColor, Genie.ColorCode.ColorToGrayscale(m_ForegroundColor)));
                w = (int)(PanelRT.Width / (double)StartRT * RT);
                g.FillRectangle(myTextureBrush, 0, 0, w, PanelRT.Height);
                Pen argp = (Pen)Interaction.IIf(m_IsConnected, m_BorderColorRT, m_BorderColorRTGrayScale);
                DrawBorder(e.Graphics, argp);
            }
            else
            {
                Pen argp1 = (Pen)Interaction.IIf(m_IsConnected, m_BorderColor, m_BorderColorGrayScale);
                DrawBorder(e.Graphics, argp1);
            }
        }

        public int CurrentRT
        {
            get
            {
                return RT;
            }
        }

        public void SetRT(int RoundTime)
        {
            PanelRT.BackColor = (Color)Interaction.IIf(m_IsConnected, m_BackgroundColorRT, Genie.ColorCode.ColorToGrayscale(m_BackgroundColorRT));
            RT = RoundTime;
            StartRT = RoundTime;
            LabelRT.Text = RT > 0 ? RT.ToString() : "";
            Invalidate();
            TimerRT.Stop();
            TimerRT.Start();
        }

        private void TickRT()
        {
            if (RT > 1)
            {
                RT = RT - 1;
                Invalidate();
                LabelRT.Text = RT.ToString();
            }
            else if (RT <= 1)
            {
                RT = 0;
                LabelRT.Text = "";
                PanelRT.BackColor = m_BackgroundColor;
            }
        }

        private void TimerRT_Tick(object sender, EventArgs e)
        {
            TickRT();
            if (RT == 0)
            {
                TimerRT.Stop();
            }
        }

        private void DrawBorder(Graphics g, Pen p)
        {
            g.DrawLine(p, new Point(ClientRectangle.Left, ClientRectangle.Top), new Point(int.Parse((ClientRectangle.Width - p.Width).ToString()), ClientRectangle.Top));
            g.DrawLine(p, new Point(ClientRectangle.Left, ClientRectangle.Top), new Point(ClientRectangle.Left, int.Parse((ClientRectangle.Height - p.Width).ToString())));
            g.DrawLine(p, new Point(ClientRectangle.Left, int.Parse((ClientRectangle.Height - p.Width).ToString())), new Point(int.Parse((ClientRectangle.Width - p.Width).ToString()), int.Parse((ClientRectangle.Height - p.Width).ToString())));
            g.DrawLine(p, new Point(int.Parse((ClientRectangle.Width - p.Width).ToString()), ClientRectangle.Top), new Point(int.Parse((ClientRectangle.Width - p.Width).ToString()), int.Parse((ClientRectangle.Height - p.Width).ToString())));
        }
    }
}