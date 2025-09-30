using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

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