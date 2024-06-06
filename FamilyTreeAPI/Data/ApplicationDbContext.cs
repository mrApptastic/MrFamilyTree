using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> FamilyTreeUsers { get; set; }
        public DbSet<Article> FamilyTreeArticles { get; set; }
        public DbSet<Place> FamilyTreePlaces { get; set; }
        public DbSet<Image> FamilyTreeImages { get; set; }
        public DbSet<Keyword> FamilyTreeKeywords { get; set; }
        public DbSet<Person> FamilyTreePersons { get; set; }
        public DbSet<Branch> FamilyTreeBranches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Keyword>()
            .HasMany(a => a.Images)
            .WithMany(i => i.Keywords)
            .UsingEntity<Dictionary<string, object>>(
                "FamilyTreeImageKeywords",
                j => j.HasOne<Image>().WithMany().HasForeignKey("ImageId"),
                j => j.HasOne<Keyword>().WithMany().HasForeignKey("KeywordId"));
    }
    }
}
