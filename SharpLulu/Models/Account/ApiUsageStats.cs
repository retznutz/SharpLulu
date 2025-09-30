using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

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