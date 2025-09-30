using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// PDF file data for printing
/// </summary>
public class PdfData
{
    /// <summary>
    /// Base64-encoded PDF content
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Original filename
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// File size in bytes
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    /// MD5 hash of the file content
    /// </summary>
    [JsonPropertyName("md5")]
    public string? Md5 { get; set; }
}