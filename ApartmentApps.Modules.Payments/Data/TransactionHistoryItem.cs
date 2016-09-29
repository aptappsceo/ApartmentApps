using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;

namespace ApartmentApps.Modules.Payments.Data
{
    public class TransactionHistoryItem
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        public string CommiterId { get; set; }

        [ForeignKey(nameof(CommiterId))]
        public virtual ApplicationUser Commiter { get; set; }

        public PaymentVendor Service { get; set; }

        public decimal Amount { get; set; }

        public decimal ConvenienceFee { get; set; }

        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public TransactionState State { get; set; }

        public string Trace { get; set; }

        public string StateMessage { get; set; }

        [InverseProperty("TransactionHistoryItems")]
        public ICollection<Invoice> Invoices { get; set; }

    }

    public enum PaymentVendor
    {
        Forte = 0 //Default
    }

}
