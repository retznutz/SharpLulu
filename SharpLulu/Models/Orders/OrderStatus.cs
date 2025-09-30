using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

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