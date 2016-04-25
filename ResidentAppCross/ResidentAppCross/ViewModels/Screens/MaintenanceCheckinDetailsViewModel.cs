using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using ResidentAppCross.Extensions;

namespace ResidentAppCross.ViewModels.Screens
{
    public class MaintenanceCheckinDetailsViewModel : ViewModelBase
    {

        private MaintenanceCheckinBindingModel _checkin;
        private ImageBundleViewModel _checkinPhotos;

        public MaintenanceCheckinBindingModel Checkin
        {
            get { return _checkin; }
            set
            {
                SetProperty(ref _checkin, value);
                var photos = new ImageBundleViewModel();
                photos.RawImages.AddRange(Checkin.Photos.Select(p => new ImageBundleItemViewModel()
                {
                    Uri = new Uri(p.Url)
                }));
                CheckinPhotos = photos;
            }
        }

        public ImageBundleViewModel CheckinPhotos
        {
            get { return _checkinPhotos; }
            set { SetProperty(ref _checkinPhotos, value); }
        }
    }
}
