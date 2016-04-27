using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Widget;
using Java.Lang;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class CourtesyOfficerCheckinsView : ViewFragment<CourtesyOfficerCheckinsViewModel>
    {
        private Bitmap _geoMarkerFilled;
        private Bitmap _geoMarker;

        [Outlet]
        public MapView Map { get; set; }

        [Outlet]
        public Button CheckinButton { get; set; }

        public GoogleMap GoogleMap { get; set; }

        public override string Title => "Courtesy Checkins";

        public override void Bind()
        {
            base.Bind();
            CurrentLocationUpdated = false;
            Map.BindLifecycleProvider(this);
            var invoker = new IOnMapReadyMonoInvoker();
            invoker.MapReady += OnMapReady;
            Map.GetMapAsync(invoker);
           // IconView.SetImageResource(Resource.Drawable.location_ok);
          //  IconView.SetColorFilter(Resources.GetColor(Resource.Color.secondary_text_body));

            this.OnViewModelEvent<CourtesyOfficerCheckingLocationsUpdated>(evt =>
            {
                UpdateMarkers();
            });

            ViewModel.PropertyChanged += (sender, args) =>
            {
                if (GoogleMap != null && ViewModel.CurrentLocation != null && !CurrentLocationUpdated)
                {
                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(ViewModel.CurrentLocation.ToLatLng(), 10);
                    GoogleMap?.AnimateCamera(cameraUpdate);
                    CurrentLocationUpdated = true;
                }
            };
            var set = this.CreateBindingSet<CourtesyOfficerCheckinsView, CourtesyOfficerCheckinsViewModel>();
            set.Bind(CheckinButton).To(vm => vm.CheckinCommand);
            set.Apply();
            ViewModel.UpdateLocations.Execute(null);
        }

        public bool CurrentLocationUpdated { get; set; }

        private void OnMapReady(GoogleMap obj)
        {
            GoogleMap = obj;
            GoogleMap.UiSettings.MyLocationButtonEnabled = false;
            GoogleMap.MyLocationEnabled = true;
            GoogleMap.UiSettings.ZoomControlsEnabled = true;
            UpdateMarkers();

        }

        public void UpdateMarkers()
        {
            if (GoogleMap == null) return;
            GoogleMap.Clear();
            foreach (var location in ViewModel.Locations)
            {
                var markerOptions =
                    new MarkerOptions().SetPosition(new LatLng(location.Latitude ?? 0, location.Longitude ?? 0))
                    .SetIcon(BitmapDescriptorFactory.FromBitmap(location.Complete ?? false ? GeoMarkerFilled : GeoMarker))
                    .SetTitle(location.Label);
                GoogleMap.AddMarker(markerOptions);
            }

        }

        public Bitmap GeoMarkerFilled
        {
            get { return _geoMarkerFilled ?? (_geoMarkerFilled = scaleImage(Resources, Resource.Drawable.geo_filled, 24)); }
            set { _geoMarkerFilled = value; }
        }

        public Bitmap GeoMarker
        {
            get { return _geoMarker ?? (_geoMarker = scaleImage(Resources, Resource.Drawable.geo, 24)); }
            set { _geoMarker = value; }
        }

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
}