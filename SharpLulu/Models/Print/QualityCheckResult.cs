using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Quality check result
/// </summary>
public class QualityCheckResult
{
    /// <summary>
    /// Whether the print passed quality check
    /// </summary>
    [JsonPropertyName("passed")]
    public bool Passed { get; set; }

    /// <summary>
    /// Quality score (0-100)
    /// </summary>
    [JsonPropertyName("score")]
    public int Score { get; set; }

    /// <summary>
    /// Quality check issues found
    /// </summary>
    [JsonPropertyName("issues")]
    public List<QualityIssue>? Issues { get; set; }

    /// <summary>
    /// Date of quality check
    /// </summary>
    [JsonPropertyName("checked_at")]
    public DateTime CheckedAt { get; set; }
}