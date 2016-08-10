using System;
using System.Collections.Generic;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{
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
}