using MrFamilyTree.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrFamilyTree.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Article> FamilyTreeArticles {get; set;}
        public DbSet<BirthParish> FamilyTreeBirthParishes {get; set;}
        public DbSet<Image> FamilyTreeImages { get; set; }
        public DbSet<Keyword> FamilyTreeKeywords {get; set;}
        public DbSet<Person> FamilyTreePersons {get; set;}

    }
}   

