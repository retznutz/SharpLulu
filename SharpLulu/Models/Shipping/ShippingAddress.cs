using System.Text.Json.Serialization;

namespace SharpLulu.Models.Shipping;

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