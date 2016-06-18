using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public virtual IDbSet<MaintenanceRequestStatus> MaintenanceRequestStatuses { get; set; }
        public virtual IDbSet<IncidentReportStatus> IncidentReportStatuses { get; set; }
        public virtual IDbSet<Corporation> Corporations { get; set; }
        public virtual IDbSet<Property> Properties { get; set; }
        public virtual IDbSet<ImageReference> ImageReferences { get; set; }
        public virtual IDbSet<Building> Buildings { get; set; }
        public virtual IDbSet<Unit> Units { get; set; }
        public virtual IDbSet<MaitenanceRequest> MaitenanceRequests { get; set; }
        public virtual IDbSet<MaintenanceRequestCheckin> MaintenanceRequestCheckins { get; set; }
        public virtual IDbSet<MaitenanceRequestType> MaitenanceRequestTypes { get; set; }
        public virtual IDbSet<PropertyEntrataInfo> PropertyEntrataInfos { get; set; }
        public virtual IDbSet<PropertyYardiInfo> PropertyYardiInfos { get; set; }
        public virtual IDbSet<CourtesyOfficerLocation> CourtesyOfficerLocations { get; set; }
        public virtual IDbSet<CourtesyOfficerCheckin> CourtesyOfficerCheckins { get; set; }
        public virtual IDbSet<IncidentReport> IncidentReports { get; set; }
        public virtual IDbSet<IncidentReportCheckin> IncidentReportCheckins { get; set; }
        public virtual IDbSet<UserAlert> UserAlerts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!assembly.FullName.StartsWith("ApartmentApps")) continue;
                var entityTypes = assembly
                  .GetTypes()
                  .Where(t =>
                    t.GetCustomAttributes(typeof(PersistantAttribute), inherit: true)
                    .Any() );

                
                foreach (var type in entityTypes)
                modelBuilder.RegisterEntityType(type);
            }
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(p=>p.UserAlerts)
            //    .WithRequired(p=>p.User)
            //    .WillCascadeOnDelete(true);
           
        }

        public ApplicationDbContext()
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class PersistantAttribute : Attribute
    {
    }
}