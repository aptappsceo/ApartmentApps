using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers.Api
{
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
}