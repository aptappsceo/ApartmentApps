using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models.VMS;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

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
            return
                Context.Units.Where(p => p.Building.PropertyId == propertyId)
                    .ToArray()
                    .Select(p =>
                    {
                        var name = $"[{p.Building?.Name}] {p.Name}";
                        if (p.Users.Any())
                        {
                            var user = p.Users.First();
                            name += $" ({user.FirstName} {user.LastName})";
                        }

                        return new LookupPairModel()
                        {
                            Key = p.Id.ToString(),
                            Value = name
                        };
                    }).OrderByAlphaNumeric(s=>s.Value);
        }

        public LookupsController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }
    }

    public static class LooupsSortExtensions
    {
        public static IEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            int max = source
                .SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?) m.Value.Length))
                .Max() ?? 0;

            return source.OrderBy(i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0')));
        }
    }
}
