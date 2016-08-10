using System;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.BindingModels
{
    public class IncidentIndexBindingModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        public string StatusId { get; set; }
      
        public DateTime RequestDate { get; set; }
        public UserBindingModel ReportedBy { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public IncidentCheckinBindingModel LatestCheckin { get; set; }
        public string Reporter { get; set; }
    }
}