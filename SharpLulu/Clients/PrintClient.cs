using SharpLulu.Common;
using SharpLulu.Configuration;
using SharpLulu.Models.Print;

namespace SharpLulu.Clients;

/// <summary>
/// Client for print operations in the Lulu API
/// </summary>
public class PrintClient : BaseClient
{
    /// <summary>
    /// Creates a new instance of PrintClient
    /// </summary>
    /// <param name="httpClient">HTTP client instance</param>
    /// <param name="options">Client configuration options</param>
    public PrintClient(HttpClient httpClient, LuluClientOptions options) 
        : base(httpClient, options)
    {
    }

    /// <summary>
    /// Gets print job status
    /// </summary>
    /// <param name="printJobId">Print job identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Print job status</returns>
    public async Task<PrintJob?> GetPrintJobAsync(string printJobId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(printJobId))
            throw new ArgumentException("Print job ID cannot be null or empty", nameof(printJobId));

        var endpoint = $"/v1/print/jobs/{printJobId}";
        return await GetAsync<PrintJob>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets print job history
    /// </summary>
    /// <param name="page">Page number (0-based)</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="status">Filter by print job status</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Print job history</returns>
    public async Task<PagedResponse<PrintJob>?> GetPrintJobsAsync(
        int page = 0,
        int size = 20,
        PrintJobStatus? status = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"page={page}",
            $"size={size}"
        };

        if (status.HasValue)
            queryParams.Add($"status={status.Value.ToString().ToLowerInvariant()}");

        var endpoint = $"/v1/print/jobs?{string.Join("&", queryParams)}";
        return await GetAsync<PagedResponse<PrintJob>>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Validates a PDF file for printing
    /// </summary>
    /// <param name="request">PDF validation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Validation result</returns>
    public async Task<PdfValidationResult?> ValidatePdfAsync(PdfValidationRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var endpoint = "/v1/print/validate-pdf";
        return await PostAsync<PdfValidationResult>(endpoint, request, cancellationToken);
    }

    /// <summary>
    /// Gets print quality requirements for a product
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Print quality requirements</returns>
    public async Task<PrintQualityRequirements?> GetQualityRequirementsAsync(string productId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(productId))
            throw new ArgumentException("Product ID cannot be null or empty", nameof(productId));

        var endpoint = $"/v1/print/quality-requirements/{productId}";
        return await GetAsync<PrintQualityRequirements>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets available print facilities
    /// </summary>
    /// <param name="countryCode">Filter by country code</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of print facilities</returns>
    public async Task<List<PrintFacility>?> GetPrintFacilitiesAsync(string? countryCode = null, CancellationToken cancellationToken = default)
    {
        var endpoint = "/v1/print/facilities";
        
        if (!string.IsNullOrWhiteSpace(countryCode))
            endpoint += $"?country={Uri.EscapeDataString(countryCode)}";

        return await GetAsync<List<PrintFacility>>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Estimates print production time
    /// </summary>
    /// <param name="request">Production time estimate request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Production time estimate</returns>
    public async Task<ProductionTimeEstimate?> EstimateProductionTimeAsync(ProductionTimeRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var endpoint = "/v1/print/production-time";
        return await PostAsync<ProductionTimeEstimate>(endpoint, request, cancellationToken);
    }
}