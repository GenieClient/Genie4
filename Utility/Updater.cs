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
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Genie Client Updater");

                var streamTask = client.GetStreamAsync(GitHubClientReleaseURL).Result;
                Release latest = JsonSerializer.Deserialize<Release>(streamTask);

                return latest.Version;
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

        public static void UpdateUpdater()
        {
            if (UpdaterIsCurrent) return;
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
                    response.Content.CopyToAsync(updaterFile);
                }
            }
        }

        public static void RunUpdate()
        {
            UpdateUpdater();
            Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", "--a", false);
        }

        public static void UpdateToTest()
        {
            UpdateUpdater();
            Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", "--a --t", false);
        }
        public static bool UpdateMaps(string mapdir)
        {
            UpdateUpdater();
            return Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", $"--a --m|\"{mapdir}\"", true);
        }

        public static bool UpdatePlugins(string plugindir)
        {
            UpdateUpdater();
            return Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", $"--a --p|\"{plugindir}\"", true);
        }
        public static void ForceUpdate()
        {
            UpdateUpdater();
            Utility.ExecuteProcess($@"{Environment.CurrentDirectory}\{UpdaterFilename}", "--a --f", false);
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
