using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// PDF validation level
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValidationLevel
{
    /// <summary>
    /// Basic validation
    /// </summary>
    Basic,

    /// <summary>
    /// Standard validation
    /// </summary>
    Standard,

    /// <summary>
    /// Comprehensive validation
    /// </summary>
    Comprehensive
}