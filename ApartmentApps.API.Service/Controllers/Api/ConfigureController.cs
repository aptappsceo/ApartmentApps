using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers.Api
{
    public class ConfigureController : ApartmentAppsApiController
    {
        public void AddCourtesyLocation(Guid guid, decimal latitude, decimal longitude)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (CurrentUser.PropertyId != null)
                    ctx.CourtesyOfficerLocations.Add(new CourtesyOfficerLocation()
                    {
                        PropertyId = CurrentUser.PropertyId.Value,
                        Latitude = latitude,
                        Longitude = longitude,
                        LocationId = guid.ToString()
                    });
            }
        }
    }
}
