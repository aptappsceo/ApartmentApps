using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentApps.API.Service.Models.VMS
{
    public class MaitenanceRequestModel
    {
        public int MaitenanceRequestTypeId { get; set; }
        public string Comments { get; set; }
    }

    public class Response
    {
        public bool Error { get; set; }
        public string Message { get; set; }
    }

    public class LookupPairModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}