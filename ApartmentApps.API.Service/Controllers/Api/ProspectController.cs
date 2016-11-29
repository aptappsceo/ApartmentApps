using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Prospect;
using Ninject;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/ProspectId")]
    [System.Web.Http.Authorize()]
    public class ProspectController : ApartmentAppsApiController
    {
        private readonly ProspectService _service;

        public ProspectController(ProspectService service, IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            _service = service;
        }

        [System.Web.Mvc.HttpGet, Route("SubmitApplicant")]
        public IHttpActionResult SubmitApplicant(ProspectApplicationBindingModel vm)
        {
            try
            {
                _service.SubmitApplicant(vm);
            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }

        [HttpPost, Route("ScanId"), System.Web.Mvc.HttpPost]
        public ScanIdResult ScanId([FromBody] string base64Image)
        {
            var result = _service.ScanId(base64Image);
            if (result != null)
                return result;
            InternalServerError(new Exception("Couldn't scan ID."));
            return null;
        }
        [HttpPost, Route("ScanIdByText"), System.Web.Mvc.HttpPost]
        public ScanIdResult ScanIdByText([FromBody] string text)
        {
           
            return null;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetDesiredPropertyTypes")]
        public IEnumerable<LookupPairModel> GetDesiredPropertyTypes()
        {
            yield return new LookupPairModel() {Key = "A", Value = "M"};
            //return Kernel.Get<IRepository<>>().GetAll().Select(x => new LookupPairModel() { Key = x.Id.ToString(), Value = x.Name }).ToArray();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetHowdYouHereAboutUsItems")]
        public IEnumerable<LookupPairModel> GetHowdYouHereAboutUsItems()
        {
            yield return new LookupPairModel() { Key = "A", Value = "M" };
            //return Kernel.Get<IRepository<>>().GetAll().Select(x => new LookupPairModel() { Key = x.Id.ToString(), Value = x.Name }).ToArray();
        }
        [System.Web.Http.HttpGet, Route("GetProspectApplications")]
        public IEnumerable<ProspectApplicationBindingModel> GetProspectApplications()
        {
            return _service.GetAll<ProspectApplicationBindingModel>();
        }
        [System.Web.Http.HttpGet, Route("GetProspectApplication")]
        public ProspectApplicationBindingModel GetProspectApplication(string id)
        {
            return _service.Find<ProspectApplicationBindingModel>(id);
        }
        [System.Web.Http.HttpGet, Route("Delete")]
        public void Delete(string id)
        {
            _service.Remove(id);

        }
        [HttpPost, Route("ScanId"), System.Web.Mvc.HttpPost]
        public ServiceResponseBase Save(ProspectApplicationBindingModel model)
        {
            try
            {
                _service.Save(model);
            }
            catch (Exception ex)
            {
                return new ServiceResponseBase(ex.Message);
            }
            
            return new ServiceResponseBase();
        }
    }

    public class ErrorResponse
    {
        
    }
    public class ServiceResponse<TResult> : ServiceResponseBase
    {

        public TResult Result { get; set; }

        public ServiceResponse(TResult result)
        {
            Result = result;
            Success = true;
        }

        public ServiceResponse(string message) : base(message)
        {
            Message = message;
            Success = false;
        }
    }
}