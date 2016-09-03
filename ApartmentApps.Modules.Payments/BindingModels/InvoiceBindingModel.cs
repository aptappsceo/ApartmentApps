using System;
using System.Collections.Generic;

namespace ApartmentApps.Api.Modules
{
    public class InvoiceBindingModel
    {
        public int Id { get; set; }

        public UserLeaseInfoBindingModel UserLeaseInfo { get; set; }

        public decimal Amount { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime AvailableDate { get; set; }

        public InvoiceUrgencyState UrgencyState { get; set; }
    }

    public class TransactionBindingModel
    {
        
        public int Id { get; set; }
        public string Comments { get; set; }
        public List<Invoice> Invoices { get; set; }
        public TransactionState State { get; set; }

    }

    public static class InvoiceExtensions
    {
        public static InvoiceBindingModel ToBindingModel(this Invoice invoice,
            IBlobStorageService blobStorageService)
        {
            var invoiceBindingModel = new InvoiceBindingModel()
            {
                Id = invoice.Id,
                UserLeaseInfo = invoice.UserLeaseInfo.ToBindingModel(blobStorageService),
                Amount = invoice.Amount,
                Title = invoice.Title,
                DueDate = invoice.DueDate,
                AvailableDate = invoice.AvailableDate,
            };

            var tzNow = invoice.UserLeaseInfo.User.Property.TimeZone.Now();
            if(tzNow > invoice.DueDate) invoiceBindingModel.UrgencyState = InvoiceUrgencyState.Urgent;
            else if(tzNow > invoice.AvailableDate) invoiceBindingModel.UrgencyState = InvoiceUrgencyState.Available;
            else invoiceBindingModel.UrgencyState = InvoiceUrgencyState.Upcoming;
            

            return invoiceBindingModel;
        }
    }
}