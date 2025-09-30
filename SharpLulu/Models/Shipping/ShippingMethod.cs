using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Available shipping method
/// </summary>
public class ShippingMethod
{
    /// <summary>
    /// Shipping method identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Display name for the shipping method
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the shipping method
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Carrier name
    /// </summary>
    [JsonPropertyName("carrier")]
    public string Carrier { get; set; } = string.Empty;

    /// <summary>
    /// Estimated delivery time in business days
    /// </summary>
    [JsonPropertyName("delivery_days")]
    public int DeliveryDays { get; set; }

    /// <summary>
    /// Whether tracking is available
    /// </summary>
    [JsonPropertyName("tracking_available")]
    public bool TrackingAvailable { get; set; }

    /// <summary>
    /// Base cost in cents
    /// </summary>
    [JsonPropertyName("base_cost")]
    public int BaseCost { get; set; }
}