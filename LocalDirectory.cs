using System;
using System.IO;
using System.Reflection;

namespace GenieClient
{
    /// <summary>
    /// Manages local directory paths for the application.
    /// Cross-platform compatible.
    /// </summary>
    static class LocalDirectory
    {
        public static string Path = AppDomain.CurrentDomain.BaseDirectory;
        public static bool IsLocal = true;

        /// <summary>
        /// Gets the product name from assembly attributes (cross-platform alternative to Windows Forms).
        /// </summary>
        private static string ProductName
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var attribute = assembly.GetCustomAttribute<AssemblyProductAttribute>();
                return attribute?.Product ?? assembly.GetName().Name ?? "GenieClient";
            }
        }

        public static void CheckUserDirectory()
        {
            string dir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
            if (!System.IO.Directory.Exists(dir))
            {
                // No local settings, change to user data directory
                SetUserDataDirectory();
            }
        }

        public static void SetUserDataDirectory()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir = System.IO.Path.Combine(dir, ProductName);
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            Path = dir;
            IsLocal = false;
        }

        public static string ValidateDirectory(string path)
        {
            try
            {
                if (!System.IO.Path.IsPathRooted(path)) path = System.IO.Path.Combine(Path, path);
                DirectoryInfo directory = new DirectoryInfo(path);
                if (!directory.Exists)
                {
                    directory.Create();
                    return $"Directory Created: {directory.FullName}";
                }
                return $"Diretory Found: {directory.FullName}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Setting Directory: {ex.Message}");
            }
        }
    }
}