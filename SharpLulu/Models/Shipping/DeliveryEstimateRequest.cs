using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Request for delivery estimates
/// </summary>
public class DeliveryEstimateRequest
{
    /// <summary>
    /// Destination address
    /// </summary>
    [JsonPropertyName("destination")]
    public ShippingAddress Destination { get; set; } = new();

    /// <summary>
    /// Product identifiers
    /// </summary>
    [JsonPropertyName("product_ids")]
    public List<string> ProductIds { get; set; } = new();
}