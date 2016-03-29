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



        public class MaintenanceBindingModel
        {
            public string UserName { get; set; }
            public string UserId { get; set; }
            public string Name { get; set; }
            public string Message { get; set; }
            public string BuildingName { get; set; }
            public string BuildingAddress { get; set; }
            public string BuildingState { get; set; }
            public string BuildingCity { get; set; }
            public IEnumerable<string> Photos { get; set; }
            public string BuildingPostalCode { get; set; }
            public string UnitName { get; set; }
            public string Status { get; set; }
            public string TenantFullName { get; set; }
            public DateTime? ScheduleDate { get; set; }
            public int PetStatus { get; set; }
            public MaintenanceCheckinBindingModel[] Checkins { get; set; }
        }

        public class MaintenanceIndexBindingModel
        {
            public string Title { get; set; }
            public string Comments { get; set; }
            public string StatusId { get; set; }
            public int Id { get; set; }
            public DateTime RequestDate { get; set; }
        }

        public class MaintenanceCheckinBindingModel
        {
            public string StatusId { get; set; }
            public DateTime Date { get; set; }
            public string Comments { get; set; }
            public string WorkerName { get; set; }
            public List<ImageReference> Photos { get; set; }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("List")]
        public IEnumerable<MaintenanceIndexBindingModel> ListRequests()
        {
         
                var propertyId = this.CurrentUser.PropertyId;
                return
                    Context.MaitenanceRequests.Include(r=>r.MaitenanceRequestType).Where(p => p.User.PropertyId == propertyId).Select(
                        x => new MaintenanceIndexBindingModel()
                        {
                            Title = x.MaitenanceRequestType.Name,
                            RequestDate = x.SubmissionDate,
                            Comments = x.Message,
                            StatusId = x.StatusId,
                            Id = x.Id
                        }).ToArray();
            
        }
        
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetRequest")]
        public async Task<MaintenanceBindingModel> Get(int id)
        {
        
                //var userId = CurrentUser.UserName;
                //var user = Db.Users.FirstOrDefault(p => p.UserName == userId);

                var result = await Context.MaitenanceRequests
                    .FirstOrDefaultAsync(p=>p.Id == id);
                var photos = Context.ImageReferences.Where(r => r.GroupId == result.GroupId).ToList();

                var response = new MaintenanceBindingModel
                {
                    UserName = result.User.UserName,
                    Status = result.StatusId,
                    TenantFullName = result.User.FirstName + " " + result.User.LastName,
                    UserId = result.UserId,
                    BuildingAddress = result.User.Tenant?.Address,
                    BuildingCity= result.User.Tenant?.City,
                    BuildingPostalCode= result.User.Tenant?.PostalCode,
                    BuildingState= result.User.Tenant?.State,
                    Name = result.MaitenanceRequestType.Name,
                    PetStatus = result.PetStatus,
                    Checkins = result.Checkins.ToArray().Select(x=>
                    {
                        var imageReferences = Context.ImageReferences.Where(r => r.GroupId == x.GroupId).ToList();
                        foreach (var reference in imageReferences)
                        {
                            reference.Url = BlobStorageService.GetPhotoUrl(reference.Url); //This call replaces RELATIVE url with ABSOLUTE url. ( STORAGE SERVICE + IMAGE URL)
                                                                                           //This is done to make URLs independent from the service, which is used to store them.                            
                                                                                           //It needs some cleanup later maybe
                        }
                        return new MaintenanceCheckinBindingModel
                        {
                            StatusId = x.StatusId,
                            Date = x.Date,
                            Comments = x.Comments,
                            WorkerName = x.Worker.UserName,
                            Photos = imageReferences
                        };
                    }).ToArray(),
                    ScheduleDate = result.ScheduleDate,
                    Message = result.Message, BuildingName = result.Unit?.Building?.Name, UnitName = result.Unit?.Name,
                    Photos = photos.Select(key=> BlobStorageService.GetPhotoUrl(key.Url))
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
            MaintenanceService.SubmitRequest(CurrentUser, request.Comments, request.MaitenanceRequestTypeId,request.PetStatus,request.PermissionToEnter, images);
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
