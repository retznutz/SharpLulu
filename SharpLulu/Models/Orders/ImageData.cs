using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Image data for covers or illustrations
/// </summary>
public class ImageData
{
    /// <summary>
    /// Base64-encoded image content
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Original filename
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// MIME type (e.g., image/jpeg, image/png)
    /// </summary>
    [JsonPropertyName("mime_type")]
    public string MimeType { get; set; } = string.Empty;

    /// <summary>
    /// File size in bytes
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    /// Image width in pixels
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// Image height in pixels
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
}