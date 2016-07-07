using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Data;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{

    // Models used as parameters to AccountController actions.
    public class UserBindingModel : BaseViewModel
    {

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
        public string Email { get; set; }
    }

    public class MaintenanceRequestViewModel : BaseViewModel
    {
        public DateTime? ScheduleDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Title { get; set; }
        public DateTime RequestDate { get; set; }
        public string Comments { get; set; }
        public UserBindingModel SubmissionBy { get; set; }

        public string SubmissionByFullName
        {
            get { return SubmissionBy.FullName; }
        }

        public string StatusId { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public MaintenanceCheckinBindingModel LatestCheckin { get; set; }
        public IEnumerable<MaintenanceCheckinBindingModel> Checkins { get; set; }
        public string MainImage { get; set; }

        public bool PermissionToEnter { get; set; }
        public int PetStatus { get; set; }
        public bool HasPet { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
    }

    public class CourtesyCheckinViewModel : BaseViewModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Label { get; set; }
        public List<string> AcceptableCheckinCodes { get; set; }

        public bool Complete { get; set; }
    }

    public class IncidentReportViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public DateTime RequestDate { get; set; }
        public string Comments { get; set; }
        public UserBindingModel SubmissionBy { get; set; }
        public string StatusId { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public IncidentCheckinBindingModel LatestCheckin { get; set; }
        public IEnumerable<IncidentCheckinBindingModel> Checkins { get; set; }
    }
    [DisplayName("Buildings")]
    public class BuildingViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }
    [DisplayName("Messages")]
    public class MessageViewModel : BaseViewModel
    {
        public string Body { get; set; }
        public string Title { get; set; }
        public int SentToCount { get; set; }
        public DateTime? SentOn { get; set; }
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
