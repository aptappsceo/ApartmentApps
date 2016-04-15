using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Data
{
    public class ApplicationDbContext2 : DbContext
    {
        public virtual IDbSet<MaintenanceRequestStatus> MaintenanceRequestStatuses { get; set; }
        public virtual IDbSet<Corporation> Corporations { get; set; }
        public virtual IDbSet<Property> Properties { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual IDbSet<Unit> Units { get; set; }
        public virtual IDbSet<Tenant> Tenants { get; set; }
        public virtual IDbSet<MaitenanceRequest> MaitenanceRequests { get; set; }
        public virtual IDbSet<MaintenanceRequestCheckin> MaintenanceRequestCheckins { get; set; }
        public virtual IDbSet<MaitenanceRequestType> MaitenanceRequestTypes { get; set; }
        public virtual IDbSet<PropertyEntrataInfo> PropertyEntrataInfos { get; set; }
        public virtual IDbSet<PropertyYardiInfo> PropertyYardiInfos { get; set; }

        public virtual IDbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual IDbSet<IdentityRole> Roles { get; set; }
        public ApplicationDbContext2()
        {
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Unit>().Property(p => p.Latitude);
            //modelBuilder.Entity<Unit>().Property(p => p.Longitude).HasPrecision(9, 6);
            //modelBuilder.Entity<CourtesyOfficerLocation>().Property(p => p.Latitude).HasPrecision(9, 6);
            //modelBuilder.Entity<CourtesyOfficerLocation>().Property(p => p.Longitude).HasPrecision(9, 6);
            modelBuilder.Entity<ApplicationUser>().HasKey<string>(l => l.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
           // modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            

            modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
               new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");
        }

        public System.Data.Entity.DbSet<ApartmentApps.Data.MaintenanceRequestStatus> MaintenanceRequestStatus { get; set; }

        public virtual IDbSet<CourtesyOfficerLocation> CourtesyOfficerLocations { get; set; }
        public virtual IDbSet<IncidentReport> IncidentReports { get; set; }
        public virtual IDbSet<IncidentReportCheckin> IncidentReportCheckins { get; set; }
        public virtual IDbSet<IncidentReportStatus> IncidentReportStatuses { get; set; }

        public System.Data.Entity.DbSet<ApartmentApps.Data.IncidentReportStatus> IncidentReportStatus { get; set; }
    }
}