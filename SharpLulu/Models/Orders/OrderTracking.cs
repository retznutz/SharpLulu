using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Order tracking information
/// </summary>
public class OrderTracking
{
    /// <summary>
    /// Tracking number
    /// </summary>
    [JsonPropertyName("tracking_number")]
    public string? TrackingNumber { get; set; }

    /// <summary>
    /// Carrier name
    /// </summary>
    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    /// <summary>
    /// Tracking URL
    /// </summary>
    [JsonPropertyName("tracking_url")]
    public string? TrackingUrl { get; set; }

    /// <summary>
    /// Estimated delivery date
    /// </summary>
    [JsonPropertyName("estimated_delivery")]
    public DateTime? EstimatedDelivery { get; set; }

    /// <summary>
    /// Actual delivery date
    /// </summary>
    [JsonPropertyName("delivered_at")]
    public DateTime? DeliveredAt { get; set; }
}