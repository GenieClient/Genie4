using System.Collections.Generic;

namespace GenieClient.Services
{
    /// <summary>
    /// Provides cross-platform color name parsing and conversion.
    /// Abstracts System.Drawing.KnownColor and color name resolution.
    /// </summary>
    public interface IColorParsingService
    {
        /// <summary>
        /// Parses a color string (name, hex, or RGB) into a GenieColor.
        /// </summary>
        /// <param name="colorString">Color string to parse (e.g., "Red", "#FF0000", "255,0,0").</param>
        /// <returns>The parsed color, or Transparent if parsing fails.</returns>
        GenieColor ParseColor(string colorString);

        /// <summary>
        /// Attempts to parse a color string into a GenieColor.
        /// </summary>
        /// <param name="colorString">Color string to parse.</param>
        /// <param name="color">The parsed color if successful.</param>
        /// <returns>True if parsing succeeded.</returns>
        bool TryParseColor(string colorString, out GenieColor color);

        /// <summary>
        /// Converts a GenieColor to its best matching color name.
        /// Returns hex if no exact name match is found.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>Color name or hex string.</returns>
        string ColorToString(GenieColor color);

        /// <summary>
        /// Converts a GenieColor to a hex string.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <param name="includeHash">Whether to include the # prefix.</param>
        /// <returns>Hex color string (e.g., "#FF5733" or "FF5733").</returns>
        string ColorToHex(GenieColor color, bool includeHash = true);

        /// <summary>
        /// Converts a GenieColor to a Win32 COLORREF value.
        /// COLORREF is 0x00BBGGRR format.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>COLORREF integer value.</returns>
        int ColorToColorref(GenieColor color);

        /// <summary>
        /// Converts a Win32 COLORREF value to a GenieColor.
        /// </summary>
        /// <param name="colorref">COLORREF integer (0x00BBGGRR format).</param>
        /// <returns>The converted color.</returns>
        GenieColor ColorrefToColor(int colorref);

        /// <summary>
        /// Gets all available known color names.
        /// </summary>
        /// <returns>List of color names.</returns>
        IReadOnlyList<string> GetKnownColorNames();

        /// <summary>
        /// Checks if a color name is recognized.
        /// </summary>
        /// <param name="colorName">The color name to check.</param>
        /// <returns>True if the color name is known.</returns>
        bool IsKnownColor(string colorName);
    }
}

