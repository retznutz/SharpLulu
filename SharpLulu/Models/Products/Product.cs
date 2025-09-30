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