using System;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class UserLeaseInfo : PropertyEntity
    {

        public string UserId { get; set; }

        //User that must pay
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        //Amount of money to pay
           [Searchable(Caption = "Amount")]
        public decimal Amount { get; set; }

        //Starting point: first invoice will be generated with DueDate equal to InvoiceDate
        public DateTime? NextInvoiceDate { get; set; }

        //Will be here for further extensions
        public int? IntervalDays { get; set; }

        public int? IntervalYears { get; set; }

        public int? IntervalMonths { get; set; }

        //Date, after which (if user commited last payment) LeaseInfo will be Suspended and Archived and not updated any more
        public DateTime? RepetitionCompleteDate { get; set; }

        //The moment when leaseinfo is created
        public DateTime CreateDate { get; set; }

           [Searchable(Caption = "State")]
        public LeaseState State { get; set; }
        
        public string Title { get; set; }

    }
}