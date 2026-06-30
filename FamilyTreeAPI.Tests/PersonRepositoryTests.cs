using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using FamilyTreeAPI.Data;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Tests;

public class PersonRepositoryTests
{
    private ServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddAutoMapper(cfg => cfg.AddProfile<PersonProfile>());
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        services.AddScoped<IPersonRepository, PersonRepository>();
        return services.BuildServiceProvider();
    }

    [Fact]
    public async Task GetPersonAsync_WithNonExistentId_ThrowsArgumentException()
    {
        using var provider = CreateServiceProvider();
        var repo = provider.GetRequiredService<IPersonRepository>();

        await Assert.ThrowsAsync<ArgumentException>(
            () => repo.GetPersonAsync(Guid.NewGuid(), true));
    }

    [Fact]
    public async Task GetPersonAsync_WithExistingPerson_ReturnsPerson()
    {
        using var provider = CreateServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();
        var branch = new Branch { Name = "Test Branch", Description = "Test" };
        var person = new Person
        {
            FirstNames = "John",
            LastName = "Doe",
            Public = true,
            Branch = branch
        };
        context.FamilyTreePersons.Add(person);
        await context.SaveChangesAsync();

        var repo = provider.GetRequiredService<IPersonRepository>();
        var result = await repo.GetPersonAsync(person.Id, true);

        Assert.NotNull(result);
        Assert.Equal("John", result.FirstNames);
        Assert.Equal("Doe", result.LastName);
    }

    [Fact]
    public async Task GetPersonAsync_WithPrivatePerson_ThrowsArgumentException()
    {
        using var provider = CreateServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();
        var branch = new Branch { Name = "Test Branch", Description = "Test" };
        var person = new Person
        {
            FirstNames = "Private",
            LastName = "Person",
            Public = false,
            Branch = branch
        };
        context.FamilyTreePersons.Add(person);
        await context.SaveChangesAsync();

        var repo = provider.GetRequiredService<IPersonRepository>();
        await Assert.ThrowsAsync<ArgumentException>(
            () => repo.GetPersonAsync(person.Id, true));
    }

    [Fact]
    public async Task GetPersonWithGenerationsAsync_ReturnsAncestors()
    {
        using var provider = CreateServiceProvider();
        var context = provider.GetRequiredService<ApplicationDbContext>();
        var branch = new Branch { Name = "Test Branch", Description = "Test" };

        var grandmother = new Person { FirstNames = "Grand", LastName = "Mother", Public = true, IsFemale = true, Branch = branch };
        var grandfather = new Person { FirstNames = "Grand", LastName = "Father", Public = true, IsFemale = false, Branch = branch };
        var mother = new Person { FirstNames = "Test", LastName = "Mother", Public = true, IsFemale = true, Mother = grandmother, Father = grandfather, Branch = branch };
        var child = new Person { FirstNames = "Test", LastName = "Child", Public = true, IsFemale = false, Mother = mother, Branch = branch };

        context.FamilyTreePersons.AddRange(grandmother, grandfather, mother, child);
        await context.SaveChangesAsync();

        var repo = provider.GetRequiredService<IPersonRepository>();
        var result = await repo.GetPersonWithGenerationsAsync(child.Id);

        Assert.NotNull(result);
        Assert.Equal("Test", result.FirstNames);
        Assert.Equal("Child", result.LastName);
        Assert.NotNull(result.Mother);
        Assert.Equal("Test", result.Mother.FirstNames);
        Assert.Equal("Mother", result.Mother.LastName);
    }
}
