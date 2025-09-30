using SharpLulu.Common;
using SharpLulu.Configuration;
using SharpLulu.Models.Products;

namespace SharpLulu.Clients;

/// <summary>
/// Client for managing products and catalog in the Lulu API
/// </summary>
public class ProductsClient : BaseClient
{
    /// <summary>
    /// Creates a new instance of ProductsClient
    /// </summary>
    /// <param name="httpClient">HTTP client instance</param>
    /// <param name="options">Client configuration options</param>
    public ProductsClient(HttpClient httpClient, LuluClientOptions options) 
        : base(httpClient, options)
    {
    }

    /// <summary>
    /// Gets a paginated list of available products
    /// </summary>
    /// <param name="page">Page number (0-based)</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="category">Filter by category</param>
    /// <param name="type">Filter by product type</param>
    /// <param name="available">Filter by availability</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Paginated list of products</returns>
    public async Task<PagedResponse<Product>?> GetProductsAsync(
        int page = 0,
        int size = 20,
        string? category = null,
        ProductType? type = null,
        bool? available = null,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new List<string>
        {
            $"page={page}",
            $"size={size}"
        };

        if (!string.IsNullOrWhiteSpace(category))
            queryParams.Add($"category={Uri.EscapeDataString(category)}");

        if (type.HasValue)
            queryParams.Add($"type={type.Value.ToString().ToLowerInvariant()}");

        if (available.HasValue)
            queryParams.Add($"available={available.Value.ToString().ToLowerInvariant()}");

        var endpoint = $"/v1/products?{string.Join("&", queryParams)}";
        return await GetAsync<PagedResponse<Product>>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets a specific product by ID
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Product details</returns>
    public async Task<Product?> GetProductAsync(string productId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(productId))
            throw new ArgumentException("Product ID cannot be null or empty", nameof(productId));

        var endpoint = $"/v1/products/{productId}";
        return await GetAsync<Product>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets available product categories
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of product categories</returns>
    public async Task<List<string>?> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = "/v1/products/categories";
        return await GetAsync<List<string>>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets product pricing for a specific configuration
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <param name="sizeId">Size identifier</param>
    /// <param name="pageCount">Number of pages</param>
    /// <param name="quantity">Quantity</param>
    /// <param name="paperType">Paper type</param>
    /// <param name="bindingType">Binding type</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Pricing information</returns>
    public async Task<ProductPricing?> GetPricingAsync(
        string productId,
        string sizeId,
        int pageCount,
        int quantity = 1,
        string? paperType = null,
        string? bindingType = null,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(productId))
            throw new ArgumentException("Product ID cannot be null or empty", nameof(productId));

        if (string.IsNullOrWhiteSpace(sizeId))
            throw new ArgumentException("Size ID cannot be null or empty", nameof(sizeId));

        if (pageCount <= 0)
            throw new ArgumentException("Page count must be greater than zero", nameof(pageCount));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));

        var queryParams = new List<string>
        {
            $"size_id={Uri.EscapeDataString(sizeId)}",
            $"page_count={pageCount}",
            $"quantity={quantity}"
        };

        if (!string.IsNullOrWhiteSpace(paperType))
            queryParams.Add($"paper_type={Uri.EscapeDataString(paperType)}");

        if (!string.IsNullOrWhiteSpace(bindingType))
            queryParams.Add($"binding_type={Uri.EscapeDataString(bindingType)}");

        var endpoint = $"/v1/products/{productId}/pricing?{string.Join("&", queryParams)}";
        return await GetAsync<ProductPricing>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Gets available sizes for a product
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of available sizes</returns>
    public async Task<List<ProductSize>?> GetProductSizesAsync(string productId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(productId))
            throw new ArgumentException("Product ID cannot be null or empty", nameof(productId));

        var endpoint = $"/v1/products/{productId}/sizes";
        return await GetAsync<List<ProductSize>>(endpoint, cancellationToken);
    }

    /// <summary>
    /// Searches for products using a text query
    /// </summary>
    /// <param name="query">Search query</param>
    /// <param name="page">Page number (0-based)</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Search results</returns>
    public async Task<PagedResponse<Product>?> SearchProductsAsync(
        string query,
        int page = 0,
        int size = 20,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException("Query cannot be null or empty", nameof(query));

        var queryParams = new List<string>
        {
            $"q={Uri.EscapeDataString(query)}",
            $"page={page}",
            $"size={size}"
        };

        var endpoint = $"/v1/products/search?{string.Join("&", queryParams)}";
        return await GetAsync<PagedResponse<Product>>(endpoint, cancellationToken);
    }
}