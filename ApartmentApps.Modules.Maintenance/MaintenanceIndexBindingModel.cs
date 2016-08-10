using System;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.BindingModels
{
    public class MaintenanceIndexBindingModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        public string StatusId { get; set; }
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public UserBindingModel SubmissionBy { get; set; }
        public MaintenanceCheckinBindingModel LatestCheckin { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
    }
}