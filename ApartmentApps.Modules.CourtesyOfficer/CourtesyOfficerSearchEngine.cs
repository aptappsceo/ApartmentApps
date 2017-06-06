using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;

namespace ApartmentApps.Api
{
    public class CourtesyOfficerSearchEngine : SearchEngine<IncidentReport>
    {
        
        [Filter(nameof(SearchByType), "Search By Type", EditorTypes.CheckboxList, false, DataSource = nameof(IncidentReportStatus), DataSourceType = typeof(IncidentReportStatus))]
        public IQueryable<IncidentReport> SearchByType(IQueryable<IncidentReport> set, List<string> key)
        {
            return set.Where(item => key.Contains(item.StatusId));
        }
        [Filter(nameof(SearchByUser), "Search By User", EditorTypes.SelectMultiple, false, DataSource = nameof(ApplicationUser), DataSourceType = typeof(ApplicationUser))]
        public IQueryable<IncidentReport> SearchByUser(IQueryable<IncidentReport> set, List<string> key)
        {
            return set.Where(item => key.Contains(item.UserId));
        }
    }
}