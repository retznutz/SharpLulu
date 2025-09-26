using SharpLulu;
using SharpLulu.Configuration;
using SharpLulu.Models.Projects;
using SharpLulu.Models.Products;
using SharpLulu.Common;

namespace SharpLulu.Sample;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("SharpLulu Sample Application");
        Console.WriteLine("===========================");

        // Note: In a real application, you would get the API key from configuration or environment variables
        var apiKey = Environment.GetEnvironmentVariable("LULU_API_KEY") ?? "demo-api-key";
        
        var options = new LuluClientOptions
        {
            ApiKey = apiKey,
            UseSandbox = true, // Always use sandbox for demo
            TimeoutSeconds = 60
        };

        using var client = new LuluClient(options);

        try
        {
            await DemonstrateProjectsAsync(client);
            await DemonstrateProductsAsync(client);
            await DemonstrateAccountAsync(client);
        }
        catch (LuluApiException ex)
        {
            Console.WriteLine($"❌ API Error: {ex.Message}");
            Console.WriteLine($"Status Code: {ex.StatusCode}");
            if (!string.IsNullOrEmpty(ex.ResponseContent))
            {
                Console.WriteLine($"Response: {ex.ResponseContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected Error: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static async Task DemonstrateProjectsAsync(LuluClient client)
    {
        Console.WriteLine("\n📁 Projects Demo");
        Console.WriteLine("=================");

        try
        {
            // Create a new project
            Console.WriteLine("Creating a new project...");
            var createRequest = new CreateProjectRequest
            {
                Title = "My Sample Book Project",
                Description = "A demonstration project created with SharpLulu",
                Author = "SharpLulu Demo"
            };

            var project = await client.Projects.CreateProjectAsync(createRequest);
            if (project != null)
            {
                Console.WriteLine($"✅ Created project: {project.Id} - {project.Title}");
                Console.WriteLine($"   Status: {project.Status}");
                Console.WriteLine($"   Created: {project.CreatedAt:yyyy-MM-dd HH:mm:ss}");

                // Get the project details
                Console.WriteLine("\nRetrieving project details...");
                var retrievedProject = await client.Projects.GetProjectAsync(project.Id);
                if (retrievedProject != null)
                {
                    Console.WriteLine($"✅ Retrieved project: {retrievedProject.Title}");
                }

                // Update the project
                Console.WriteLine("\nUpdating project...");
                var updateRequest = new UpdateProjectRequest
                {
                    Description = "Updated description via SharpLulu"
                };
                var updatedProject = await client.Projects.UpdateProjectAsync(project.Id, updateRequest);
                if (updatedProject != null)
                {
                    Console.WriteLine($"✅ Updated project description");
                }

                // List projects
                Console.WriteLine("\nListing projects...");
                var projects = await client.Projects.GetProjectsAsync(page: 0, size: 5);
                if (projects != null)
                {
                    Console.WriteLine($"✅ Found {projects.Items.Count} projects (total: {projects.Total})");
                    foreach (var p in projects.Items.Take(3))
                    {
                        Console.WriteLine($"   - {p.Title} ({p.Status})");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Projects demo failed: {ex.Message}");
        }
    }

    static async Task DemonstrateProductsAsync(LuluClient client)
    {
        Console.WriteLine("\n📦 Products Demo");
        Console.WriteLine("=================");

        try
        {
            // Get available products
            Console.WriteLine("Fetching available products...");
            var products = await client.Products.GetProductsAsync(page: 0, size: 5);
            if (products != null && products.Items.Any())
            {
                Console.WriteLine($"✅ Found {products.Items.Count} products (total: {products.Total})");
                
                var firstProduct = products.Items.First();
                Console.WriteLine($"   Sample product: {firstProduct.Name}");
                Console.WriteLine($"   Category: {firstProduct.Category}");
                Console.WriteLine($"   Type: {firstProduct.Type}");
                Console.WriteLine($"   Available: {firstProduct.Available}");

                // Get product details
                Console.WriteLine($"\nGetting details for product {firstProduct.Id}...");
                var productDetails = await client.Products.GetProductAsync(firstProduct.Id);
                if (productDetails != null)
                {
                    Console.WriteLine($"✅ Product details retrieved");
                    Console.WriteLine($"   Page range: {productDetails.MinPages}-{productDetails.MaxPages}");
                    Console.WriteLine($"   Available sizes: {productDetails.Sizes.Count}");
                }

                // Get product sizes
                Console.WriteLine($"\nGetting sizes for product {firstProduct.Id}...");
                var sizes = await client.Products.GetProductSizesAsync(firstProduct.Id);
                if (sizes != null && sizes.Any())
                {
                    Console.WriteLine($"✅ Found {sizes.Count} available sizes:");
                    foreach (var size in sizes.Take(3))
                    {
                        Console.WriteLine($"   - {size.Name}: {size.WidthInches}\" x {size.HeightInches}\"");
                    }
                }
            }
            else
            {
                Console.WriteLine("ℹ️ No products found or API returned empty response");
            }

            // Get categories
            Console.WriteLine("\nFetching product categories...");
            var categories = await client.Products.GetCategoriesAsync();
            if (categories != null && categories.Any())
            {
                Console.WriteLine($"✅ Found {categories.Count} categories:");
                foreach (var category in categories.Take(5))
                {
                    Console.WriteLine($"   - {category}");
                }
            }

            // Search for books
            Console.WriteLine("\nSearching for book products...");
            var bookProducts = await client.Products.GetProductsAsync(
                type: ProductType.Book, 
                available: true, 
                size: 3);
            if (bookProducts != null)
            {
                Console.WriteLine($"✅ Found {bookProducts.Items.Count} book products");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Products demo failed: {ex.Message}");
        }
    }

    static async Task DemonstrateAccountAsync(LuluClient client)
    {
        Console.WriteLine("\n👤 Account Demo");
        Console.WriteLine("================");

        try
        {
            // Get account information
            Console.WriteLine("Fetching account information...");
            var account = await client.Account.GetAccountAsync();
            if (account != null)
            {
                Console.WriteLine($"✅ Account retrieved");
                Console.WriteLine($"   Name: {account.Name}");
                Console.WriteLine($"   Email: {account.Email}");
                Console.WriteLine($"   Type: {account.Type}");
                Console.WriteLine($"   Status: {account.Status}");
                Console.WriteLine($"   Created: {account.CreatedAt:yyyy-MM-dd}");
            }

            // Get account balance
            Console.WriteLine("\nFetching account balance...");
            var balance = await client.Account.GetBalanceAsync();
            if (balance != null)
            {
                Console.WriteLine($"✅ Balance retrieved");
                Console.WriteLine($"   Balance: {balance.Balance / 100.0:C} {balance.Currency}");
                Console.WriteLine($"   Credit: {balance.Credit / 100.0:C}");
                Console.WriteLine($"   Credit Limit: {balance.CreditLimit / 100.0:C}");
            }

            // Get usage statistics
            Console.WriteLine("\nFetching API usage statistics...");
            var usage = await client.Account.GetUsageStatsAsync(
                startDate: DateTime.Now.AddDays(-30),
                endDate: DateTime.Now);
            if (usage != null)
            {
                Console.WriteLine($"✅ Usage stats retrieved");
                Console.WriteLine($"   Total calls: {usage.TotalCalls}");
                Console.WriteLine($"   Successful: {usage.SuccessfulCalls}");
                Console.WriteLine($"   Failed: {usage.FailedCalls}");
                Console.WriteLine($"   Period: {usage.PeriodStart:yyyy-MM-dd} to {usage.PeriodEnd:yyyy-MM-dd}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Account demo failed: {ex.Message}");
        }
    }
}
