using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FamilyTreeAPI.Data;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Tests;

public class UserRepositoryTests
{
    private ServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddAutoMapper(cfg => { });
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        services.AddScoped<IUserRepository, UserRepository>();
        return services.BuildServiceProvider();
    }

    [Fact]
    public async Task GetUserAsync_WithValidCredentials_ReturnsUser()
    {
        using var provider = CreateServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();
        var branch = new Branch { Name = "Test Branch", Description = "Test" };
        var user = new User { Name = "admin", Password = "secret123", Branches = new List<Branch> { branch } };
        context.FamilyTreeUsers.Add(user);
        await context.SaveChangesAsync();

        var repo = provider.GetRequiredService<IUserRepository>();
        var result = await repo.GetUserAsync("admin", "secret123");

        Assert.NotNull(result);
        Assert.Equal("admin", result.Name);
    }

    [Fact]
    public async Task GetUserAsync_WithInvalidPassword_ReturnsNull()
    {
        using var provider = CreateServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();
        var branch = new Branch { Name = "Test Branch", Description = "Test" };
        var user = new User { Name = "admin", Password = "secret123", Branches = new List<Branch> { branch } };
        context.FamilyTreeUsers.Add(user);
        await context.SaveChangesAsync();

        var repo = provider.GetRequiredService<IUserRepository>();
        var result = await repo.GetUserAsync("admin", "wrongpassword");

        Assert.Null(result);
    }

    [Fact]
    public async Task GetUserAsync_WithNonExistentUser_ReturnsNull()
    {
        using var provider = CreateServiceProvider();
        var repo = provider.GetRequiredService<IUserRepository>();
        var result = await repo.GetUserAsync("nonexistent", "password");

        Assert.Null(result);
    }
}
