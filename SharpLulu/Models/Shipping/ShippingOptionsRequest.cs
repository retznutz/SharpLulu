using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Request for shipping options
/// </summary>
public class ShippingOptionsRequest
{
    /// <summary>
    /// Destination country code
    /// </summary>
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Destination state/province
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Destination postal code
    /// </summary>
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Product identifiers to ship
    /// </summary>
    [JsonPropertyName("product_ids")]
    public List<string> ProductIds { get; set; } = new();

    /// <summary>
    /// Total weight in grams
    /// </summary>
    [JsonPropertyName("weight_grams")]
    public int? WeightGrams { get; set; }
}