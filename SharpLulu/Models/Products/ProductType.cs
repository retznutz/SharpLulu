using System.Text.Json.Serialization;

namespace SharpLulu.Models.Products;

/// <summary>
/// Product type enumeration
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductType
{
    /// <summary>
    /// Standard book
    /// </summary>
    Book,

    /// <summary>
    /// Magazine or periodical
    /// </summary>
    Magazine,

    /// <summary>
    /// Calendar
    /// </summary>
    Calendar,

    /// <summary>
    /// Poster
    /// </summary>
    Poster,

    /// <summary>
    /// Journal or notebook
    /// </summary>
    Journal,

    /// <summary>
    /// Photo book
    /// </summary>
    PhotoBook,

    /// <summary>
    /// Cookbook
    /// </summary>
    Cookbook
}