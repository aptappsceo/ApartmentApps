using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [Authorize(Roles="PropertyAdmin")]
    public class ConfigureController : ApartmentAppsApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddCourtesyLocation")]
        public CourtesyOfficerLocation AddCourtesyLocation(string locationId, decimal latitude, decimal longitude, string label = null)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (CurrentUser.PropertyId != null)
                {
                    var propertyId = CurrentUser.PropertyId.Value;
                    
                    var courtesyOfficerLocation = new CourtesyOfficerLocation()
                    {
                        PropertyId = propertyId,
                        Latitude = latitude,
                        Longitude = longitude,
                        LocationId = locationId,
                        Label = label ?? "Location " + (ctx.CourtesyOfficerLocations.Count(p=>p.PropertyId == propertyId) + 1)
                    };
                    ctx.CourtesyOfficerLocations.Add(courtesyOfficerLocation);
                    ctx.SaveChanges();
                    return courtesyOfficerLocation;
                }
                return null;
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetLocations")]
        public IEnumerable<CourtesyOfficerLocation> GetLocations()
        {
            if (CurrentUser.PropertyId == null) return Enumerable.Empty<CourtesyOfficerLocation>();
            using (var ctx = new ApplicationDbContext())
            {
                var propertyId = CurrentUser.PropertyId.Value;
                return ctx.CourtesyOfficerLocations.Where(p => p.PropertyId == propertyId);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("DeleteCourtesyLocation")]
        public void DeleteCourtesyLocation(int id)
        {
            if (CurrentUser.PropertyId == null) return;
            using (var ctx = new ApplicationDbContext())
            {
                var propertyId = CurrentUser.PropertyId.Value;
                var item =ctx.CourtesyOfficerLocations.FirstOrDefault(p => p.Id == id && p.PropertyId == propertyId);
                ctx.CourtesyOfficerLocations.Remove(item);
                ctx.SaveChanges();
            }
        }
    }
}
