﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers.Api
{
    public class LocationBindingModel
    {
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
    }
    [Authorize(Roles = "PropertyAdmin")]
    public class ConfigureController : ApartmentAppsApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddLocation")]
        public void AddLocation(string qrCode, decimal latitude, decimal longitude, string label = null)
        {

            string url = qrCode;
            string querystring = url.Substring(url.IndexOf('?'));
            System.Collections.Specialized.NameValueCollection parameters =
               System.Web.HttpUtility.ParseQueryString(querystring);


            using (var ctx = new ApplicationDbContext())
            {
                if (CurrentUser.PropertyId != null)
                {
                    var propertyId = CurrentUser.PropertyId.Value;
                    if (parameters["unitid"] != null)
                    {
                        var unitId = Convert.ToInt32(parameters["unitid"]);
                        var unit = ctx.Units.FirstOrDefault(p => p.Id == unitId);
                        if (unit != null)
                        {
                            unit.Latitude = latitude;
                            unit.Longitude = longitude;
                        }
                    }
                    else
                    {
                        var courtesyOfficerLocation = new CourtesyOfficerLocation()
                        {
                            PropertyId = propertyId,
                            Latitude = latitude,
                            Longitude = longitude,
                            LocationId = parameters["location"],
                            Label = label ?? "Location " + (ctx.CourtesyOfficerLocations.Count(p => p.PropertyId == propertyId) + 1)
                        };
                        ctx.CourtesyOfficerLocations.Add(courtesyOfficerLocation);
                    }
                    ctx.SaveChanges();

                }

            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetLocations")]
        public IEnumerable<LocationBindingModel> GetLocations()
        {
            //if (CurrentUser.PropertyId == null)
            //return Enumerable.Empty<LocationBindingModel>();
            using (var ctx = new ApplicationDbContext())
            {
                var propertyId = CurrentUser.PropertyId.Value;

                foreach (var item in ctx.CourtesyOfficerLocations.Where(p => p.PropertyId == propertyId).Select(p => new LocationBindingModel()
                {
                    Id = p.Id,
                    Type = "Checkin",
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Name = p.Label
                })) yield return item;
                foreach (var item in ctx.Units.Include(p => p.Building).Where(p => p.Longitude > 0 && p.Latitude > 0 && p.Building.PropertyId == propertyId))
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
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("DeleteLocation")]
        public void DeleteLocation(int id, string type)
        {
            //if (CurrentUser.PropertyId == null) return;
            //using (var ctx = new ApplicationDbContext())
            //{
            //    var propertyId = CurrentUser.PropertyId.Value;
            //    var item = ctx.CourtesyOfficerLocations.FirstOrDefault(p => p.Id == id && p.PropertyId == propertyId);
            //    ctx.CourtesyOfficerLocations.Remove(item);
            //    ctx.SaveChanges();
            //}
        }
    }
}
