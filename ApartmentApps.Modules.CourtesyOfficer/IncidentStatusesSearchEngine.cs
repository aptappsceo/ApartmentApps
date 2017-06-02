using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;

namespace ApartmentApps.Api
{
    public class IncidentStatusesSearchEngine : SearchEngine<IncidentReportStatus>
    {

        [Filter(nameof(CommonSearch), "Search")]
        public IQueryable<IncidentReportStatus> CommonSearch(IQueryable<IncidentReportStatus> set, string key)
        {
            var tokenize = Tokenize(key);
            if (tokenize.Length > 0)
            {
                return set.Where(item => tokenize.Any(token => item.Name.Contains(token)));
            }
            else
            {
                return set;
            }
        }

    }
}