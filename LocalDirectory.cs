using GenieClient.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace GenieClient
{
    static class LocalDirectory
    {
        public static string Path = Application.StartupPath;
        public static bool IsLocal = true;
        public static string SettingsPath { get { return Path + FileName; } }

        public static string FileName = "appsettings." + Environment.MachineName + ".json";
        public static void ConfigureUserDirectory()
        {
            try
            {
                // If there's a machine specific local appsettings, that's our default
                if (File.Exists(SettingsPath)) return;

                // If there's not, look for a local appsettings
                FileName = "appsettings.json";
                if (File.Exists(SettingsPath)) return;

                //repeat this search in the appdata folder
                FileName = "appsettings." + Environment.MachineName + ".json";
                Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Application.ProductName;
                IsLocal = false;

                if (File.Exists(SettingsPath)) return;
                FileName = "appsettings.json";
            
                if (!File.Exists(SettingsPath))
                {
                    FileName = "appsettings." + Environment.MachineName + ".json";
                    CreateDefaultUserDataDirectory();
                }
            }
            finally
            {

            }
        }

        private static void CreateDefaultUserDataDirectory()
        {
            if(!Application.StartupPath.Contains(@":\Program Files"))
            {
                Path = Application.StartupPath;
                IsLocal = true;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(SettingsPath, new FileStreamOptions()))
                {
                    sw.Write(GenieSettingsService.GenerateDefaultAppSettings());
                }
            }
            catch (Exception ex)
            {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Application.ProductName;
                IsLocal = false;
                using (StreamWriter sw = new StreamWriter(SettingsPath, new FileStreamOptions()))
                {
                    sw.Write(GenieSettingsService.GenerateDefaultAppSettings());
                }
            }
        }
    }
}