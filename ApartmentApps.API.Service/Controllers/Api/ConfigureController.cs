using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.API.Service.Controllers.Api
{
    public class LocationBindingModel
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
    }
    [Authorize(Roles = "PropertyAdmin")]
    public class ConfigureController : ApartmentAppsApiController
    {
        public ConfigureController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddLocation")]
        public void AddLocation(string qrCode, double latitude, double longitude, string label = null)
        {

            string url = qrCode;
            string querystring = url.Substring(url.IndexOf('?'));
            System.Collections.Specialized.NameValueCollection parameters =
               System.Web.HttpUtility.ParseQueryString(querystring);

            if (CurrentUser.PropertyId != null)
            {
                var propertyId = CurrentUser.PropertyId.Value;
                if (parameters["unitid"] != null)
                {
                    var unitId = Convert.ToInt32(parameters["unitid"]);
                    var unit = Context.Units.Find(unitId);
                    if (unit != null)
                    {
                        unit.Latitude = latitude;
                        unit.Longitude = longitude;
                    }
                } else if (parameters["coloc"] != null)
                {
                    var courtesyOfficerLocation = new CourtesyOfficerLocation()
                    {
                        PropertyId = propertyId,
                        Latitude = latitude,
                        Longitude = longitude,
                        LocationId = parameters["coloc"],
                        Label = label ?? "Location " + (Context.CourtesyOfficerLocations.Count() + 1)
                    };
                    Context.CourtesyOfficerLocations.Add(courtesyOfficerLocation);
                }
                else
                {
                    var courtesyOfficerLocation = new CourtesyOfficerLocation()
                    {
                        PropertyId = propertyId,
                        Latitude = latitude,
                        Longitude = longitude,
                        LocationId = parameters["location"],
                        Label = label ?? "Location " + (Context.CourtesyOfficerLocations.Count() + 1)
                    };
                    Context.CourtesyOfficerLocations.Add(courtesyOfficerLocation);
                }
                Context.SaveChanges();
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetLocations")]
        public IEnumerable<LocationBindingModel> GetLocations()
        {
            foreach (var item in Context.CourtesyOfficerLocations.GetAll().Select(p => new LocationBindingModel()
            {
                Id = p.Id,
                Type = "Checkin",
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                Name = p.Label
            }))
            yield return item;
            foreach (var item in Context.Units.Where(p => p.Longitude > 0 && p.Latitude > 0))
            {
                yield return new LocationBindingModel()
                {
                    Id = item.Id,
                    Type = "Unit",
                    Name = item.Building.Name + " " + item.Name,
                    Longitude = item.Longitude,
                    Latitude = item.Latitude
                };
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("DeleteLocation")]
        public void DeleteLocation(int id, string type)
        {
            //if (CurrentUser.PropertyId == null) return;
            //using (var ctx = new ApplicationDbContext())
            //{
              
            if (type.ToLower() == "checkin")
            {
                Context.CourtesyOfficerLocations.Remove(
                    Context.CourtesyOfficerLocations.Find(id));
                Context.SaveChanges();
            }
            //    var item = ctx.CourtesyOfficerLocations.FirstOrDefault(p => p.Id == id && p.PropertyId == propertyId);
            //    ctx.CourtesyOfficerLocations.Remove(item);
            //    ctx.SaveChanges();
            //}
        }
    }
}
