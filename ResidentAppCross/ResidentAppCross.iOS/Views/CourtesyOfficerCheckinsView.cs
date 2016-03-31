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
        private CallToActionSection _callToActionSection;

        public MapSection MapSection
        {
            get
            {
                if (_mapSection == null)
                {
                   
                    _mapSection = Formals.Create<MapSection>();
                    _mapSection.MapView.Delegate = new PropertyMapViewDelegate();
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
            b.Bind(CallToActionSection.MainButton).To(vm => vm.CheckinCommand);
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
            content.Add(CallToActionSection);

            //content.Add(ButtonToolbarSection);
        }
        public CallToActionSection CallToActionSection
        {
            get
            {
                if (_callToActionSection == null)
                {
                    _callToActionSection = Formals.Create<CallToActionSection>();
                    _callToActionSection.MainButton.SetTitle("Scan QR Code", UIControlState.Normal);
                    _callToActionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
                }
                return _callToActionSection;
            }
        }


        //add to con
        public bool CurrentLocationUpdated { get; set; }
    }

    public class PropertyMapViewDelegate :MKMapViewDelegate
    {
        private string annotationId = "LocationAnnotationView";

        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
                return null;
            var checkinAnnotation = annotation as CheckinBindingModelAnnotation;
            if (checkinAnnotation != null)
            {

                // show conference annotation
                annotationView = mapView.DequeueReusableAnnotation(annotationId);

                if (annotationView == null)
                    annotationView = new MKAnnotationView(annotation, annotationId);
                if (checkinAnnotation._house.Complete == true)
                {
                    annotationView.Image = UIImage.FromBundle("MaintenaceIcon");

                }
                else
                {
                    annotationView.Image = UIImage.FromBundle("OfficerIcon");
                }
               
                annotationView.CanShowCallout = true;
            }

            return annotationView;
            //var result =  base.GetViewForAnnotation(mapView, annotation);
            //result.Image = UIImage.FromBundle("MaintenaceIcon");
            //return result;
        }
    }
}