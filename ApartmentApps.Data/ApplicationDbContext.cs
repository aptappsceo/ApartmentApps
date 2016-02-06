using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.API.Service.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Property> Properties { get; set; }
        //public DbSet<Building> Buildings { get; set; }
        //public DbSet<Unit> Units { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<MaitenanceRequest> MaitenanceRequests { get; set; }
        public DbSet<MaitenanceAction> MaitenanceActions { get; set; }
        public DbSet<MaitenanceRequestType> MaitenanceRequestTypes { get; set; }
        public DbSet<PropertyAddon> PropertyAddons { get; set; }
        public DbSet<PropertyAddonType> PropertyAddonTypes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}