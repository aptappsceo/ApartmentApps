using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels.Screens
{
    public class CourtesyOfficerCheckinsViewModel : ViewModelBase
    {
        public IApartmentAppsAPIService ApiService { get; set; }
        private readonly IQRService _qrService;
        private MvxSubscriptionToken _token;
        private LocationMessage _currentLocation;

        public CourtesyOfficerCheckinsViewModel(IApartmentAppsAPIService apiService, IMvxMessenger messenger, IQRService qrService)
        {
            ApiService = apiService;
            _qrService = qrService;
            _token = messenger.Subscribe<LocationMessage>(DeliveryAction);

        }

        public ICommand UpdateLocations
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var locations = await ApiService.Checkins.GetAsync();
                    Locations.Clear();
                    foreach (var item in locations)
                    {
                        Locations.Add(item);
                    }

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

        public ICommand CheckinCommand
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
                            var location = Locations.FirstOrDefault(p => p.AcceptableCheckinCodes.Contains(ScanResult.Data));
                            if (location == null)
                            {
                                context.FailTask("This is not a valid qr code.");
                                return;
                            }
                            var result = await ApiService.Checkins.PostWithOperationResponseAsync(location.Id.Value);
                            if (!result.Response.IsSuccessStatusCode)
                            {
                                context.FailTask(result.Response.ReasonPhrase);
                                return;
                            }
                            
                        }).OnStart("Checking In...").OnComplete("Reloading...", () =>
                        {
                            this.UpdateLocations.Execute(null);
                        }).Execute(null);
                    }

                });

            }
        }

        public QRData ScanResult { get; set; }
        public ObservableCollection<CourtesyCheckinBindingModel> Locations { get; set; } = new ObservableCollection<CourtesyCheckinBindingModel>();

    }
}