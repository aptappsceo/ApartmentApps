using System;
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
            SegmentSelectionSection.Selector.ValueChanged += (sender, args) => RefreshContent();
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
            content.Add(MapSection);
            if (SegmentSelectionSection.Selector.SelectedSegment == 0)
            {
                
            }
            else
            {
                content.Add(TableSection);
            }
           
            content.Add(ButtonToolbarSection);
        }


        //add to contents
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
