using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Description;
using ApartmentApps.Api;
using ApartmentApps.Api.Services;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Maintenance;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.API.Service.Controllers
{

    [Authorize]
    [RoutePrefix("api/Lookups")]
    public class LookupsController : ApartmentAppsApiController
    {

        public LookupsController(IKernel kernel, PropertyContext context, IUserContext userContext, IDataSheet<MaitenanceRequestType> maintenanceRequestTypes, IDataSheet<MaintenanceRequestStatus> maintenanceRequestStatuses, IDataSheet<Unit> units, IDataSheet<ApplicationUser> users) : base(kernel, context, userContext)
        {
            _maintenanceRequestTypes = maintenanceRequestTypes;
            _maintenanceRequestStatuses = maintenanceRequestStatuses;
            _units = units;
            _users = users;
        }

        private readonly IDataSheet<MaintenanceRequestStatus> _maintenanceRequestStatuses;
        private readonly IDataSheet<MaitenanceRequestType> _maintenanceRequestTypes;
        private readonly IDataSheet<Unit> _units;
        private readonly IDataSheet<ApplicationUser> _users;

        [Route("GetLookups", Name = nameof(GetLookups))]
        [HttpGet]
        [ResponseType(typeof(QueryResult<LookupBindingModel>))]
        public IHttpActionResult GetLookups(string type, string search)
        {
            var lookupService = Kernel.Get<LookupService>();
            return Ok(lookupService.GetLookups(Type.GetType(type), search));
        }

        [Route("MaintenanceRequestType", Name = nameof(MaintenanceRequestType))]
        [HttpGet]
        [ResponseType(typeof(QueryResult<LookupBindingModel>))]
        public IHttpActionResult MaintenanceRequestType(string query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Ok(_maintenanceRequestTypes.Query().Get<LookupBindingModel>());
            }
            else
            {
                return Ok(_maintenanceRequestTypes.Query()
                    .Search<MaintenanceRequestTypesSearchEngine>((eng,set)=>eng.CommonSearch(set,query))
                    .Get<LookupBindingModel>());
            }
        }

        [Route("MaintenanceRequestStatus",Name = nameof(MaintenanceRequestStatus))]
        [HttpGet]

        [ResponseType(typeof(QueryResult<LookupBindingModel>))]
        public IHttpActionResult MaintenanceRequestStatus(string query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Ok(_maintenanceRequestStatuses.Query().Get<LookupBindingModel>());
            }
            else
            {
                return Ok(_maintenanceRequestStatuses.Query()
                    .Search<MaintenanceRequestStatusesSearchEngine>((eng, set) => eng.CommonSearch(set, query))
                    .Get<LookupBindingModel>());
            }
        }

        [Route(nameof(LookupUnits), Name = nameof(LookupUnits))]
        [HttpGet]
        [ResponseType(typeof(QueryResult<LookupBindingModel>))]
        public IHttpActionResult LookupUnits(string query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Ok(_units.Query().SkipTake(0,10).Get<LookupBindingModel>());
            }
            else
            {
                return Ok(_units.Query()
                    .SkipTake(0, 20)
                    .Search<UnitSearchEngine>((eng, set) => eng.CommonSearch(set, query))
                    .Get<LookupBindingModel>());
            }
        }

        [Route(nameof(Users), Name = nameof(Users))]
        [HttpGet]
        [ResponseType(typeof(QueryResult<LookupBindingModel>))]
        public IHttpActionResult Users(string query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Ok(_users.Query().SkipTake(0,10).Get<LookupBindingModel>());
            }
            else
            {
                return Ok(_users.Query()
                    .SkipTake(0, 20)
                    .Search<UserSearchEngine>((eng, set) => eng.CommonSearch(set, query))
                    .Get<LookupBindingModel>());
            }
        }


        // GET api/values
        [Route("Units")]
        [HttpGet]
        public IEnumerable<LookupPairModel> GetUnits()
        {
            var propertyId = CurrentUser.PropertyId.Value;
            return
                Context.Units.Where(p => p.Building.PropertyId == propertyId)
                    .ToArray()
                    .Select(p =>
                    {
                        var name = $"[{p.Building?.Name}] {p.Name}";
                        if (p.Users.Any())
                        {
                            var user = p.Users.First();
                            name += $" ({user.FirstName} {user.LastName})";
                        }

                        return new LookupPairModel()
                        {
                            Key = p.Id.ToString(),
                            Value = name
                        };
                    }).OrderByAlphaNumeric(s=>s.Value);
        }

    
    }

    public static class LooupsSortExtensions
    {
        public static IEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            int max = source
                .SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?) m.Value.Length))
                .Max() ?? 0;

            return source.OrderBy(i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0')));
        }
    }
}
