using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// PDF metadata
/// </summary>
public class PdfMetadata
{
    /// <summary>
    /// Number of pages
    /// </summary>
    [JsonPropertyName("page_count")]
    public int PageCount { get; set; }

    /// <summary>
    /// File size in bytes
    /// </summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }

    /// <summary>
    /// PDF version
    /// </summary>
    [JsonPropertyName("pdf_version")]
    public string? PdfVersion { get; set; }

    /// <summary>
    /// Color profile
    /// </summary>
    [JsonPropertyName("color_profile")]
    public string? ColorProfile { get; set; }

    /// <summary>
    /// Resolution in DPI
    /// </summary>
    [JsonPropertyName("resolution")]
    public int? Resolution { get; set; }

    /// <summary>
    /// Whether the PDF contains fonts
    /// </summary>
    [JsonPropertyName("embedded_fonts")]
    public bool EmbeddedFonts { get; set; }

    /// <summary>
    /// Whether the PDF contains images
    /// </summary>
    [JsonPropertyName("contains_images")]
    public bool ContainsImages { get; set; }
}