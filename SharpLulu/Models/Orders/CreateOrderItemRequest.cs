using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Request model for creating an order item
/// </summary>
public class CreateOrderItemRequest
{
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
    /// Quantity to order
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; } = 1;

    /// <summary>
    /// Product configuration
    /// </summary>
    [JsonPropertyName("configuration")]
    public ProductConfiguration Configuration { get; set; } = new();

    /// <summary>
    /// PDF file data for the print job
    /// </summary>
    [JsonPropertyName("pdf_data")]
    public PdfData? PdfData { get; set; }

    /// <summary>
    /// Cover image data (if applicable)
    /// </summary>
    [JsonPropertyName("cover_data")]
    public ImageData? CoverData { get; set; }
}