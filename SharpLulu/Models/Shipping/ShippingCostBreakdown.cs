using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Shipping cost breakdown
/// </summary>
public class ShippingCostBreakdown
{
    /// <summary>
    /// Base shipping rate in cents
    /// </summary>
    [JsonPropertyName("base_rate")]
    public int BaseRate { get; set; }

    /// <summary>
    /// Weight-based charges in cents
    /// </summary>
    [JsonPropertyName("weight_charges")]
    public int WeightCharges { get; set; }

    /// <summary>
    /// Additional fees in cents
    /// </summary>
    [JsonPropertyName("additional_fees")]
    public int AdditionalFees { get; set; }

    /// <summary>
    /// Fuel surcharge in cents
    /// </summary>
    [JsonPropertyName("fuel_surcharge")]
    public int FuelSurcharge { get; set; }
}