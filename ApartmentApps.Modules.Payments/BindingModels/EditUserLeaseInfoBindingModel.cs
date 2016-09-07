using System;

namespace ApartmentApps.Api.Modules
{
    public class EditUserLeaseInfoBindingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public bool UseInterval { get; set; }
        public bool UseCompleteDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public int IntervalMonths { get; set; }
        public DateTime InvoiceDate { get;set; }

    }
}