using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules.Corporations;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [RoutePrefix("api/Corporation")]
    public class CorporationController : ServiceController<CorporationService, CorporationIndexBindingModel, CorporationIndexBindingModel>
    {
        public CorporationController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("schema")]
        public override HttpResponseMessage Schema()
        {
            return base.Schema();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("fetch")]
        public override Task<QueryResult<CorporationIndexBindingModel>> Fetch(Query query)
        {
            return base.Fetch(query);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("entry")]
        public override CorporationIndexBindingModel Entry(string id)
        {
            return base.Entry(id);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("delete")]
        public override Task<IHttpActionResult> Delete(string id)
        {
            return base.Delete(id);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("save")]
        public override Task<IHttpActionResult> Save(CorporationIndexBindingModel entry)
        {
            return base.Save(entry);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("excel")]
        public override IHttpActionResult ToExcel(Query query)
        {
            return base.ToExcel(query);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("pdf")]
        public override Task<IHttpActionResult> ToPDF(Query query)
        {
            return base.ToPDF(query);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("activate")]
        public IHttpActionResult Activate(string id)
        {
            var user = UserContext.CurrentUser;
            user.PropertyId = Convert.ToInt32(id);
            Context.SaveChanges();
            return Ok();
        }

    }
}