using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Account update request
/// </summary>
public class UpdateAccountRequest
{
    /// <summary>
    /// Account holder name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Email address
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Company name
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    /// <summary>
    /// Account preferences
    /// </summary>
    [JsonPropertyName("preferences")]
    public AccountPreferences? Preferences { get; set; }
}