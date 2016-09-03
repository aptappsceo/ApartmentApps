using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string Comments { get; set; }
    }
}