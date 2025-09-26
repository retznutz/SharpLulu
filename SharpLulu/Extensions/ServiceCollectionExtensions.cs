using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SharpLulu.Configuration;

namespace SharpLulu.Extensions;

/// <summary>
/// Extension methods for IServiceCollection to register LuluClient
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds LuluClient services to the dependency injection container
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configureOptions">Configuration action for LuluClientOptions</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddLuluClient(
        this IServiceCollection services,
        Action<LuluClientOptions> configureOptions)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        if (configureOptions == null)
            throw new ArgumentNullException(nameof(configureOptions));

        services.Configure(configureOptions);
        
        services.AddHttpClient<LuluClient>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<LuluClientOptions>>().Value;
            httpClient.BaseAddress = new Uri(options.BaseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.ApiKey}");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "SharpLulu/1.0.0");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddTransient<LuluClient>();

        return services;
    }

    /// <summary>
    /// Adds LuluClient services to the dependency injection container with pre-configured options
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="options">Pre-configured LuluClientOptions</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddLuluClient(
        this IServiceCollection services,
        LuluClientOptions options)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        return services.AddLuluClient(opt =>
        {
            opt.ApiKey = options.ApiKey;
            opt.UseSandbox = options.UseSandbox;
            opt.ProductionBaseUrl = options.ProductionBaseUrl;
            opt.SandboxBaseUrl = options.SandboxBaseUrl;
            opt.TimeoutSeconds = options.TimeoutSeconds;
            opt.MaxRetryAttempts = options.MaxRetryAttempts;
        });
    }

    /// <summary>
    /// Adds LuluClient services to the dependency injection container using configuration section
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">Configuration section containing LuluClient settings</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddLuluClient(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        services.Configure<LuluClientOptions>(configuration);
        
        services.AddHttpClient<LuluClient>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<LuluClientOptions>>().Value;
            httpClient.BaseAddress = new Uri(options.BaseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.ApiKey}");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "SharpLulu/1.0.0");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddTransient<LuluClient>();

        return services;
    }
}