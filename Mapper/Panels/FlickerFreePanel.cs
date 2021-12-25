using System.Drawing;
using System.Windows.Forms;

namespace GenieClient
{
    public class FlickerFreePanel : Panel
    {
        public FlickerFreePanel()
        {
            this.Paint += FlickerFreePanel_Paint;
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        private bool m_Drawlines = true;

        public bool DrawLines
        {
            get
            {
                return m_Drawlines;
            }

            set
            {
                m_Drawlines = value;
                Invalidate();
            }
        }

        private void FlickerFreePanel_Paint(object sender, PaintEventArgs e)
        {
            if (m_Drawlines == true)
            {
                int I = 0;
                while (I < Height)
                {
                    I += 20;
                    e.Graphics.DrawLine(m_GridColor, 0, I, Width, I);
                }

                I = 0;
                while (I < Width)
                {
                    I += 20;
                    e.Graphics.DrawLine(m_GridColor, I, 0, I, Height);
                }
            }
        }

        private Pen m_GridColor = Pens.PaleGoldenrod;

        public Pen GridColor
        {
            get
            {
                return m_GridColor;
            }

            set
            {
                m_GridColor = value;
            }
        }
    }
}