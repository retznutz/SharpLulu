using System.Text.Json.Serialization;

namespace SharpLulu.Models.Orders;

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