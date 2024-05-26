using Microsoft.EntityFrameworkCore;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Data
{

    public class SeedData
    {

        public static void SeedDatabase(ApplicationDbContext context)
        {
            if (context.Database.GetMigrations().Count() > 0
                    && context.Database.GetPendingMigrations().Count() == 0
                    && context.FamilyTreePersons.Count() == 0)
            {
                var duckFamily = new Branch()
                {
                    Name = "The Duck Family",
                    Description = "Relatives of Donald Duck from Duckville."
                };

                var quackmore = new Person
                {
                    FirstNames = "Quackmore",
                    LastName = "Duck",
                    IsFemale = false,
                    EnabledInWeb = true,
                    Branch = duckFamily
                };
                var hortense = new Person
                {
                    FirstNames = "Hortense",
                    LastName = "Duck",
                    BirthName = "Hortense McDuck",
                    IsFemale = true,
                    EnabledInWeb = true,
                    Branch = duckFamily
                };
                var donald = new Person
                {
                    FirstNames = "Donald",
                    LastName = "Duck",
                    DateOfBirth = new DateOnly(1934, 6, 9),
                    IsFemale = false,
                    Father = quackmore,
                    Mother = hortense,
                    EnabledInWeb = true,
                    Branch = duckFamily
                };
                var della = new Person
                {
                    FirstNames = "Della",
                    LastName = "Duck",
                    IsFemale = true,
                    Father = quackmore,
                    Mother = hortense,
                    EnabledInWeb = true,
                    Branch = duckFamily
                };
                var huey = new Person
                {
                    FirstNames = "Huey",
                    LastName = "Duck",
                    IsFemale = false,
                    Mother = della,
                    DateOfBirth = new DateOnly(1937, 5, 2),
                    EnabledInWeb = true,
                    Branch = duckFamily
                };
                var louie = new Person
                {
                    FirstNames = "Louie",
                    LastName = "Duck",
                    IsFemale = false,
                    Mother = della,
                    DateOfBirth = new DateOnly(1937, 5, 2),
                    EnabledInWeb = true,
                    Branch = duckFamily
                };
                var dewey = new Person
                {
                    FirstNames = "Dewey",
                    LastName = "Duck",
                    IsFemale = false,
                    Mother = della,
                    DateOfBirth = new DateOnly(1937, 5, 2),
                    EnabledInWeb = true,
                    Branch = duckFamily
                };

                context.FamilyTreeBranches.Add(duckFamily);
                
                context.FamilyTreePersons.AddRange(
                    quackmore,
                    hortense,
                    donald,
                    della,
                    huey,
                    louie,
                    dewey
                );

                context.FamilyTreeArticles.AddRange(
                    new Article()
                    {
                        Name = "The Wise Litte Hen",
                        Description = "",
                        Persons = new List<Person>() { donald },
                        EnabledInWeb = true,
                        Branch = duckFamily
                    }
                );

                context.FamilyTreeUsers.Add(
                    new User() { 
                        Name = "Test", 
                        Password = "Test-1234", 
                        Branches = new List<Branch>() { duckFamily } 
                });

                context.SaveChanges();
            }
        }
    }
}
