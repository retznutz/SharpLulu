using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Account status enumeration
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountStatus
{
    /// <summary>
    /// Account is active
    /// </summary>
    Active,

    /// <summary>
    /// Account is suspended
    /// </summary>
    Suspended,

    /// <summary>
    /// Account is pending verification
    /// </summary>
    Pending,

    /// <summary>
    /// Account is closed
    /// </summary>
    Closed
}