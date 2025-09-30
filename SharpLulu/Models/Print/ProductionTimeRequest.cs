using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Production time estimate request
/// </summary>
public class ProductionTimeRequest
{
    /// <summary>
    /// Product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Quantity to produce
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Preferred facility (optional)
    /// </summary>
    [JsonPropertyName("facility_id")]
    public string? FacilityId { get; set; }

    /// <summary>
    /// Rush order flag
    /// </summary>
    [JsonPropertyName("rush_order")]
    public bool RushOrder { get; set; }
}