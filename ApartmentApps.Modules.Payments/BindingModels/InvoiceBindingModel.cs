using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;

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

        public InvoiceState State { get; set; }

    }

    public class TransactionBindingModel
    {
        public string Id { get; set; }
        public string Comments { get; set; }
        public List<InvoiceBindingModel> Invoices { get; set; }
        public TransactionState State { get; set; }
        public UserBindingModel User { get; set; }
        public DateTime? ProcessDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? EstimatedCompleteDate { get; set; }
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
                State = invoice.State
            };

            var tzNow = invoice.UserLeaseInfo.User.Property.TimeZone.Now();
            if(tzNow > invoice.DueDate) invoiceBindingModel.UrgencyState = InvoiceUrgencyState.Urgent;
            else if(tzNow > invoice.AvailableDate) invoiceBindingModel.UrgencyState = InvoiceUrgencyState.Available;
            else invoiceBindingModel.UrgencyState = InvoiceUrgencyState.Upcoming;
            

            return invoiceBindingModel;
        }
    }

    public static class TransactionExtensions 
    {
        public static TransactionBindingModel ToBindingModel(this InvoiceTransaction transaction,
            IBlobStorageService blobStorageService)
        {
            var bm = new TransactionBindingModel()
            {
                Id = transaction.Id,
                User = transaction.User.ToUserBindingModel(blobStorageService),
                Comments = transaction.Comments,
                State = transaction.State,
                Invoices = transaction.Invoices.Select(s=>s.ToBindingModel(blobStorageService)).ToList(),
                CompleteDate = transaction.CompleteDate,
                EstimatedCompleteDate = transaction.EstimatedCompleteDate,
                ProcessDate = transaction.ProcessDate
            };

            return bm;
        }
    }
}