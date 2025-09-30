using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Billing record
/// </summary>
public class BillingRecord
{
    /// <summary>
    /// Transaction identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Transaction type
    /// </summary>
    [JsonPropertyName("type")]
    public BillingType Type { get; set; }

    /// <summary>
    /// Amount in cents
    /// </summary>
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    /// <summary>
    /// Currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Description of the transaction
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Related order ID (if applicable)
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Transaction date
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Transaction status
    /// </summary>
    [JsonPropertyName("status")]
    public BillingStatus Status { get; set; }
}