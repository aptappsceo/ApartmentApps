using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Forms;
using ApartmentApps.Portal.Controllers;
using ExpressiveAnnotations.Attributes;
using Ninject;

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
        [RequiredIf("UseInterval == true || Id == null",ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        [AssertThat("NotBeforeToday(NextInvoiceDate)",ErrorMessage = "Invoice date must be future date")]
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
        [AssertThat("NotBefore(NextInvoiceDate,CompleteDate)",ErrorMessage = "Complete date must be after invoice date")]
        [DataType(DataType.Date)]
        public DateTime? CompleteDate { get; set; }
        
        public List<UserLookupBindingModel> UserIdItems { get; set; }

        public bool NotBeforeToday(DateTime? time)
        {
            if (!time.HasValue) return true;
            return CurrentUserDateTime.Now() < time.Value;

        }

        public bool NotBefore(DateTime? past, DateTime? future)
        {
            if (!past.HasValue || !future.HasValue)
            {
                return true;
            }

            return past.Value < future.Value;

        }

    }
}