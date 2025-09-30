using System.Text.Json.Serialization;

namespace SharpLulu.Models.Print;

/// <summary>
/// Location on a page
/// </summary>
public class PageLocation
{
    /// <summary>
    /// X coordinate
    /// </summary>
    [JsonPropertyName("x")]
    public double X { get; set; }

    /// <summary>
    /// Y coordinate
    /// </summary>
    [JsonPropertyName("y")]
    public double Y { get; set; }

    /// <summary>
    /// Width of the affected area
    /// </summary>
    [JsonPropertyName("width")]
    public double? Width { get; set; }

    /// <summary>
    /// Height of the affected area
    /// </summary>
    [JsonPropertyName("height")]
    public double? Height { get; set; }
}