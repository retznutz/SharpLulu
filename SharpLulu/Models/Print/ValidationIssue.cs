using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// PDF validation issue
/// </summary>
public class ValidationIssue
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
    public ValidationSeverity Severity { get; set; }

    /// <summary>
    /// Issue description
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Page number where issue was found (if applicable)
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Suggested fix
    /// </summary>
    [JsonPropertyName("suggested_fix")]
    public string? SuggestedFix { get; set; }
}