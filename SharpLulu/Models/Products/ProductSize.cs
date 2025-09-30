using System.Text.Json.Serialization;

namespace SharpLulu.Models.Products;

/// <summary>
/// Product size information
/// </summary>
public class ProductSize
{
    /// <summary>
    /// Size identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Display name for the size
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Width in inches
    /// </summary>
    [JsonPropertyName("width_inches")]
    public double WidthInches { get; set; }

    /// <summary>
    /// Height in inches
    /// </summary>
    [JsonPropertyName("height_inches")]
    public double HeightInches { get; set; }

    /// <summary>
    /// Width in millimeters
    /// </summary>
    [JsonPropertyName("width_mm")]
    public double WidthMm { get; set; }

    /// <summary>
    /// Height in millimeters
    /// </summary>
    [JsonPropertyName("height_mm")]
    public double HeightMm { get; set; }
}