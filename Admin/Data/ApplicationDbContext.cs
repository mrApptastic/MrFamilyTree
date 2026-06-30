using MrFamilyTree.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MrFamilyTree.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> FamilyTreeArticles { get; set; }
        public DbSet<BirthParish> FamilyTreeBirthParishes { get; set; }
        public DbSet<Image> FamilyTreeImages { get; set; }
        public DbSet<Keyword> FamilyTreeKeywords { get; set; }
        public DbSet<Person> FamilyTreePersons { get; set; }
    }
}
