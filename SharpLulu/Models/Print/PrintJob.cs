using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Print job information
/// </summary>
public class PrintJob
{
    /// <summary>
    /// Print job identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Associated order identifier
    /// </summary>
    [JsonPropertyName("order_id")]
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Print job status
    /// </summary>
    [JsonPropertyName("status")]
    public PrintJobStatus Status { get; set; }

    /// <summary>
    /// Product being printed
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Quantity being printed
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Print facility handling the job
    /// </summary>
    [JsonPropertyName("facility_id")]
    public string? FacilityId { get; set; }

    /// <summary>
    /// Date when print job was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date when printing started
    /// </summary>
    [JsonPropertyName("started_at")]
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// Date when printing completed
    /// </summary>
    [JsonPropertyName("completed_at")]
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Estimated completion date
    /// </summary>
    [JsonPropertyName("estimated_completion")]
    public DateTime? EstimatedCompletion { get; set; }

    /// <summary>
    /// Quality check results
    /// </summary>
    [JsonPropertyName("quality_check")]
    public QualityCheckResult? QualityCheck { get; set; }
}