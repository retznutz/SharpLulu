using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Quality issue found during printing
/// </summary>
public class QualityIssue
{
    /// <summary>
    /// Issue type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Severity level
    /// </summary>
    [JsonPropertyName("severity")]
    public QualityIssueSeverity Severity { get; set; }

    /// <summary>
    /// Description of the issue
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Page number where issue was found (if applicable)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Location coordinates on the page
    /// </summary>
    [JsonPropertyName("location")]
    public PageLocation? Location { get; set; }
}