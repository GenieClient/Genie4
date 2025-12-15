using System;
using System.IO;
using System.Runtime.InteropServices;

namespace GenieClient.Services
{
    /// <summary>
    /// Cross-platform implementation of IPathService.
    /// </summary>
    public class PathService : IPathService
    {
        private readonly string _appDirectory;
        private readonly string _userDataDirectory;
        private readonly bool _isPortableMode;

        public PathService()
        {
            _appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            
            // Check for portable mode: if a Config folder exists next to the exe, use portable mode
            var portableConfigPath = Path.Combine(_appDirectory, "Config");
            _isPortableMode = Directory.Exists(portableConfigPath);

            if (_isPortableMode)
            {
                _userDataDirectory = _appDirectory;
            }
            else
            {
                _userDataDirectory = GetPlatformUserDataDirectory();
                EnsureDirectory(_userDataDirectory);
            }
        }

        public string AppDirectory => _appDirectory;
        public string UserDataDirectory => _userDataDirectory;
        public bool IsPortableMode => _isPortableMode;

        public string ConfigDirectory => EnsureDirectory(Combine(UserDataDirectory, "Config"));
        public string ScriptsDirectory => EnsureDirectory(Combine(UserDataDirectory, "Scripts"));
        public string LogsDirectory => EnsureDirectory(Combine(UserDataDirectory, "Logs"));
        public string SoundsDirectory => EnsureDirectory(Combine(UserDataDirectory, "Sounds"));
        public string MapsDirectory => EnsureDirectory(Combine(UserDataDirectory, "Maps"));
        public string PluginsDirectory => EnsureDirectory(Combine(UserDataDirectory, "Plugins"));

        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        public string EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public string NormalizePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return path;

            // Convert to platform-appropriate separators
            if (Path.DirectorySeparatorChar == '/')
            {
                return path.Replace('\\', '/');
            }
            else
            {
                return path.Replace('/', '\\');
            }
        }

        public bool IsAbsolutePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            return Path.IsPathRooted(path);
        }

        public string GetFullPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return UserDataDirectory;

            path = NormalizePath(path);

            if (IsAbsolutePath(path))
                return path;

            return Combine(UserDataDirectory, path);
        }

        private static string GetPlatformUserDataDirectory()
        {
            string appName = "Genie";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Windows: %APPDATA%\Genie
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(appData, appName);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // macOS: ~/Library/Application Support/Genie
                var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return Path.Combine(home, "Library", "Application Support", appName);
            }
            else
            {
                // Linux and others: ~/.config/Genie
                var configHome = Environment.GetEnvironmentVariable("XDG_CONFIG_HOME");
                if (string.IsNullOrEmpty(configHome))
                {
                    var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    configHome = Path.Combine(home, ".config");
                }
                return Path.Combine(configHome, appName);
            }
        }
    }
}

