using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Request for shipping cost calculation
/// </summary>
public class ShippingCostRequest
{
    /// <summary>
    /// Shipping method identifier
    /// </summary>
    [JsonPropertyName("method_id")]
    public string MethodId { get; set; } = string.Empty;

    /// <summary>
    /// Destination address
    /// </summary>
    [JsonPropertyName("destination")]
    public ShippingAddress Destination { get; set; } = new();

    /// <summary>
    /// Items to ship
    /// </summary>
    [JsonPropertyName("items")]
    public List<ShippingItem> Items { get; set; } = new();
}