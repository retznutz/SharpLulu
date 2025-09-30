using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Print facility information
/// </summary>
public class PrintFacility
{
    /// <summary>
    /// Facility identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Facility name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Country code
    /// </summary>
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// City
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Supported product types
    /// </summary>
    [JsonPropertyName("supported_products")]
    public List<string> SupportedProducts { get; set; } = new();

    /// <summary>
    /// Average production time in days
    /// </summary>
    [JsonPropertyName("avg_production_days")]
    public int AvgProductionDays { get; set; }

    /// <summary>
    /// Whether facility is currently active
    /// </summary>
    [JsonPropertyName("active")]
    public bool Active { get; set; }
}