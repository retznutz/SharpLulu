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

/// <summary>
/// Notification preferences
/// </summary>
public class NotificationPreferences
{
    /// <summary>
    /// Email notifications for order updates
    /// </summary>
    [JsonPropertyName("order_updates")]
    public bool OrderUpdates { get; set; } = true;

    /// <summary>
    /// Email notifications for print job completion
    /// </summary>
    [JsonPropertyName("print_completion")]
    public bool PrintCompletion { get; set; } = true;

    /// <summary>
    /// Email notifications for shipping updates
    /// </summary>
    [JsonPropertyName("shipping_updates")]
    public bool ShippingUpdates { get; set; } = true;

    /// <summary>
    /// Marketing email notifications
    /// </summary>
    [JsonPropertyName("marketing")]
    public bool Marketing { get; set; } = false;
}

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

/// <summary>
/// API usage statistics
/// </summary>
public class ApiUsageStats
{
    /// <summary>
    /// Total API calls in the period
    /// </summary>
    [JsonPropertyName("total_calls")]
    public int TotalCalls { get; set; }

    /// <summary>
    /// Successful API calls
    /// </summary>
    [JsonPropertyName("successful_calls")]
    public int SuccessfulCalls { get; set; }

    /// <summary>
    /// Failed API calls
    /// </summary>
    [JsonPropertyName("failed_calls")]
    public int FailedCalls { get; set; }

    /// <summary>
    /// API calls by endpoint
    /// </summary>
    [JsonPropertyName("calls_by_endpoint")]
    public Dictionary<string, int>? CallsByEndpoint { get; set; }

    /// <summary>
    /// Period start date
    /// </summary>
    [JsonPropertyName("period_start")]
    public DateTime PeriodStart { get; set; }

    /// <summary>
    /// Period end date
    /// </summary>
    [JsonPropertyName("period_end")]
    public DateTime PeriodEnd { get; set; }
}

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