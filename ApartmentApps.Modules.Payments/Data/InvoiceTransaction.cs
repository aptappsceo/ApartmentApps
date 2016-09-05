using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class InvoiceTransaction
    {
        [Key]
        public string Id { get; set; }

        public InvoiceTransaction()
        {
            Invoices = new List<Invoice>();
        }

        public ICollection<Invoice> Invoices { get; set; }

        public TransactionState State { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public string Comments { get; set; }

        public DateTime? ProcessDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public DateTime? EstimatedCompleteDate { get; set; }

    }
}