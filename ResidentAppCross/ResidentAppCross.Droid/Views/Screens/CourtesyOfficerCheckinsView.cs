using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
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

        [Outlet]
        public TextView TitleLabel { get; set; }

        [Outlet]
        public TextView SubtitleLabel { get; set; }

        [Outlet]
        public ImageView IconView { get; set; }

        [Outlet]
        public MapView Map { get; set; }

        [Outlet]
        public Button CheckinButton { get; set; }

        public GoogleMap GoogleMap { get; set; }

        public override void Bind()
        {
            base.Bind();
            Map.BindLifecycleProvider(this);
            var invoker = new IOnMapReadyMonoInvoker();
            invoker.MapReady += OnMapReady;
            Map.GetMapAsync(invoker);
            IconView.SetImageResource(Resource.Drawable.location_ok);
            IconView.SetColorFilter(Resources.GetColor(Resource.Color.secondary_text_body));
        }

        private void PlaceM()
        {
            //EventAggregator.Subscribe()<LocationMessage>();

            var marker2 = new MarkerOptions();
            marker2.SetPosition(new LatLng(ViewModel.CurrentLocation.Latitude, ViewModel.CurrentLocation.Longitude));
            marker2.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.avatar_placeholder));
            marker2.SetTitle("Waiting");
            GoogleMap.AddMarker(marker2);
        }

        private void OnMapReady(GoogleMap obj)
        {
            GoogleMap = obj;
            GoogleMap.UiSettings.MyLocationButtonEnabled = false;
            GoogleMap.MyLocationEnabled = true;

 



            foreach (var location in ViewModel.Locations)
            {
                var marker = GoogleMap.AddMarker(new MarkerOptions()
                {
                    Position = { Latitude = location.Latitude ?? 0, Longitude = location.Longitude ?? 0}
                });
                var bitmapDescriptor = BitmapDescriptorFactory.FromResource(Resource.Drawable.search);
                marker.SetIcon(bitmapDescriptor);
            }

            var loc = ViewModel.Locations.FirstOrDefault();

            if (loc == null) return;

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(new LatLng(loc.Latitude ?? 0, loc.Longitude ?? 0), 10);
            GoogleMap.AnimateCamera(cameraUpdate);

        }
    }
}