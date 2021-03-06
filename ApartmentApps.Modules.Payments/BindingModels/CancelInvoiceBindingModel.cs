﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Modules.Payments.BindingModels
{
    public class CancelInvoiceBindingModel
    {
        public int Id { get; set; }
        public UserLeaseInfoAction UserLeaseInfoAction { get;set; }
    }

    public enum UserLeaseInfoAction
    {
        GenerateNextInvoice,
        Cancel
    }
}
