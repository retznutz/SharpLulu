using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Represents an item in an order
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Item identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Project identifier (if applicable)
    /// </summary>
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }

    /// <summary>
    /// Quantity ordered
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Unit price in cents
    /// </summary>
    [JsonPropertyName("unit_price")]
    public int UnitPrice { get; set; }

    /// <summary>
    /// Total price for this item in cents
    /// </summary>
    [JsonPropertyName("total_price")]
    public int TotalPrice { get; set; }

    /// <summary>
    /// Product configuration
    /// </summary>
    [JsonPropertyName("configuration")]
    public ProductConfiguration? Configuration { get; set; }

    /// <summary>
    /// Current status of this item
    /// </summary>
    [JsonPropertyName("status")]
    public OrderItemStatus Status { get; set; }
}