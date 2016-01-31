using ApartmentApps.API.Service.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.API.Service.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApartmentApps.API.Service.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApartmentApps.API.Service.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Roles.AddOrUpdate(
                  new IdentityRole { Id = "Maintenance",Name = "Maintenance" },
                  new IdentityRole { Id = "Resident",Name = "Resident" },
                  new IdentityRole { Id = "Officer" ,Name = "Officer" },
                  new IdentityRole { Id = "PropertyAdmin",Name = "PropertyAdmin" }
            );
        }
    }
}
