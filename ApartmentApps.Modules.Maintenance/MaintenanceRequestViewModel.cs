using System;
using System.Collections.Generic;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.ViewModels
{
    public class MaintenanceRequestIndexBindingModel
    {
        public string RequestType { get; set; }
        public string Building { get; set; }
        public string Unit { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public string Requestor { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public DateTime CompletedBy { get; set; }
    }
    public class MaintenanceRequestViewModel : BaseViewModel
    {
        private UserBindingModel[] _tenants;
        public DateTime? ScheduleDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Title { get; set; }
        public DateTime RequestDate { get; set; }
        public string Comments { get; set; }
        public UserBindingModel SubmissionBy { get; set; }
        public UserBindingModel CompletedBy { get; set; }

        public string SubmissionByFullName
        {
            get { return SubmissionBy.FullName; }
        }

        public string CompletedByFullName
        {
            get { return CompletedBy?.FullName; }
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
        public string AssignedToId { get; set; }
        public UserBindingModel AssignedTo { get; set; }
        public string Description { get; set; }

        public ActionLinkModel AssignLink { get; set; }

        public UserBindingModel[] Tenants
        {
            get { return _tenants ?? (_tenants = new UserBindingModel[0]); }
            set { _tenants = value; }
        }
    }



}