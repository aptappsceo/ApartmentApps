﻿using System;
using System.Collections.Generic;
using System.Text;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    [Register("PropertyConfigFormView")]
    public class PropertyConfigFormView : BaseForm<PropertyConfigFormViewModel>
    {
        private HeaderSection _headerSection;
        private MapSection _mapSection;
        private ButtonToolbarSection _toolbarSection;


        //create

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {

                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.MainLabel.Text = "Property";
                    _headerSection.SubLabel.Text = "Configuration";
                    _headerSection.LogoImage.Image = UIImage.FromBundle("MaintenaceIcon");
                }
                
                return _headerSection;
            }
        }
        public MapSection MapSection
        {
            get
            {
                if (_mapSection == null)
                {
                    _mapSection = Formals.Create<MapSection>();
                    _mapSection.HeightConstraint.Constant = 400;
                    _mapSection.HeaderLabel.Text = "This is map";
                    CLLocationCoordinate2D coords = new CLLocationCoordinate2D(48.857, 2.351);
                    MKCoordinateSpan span = new MKCoordinateSpan(_mapSection.MilesToLatitudeDegrees(0.1), _mapSection.MilesToLongitudeDegrees(0.1, coords.Latitude));
                    _mapSection.MapView.Region = new MKCoordinateRegion(coords, span);
                    _mapSection.MapView.ShowsUserLocation = true;

                }
                return _mapSection;
            }
        }

        //bind

        public override void BindForm()
        {
            base.BindForm();
            var b = this.CreateBindingSet<PropertyConfigFormView, PropertyConfigFormViewModel>();
            ViewModel.PropertyChanged += (sender, args) =>
            {
                if (ViewModel.CurrentLocation != null)
                {
                    MapSection.MapView.SetCenterCoordinate(new CLLocationCoordinate2D(ViewModel.CurrentLocation.Latitude, ViewModel.CurrentLocation.Longitude),true);
                    MapSection.MapView.UserLocation.Coordinate =
                        new CLLocationCoordinate2D(ViewModel.CurrentLocation.Latitude,
                            ViewModel.CurrentLocation.Longitude);
                }
            };
           // b.Bind(MapSection.MapView.UserLocation).OneWay().For(p => p.).To(p =>p.CurrentLocation.Longitude);
            b.Bind(AddLocationButton).To(p => p.AddLocationCommand);
            //b.Bind(ForgotPasswordButton).To(vm => vm.RemindPasswordCommand);
            //b.Bind(SignUpButton).To(vm => vm.SignUpCommand);
            b.Apply();
        }

        public ButtonToolbarSection ButtonToolbarSection
        {
            get
            {
                if (_toolbarSection == null)
                {
                    _toolbarSection = Formals.Create<ButtonToolbarSection>();
                    _toolbarSection.HeightConstraint.Constant = 80;

                    var style = new UIViewStyle()
                    {
                        BackgroundColor = AppTheme.SecondaryBackgoundColor,
                        ForegroundColor = AppTheme.SecondaryForegroundColor,
                        FontSize = 23.0f
                    };

                    AddLocationButton = _toolbarSection.AddButton("Add Location", style);
                   
                   

                }
                return _toolbarSection;
            }
        }

        public UIButton AddLocationButton { get; set; }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(HeaderSection);
            content.Add(MapSection);
            content.Add(ButtonToolbarSection);
        }


        //add to contents
    }
}
