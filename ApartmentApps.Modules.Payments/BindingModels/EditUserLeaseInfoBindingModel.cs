using System;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Portal.Controllers;
using ExpressiveAnnotations.Attributes;

namespace ApartmentApps.Api.Modules
{
    public class EditUserLeaseInfoBindingModel : BaseViewModel
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public bool UseInterval { get; set; }

        public bool UseCompleteDate { get; set; }

        [RequiredIf("UseInterval == true && UseCompleteDate == true",ErrorMessage = "Expiration date is required. Subscription will expire after given date.")]
        public DateTime? CompleteDate { get; set; }

        [RequiredIf("UseInterval == true",ErrorMessage = "Month Interval is required. Invoice will be regenerated every X month(s)")]
        public int? IntervalMonths { get; set; }

        [RequiredIf("UseInterval == true",ErrorMessage = "Next Invoice Date is required. Invoice will be regenerated due to given date")]
        public DateTime? NextInvoiceDate { get;set; }

    }
}