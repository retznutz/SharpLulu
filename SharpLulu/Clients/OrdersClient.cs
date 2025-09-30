using System.Text.Json.Serialization;
using SharpLulu.Common;
using SharpLulu.Configuration;
using SharpLulu.Models.Orders;

namespace SharpLulu.Clients;

/// <summary>
/// Client for managing print orders in the Lulu API
/// </summary>
public class OrdersClient : BaseClient
{
    /// <summary>
    /// Creates a new instance of OrdersClient
    /// </summary>
    /// <param name="httpClient">HTTP client instance</param>
    /// <param name="options">Client configuration options</param>
    public OrdersClient(HttpClient httpClient, LuluClientOptions options) 
        : base(httpClient, options)
    {
    }

    /// <summary>
    /// Gets a paginated list of orders
    /// </summary>
    /// <param name="page">Page number (0-based)</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="status">Filter by order status</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Paginated list of orders</returns>
    public async Task<PagedResponse<Order>?> GetOrdersAsync(
        int page = 0,
        int size = 20,
        OrderStatus? status = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"page={page}",
            $"size={size}"
        };

        if (status.HasValue)
            queryParams.Add($"status={status.Value.ToString().ToLowerInvariant()}");

        var endpoint = $"/v1/orders?{string.Join("&", queryParams)}";
        return await GetAsync<PagedResponse<Order>>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets a specific order by ID
    /// </summary>
    /// <param name="orderId">Order identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Order details</returns>
    public async Task<Order?> GetOrderAsync(string orderId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(orderId))
            throw new ArgumentException("Order ID cannot be null or empty", nameof(orderId));

        var endpoint = $"/v1/orders/{orderId}";
        return await GetAsync<Order>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Creates a new print order
    /// </summary>
    /// <param name="request">Order creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Created order</returns>
    public async Task<Order?> CreateOrderAsync(CreateOrderRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        if (!request.Items.Any())
            throw new ArgumentException("Order must contain at least one item", nameof(request));

        var endpoint = "/v1/orders";
        return await PostAsync<Order>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Cancels an order
    /// </summary>
    /// <param name="orderId">Order identifier</param>
    /// <param name="reason">Cancellation reason</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated order</returns>
    public async Task<Order?> CancelOrderAsync(string orderId, string? reason = null, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(orderId))
            throw new ArgumentException("Order ID cannot be null or empty", nameof(orderId));

        var request = new { reason };
        var endpoint = $"/v1/orders/{orderId}/cancel";
        return await PostAsync<Order>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Gets tracking information for an order
    /// </summary>
    /// <param name="orderId">Order identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Tracking information</returns>
    public async Task<OrderTracking?> GetTrackingAsync(string orderId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(orderId))
            throw new ArgumentException("Order ID cannot be null or empty", nameof(orderId));

        var endpoint = $"/v1/orders/{orderId}/tracking";
        return await GetAsync<OrderTracking>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets the estimated cost for an order without placing it
    /// </summary>
    /// <param name="request">Order request to estimate</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Cost estimate</returns>
    public async Task<OrderEstimate?> EstimateOrderAsync(CreateOrderRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        if (!request.Items.Any())
            throw new ArgumentException("Order must contain at least one item", nameof(request));

        var endpoint = "/v1/orders/estimate";
        return await PostAsync<OrderEstimate>(endpoint, request, cancellationToken);
    }
}

/// <summary>
/// Order cost estimate
/// </summary>
public class OrderEstimate
{
    /// <summary>
    /// Total estimated cost in cents
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// Currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Breakdown of costs
    /// </summary>
    [JsonPropertyName("breakdown")]
    public OrderCostBreakdown? Breakdown { get; set; }

    /// <summary>
    /// Estimated production time in days
    /// </summary>
    [JsonPropertyName("production_days")]
    public int ProductionDays { get; set; }

    /// <summary>
    /// Estimated shipping time in days
    /// </summary>
    [JsonPropertyName("shipping_days")]
    public int ShippingDays { get; set; }
}

/// <summary>
/// Order cost breakdown
/// </summary>
public class OrderCostBreakdown
{
    /// <summary>
    /// Subtotal for items in cents
    /// </summary>
    [JsonPropertyName("subtotal")]
    public int Subtotal { get; set; }

    /// <summary>
    /// Shipping cost in cents
    /// </summary>
    [JsonPropertyName("shipping")]
    public int Shipping { get; set; }

    /// <summary>
    /// Tax amount in cents
    /// </summary>
    [JsonPropertyName("tax")]
    public int Tax { get; set; }

    /// <summary>
    /// Discount amount in cents
    /// </summary>
    [JsonPropertyName("discount")]
    public int Discount { get; set; }
}