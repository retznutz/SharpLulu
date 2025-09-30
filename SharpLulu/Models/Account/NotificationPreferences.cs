using System.Text.Json.Serialization;

namespace SharpLulu.Models.Account;

/// <summary>
/// Notification preferences
/// </summary>
public class NotificationPreferences
{
    /// <summary>
    /// Email notifications for order updates
    /// </summary>
    [JsonPropertyName("order_updates")]
    public bool OrderUpdates { get; set; } = true;

    /// <summary>
    /// Email notifications for print job completion
    /// </summary>
    [JsonPropertyName("print_completion")]
    public bool PrintCompletion { get; set; } = true;

    /// <summary>
    /// Email notifications for shipping updates
    /// </summary>
    [JsonPropertyName("shipping_updates")]
    public bool ShippingUpdates { get; set; } = true;

    /// <summary>
    /// Marketing email notifications
    /// </summary>
    [JsonPropertyName("marketing")]
    public bool Marketing { get; set; } = false;
}