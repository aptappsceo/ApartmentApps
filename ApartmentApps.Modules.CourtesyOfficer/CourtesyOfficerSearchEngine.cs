using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;

namespace ApartmentApps.Api
{
    public class CourtesyOfficerSearchEngine : SearchEngine<IncidentReport>
    {
        
        [Filter(nameof(SearchByType), "Search by type", EditorTypes.SelectMultiple, false, DataSource = nameof(IncidentReportStatus), DataSourceType = typeof(IncidentReportStatus))]
        public IQueryable<IncidentReport> SearchByType(IQueryable<IncidentReport> set, string key)
        {
            return set.Where(item => item.StatusId == key);
        }
    }
}