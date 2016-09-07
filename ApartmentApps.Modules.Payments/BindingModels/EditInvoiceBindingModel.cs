using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Modules.Payments.BindingModels
{
    public class EditInvoiceBindingModel
    {
        public int Id { get; set; }

        public DateTime AvailableDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }

    }
}
