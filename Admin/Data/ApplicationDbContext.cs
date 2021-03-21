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
        public DbSet<FamilyTreeArticle> Articles {get; set;}
        public DbSet<FamilyTreeImage> Images { get; set; }
        public DbSet<FamilyTreeKeyword> Keywords {get; set;}
        public DbSet<FamilyTreePerson> Persons {get; set;}

    }
}   

