using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels.Screens
{
    public class PropertyConfigFormViewModel : ViewModelBase
    {
        public IApartmentAppsAPIService ApiService { get; set; }
        private readonly IQRService _qrService;
        private MvxSubscriptionToken _token;
        private LocationMessage _currentLocation;

        public PropertyConfigFormViewModel(IApartmentAppsAPIService apiService, IMvxMessenger messenger, IQRService qrService)
        {
            ApiService = apiService;
            _qrService = qrService;
            _token = messenger.Subscribe<LocationMessage>(DeliveryAction);
            Mvx.Resolve<ILocationService>().Start();
        }

        public ICommand UpdateLocations
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var locations = await ApiService.Configure.GetLocationsAsync();
                    Locations.Clear();
                    foreach (var item in locations)
                    {
                        Locations.Add(item);
                    }
                    this.Publish(new PropertyConfigLocationsUpdated(this));
                });
                //return this.TaskCommand(async context =>
                //{
                   
                //}).OnStart("Loading Locations");
            }
        }
        public LocationMessage CurrentLocation
        {
            get { return _currentLocation; }
            set { SetProperty(ref _currentLocation, value, "CurrentLocation"); }
        }

        private void DeliveryAction(LocationMessage locationMessage)
        {
            CurrentLocation = locationMessage;
        }

        public ICommand AddLocationCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    ScanResult = await _qrService.ScanAsync();
                    if (!string.IsNullOrEmpty(ScanResult.Data))
                    {
                        this.TaskCommand(async context =>
                        {

                            var result = await ApiService.Configure.AddLocationWithOperationResponseAsync(ScanResult.Data,
                                CurrentLocation.Latitude, CurrentLocation.Longitude);
                            if (!result.Response.IsSuccessStatusCode)
                            {
                                context.FailTask(result.Response.ReasonPhrase);
                            }
                        }).OnStart("Adding...").OnComplete("Location Added!", () =>
                        {
                            UpdateLocations.Execute(null);
                        }).Execute(null);
                    }
                    
                });
               
            }
        }

        public QRData ScanResult { get; set; }
        public ObservableCollection<LocationBindingModel> Locations { get; set; } = new ObservableCollection<LocationBindingModel>();
        public ICommand DeleteCommand => new MvxCommand<LocationBindingModel>( (loc) =>
        {
            this.TaskCommand(async context =>
            {
                await this.ApiService.Configure.DeleteLocationAsync(loc.Id.Value, loc.Type);
            }).OnStart("Deleting...").OnComplete("Location Removed!", () =>
            {
                UpdateLocations.Execute(null);
            }).Execute(null);
        });
    }

    public class PropertyConfigLocationsUpdated : MvxMessage
    {
        public PropertyConfigLocationsUpdated(object sender) : base(sender)
        {
        }

    }
}
