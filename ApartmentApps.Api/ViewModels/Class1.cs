using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{
    // Models used as parameters to AccountController actions.
    public class UserBindingModel : BaseViewModel
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public bool IsTenant { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
    public class MaintenanceRequestViewModel : BaseViewModel
    {
        public DateTime? ScheduleDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Title { get; set; }
        public DateTime RequestDate { get; set; }
        public string Comments { get; set; }
        public UserBindingModel SubmissionBy { get; set; }
        public string StatusId { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public MaintenanceCheckinBindingModel LatestCheckin { get; set; }
        public IEnumerable<MaintenanceCheckinBindingModel> Checkins { get; set; }
        public string MainImage { get; set; }

        public bool PermissionToEnter { get; set; }
        public int PetStatus { get; set; }
        public bool HasPet { get; set; }
    }

    public class IncidentReportViewModel : BaseViewModel
    {
        
    }
    public class BuildingViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }
    public class UnitViewModel :BaseViewModel
    {
        public string Name { get; set; }
        public string BuildingName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int BuildingId { get; set; }
    }
}
