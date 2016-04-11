using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApartmentApps.Data.Repository
{
    public class PropertyContext
    {
        private readonly ApplicationDbContext _db;

        public PropertyContext(ApplicationDbContext db, IRepository<ApplicationUser> users,IRepository<IdentityRole> roles,
            IRepository<MaintenanceRequestStatus> maintenanceRequestStatuses, 
            IRepository<IncidentReportStatus> incidentReportStatuses, 
            IRepository<Corporation> corporations, 
            IRepository<Property> properties, 
            IRepository<ImageReference> imageReferences, 
            IRepository<Building> buildings, 
            IRepository<Unit> units, 
            IRepository<Tenant> tenants, 
            IRepository<MaitenanceRequest> maitenanceRequests, 
            IRepository<MaintenanceRequestCheckin> maintenanceRequestCheckins, 
            IRepository<MaitenanceRequestType> maitenanceRequestTypes, 
            IRepository<PropertyEntrataInfo> propertyEntrataInfos, 
            IRepository<PropertyYardiInfo> propertyYardiInfos, 
            IRepository<CourtesyOfficerLocation> courtesyOfficerLocations, 
            IRepository<CourtesyOfficerCheckin> courtesyOfficerCheckins, 
            IRepository<IncidentReport> incidentReports, 
            IRepository<IncidentReportCheckin> incidentReportCheckins, 
            IRepository<UserAlert> userAlerts)
        {
            _db = db;
            Users = users;
            Roles = roles;
            MaintenanceRequestStatuses = maintenanceRequestStatuses;
            IncidentReportStatuses = incidentReportStatuses;
            Corporations = corporations;
            Properties = properties;
            ImageReferences = imageReferences;
            Buildings = buildings;
            Units = units;
            Tenants = tenants;
            MaitenanceRequests = maitenanceRequests;
            MaintenanceRequestCheckins = maintenanceRequestCheckins;
            MaitenanceRequestTypes = maitenanceRequestTypes;
            PropertyEntrataInfos = propertyEntrataInfos;
            PropertyYardiInfos = propertyYardiInfos;
            CourtesyOfficerLocations = courtesyOfficerLocations;
            CourtesyOfficerCheckins = courtesyOfficerCheckins;
            IncidentReports = incidentReports;
            IncidentReportCheckins = incidentReportCheckins;
            UserAlerts = userAlerts;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public IRepository<ApplicationUser> Users { get; set; }
        public IRepository<IdentityRole> Roles { get; set; }
        public virtual IRepository<MaintenanceRequestStatus> MaintenanceRequestStatuses { get; set; }
        public virtual IRepository<IncidentReportStatus> IncidentReportStatuses { get; set; }
        public virtual IRepository<Corporation> Corporations { get; set; }
        public virtual IRepository<Property> Properties { get; set; }
        public virtual IRepository<ImageReference> ImageReferences { get; set; }
        public virtual IRepository<Building> Buildings { get; set; }
        public virtual IRepository<Unit> Units { get; set; }
        public virtual IRepository<Tenant> Tenants { get; set; }
        public virtual IRepository<MaitenanceRequest> MaitenanceRequests { get; set; }
        public virtual IRepository<MaintenanceRequestCheckin> MaintenanceRequestCheckins { get; set; }
        public virtual IRepository<MaitenanceRequestType> MaitenanceRequestTypes { get; set; }
        public virtual IRepository<PropertyEntrataInfo> PropertyEntrataInfos { get; set; }
        public virtual IRepository<PropertyYardiInfo> PropertyYardiInfos { get; set; }
        public virtual IRepository<CourtesyOfficerLocation> CourtesyOfficerLocations { get; set; }
        public virtual IRepository<CourtesyOfficerCheckin> CourtesyOfficerCheckins { get; set; }
        public virtual IRepository<IncidentReport> IncidentReports { get; set; }
        public virtual IRepository<IncidentReportCheckin> IncidentReportCheckins { get; set; }
        public virtual IRepository<UserAlert> UserAlerts { get; set; }

        public void Entry(object obj)
        {
          this._db.Entry(obj).State = EntityState.Modified;
        }
  
    }
    public interface IRepository<T> : IEnumerable<T>
    {
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T Find(object id);
        int Count();
    }
}