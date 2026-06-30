using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MrFamilyTree.Data;
using System.Net;

namespace Admin.Tests;

public class AdminIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AdminIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {
                // Remove all DbContext-related registrations
                var descriptorsToRemove = services
                    .Where(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>) ||
                                d.ServiceType == typeof(ApplicationDbContext) ||
                                d.ServiceType.FullName?.Contains("EntityFrameworkCore") == true ||
                                d.ServiceType.FullName?.Contains("Identity") == true)
                    .ToList();
                foreach (var d in descriptorsToRemove)
                    services.Remove(d);

                // Add in-memory database for testing
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TestAdminDb"));
            });
        });
    }

    [Fact]
    public async Task HealthCheck_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();
        // The fallback should return index.html or 404 for non-API routes
        var response = await client.GetAsync("/");
        Assert.True(response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task WeatherForecast_WithoutAuth_ReturnsUnauthorizedOrRedirect()
    {
        var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
        var response = await client.GetAsync("/WeatherForecast");
        // Should be unauthorized or redirect to login since [Authorize] is applied
        Assert.True(
            response.StatusCode == HttpStatusCode.Unauthorized ||
            response.StatusCode == HttpStatusCode.Redirect ||
            response.StatusCode == HttpStatusCode.Found);
    }
}
