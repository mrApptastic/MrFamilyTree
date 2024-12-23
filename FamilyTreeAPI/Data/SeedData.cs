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
                    Description = "Relatives of Donald Duck from Duckburg."
                };

                var duckburg = new Place()
                {
                    Name = "Duckburg",
                    Longitude = (decimal)124.18155,
                    Latitude = (decimal)40.38130,
                    Branch = duckFamily
                };

                var gertrude = new Person
                {
                    FirstNames = "Gertrude",
                    LastName = "Coot",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    BirthName = "Gertrude Gadwall"
                };

                var clinton = new Person
                {
                    FirstNames = "Clinton",
                    LastName = "Coot",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily
                };

                var casey = new Person
                {
                    FirstNames = "Casey",
                    LastName = "Coot",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = gertrude,
                    Father = clinton
                };

                var gretchen = new Person
                {
                    FirstNames = "Gretchen",
                    LastName = "Coot",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    BirthName = "Gretchen Grebbe"
                };

                var fanny = new Person
                {
                    FirstNames = "Fanny",
                    LastName = "Goose",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    Mother = gretchen,
                    Father = casey,
                    BirthName = "Fanny Coot"
                };

                var cuthbert = new Person
                {
                    FirstNames = "Cuthbert",
                    LastName = "Coot",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = gretchen,
                    Father = casey
                };

                var luke = new Person
                {
                    FirstNames = "Luke",
                    LastName = "Goose",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily
                };

                var gus = new Person
                {
                    FirstNames = "Gus",
                    LastName = "Goose",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = fanny,
                    Father = luke,
                    DateOfBirth = new DateOnly(1939, 5, 19)
                };

                var grandma = new Person
                {
                    FirstNames = "Grandma",
                    LastName = "Duck",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    Mother = gertrude,
                    Father = clinton,
                    BirthName = "Elvira Coot"
                };

                var humberdink = new Person
                {
                    FirstNames = "Humberdink",
                    LastName = "Duck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily
                };

                var daphne = new Person
                {
                    FirstNames = "Daphne",
                    LastName = "Gander",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    Mother = grandma,
                    Father = humberdink,
                    BirthName = "Daphne Duck"
                };

                var goosetave = new Person
                {
                    FirstNames = "Goosetave",
                    LastName = "Gander",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily
                };

                var gladstone = new Person
                {
                    FirstNames = "Gladstone",
                    LastName = "Gander",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = daphne,
                    Father = goosetave
                };

                var eider = new Person
                {
                    FirstNames = "Eider",
                    LastName = "Duck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = grandma,
                    Father = humberdink
                };

                var lulubelle = new Person
                {
                    FirstNames = "Lulubelle",
                    LastName = "Loon",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily
                };

                var fethry = new Person
                {
                    FirstNames = "Fethry",
                    LastName = "Duck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = lulubelle,
                    Father = eider,
                    DateOfBirth = new DateOnly(1964, 8, 2)
                };

                var abner = new Person
                {
                    FirstNames = "Abner",
                    LastName = "Duck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = lulubelle,
                    Father = eider
                };

                var quackmore = new Person
                {
                    FirstNames = "Quackmore",
                    LastName = "Duck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = grandma,
                    Father = humberdink
                };

                var dingus = new Person
                {
                    FirstNames = "Dingus",
                    LastName = "McDuck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily
                };

                var molly = new Person
                {
                    FirstNames = "Molly",
                    LastName = "McDuck",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    BirthName = "Molly Mallard"
                };

                var angus = new Person
                {
                    FirstNames = "Angus",
                    LastName = "McDuck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = molly,
                    Father = dingus
                };

                var jake = new Person
                {
                    FirstNames = "Jake",
                    LastName = "McDuck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = molly,
                    Father = dingus
                };

                var fergus = new Person
                {
                    FirstNames = "Fergus",
                    LastName = "McDuck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = molly,
                    Father = dingus
                };

                var downy = new Person
                {
                    FirstNames = "Downy",
                    LastName = "McDuck",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    BirthName = "Downy O'Drake"
                };

                var matilda = new Person
                {
                    FirstNames = "Matilda",
                    LastName = "McDuck",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    Mother = downy,
                    Father = fergus
                };

                var scrooge = new Person
                {
                    FirstNames = "Scrooge",
                    LastName = "McDuck",
                    IsFemale = false,
                    Public = true,
                    Branch = duckFamily,
                    Mother = downy,
                    Father = fergus
                };

                var hortense = new Person
                {
                    FirstNames = "Hortense",
                    LastName = "Duck",
                    BirthName = "Hortense McDuck",
                    IsFemale = true,
                    Public = true,
                    Branch = duckFamily,
                    Mother = downy,
                    Father = fergus
                };

                var donald = new Person
                {
                    FirstNames = "Donald",
                    LastName = "Duck",
                    DateOfBirth = new DateOnly(1934, 6, 9),
                    IsFemale = false,
                    Father = quackmore,
                    Mother = hortense,
                    Public = true,
                    Branch = duckFamily
                };

                var della = new Person
                {
                    FirstNames = "Della",
                    LastName = "Duck",
                    IsFemale = true,
                    Father = quackmore,
                    Mother = hortense,
                    Public = true,
                    Branch = duckFamily
                };

                var huey = new Person
                {
                    FirstNames = "Huey",
                    LastName = "Duck",
                    IsFemale = false,
                    Mother = della,
                    DateOfBirth = new DateOnly(1937, 5, 2),
                    Public = true,
                    Branch = duckFamily
                };

                var louie = new Person
                {
                    FirstNames = "Louie",
                    LastName = "Duck",
                    IsFemale = false,
                    Mother = della,
                    DateOfBirth = new DateOnly(1937, 5, 2),
                    Public = true,
                    Branch = duckFamily
                };

                var dewey = new Person
                {
                    FirstNames = "Dewey",
                    LastName = "Duck",
                    IsFemale = false,
                    Mother = della,
                    DateOfBirth = new DateOnly(1937, 5, 2),
                    Public = true,
                    Branch = duckFamily
                };

                context.FamilyTreeBranches.Add(duckFamily);

                context.FamilyTreePlaces.Add(duckburg);

                context.FamilyTreePersons.AddRange(
                    clinton,
                    gertrude,
                    casey,
                    gretchen,
                    cuthbert,
                    fanny,
                    luke,
                    gus,
                    humberdink,
                    grandma,
                    daphne,
                    goosetave,
                    gladstone,
                    eider,
                    lulubelle,
                    abner,
                    fethry,
                    molly,
                    dingus,
                    angus,
                    jake,
                    fergus,
                    downy,
                    matilda,
                    scrooge,
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
                        Public = true,
                        Branch = duckFamily
                    },
                    new Article()
                    {
                        Name = "Donald's Nephews",
                        Description = "",
                        Persons = new List<Person>() { donald, huey, louie, dewey },
                        Public = true,
                        Branch = duckFamily
                    },
                    new Article()
                    {
                        Name = "Donald's Cousin Gus",
                        Description = "",
                        Persons = new List<Person>() { donald, gus },
                        Public = true,
                        Branch = duckFamily
                    }
                );

                context.FamilyTreeUsers.Add(
                    new User()
                    {
                        Name = "Test",
                        Password = "Test-1234",
                        Branches = new List<Branch>() { duckFamily }
                    });

                context.SaveChanges();
            }
        }
    }
}
