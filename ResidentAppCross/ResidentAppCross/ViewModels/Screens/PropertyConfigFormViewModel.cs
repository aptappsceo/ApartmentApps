using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Services;

namespace ResidentAppCross.ViewModels.Screens
{
    public class PropertyConfigFormViewModel : ViewModelBase
    {
        private readonly IQRService _qrService;
        private MvxSubscriptionToken _token;
        private LocationMessage _currentLocation;

        public PropertyConfigFormViewModel(IMvxMessenger messenger, IQRService qrService)
        {
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
                return this.TaskCommand(async context =>
                {
                    ScanResult = await _qrService.ScanAsync();
                    var data = ScanResult?.Data;
                    

                    
                }).OnStart("Updating Request...");
            }
        }

        public QRData ScanResult { get; set; }
    }
}
