using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.API.Service.Providers;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Modules.Maintenance;
using Ninject;

namespace ApartmentApps.API.Service.Controllers
{
    [System.Web.Http.RoutePrefix("api/Maitenance")]
    [System.Web.Http.Authorize]
    public class MaitenanceController : ApartmentAppsApiController
    {


        public IMaintenanceService MaintenanceService { get; set; }
        public IBlobStorageService BlobStorageService { get; set; }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("List")]
        public IEnumerable<MaintenanceIndexBindingModel> ListRequests()
        {
            // TODO Move this into mappers
            if (GetConfig<MaintenanceConfig>().SupervisorMode)
            {
                var userId = CurrentUser.Id;
                return
                 Context.MaitenanceRequests.GetAll().Where(p=>p.WorkerAssignedId == userId).OrderByDescending(p => p.SubmissionDate).ToArray().Select(
                     x => new MaintenanceIndexBindingModel()
                     {
                         Title = x.MaitenanceRequestType.Name,
                         RequestDate = x.SubmissionDate,
                         Comments = x.Message,
                         SubmissionBy = x.User.ToUserBindingModel(BlobStorageService),
                         StatusId = x.StatusId,
                         Id = x.Id.ToString(),
                         UnitName = x.Unit?.Name,
                         BuildingName = x.Unit?.Building?.Name,
                         LatestCheckin = x.LatestCheckin?.ToMaintenanceCheckinBindingModel(BlobStorageService)
                     }).ToArray();
            }

            return
                Context.MaitenanceRequests.GetAll().OrderByDescending(p => p.SubmissionDate).ToArray().Select(
                    x => new MaintenanceIndexBindingModel()
                    {
                        Title = x.MaitenanceRequestType.Name,
                        RequestDate = x.SubmissionDate,
                        Comments = x.Message,
                        SubmissionBy = x.User.ToUserBindingModel(BlobStorageService),
                        StatusId = x.StatusId,
                        Id = x.Id.ToString(),
                        UnitName = x.Unit?.Name,
                        BuildingName = x.Unit?.Building?.Name,
                        LatestCheckin = x.LatestCheckin?.ToMaintenanceCheckinBindingModel(BlobStorageService)
                    }).ToArray();

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetRequest")]
        public MaintenanceBindingModel Get(int id)
        {
            var result = Context.MaitenanceRequests
                .Find(id);
            var photos = Context.ImageReferences.Where(r => r.GroupId == result.GroupId).ToList();

            var response = new MaintenanceBindingModel
            {
                User = result.User.ToUserBindingModel(BlobStorageService),
                Status = result.StatusId,
                Name = result.MaitenanceRequestType.Name,
                PetStatus = result.PetStatus,
                AcceptableCheckinCodes = new List<string>()
                    {
                        $"http://www.apartmentapps.com?apt={result.Unit.BuildingId},{result.UnitId}",
                        $"http://www.apartmentapps.com?apt={result.Unit.Building.Name},{result.Unit.Name}"
                    },
                BuildingName = result.Unit?.Building?.Name + " " + result.Unit?.Name,
                PermissionToEnter = result.PermissionToEnter,
                Checkins = result.Checkins.ToArray().Select(x => x.ToMaintenanceCheckinBindingModel(BlobStorageService)).ToArray(),
                ScheduleDate = result.ScheduleDate,
                Message = result.Message,
                Photos = photos.Select(key => BlobStorageService.GetPhotoUrl(key.Url))
            };
            return response;
        }




        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("ScheduleRequest")]
        public void ScheduleRequest(int id, DateTime scheduleDate)
        {
            MaintenanceService.ScheduleRequest(CurrentUser, id, scheduleDate);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SubmitRequest")]
        public void SubmitRequest(MaitenanceRequestModel request)
        {
            var images = request.Images?.Select(Convert.FromBase64String).ToList();
            MaintenanceService.SubmitRequest(request.Comments, request.MaitenanceRequestTypeId, request.PetStatus, request.Emergency, request.PermissionToEnter, images, request.UnitId);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CompleteRequest")]
        public void CompleteRequest(int id, string comments, List<string> images)
        {
            var photos = images?.Select(Convert.FromBase64String).ToList();
            MaintenanceService.CompleteRequest(CurrentUser, id, comments, photos);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PauseRequest")]
        public void PauseRequest(int id, string comments, List<string> images)
        {
            var photos = images?.Select(Convert.FromBase64String).ToList();
            MaintenanceService.PauseRequest(CurrentUser, id, comments, photos);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("StartRequest")]
        public void StartRequest(int id, string comments, List<string> images)
        {
            var photos = images?.Select(Convert.FromBase64String).ToList();
            MaintenanceService.StartRequest(CurrentUser, id, comments, photos);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetMaitenanceRequestTypes")]
        public IEnumerable<LookupPairModel> GetMaitenanceRequestTypes()
        {
            return Context.MaitenanceRequestTypes.GetAll().Select(x => new LookupPairModel() { Key = x.Id.ToString(), Value = x.Name }).ToArray();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWorkOrders")]
        public IEnumerable<MaitenanceRequest> GetWorkOrders(string workerId)
        {
            return null;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetByResident")]
        public IEnumerable<MaitenanceRequest> GetByResident(string workerId)
        {
            return null;
        }

        public MaitenanceController(IKernel kernel, IMaintenanceService maintenanceService, IBlobStorageService blobStorageService,PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
            MaintenanceService = maintenanceService;
            BlobStorageService = blobStorageService;
        }
    }


}
