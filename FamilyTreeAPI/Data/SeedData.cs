using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FamilyTreeAPI.Data;
using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Data {

    public class SeedData {

        public static void SeedDatabase(ApplicationDbContext context) {            
            // if (context.Database.GetMigrations().Count() > 0
            //         && context.Database.GetPendingMigrations().Count() == 0
            //         && context.FamilyTreePersons.Count() == 0) {

            // }
        }
    }
}
