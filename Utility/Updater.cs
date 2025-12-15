using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GenieClient
{
    public static class Updater
    {
        /// <summary>
        /// Event to request user confirmation. UI layer should handle this.
        /// Return true to proceed, false to cancel.
        /// </summary>
        public static event Func<string, string, bool> ConfirmationRequested;

        /// <summary>
        /// Shows a confirmation dialog via the registered handler.
        /// Falls back to true (auto-confirm) if no handler is registered.
        /// </summary>
        private static bool RequestConfirmation(string message, string title)
        {
            return ConfirmationRequested?.Invoke(message, title) ?? true;
        }

        private static string GitHubClientReleaseURL = @"https://api.github.com/repos/GenieClient/Genie4/releases/latest";
        private static HttpClient client = new HttpClient();

        // Default GitHub repository URLs for direct downloads
        private static string DefaultMapsRepoURL = @"https://github.com/GenieClient/Maps/archive/refs/heads/main.zip";
        private static string DefaultPluginsRepoURL = @"https://github.com/GenieClient/Plugins/archive/refs/heads/main.zip";

        public static string LocalClientVersion
        {
            get
            {
                return FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Genie.exe").FileVersion;
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

        public static async Task<bool> RunUpdate()
        {
            return await Task.FromResult(false);
        }

        public static async Task<bool> UpdateToTest()
        {
            return await Task.FromResult(false);
        }

        public static async Task<bool> UpdateMaps(string mapdir)
        {
            return await DownloadAndExtractZip(DefaultMapsRepoURL, mapdir);
        }

        public static async Task<bool> UpdatePlugins(string plugindir)
        {
            return await DownloadAndExtractZip(DefaultPluginsRepoURL, plugindir);
        }

        public static async Task<bool> UpdateScripts(string scriptdir, string scriptrepo)
        {
            if (string.IsNullOrWhiteSpace(scriptrepo))
            {
                return false; // No script repo configured
            }
            return await DownloadAndExtractZip(scriptrepo, scriptdir);
        }

        public static async Task<bool> UpdateArt(string artdir, string artrepo)
        {
            if (string.IsNullOrWhiteSpace(artrepo))
            {
                return false; // No art repo configured
            }
            return await DownloadAndExtractZip(artrepo, artdir);
        }

        /// <summary>
        /// Downloads a zip file from a URL and extracts its contents to the target directory.
        /// Handles GitHub's zip structure where files are in a subdirectory like "Maps-main/".
        /// </summary>
        private static async Task<bool> DownloadAndExtractZip(string zipUrl, string targetDirectory)
        {
            try
            {
                // Ensure target directory exists
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // Download the zip file
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "Genie Client Updater");

                using var response = await client.GetAsync(zipUrl, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                // Create a temporary file to store the zip
                string tempZipPath = Path.Combine(Path.GetTempPath(), $"genie_update_{Guid.NewGuid()}.zip");

                try
                {
                    // Download to temp file
                    using (var fileStream = new FileStream(tempZipPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }

                    // Extract the zip
                    using (var archive = ZipFile.OpenRead(tempZipPath))
                    {
                        // GitHub zips have a root folder like "Maps-main", we need to extract contents from inside that
                        string rootFolder = null;

                        // Find the root folder (first entry that's a directory)
                        foreach (var entry in archive.Entries)
                        {
                            if (string.IsNullOrEmpty(entry.Name) && entry.FullName.EndsWith("/"))
                            {
                                // This is the root directory
                                rootFolder = entry.FullName;
                                break;
                            }
                        }

                        // Extract files, stripping the root folder prefix
                        foreach (var entry in archive.Entries)
                        {
                            // Skip directory entries and the root folder itself
                            if (string.IsNullOrEmpty(entry.Name))
                                continue;

                            string relativePath = entry.FullName;

                            // Strip the root folder prefix if present
                            if (rootFolder != null && relativePath.StartsWith(rootFolder))
                            {
                                relativePath = relativePath.Substring(rootFolder.Length);
                            }

                            if (string.IsNullOrEmpty(relativePath))
                                continue;

                            string destinationPath = Path.Combine(targetDirectory, relativePath);

                            // Create directory if needed
                            string destinationDir = Path.GetDirectoryName(destinationPath);
                            if (!string.IsNullOrEmpty(destinationDir) && !Directory.Exists(destinationDir))
                            {
                                Directory.CreateDirectory(destinationDir);
                            }

                            // Extract the file, overwriting if exists
                            entry.ExtractToFile(destinationPath, overwrite: true);
                        }
                    }

                    return true;
                }
                finally
                {
                    // Clean up temp file
                    if (File.Exists(tempZipPath))
                    {
                        try { File.Delete(tempZipPath); } catch { /* ignore cleanup errors */ }
                    }
                }
            }
            catch (Exception ex)
            {
                GenieError.Error("Updater", $"Error downloading/extracting from {zipUrl}", ex.Message);
                return false;
            }
        }
        public static async Task<bool> ForceUpdate()
        {
            return await Task.FromResult(false);
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
