﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers.Api
{


    public class IncidentReportBindingModel
    {
        public string Comments { get; set; }
        public string IncidentType { get; set; }
        public IEnumerable<string> Photos { get; set; }
        public UserBindingModel Requester { get; set; }
        public string RequesterId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UnitName { get; set; }
        public string BuildingName { get; set; }
        public string Status { get; set; }

        public IncidentCheckinBindingModel[] Checkins { get; set; }
        public string RequesterPhoneNumber { get; set; }
    }
    public class IncidentCheckinBindingModel
    {
        public string StatusId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public List<ImageReference> Photos { get; set; }
  
        public UserBindingModel Officer { get; set; }
    }

    [System.Web.Http.RoutePrefix("api/Courtesy")]
    [System.Web.Http.Authorize]
    public class CourtesyController : ApartmentAppsApiController
    {

        public IBlobStorageService BlobStorageService { get; set; }
        public ICourtesyService CourtesyService { get; set; }

        public CourtesyController(ICourtesyService courtesyService, IBlobStorageService blobStorageService, ApplicationDbContext context) :base (context)
        {
            CourtesyService = courtesyService;
            BlobStorageService = blobStorageService;
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("List")]
        public IEnumerable<IncidentIndexBindingModel> ListRequests()
        {
         
                var propertyId = this.CurrentUser.PropertyId;

                return
                    Context.IncidentReports.Include(r => r.IncidentReportStatus)
                    .Where(p => p.User.PropertyId == propertyId).ToArray().Select(
                        x => new IncidentIndexBindingModel()
                        {
                            Title = x.IncidentType.ToString(),
                            Comments = x.Comments,
                            RequestDate = x.CreatedOn,
                            ReportedBy = x.User.ToUserBindingModel(BlobStorageService),
                            StatusId = x.StatusId,
                            Id = x.Id
                        }).ToArray();
            
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetIncidentReport")]
        public async Task<IncidentReportBindingModel> Get(int id)
        {

          
                var result = await Context.IncidentReports
                    .Include(p=>p.User.Tenant)
                    .Include(p=>p.User.Tenant.Unit)
                    .Include(p=>p.User.Tenant.Unit.Building)
                    .Include(p=>p.Checkins)
                    .FirstOrDefaultAsync(p => p.Id == id);
                //var userId = CurrentUser.UserName;
                //var user = Db.Users.FirstOrDefault(p => p.UserName == userId);
                var photos = Context.ImageReferences.Where(r => r.GroupId == result.GroupId).ToList();

                var response = new IncidentReportBindingModel()
                {
                    Comments = result.Comments,

                    Requester = result.User.ToUserBindingModel(BlobStorageService),
                    Status = result.StatusId,
                    CreatedOn = result.CreatedOn,
                    IncidentType = result.IncidentType.ToString(),
                    Checkins = result.Checkins.ToArray().Select(x => new IncidentCheckinBindingModel
                    {
                        StatusId = x.StatusId,
                        Date = x.CreatedOn,
                        Comments = x.Comments,
                        Officer = x.Officer.ToUserBindingModel(BlobStorageService),
                     
                        
                        Photos = Context.ImageReferences.Where(r => r.GroupId == x.GroupId).ToList()
                    }).ToArray(),
                    Photos = photos.Select(key => BlobStorageService.GetPhotoUrl(key.Url))
                };
                return response;
            

        }

       

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SubmitIncidentReport")]
        public void SubmitIncidentReport(IncidentReportModel request)
        {
            CourtesyService.SubmitIncidentReport(CurrentUser, request.Comments, request.IncidentReportTypeId,
                request.Images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("OpenIncidentReport")]
        public void OpenIncidentReport(int id, string comments, List<Byte[]> images)
        {
            CourtesyService.OpenIncidentReport(CurrentUser, id, comments, images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PauseIncidentReport")]
        public void PauseIncidentReport(int id, string comments, List<Byte[]> images)
        {
            CourtesyService.PauseIncidentReport(CurrentUser, id, comments, images);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CloseIncidentReport")]
        public void CloseIncidentReport(int id, string comments, List<Byte[]> images)
        {
            CourtesyService.CloseIncidentReport(CurrentUser, id, comments, images);
        }

        

    }
    [System.Web.Http.RoutePrefix("api/Checkins")]
    [System.Web.Http.Authorize()]
    public class CheckinsController : ApartmentAppsApiController
    {
        [HttpGet]
        public IEnumerable<CourtesyCheckinBindingModel> Get()
        {
            var propertyId = CurrentUser.PropertyId.Value;
            var today = CurrentUser.TimeZone.Now();
            return Context.CourtesyOfficerLocations.Where(p => p.PropertyId == propertyId).ToArray()
                .Select(p => new CourtesyCheckinBindingModel
                {
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Label = p.Label,
                    Id = p.Id,
                    Complete = p.CourtesyOfficerCheckins
                        .Any(x=>x.CreatedOn.DayOfYear == today.DayOfYear),
                    AcceptableCheckinCodes = new List<string>()
                    {
                        $"http://apartmentapps.com?location={p.LocationId}"
                    }
                });
        }
        [HttpPost]
        public void Post(int locationId)
        {
            Context.CourtesyOfficerCheckins.Add(new CourtesyOfficerCheckin()
            {
                CourtesyOfficerLocationId = locationId,
                Comments = string.Empty,
                OfficerId = CurrentUser.Id,
                CreatedOn = CurrentUser.TimeZone.Now(),
                GroupId = Guid.NewGuid(),
                

            });
            Context.SaveChanges();
        } 

        public CheckinsController(ApplicationDbContext context) : base(context)
        {
        }
    }

    public class CourtesyCheckinBindingModel
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Label { get; set; }
        public List<string> AcceptableCheckinCodes { get; set; }
        public int Id { get; set; }
        public bool Complete { get; set; }
    }

    public class IncidentIndexBindingModel
    {
        public string Title { get; set; }
        public string Comments { get; set; }
        public string StatusId { get; set; }
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public UserBindingModel ReportedBy { get; set; }
    }
}