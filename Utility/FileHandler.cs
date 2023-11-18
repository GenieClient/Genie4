using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;


namespace GenieClient
{
    internal static class FileHandler
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static string GetFileVersion(string filename)
        {
            return FileVersionInfo.GetVersionInfo(filename).FileVersion;
        }
        public static async Task<MemoryStream> DownloadToMemoryStream(string downloadURL)
        {
            SafeDownloadToMemoryStreamDelegate threadSafeCall = SafeDownloadToMemoryStream;
            var memoryStream = Task.Run(() => threadSafeCall.Invoke(downloadURL));
            return await memoryStream;
        }
        delegate Task<MemoryStream> SafeDownloadToMemoryStreamDelegate(string downloadURL);
        private static async Task<MemoryStream> SafeDownloadToMemoryStream(string downloadURL)
        {
            try
            {
                Console.Write($"Downloading {downloadURL}");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Genie Client Updater");
                var response = _httpClient.GetAsync(new Uri(downloadURL)).Result;
                if(response.RequestMessage.RequestUri.AbsolutePath == @"/error.asp") return new MemoryStream();
                MemoryStream memoryStream = new MemoryStream();
                await response.Content.CopyToAsync(memoryStream);
                return memoryStream;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                string s = ex.Message;
                return new MemoryStream();
            }
        }

        public static async Task<bool> FetchImage(string filename)
        {
            string cachedFile = Path.Combine(LocalDirectory.Path, "Art", filename);
            if (File.Exists(cachedFile)) return true;
            using (MemoryStream imageStream = await FileHandler.DownloadToMemoryStream($@"https://www.play.net/bfe/DR-art/{filename}"))
            { 
                if (imageStream.Length > 0)
                {
                    LocalDirectory.ValidateDirectory(Path.GetDirectoryName(cachedFile));
                    using (FileStream file = new FileStream(cachedFile, FileMode.Create))
                    {
                        imageStream.Position = 0;
                        imageStream.WriteTo(file);
                    }
                }
            }
            return File.Exists(cachedFile);
        }

        public static async Task<Image> GetImage(string filename, int width, int height)
        {
            string cachedFile = Path.Combine(LocalDirectory.Path, "Art", filename);
            if (!File.Exists(cachedFile)) return null;
            
            System.Drawing.Image image = Image.FromFile(cachedFile);
            int h = height > 0 ? height : image.Height;
            int w = width > 0 ? width : image.Width;
            image = (Image)new Bitmap(image, new Size(w, h));
            return image;
        }
    }
}
