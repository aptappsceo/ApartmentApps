using System;
using System.Linq;
using ApartmentApps.Client.Models;
using ResidentAppCross.Extensions;

namespace ResidentAppCross.ViewModels.Screens
{
    public class IncidentReportCheckinDetailsViewModel : ViewModelBase
    {

        private IncidentCheckinBindingModel _checkin;
        private ImageBundleViewModel _checkinPhotos;

        public IncidentCheckinBindingModel Checkin
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
                    try
                    {
                        _checkinPhotos.RawImages.AddRange(Checkin.Photos.Select(p => new ImageBundleItemViewModel()
                        {
                            Uri = new Uri(p.Url)
                        }));
                    }
                    catch (Exception ex)
                    {
                        this.FailTaskWithPrompt("Some of the Photos could not be loaded.");
                    }

                }
                return _checkinPhotos;
            }
            set { _checkinPhotos = value; }
        }

    }
}