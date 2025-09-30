using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Account preferences
/// </summary>
public class AccountPreferences
{
    /// <summary>
    /// Preferred currency
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Time zone
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Language preference
    /// </summary>
    [JsonPropertyName("language")]
    public string Language { get; set; } = "en";

    /// <summary>
    /// Email notification preferences
    /// </summary>
    [JsonPropertyName("notifications")]
    public NotificationPreferences? Notifications { get; set; }
}