﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.API.Service.Providers;
using ApartmentApps.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ApartmentApps.API.Service.Controllers
{
    public class ApartmentAppsApiController : ApiController
    {

        public ApplicationUserManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }
        public ApplicationUser CurrentUser
        {
            get
            {
                var user = UserManager.FindByName(User.Identity.Name);
                return user;//user.Email
            }
        }
    }

    [System.Web.Http.RoutePrefix("api/Maitenance")]
    [System.Web.Http.Authorize]
    public class MaitenanceController : ApartmentAppsApiController
    {


        public IMaintenanceService MaintenanceService { get; set; }
        public ApplicationDbContext Context { get; set; }


        public class MaintenanceBindingModel
        {
            public string UserName { get; set; }
            public string UserId { get; set; }
            public string Name { get; set; }
            public string Message { get; set; }
            public string BuildingName { get; set; }
            public string UnitName { get; set; }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetRequest")]
        public async Task<MaintenanceBindingModel> Get(int id)
        {
            using (Context = new ApplicationDbContext())
            {
                //var userId = CurrentUser.UserName;
                //var user = Context.Users.FirstOrDefault(p => p.UserName == userId);

                var result = await Context.MaitenanceRequests
                    
                    .FirstOrDefaultAsync(p=>p.Id == id);
                return new MaintenanceBindingModel
                {
                    UserName = result.User.UserName,
                    UserId = result.UserId,
                    Name = result.MaitenanceRequestType.Name,
                    Message = result.Message, BuildingName = result.Unit?.Building?.Name, UnitName = result.Unit?.Name
                };
            }
           
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SubmitRequest")]
        public void SubmitRequest(MaitenanceRequestModel request)
        {
            MaintenanceService.SubmitRequest(CurrentUser, request.Comments, request.MaitenanceRequestTypeId);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CompleteRequest")]
        public void CompleteRequest(int id, string comments, List<Byte[]> images)
        {
            MaintenanceService.CompleteRequest(CurrentUser, id, comments);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PauseRequest")]
        public void PauseRequest(int id, string comments, List<Byte[]> images)
        {
            MaintenanceService.PauseRequest(CurrentUser, id, comments, images);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PauseRequest")]
        public void StartRequest(int id, string comments, List<Byte[]> images)
        {
            MaintenanceService.StartRequest(CurrentUser, id, comments, images);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetMaitenanceRequestTypes")]
        public IEnumerable<LookupPairModel> GetMaitenanceRequestTypes()
        {
            using (Context = new ApplicationDbContext())
            {
                return Context.MaitenanceRequestTypes.Select(x => new LookupPairModel() { Key = x.Id.ToString(), Value = x.Name }).ToArray();
            }
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

        public MaitenanceController()
        {
        }

        public MaitenanceController(IMaintenanceService maintenanceService) 
        {
            MaintenanceService = maintenanceService;
        }
    }


}
