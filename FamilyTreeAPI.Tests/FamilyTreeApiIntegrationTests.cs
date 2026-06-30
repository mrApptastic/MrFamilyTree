using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FamilyTreeAPI.Data;
using System.Net;
using System.Net.Http.Json;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Tests;

public class FamilyTreeApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private static readonly string DbName = "TestFamilyTreeDb_Integration";

    public FamilyTreeApiIntegrationTests(WebApplicationFactory<Program> factory)
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
                                d.ServiceType.FullName?.Contains("EntityFrameworkCore") == true)
                    .ToList();
                foreach (var d in descriptorsToRemove)
                    services.Remove(d);

                // Add in-memory database for testing
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase(DbName));
            });
        });

        // Seed data once
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
        SeedTestData(context);
    }

    [Fact]
    public async Task GetPerson_WithInvalidId_ReturnsNoContent()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/Api/FamilyTree/Person/{Guid.NewGuid()}");
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
    {
        var client = _factory.CreateClient();
        var loginModel = new { UserName = "nonexistent", Password = "wrongpassword" };
        var response = await client.PostAsJsonAsync("/Api/Authentication/Login", loginModel);
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsToken()
    {
        var client = _factory.CreateClient();

        var loginModel = new { UserName = "Test", Password = "Test-1234" };
        var response = await client.PostAsJsonAsync("/Api/Authentication/Login", loginModel);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = await response.Content.ReadFromJsonAsync<AuthenticatedResponse>();
        Assert.NotNull(result);
        Assert.False(string.IsNullOrEmpty(result.Token));
        Assert.Equal("Test", result.User);
    }

    [Fact]
    public async Task GetPerson_WithSeededData_ReturnsDonaldDuck()
    {
        var client = _factory.CreateClient();

        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var donald = await context.FamilyTreePersons
            .FirstOrDefaultAsync(p => p.FirstNames == "Donald" && p.LastName == "Duck");
        Assert.NotNull(donald);

        var response = await client.GetAsync($"/Api/FamilyTree/Person/{donald.Id}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var personView = await response.Content.ReadFromJsonAsync<PersonView>();
        Assert.NotNull(personView);
        Assert.Equal("Donald", personView.FirstNames);
        Assert.Equal("Duck", personView.LastName);
    }

    private static void SeedTestData(ApplicationDbContext context)
    {
        if (context.FamilyTreePersons.Any()) return;

        var branch = new Branch { Name = "Test Branch", Description = "Test" };
        var hortense = new Person { FirstNames = "Hortense", LastName = "Duck", IsFemale = true, Public = true, Branch = branch };
        var quackmore = new Person { FirstNames = "Quackmore", LastName = "Duck", IsFemale = false, Public = true, Branch = branch };
        var donald = new Person { FirstNames = "Donald", LastName = "Duck", DateOfBirth = new DateOnly(1934, 6, 9), IsFemale = false, Public = true, Branch = branch, Mother = hortense, Father = quackmore };

        context.FamilyTreeBranches.Add(branch);
        context.FamilyTreePersons.AddRange(hortense, quackmore, donald);
        context.FamilyTreeUsers.Add(new User { Name = "Test", Password = "Test-1234", Branches = new List<Branch> { branch } });
        context.SaveChanges();
    }
}
