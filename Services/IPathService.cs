namespace GenieClient.Services
{
    /// <summary>
    /// Provides cross-platform file path operations.
    /// Abstracts file system paths to work on Windows, macOS, and Linux.
    /// </summary>
    public interface IPathService
    {
        /// <summary>
        /// Gets the application's base directory (where the executable is located).
        /// </summary>
        string AppDirectory { get; }

        /// <summary>
        /// Gets the user's data directory (config, scripts, logs, etc.).
        /// On Windows: %APPDATA%\Genie
        /// On macOS: ~/Library/Application Support/Genie
        /// On Linux: ~/.config/Genie
        /// </summary>
        string UserDataDirectory { get; }

        /// <summary>
        /// Gets whether the application is running in "portable mode" 
        /// (config stored alongside executable).
        /// </summary>
        bool IsPortableMode { get; }

        /// <summary>
        /// Combines path segments using the correct platform separator.
        /// </summary>
        string Combine(params string[] paths);

        /// <summary>
        /// Ensures a directory exists, creating it if necessary.
        /// Returns the full path to the directory.
        /// </summary>
        string EnsureDirectory(string path);

        /// <summary>
        /// Gets the config directory path.
        /// </summary>
        string ConfigDirectory { get; }

        /// <summary>
        /// Gets the scripts directory path.
        /// </summary>
        string ScriptsDirectory { get; }

        /// <summary>
        /// Gets the logs directory path.
        /// </summary>
        string LogsDirectory { get; }

        /// <summary>
        /// Gets the sounds directory path.
        /// </summary>
        string SoundsDirectory { get; }

        /// <summary>
        /// Gets the maps directory path.
        /// </summary>
        string MapsDirectory { get; }

        /// <summary>
        /// Gets the plugins directory path.
        /// </summary>
        string PluginsDirectory { get; }

        /// <summary>
        /// Normalizes a path to use the correct platform separator.
        /// Converts both forward and back slashes to the platform default.
        /// </summary>
        string NormalizePath(string path);

        /// <summary>
        /// Checks if a path is absolute or relative.
        /// </summary>
        bool IsAbsolutePath(string path);

        /// <summary>
        /// Gets the full path, resolving relative paths against the user data directory.
        /// </summary>
        string GetFullPath(string path);
    }
}

