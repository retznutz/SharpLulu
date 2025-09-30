using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

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