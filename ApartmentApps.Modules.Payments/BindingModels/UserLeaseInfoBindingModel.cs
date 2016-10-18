using System;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api.Modules
{
    public class UserLeaseInfoBindingModel : BaseViewModel
    {
        public virtual UserBindingModel User { get; set; }
        
        public decimal Amount { get; set; }

        public DateTime? NextInvoiceDate  { get; set; }

        public int? IntervalDays { get; set; }

        public int? IntervalMonths { get; set; }

        public int? IntervalYears { get; set; }

        public DateTime? RepetitionCompleteDate { get; set; }

        public DateTime CreateDate { get; set; }

        public LeaseState State { get; set; }
        
        public string Title { get; set; }

        public bool UsesInterval { get;set; }

        public bool UsesCompleteDate { get; set; }

    }

 

    public static class UserLeaseInfoExtensions
    {
        public static UserLeaseInfoBindingModel ToBindingModel(this UserLeaseInfo lease, IBlobStorageService blobStorageService)
        {
            var bm = new UserLeaseInfoBindingModel()
            {
                Amount = lease.Amount,
                Title = lease.Title,
                User = lease.User.ToUserBindingModel(blobStorageService),
                CreateDate = lease.CreateDate,
                NextInvoiceDate = lease.NextInvoiceDate ,
                Id = lease.Id,
                RepetitionCompleteDate = lease.RepetitionCompleteDate,
                IntervalDays = lease.IntervalDays,
                IntervalMonths = lease.IntervalMonths,
                IntervalYears = lease.IntervalYears,
                State = lease.State,
                UsesInterval = lease.IsIntervalSet(),
                UsesCompleteDate = lease.RepetitionCompleteDate.HasValue
            };

            return bm;
        }
    }
}