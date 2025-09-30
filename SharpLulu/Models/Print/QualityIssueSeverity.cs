using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Quality issue severity
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum QualityIssueSeverity
{
    /// <summary>
    /// Low severity issue
    /// </summary>
    Low,

    /// <summary>
    /// Medium severity issue
    /// </summary>
    Medium,

    /// <summary>
    /// High severity issue
    /// </summary>
    High,

    /// <summary>
    /// Critical issue that prevents printing
    /// </summary>
    Critical
}