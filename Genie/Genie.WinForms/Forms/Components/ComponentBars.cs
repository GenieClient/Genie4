using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class ComponentBars
    {
        public ComponentBars()
        {
            InitializeComponent();
        }

        private int m_CurrentValue = 0;
        private string m_Text = string.Empty;
        private Color m_BackgroundColor = Color.Black;
        private Color m_ForegroundColor = Color.Gray;
        private Pen m_BorderColor = Pens.Gray;
        private Pen m_BorderColorGrayScale = Pens.Gray;

        // Private myImage As Image = Image.FromFile("RT.bmp")

        private void PanelBar_Paint(object sender, PaintEventArgs e)
        {
            // Dim myTextureBrush As New TextureBrush(myImage)

            if (m_CurrentValue > 0)
            {
                var myTextureBrush = new SolidBrush((Color)Interaction.IIf(m_IsConnected, m_ForegroundColor, Genie.ColorCode.ColorToGrayscale(m_ForegroundColor)));
                int w = Conversions.ToInteger(Math.Round(Width / (double)100 * m_CurrentValue));
                e.Graphics.FillRectangle(myTextureBrush, 0, 0, w, PanelBar.Height);
                Pen argp = (Pen)Interaction.IIf(m_IsConnected, m_BorderColor, m_BorderColorGrayScale);
                DrawBorder(e.Graphics, argp);
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
                PanelBar.BackColor = (Color)Interaction.IIf(m_IsConnected, m_BackgroundColor, Genie.ColorCode.ColorToGrayscale(m_BackgroundColor));
                Invalidate();
            }
        }

        public string BarText
        {
            get
            {
                return m_Text;
            }

            set
            {
                m_Text = value;
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
                PanelBar.BackColor = (Color)Interaction.IIf(m_IsConnected, m_BackgroundColor, Genie.ColorCode.ColorToGrayscale(m_BackgroundColor));
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

        public int Value
        {
            get
            {
                return m_CurrentValue;
            }

            set
            {
                if (value < 0)
                    value = 0;
                if (value > 100)
                    value = 100;
                m_CurrentValue = value;
                LabelValue.Text = m_Text;
                Invalidate();
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