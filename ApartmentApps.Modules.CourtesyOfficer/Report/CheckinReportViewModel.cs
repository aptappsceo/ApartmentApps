using ApartmentApps.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Modules.CourtesyOfficer.Report
{
    public class CheckinReportViewModel
    {
        public List<IGrouping<DateTime, CourtesyOfficerCheckin>> CheckinListPerDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PropertyName { get; set; }
    }
}
