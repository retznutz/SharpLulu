using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

/// <summary>
/// Represents a print order
/// </summary>
public class Order
{
    /// <summary>
    /// Unique identifier for the order
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Order reference number
    /// </summary>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <summary>
    /// Current order status
    /// </summary>
    [JsonPropertyName("status")]
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Order items
    /// </summary>
    [JsonPropertyName("items")]
    public List<OrderItem> Items { get; set; } = new();

    /// <summary>
    /// Shipping information
    /// </summary>
    [JsonPropertyName("shipping")]
    public ShippingInfo? Shipping { get; set; }

    /// <summary>
    /// Billing information
    /// </summary>
    [JsonPropertyName("billing")]
    public BillingInfo? Billing { get; set; }

    /// <summary>
    /// Order total in cents
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// Currency code
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    /// Date and time when the order was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the order was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Tracking information
    /// </summary>
    [JsonPropertyName("tracking")]
    public OrderTracking? Tracking { get; set; }
}

/// <summary>
/// Represents an item in an order
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Item identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Product identifier
    /// </summary>
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Project identifier (if applicable)
    /// </summary>
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }

    /// <summary>
    /// Quantity ordered
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    /// Unit price in cents
    /// </summary>
    [JsonPropertyName("unit_price")]
    public int UnitPrice { get; set; }

    /// <summary>
    /// Total price for this item in cents
    /// </summary>
    [JsonPropertyName("total_price")]
    public int TotalPrice { get; set; }

    /// <summary>
    /// Product configuration
    /// </summary>
    [JsonPropertyName("configuration")]
    public ProductConfiguration? Configuration { get; set; }

    /// <summary>
    /// Current status of this item
    /// </summary>
    [JsonPropertyName("status")]
    public OrderItemStatus Status { get; set; }
}

/// <summary>
/// Product configuration for an order item
/// </summary>
public class ProductConfiguration
{
    /// <summary>
    /// Size identifier
    /// </summary>
    [JsonPropertyName("size_id")]
    public string SizeId { get; set; } = string.Empty;

    /// <summary>
    /// Paper type
    /// </summary>
    [JsonPropertyName("paper_type")]
    public string? PaperType { get; set; }

    /// <summary>
    /// Binding type
    /// </summary>
    [JsonPropertyName("binding_type")]
    public string? BindingType { get; set; }

    /// <summary>
    /// Number of pages
    /// </summary>
    [JsonPropertyName("page_count")]
    public int PageCount { get; set; }

    /// <summary>
    /// Cover finish
    /// </summary>
    [JsonPropertyName("cover_finish")]
    public string? CoverFinish { get; set; }

    /// <summary>
    /// Interior paper color
    /// </summary>
    [JsonPropertyName("interior_color")]
    public string? InteriorColor { get; set; }
}

/// <summary>
/// Shipping information
/// </summary>
public class ShippingInfo
{
    /// <summary>
    /// Recipient name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Company name (optional)
    /// </summary>
    [JsonPropertyName("company")]
    public string? Company { get; set; }

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

    /// <summary>
    /// Phone number (optional)
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Email address
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Shipping method
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }
}

/// <summary>
/// Billing information
/// </summary>
public class BillingInfo
{
    /// <summary>
    /// Same as shipping address
    /// </summary>
    [JsonPropertyName("same_as_shipping")]
    public bool SameAsShipping { get; set; }

    /// <summary>
    /// Billing name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Billing address (if different from shipping)
    /// </summary>
    [JsonPropertyName("address")]
    public ShippingInfo? Address { get; set; }
}

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

/// <summary>
/// Order status enumeration
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    /// <summary>
    /// Order is being processed
    /// </summary>
    Processing,

    /// <summary>
    /// Order has been confirmed and is being prepared
    /// </summary>
    Confirmed,

    /// <summary>
    /// Order is in production
    /// </summary>
    InProduction,

    /// <summary>
    /// Order has been printed and is being prepared for shipping
    /// </summary>
    Printed,

    /// <summary>
    /// Order has been shipped
    /// </summary>
    Shipped,

    /// <summary>
    /// Order has been delivered
    /// </summary>
    Delivered,

    /// <summary>
    /// Order has been cancelled
    /// </summary>
    Cancelled,

    /// <summary>
    /// Order has been refunded
    /// </summary>
    Refunded
}

/// <summary>
/// Order item status enumeration
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderItemStatus
{
    /// <summary>
    /// Item is being processed
    /// </summary>
    Processing,

    /// <summary>
    /// Item is in production
    /// </summary>
    InProduction,

    /// <summary>
    /// Item has been printed
    /// </summary>
    Printed,

    /// <summary>
    /// Item has been shipped
    /// </summary>
    Shipped,

    /// <summary>
    /// Item has been delivered
    /// </summary>
    Delivered,

    /// <summary>
    /// Item has been cancelled
    /// </summary>
    Cancelled
}