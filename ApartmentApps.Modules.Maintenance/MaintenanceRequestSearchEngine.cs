using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.DataSheets;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using Ninject;

namespace ApartmentApps.Modules.Maintenance
{

    public class MaintenanceRequestDataSheet : BasePropertyDataSheet<MaitenanceRequest>
    {
        public MaintenanceRequestDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler) : base(userContext, dbContext, kernel, searchCompiler)
        {

        }

        protected override IQueryable<MaitenanceRequest> DefaultOrderFilter(IQueryable<MaitenanceRequest> set, Query query = null)
        {
            return set.OrderByDescending(req => req.Id);
        }
    }

    public class MaintenanceRequestTypeDataSheet : BaseDataSheet<MaitenanceRequestType>
    {
        public MaintenanceRequestTypeDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler) : base(userContext, dbContext, kernel, searchCompiler)
        {

        }

        protected override IQueryable<MaitenanceRequestType> DefaultOrderFilter(IQueryable<MaitenanceRequestType> set, Query query = null)
        {
            return set.OrderBy(s => s.Name);
        }
    }
    public class MaintenanceRequestStatusDataSheet : BaseDataSheet<MaintenanceRequestStatus>
    {
        public MaintenanceRequestStatusDataSheet(IUserContext userContext, ApplicationDbContext dbContext, IKernel kernel, ISearchCompiler searchCompiler) : base(userContext, dbContext, kernel, searchCompiler)
        {

        }

        protected override IQueryable<MaintenanceRequestStatus> DefaultOrderFilter(IQueryable<MaintenanceRequestStatus> set, Query query = null)
        {
            return set.OrderBy(s => s.Name);
        }

        public override object StringToPrimaryKey(string id)
        {
            return id;
        }
    }

    public class MaintenanceRequestSearchEngine : SearchEngine<MaitenanceRequest>
    {
        
        [Filter(nameof(SearchByType),"Search by type", EditorTypes.SelectMultiple, false, DataSource = nameof(MaitenanceRequestType))]
        public IQueryable<MaitenanceRequest> SearchByType(IQueryable<MaitenanceRequest> set, List<int> keys)
        {
            return set.Where(item => keys.Any(key => item.MaitenanceRequestTypeId == key));
        }

        [Filter(nameof(SearchByStatus),"Search by status", EditorTypes.SelectMultiple, false, DataSource = nameof(MaintenanceRequestStatus))]
        public IQueryable<MaitenanceRequest> SearchByStatus(IQueryable<MaitenanceRequest> set, List<string> names)
        {
            if (names?.Count <= 0) return set;
            return set.Where(item => names.Any(name => item.StatusId == name));
        }

        [Filter(nameof(SearchByUnits),"Search by units", EditorTypes.TypeaheadMultiple, false, DataSource = nameof(Unit))]
        public IQueryable<MaitenanceRequest> SearchByUnits(IQueryable<MaitenanceRequest> set, List<int> unitIds)
        {
            if (unitIds?.Count <= 0) return set;
            return set.Where(item => unitIds.Any(unitId => item.UnitId == unitId));
        }

        [Filter(nameof(SearchByUsers),"Search by users", EditorTypes.TypeaheadMultiple, false, DataSource = nameof(ApplicationUser))]
        public IQueryable<MaitenanceRequest> SearchByUsers(IQueryable<MaitenanceRequest> set, List<string> userIds)
        {
            if (userIds?.Count <= 0) return set;
            return set.Where(item => userIds.Any(_=> item.UserId == _));
        }

    }

    public class MaintenanceRequestTypesSearchEngine : SearchEngine<MaitenanceRequestType>
    {

        [Filter(nameof(CommonSearch), "Search")]
        public IQueryable<MaitenanceRequestType> CommonSearch(IQueryable<MaitenanceRequestType> set, string key)
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
    public class MaintenanceRequestStatusesSearchEngine : SearchEngine<MaintenanceRequestStatus>
    {

        [Filter(nameof(CommonSearch), "Search")]
        public IQueryable<MaintenanceRequestStatus> CommonSearch(IQueryable<MaintenanceRequestStatus> set, string key)
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
