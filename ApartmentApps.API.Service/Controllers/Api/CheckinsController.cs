using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/Checkins")]
    [System.Web.Http.Authorize()]
    public class CheckinsController : ApartmentAppsApiController
    {
        [System.Web.Mvc.HttpGet]
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
                        $"http://apartmentapps.com?location={p.LocationId}",
                        $"http://www.apartmentapps.com?coloc={p.LocationId}"
                    }
                });
        }
        [System.Web.Mvc.HttpPost]
        public async Task<IHttpActionResult> Post(int locationId, double latitude= 0, double longitude = 0)
        {
            var location = await Context.CourtesyOfficerLocations.FirstOrDefaultAsync(p => p.Id == locationId);
            if (location == null)
            {
                return this.Content(HttpStatusCode.BadRequest, "Location not found.");
                return this.BadRequest("Location not found.");
            }
            var distanceToCheckin = DistanceCalcs.DistanceInFeet(location.Latitude, location.Longitude, latitude, longitude);
            if (distanceToCheckin < 100)
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
                return Ok();
            }

            return this.Content(HttpStatusCode.BadRequest, $"You must be within 100 ft. You are currently {distanceToCheckin} ft.");
            return this.BadRequest($"You must be within 100 ft. You are currently {distanceToCheckin} ft.");
        }
        public class DistanceCalcs
        {
            /// Calculates the distance between two points of latitude and longitude.
            /// Great Link - http://www.movable-type.co.uk/scripts/latlong.html
            public static Double DistanceInMetres(double lat1, double lon1, double lat2, double lon2)
            {

                if (lat1 == lat2 && lon1 == lon2)
                    return 0.0;

                var theta = lon1 - lon2;

                var distance = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) +
                               Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
                               Math.Cos(deg2rad(theta));

                distance = Math.Acos(distance);
                if (double.IsNaN(distance))
                    return 0.0;

                distance = rad2deg(distance);
                distance = distance * 60.0 * 1.1515 * 1609.344;

                return (distance);
            }
            public static Double DistanceInFeet(double lat1, double lon1, double lat2, double lon2)
            {


                if (lat1 == lat2 && lon1 == lon2)
                    return 0.0;

                var theta = lon1 - lon2;

                var distance = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) +
                               Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
                               Math.Cos(deg2rad(theta));

                distance = Math.Acos(distance);
                if (double.IsNaN(distance))
                    return 0.0;

                distance = rad2deg(distance);
                distance = distance * 60.0 * 1.1515 * 1609.344;

                return (distance) * 3.28084; // feet
            }

            private static double deg2rad(double deg)
            {
                return (deg * Math.PI / 180.0);
            }

            private static double rad2deg(double rad)
            {
                return (rad / Math.PI * 180.0);
            }
        }
        public CheckinsController(ApplicationDbContext context) : base(context)
        {
        }
    }
}