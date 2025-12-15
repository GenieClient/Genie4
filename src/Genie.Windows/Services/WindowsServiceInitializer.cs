using GenieClient.Services;

namespace GenieClient.Windows.Services
{
    /// <summary>
    /// Initializes all Windows-specific services.
    /// Call this at application startup before using any services.
    /// </summary>
    public static class WindowsServiceInitializer
    {
        private static bool _initialized = false;

        /// <summary>
        /// Initializes all Windows-specific services and registers them with GenieServices.
        /// </summary>
        /// <param name="pathService">The path service for resolving directories.</param>
        public static void Initialize(IPathService? pathService = null)
        {
            if (_initialized)
                return;

            // Register Windows implementations
            GenieServices.WindowAttention = new WindowsAttentionService();
            GenieServices.RichText = new WindowsRichTextService();
            GenieServices.Image = new WindowsImageService();
            GenieServices.WindowChrome = new WindowsChromeService();
            GenieServices.ColorParsing = new WindowsColorParsingService();

            // Sound service needs path service - use existing SoundService if available
            if (pathService != null)
            {
                GenieServices.Sound = new SoundService(pathService);
            }

            _initialized = true;
        }

        /// <summary>
        /// Resets initialization state (for testing).
        /// </summary>
        public static void Reset()
        {
            _initialized = false;
            GenieServices.Reset();
        }
    }
}

