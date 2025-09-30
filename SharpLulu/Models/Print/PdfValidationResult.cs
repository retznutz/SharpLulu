using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// PDF validation result
/// </summary>
public class PdfValidationResult
{
    /// <summary>
    /// Whether the PDF is valid for printing
    /// </summary>
    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    /// <summary>
    /// Validation score (0-100)
    /// </summary>
    [JsonPropertyName("score")]
    public int Score { get; set; }

    /// <summary>
    /// Validation issues found
    /// </summary>
    [JsonPropertyName("issues")]
    public List<ValidationIssue>? Issues { get; set; }

    /// <summary>
    /// PDF metadata
    /// </summary>
    [JsonPropertyName("metadata")]
    public PdfMetadata? Metadata { get; set; }

    /// <summary>
    /// Validation timestamp
    /// </summary>
    [JsonPropertyName("validated_at")]
    public DateTime ValidatedAt { get; set; }
}