using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

        private static async Task<System.IO.Stream> GetGitHubStreamAsync(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Remove("User-Agent");
            client.DefaultRequestHeaders.Add("User-Agent", "Genie Client Updater");

            return await client.GetStreamAsync(url).ConfigureAwait(false);
        }

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
                try
                {
                    return GetServerUpdaterVersionAsync().GetAwaiter().GetResult();
                }
                catch
                {
                    return LocalUpdaterVersion;
                }
            }
        }
        public static string ServerClientVersion
        {
            get
            {
                try
                {
                    return GetServerClientVersionAsync().GetAwaiter().GetResult();
                }
                catch
                {
                    // if we can't reach github just report current because we can't update
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
            Release latest = await GetReleaseAsync(GitHubUpdaterReleaseURL).ConfigureAwait(false);
            await latest.LoadAssetsAsync().ConfigureAwait(false);
            if (latest.Assets.ContainsKey(UpdaterFilename))
            {
                Asset updaterAsset = latest.Assets[UpdaterFilename];

                // Kill any running Lamp process before overwriting the file
                foreach (var proc in System.Diagnostics.Process.GetProcessesByName("Lamp"))
                {
                    try { proc.Kill(); proc.WaitForExit(3000); } catch { }
                }

                using (var response = await client.GetAsync(new Uri(updaterAsset.DownloadURL)).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    using (var updaterFile = new FileStream(updaterAsset.LocalFilepath, FileMode.Create))
                    {
                        await response.Content.CopyToAsync(updaterFile).ConfigureAwait(false);
                    }
                }

                // Integrity check: if a corresponding .sha256 asset exists, verify it
                string checksumAssetName = UpdaterFilename + ".sha256";
                if (latest.Assets.ContainsKey(checksumAssetName))
                {
                    Asset checksumAsset = latest.Assets[checksumAssetName];
                    string remoteHash;
                    using (var resp = await client.GetAsync(new Uri(checksumAsset.DownloadURL)).ConfigureAwait(false))
                    {
                        resp.EnsureSuccessStatusCode();
                        remoteHash = (await resp.Content.ReadAsStringAsync().ConfigureAwait(false)).Trim();
                    }

                    // remote file may include filename; extract first token that looks like hex
                    var token = remoteHash.Split(new[] {' ', '\t', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? string.Empty;
                    token = token.Trim();

                    using (var fs = File.OpenRead(updaterAsset.LocalFilepath))
                    using (var sha = SHA256.Create())
                    {
                        var localHashBytes = sha.ComputeHash(fs);
                        var localHash = BitConverter.ToString(localHashBytes).Replace("-", "").ToLowerInvariant();
                        if (!string.IsNullOrEmpty(token) && !localHash.Equals(token, StringComparison.OrdinalIgnoreCase))
                        {
                            // verification failed
                            File.Delete(updaterAsset.LocalFilepath);
                            throw new InvalidOperationException("Updater integrity check failed: checksum mismatch.");
                        }
                    }
                }
            }
        }

        private static async Task<string> GetServerUpdaterVersionAsync()
        {
            Release latest = await GetReleaseAsync(GitHubUpdaterReleaseURL).ConfigureAwait(false);
            return latest.Version?.TrimStart('v') ?? "0";
        }

        private static async Task<string> GetServerClientVersionAsync()
        {
            Release latest = await GetReleaseAsync(GitHubClientReleaseURL).ConfigureAwait(false);
            return latest.Version?.TrimStart('v') ?? "0";
        }

        private static async Task<Release> GetReleaseAsync(string releaseUrl)
        {
            using (var stream = await GetGitHubStreamAsync(releaseUrl).ConfigureAwait(false))
            {
                return JsonSerializer.Deserialize<Release>(stream);
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
                // synchronous wrapper
                LoadAssetsAsync().GetAwaiter().GetResult();
            }

            public async Task LoadAssetsAsync()
            {
                if (!string.IsNullOrWhiteSpace(AssetsURL))
                {
                    Assets = new Dictionary<string, Asset>();
                    using (var stream = await GetGitHubStreamAsync(AssetsURL).ConfigureAwait(false))
                    {
                        List<Asset> latestAssets = JsonSerializer.Deserialize<List<Asset>>(stream);
                        foreach (Asset asset in latestAssets)
                        {
                            Assets.Add(asset.Name, asset);
                        }
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
