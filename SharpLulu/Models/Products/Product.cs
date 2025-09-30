using System.Text.Json.Serialization;

namespace SharpLulu.Models.Products;

/// <summary>
/// Represents a product in the Lulu catalog
/// </summary>
public class Product
{
    /// <summary>
    /// Unique identifier for the product
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Product name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Product description
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Product category
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Product type (e.g., book, magazine, calendar)
    /// </summary>
    [JsonPropertyName("type")]
    public ProductType Type { get; set; }

    /// <summary>
    /// Available sizes for this product
    /// </summary>
    [JsonPropertyName("sizes")]
    public List<ProductSize> Sizes { get; set; } = new();

    /// <summary>
    /// Available paper types
    /// </summary>
    [JsonPropertyName("paper_types")]
    public List<string> PaperTypes { get; set; } = new();

    /// <summary>
    /// Available binding types
    /// </summary>
    [JsonPropertyName("binding_types")]
    public List<string> BindingTypes { get; set; } = new();

    /// <summary>
    /// Pricing information
    /// </summary>
    [JsonPropertyName("pricing")]
    public ProductPricing? Pricing { get; set; }

    /// <summary>
    /// Minimum page count for this product
    /// </summary>
    [JsonPropertyName("min_pages")]
    public int MinPages { get; set; }

    /// <summary>
    /// Maximum page count for this product
    /// </summary>
    [JsonPropertyName("max_pages")]
    public int MaxPages { get; set; }

    /// <summary>
    /// Whether this product is available for printing
    /// </summary>
    [JsonPropertyName("available")]
    public bool Available { get; set; }
}

/// <summary>
/// Product size information
/// </summary>
public class ProductSize
{
    /// <summary>
    /// Size identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Display name for the size
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Width in inches
    /// </summary>
    [JsonPropertyName("width_inches")]
    public double WidthInches { get; set; }

    /// <summary>
    /// Height in inches
    /// </summary>
    [JsonPropertyName("height_inches")]
    public double HeightInches { get; set; }

    /// <summary>
    /// Width in millimeters
    /// </summary>
    [JsonPropertyName("width_mm")]
    public double WidthMm { get; set; }

    /// <summary>
    /// Height in millimeters
    /// </summary>
    [JsonPropertyName("height_mm")]
    public double HeightMm { get; set; }
}

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

/// <summary>
/// Product type enumeration
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductType
{
    /// <summary>
    /// Standard book
    /// </summary>
    Book,

    /// <summary>
    /// Magazine or periodical
    /// </summary>
    Magazine,

    /// <summary>
    /// Calendar
    /// </summary>
    Calendar,

    /// <summary>
    /// Poster
    /// </summary>
    Poster,

    /// <summary>
    /// Journal or notebook
    /// </summary>
    Journal,

    /// <summary>
    /// Photo book
    /// </summary>
    PhotoBook,

    /// <summary>
    /// Cookbook
    /// </summary>
    Cookbook
}