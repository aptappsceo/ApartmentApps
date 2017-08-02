using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Frameworx.GMap;
using Ninject;

namespace ApartmentApps.Api
{
    public class CourtesyOfficerService : StandardCrudService<CourtesyOfficerCheckin>
    {
        private readonly IMapper<ApplicationUser, UserBindingModel> _userMapper;

        public CourtesyOfficerService(IMapper<ApplicationUser, UserBindingModel> userMapper, IRepository<CourtesyOfficerCheckin> repository, IUserContext userContext, IRepository<CourtesyOfficerLocation> locations, IKernel kernel) : base(kernel,repository)
        {
            _userMapper = userMapper;
            UserContext = userContext;
            Locations = locations;
        }

        public IUserContext UserContext { get; set; }
        public IRepository<CourtesyOfficerLocation> Locations { get; set; }


        public DailyOfficerReport GetDailyReport()
        {
            return new DailyOfficerReport()
            {
                Checkins = ForDay(UserContext.CurrentUser.TimeZone.Now().Subtract(new TimeSpan(1,0,0,0,0)))
            };
        }
        public IEnumerable<CourtesyCheckinBindingModel> ForRange(DateTime? startDay, DateTime? endDay)
        {
            foreach (var p in Locations.GetAll().ToArray())
            {
                var item = p.CourtesyOfficerCheckins.FirstOrDefault(
                    x =>
                        x.CreatedOn >= startDay && x.CreatedOn <= endDay);
                yield return ToCourtesyCheckinBindingModel(p, item);
            }
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
               if (item != null)
                    yield return ToCourtesyCheckinBindingModel(p, item);
            }
        }

        private CourtesyCheckinBindingModel ToCourtesyCheckinBindingModel(CourtesyOfficerLocation p,
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
                Officer = _userMapper.ToViewModel(item.Officer),
                AcceptableCheckinCodes = new List<string>()
                {
                    $"http://apartmentapps.com?location={p.LocationId}",
                    $"http://www.apartmentapps.com?coloc={p.LocationId}"
                }
            };
        }
    }
}