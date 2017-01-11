using System;
using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;

namespace ApartmentApps.Api.BindingModels
{
    public class MaintenanceBindingModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public IEnumerable<string> Photos { get; set; }
        public string UnitName { get; set; }
        public string Status { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int PetStatus { get; set; }
        public MaintenanceCheckinBindingModel[] Checkins { get; set; }
        public UserBindingModel User { get; set; }
        public string BuildingName { get; set; }
        public bool PermissionToEnter { get; set; }
        public List<string> AcceptableCheckinCodes { get; set; }
        public bool CanComplete { get; set; }
        public bool CanPause { get; set; }
        public bool CanSchedule { get; set; }
        public bool CanStart { get; set; }
    }
}