using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.NewFolder1;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;
using ApartmentApps.Data.Repository;
using ApartmentApps.Portal.Controllers;
using Frameworx.GMap;
using Ninject;
using StaticMap.Core.Model;
using StaticMap.Google;

namespace ApartmentApps.Api
{
    public class DailyOfficerReport : EmailData
    {
        public IEnumerable<CourtesyCheckinBindingModel> Checkins { get; set; }

        public GeoCoordinate Center
        {
            get
            {
                return GetCentralGeoCoordinate(
                    Checkins.Select(x => new GeoCoordinate(x.Latitude, x.Longitude)).ToList());
            }
        }

        public string StaticMapUrl
        {
            get
            {
                
                var center = Center;
                var staticMap = new GoogleStaticMapUrlBuilder("https://maps.googleapis.com/maps/api/staticmap")
                    .SetCenter(new Point(center.Latitude,center.Longitude));
                foreach (var item in Checkins.Where(p => p.Complete))//
                {
                    staticMap.AddMarker(new StaticMap.Core.Model.Marker(new Point(item.Latitude, item.Longitude))
                    {
                        DrawColor = HttpUtility.UrlEncode(item.Complete ? "green" : "grey"),
                       // Label = Uri.EscapeUriString(item.Label)
                    });
                }
                staticMap.SetZoom(17);
                return staticMap.Build(500, 500) +"&key=AIzaSyDjBsoydtvTc55SZZsqlJZQMstPtyIs3z8";
            }
        }

        public static GeoCoordinate GetCentralGeoCoordinate(
            IList<GeoCoordinate> geoCoordinates)
        {
            if (geoCoordinates.Count == 1)
            {
                return geoCoordinates.Single();
            }

            double x = 0;
            double y = 0;
            double z = 0;

            foreach (var geoCoordinate in geoCoordinates)
            {
                var latitude = geoCoordinate.Latitude * Math.PI / 180;
                var longitude = geoCoordinate.Longitude * Math.PI / 180;

                x += Math.Cos(latitude) * Math.Cos(longitude);
                y += Math.Cos(latitude) * Math.Sin(longitude);
                z += Math.Sin(latitude);
            }

            var total = geoCoordinates.Count;

            x = x / total;
            y = y / total;
            z = z / total;

            var centralLongitude = Math.Atan2(y, x);
            var centralSquareRoot = Math.Sqrt(x * x + y * y);
            var centralLatitude = Math.Atan2(z, centralSquareRoot);

            return new GeoCoordinate(centralLatitude * 180 / Math.PI, centralLongitude * 180 / Math.PI);
        }
        //public StaticMap GoogleMap
        //{
        //    get
        //    {
        //        var map = new StaticMap();
        //        map.Markers.Add(new StaticMap.Marker()
        //        {

        //        });
        //        map.
        //    }
        //}

    }

    public class GeoCoordinate
    {
        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class CourtesyCheckinMapper : BaseMapper<CourtesyOfficerCheckin, CourtesyCheckinViewModel>
    {
        public CourtesyCheckinMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(CourtesyCheckinViewModel viewModel, CourtesyOfficerCheckin model)
        {

        }

        public override void ToViewModel(CourtesyOfficerCheckin p, CourtesyCheckinViewModel viewModel)
        {

            //viewModel.Latitude = p.Latitude;
            //viewModel.Longitude = p.Longitude;
            //viewModel.Label = p.Label;
            //viewModel.Id = p.Id;
            //viewModel.Date = item?.CreatedOn;
            //viewModel.Complete = item != null;
            //viewModel.AcceptableCheckinCodes = new List<string>()
            //{
            //    $"http://apartmentapps.com?location={p.LocationId}",
            //    $"http://www.apartmentapps.com?coloc={p.LocationId}"
            //};

        }
    }

    public class IncidentStatusLookupMapper : BaseMapper<IncidentReportStatus, LookupBindingModel>
    {
        public IncidentStatusLookupMapper(IUserContext userContext, IModuleHelper moduleHelper) : base(userContext, moduleHelper)
        {
        }

        public override void ToModel(LookupBindingModel viewModel, IncidentReportStatus model)
        {
            
        }

        public override void ToViewModel(IncidentReportStatus model, LookupBindingModel viewModel)
        {
            viewModel.Title = model.Name;
            viewModel.Id = model.Name;
           
        }
    }
    public class IncidentStatusesSearchEngine : SearchEngine<IncidentReportStatus>
    {

        [Filter(nameof(CommonSearch), "Search")]
        public IQueryable<IncidentReportStatus> CommonSearch(IQueryable<IncidentReportStatus> set, string key)
        {
            var tokenize = Tokenize(key);
            if (tokenize.Length > 0)
            {
                return set.Where(item => tokenize.Any(token => item.Name.Contains(token)));
            }
            else
            {
                return set;
            }
        }

    }
    public class CourtesyOfficerService : StandardCrudService<CourtesyOfficerCheckin>
    {
        public CourtesyOfficerService(IRepository<CourtesyOfficerCheckin> repository, IUserContext userContext, IRepository<CourtesyOfficerLocation> locations, IKernel kernel) : base(kernel,repository)
        {
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