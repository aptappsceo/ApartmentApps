using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Data
{
    public class ApplicationDbContext2 : DbContext
    {
        public virtual IDbSet<MaintenanceRequestStatus> MaintenanceRequestStatuses { get; set; }
        public virtual IDbSet<Corporation> Corporations { get; set; }
        public virtual IDbSet<Property> Properties { get; set; }
        public virtual IDbSet<Building> Buildings { get; set; }
        public virtual IDbSet<Unit> Units { get; set; }
        public virtual IDbSet<Tenant> Tenants { get; set; }
        public virtual IDbSet<MaitenanceRequest> MaitenanceRequests { get; set; }
        public virtual IDbSet<MaitenanceAction> MaitenanceActions { get; set; }
        public virtual IDbSet<MaitenanceRequestType> MaitenanceRequestTypes { get; set; }
        public virtual IDbSet<PropertyAddon> PropertyAddons { get; set; }
        public virtual IDbSet<PropertyAddonType> PropertyAddonTypes { get; set; }
        public virtual IDbSet<PropertyEntrataInfo> PropertyEntrataInfos { get; set; }
        public virtual IDbSet<PropertyYardiInfo> PropertyYardiInfos { get; set; }
        public virtual IDbSet<ApplicationUser> Users { get; set; }
        public virtual IDbSet<IdentityRole> Roles { get; set; }

        public ApplicationDbContext2()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasKey<string>(l => l.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public System.Data.Entity.DbSet<ApartmentApps.Data.ApplicationUser> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<ApartmentApps.Data.MaintenanceRequestStatus> MaintenanceRequestStatus { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual IDbSet<MaintenanceRequestStatus> MaintenanceRequestStatuses { get; set; }
        public virtual IDbSet<Corporation> Corporations { get; set; }
        public virtual IDbSet<Property> Properties { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual IDbSet<Unit> Units { get; set; }
        public virtual IDbSet<Tenant> Tenants { get; set; }
        public virtual IDbSet<MaitenanceRequest> MaitenanceRequests { get; set; }
        public virtual IDbSet<MaitenanceAction> MaitenanceActions { get; set; }
        public virtual IDbSet<MaitenanceRequestType> MaitenanceRequestTypes { get; set; }
        public virtual IDbSet<PropertyAddon> PropertyAddons { get; set; }
        public virtual IDbSet<PropertyAddonType> PropertyAddonTypes { get; set; }
        public virtual IDbSet<PropertyEntrataInfo> PropertyEntrataInfos { get; set; }
        public virtual IDbSet<PropertyYardiInfo> PropertyYardiInfos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

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