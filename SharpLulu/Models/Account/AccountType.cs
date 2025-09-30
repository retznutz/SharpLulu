using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Account type enumeration
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountType
{
    /// <summary>
    /// Individual account
    /// </summary>
    Individual,

    /// <summary>
    /// Business account
    /// </summary>
    Business,

    /// <summary>
    /// Enterprise account
    /// </summary>
    Enterprise
}