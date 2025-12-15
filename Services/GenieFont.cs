using System;

namespace GenieClient.Services
{
    /// <summary>
    /// Platform-agnostic font representation.
    /// Stores font information that can be converted to platform-specific Font objects.
    /// </summary>
    public struct GenieFont : IEquatable<GenieFont>
    {
        public string FamilyName { get; }
        public float Size { get; }
        public GenieFontStyle Style { get; }

        public GenieFont(string familyName, float size, GenieFontStyle style = GenieFontStyle.Regular)
        {
            FamilyName = familyName ?? "Courier New";
            Size = size > 0 ? size : 9f;
            Style = style;
        }

        public static GenieFont Default => new GenieFont("Courier New", 9f, GenieFontStyle.Regular);

        public bool Equals(GenieFont other)
        {
            return string.Equals(FamilyName, other.FamilyName, StringComparison.OrdinalIgnoreCase) 
                && Math.Abs(Size - other.Size) < 0.001f 
                && Style == other.Style;
        }

        public override bool Equals(object obj) => obj is GenieFont other && Equals(other);
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + (FamilyName?.GetHashCode() ?? 0);
                hash = hash * 31 + Size.GetHashCode();
                hash = hash * 31 + Style.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(GenieFont left, GenieFont right) => left.Equals(right);
        public static bool operator !=(GenieFont left, GenieFont right) => !left.Equals(right);

        public override string ToString() => $"{FamilyName}, {Size}pt, {Style}";

#if WINDOWS
        /// <summary>
        /// Converts to System.Drawing.Font (Windows only).
        /// </summary>
        public System.Drawing.Font ToDrawingFont()
        {
            return new System.Drawing.Font(FamilyName, Size, (System.Drawing.FontStyle)Style);
        }

        /// <summary>
        /// Creates from System.Drawing.Font (Windows only).
        /// </summary>
        public static GenieFont FromDrawingFont(System.Drawing.Font font)
        {
            if (font == null) return Default;
            return new GenieFont(font.FontFamily.Name, font.Size, (GenieFontStyle)font.Style);
        }
#endif
    }

    [Flags]
    public enum GenieFontStyle
    {
        Regular = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4,
        Strikeout = 8,
        BoldItalic = Bold | Italic
    }

#if WINDOWS
    /// <summary>
    /// Extension methods for Font conversion (Windows only).
    /// </summary>
    public static class GenieFontExtensions
    {
        public static GenieFont ToGenieFont(this System.Drawing.Font font)
        {
            return GenieFont.FromDrawingFont(font);
        }

        public static System.Drawing.Font ToDrawingFont(this GenieFont font)
        {
            return font.ToDrawingFont();
        }
    }
#endif
}

