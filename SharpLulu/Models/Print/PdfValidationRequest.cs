using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// PDF validation request
/// </summary>
public class PdfValidationRequest
{
    /// <summary>
    /// Product identifier to validate against
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Base64-encoded PDF content
    /// </summary>
    [JsonPropertyName("pdf_content")]
    public string PdfContent { get; set; } = string.Empty;

    /// <summary>
    /// PDF filename
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// Validation level
    /// </summary>
    [JsonPropertyName("validation_level")]
    public ValidationLevel ValidationLevel { get; set; } = ValidationLevel.Standard;
}