using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Payments.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class Invoice : PropertyEntity
    {
        public Invoice()
        {
            TransactionHistoryItems = new HashSet<TransactionHistoryItem>();
        }

        public int UserLeaseInfoId { get; set; }

        [ForeignKey(nameof(UserLeaseInfoId))]
        public virtual UserLeaseInfo UserLeaseInfo { get;set; }

        public decimal Amount { get; set; }

        public DateTime AvailableDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsArchived { get; set; }

        public InvoiceState State { get; set; }
        public string Title { get; set; }

        [InverseProperty("Invoices")]
        public ICollection<TransactionHistoryItem> TransactionHistoryItems { get; set; }

    }

    public static class InvoiceRepositoryExtensions
    {
        public static IEnumerable<Invoice> GetAvailableBy(this IRepository<Invoice> repo, DateTime by, string forUserId)
        {
            return repo.Where(i => i.UserLeaseInfo.UserId == forUserId && !i.IsArchived && i.AvailableDate < by && i.State == InvoiceState.NotPaid);
        }
    }
}