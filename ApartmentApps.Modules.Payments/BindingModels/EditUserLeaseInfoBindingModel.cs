using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using ExpressiveAnnotations.Attributes;

namespace ApartmentApps.Api.Modules
{
    public class EditUserLeaseInfoBindingModel : BaseViewModel
    {

        [Required]
        [DisplayName("Reasonable name for the payment request")]
        public string Title { get; set; }

        [Required]
        [DisplayName("User that will be charged")]
        [SelectFrom(nameof(UserIdItems))]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Amount that will be charged in USD")]
        public decimal Amount { get; set; }

        [DisplayName("Create invoice due")]
        [RequiredIf("UseInterval == true || Id == null")]
        [DataType(DataType.Date)]
        public DateTime? NextInvoiceDate { get;set; }

        [DisplayName("Create subscription ?")]
        [Description("Subscription allows to repeat invoices with a certain interval")]
        [ToggleCategory("IntervalSettings")]
        public bool UseInterval { get; set; }

        [DisplayName("Interval in months")]
        [WithCategory("IntervalSettings")]
        [RequiredIf("UseInterval == true")]
        public int? IntervalMonths { get; set; }

        [DisplayName("Set expiration date ?")]
        [WithCategory("IntervalSettings")]
        [ToggleCategory("ExpirationSettings")]
        public bool UseCompleteDate { get; set; }

        [DisplayName("Close subscription on")]
        [WithCategory("IntervalSettings ExpirationSettings")]
        [RequiredIf("UseInterval == true && UseCompleteDate == true")]
        [DataType(DataType.Date)]
        public DateTime? CompleteDate { get; set; }
        
        public List<UserBindingModel> UserIdItems { get; set; }

    }
}