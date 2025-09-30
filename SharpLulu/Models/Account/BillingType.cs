using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Billing transaction type
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BillingType
{
    /// <summary>
    /// Charge for an order
    /// </summary>
    Charge,

    /// <summary>
    /// Refund for an order
    /// </summary>
    Refund,

    /// <summary>
    /// Credit adjustment
    /// </summary>
    Credit,

    /// <summary>
    /// Debit adjustment
    /// </summary>
    Debit
}