using GenieClient.Genie;
using System.Drawing;
using System.Windows.Forms;

namespace GenieClient
{
    public class FlickerFreePanel : Panel
    {
        private Globals _Globals;
        public FlickerFreePanel(Globals Globals)
        {
            _Globals = Globals;
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
                    e.Graphics.DrawLine(GridColor, 0, I, Width, I);
                }

                I = 0;
                while (I < Width)
                {
                    I += 20;
                    e.Graphics.DrawLine(GridColor, I, 0, I, Height);
                }
            }
        }

        public Pen GridColor { 
            get 
            { 
                return new Pen(_Globals.PresetList["automapper.panel"].BgColor); 
            } 
        }
    }
}