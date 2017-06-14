using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Data.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ninject;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/Modules")]
    [System.Web.Http.Authorize(Roles="Admin")]
    public class ModulesController : ApartmentAppsApiController
    {
        public ModulesController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SaveConfig")]
        public IHttpActionResult SaveConfig(string moduleName, [FromBody] string configJson)
        {
            var module = Kernel.Get<IModuleHelper>().AllModules.First(p => p.Name == moduleName);
            var config = JsonConvert.DeserializeObject(configJson, module.ConfigType);
            var dbContext = Kernel.Get<ApplicationDbContext>();
            var propertyEntity = config as IPropertyEntity;
            if (propertyEntity != null)
            {
                propertyEntity.PropertyId = UserContext.PropertyId;
            }
            var userEntity = config as IUserEntity;
            if (userEntity != null)
            {
                userEntity.UserId = UserContext.UserId;
            }
            dbContext.Entry(propertyEntity);
            dbContext.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetConfig")]
        public IHttpActionResult GetConfig(string moduleName)
        {
            var module = Kernel.Get<IModuleHelper>().AllModules.First(p => p.Name == moduleName);

            return Ok(module.ModuleConfig);

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ModuleSchemas")]
        [ResponseType(typeof(object[]))]
        public HttpResponseMessage ModuleSchemas()
        {
            var ignore = new[] {"Property", "PropertyId", "CreateDate"};
            var schemas = Kernel.Get<IModuleHelper>().AllModules.Select(p =>
            {
                var schema = CreateSchema(p.ConfigType,ignore);
                var jobj= new JObject();
                jobj["schema"] = schema;
                jobj["name"] = p.Name;
                return jobj;
            });
            var jarray = new JArray();
            foreach (var item in schemas)
                jarray.Add(item);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jarray.ToString(Formatting.Indented), Encoding.UTF8, "application/json");
            return response;

        }
    }
}