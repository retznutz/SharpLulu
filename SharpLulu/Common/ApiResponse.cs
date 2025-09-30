using System.Text.Json.Serialization;

namespace SharpLulu.Common;

/// <summary>
/// Base class for API responses
/// </summary>
/// <typeparam name="T">The type of data returned</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// The response data
    /// </summary>
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    /// <summary>
    /// Error information if the request failed
    /// </summary>
    [JsonPropertyName("errors")]
    public List<ApiError>? Errors { get; set; }

    /// <summary>
    /// Indicates whether the response was successful
    /// </summary>
    [JsonIgnore]
    public bool IsSuccess => Errors == null || !Errors.Any();
}

/// <summary>
/// Represents an API error
/// </summary>
public class ApiError
{
    /// <summary>
    /// Error code
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// Human-readable error message
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Field that caused the error (if applicable)
    /// </summary>
    [JsonPropertyName("field")]
    public string? Field { get; set; }
}

/// <summary>
/// Paginated response wrapper
/// </summary>
/// <typeparam name="T">The type of items in the collection</typeparam>
public class PagedResponse<T>
{
    /// <summary>
    /// The collection of items
    /// </summary>
    [JsonPropertyName("items")]
    public List<T> Items { get; set; } = new();

    /// <summary>
    /// Total number of items available
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// Current page number (0-based)
    /// </summary>
    [JsonPropertyName("page")]
    public int Page { get; set; }

    /// <summary>
    /// Number of items per page
    /// </summary>
    [JsonPropertyName("size")]
    public int Size { get; set; }

    /// <summary>
    /// Whether there are more pages available
    /// </summary>
    [JsonIgnore]
    public bool HasNextPage => (Page + 1) * Size < Total;

    /// <summary>
    /// Whether there are previous pages available
    /// </summary>
    [JsonIgnore]
    public bool HasPreviousPage => Page > 0;
}