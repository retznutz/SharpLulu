using System.Net;

namespace SharpLulu.Common;

/// <summary>
/// Exception thrown when the Lulu API returns an error
/// </summary>
public class LuluApiException : Exception
{
    /// <summary>
    /// The HTTP status code returned by the API
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// The response content from the API
    /// </summary>
    public string? ResponseContent { get; }

    /// <summary>
    /// Creates a new instance of LuluApiException
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="statusCode">The HTTP status code</param>
    /// <param name="responseContent">The response content</param>
    public LuluApiException(string message, HttpStatusCode statusCode, string? responseContent = null)
        : base(message)
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }

    /// <summary>
    /// Creates a new instance of LuluApiException
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="statusCode">The HTTP status code</param>
    /// <param name="responseContent">The response content</param>
    /// <param name="innerException">The inner exception</param>
    public LuluApiException(string message, HttpStatusCode statusCode, string? responseContent, Exception innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }
}