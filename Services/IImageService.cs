using System;
using System.IO;
using System.Threading.Tasks;

namespace GenieClient.Services
{
    /// <summary>
    /// Specifies the format for saving images.
    /// </summary>
    public enum GenieImageFormat
    {
        Png,
        Jpeg,
        Gif,
        Bmp,
        Webp
    }

    /// <summary>
    /// Represents a platform-agnostic image.
    /// </summary>
    public interface IGenieImage : IDisposable
    {
        /// <summary>
        /// Gets the width of the image in pixels.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the height of the image in pixels.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Saves the image to a file.
        /// </summary>
        /// <param name="path">File path to save to.</param>
        /// <param name="format">Image format.</param>
        void Save(string path, GenieImageFormat format = GenieImageFormat.Png);

        /// <summary>
        /// Converts the image to a stream.
        /// </summary>
        /// <param name="format">Image format for encoding.</param>
        /// <returns>A stream containing the encoded image data.</returns>
        Stream ToStream(GenieImageFormat format = GenieImageFormat.Png);

        /// <summary>
        /// Creates a scaled copy of the image.
        /// </summary>
        /// <param name="width">Target width.</param>
        /// <param name="height">Target height.</param>
        /// <returns>A new scaled image.</returns>
        IGenieImage Scale(int width, int height);

        /// <summary>
        /// Gets the underlying native image object (for platform-specific operations).
        /// On Windows: System.Drawing.Image
        /// On SkiaSharp: SKBitmap
        /// </summary>
        object NativeImage { get; }
    }

    /// <summary>
    /// Provides cross-platform image loading and manipulation.
    /// Abstracts System.Drawing.Image for Windows and SkiaSharp for cross-platform.
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Loads an image from a file path.
        /// </summary>
        /// <param name="path">Path to the image file.</param>
        /// <returns>The loaded image, or null if loading fails.</returns>
        IGenieImage? LoadFromFile(string path);

        /// <summary>
        /// Loads an image from a file path asynchronously.
        /// </summary>
        /// <param name="path">Path to the image file.</param>
        /// <returns>The loaded image, or null if loading fails.</returns>
        Task<IGenieImage?> LoadFromFileAsync(string path);

        /// <summary>
        /// Loads an image from a stream.
        /// </summary>
        /// <param name="stream">Stream containing image data.</param>
        /// <returns>The loaded image, or null if loading fails.</returns>
        IGenieImage? LoadFromStream(Stream stream);

        /// <summary>
        /// Loads an image from a stream asynchronously.
        /// </summary>
        /// <param name="stream">Stream containing image data.</param>
        /// <returns>The loaded image, or null if loading fails.</returns>
        Task<IGenieImage?> LoadFromStreamAsync(Stream stream);

        /// <summary>
        /// Downloads and loads an image from a URL.
        /// </summary>
        /// <param name="url">URL of the image.</param>
        /// <returns>The loaded image, or null if download/loading fails.</returns>
        Task<IGenieImage?> LoadFromUrlAsync(string url);

        /// <summary>
        /// Creates an empty image with the specified dimensions.
        /// </summary>
        /// <param name="width">Image width in pixels.</param>
        /// <param name="height">Image height in pixels.</param>
        /// <returns>A new empty image.</returns>
        IGenieImage CreateEmpty(int width, int height);

        /// <summary>
        /// Scales an existing image to new dimensions.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="maxWidth">Maximum width.</param>
        /// <param name="maxHeight">Maximum height.</param>
        /// <param name="maintainAspectRatio">Whether to maintain aspect ratio.</param>
        /// <returns>A new scaled image.</returns>
        IGenieImage Scale(IGenieImage image, int maxWidth, int maxHeight, bool maintainAspectRatio = true);
    }
}

