using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GenieClient.Services;

namespace GenieClient.Windows.Services
{
    /// <summary>
    /// Windows implementation of IColorParsingService using System.Drawing color names.
    /// </summary>
    public sealed class WindowsColorParsingService : IColorParsingService
    {
        private static readonly Lazy<IReadOnlyList<string>> _knownColorNames = new(() =>
        {
            return Enum.GetNames(typeof(KnownColor))
                .Where(name =>
                {
                    var knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), name);
                    var color = Color.FromKnownColor(knownColor);
                    return !color.IsSystemColor; // Exclude system colors like "Control", "Window", etc.
                })
                .OrderBy(n => n)
                .ToList();
        });

        private static readonly Lazy<Dictionary<string, Color>> _colorsByName = new(() =>
        {
            var dict = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase);
            foreach (var name in _knownColorNames.Value)
            {
                var knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), name);
                dict[name] = Color.FromKnownColor(knownColor);
            }
            return dict;
        });

        public GenieColor ParseColor(string colorString)
        {
            if (TryParseColor(colorString, out var color))
                return color;
            return GenieColor.Transparent;
        }

        public bool TryParseColor(string colorString, out GenieColor color)
        {
            color = GenieColor.Transparent;

            if (string.IsNullOrWhiteSpace(colorString))
                return false;

            colorString = colorString.Trim();

            // Try named color first
            if (_colorsByName.Value.TryGetValue(colorString, out var namedColor))
            {
                color = new GenieColor(namedColor.R, namedColor.G, namedColor.B, namedColor.A);
                return true;
            }

            // Try hex format
            if (colorString.StartsWith("#"))
            {
                try
                {
                    color = GenieColor.FromHex(colorString);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            // Try parsing with ColorConverter (handles "255, 128, 64" format)
            try
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Color));
                if (converter.ConvertFromString(colorString) is Color parsedColor)
                {
                    color = new GenieColor(parsedColor.R, parsedColor.G, parsedColor.B, parsedColor.A);
                    return true;
                }
            }
            catch
            {
                // Ignore conversion errors
            }

            // Try RGB format "R,G,B"
            var parts = colorString.Split(',');
            if (parts.Length >= 3 &&
                byte.TryParse(parts[0].Trim(), out byte r) &&
                byte.TryParse(parts[1].Trim(), out byte g) &&
                byte.TryParse(parts[2].Trim(), out byte b))
            {
                byte a = 255;
                if (parts.Length >= 4)
                    byte.TryParse(parts[3].Trim(), out a);

                color = new GenieColor(r, g, b, a);
                return true;
            }

            return false;
        }

        public string ColorToString(GenieColor color)
        {
            // Try to find matching named color
            foreach (var kvp in _colorsByName.Value)
            {
                if (kvp.Value.R == color.R &&
                    kvp.Value.G == color.G &&
                    kvp.Value.B == color.B &&
                    kvp.Value.A == color.A)
                {
                    return kvp.Key;
                }
            }

            // Fall back to hex
            return color.ToHex();
        }

        public string ColorToHex(GenieColor color, bool includeHash = true)
        {
            var hex = color.ToHex();
            return includeHash ? hex : hex.TrimStart('#');
        }

        public int ColorToColorref(GenieColor color)
        {
            // COLORREF is 0x00BBGGRR format
            return color.B << 16 | color.G << 8 | color.R;
        }

        public GenieColor ColorrefToColor(int colorref)
        {
            return new GenieColor(
                (byte)(colorref & 0xFF),           // R
                (byte)((colorref >> 8) & 0xFF),    // G
                (byte)((colorref >> 16) & 0xFF));  // B
        }

        public IReadOnlyList<string> GetKnownColorNames() => _knownColorNames.Value;

        public bool IsKnownColor(string colorName)
        {
            return _colorsByName.Value.ContainsKey(colorName);
        }
    }
}

