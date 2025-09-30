# SharpLulu
A comprehensive .NET client library for the Lulu Print API.  Another project I'm trying out github co-pilot with.  So far impressed with it's abilities to make API clients by giving it API documentation.  I'm reviewing and updating code as I find issues.

## Overview

SharpLulu is a modern .NET 8.0 client library that provides a complete implementation of the Lulu Print API. It offers a strongly-typed, async/await-enabled interface for all major Lulu API functionality including projects, products, orders, shipping, account management, and print operations.

## Features

- **Comprehensive API Coverage**: Full implementation of all major Lulu API endpoints
- **Sandbox/Production Toggle**: Easy switching between sandbox and production environments
- **Strongly Typed Models**: All request/response objects with proper JSON serialization attributes
- **Async/Await Support**: Modern asynchronous programming patterns
- **Dependency Injection**: Built-in support for .NET dependency injection
- **Error Handling**: Robust error handling with custom exceptions
- **Extensible Architecture**: Modular client design for easy extension

## Installation

```bash
dotnet add package SharpLulu
```

## Quick Start

### Basic Usage

```csharp
using SharpLulu;
using SharpLulu.Configuration;

// Configure the client
var options = new LuluClientOptions
{
    ApiKey = "your-api-key-here",
    UseSandbox = true // Set to false for production
};

// Create the client
using var client = new LuluClient(options);

// Get available products
var products = await client.Products.GetProductsAsync();

// Create a new project
var project = await client.Projects.CreateProjectAsync(new CreateProjectRequest
{
    Title = "My Book Project",
    Description = "A sample book project"
});
```

### Dependency Injection

```csharp
using Microsoft.Extensions.DependencyInjection;
using SharpLulu.Extensions;

// In your Startup.cs or Program.cs
services.AddLuluClient(options =>
{
    options.ApiKey = "your-api-key-here";
    options.UseSandbox = true;
});

// Inject and use in your services
public class BookService
{
    private readonly LuluClient _luluClient;
    
    public BookService(LuluClient luluClient)
    {
        _luluClient = luluClient;
    }
    
    public async Task<Order> CreateBookOrderAsync(CreateOrderRequest request)
    {
        return await _luluClient.Orders.CreateOrderAsync(request);
    }
}
```

## Client Architecture

SharpLulu is organized into specialized client classes for different areas of functionality:

### ProjectsClient
- Create, update, and manage print projects
- Archive and activate projects
- List projects with filtering options

```csharp
// Create a new project
var project = await client.Projects.CreateProjectAsync(new CreateProjectRequest
{
    Title = "My Novel",
    Description = "A thrilling adventure story",
    Author = "John Doe"
});

// Get project details
var projectDetails = await client.Projects.GetProjectAsync(project.Id);

// Archive a project
await client.Projects.ArchiveProjectAsync(project.Id);
```

### ProductsClient
- Browse the Lulu product catalog
- Get product specifications and pricing
- Search for products by category or type

```csharp
// Get all available products
var products = await client.Products.GetProductsAsync();

// Search for books
var books = await client.Products.GetProductsAsync(type: ProductType.Book);

// Get pricing for a specific configuration
var pricing = await client.Products.GetPricingAsync(
    productId: "product-123",
    sizeId: "size-456",
    pageCount: 200,
    quantity: 100
);
```

### OrdersClient
- Create and manage print orders
- Track order status and shipping
- Estimate order costs

```csharp
// Create a print order
var order = await client.Orders.CreateOrderAsync(new CreateOrderRequest
{
    Items = new List<CreateOrderItemRequest>
    {
        new CreateOrderItemRequest
        {
            ProductId = "product-123",
            ProjectId = "project-456",
            Quantity = 100,
            Configuration = new ProductConfiguration
            {
                SizeId = "size-789",
                PaperType = "white",
                BindingType = "perfect-bound",
                PageCount = 200
            }
        }
    },
    Shipping = new ShippingInfo
    {
        Name = "John Doe",
        AddressLine1 = "123 Main St",
        City = "Anytown",
        State = "CA",
        PostalCode = "12345",
        Country = "US",
        Email = "john@example.com"
    }
});

// Get order status
var orderStatus = await client.Orders.GetOrderAsync(order.Id);

// Get tracking information
var tracking = await client.Orders.GetTrackingAsync(order.Id);
```

### ShippingClient  
- Calculate shipping costs and delivery times
- Validate shipping addresses
- Get available shipping methods

```csharp
// Get shipping options
var shippingOptions = await client.Shipping.GetShippingOptionsAsync(
    new ShippingOptionsRequest
    {
        Country = "US",
        State = "CA",
        PostalCode = "90210",
        ProductIds = new List<string> { "product-123" }
    });

// Calculate shipping cost
var shippingCost = await client.Shipping.CalculateShippingAsync(
    new ShippingCostRequest
    {
        MethodId = "standard",
        Destination = new ShippingAddress { /* address details */ },
        Items = new List<ShippingItem> { /* items to ship */ }
    });
```

### AccountClient
- Manage account information
- View billing history and account balance
- Get API usage statistics

```csharp
// Get account information
var account = await client.Account.GetAccountAsync();

// Check account balance
var balance = await client.Account.GetBalanceAsync();

// Get API usage stats
var usage = await client.Account.GetUsageStatsAsync(
    startDate: DateTime.Now.AddMonths(-1),
    endDate: DateTime.Now
);
```

### PrintClient
- Monitor print job status
- Validate PDF files for printing
- Get print quality requirements

```csharp
// Validate a PDF for printing
var validation = await client.Print.ValidatePdfAsync(new PdfValidationRequest
{
    ProductId = "product-123",
    PdfContent = Convert.ToBase64String(pdfBytes),
    Filename = "my-book.pdf"
});

// Get print job status
var printJob = await client.Print.GetPrintJobAsync("job-123");

// Get quality requirements for a product
var requirements = await client.Print.GetQualityRequirementsAsync("product-123");
```

## Configuration

### LuluClientOptions

```csharp
var options = new LuluClientOptions
{
    ApiKey = "your-api-key",           // Required: Your Lulu API key
    UseSandbox = true,                 // Optional: Use sandbox (default: true)
    TimeoutSeconds = 30,               // Optional: HTTP timeout (default: 30)
    MaxRetryAttempts = 3,              // Optional: Max retry attempts (default: 3)
    ProductionBaseUrl = "https://api.lulu.com",          // Optional: Production URL
    SandboxBaseUrl = "https://api.sandbox.lulu.com"      // Optional: Sandbox URL
};
```

### Environment Configuration

You can also configure the client using .NET configuration:

```json
{
  "LuluClient": {
    "ApiKey": "your-api-key-here",
    "UseSandbox": true,
    "TimeoutSeconds": 60
  }
}
```

```csharp
services.AddLuluClient(configuration.GetSection("LuluClient"));
```

## Error Handling

SharpLulu provides comprehensive error handling through the `LuluApiException` class:

```csharp
try
{
    var order = await client.Orders.CreateOrderAsync(request);
}
catch (LuluApiException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
    Console.WriteLine($"Status Code: {ex.StatusCode}");
    Console.WriteLine($"Response: {ex.ResponseContent}");
}
```

## Model Classes

All API objects are represented by strongly-typed model classes with JSON serialization attributes:

- **Projects**: `Project`, `CreateProjectRequest`, `UpdateProjectRequest`
- **Products**: `Product`, `ProductSize`, `ProductPricing`
- **Orders**: `Order`, `OrderItem`, `CreateOrderRequest`, `ShippingInfo`
- **Shipping**: `ShippingMethod`, `ShippingCost`, `DeliveryEstimate`
- **Account**: `Account`, `AccountBalance`, `BillingRecord`
- **Print**: `PrintJob`, `PdfValidationResult`, `PrintQualityRequirements`

## Requirements

- .NET 8.0 or later
- Valid Lulu API key

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For issues and questions:
1. Check the [Lulu API Documentation](https://api.lulu.com/docs/)
2. Open an issue on GitHub
3. Contact the maintainers

## Changelog

### v1.0.0
- Initial release
- Complete implementation of Lulu Print API
- Support for all major API endpoints
- Sandbox/production environment toggle
- Comprehensive model classes with JSON attributes
- Dependency injection support
