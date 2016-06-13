using System.Collections.Generic;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.Resources;
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
		private CheckinsAnnotationManager _manager;
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
                    MKCoordinateSpan span = new MKCoordinateSpan(_mapSection.MilesToLatitudeDegrees(0.01), _mapSection.MilesToLongitudeDegrees(0.01, coords.Latitude));
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
			_manager = new CheckinsAnnotationManager(this.MapSection.MapView);
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
                    _headerSection.MainLabel.Text = "Courtesy Officer";
                    _headerSection.SubLabel.Text = "Checkins";
                    _headerSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.LocationOk, SharedResources.Size.L);
                    _headerSection.LogoImage.TintColor = AppTheme.SecondaryBackgoundColor;
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
         

        
            if (annotation is MKUserLocation)
                return base.GetViewForAnnotation(mapView, annotation);
            var checkinAnnotation = annotation as CheckinBindingModelAnnotation;
            if (checkinAnnotation != null)
            {
                MKAnnotationView annotationView = null;
                var unCompleteIcon = AppTheme.GetIcon(SharedResources.Icons.LocationQuestion, ResidentAppCross.Resources.SharedResources.Size.S).TintBlack(AppTheme.InProgressColor);
                var completeIcon = AppTheme.GetIcon(SharedResources.Icons.LocationOk, ResidentAppCross.Resources.SharedResources.Size.S).TintBlack(AppTheme.CompleteColor);

                // show conference annotation
                annotationView = mapView.DequeueReusableAnnotation(annotationId);

                if (annotationView == null)
                    annotationView = new MKAnnotationView(annotation, annotationId);
                if (checkinAnnotation._house.Complete == true)
                {
                    annotationView.Image = completeIcon;
                }
                else
                {
                    annotationView.Image = unCompleteIcon;
                }
               
                annotationView.CanShowCallout = true;
                return annotationView;
            }

            return null;
            //var result =  
            //result.Image = UIImage.FromBundle("MaintenaceIcon");
            //return result;
        }
    }

    [Register("RentSummaryView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class RentSummaryView : BaseForm<RentSummaryViewModel>
    {
        
    }

    [Register("AddCreditCardPaymentOptionView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class AddCreditCardPaymentOptionView : BaseForm<AddCreditCardPaymentOptionViewModel>
    {

    }

    [Register("AddBankAccountPaymentOptionView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class AddBankAccountPaymentOptionView : BaseForm<AddBankAccountPaymentOptionViewModel>
    {
        private TextFieldSection _paymentOptionTitleSection;
        private TextFieldSection _routingNumberSection;
        private TextFieldSection _accountNumberSection;
        private TextFieldSection _accountHolderSection;
        private CallToActionSection _callToActionSection;
        private HeaderSection _headerSection;

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                    _headerSection.LogoImage.Image = UIImage.FromBundle("WalletIcon");
                    _headerSection.MainLabel.Text = "Add Credit Card";
                    _headerSection.SubLabel.Text = "Please, fill the information below";
                }
                return _headerSection;
            }
        }

        public TextFieldSection PaymentOptionTitleSection
        {
            get
            {
                return _paymentOptionTitleSection ?? (_paymentOptionTitleSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Payment Option Title...")
                    .WithNextResponder(AccountNumberSection));
            }
        }

        public TextFieldSection RoutingNumberSection
        {
            get
            {
                return _routingNumberSection ?? (_routingNumberSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Routing Number...")
                    .WithNextResponder(AccountHolderSection));
            }
        }

        public TextFieldSection AccountNumberSection
        {
            get
            {
                return _accountNumberSection ?? (_accountNumberSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Account Number...")
                    .WithNextResponder(RoutingNumberSection));
            }
        }

        public TextFieldSection AccountHolderSection
        {
            get
            {
                return _accountHolderSection ?? (_accountHolderSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Account Holder Name..."));
            }
        }

        public CallToActionSection CallToActionSection
        {
            get
            {
                if (_callToActionSection == null)
                {
                    _callToActionSection = Formals.Create<CallToActionSection>();
                    _callToActionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
                }
                return _callToActionSection;
            }
        }


    }

    [Register("PaymentOptionsView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class PaymentOptionsView : BaseForm<PaymentOptionsViewModel>
    {

    }

    [Register("CommitPaymentView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class CommitPaymentView : BaseForm<CommitPaymentViewModel>
    {

    }






}