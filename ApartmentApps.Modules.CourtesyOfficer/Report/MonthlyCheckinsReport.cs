using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Modules.CourtesyOfficer.Report
{
    public class OfficerReportHelper
    {
        private IUserContext UserContext { get; set; }
        private IRepository<CourtesyOfficerCheckin> OffficerCheckins { get; set; }
        public OfficerReportHelper(IUserContext userContext, IRepository<CourtesyOfficerCheckin> checkins)
        {
            UserContext = userContext;
            OffficerCheckins = checkins;
        }
        public CheckinReportViewModel CreateMonthlyCheckinsReport(CheckinsFilterModel filterModel)
        {
            var checkinFiltered = OffficerCheckins.Where(s => s.PropertyId == UserContext.CurrentUser.PropertyId && s.CreatedOn >= filterModel.StartDate && s.CreatedOn <= filterModel.EndDate).Distinct().ToArray();
            var checkinPerDate = checkinFiltered.GroupBy(s => s.CreatedOn);
            var reportVM = new CheckinReportViewModel();
            reportVM.CheckinListPerDate = checkinPerDate.ToList();
            reportVM.PropertyName = UserContext.CurrentUser.Property.Name;
            reportVM.StartDate = filterModel.StartDate.GetValueOrDefault();
            reportVM.EndDate = filterModel.EndDate.GetValueOrDefault();
            return reportVM;
        }
    }
}
