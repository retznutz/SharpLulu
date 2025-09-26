using SharpLulu.Common;
using SharpLulu.Configuration;
using SharpLulu.Models.Account;

namespace SharpLulu.Clients;

/// <summary>
/// Client for account management in the Lulu API
/// </summary>
public class AccountClient : BaseClient
{
    /// <summary>
    /// Creates a new instance of AccountClient
    /// </summary>
    /// <param name="httpClient">HTTP client instance</param>
    /// <param name="options">Client configuration options</param>
    public AccountClient(HttpClient httpClient, LuluClientOptions options) 
        : base(httpClient, options)
    {
    }

    /// <summary>
    /// Gets the current account information
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Account information</returns>
    public async Task<Account?> GetAccountAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = "/v1/account";
        return await GetAsync<Account>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Updates account information
    /// </summary>
    /// <param name="request">Account update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated account information</returns>
    public async Task<Account?> UpdateAccountAsync(UpdateAccountRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var endpoint = "/v1/account";
        return await PutAsync<Account>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Gets account balance and credit information
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Account balance</returns>
    public async Task<AccountBalance?> GetBalanceAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = "/v1/account/balance";
        return await GetAsync<AccountBalance>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets account billing history
    /// </summary>
    /// <param name="page">Page number (0-based)</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Billing history</returns>
    public async Task<PagedResponse<BillingRecord>?> GetBillingHistoryAsync(
        int page = 0,
        int size = 20,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"page={page}",
            $"size={size}"
        };

        var endpoint = $"/v1/account/billing?{string.Join("&", queryParams)}";
        return await GetAsync<PagedResponse<BillingRecord>>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets API usage statistics
    /// </summary>
    /// <param name="startDate">Start date for statistics</param>
    /// <param name="endDate">End date for statistics</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>API usage statistics</returns>
    public async Task<ApiUsageStats?> GetUsageStatsAsync(
        DateTime? startDate = null,
        DateTime? endDate = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>();

        if (startDate.HasValue)
            queryParams.Add($"start_date={startDate.Value:yyyy-MM-dd}");

        if (endDate.HasValue)
            queryParams.Add($"end_date={endDate.Value:yyyy-MM-dd}");

        var endpoint = queryParams.Any() 
            ? $"/v1/account/usage?{string.Join("&", queryParams)}"
            : "/v1/account/usage";

        return await GetAsync<ApiUsageStats>(endpoint, cancellationToken);
    }
}