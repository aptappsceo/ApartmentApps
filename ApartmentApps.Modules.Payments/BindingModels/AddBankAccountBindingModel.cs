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
    public class AddBankAccountBindingModel
    {
        
        [DisplayName("User to bind bank account")]
        [SelectFrom(nameof(Users))]
        [Required]
        public string UserId { get; set; }
        
        [DisplayName("Friendly Name")]
        [Description("A friendly name such, that you can identify this account.")]
        [Required]
        public string FriendlyName { get; set; }
    
        [DisplayName("Account Holder Name")]
        [Required]
        public string AccountHolderName { get; set; }

        [DisplayName("Account Number")]
        [Required]
        public string AccountNumber { get; set; }

        [DisplayName("Routing Number")]
        [Required]
        public string RoutingNumber { get; set; }

        [DisplayName("Is Savings?")]
        [Description("If unchecked a checking account is used.")]
        [Required]
        public bool IsSavings { get; set; }

        public List<UserLookupBindingModel> Users { get; set; }
    }

    public class CreateUserLeaseInfoBindingModel
    {
        [Required]
        [DisplayName("Title")]
        [Description("User-friendly title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("User")]
        [Description("User that will be charged")]
        [SelectFrom(nameof(Users))]
        public string UserId { get; set; }

        [Required]
        [DisplayName("Amount")]
        [Description("The user will be charged this amount")]
        public decimal Amount { get; set; }

        [Required]
        [DisplayName("Invoice Date")]
        [Description("Date, by which user has to pay the invoice")]
        public DateTime InvoiceDate { get; set; }
        
        public int? IntervalDays { get; set; }

        [RequiredIf("UseInterval == true",ErrorMessage = "Month Interval is required. Invoice will be regenerated every X month(s)")]
        public int? IntervalMonths { get; set; }
        public int? IntervalYears { get; set; }

        [RequiredIf("UseInterval == true && UseCompleteDate == true",ErrorMessage = "Expiration date is required. Subscription will expire after given date.")]
        public DateTime? RepetitionCompleteDate { get; set; }

        public List<UserLookupBindingModel> Users { get; set; }

        public bool UseInterval { get; set; }

        public bool UseCompleteDate { get; set; }
    }
}