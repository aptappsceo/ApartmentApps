using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class Invoice
    {
        
        [Key]
        public int Id { get; set; }

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
        public ICollection<Invoice> TransactionHistoryItems { get; set; }

    }

    public static class InvoiceRepositoryExtensions
    {
        public static IEnumerable<Invoice> GetAvailableBy(this IRepository<Invoice> repo, DateTime by)
        {
            return repo.Where(i => !i.IsArchived && i.AvailableDate < by && i.State == InvoiceState.NotPaid);
        }
    }
}