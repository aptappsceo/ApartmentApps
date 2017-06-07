using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Ninject;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [RoutePrefix("api/Property")]
    public class PropertyController : ServiceController<PropertyService, PropertyFormBindingModel, PropertyFormBindingModel>
    {
        public PropertyController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("entry")]

        public override PropertyFormBindingModel Entry(string id)
        {
            return base.Entry(id);
        }



    }
}