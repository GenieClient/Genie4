using System.Drawing;

namespace GenieClient.Services
{
    /// <summary>
    /// Provides conversion between GenieColor and System.Drawing.Color.
    /// This is a temporary bridge during migration - eventually Windows Forms
    /// UI will use GenieColor directly or convert at the UI layer only.
    /// </summary>
    public static class ColorConverter
    {
        /// <summary>
        /// Converts a System.Drawing.Color to GenieColor.
        /// </summary>
        public static GenieColor ToGenieColor(this Color color)
        {
            // Handle Color.Empty specially - it should map to GenieColor.Transparent
            if (color.IsEmpty || color == Color.Empty)
            {
                return GenieColor.Transparent;
            }
            return new GenieColor(color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Converts a GenieColor to System.Drawing.Color.
        /// </summary>
        public static Color ToDrawingColor(this GenieColor color)
        {
            // Handle transparent colors - return Color.Transparent to preserve proper transparency semantics
            // Note: Color.Transparent is (255,255,255,0) in System.Drawing - white with 0 alpha
            if (color.IsTransparent)
            {
                return Color.Transparent;
            }
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}

