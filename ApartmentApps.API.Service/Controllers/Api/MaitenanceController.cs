﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.API.Service.Providers;
using ApartmentApps.Data;

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

            var propertyId = this.CurrentUser.PropertyId;
            return
                Context.MaitenanceRequests.Include(r => r.MaitenanceRequestType)
                .Where(p => p.User.PropertyId == propertyId).OrderByDescending(p => p.SubmissionDate).ToArray().Select(
                    x => new MaintenanceIndexBindingModel()
                    {
                        Title = x.MaitenanceRequestType.Name,
                        RequestDate = x.SubmissionDate,
                        Comments = x.Message,
                        SubmissionBy = x.User.ToUserBindingModel(BlobStorageService),
                        StatusId = x.StatusId,
                        Id = x.Id,
                        UnitName = x.Unit?.Name,
                        BuildingName = x.Unit?.Building?.Name,
                        LatestCheckin = x.LatestCheckin?.ToMaintenanceCheckinBindingModel(BlobStorageService)
                    }).ToArray();

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetRequest")]
        public async Task<MaintenanceBindingModel> Get(int id)
        {
            var result = await Context.MaitenanceRequests
                .FirstOrDefaultAsync(p => p.Id == id);
            var photos = Context.ImageReferences.Where(r => r.GroupId == result.GroupId).ToList();

            var response = new MaintenanceBindingModel
            {
                User = result.User.ToUserBindingModel(BlobStorageService),
                Status = result.StatusId,
                Name = result.MaitenanceRequestType.Name,
                PetStatus = result.PetStatus,
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
            MaintenanceService.SubmitRequest(CurrentUser, request.Comments, request.MaitenanceRequestTypeId, request.PetStatus, request.PermissionToEnter, images);
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
            return Context.MaitenanceRequestTypes.Select(x => new LookupPairModel() { Key = x.Id.ToString(), Value = x.Name }).ToArray();
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

        public MaitenanceController(IMaintenanceService maintenanceService, IBlobStorageService blobStorageService, ApplicationDbContext context) : base(context)
        {
            MaintenanceService = maintenanceService;
            BlobStorageService = blobStorageService;
        }
    }


}
