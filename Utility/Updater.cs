using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace GenieClient
{
    public static class Updater
    {
        private static string GitHubUpdaterReleaseURL = @"https://api.github.com/repos/GenieClient/Lamp/releases/latest";
        private static string GitHubClientReleaseURL = @"https://api.github.com/repos/GenieClient/Genie4/releases/latest";
        private static string UpdaterFilename = @"Lamp.exe";
        private static string LocalUpdater = @$"{Environment.CurrentDirectory}\{UpdaterFilename}";
        private static HttpClient client = new HttpClient();

        public static string LocalUpdaterVersion
        {
            get
            {
                if (File.Exists(LocalUpdater)) return FileVersionInfo.GetVersionInfo(LocalUpdater).FileVersion;
                return "0";
            }
        }
        public static string LocalClientVersion
        {
            get
            {
                return FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Genie.exe").FileVersion;
            }
        }
        public static string ServerUpdaterVersion
        {
            get 
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Genie Client Updater");

                var streamTask = client.GetStreamAsync(GitHubUpdaterReleaseURL).Result;
                Release latest = JsonSerializer.Deserialize<Release>(streamTask);

                return latest.Version;
            }
        }
        public static string ServerClientVersion
        {
            get
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                    client.DefaultRequestHeaders.Add("User-Agent", "Genie Client Updater");

                    var streamTask = client.GetStreamAsync(GitHubClientReleaseURL).Result;
                    Release latest = JsonSerializer.Deserialize<Release>(streamTask);

                    return latest.Version;
                }
                catch
                {
                    //if we can't reach github just report current because we can't update
                    return LocalClientVersion;
                }
            }
        }

        public static bool ClientIsCurrent 
        { 
            get
            {
                return LocalClientVersion == ServerClientVersion;
            } 
        }

        public static bool UpdaterIsCurrent
        {
            get 
            {
                return LocalUpdaterVersion == ServerUpdaterVersion;
            }
        }

        public static async Task UpdateUpdater(bool autoUpdate)
        {
            if (!UpdaterIsCurrent && !autoUpdate && MessageBox.Show(@"An updated version of Lamp is available. It is recommended to update Lamp before continuing. Would you like to update now?", "Update Lamp?", MessageBoxButtons.YesNoCancel) != DialogResult.Yes) return;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Genie Client Updater");

            var streamTask = client.GetStreamAsync(GitHubUpdaterReleaseURL).Result;
            Release latest = JsonSerializer.Deserialize<Release>(streamTask);
            
            latest.LoadAssets();
            if (latest.Assets.ContainsKey(UpdaterFilename))
            {
                Asset updaterAsset = latest.Assets[UpdaterFilename];
                var response = client.GetAsync(new Uri(updaterAsset.DownloadURL)).Result;
                using (var updaterFile = new FileStream(updaterAsset.LocalFilepath, FileMode.Create))
                {
                    await response.Content.CopyToAsync(updaterFile);
                }
            }
        }

        public static async Task<bool> RunUpdate(bool autoUpdateLamp)
        {
            await UpdateUpdater(autoUpdateLamp);
            return await Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", "--a", false, true);
        }

        public static async Task<bool> UpdateToTest(bool autoUpdateLamp)
        {
            await UpdateUpdater(autoUpdateLamp);
            return await Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", "--a --t", false, true);
        }
        public static async Task<bool> UpdateMaps(string mapdir, bool autoUpdateLamp)
        {
            await UpdateUpdater(autoUpdateLamp);
            return await Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", $"--background --maps", true, false);
        }

        public static async Task<bool> UpdatePlugins(string plugindir, bool autoUpdateLamp)
        {
            await UpdateUpdater(autoUpdateLamp);
            return await Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", $"--background --plugins", true, false);
        }
        public static async Task<bool> UpdateScripts(string scriptdir, string scriptrepo, bool autoUpdateLamp)
        {
            await UpdateUpdater(autoUpdateLamp);
            return await Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", $"--background --scripts", true, false);
        }

        public static async Task<bool> UpdateArt(string artdir, string artrepo, bool autoUpdateLamp)
        {
            await UpdateUpdater(autoUpdateLamp);
            return await Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", $"--background --art", true, false);
        }
        public static async Task<bool> ForceUpdate()
        {
            await UpdateUpdater(true);
            return await Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", "--a --f", false, true);
        }
        public class Release
        {
            [JsonPropertyName("tag_name")]
            public string Version { get; set; }
            [JsonPropertyName("html_url")]
            public string ReleaseURL { get; set; }
            [JsonPropertyName("assets_url")]
            public string AssetsURL { get; set; }
            public Dictionary<string, Asset> Assets { get; set; }
            public void LoadAssets()
            {
                if (!string.IsNullOrWhiteSpace(AssetsURL))
                {
                    Assets = new Dictionary<string, Asset>();
                    
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                    client.DefaultRequestHeaders.Add("User-Agent", "Genie Client Updater");

                    var streamTask = client.GetStreamAsync(AssetsURL).Result;
                    List<Asset> latestAssets = JsonSerializer.Deserialize<List<Asset>>(streamTask);
                    foreach (Asset asset in latestAssets)
                    {
                        Assets.Add(asset.Name, asset);
                    }
                }
            }
        }
        public class Asset
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("browser_download_url")]
            public string DownloadURL { get; set; }
            public string LocalFilepath
            {
                get
                {
                    return Environment.CurrentDirectory + "\\" + Name;
                }
            }
        }

        

        

    }
}
