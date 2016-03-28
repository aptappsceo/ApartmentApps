using System.Collections.Generic;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{
    [Register("CourtesyOfficerCheckinsView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class CourtesyOfficerCheckinsView : BaseForm<CourtesyOfficerCheckinsViewModel>
    {
        private MapSection _mapSection;
        private LocationsAnnotationManager _manager;
        private HeaderSection _headerSection;

        public MapSection MapSection
        {
            get
            {
                if (_mapSection == null)
                {
                   
                    _mapSection = Formals.Create<MapSection>();
                    _mapSection.MapView.MapType = MKMapType.SatelliteFlyover;
                    _mapSection.HeightConstraint.Constant = 400;
                    _mapSection.HeaderLabel.Text = "Checkin Locations";
                    CLLocationCoordinate2D coords = new CLLocationCoordinate2D(48.857, 2.351);
                    MKCoordinateSpan span = new MKCoordinateSpan(_mapSection.MilesToLatitudeDegrees(0.1), _mapSection.MilesToLongitudeDegrees(0.1, coords.Latitude));
                    _mapSection.MapView.Region = new MKCoordinateRegion(coords, span);
                    _mapSection.MapView.ShowsUserLocation = true;

                }
                return _mapSection;
            }
        }

        public override void BindForm()
        {
            base.BindForm();
            var b = this.CreateBindingSet<CourtesyOfficerCheckinsView, CourtesyOfficerCheckinsViewModel>();
            ViewModel.PropertyChanged += (sender, args) =>
            {
                MapSection.MapView.UserLocation.Coordinate =
                     new CLLocationCoordinate2D(ViewModel.CurrentLocation.Latitude,
                         ViewModel.CurrentLocation.Longitude);
                MapSection.MapView.SetCenterCoordinate(new CLLocationCoordinate2D(ViewModel.CurrentLocation.Latitude, ViewModel.CurrentLocation.Longitude), false);
            };

            _manager = new LocationsAnnotationManager(this.MapSection.MapView);
            b.Bind(_manager).For(m => m.ItemsSource).To(vm => vm.Locations);
            // SegmentSelectionSection.Selector.ValueChanged += (sender, args) => RefreshContent();
            b.Apply();
            ViewModel.UpdateLocations.Execute(null);

        }
        
        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {

                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = 100;
                    _headerSection.MainLabel.Text = "Courtesy Officer";
                    _headerSection.SubLabel.Text = "Checkins";
                    _headerSection.LogoImage.Image = UIImage.FromBundle("MaintenaceIcon");
                }
                
                return _headerSection;
            }
        }
        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(HeaderSection);
            //content.Add(SegmentSelectionSection);
            content.Add(MapSection);
            

            //content.Add(ButtonToolbarSection);
        }


        //add to con
        public bool CurrentLocationUpdated { get; set; }
    }
}