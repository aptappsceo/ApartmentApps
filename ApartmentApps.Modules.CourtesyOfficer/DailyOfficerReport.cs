using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentApps.Api.BindingModels;
using ApartmentApps.Api.NewFolder1;
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
}