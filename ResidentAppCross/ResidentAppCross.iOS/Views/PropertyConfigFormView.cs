using System;
using System.Collections.Generic;
using System.Text;
using ApartmentApps.Client.Models;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS.Views
{
    [Register("PropertyConfigFormView")]
    [NavbarStyling]
    public class PropertyConfigFormView : BaseForm<PropertyConfigFormViewModel>
    {
        private HeaderSection _headerSection;
        private MapSection _mapSection;
        private ButtonToolbarSection _toolbarSection;
        private UIButton _addLocationButton;
        private SegmentSelectionSection _segmentSelectionSection;
        private TableSection _tableSection;

        public SegmentSelectionSection SegmentSelectionSection
        {
            get
            {
                if (_segmentSelectionSection == null)
                {
                    _segmentSelectionSection = Formals.Create<SegmentSelectionSection>();
                    _segmentSelectionSection.HeightConstraint.Constant = 60;
                    _segmentSelectionSection.HideTitle(true);
                    _segmentSelectionSection.Selector.RemoveAllSegments();
                    _segmentSelectionSection.Selector.InsertSegment("Map", 0, false);
                    _segmentSelectionSection.Selector.InsertSegment("List", 1, false);
                }
                return _segmentSelectionSection;
            }
        }

        //create

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {

                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = 100;
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
        public TableSection TableSection
        {
            get
            {
                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>(); //Create as usually. 

                    var tableDataBinding = new TableDataBinding<UITableViewCell, MaintenanceIndexBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = item.Title;
                            cell.DetailTextLabel.Text = item.Comments;
                            cell.ImageView.Image = UIImage.FromBundle("MaintenaceIcon");
                            cell.TextLabel.MinimumScaleFactor = 0.2f;

                        },
                        ItemSelected = item =>
                        {
                            //ViewModel.SelectedRequest = item;
                            //ViewModel.OpenSelectedRequestCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCell"), //Define how to create cell, if reusables not found
                    };

                    var source = new GenericTableSource()
                    {
                        Items = ViewModel.Locations, //Deliver data
                        Binding = tableDataBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };


                    _tableSection.Table.AllowsSelection = true; //Step 1. Look at the end of BindForm method for step 2
                    _tableSection.Source = source;
                    _tableSection.ReloadData();

                }
                return _tableSection;
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
            b.Bind(AddLocationButton).To(p => p.AddLocationCommand);
            SegmentSelectionSection.Selector.ValueChanged += (sender, args) => RefreshContent();
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
                }
                return _toolbarSection;
            }
        }

        public UIButton AddLocationButton
            =>
                _addLocationButton ??
                (_addLocationButton = ButtonToolbarSection.AddButton("Add Location", new UIViewStyle()
                {
                    BackgroundColor = AppTheme.SecondaryBackgoundColor,
                    ForegroundColor = AppTheme.SecondaryForegroundColor,
                    FontSize = 23.0f
                }));

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(HeaderSection);
            content.Add(SegmentSelectionSection);
            if (SegmentSelectionSection.Selector.SelectedSegment == 0)
            {
                content.Add(MapSection);
            }
            else
            {
                content.Add(TableSection);
            }
           
            content.Add(ButtonToolbarSection);
        }


        //add to contents
    }
}
