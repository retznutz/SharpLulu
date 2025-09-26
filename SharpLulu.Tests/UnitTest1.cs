using SharpLulu.Configuration;
using Xunit;

namespace SharpLulu.Tests;

public class LuluClientTests
{
    [Fact]
    public void LuluClient_CanBeCreated()
    {
        // Arrange
        var options = new LuluClientOptions
        {
            ApiKey = "test-api-key",
            UseSandbox = true
        };

        // Act
        using var client = new LuluClient(options);

        // Assert
        Assert.NotNull(client);
        Assert.NotNull(client.Projects);
        Assert.NotNull(client.Products);
        Assert.NotNull(client.Orders);
        Assert.NotNull(client.Shipping);
        Assert.NotNull(client.Account);
        Assert.NotNull(client.Print);
    }

    [Fact]
    public void LuluClientOptions_DefaultsToSandbox()
    {
        // Arrange & Act
        var options = new LuluClientOptions
        {
            ApiKey = "test-key"
        };

        // Assert
        Assert.True(options.UseSandbox);
        Assert.Equal("https://api.sandbox.lulu.com", options.BaseUrl);
    }

    [Fact]
    public void LuluClientOptions_CanUseProduction()
    {
        // Arrange & Act
        var options = new LuluClientOptions
        {
            ApiKey = "test-key",
            UseSandbox = false
        };

        // Assert
        Assert.False(options.UseSandbox);
        Assert.Equal("https://api.lulu.com", options.BaseUrl);
    }
}