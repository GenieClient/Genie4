using System;
using System.Windows.Forms;

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
    }
}