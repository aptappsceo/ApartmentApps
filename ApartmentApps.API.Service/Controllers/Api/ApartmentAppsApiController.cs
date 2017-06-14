using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
//using System.Web.Http.Cors;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.Schema;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;
using Ninject;

namespace ApartmentApps.API.Service.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApartmentAppsApiController : ApiController
    {
        public IKernel Kernel { get; set; }
        public PropertyContext Context { get; }
        public IUserContext UserContext { get; set; }

        //public ApplicationUserManager UserManager
        //{
        //    get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        //}
        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            if (UserContext.CurrentUser != null)
            {
                if (UserContext.CurrentUser.LastMobileLoginTime == null || UserContext.CurrentUser.LastMobileLoginTime.Value.Add(new TimeSpan(1, 0, 0)) < DateTime.UtcNow)
                {
                    UserContext.CurrentUser.LastMobileLoginTime = DateTime.UtcNow;
                    Kernel.Get<ApplicationDbContext>().SaveChanges();
                }
            }
            
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }

        [NonAction]
        public TConfig GetConfig<TConfig>() where TConfig : PropertyModuleConfig, new()
        {
            var config = UserContext.GetConfig<TConfig>();
            return config;
        }

        public ApplicationUser CurrentUser => UserContext.CurrentUser;

        public ApartmentAppsApiController(IKernel kernel, PropertyContext context, IUserContext userContext)
        {
            Kernel = kernel;
            Context = context;
            UserContext = userContext;
        }

        protected JObject CreateSchema(Type type, string[] ignoreProperties = null)
        {
            var jObject = new JObject();
            var jProperties = (JObject) (jObject["properties"] = new JObject());
            var jRequired = (JArray) (jObject["required"] = new JArray());
            foreach (var property in type.GetProperties(BindingFlags.Default | BindingFlags.Public | BindingFlags.NonPublic |
                                                        BindingFlags.Instance))
            {
                if (property.Name.EndsWith("_Items") || property.Name == "ActionLinks") continue;
                if (property.Name == ("Id") || property.Name == "Title") continue;
                if (ignoreProperties != null && ignoreProperties.Contains(property.Name)) continue;
                var jProperty = (JObject) (jProperties[property.Name] = new JObject());
                jProperty["name"] = property.Name;
                jProperty["type"] = MapType(property.PropertyType);
                if (property.IsDefined(typeof(DisplayNameAttribute)))
                {
                    var att = property.GetCustomAttributes<DisplayNameAttribute>().First();
                    jProperty["title"] = att.DisplayName;
                }
                else
                {
                    jProperty["title"] = property.Name;
                }

                jProperty["widget"] = MapWidgetType(property);
                if (property.PropertyType.IsEnum)
                {
                    var enumNames = Enum.GetNames(property.PropertyType);
                    var enumValues = Enum.GetValues(property.PropertyType).Cast<int>().ToArray();
                    var oneOf = (JArray) (jProperty["oneOf"] = new JArray());
                    for (var i = 0; i < enumNames.Length; i++)
                    {
                        var jItem = new JObject();
                        var jEnum = (JArray) (jItem["enum"] = new JArray());
                        jEnum.Add(enumValues[i].ToString());
                        jItem["description"] = enumNames[i].ToString();
                        oneOf.Add(jItem);
                    }
                }
                if (property.IsDefined(typeof(RemoteSelectAttribute)))
                {
                    var att = property.GetCustomAttributes<RemoteSelectAttribute>().First();
                    jProperty["remote"] = att.SelectType.AssemblyQualifiedName;
                    jProperty["remote_filter"] = att.Filter;
                    jProperty["widget"] = "select-remote";
                    jProperty["type"] = "string";
                }
                if (property.IsDefined(typeof(RequiredAttribute)))
                {
                    jRequired.Add(property.Name);
                }
            }
            return jObject;
        }

        private string MapWidgetType(PropertyInfo property)
        {
            //string: string, search, tel, url, email, password, color, date, date-time, time, textarea, select, file, radio, richtext
            //number: number, integer, range
            //integer: integer, range
            //boolean: boolean, checkbox
            if (property.IsDefined(typeof(WidgetAttribute)))
            {
                return property.GetCustomAttributes<WidgetAttribute>().First().WidgetName;
            }
            if (property.PropertyType.IsEnum)
            {
                return "radio";
            }
            return MapType(property.PropertyType);
        }

        private string MapType(Type type)
        {
            if (type == typeof(DateTime))
                return "date-time";
            if (type == typeof(string))
                return "string";
            if (type == typeof(bool))
                return "boolean";
            if (type == typeof(int))
                return "integer";
            if ( type == typeof(float) || type== typeof(double) || type== typeof(decimal) || type == typeof(long) || type == typeof(short))
                return "number";

            return "string";
        }
    }
}