using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GenieClient.Services
{
    /// <summary>
    /// Null implementation of IWindowAttentionService (no-op).
    /// </summary>
    public sealed class NullWindowAttentionService : IWindowAttentionService
    {
        public static readonly NullWindowAttentionService Instance = new();
        private NullWindowAttentionService() { }

        public void RequestAttention(IntPtr windowHandle, bool critical = false) { }
        public void CancelAttention(IntPtr windowHandle) { }
        public bool FlashWindow(IntPtr windowHandle, bool invert = true) => false;
    }

    /// <summary>
    /// Null implementation of IRichTextService (no-op).
    /// </summary>
    public sealed class NullRichTextService : IRichTextService
    {
        public static readonly NullRichTextService Instance = new();
        private NullRichTextService() { }

        public void BeginUpdate(IntPtr controlHandle) { }
        public void EndUpdate(IntPtr controlHandle) { }
        public int GetFirstVisibleLine(IntPtr controlHandle) => 0;
        public void ScrollByLines(IntPtr controlHandle, int lineCount) { }
        public int GetScrollPosition(IntPtr controlHandle) => 0;
        public bool SetScrollPosition(IntPtr controlHandle, int position) => false;
    }

    /// <summary>
    /// Null implementation of IGenieImage.
    /// </summary>
    public sealed class NullGenieImage : IGenieImage
    {
        public static readonly NullGenieImage Instance = new(1, 1);

        public int Width { get; }
        public int Height { get; }
        public object NativeImage => this;

        public NullGenieImage(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Save(string path, GenieImageFormat format = GenieImageFormat.Png) { }
        public Stream ToStream(GenieImageFormat format = GenieImageFormat.Png) => new MemoryStream();
        public IGenieImage Scale(int width, int height) => new NullGenieImage(width, height);
        public void Dispose() { }
    }

    /// <summary>
    /// Null implementation of IImageService.
    /// </summary>
    public sealed class NullImageService : IImageService
    {
        public static readonly NullImageService Instance = new();
        private NullImageService() { }

        public IGenieImage? LoadFromFile(string path) => null;
        public Task<IGenieImage?> LoadFromFileAsync(string path) => Task.FromResult<IGenieImage?>(null);
        public IGenieImage? LoadFromStream(Stream stream) => null;
        public Task<IGenieImage?> LoadFromStreamAsync(Stream stream) => Task.FromResult<IGenieImage?>(null);
        public Task<IGenieImage?> LoadFromUrlAsync(string url) => Task.FromResult<IGenieImage?>(null);
        public IGenieImage CreateEmpty(int width, int height) => new NullGenieImage(width, height);
        public IGenieImage Scale(IGenieImage image, int maxWidth, int maxHeight, bool maintainAspectRatio = true)
            => new NullGenieImage(maxWidth, maxHeight);
    }

    /// <summary>
    /// Null implementation of IWindowChromeService (no-op).
    /// </summary>
    public sealed class NullWindowChromeService : IWindowChromeService
    {
        public static readonly NullWindowChromeService Instance = new();
        private NullWindowChromeService() { }

        public void StartWindowDrag(IntPtr windowHandle) { }
        public void StartWindowResize(IntPtr windowHandle, WindowResizeEdge edge) { }
        public bool ReleaseCapture(IntPtr windowHandle) => false;
        public IntPtr SendMessage(IntPtr windowHandle, int msg, int wParam, int lParam) => IntPtr.Zero;
    }

    /// <summary>
    /// Null implementation of IColorParsingService with basic hex/RGB support.
    /// </summary>
    public sealed class NullColorParsingService : IColorParsingService
    {
        public static readonly NullColorParsingService Instance = new();
        private NullColorParsingService() { }

        private static readonly IReadOnlyList<string> EmptyColorNames = Array.Empty<string>();

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

            // Try hex format
            if (colorString.StartsWith("#") || colorString.Length == 6 || colorString.Length == 8)
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

        public string ColorToString(GenieColor color) => color.ToHex();
        public string ColorToHex(GenieColor color, bool includeHash = true)
            => includeHash ? color.ToHex() : color.ToHex().TrimStart('#');

        public int ColorToColorref(GenieColor color)
            => color.B << 16 | color.G << 8 | color.R;

        public GenieColor ColorrefToColor(int colorref)
            => new GenieColor(
                (byte)(colorref & 0xFF),
                (byte)((colorref >> 8) & 0xFF),
                (byte)((colorref >> 16) & 0xFF));

        public IReadOnlyList<string> GetKnownColorNames() => EmptyColorNames;
        public bool IsKnownColor(string colorName) => false;
    }

    /// <summary>
    /// Null implementation of ISoundService (no-op).
    /// </summary>
    public sealed class NullSoundService : ISoundService
    {
        public static readonly NullSoundService Instance = new();
        private NullSoundService() { }

        public bool IsEnabled { get; set; } = false;
        public void PlayWaveFile(string filePath) { }
        public void PlayWaveResource(string resourceName) { }
        public void PlaySystemSound(string soundAlias) { }
        public void StopPlaying() { }
    }
}

