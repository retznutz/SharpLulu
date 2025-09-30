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

/// <summary>
/// PDF file data for printing
/// </summary>
public class PdfData
{
    /// <summary>
    /// Base64-encoded PDF content
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Original filename
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// File size in bytes
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    /// MD5 hash of the file content
    /// </summary>
    [JsonPropertyName("md5")]
    public string? Md5 { get; set; }
}

/// <summary>
/// Image data for covers or illustrations
/// </summary>
public class ImageData
{
    /// <summary>
    /// Base64-encoded image content
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Original filename
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// MIME type (e.g., image/jpeg, image/png)
    /// </summary>
    [JsonPropertyName("mime_type")]
    public string MimeType { get; set; } = string.Empty;

    /// <summary>
    /// File size in bytes
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    /// Image width in pixels
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// Image height in pixels
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
}