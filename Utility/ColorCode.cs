using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualBasic;
using GenieClient.Services;

namespace GenieClient.Genie
{
    /// <summary>
    /// Color parsing and conversion utilities.
    /// Contains both System.Drawing.Color methods (legacy) and GenieColor methods (cross-platform).
    /// </summary>
    public class ColorCode
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
                if (sColor.StartsWith("@"))
                    return default;
                if (IsHexString(sColor))
                {
                    return HexToColor(sColor);
                }
                else if (IsColorString(sColor))
                {
                    return (Color)new System.Drawing.ColorConverter().ConvertFromString(sColor);
                }
            }
            #pragma warning disable CS0168
            catch (Exception ex) // Unfortunately there is no specific error for convert errors.
            #pragma warning restore CS0168
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
            byte argcolor = oColor.R;
            byte argcolor1 = oColor.G;
            byte argcolor2 = oColor.B;
            return "#" + Hex2Digits(argcolor) + Hex2Digits(argcolor1) + Hex2Digits(argcolor2);
        }

        private static string Hex2Digits(byte color)
        {
            string sColor = Conversion.Hex(color);
            if (sColor.Length == 1)
            {
                sColor = "0" + sColor;
            }

            return sColor;
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
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                return default;
            }
        }

        public const string ValidHexChars = "1234567890aAbBcCdDeEfF";

        public static bool IsHexString(string sText)
        {
            if (!sText.StartsWith("#"))
                return false;
            if (sText.Trim().Length != 7)
                return false;
            sText = sText.Substring(1);
            foreach (char c in sText.ToCharArray())
            {
                if (ValidHexChars.IndexOf(c) == -1)
                {
                    return false;
                }
            }

            return true;
        }

        private static List<string> ColorList = null;

        public static bool IsColorString(string sText)
        {
            if (Information.IsNothing(ColorList))
            {
                ColorList = new List<string>();
                KnownColor c;
                foreach (string s in Enum.GetNames(typeof(KnownColor)))
                {
                    c = (KnownColor)Enum.Parse(typeof(KnownColor), s);
                    if (c > KnownColor.Transparent & c < KnownColor.ButtonFace)
                    {
                        ColorList.Add(s.ToLower());
                    }
                }
            }

            if (ColorList.Contains(sText.ToLower()))
                return true;
            return false;
        }

        #region GenieColor Methods (Cross-Platform)

        /// <summary>
        /// Converts a GenieColor to its string representation.
        /// </summary>
        public static string GenieColorToString(GenieColor color)
        {
            return color.ToHex();
        }

        /// <summary>
        /// Parses a color string to GenieColor.
        /// Supports hex format (#RRGGBB) and named colors.
        /// </summary>
        public static GenieColor StringToGenieColor(string sColor)
        {
            if (string.IsNullOrWhiteSpace(sColor) || sColor.StartsWith("@"))
                return GenieColor.Transparent;

            // Try hex format first
            if (IsHexString(sColor))
            {
                return GenieColor.FromHex(sColor);
            }

            // Try named color via System.Drawing.Color conversion
            if (IsColorString(sColor))
            {
                try
                {
                    var drawingColor = (Color)new System.Drawing.ColorConverter().ConvertFromString(sColor);
                    return drawingColor.ToGenieColor();
                }
                catch
                {
                    return GenieColor.Transparent;
                }
            }

            return GenieColor.Transparent;
        }

        /// <summary>
        /// Converts GenieColor to hex string.
        /// </summary>
        public static string GenieColorToHex(GenieColor color)
        {
            return color.ToHex();
        }

        /// <summary>
        /// Creates a lighter version of the color.
        /// </summary>
        public static GenieColor GenieColorToLighter(GenieColor color)
        {
            int R = (int)(color.R / 1.299);
            int G = (int)(color.G / 1.587);
            int B = (int)(color.B / 1.114);
            return new GenieColor((byte)Math.Min(255, R), (byte)Math.Min(255, G), (byte)Math.Min(255, B), color.A);
        }

        /// <summary>
        /// Creates a darker version of the color.
        /// </summary>
        public static GenieColor GenieColorToDarker(GenieColor color)
        {
            int R = (int)(color.R * 0.299);
            int G = (int)(color.G * 0.587);
            int B = (int)(color.B * 0.114);
            return new GenieColor((byte)R, (byte)G, (byte)B, color.A);
        }

        /// <summary>
        /// Creates a grayscale version of the color.
        /// </summary>
        public static GenieColor GenieColorToGrayscale(GenieColor color)
        {
            int gray = (int)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
            return new GenieColor((byte)gray, (byte)gray, (byte)gray, color.A);
        }

        #endregion
    }
}