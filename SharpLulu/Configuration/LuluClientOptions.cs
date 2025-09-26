using System.ComponentModel.DataAnnotations;

namespace SharpLulu.Configuration;

/// <summary>
/// Configuration options for the Lulu API client
/// </summary>
public class LuluClientOptions
{
    /// <summary>
    /// The API key for authentication
    /// </summary>
    [Required]
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Whether to use the sandbox environment (true) or production (false)
    /// </summary>
    public bool UseSandbox { get; set; } = true;

    /// <summary>
    /// The base URL for the production API
    /// </summary>
    public string ProductionBaseUrl { get; set; } = "https://api.lulu.com";

    /// <summary>
    /// The base URL for the sandbox API
    /// </summary>
    public string SandboxBaseUrl { get; set; } = "https://api.sandbox.lulu.com";

    /// <summary>
    /// Gets the effective base URL based on the UseSandbox setting
    /// </summary>
    public string BaseUrl => UseSandbox ? SandboxBaseUrl : ProductionBaseUrl;

    /// <summary>
    /// HTTP client timeout in seconds
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Maximum number of retry attempts for failed requests
    /// </summary>
    public int MaxRetryAttempts { get; set; } = 3;
}