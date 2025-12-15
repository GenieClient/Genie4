using System.Drawing;
using GenieClient.Services;

namespace GenieClient.Genie
{
    /// <summary>
    /// Windows-specific color code methods.
    /// These methods require System.Drawing which is only available on Windows.
    /// </summary>
    public static class ColorCodeWindows
    {
        public static string ColorToString(Color oColor)
        {
            if (oColor.IsNamedColor == true)
            {
                return oColor.Name;
            }
            else
            {
                return ColorToHex(oColor);
            }
        }

        public static string ColorToString(Color oFgColor, Color oBgColor)
        {
            return ColorToString(oFgColor) + ", " + ColorToString(oBgColor);
        }

        public static Color StringToColor(string sColor)
        {
            try
            {
                if (string.IsNullOrEmpty(sColor) || sColor.StartsWith("@"))
                    return default;
                if (ColorCode.IsHexString(sColor))
                {
                    return HexToColor(sColor);
                }
                else if (ColorCode.IsColorString(sColor))
                {
                    // Use cross-platform color lookup and convert to System.Drawing.Color
                    var genieColor = ColorCode.StringToGenieColor(sColor);
                    return genieColor.ToDrawingColor();
                }
            }
            catch
            {
                return default;
            }

            return default;
        }

        public static int ColorToColorref(Color clr)
        {
            return ColorTranslator.ToWin32(clr);
        }

        public static string ColorToHex(Color oColor)
        {
            return "#" + oColor.R.ToString("X2") + oColor.G.ToString("X2") + oColor.B.ToString("X2");
        }

        public static Color ColorToLighter(Color oColor)
        {
            int R = (int)(oColor.R / 1.299);
            int G = (int)(oColor.G / 1.587);
            int B = (int)(oColor.B / 1.114);
            return Color.FromArgb(R, G, B);
        }

        public static Color ColorToDarker(Color oColor)
        {
            int R = (int)(oColor.R * 0.299);
            int G = (int)(oColor.G * 0.587);
            int B = (int)(oColor.B * 0.114);
            return Color.FromArgb(R, G, B);
        }

        public static Color ColorToGrayscale(Color oColor)
        {
            int iColor = (int)(oColor.R * 0.299 + oColor.G * 0.587 + oColor.B * 0.114);
            return Color.FromArgb(iColor, iColor, iColor);
        }

        public static Color HexToColor(string sColor)
        {
            try
            {
                return ColorTranslator.FromHtml(sColor);
            }
            catch
            {
                return default;
            }
        }
    }
}

