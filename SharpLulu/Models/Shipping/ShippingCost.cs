using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Shipping cost calculation
/// </summary>
public class ShippingCost
{
    /// <summary>
    /// Shipping method identifier
    /// </summary>
    [JsonPropertyName("method_id")]
    public string MethodId { get; set; } = string.Empty;

    /// <summary>
    /// Total shipping cost in cents
    /// </summary>
    [JsonPropertyName("cost")]
    public int Cost { get; set; }

    /// <summary>
    /// Currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Cost breakdown
    /// </summary>
    [JsonPropertyName("breakdown")]
    public ShippingCostBreakdown? Breakdown { get; set; }
}