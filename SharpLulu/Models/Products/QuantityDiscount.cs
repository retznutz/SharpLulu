using System.Text.Json.Serialization;

namespace SharpLulu.Models.Products;

/// <summary>
/// Quantity-based discount information
/// </summary>
public class QuantityDiscount
{
    /// <summary>
    /// Minimum quantity for this discount
    /// </summary>
    [JsonPropertyName("min_quantity")]
    public int MinQuantity { get; set; }

    /// <summary>
    /// Discount percentage (0.0 to 1.0)
    /// </summary>
    [JsonPropertyName("discount_percentage")]
    public double DiscountPercentage { get; set; }
}