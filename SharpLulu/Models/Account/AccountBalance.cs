using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Account balance information
/// </summary>
public class AccountBalance
{
    /// <summary>
    /// Current balance in cents
    /// </summary>
    [JsonPropertyName("balance")]
    public int Balance { get; set; }

    /// <summary>
    /// Currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Available credit in cents
    /// </summary>
    [JsonPropertyName("credit")]
    public int Credit { get; set; }

    /// <summary>
    /// Credit limit in cents
    /// </summary>
    [JsonPropertyName("credit_limit")]
    public int CreditLimit { get; set; }

    /// <summary>
    /// Last updated timestamp
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}