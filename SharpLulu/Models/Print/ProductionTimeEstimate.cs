using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Production time estimate
/// </summary>
public class ProductionTimeEstimate
{
    /// <summary>
    /// Estimated production days
    /// </summary>
    [JsonPropertyName("production_days")]
    public int ProductionDays { get; set; }

    /// <summary>
    /// Earliest start date
    /// </summary>
    [JsonPropertyName("earliest_start")]
    public DateTime EarliestStart { get; set; }

    /// <summary>
    /// Estimated completion date
    /// </summary>
    [JsonPropertyName("estimated_completion")]
    public DateTime EstimatedCompletion { get; set; }

    /// <summary>
    /// Rush order surcharge (if applicable)
    /// </summary>
    [JsonPropertyName("rush_surcharge")]
    public int? RushSurcharge { get; set; }

    /// <summary>
    /// Recommended facility
    /// </summary>
    [JsonPropertyName("recommended_facility")]
    public string? RecommendedFacility { get; set; }
}