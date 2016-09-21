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

        [ForeignKey(nameof(PaymentTransactionId))]
        public virtual InvoiceTransaction PaymentTransaction { get; set; }

        public string PaymentTransactionId { get; set; } //Id of operation on Forte/else where

        public InvoiceState State { get; set; }
        public string Title { get; set; }
    }

    public static class InvoiceRepositoryExtensions
    {
        public static IEnumerable<Invoice> GetAvailableBy(this IRepository<Invoice> repo, DateTime by)
        {
            return repo.Where(i => !i.IsArchived && i.AvailableDate < by && i.State == InvoiceState.NotPaid);
        }
    }
}