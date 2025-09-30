using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Billing information
/// </summary>
public class BillingInfo
{
    /// <summary>
    /// Same as shipping address
    /// </summary>
    [JsonPropertyName("same_as_shipping")]
    public bool SameAsShipping { get; set; }

    /// <summary>
    /// Billing name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Billing address (if different from shipping)
    /// </summary>
    [JsonPropertyName("address")]
    public ShippingInfo? Address { get; set; }
}