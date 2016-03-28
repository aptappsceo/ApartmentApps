using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using ResidentAppCross.Extensions;

namespace ResidentAppCross.ViewModels.Screens
{
    public class CheckinDetailsViewModel : ViewModelBase
    {

        private MaintenanceCheckinBindingModel _checkin;
        private ImageBundleViewModel _checkinPhotos;

        public MaintenanceCheckinBindingModel Checkin
        {
            get { return _checkin; }
            set { SetProperty(ref _checkin, value); }
        }

        public ImageBundleViewModel CheckinPhotos
        {
            get
            {
                if (_checkinPhotos == null)
                {
                    _checkinPhotos = new ImageBundleViewModel();
                    _checkinPhotos.RawImages.AddRange(Checkin.Photos.Select(p=>new ImageBundleItemViewModel()
                    {
                        Uri = new Uri(p.Url)
                    }));
                }
                return _checkinPhotos;
            }
            set { _checkinPhotos = value; }
        }
    }
}
