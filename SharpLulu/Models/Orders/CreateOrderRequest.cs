using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Request model for creating a new order
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// Optional order reference number
    /// </summary>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <summary>
    /// Order items to be printed
    /// </summary>
    [JsonPropertyName("items")]
    public List<CreateOrderItemRequest> Items { get; set; } = new();

    /// <summary>
    /// Shipping information
    /// </summary>
    [JsonPropertyName("shipping")]
    public ShippingInfo Shipping { get; set; } = new();

    /// <summary>
    /// Billing information
    /// </summary>
    [JsonPropertyName("billing")]
    public BillingInfo? Billing { get; set; }

    /// <summary>
    /// Whether this is a test order (sandbox only)
    /// </summary>
    [JsonPropertyName("test_order")]
    public bool TestOrder { get; set; }
}