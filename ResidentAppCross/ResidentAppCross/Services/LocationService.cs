using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;

namespace ResidentAppCross.Services
{
    public class LocationService
       : ILocationService
    {
        private readonly IMvxLocationWatcher _watcher;
        private readonly IMvxMessenger _messenger;

        public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
        {
            _watcher = watcher;
            _messenger = messenger;
            _watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
        }

        private void OnLocation(MvxGeoLocation location)
        {
            var message = new LocationMessage(this,
                                              location.Coordinates.Latitude,
                                              location.Coordinates.Longitude
                );

            _messenger.Publish(message);
        }

        private void OnError(MvxLocationError error)
        {
            Mvx.Error("Seen location error {0}", error.Code);
        }
    }

    public interface ILocationService
    {
    }

    public class LocationMessage : MvxMessage
    {

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LocationMessage(LocationService locationService, double latitude, double longitude) : base(locationService)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        
    }
}
