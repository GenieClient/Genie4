using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GenieClient.Services;

namespace GenieClient.Windows.Services
{
    /// <summary>
    /// Windows image wrapper implementing IGenieImage using System.Drawing.Image.
    /// </summary>
    public sealed class WindowsGenieImage : IGenieImage
    {
        private Image _image;
        private bool _disposed;

        public WindowsGenieImage(Image image)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
        }

        public int Width => _image.Width;
        public int Height => _image.Height;
        public object NativeImage => _image;

        public void Save(string path, GenieImageFormat format = GenieImageFormat.Png)
        {
            _image.Save(path, GetImageFormat(format));
        }

        public Stream ToStream(GenieImageFormat format = GenieImageFormat.Png)
        {
            var stream = new MemoryStream();
            _image.Save(stream, GetImageFormat(format));
            stream.Position = 0;
            return stream;
        }

        public IGenieImage Scale(int width, int height)
        {
            var scaled = new Bitmap(width, height);
            using (var g = Graphics.FromImage(scaled))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(_image, 0, 0, width, height);
            }
            return new WindowsGenieImage(scaled);
        }

        private static System.Drawing.Imaging.ImageFormat GetImageFormat(GenieImageFormat format)
        {
            return format switch
            {
                GenieImageFormat.Png => System.Drawing.Imaging.ImageFormat.Png,
                GenieImageFormat.Jpeg => System.Drawing.Imaging.ImageFormat.Jpeg,
                GenieImageFormat.Gif => System.Drawing.Imaging.ImageFormat.Gif,
                GenieImageFormat.Bmp => System.Drawing.Imaging.ImageFormat.Bmp,
                _ => System.Drawing.Imaging.ImageFormat.Png
            };
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _image.Dispose();
                _disposed = true;
            }
        }
    }

    /// <summary>
    /// Windows implementation of IImageService using System.Drawing.
    /// </summary>
    public sealed class WindowsImageService : IImageService
    {
        private static readonly HttpClient _httpClient = new();

        public IGenieImage? LoadFromFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return null;

                var image = Image.FromFile(path);
                return new WindowsGenieImage(image);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IGenieImage?> LoadFromFileAsync(string path)
        {
            return await Task.Run(() => LoadFromFile(path));
        }

        public IGenieImage? LoadFromStream(Stream stream)
        {
            try
            {
                var image = Image.FromStream(stream);
                return new WindowsGenieImage(image);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IGenieImage?> LoadFromStreamAsync(Stream stream)
        {
            return await Task.Run(() => LoadFromStream(stream));
        }

        public async Task<IGenieImage?> LoadFromUrlAsync(string url)
        {
            try
            {
                using var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                // Copy to memory stream since we need to keep the data
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var image = Image.FromStream(memoryStream);
                return new WindowsGenieImage(image);
            }
            catch
            {
                return null;
            }
        }

        public IGenieImage CreateEmpty(int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            return new WindowsGenieImage(bitmap);
        }

        public IGenieImage Scale(IGenieImage image, int maxWidth, int maxHeight, bool maintainAspectRatio = true)
        {
            if (image is not WindowsGenieImage windowsImage)
            {
                return new NullGenieImage(maxWidth, maxHeight);
            }

            var sourceImage = (Image)windowsImage.NativeImage;
            int targetWidth = maxWidth;
            int targetHeight = maxHeight;

            if (maintainAspectRatio)
            {
                double ratioX = (double)maxWidth / sourceImage.Width;
                double ratioY = (double)maxHeight / sourceImage.Height;
                double ratio = Math.Min(ratioX, ratioY);

                targetWidth = (int)(sourceImage.Width * ratio);
                targetHeight = (int)(sourceImage.Height * ratio);
            }

            var scaled = new Bitmap(targetWidth, targetHeight);
            using (var g = Graphics.FromImage(scaled))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(sourceImage, 0, 0, targetWidth, targetHeight);
            }

            return new WindowsGenieImage(scaled);
        }
    }
}

