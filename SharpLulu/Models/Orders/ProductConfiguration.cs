using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Product configuration for an order item
/// </summary>
public class ProductConfiguration
{
    /// <summary>
    /// Size identifier
    /// </summary>
    [JsonPropertyName("size_id")]
    public string SizeId { get; set; } = string.Empty;

    /// <summary>
    /// Paper type
    /// </summary>
    [JsonPropertyName("paper_type")]
    public string? PaperType { get; set; }

    /// <summary>
    /// Binding type
    /// </summary>
    [JsonPropertyName("binding_type")]
    public string? BindingType { get; set; }

    /// <summary>
    /// Number of pages
    /// </summary>
    [JsonPropertyName("page_count")]
    public int PageCount { get; set; }

    /// <summary>
    /// Cover finish
    /// </summary>
    [JsonPropertyName("cover_finish")]
    public string? CoverFinish { get; set; }

    /// <summary>
    /// Interior paper color
    /// </summary>
    [JsonPropertyName("interior_color")]
    public string? InteriorColor { get; set; }
}