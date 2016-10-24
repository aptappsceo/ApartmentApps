using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Portal.Controllers;
using ExpressiveAnnotations.Attributes;

namespace ApartmentApps.Api.Modules
{
    public class EditUserLeaseInfoBindingModel : BaseViewModel
    {

        [Required]
        [DisplayName("Title")]
        [Description("User-friendly title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("User")]
        [Description("User that will be charged")]
        public string UserId { get; set; }

        [Required]
        [DisplayName("Amount")]
        [Description("The user will be charged this amount")]
        public decimal Amount { get; set; }

        public bool UseInterval { get; set; }

        public bool UseCompleteDate { get; set; }

        [RequiredIf("UseInterval == true && UseCompleteDate == true",ErrorMessage = "Expiration date is required. Subscription will expire after given date.")]
        public DateTime? CompleteDate { get; set; }

        [RequiredIf("UseInterval == true",ErrorMessage = "Month Interval is required. Invoice will be regenerated every X month(s)")]
        public int? IntervalMonths { get; set; }

        [RequiredIf("UseInterval == true",ErrorMessage = "Next Invoice Date is required. Invoice will be regenerated due to given date")]
        public DateTime? NextInvoiceDate { get;set; }
        
        public List<UserBindingModel> UserIdItems { get; set; }

    }
}