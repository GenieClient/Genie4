using System;
using System.Collections.Generic;
using GenieClient.Services;

namespace GenieClient.Genie
{
    /// <summary>
    /// Color parsing and conversion utilities.
    /// Cross-platform implementation using GenieColor.
    /// </summary>
    public class ColorCode
    {
        #region Cross-Platform Color Name Dictionary
        
        /// <summary>
        /// Dictionary of known color names to GenieColor values.
        /// This provides cross-platform color name resolution without System.Drawing dependency.
        /// </summary>
        private static readonly Dictionary<string, GenieColor> _namedColors = new Dictionary<string, GenieColor>(StringComparer.OrdinalIgnoreCase)
        {
            // Basic colors
            { "black", GenieColor.Black },
            { "white", GenieColor.White },
            { "red", GenieColor.Red },
            { "green", GenieColor.Green },
            { "blue", GenieColor.Blue },
            { "yellow", GenieColor.Yellow },
            { "cyan", GenieColor.Cyan },
            { "magenta", GenieColor.Magenta },
            { "gray", GenieColor.Gray },
            { "grey", GenieColor.Gray },
            { "silver", GenieColor.Silver },
            { "maroon", GenieColor.Maroon },
            { "navy", GenieColor.Navy },
            { "purple", GenieColor.Purple },
            { "orange", GenieColor.Orange },
            { "transparent", GenieColor.Transparent },
            
            // Extended colors
            { "lightgray", GenieColor.LightGray },
            { "lightgrey", GenieColor.LightGray },
            { "darkgray", GenieColor.DarkGray },
            { "darkgrey", GenieColor.DarkGray },
            { "orangered", GenieColor.OrangeRed },
            { "lime", GenieColor.Lime },
            { "aqua", GenieColor.Aqua },
            { "teal", GenieColor.Teal },
            { "olive", GenieColor.Olive },
            { "fuchsia", GenieColor.Fuchsia },
            
            // Blues
            { "royalblue", GenieColor.RoyalBlue },
            { "steelblue", GenieColor.SteelBlue },
            { "cornflowerblue", GenieColor.CornflowerBlue },
            { "mediumblue", GenieColor.MediumBlue },
            { "darkblue", GenieColor.DarkBlue },
            { "lightblue", GenieColor.LightBlue },
            
            // Greens
            { "palegreen", GenieColor.PaleGreen },
            { "lightgreen", GenieColor.LightGreen },
            { "greenyellow", GenieColor.GreenYellow },
            
            // Other
            { "palegoldenrod", GenieColor.PaleGoldenrod },
            
            // Additional common colors (from System.Drawing.KnownColor)
            { "aliceblue", new GenieColor(240, 248, 255) },
            { "antiquewhite", new GenieColor(250, 235, 215) },
            { "aquamarine", new GenieColor(127, 255, 212) },
            { "azure", new GenieColor(240, 255, 255) },
            { "beige", new GenieColor(245, 245, 220) },
            { "bisque", new GenieColor(255, 228, 196) },
            { "blanchedalmond", new GenieColor(255, 235, 205) },
            { "blueviolet", new GenieColor(138, 43, 226) },
            { "brown", new GenieColor(165, 42, 42) },
            { "burlywood", new GenieColor(222, 184, 135) },
            { "cadetblue", new GenieColor(95, 158, 160) },
            { "chartreuse", new GenieColor(127, 255, 0) },
            { "chocolate", new GenieColor(210, 105, 30) },
            { "coral", new GenieColor(255, 127, 80) },
            { "cornsilk", new GenieColor(255, 248, 220) },
            { "crimson", new GenieColor(220, 20, 60) },
            { "darkgoldenrod", new GenieColor(184, 134, 11) },
            { "darkcyan", new GenieColor(0, 139, 139) },
            { "darkgreen", new GenieColor(0, 100, 0) },
            { "darkkhaki", new GenieColor(189, 183, 107) },
            { "darkmagenta", new GenieColor(139, 0, 139) },
            { "darkolivegreen", new GenieColor(85, 107, 47) },
            { "darkorange", new GenieColor(255, 140, 0) },
            { "darkorchid", new GenieColor(153, 50, 204) },
            { "darkred", new GenieColor(139, 0, 0) },
            { "darksalmon", new GenieColor(233, 150, 122) },
            { "darkseagreen", new GenieColor(143, 188, 143) },
            { "darkslateblue", new GenieColor(72, 61, 139) },
            { "darkslategray", new GenieColor(47, 79, 79) },
            { "darkslategrey", new GenieColor(47, 79, 79) },
            { "darkturquoise", new GenieColor(0, 206, 209) },
            { "darkviolet", new GenieColor(148, 0, 211) },
            { "deeppink", new GenieColor(255, 20, 147) },
            { "deepskyblue", new GenieColor(0, 191, 255) },
            { "dimgray", new GenieColor(105, 105, 105) },
            { "dimgrey", new GenieColor(105, 105, 105) },
            { "dodgerblue", new GenieColor(30, 144, 255) },
            { "firebrick", new GenieColor(178, 34, 34) },
            { "floralwhite", new GenieColor(255, 250, 240) },
            { "forestgreen", new GenieColor(34, 139, 34) },
            { "gainsboro", new GenieColor(220, 220, 220) },
            { "ghostwhite", new GenieColor(248, 248, 255) },
            { "gold", new GenieColor(255, 215, 0) },
            { "goldenrod", new GenieColor(218, 165, 32) },
            { "honeydew", new GenieColor(240, 255, 240) },
            { "hotpink", new GenieColor(255, 105, 180) },
            { "indianred", new GenieColor(205, 92, 92) },
            { "indigo", new GenieColor(75, 0, 130) },
            { "ivory", new GenieColor(255, 255, 240) },
            { "khaki", new GenieColor(240, 230, 140) },
            { "lavender", new GenieColor(230, 230, 250) },
            { "lavenderblush", new GenieColor(255, 240, 245) },
            { "lawngreen", new GenieColor(124, 252, 0) },
            { "lemonchiffon", new GenieColor(255, 250, 205) },
            { "lightcoral", new GenieColor(240, 128, 128) },
            { "lightcyan", new GenieColor(224, 255, 255) },
            { "lightgoldenrodyellow", new GenieColor(250, 250, 210) },
            { "lightpink", new GenieColor(255, 182, 193) },
            { "lightsalmon", new GenieColor(255, 160, 122) },
            { "lightseagreen", new GenieColor(32, 178, 170) },
            { "lightskyblue", new GenieColor(135, 206, 250) },
            { "lightslategray", new GenieColor(119, 136, 153) },
            { "lightslategrey", new GenieColor(119, 136, 153) },
            { "lightsteelblue", new GenieColor(176, 196, 222) },
            { "lightyellow", new GenieColor(255, 255, 224) },
            { "limegreen", new GenieColor(50, 205, 50) },
            { "linen", new GenieColor(250, 240, 230) },
            { "mediumaquamarine", new GenieColor(102, 205, 170) },
            { "mediumorchid", new GenieColor(186, 85, 211) },
            { "mediumpurple", new GenieColor(147, 112, 219) },
            { "mediumseagreen", new GenieColor(60, 179, 113) },
            { "mediumslateblue", new GenieColor(123, 104, 238) },
            { "mediumspringgreen", new GenieColor(0, 250, 154) },
            { "mediumturquoise", new GenieColor(72, 209, 204) },
            { "mediumvioletred", new GenieColor(199, 21, 133) },
            { "midnightblue", new GenieColor(25, 25, 112) },
            { "mintcream", new GenieColor(245, 255, 250) },
            { "mistyrose", new GenieColor(255, 228, 225) },
            { "moccasin", new GenieColor(255, 228, 181) },
            { "navajowhite", new GenieColor(255, 222, 173) },
            { "oldlace", new GenieColor(253, 245, 230) },
            { "olivedrab", new GenieColor(107, 142, 35) },
            { "orchid", new GenieColor(218, 112, 214) },
            { "papayawhip", new GenieColor(255, 239, 213) },
            { "peachpuff", new GenieColor(255, 218, 185) },
            { "peru", new GenieColor(205, 133, 63) },
            { "pink", new GenieColor(255, 192, 203) },
            { "plum", new GenieColor(221, 160, 221) },
            { "powderblue", new GenieColor(176, 224, 230) },
            { "rosybrown", new GenieColor(188, 143, 143) },
            { "saddlebrown", new GenieColor(139, 69, 19) },
            { "salmon", new GenieColor(250, 128, 114) },
            { "sandybrown", new GenieColor(244, 164, 96) },
            { "seagreen", new GenieColor(46, 139, 87) },
            { "seashell", new GenieColor(255, 245, 238) },
            { "sienna", new GenieColor(160, 82, 45) },
            { "skyblue", new GenieColor(135, 206, 235) },
            { "slateblue", new GenieColor(106, 90, 205) },
            { "slategray", new GenieColor(112, 128, 144) },
            { "slategrey", new GenieColor(112, 128, 144) },
            { "snow", new GenieColor(255, 250, 250) },
            { "springgreen", new GenieColor(0, 255, 127) },
            { "tan", new GenieColor(210, 180, 140) },
            { "thistle", new GenieColor(216, 191, 216) },
            { "tomato", new GenieColor(255, 99, 71) },
            { "turquoise", new GenieColor(64, 224, 208) },
            { "violet", new GenieColor(238, 130, 238) },
            { "wheat", new GenieColor(245, 222, 179) },
            { "whitesmoke", new GenieColor(245, 245, 245) },
            { "yellowgreen", new GenieColor(154, 205, 50) },
        };

        /// <summary>
        /// Gets all known color names.
        /// </summary>
        public static IReadOnlyCollection<string> KnownColorNames => _namedColors.Keys;

        #endregion

        #region Cross-Platform Hex Utilities

        public const string ValidHexChars = "1234567890aAbBcCdDeEfF";

        /// <summary>
        /// Checks if a string is a valid hex color string (#RRGGBB format).
        /// </summary>
        public static bool IsHexString(string sText)
        {
            if (string.IsNullOrEmpty(sText) || !sText.StartsWith("#"))
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

        /// <summary>
        /// Checks if a string is a known color name.
        /// </summary>
        public static bool IsColorString(string sText)
        {
            if (string.IsNullOrEmpty(sText))
                return false;
            return _namedColors.ContainsKey(sText);
        }

        /// <summary>
        /// Converts a byte to a 2-digit hex string.
        /// </summary>
        private static string Hex2Digits(byte color)
        {
            return color.ToString("X2");
        }

        #endregion

        #region GenieColor Methods (Cross-Platform)

        /// <summary>
        /// Converts a GenieColor to its string representation.
        /// Tries to find a matching named color, otherwise returns hex.
        /// </summary>
        public static string GenieColorToString(GenieColor color)
        {
            // Try to find a named color match
            foreach (var kvp in _namedColors)
            {
                if (kvp.Value.R == color.R && kvp.Value.G == color.G && kvp.Value.B == color.B && kvp.Value.A == color.A)
                {
                    return kvp.Key;
                }
            }
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

            // Try named color from dictionary
            if (_namedColors.TryGetValue(sColor, out GenieColor namedColor))
            {
                return namedColor;
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

        #region System.Drawing.Color Methods (Windows-Only Legacy)
        // These methods are kept for backwards compatibility with Windows Forms code.
        // They require System.Drawing and should only be called from Genie.Windows.

#if WINDOWS
        public static string ColorToString(System.Drawing.Color oColor)
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

        public static string ColorToString(System.Drawing.Color oFgColor, System.Drawing.Color oBgColor)
        {
            return ColorToString(oFgColor) + ", " + ColorToString(oBgColor);
        }

        public static System.Drawing.Color StringToColor(string sColor)
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
                    // Use our cross-platform color lookup and convert to System.Drawing.Color
                    var genieColor = StringToGenieColor(sColor);
                    return genieColor.ToDrawingColor();
                }
            }
            catch (Exception)
            {
                return default;
            }

            return default;
        }

        public static int ColorToColorref(System.Drawing.Color clr)
        {
            return System.Drawing.ColorTranslator.ToWin32(clr);
        }

        public static string ColorToHex(System.Drawing.Color oColor)
        {
            return "#" + Hex2Digits(oColor.R) + Hex2Digits(oColor.G) + Hex2Digits(oColor.B);
        }

        public static System.Drawing.Color ColorToLighter(System.Drawing.Color oColor)
        {
            int R = (int)(oColor.R / 1.299);
            int G = (int)(oColor.G / 1.587);
            int B = (int)(oColor.B / 1.114);
            return System.Drawing.Color.FromArgb(R, G, B);
        }

        public static System.Drawing.Color ColorToDarker(System.Drawing.Color oColor)
        {
            int R = (int)(oColor.R * 0.299);
            int G = (int)(oColor.G * 0.587);
            int B = (int)(oColor.B * 0.114);
            return System.Drawing.Color.FromArgb(R, G, B);
        }

        public static System.Drawing.Color ColorToGrayscale(System.Drawing.Color oColor)
        {
            int iColor = (int)(oColor.R * 0.299 + oColor.G * 0.587 + oColor.B * 0.114);
            return System.Drawing.Color.FromArgb(iColor, iColor, iColor);
        }

        public static System.Drawing.Color HexToColor(string sColor)
        {
            try
            {
                return System.Drawing.ColorTranslator.FromHtml(sColor);
            }
            catch (Exception)
            {
                return default;
            }
        }
#endif

        #endregion
    }
}