using System;

namespace GenieClient.Services
{
    /// <summary>
    /// Platform-agnostic color representation.
    /// Replaces System.Drawing.Color for cross-platform compatibility.
    /// </summary>
    public readonly struct GenieColor : IEquatable<GenieColor>
    {
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public byte A { get; }

        public GenieColor(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Creates a GenieColor from an ARGB integer value.
        /// </summary>
        public static GenieColor FromArgb(int argb)
        {
            return new GenieColor(
                (byte)((argb >> 16) & 0xFF),
                (byte)((argb >> 8) & 0xFF),
                (byte)(argb & 0xFF),
                (byte)((argb >> 24) & 0xFF)
            );
        }

        /// <summary>
        /// Creates a GenieColor from RGB values with full opacity.
        /// </summary>
        public static GenieColor FromRgb(byte r, byte g, byte b)
        {
            return new GenieColor(r, g, b, 255);
        }

        /// <summary>
        /// Converts to ARGB integer representation.
        /// </summary>
        public int ToArgb()
        {
            return (A << 24) | (R << 16) | (G << 8) | B;
        }

        /// <summary>
        /// Returns a hex string representation (e.g., "#FF5733" or "#80FF5733" with alpha).
        /// </summary>
        public string ToHex(bool includeAlpha = false)
        {
            if (includeAlpha && A != 255)
            {
                return $"#{A:X2}{R:X2}{G:X2}{B:X2}";
            }
            return $"#{R:X2}{G:X2}{B:X2}";
        }

        /// <summary>
        /// Parses a color from a hex string (e.g., "#FF5733" or "FF5733").
        /// </summary>
        public static GenieColor FromHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return Transparent;

            hex = hex.TrimStart('#');

            if (hex.Length == 6)
            {
                return new GenieColor(
                    Convert.ToByte(hex.Substring(0, 2), 16),
                    Convert.ToByte(hex.Substring(2, 2), 16),
                    Convert.ToByte(hex.Substring(4, 2), 16)
                );
            }
            else if (hex.Length == 8)
            {
                return new GenieColor(
                    Convert.ToByte(hex.Substring(2, 2), 16),
                    Convert.ToByte(hex.Substring(4, 2), 16),
                    Convert.ToByte(hex.Substring(6, 2), 16),
                    Convert.ToByte(hex.Substring(0, 2), 16)
                );
            }

            return Transparent;
        }

        public bool IsTransparent => A == 0;

        // Common colors
        public static GenieColor Transparent => new(0, 0, 0, 0);
        public static GenieColor Black => new(0, 0, 0);
        public static GenieColor White => new(255, 255, 255);
        public static GenieColor Red => new(255, 0, 0);
        public static GenieColor Green => new(0, 128, 0);
        public static GenieColor Blue => new(0, 0, 255);
        public static GenieColor Yellow => new(255, 255, 0);
        public static GenieColor Cyan => new(0, 255, 255);
        public static GenieColor Magenta => new(255, 0, 255);
        public static GenieColor Gray => new(128, 128, 128);
        public static GenieColor Silver => new(192, 192, 192);
        public static GenieColor Maroon => new(128, 0, 0);
        public static GenieColor Navy => new(0, 0, 128);
        public static GenieColor Purple => new(128, 0, 128);
        public static GenieColor Orange => new(255, 165, 0);

        // Game-specific colors
        public static GenieColor PaleGreen => new(152, 251, 152);
        public static GenieColor PaleGoldenrod => new(238, 232, 170);
        public static GenieColor GreenYellow => new(173, 255, 47);
        public static GenieColor MediumBlue => new(0, 0, 205);
        public static GenieColor DarkBlue => new(0, 0, 139);
        public static GenieColor LightBlue => new(173, 216, 230);
        public static GenieColor LightGreen => new(144, 238, 144);

        public bool Equals(GenieColor other)
        {
            return R == other.R && G == other.G && B == other.B && A == other.A;
        }

        public override bool Equals(object? obj)
        {
            return obj is GenieColor other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(R, G, B, A);
        }

        public static bool operator ==(GenieColor left, GenieColor right) => left.Equals(right);
        public static bool operator !=(GenieColor left, GenieColor right) => !left.Equals(right);

        public override string ToString() => ToHex();
    }
}

