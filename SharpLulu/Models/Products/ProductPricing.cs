using System.Text.Json.Serialization;

namespace SharpLulu.Models.Products;

/// <summary>
/// Product pricing information
/// </summary>
public class ProductPricing
{
    /// <summary>
    /// Base price in cents
    /// </summary>
    [JsonPropertyName("base_price")]
    public int BasePrice { get; set; }

    /// <summary>
    /// Currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Price per page in cents
    /// </summary>
    [JsonPropertyName("price_per_page")]
    public int PricePerPage { get; set; }

    /// <summary>
    /// Quantity-based pricing tiers
    /// </summary>
    [JsonPropertyName("quantity_discounts")]
    public List<QuantityDiscount>? QuantityDiscounts { get; set; }
}