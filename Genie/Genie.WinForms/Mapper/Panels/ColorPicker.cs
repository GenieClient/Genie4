using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenieClient
{
    public partial class ColorPicker
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        public Color Color
        {
            get
            {
                return LabelColor.BackColor;
            }

            set
            {
                LabelColor.BackColor = value;
                LabelColor.Text = Genie.ColorCode.ColorToString(LabelColor.BackColor);
            }
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialogPicker.Color = LabelColor.BackColor;
            if (ColorDialogPicker.ShowDialog(this) == DialogResult.OK)
            {
                Color = ColorDialogPicker.Color;
            }
        }
    }
}