using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GenieClient.Services
{
    /// <summary>
    /// Windows implementation of ISoundService using winmm.dll.
    /// This will be replaced with a cross-platform implementation when needed.
    /// </summary>
    public partial class SoundService : ISoundService
    {
        private readonly IPathService _pathService;

        // Windows-specific P/Invoke
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int PlaySound(string name, int hmod, int flags);

        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int PlaySound(byte[] name, int hmod, int flags);

        private const int SND_SYNC = 0x0;
        private const int SND_ASYNC = 0x1;
        private const int SND_MEMORY = 0x4;
        private const int SND_ALIAS = 0x10000;
        private const int SND_NODEFAULT = 0x2;
        private const int SND_FILENAME = 0x20000;
        private const int SND_RESOURCE = 0x40004;
        private const int SND_PURGE = 0x40;

        public bool IsEnabled { get; set; } = true;

        public SoundService(IPathService pathService)
        {
            _pathService = pathService;
        }

        public void PlayWaveFile(string filePath)
        {
            if (!IsEnabled || string.IsNullOrEmpty(filePath))
                return;

            try
            {
                // Resolve relative paths to the Sounds directory
                if (!_pathService.IsAbsolutePath(filePath))
                {
                    filePath = _pathService.Combine(_pathService.SoundsDirectory, filePath);
                }

                // Add .wav extension if missing
                if (!Path.HasExtension(filePath))
                {
                    filePath += ".wav";
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    PlaySound(filePath, 0, SND_FILENAME | SND_ASYNC);
                }
                else
                {
                    // TODO: Implement cross-platform audio playback
                    // Could use NAudio, NetCoreAudio, or platform-specific APIs
                }
            }
            catch
            {
                // Silently fail on audio errors (matches original behavior)
            }
        }

        public void PlayWaveResource(string resourceName)
        {
            if (!IsEnabled || string.IsNullOrEmpty(resourceName))
                return;

            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var namespaceName = assembly.GetName().Name;
                var fullResourceName = $"{namespaceName}.{resourceName}";

                using var stream = assembly.GetManifestResourceStream(fullResourceName);
                if (stream == null)
                    return;

                var wavData = new byte[stream.Length];
                stream.Read(wavData, 0, (int)stream.Length);

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    PlaySound(wavData, 0, SND_ASYNC | SND_MEMORY);
                }
            }
            catch
            {
                // Silently fail on audio errors
            }
        }

        public void PlaySystemSound(string soundAlias)
        {
            if (!IsEnabled || string.IsNullOrEmpty(soundAlias))
                return;

            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    PlaySound(soundAlias, 0, SND_ALIAS | SND_ASYNC | SND_NODEFAULT);
                }
            }
            catch
            {
                // Silently fail on audio errors
            }
        }

        public void StopPlaying()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    PlaySound(string.Empty, 0, SND_NODEFAULT | SND_MEMORY);
                }
            }
            catch
            {
                // Silently fail
            }
        }
    }
}

