using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Represents a print order
/// </summary>
public class Order
{
    /// <summary>
    /// Unique identifier for the order
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Order reference number
    /// </summary>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <summary>
    /// Current order status
    /// </summary>
    [JsonPropertyName("status")]
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Order items
    /// </summary>
    [JsonPropertyName("items")]
    public List<OrderItem> Items { get; set; } = new();

    /// <summary>
    /// Shipping information
    /// </summary>
    [JsonPropertyName("shipping")]
    public ShippingInfo? Shipping { get; set; }

    /// <summary>
    /// Billing information
    /// </summary>
    [JsonPropertyName("billing")]
    public BillingInfo? Billing { get; set; }

    /// <summary>
    /// Order total in cents
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// Currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Date and time when the order was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the order was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Tracking information
    /// </summary>
    [JsonPropertyName("tracking")]
    public OrderTracking? Tracking { get; set; }
}