using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

/// <summary>
/// Available shipping method
/// </summary>
public class ShippingMethod
{
    /// <summary>
    /// Shipping method identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Display name for the shipping method
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the shipping method
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Carrier name
    /// </summary>
    [JsonPropertyName("carrier")]
    public string Carrier { get; set; } = string.Empty;

    /// <summary>
    /// Estimated delivery time in business days
    /// </summary>
    [JsonPropertyName("delivery_days")]
    public int DeliveryDays { get; set; }

    /// <summary>
    /// Whether tracking is available
    /// </summary>
    [JsonPropertyName("tracking_available")]
    public bool TrackingAvailable { get; set; }

    /// <summary>
    /// Base cost in cents
    /// </summary>
    [JsonPropertyName("base_cost")]
    public int BaseCost { get; set; }
}

/// <summary>
/// Request for shipping options
/// </summary>
public class ShippingOptionsRequest
{
    /// <summary>
    /// Destination country code
    /// </summary>
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Destination state/province
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Destination postal code
    /// </summary>
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Product identifiers to ship
    /// </summary>
    [JsonPropertyName("product_ids")]
    public List<string> ProductIds { get; set; } = new();

    /// <summary>
    /// Total weight in grams
    /// </summary>
    [JsonPropertyName("weight_grams")]
    public int? WeightGrams { get; set; }
}

/// <summary>
/// Shipping cost calculation
/// </summary>
public class ShippingCost
{
    /// <summary>
    /// Shipping method identifier
    /// </summary>
    [JsonPropertyName("method_id")]
    public string MethodId { get; set; } = string.Empty;

    /// <summary>
    /// Total shipping cost in cents
    /// </summary>
    [JsonPropertyName("cost")]
    public int Cost { get; set; }

    /// <summary>
    /// Currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Cost breakdown
    /// </summary>
    [JsonPropertyName("breakdown")]
    public ShippingCostBreakdown? Breakdown { get; set; }
}

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

/// <summary>
/// Request for shipping cost calculation
/// </summary>
public class ShippingCostRequest
{
    /// <summary>
    /// Shipping method identifier
    /// </summary>
    [JsonPropertyName("method_id")]
    public string MethodId { get; set; } = string.Empty;

    /// <summary>
    /// Destination address
    /// </summary>
    [JsonPropertyName("destination")]
    public ShippingAddress Destination { get; set; } = new();

    /// <summary>
    /// Items to ship
    /// </summary>
    [JsonPropertyName("items")]
    public List<ShippingItem> Items { get; set; } = new();
}

/// <summary>
/// Shipping address
/// </summary>
public class ShippingAddress
{
    /// <summary>
    /// Street address line 1
    /// </summary>
    [JsonPropertyName("address_line_1")]
    public string AddressLine1 { get; set; } = string.Empty;

    /// <summary>
    /// Street address line 2 (optional)
    /// </summary>
    [JsonPropertyName("address_line_2")]
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// City
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// State or province
    /// </summary>
    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Postal code
    /// </summary>
    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; } = string.Empty;

    /// <summary>
    /// Country code
    /// </summary>
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;
}

/// <summary>
/// Item to ship
/// </summary>
public class ShippingItem
{
    /// <summary>
    /// Product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Weight per item in grams
    /// </summary>
    [JsonPropertyName("weight_grams")]
    public int WeightGrams { get; set; }
}

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

/// <summary>
/// Request for delivery estimates
/// </summary>
public class DeliveryEstimateRequest
{
    /// <summary>
    /// Destination address
    /// </summary>
    [JsonPropertyName("destination")]
    public ShippingAddress Destination { get; set; } = new();

    /// <summary>
    /// Product identifiers
    /// </summary>
    [JsonPropertyName("product_ids")]
    public List<string> ProductIds { get; set; } = new();
}

/// <summary>
/// Address validation request
/// </summary>
public class AddressValidationRequest
{
    /// <summary>
    /// Address to validate
    /// </summary>
    [JsonPropertyName("address")]
    public ShippingAddress Address { get; set; } = new();
}

/// <summary>
/// Address validation result
/// </summary>
public class AddressValidationResult
{
    /// <summary>
    /// Whether the address is valid
    /// </summary>
    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    /// <summary>
    /// Validated/corrected address
    /// </summary>
    [JsonPropertyName("address")]
    public ShippingAddress? Address { get; set; }

    /// <summary>
    /// Validation messages
    /// </summary>
    [JsonPropertyName("messages")]
    public List<string>? Messages { get; set; }

    /// <summary>
    /// Suggested corrections
    /// </summary>
    [JsonPropertyName("suggestions")]
    public List<ShippingAddress>? Suggestions { get; set; }
}