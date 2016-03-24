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

                            var result = await ApiService.Configure.AddCourtesyLocationWithOperationResponseAsync(ScanResult.Data,
                                CurrentLocation.Latitude, CurrentLocation.Longitude);
                            if (!result.Response.IsSuccessStatusCode)
                            {
                                context.FailTask(result.Response.ReasonPhrase);
                            }
                        }).OnStart("Adding...").Execute(null);
                    }
                    
                });
               
            }
        }

        public QRData ScanResult { get; set; }
        public ObservableCollection<CourtesyOfficerLocation> Locations { get; set; }
    }
}
