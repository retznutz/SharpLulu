using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Item to ship
/// </summary>
public class ShippingItem
{
    /// <summary>
    /// Product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Weight per item in grams
    /// </summary>
    [JsonPropertyName("weight_grams")]
    public int WeightGrams { get; set; }
}