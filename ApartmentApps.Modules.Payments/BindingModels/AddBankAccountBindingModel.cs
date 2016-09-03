using System;
using System.Collections.Generic;
using System.ComponentModel;
using ApartmentApps.Api.ViewModels;

namespace ApartmentApps.Api.Modules
{
    public class AddBankAccountBindingModel
    {
        [DisplayName("Is Savings?")]
        [Description("If unchecked a checking account is used.")]
        public bool IsSavings { get; set; }

        [DisplayName("Account Holder Name")]
        public string AccountHolderName { get; set; }

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [DisplayName("Routing Number")]
        public string RoutingNumber { get; set; }

        [DisplayName("Friendly Name")]
        [Description("A friendly name that you can use for this account.")]
        public string FriendlyName { get; set; }
    }

    public class CreateUserLeaseInfoBindingModel
    {
        public string Title { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }

        public DateTime InvoiceDate { get; set; }
        
        public int? IntervalDays { get; set; }
        public int? IntervalMonths { get; set; }
        public int? IntervalYears { get; set; }

        public DateTime? RepetitionCompleteDate { get; set; }

        public List<UserBindingModel> UserIdItems { get; set; }
    }
}