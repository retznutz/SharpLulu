using Microsoft.Extensions.Options;
using SharpLulu.Clients;
using SharpLulu.Configuration;

namespace SharpLulu;

/// <summary>
/// Main client for interacting with the Lulu Print API
/// </summary>
public class LuluClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly LuluClientOptions _options;
    private bool _disposed;

    /// <summary>
    /// Client for managing projects
    /// </summary>
    public ProjectsClient Projects { get; }

    /// <summary>
    /// Client for managing products and catalog
    /// </summary>
    public ProductsClient Products { get; }

    /// <summary>
    /// Client for managing print orders
    /// </summary>
    public OrdersClient Orders { get; }

    /// <summary>
    /// Client for shipping operations
    /// </summary>
    public ShippingClient Shipping { get; }

    /// <summary>
    /// Client for account management
    /// </summary>
    public AccountClient Account { get; }

    /// <summary>
    /// Client for print operations
    /// </summary>
    public PrintClient Print { get; }

    /// <summary>
    /// Creates a new instance of LuluClient
    /// </summary>
    /// <param name="options">Client configuration options</param>
    /// <param name="httpClient">Optional HTTP client instance</param>
    public LuluClient(LuluClientOptions options, HttpClient? httpClient = null)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _httpClient = httpClient ?? new HttpClient();
        
        ConfigureHttpClient();
        
        Projects = new ProjectsClient(_httpClient, _options);
        Products = new ProductsClient(_httpClient, _options);
        Orders = new OrdersClient(_httpClient, _options);
        Shipping = new ShippingClient(_httpClient, _options);
        Account = new AccountClient(_httpClient, _options);
        Print = new PrintClient(_httpClient, _options);
    }

    /// <summary>
    /// Creates a new instance of LuluClient using IOptions pattern
    /// </summary>
    /// <param name="options">Client configuration options</param>
    /// <param name="httpClient">Optional HTTP client instance</param>
    public LuluClient(IOptions<LuluClientOptions> options, HttpClient? httpClient = null)
        : this(options.Value, httpClient)
    {
    }

    private void ConfigureHttpClient()
    {
        _httpClient.BaseAddress = new Uri(_options.BaseUrl);
        _httpClient.Timeout = TimeSpan.FromSeconds(_options.TimeoutSeconds);
        
        // Set common headers
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiKey}");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "SharpLulu/1.0.0");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    /// <summary>
    /// Disposes the client and releases resources
    /// </summary>
    public void Dispose()
    {
        if (!_disposed)
        {
            _httpClient?.Dispose();
            _disposed = true;
        }
    }
}