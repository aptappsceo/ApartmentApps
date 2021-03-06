﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using ApartmentApps.Client.Models;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform.WeakSubscription;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;
using Cirrious.FluentLayouts.Touch.Extensions;
using Cirrious.FluentLayouts.Touch;
using Cirrious.FluentLayouts.Touch.RowSet;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Resources;
using ResidentAppCross.Services;

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
        private LocationsAnnotationManager _manager;

        public SegmentSelectionSection SegmentSelectionSection
        {
            get
            {
                if (_segmentSelectionSection == null)
                {
                    _segmentSelectionSection = Formals.Create<SegmentSelectionSection>();
                    _segmentSelectionSection.Label.Text = "Switch";
                    //_segmentSelectionSection.HideTitle(true);
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
                    _headerSection.MainLabel.Text = "Property";
                    _headerSection.SubLabel.Text = "Configuration";
                    _headerSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.HomeConfig, SharedResources.Size.L);
                    _headerSection.LogoImage.TintColor = AppTheme.SecondaryBackgoundColor;
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
                    _mapSection.HeaderLabel.Text = "Property Map";
                    CLLocationCoordinate2D coords = new CLLocationCoordinate2D(48.857, 2.351);
                    MKCoordinateSpan span = new MKCoordinateSpan(_mapSection.MilesToLatitudeDegrees(0.1), _mapSection.MilesToLongitudeDegrees(0.1, coords.Latitude));
                    _mapSection.MapView.Region = new MKCoordinateRegion(coords, span);
                    _mapSection.MapView.ShowsUserLocation = true;
                    _mapSection.HeightConstraint.Constant = 400;

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
                    var locationIcon = AppTheme.GetTemplateIcon(SharedResources.Icons.Location, SharedResources.Size.S,
                        true);
                    var tableDataBinding = new TableDataBinding<UITableViewCell, LocationBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = item.Name;
                            cell.ImageView.Image = locationIcon;
                            cell.ImageView.TintColor = AppTheme.InProgressColor;
                            cell.DetailTextLabel.Text = item.Type;
                        },
                        ItemSelected = item =>
                        {
                           // ViewModel.SelectedCheckin = item;
                          //  ViewModel.ShowCheckinDetailsCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Subtitle, "UITableViewCell_IncidentDetailsCheckinsTable"), //Define how to create cell, if reusables not found
                        CellIdentifier = "UITableViewCell_IncidentDetailsCheckinsTable"
                    };

                    tableDataBinding.AddAction(new TableCellAction<LocationBindingModel>()
                    {
                        Title = "Delete",
                        Handler = (item)=>ViewModel.DeleteCommand.Execute(item)
                    });
                    var source = new GenericTableSource()
                    {
                        Items = ViewModel.Locations, //Deliver data
                        Binding = tableDataBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };

                    _tableSection.Table.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                    _tableSection.Table.AllowsSelection = true; //Step 1. Look at the end of BindForm method for step 2
                    _tableSection.Source = source;
                    _tableSection.HeightConstraint.Constant = 450;
                    _tableSection.ReloadData();
                    _tableSection.LayoutMargins = new UIEdgeInsets(8f,8f,8f,8f);
                }
                return _tableSection;
            }
        
        }


        public override UIView HeaderView => HeaderSection;

        //bind

        public override void BindForm()
        {
            base.BindForm();
            var b = this.CreateBindingSet<PropertyConfigFormView, PropertyConfigFormViewModel>();
            ViewModel.PropertyChanged += (sender, args) =>
            {
                MapSection.MapView.UserLocation.Coordinate =
                     new CLLocationCoordinate2D(ViewModel.CurrentLocation.Latitude,
                         ViewModel.CurrentLocation.Longitude);
                if (ViewModel.CurrentLocation != null && !CurrentLocationUpdated)
                {
                    MapSection.MapView.SetCenterCoordinate(new CLLocationCoordinate2D(ViewModel.CurrentLocation.Latitude, ViewModel.CurrentLocation.Longitude),true);
                 
                    CurrentLocationUpdated = true;
                }
            };

            b.Bind(AddLocationButton).To(p => p.AddLocationCommand);
            _manager = new LocationsAnnotationManager(this.MapSection.MapView);
            b.Bind(_manager).For(m => m.ItemsSource).To(vm => vm.Locations);
            b.Bind(TableSection.Source).To(vm => vm.Locations);

            SegmentSelectionSection.BindTo(new List<string>() {"Map","List"},x=>x,x=>RefreshContent(),0);

            b.Apply();

            ViewModel.UpdateLocations.Execute(null);
            
        }

        public bool CurrentLocationUpdated { get; set; }

        public ButtonToolbarSection ButtonToolbarSection
        {
            get
            {
                if (_toolbarSection == null)
                {
                    _toolbarSection = Formals.Create<ButtonToolbarSection>();
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

            content.Add(SegmentSelectionSection);
          
            if (SegmentSelectionSection.Selector.SelectedSegment == 0)
            {
                content.Add(MapSection);
            }
            else
            {
                content.Add(TableSection);
            }
            TableSection.ReloadData();
        }

        public override UIView FooterView => ButtonToolbarSection;

        //add to contents
    }
    public sealed class CheckinBindingModelAnnotation : MKAnnotation
    {
        public readonly CourtesyCheckinBindingModel _house;
        private CLLocationCoordinate2D _coordinate;

        public CheckinBindingModelAnnotation(CourtesyCheckinBindingModel house)
        {
            _house = house;
            // Todo - the details of actually using the house here.
            // in theory you could also data-bind to the house too (e.g. if it's location were to move...)
            if (house.Latitude != null)
                if (house.Longitude != null)
                    _coordinate = new CLLocationCoordinate2D(house.Latitude.Value, house.Longitude.Value);


        }

        public override string Description => _house.Label;
        public override string Title => _house.Label;
        public override string Subtitle => string.Empty;
        public override CLLocationCoordinate2D Coordinate => _coordinate;
    }
    public sealed class LocationBindingModelAnnotation : MKAnnotation
    {
        private readonly LocationBindingModel _house;
        private CLLocationCoordinate2D _coordinate;

        public LocationBindingModelAnnotation(LocationBindingModel house)
        {
            _house = house;
            // Todo - the details of actually using the house here.
            // in theory you could also data-bind to the house too (e.g. if it's location were to move...)
            if (house.Latitude != null)
                if (house.Longitude != null)
                    _coordinate = new CLLocationCoordinate2D(house.Latitude.Value, house.Longitude.Value);
           
        
        }
      
        public override string Description => _house.Name;
        public override string Title => _house.Name;
        public override string Subtitle => _house.Type;
        public override CLLocationCoordinate2D Coordinate => _coordinate;
    }

    // an abstract helper class
    public abstract class MvxAnnotationManager
    {
        private readonly MKMapView _mapView;
        private IEnumerable _itemsSource;
        private IDisposable _subscription;
        public Dictionary<object, MKAnnotation> _annotations = new Dictionary<object, MKAnnotation>();

        protected MvxAnnotationManager(MKMapView mapView)
        {
            _mapView = mapView;
        }

        // MvxSetToNullAfterBinding isn't strictly needed any more 
        // - but it's nice to have for when binding is torn down
        [MvxSetToNullAfterBinding]
        public virtual IEnumerable ItemsSource
        {
            get { return _itemsSource; }
            set { SetItemsSource(value); }
        }

        protected virtual void SetItemsSource(IEnumerable value)
        {
            if (_itemsSource == value)
                return;

            if (_subscription != null)
            {
                _subscription.Dispose();
                _subscription = null;
            }
            _itemsSource = value;
            //if (_itemsSource != null && !(_itemsSource is IList))
            //    MvxBindingTrace.Trace(MvxTraceLevel.Warning,
            //                          "Binding to IEnumerable rather than IList - this can be inefficient, especially for large lists");

            ReloadAllAnnotations();

            var newObservable = _itemsSource as INotifyCollectionChanged;
            if (newObservable != null)
            {
                _subscription = newObservable.WeakSubscribe(OnItemsSourceCollectionChanged);
            }
        }

        protected virtual void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddAnnotations(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveAnnotations(e.OldItems);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveAnnotations(e.OldItems);
                    AddAnnotations(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Move:
                    // not interested in this
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ReloadAllAnnotations();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void ReloadAllAnnotations()
        {

            foreach (var item in _annotations)
            {
                _mapView.RemoveAnnotation(item.Value);
            }
            _annotations.Clear();

            if (_itemsSource == null)
                return;

            AddAnnotations(_itemsSource);
            var firstOrDefault = _annotations.Values.FirstOrDefault();
            if (firstOrDefault != null)
                _mapView.SetCenterCoordinate(firstOrDefault.Coordinate,true);
        }

        protected abstract MKAnnotation CreateAnnotation(object item);

        protected virtual void RemoveAnnotations(IEnumerable oldItems)
        {
            foreach (var item in oldItems)
            {
                RemoveAnnotationFor(item);
            }
        }

        protected virtual void RemoveAnnotationFor(object item)
        {
            var annotation = _annotations[item];
            _mapView.RemoveAnnotation(annotation);
            _annotations.Remove(item);
        }

        protected virtual void AddAnnotations(IEnumerable newItems)
        {
            foreach (object item in newItems)
            {
                AddAnnotationFor(item);
            }
        }

        protected virtual void AddAnnotationFor(object item)
        {
            var annotation = CreateAnnotation(item);
            _annotations[item] = annotation;
            _mapView.AddAnnotation(annotation);
        }
    }


    public class LocationsAnnotationManager
        : MvxAnnotationManager
    {
        public LocationsAnnotationManager(MKMapView mapView) : base(mapView)
        {
        }

        protected override MKAnnotation CreateAnnotation(object item)
        {
            var bindingModel = item as LocationBindingModel;
            return new LocationBindingModelAnnotation(bindingModel);
        }
    }

    public class CheckinsAnnotationManager
        : MvxAnnotationManager
    {
        public CheckinsAnnotationManager(MKMapView mapView) : base(mapView)
        {
        }

        protected override MKAnnotation CreateAnnotation(object item)
        {
            var bindingModel = item as CourtesyCheckinBindingModel;
            return new CheckinBindingModelAnnotation(bindingModel);
        }
    }



    //[Register("FirstView")]
    //public class FirstView : MvxViewController
    //{
    //    private HouseAnnotationManager _manager;

    //    public override void ViewDidLoad()
    //    {
    //        View = new UIView() { BackgroundColor = UIColor.White };
    //        base.ViewDidLoad();

    //        var myMapView = new MKMapView(View.Frame);
    //        Add(myMapView);
    //        myMapView.Delegate = new MyMapDelegate(); // standard map delegate - must provide the annotation views

    //        _manager = new HouseAnnotationManager(myMapView);

    //        var set = this.CreateBindingSet<FirstView, FirstViewModel>();
    //        set.Bind(_manager).For(m => m.ItemsSource).To(vm => vm.HouseList);
    //        set.Apply();
    //    }
    //}


}
