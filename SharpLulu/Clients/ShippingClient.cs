using SharpLulu.Configuration;
using SharpLulu.Models.Shipping;

namespace SharpLulu.Clients;

/// <summary>
/// Client for shipping operations in the Lulu API
/// </summary>
public class ShippingClient : BaseClient
{
    /// <summary>
    /// Creates a new instance of ShippingClient
    /// </summary>
    /// <param name="httpClient">HTTP client instance</param>
    /// <param name="options">Client configuration options</param>
    public ShippingClient(HttpClient httpClient, LuluClientOptions options) 
        : base(httpClient, options)
    {
    }

    /// <summary>
    /// Gets available shipping methods for a destination
    /// </summary>
    /// <param name="request">Shipping options request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Available shipping methods</returns>
    public async Task<List<ShippingMethod>?> GetShippingOptionsAsync(ShippingOptionsRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var endpoint = "/v1/shipping/options";
        return await PostAsync<List<ShippingMethod>>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Calculates shipping cost for an order
    /// </summary>
    /// <param name="request">Shipping cost request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Shipping cost calculation</returns>
    public async Task<ShippingCost?> CalculateShippingAsync(ShippingCostRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var endpoint = "/v1/shipping/calculate";
        return await PostAsync<ShippingCost>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Gets delivery time estimates for different shipping methods
    /// </summary>
    /// <param name="request">Delivery estimate request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Delivery time estimates</returns>
    public async Task<List<DeliveryEstimate>?> GetDeliveryEstimatesAsync(DeliveryEstimateRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var endpoint = "/v1/shipping/delivery-estimates";
        return await PostAsync<List<DeliveryEstimate>>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Validates a shipping address
    /// </summary>
    /// <param name="address">Address to validate</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Address validation result</returns>
    public async Task<AddressValidationResult?> ValidateAddressAsync(AddressValidationRequest address, CancellationToken cancellationToken = default)
    {
        if (address == null)
            throw new ArgumentNullException(nameof(address));

        var endpoint = "/v1/shipping/validate-address";
        return await PostAsync<AddressValidationResult>(endpoint, address, cancellationToken);
    }
}