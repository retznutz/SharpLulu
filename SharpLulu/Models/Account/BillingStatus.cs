using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Billing transaction status
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BillingStatus
{
    /// <summary>
    /// Transaction is pending
    /// </summary>
    Pending,

    /// <summary>
    /// Transaction completed successfully
    /// </summary>
    Completed,

    /// <summary>
    /// Transaction failed
    /// </summary>
    Failed,

    /// <summary>
    /// Transaction was reversed
    /// </summary>
    Reversed
}