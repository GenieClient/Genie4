using System;

namespace GenieClient.Services
{
    /// <summary>
    /// Static service locator for Genie services.
    /// Provides a central access point for services before full DI integration.
    /// </summary>
    public static class GenieServices
    {
        private static IWindowAttentionService? _windowAttention;
        private static IRichTextService? _richText;
        private static IImageService? _image;
        private static IWindowChromeService? _windowChrome;
        private static IColorParsingService? _colorParsing;
        private static ISoundService? _sound;

        /// <summary>
        /// Gets or sets the window attention service.
        /// Returns a null implementation if not registered.
        /// </summary>
        public static IWindowAttentionService WindowAttention
        {
            get => _windowAttention ?? NullWindowAttentionService.Instance;
            set => _windowAttention = value;
        }

        /// <summary>
        /// Gets or sets the rich text control service.
        /// Returns a null implementation if not registered.
        /// </summary>
        public static IRichTextService RichText
        {
            get => _richText ?? NullRichTextService.Instance;
            set => _richText = value;
        }

        /// <summary>
        /// Gets or sets the image service.
        /// Returns a null implementation if not registered.
        /// </summary>
        public static IImageService Image
        {
            get => _image ?? NullImageService.Instance;
            set => _image = value;
        }

        /// <summary>
        /// Gets or sets the window chrome service.
        /// Returns a null implementation if not registered.
        /// </summary>
        public static IWindowChromeService WindowChrome
        {
            get => _windowChrome ?? NullWindowChromeService.Instance;
            set => _windowChrome = value;
        }

        /// <summary>
        /// Gets or sets the color parsing service.
        /// Returns a null implementation if not registered.
        /// </summary>
        public static IColorParsingService ColorParsing
        {
            get => _colorParsing ?? NullColorParsingService.Instance;
            set => _colorParsing = value;
        }

        /// <summary>
        /// Gets or sets the sound service.
        /// Returns a null implementation if not registered.
        /// </summary>
        public static ISoundService Sound
        {
            get => _sound ?? NullSoundService.Instance;
            set => _sound = value;
        }

        /// <summary>
        /// Resets all services to null (for testing).
        /// </summary>
        public static void Reset()
        {
            _windowAttention = null;
            _richText = null;
            _image = null;
            _windowChrome = null;
            _colorParsing = null;
            _sound = null;
        }

        /// <summary>
        /// Initializes services with null implementations.
        /// Call this if no platform-specific services are available.
        /// </summary>
        public static void InitializeWithNullServices()
        {
            _windowAttention = NullWindowAttentionService.Instance;
            _richText = NullRichTextService.Instance;
            _image = NullImageService.Instance;
            _windowChrome = NullWindowChromeService.Instance;
            _colorParsing = NullColorParsingService.Instance;
            _sound = NullSoundService.Instance;
        }
    }
}

