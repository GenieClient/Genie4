namespace GenieClient.Services
{
    /// <summary>
    /// Provides cross-platform audio playback.
    /// Abstracts the Windows-specific winmm.dll P/Invoke calls.
    /// </summary>
    public interface ISoundService
    {
        /// <summary>
        /// Plays a wave file from the specified path.
        /// If the path is relative, it will be resolved against the Sounds directory.
        /// </summary>
        /// <param name="filePath">Absolute or relative path to the wave file.</param>
        void PlayWaveFile(string filePath);

        /// <summary>
        /// Plays an embedded wave resource.
        /// </summary>
        /// <param name="resourceName">Name of the embedded resource.</param>
        void PlayWaveResource(string resourceName);

        /// <summary>
        /// Plays a system sound by alias name.
        /// </summary>
        /// <param name="soundAlias">System sound alias.</param>
        void PlaySystemSound(string soundAlias);

        /// <summary>
        /// Stops any currently playing sound.
        /// </summary>
        void StopPlaying();

        /// <summary>
        /// Gets whether sound is enabled.
        /// </summary>
        bool IsEnabled { get; set; }
    }
}

