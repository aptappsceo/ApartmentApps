using System;
using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;

namespace ApartmentApps.Api.BindingModels
{
    public class IncidentReportBindingModel
    {
        public string Comments { get; set; }
        public string IncidentType { get; set; }
        public IEnumerable<string> Photos { get; set; }
        public UserBindingModel Requester { get; set; }
        public string RequesterId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public string Status { get; set; }

        public IncidentCheckinBindingModel[] Checkins { get; set; }
        public string RequesterPhoneNumber { get; set; }
        public int? UnitId { get; set; }
        public int Id { get; set; }
    }
}