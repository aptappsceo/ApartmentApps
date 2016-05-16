using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;

namespace ApartmentApps.Api
{
    public class CourtesyOfficerService : StandardCrudService<CourtesyOfficerCheckin, CourtesyCheckinViewModel>
    {
        public IUserContext UserContext { get; set; }
        public IRepository<CourtesyOfficerLocation> Locations { get; set; }

        public CourtesyOfficerService(IRepository<CourtesyOfficerCheckin> repository) : base(repository)
        {
        }

        public CourtesyOfficerService(IUserContext userContext, IRepository<CourtesyOfficerLocation> locations, IRepository<CourtesyOfficerCheckin> repository) : base(repository)
        {
            UserContext = userContext;
            Locations = locations;
        }

        public override void ToModel(CourtesyCheckinViewModel viewModel, CourtesyOfficerCheckin model)
        {
            
        }

        public override void ToViewModel(CourtesyOfficerCheckin model, CourtesyCheckinViewModel viewModel)
        {
            
        }

        public IEnumerable<CourtesyCheckinBindingModel> ForDay(DateTime? date)
        {
            var today = date ?? this.UserContext.CurrentUser.TimeZone.Now();
       
            foreach (var p in Locations.GetAll().ToArray())
            {
                var item = p.CourtesyOfficerCheckins.FirstOrDefault(
                    x =>
                        x.CreatedOn.Day == today.Day && x.CreatedOn.Year == today.Year &&
                        x.CreatedOn.Month == today.Month);
                yield return ToCourtesyCheckinBindingModel(p, item);
            }
        }
        public IEnumerable<CourtesyCheckinBindingModel> ForWeek(DateTime? date)
        {
            var today = date ?? this.UserContext.CurrentUser.TimeZone.Now();
            var calendar = new GregorianCalendar();
            var week = calendar.GetWeekOfYear(today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            var last7DaysCheckins =
                Repository.Where(x => (x.CreatedOn.Day <= today.Day && x.CreatedOn.Day > today.Day - 7 ) && x.CreatedOn.Year == today.Year &&
                                      x.CreatedOn.Month == today.Month).ToList();
            last7DaysCheckins.RemoveAll(
                p => calendar.GetWeekOfYear(p.CreatedOn, CalendarWeekRule.FirstDay, DayOfWeek.Monday) != week);

            foreach (var p in Locations.GetAll().ToArray())
            {
                var item = last7DaysCheckins.FirstOrDefault(x=>x.CourtesyOfficerLocationId == p.Id);
               
                    yield return ToCourtesyCheckinBindingModel(p, item);
            }
        }

        private static CourtesyCheckinBindingModel ToCourtesyCheckinBindingModel(CourtesyOfficerLocation p,
            CourtesyOfficerCheckin item)
        {
            return new CourtesyCheckinBindingModel
            {
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                Label = p.Label,
                Id = p.Id,
                Date = item?.CreatedOn,
                Complete = item != null,
                AcceptableCheckinCodes = new List<string>()
                {
                    $"http://apartmentapps.com?location={p.LocationId}",
                    $"http://www.apartmentapps.com?coloc={p.LocationId}"
                }
            };
        }
    }
}