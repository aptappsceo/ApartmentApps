using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Widget;
using ApartmentApps.Client.Models;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using RecyclerViewAnimators.Adapters;
using RecyclerViewAnimators.Animators;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class PropertyConfigFormView : ViewFragment<PropertyConfigFormViewModel>
    {
        private Bitmap _geoMarkerFilled;


        [Outlet] public TabLayout ModeTabs { get; set; }
        [Outlet] public ViewPager ModePager { get; set; }
        [Outlet] public MapView MapView { get; set; }
        [Outlet] public Button AddPropertyButton { get; set; }
        [Outlet] public RecyclerView PropertiesPage { get; set; }

        public bool CurrentLocationUpdated { get; set; }

        public Bitmap GeoMarkerFilled
        {
            get { return _geoMarkerFilled ?? (_geoMarkerFilled = scaleImage(Resources, Resource.Drawable.geo_filled,24)); }
            set { _geoMarkerFilled = value; }
        }

        public override void Bind()
        {
            base.Bind();

            var adapter = new LocationsIndexAdapter<LocationBindingModel>()
            {
                Items = ViewModel.Locations,
                TitleSelector = i => i.Name,
                SubTitleSelector = i => i.Type,

                DetailsSelector = i => $"{i.Latitude?.ToString() ?? "-"}, {i.Longitude.ToString() ?? "-"}",
            };

            adapter.DetailsClicked += model =>
            {
                ViewModel.DeleteCommand.Execute(model);
            };

            PropertiesPage.SetAdapter(new AlphaInAnimationAdapter(adapter));
            PropertiesPage.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false));
            PropertiesPage.SetItemAnimator(new SlideInLeftAnimator());

            ModePager.Adapter = new XmlPagerAdapter(Layout,new XmlPagerAdapter.XmlPagerAdapterItem()
            {
                Id = Resource.Id.MapPage,
                Title = "Map"
            },new XmlPagerAdapter.XmlPagerAdapterItem()
            {
                Id = Resource.Id.PropertiesPage,
                Title = "Locations"
            });
            ModeTabs.SetupWithViewPager(ModePager);
            ModePager.SetCurrentItem(0, true);
            ModePager.ScrollTo(0, 0);
            ModeTabs.Invalidate();
            MapView.BindLifecycleProvider(this);
            var invoker = new IOnMapReadyMonoInvoker();
            invoker.MapReady += OnMapReady;
            MapView.GetMapAsync(invoker);

            this.OnViewModelEvent<PropertyConfigLocationsUpdated>(evt =>
            {
                UpdateMarkers();
            });

           // HeaderSection.IconView.SetImageResource(Resource.Drawable.home_config);
           // HeaderSection.IconView.SetColorFilter(Resources.GetColor(Resource.Color.secondary_text_body));

            var b = this.CreateBindingSet<PropertyConfigFormView, PropertyConfigFormViewModel>();

            ViewModel.PropertyChanged += (sender, args) =>
            {
                if (Map != null && ViewModel.CurrentLocation != null && !CurrentLocationUpdated)
                {
                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(ViewModel.CurrentLocation.ToLatLng(), 10);
                    Map?.AnimateCamera(cameraUpdate);
                    CurrentLocationUpdated = true;
                }
            };
            b.Bind(AddPropertyButton).To(vm => vm.AddLocationCommand);
            b.Apply();


            ViewModel.UpdateLocations.Execute(null);
        }

        public void UpdateMarkers()
        {
            if (Map == null) return;
            Map.Clear();
            foreach (var location in ViewModel.Locations)
            {
                var markerOptions =
                    new MarkerOptions().SetPosition(new LatLng(location.Latitude ?? 0, location.Longitude ?? 0))
                    .SetIcon(BitmapDescriptorFactory.FromBitmap(GeoMarkerFilled))
                    .SetTitle(location.Name);
                Map.AddMarker(markerOptions);
            }

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            Map = googleMap;
            googleMap.UiSettings.MyLocationButtonEnabled = false;
            googleMap.MyLocationEnabled = true;
            googleMap.UiSettings.ZoomControlsEnabled = true;
            UpdateMarkers();
        }

        public override string Title => "Configure Property";

        public GoogleMap Map { get; set; }

        private Bitmap scaleImage(Android.Content.Res.Resources res, int id, int lessSideSize)
        {
            Bitmap b = null;
            BitmapFactory.Options o = new BitmapFactory.Options();
            o.InJustDecodeBounds = true;

            BitmapFactory.DecodeResource(res, id, o);

            float sc = 0.0f;
            int scale = 1;
            // if image height is greater than width
            if (o.OutHeight > o.OutWidth)
            {
                sc = o.OutHeight / (float)lessSideSize;
                scale = Math.Round(sc);
            }
            // if image width is greater than height
            else {
                sc = o.OutWidth / (float)lessSideSize;
                scale = Math.Round(sc);
            }

            // Decode with inSampleSize
            BitmapFactory.Options o2 = new BitmapFactory.Options();
            o2.InSampleSize = scale;
            b = BitmapFactory.DecodeResource(res, id, o2);
            return b;
        }
    }

    public static class LocationMessageExtensions
    {
        public static LatLng ToLatLng(this LocationMessage msg)
        {
            return new LatLng(msg.Latitude,msg.Longitude);
        }
    }

  
}