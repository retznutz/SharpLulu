using System.Net;
using System.Text;
using System.Text.Json;
using SharpLulu.Common;
using SharpLulu.Configuration;

namespace SharpLulu.Clients;

/// <summary>
/// Base client class for all API clients
/// </summary>
public abstract class BaseClient
{
    protected readonly HttpClient HttpClient;
    protected readonly LuluClientOptions Options;
    protected readonly JsonSerializerOptions JsonOptions;

    /// <summary>
    /// Creates a new instance of BaseClient
    /// </summary>
    /// <param name="httpClient">HTTP client instance</param>
    /// <param name="options">Client configuration options</param>
    protected BaseClient(HttpClient httpClient, LuluClientOptions options)
    {
        HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        Options = options ?? throw new ArgumentNullException(nameof(options));
        
        JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            WriteIndented = false,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };
    }

    /// <summary>
    /// Sends a GET request and returns the response
    /// </summary>
    /// <typeparam name="T">Response type</typeparam>
    /// <param name="endpoint">API endpoint</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>API response</returns>
    protected async Task<T?> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
    {
        var response = await SendRequestAsync(HttpMethod.Get, endpoint, null, cancellationToken);
        return await DeserializeResponseAsync<T>(response);
    }

    /// <summary>
    /// Sends a POST request and returns the response
    /// </summary>
    /// <typeparam name="T">Response type</typeparam>
    /// <param name="endpoint">API endpoint</param>
    /// <param name="content">Request content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>API response</returns>
    protected async Task<T?> PostAsync<T>(string endpoint, object? content = null, CancellationToken cancellationToken = default)
    {
        var response = await SendRequestAsync(HttpMethod.Post, endpoint, content, cancellationToken);
        return await DeserializeResponseAsync<T>(response);
    }

    /// <summary>
    /// Sends a PUT request and returns the response
    /// </summary>
    /// <typeparam name="T">Response type</typeparam>
    /// <param name="endpoint">API endpoint</param>
    /// <param name="content">Request content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>API response</returns>
    protected async Task<T?> PutAsync<T>(string endpoint, object? content = null, CancellationToken cancellationToken = default)
    {
        var response = await SendRequestAsync(HttpMethod.Put, endpoint, content, cancellationToken);
        return await DeserializeResponseAsync<T>(response);
    }

    /// <summary>
    /// Sends a PATCH request and returns the response
    /// </summary>
    /// <typeparam name="T">Response type</typeparam>
    /// <param name="endpoint">API endpoint</param>
    /// <param name="content">Request content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>API response</returns>
    protected async Task<T?> PatchAsync<T>(string endpoint, object? content = null, CancellationToken cancellationToken = default)
    {
        var response = await SendRequestAsync(HttpMethod.Patch, endpoint, content, cancellationToken);
        return await DeserializeResponseAsync<T>(response);
    }

    /// <summary>
    /// Sends a DELETE request
    /// </summary>
    /// <param name="endpoint">API endpoint</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if successful</returns>
    protected async Task<bool> DeleteAsync(string endpoint, CancellationToken cancellationToken = default)
    {
        var response = await SendRequestAsync(HttpMethod.Delete, endpoint, null, cancellationToken);
        return response.IsSuccessStatusCode;
    }

    private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string endpoint, object? content, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(method, endpoint);

        if (content != null && (method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Patch))
        {
            var json = JsonSerializer.Serialize(content, JsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var response = await HttpClient.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new LuluApiException(
                $"API request failed with status {response.StatusCode}",
                response.StatusCode,
                errorContent);
        }

        return response;
    }

    private async Task<T?> DeserializeResponseAsync<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        
        if (string.IsNullOrEmpty(content))
            return default;

        try
        {
            return JsonSerializer.Deserialize<T>(content, JsonOptions);
        }
        catch (JsonException ex)
        {
            throw new LuluApiException(
                "Failed to deserialize API response",
                response.StatusCode,
                content,
                ex);
        }
    }
}