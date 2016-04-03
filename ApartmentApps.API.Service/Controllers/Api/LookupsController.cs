﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;

namespace ApartmentApps.API.Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/Lookups")]
    public class LookupsController : ApartmentAppsApiController
    {
        // GET api/values
        [Route("Units")]
        [HttpGet]
        public IEnumerable<LookupPairModel> GetUnits()
        {
            var propertyId = CurrentUser.PropertyId.Value;
            return Context.Units.Include(p=>p.Building).Where(p => p.Building.PropertyId == propertyId).OrderBy(p=>p.Building.Name).ThenBy(p=>p.Name).ToArray().Select(p => new LookupPairModel()
            {
                Key = p.Id.ToString(),
                Value = $"Building - {p.Building?.Name} Unit - {p.Name}"
            });
           
        }

        public LookupsController(ApplicationDbContext context) : base(context)
        {
        }
    }
}