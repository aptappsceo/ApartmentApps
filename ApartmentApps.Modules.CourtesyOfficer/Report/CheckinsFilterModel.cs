using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Modules.CourtesyOfficer.Report
{
    [DisplayName("Checkins Report")]
    public class CheckinsFilterModel
    {
        [DataType(DataType.MultilineText)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
    }
}
