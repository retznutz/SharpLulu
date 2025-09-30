using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Delivery time estimate
/// </summary>
public class DeliveryEstimate
{
    /// <summary>
    /// Shipping method identifier
    /// </summary>
    [JsonPropertyName("method_id")]
    public string MethodId { get; set; } = string.Empty;

    /// <summary>
    /// Minimum delivery days
    /// </summary>
    [JsonPropertyName("min_days")]
    public int MinDays { get; set; }

    /// <summary>
    /// Maximum delivery days
    /// </summary>
    [JsonPropertyName("max_days")]
    public int MaxDays { get; set; }

    /// <summary>
    /// Estimated delivery date
    /// </summary>
    [JsonPropertyName("estimated_date")]
    public DateTime? EstimatedDate { get; set; }
}