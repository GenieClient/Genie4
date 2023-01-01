using System;
using System.Windows.Forms;
using System.IO;

namespace GenieClient
{
    static class LocalDirectory
    {
        public static string Path = AppDomain.CurrentDomain.BaseDirectory;
        public static bool IsLocal = true;

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
            dir = System.IO.Path.Combine(dir, Application.ProductName);
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
                if (!System.IO.Path.IsPathRooted(path)) path = Path + "\\" + path;
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