using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.API.Service.Models;
using ApartmentApps.Data;
using ApartmentApps.Data.ActionModels;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Data.Repository;
using Ninject;
using Ploeh.Hyprlinkr;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [Authorize, RoutePrefix("api/searches")]
    public class SearchEnginesController : ApartmentAppsApiController
    {
        private readonly RouteLinker _linker;
        private ISearchCompiler _searchCompiler;

        public SearchEnginesController(RouteLinker linker, IKernel kernel, PropertyContext context, IUserContext userContext, ISearchCompiler searchCompiler) : base(kernel, context, userContext)
        {
            _linker = linker;
            _searchCompiler = searchCompiler;
        }

        [ResponseType(typeof(SearchModelGetResponse))]
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetSearchModel(string id)
        {
            var serverModel = _searchCompiler.Get(id);
            var request = HttpContext.Current.Request; 
            var clientModel = new SearchModelGetResponse()
            {
                Model = new ClientSearchModel()
                {
                    Id = serverModel.Id,
                    Filters = serverModel.Filters.Values.Select(_ => new ClientSearchFilterModel()
                    {
                        Id = _.Id,
                        DataSource = ConvertDataSource(_.DataSource).ToString(),
                        DataSourceType = _.DataSourceType.AssemblyQualifiedName,
                        DefaultActive = _.DefaultActive,
                        EditorType = _.EditorType,
                        Description = _.Description,
                        Title = _.Title
                    }).ToList()
                }
            };

            return Ok(clientModel);
        }

        private Uri ConvertDataSource(string argDataSource)
        {
            if (argDataSource == nameof(MaitenanceRequest))
            {
                return null;
            } else if (argDataSource == nameof(MaitenanceRequestType))
            {
                return _linker.GetUri<LookupsController>(c => c.MaintenanceRequestType(""));
            }
            else if (argDataSource == nameof(MaintenanceRequestStatus))
            {
                return _linker.GetUri<LookupsController>(c => c.MaintenanceRequestStatus(""));
            }
            else if (argDataSource == nameof(Unit))
            {
                return _linker.GetUri<LookupsController>(c => c.LookupUnits(""));
            }
            else if (argDataSource == nameof(ApplicationUser))
            {
                return _linker.GetUri<LookupsController>(c => c.Users(""));
            }
            else if (argDataSource == nameof(IncidentReportStatus))
            {
                return _linker.GetUri<CourtesyController>(c => c.IncidentStatuses(""));
            }
            return new Uri("http://nothing");
        }
    }
}