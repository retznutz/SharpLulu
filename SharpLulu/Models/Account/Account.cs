using System.Text.Json.Serialization;
using SharpLulu.Common;

namespace SharpLulu.Models.Account;

/// <summary>
/// Account information
/// </summary>
public class Account
{
    /// <summary>
    /// Account identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Account holder name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Email address
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Company name (if applicable)
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    /// <summary>
    /// Account type
    /// </summary>
    [JsonPropertyName("type")]
    public AccountType Type { get; set; }

    /// <summary>
    /// Account status
    /// </summary>
    [JsonPropertyName("status")]
    public AccountStatus Status { get; set; }

    /// <summary>
    /// Date when account was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date when account was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Account preferences
    /// </summary>
    [JsonPropertyName("preferences")]
    public AccountPreferences? Preferences { get; set; }
}