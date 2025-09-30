using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Validation issue severity
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValidationSeverity
{
    /// <summary>
    /// Information only
    /// </summary>
    Info,

    /// <summary>
    /// Warning that should be addressed
    /// </summary>
    Warning,

    /// <summary>
    /// Error that prevents printing
    /// </summary>
    Error
}