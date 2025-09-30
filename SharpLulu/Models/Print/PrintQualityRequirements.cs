using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Print quality requirements for a product
/// </summary>
public class PrintQualityRequirements
{
    /// <summary>
    /// Product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Minimum resolution in DPI
    /// </summary>
    [JsonPropertyName("min_resolution")]
    public int MinResolution { get; set; }

    /// <summary>
    /// Maximum file size in bytes
    /// </summary>
    [JsonPropertyName("max_file_size")]
    public long MaxFileSize { get; set; }

    /// <summary>
    /// Supported color profiles
    /// </summary>
    [JsonPropertyName("color_profiles")]
    public List<string> ColorProfiles { get; set; } = new();

    /// <summary>
    /// Required bleed area in points
    /// </summary>
    [JsonPropertyName("bleed_area")]
    public double BleedArea { get; set; }

    /// <summary>
    /// Safe area margin in points
    /// </summary>
    [JsonPropertyName("safe_area")]
    public double SafeArea { get; set; }

    /// <summary>
    /// Whether fonts must be embedded
    /// </summary>
    [JsonPropertyName("fonts_embedded")]
    public bool FontsEmbedded { get; set; }

    /// <summary>
    /// Supported PDF versions
    /// </summary>
    [JsonPropertyName("pdf_versions")]
    public List<string> PdfVersions { get; set; } = new();
}