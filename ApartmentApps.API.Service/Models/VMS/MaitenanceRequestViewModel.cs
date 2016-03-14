using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentApps.API.Service.Models.VMS
{
    public class MaitenanceRequestModel
    {
        public bool PermissionToEnter { get; set; }
        public int PetStatus { get; set; }
        public int UnitId { get; set; }
        public int MaitenanceRequestTypeId { get; set; }
        public string Comments { get; set; }
        public List<string> Images { get; set; }
    }

    public class IncidentReportModel
    {
        public string IncidentReportTypeId { get; set; }
        public string Comments { get; set; }
        public List<Byte[]> Images { get; set; }
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