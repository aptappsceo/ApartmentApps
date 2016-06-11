using System;
using System.Collections.Generic;
using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ApartmentApps.Client.Models;
using FR.Ganfra.Materialspinner;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using RecyclerViewAnimators.Animators;
using ResidentAppCross.Droid.Views.AwesomeSiniExtensions;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.Resources;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;
using Math = Java.Lang.Math;
using String = Java.Lang.String;

namespace ResidentAppCross.Droid.Views
{
    [MvxFragment(typeof (ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class AddCreditCardPaymentOptionView : ViewFragment<AddCreditCardPaymentOptionViewModel>
    {

        [Outlet]
        public MaterialSpinner ExpirationMonthSelection { get; set; }
        [Outlet]
        public MaterialSpinner ExpirationYearSelection { get; set; }
        [Outlet]
        public TextView TitleLabel { get; set; }
        [Outlet]
        public TextView SubtitleLabel { get; set; }
        [Outlet]
        public ImageView IconView { get; set; }

        public override void Bind()
        {
            base.Bind();

            /* Header setup */
            TitleLabel.Text = "Add Credit Card";
            SubtitleLabel.Text = "Please fill the information below";
            IconView.SetImageResource(SharedResources.Icons.WalletPlus.ToDrawableId());
            IconView.SetColorFilter(Resources.GetColor(Resource.Color.secondary_text_body));

            /* spinners setup */
            var nowYear = DateTime.Now.Year;
            var months = Enumerable.Range(1, 12).Select(i => i.ToString()).Select(s => new Java.Lang.String(s)).ToList();
            var years = Enumerable.Range(0, 60).Select(i => (nowYear+i).ToString()).Select(s => new Java.Lang.String(s)).ToList();
            ArrayAdapter<String> monthAdapter = new ArrayAdapter<String>(Context, Resource.Layout.spinner_item_text_light, months);
            ArrayAdapter<String> yearAdapter = new ArrayAdapter<String>(Context, Resource.Layout.spinner_item_text_light, years);
            monthAdapter.SetDropDownViewResource(Resource.Layout.spinner_item_text_light);
            yearAdapter.SetDropDownViewResource(Resource.Layout.spinner_item_text_light);
            ExpirationMonthSelection.Adapter = monthAdapter;
            ExpirationYearSelection.Adapter = yearAdapter;
        }
    }

    [MvxFragment(typeof (ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class RentSummaryView : ViewFragment<RentSummaryViewModel>
    {

        [Outlet] public RecyclerView RentDetailsList { get; set; }
        [Outlet] public TextView TitleLabel { get; set; }
        [Outlet] public TextView SubtitleLabel { get; set; }
        [Outlet] public ImageView IconView { get; set; }
        [Outlet] public Button PayButton { get; set; }

        public IEnumerable<View> NoPaymentsViews => Layout.GetChildrenWithTag("NO_PAYMENTS");
        public IEnumerable<View> PaymentsViews => Layout.GetChildrenWithTag("PAYMENTS");

        public override void Bind()
        {
            base.Bind();

            var set = this.CreateBindingSet<RentSummaryView, RentSummaryViewModel>();

            set.Bind(PayButton).To(vm => vm.CheckOutCommand);
            set.Apply();
            

            TitleLabel.Text = "Rent Summary";

            IconView.SetImageResource(SharedResources.Icons.Wallet.ToDrawableId());
            var color = Resources.GetColor(Resource.Color.secondary_text_body);
            IconView.SetColorFilter(color);

            this.OnViewModelEvent<RentSummaryUpdated>(evt =>
            {

                var anyPayments = ViewModel.PaymentSummary.Entries.Any();
                if (anyPayments)
                {
                    SubtitleLabel.Text = "Pending payments are listed below.";
                }
                else
                {
                    SubtitleLabel.Text = "No pending payments.";
                }

                var paymentsViews = PaymentsViews.ToList();
                var noPaymentsViews = NoPaymentsViews.ToList();

                foreach (var view in paymentsViews)
                {
                    view.Visibility = anyPayments ? ViewStates.Visible : ViewStates.Gone;
                }

                foreach (var view in noPaymentsViews)
                {
                    view.Visibility = !anyPayments ? ViewStates.Visible : ViewStates.Gone;
                }

            });

            var adapter = new PaymentSummaryAdapter()
            {
                Summary = ViewModel.PaymentSummary
            };
            RentDetailsList.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false));
            RentDetailsList.SetItemAnimator(new SlideInLeftAnimator());
            RentDetailsList.SetAdapter(adapter);

        }
    }

    [MvxFragment(typeof(ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
    public class PaymentOptionsView : ViewFragment<PaymentOptionsViewModel>
    {

        [Outlet]
        public RecyclerView PaymentOptionsContainer { get; set; }
        [Outlet]
        public TextView TitleLabel { get; set; }
        [Outlet]
        public TextView SubtitleLabel { get; set; }
        [Outlet]
        public ImageView IconView { get; set; }
        [Outlet]
        public Button AddCreditCardButton { get; set; }
        [Outlet]
        public Button AddBankAccountButton { get; set; }


        public IEnumerable<View> NoPaymentsViews => Layout.GetChildrenWithTag("NO_PAYMENT_OPTION");
        public IEnumerable<View> PaymentsViews => Layout.GetChildrenWithTag("PAYMENT_OPTIONS");

        public override void Bind()
        {
            base.Bind();

            var set = this.CreateBindingSet<PaymentOptionsView, PaymentOptionsViewModel>();
            set.Bind(AddCreditCardButton).To(vm => vm.AddCreditCardCommand);
            set.Bind(AddBankAccountButton).To(vm => vm.AddBankAccountCommand);
            set.Apply();
            
            TitleLabel.Text = "Select Payment Option";

            IconView.SetImageResource(SharedResources.Icons.Wallet.ToDrawableId());
            var color = Resources.GetColor(Resource.Color.secondary_text_body);
            IconView.SetColorFilter(color);

            this.OnViewModelEvent<PaymentOptionsUpdated>(evt =>
            {

                var anyPayments = ViewModel.PaymentOptions.Any();
                if (anyPayments)
                {
                    SubtitleLabel.Text = "Pay with....";
                }
                else
                {
                    SubtitleLabel.Text = "Please, add payment options.";
                }

                var paymentsViews = PaymentsViews.ToList();
                var noPaymentsViews = NoPaymentsViews.ToList();

                foreach (var view in paymentsViews)
                {
                    view.Visibility = anyPayments ? ViewStates.Visible : ViewStates.Gone;
                }

                foreach (var view in noPaymentsViews)
                {
                    view.Visibility = !anyPayments ? ViewStates.Visible : ViewStates.Gone;
                }

            });


            var adapter = new IconTitleBadgeListAdapter<PaymentOptionBindingModel>()
            {
                Items = ViewModel.PaymentOptions,
                TitleSelector = i=>i.FriendlyName
            };

            PaymentOptionsContainer.SetLayoutManager(new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false));
            PaymentOptionsContainer.SetItemAnimator(new SlideInLeftAnimator());
            PaymentOptionsContainer.SetAdapter(adapter);


        }
    }

    public class PaymentSummaryAdapter : GenericRecyclerAdapter<PaymentSummaryViewHolder>
    {
        private PaymentSummary _summary;

        public PaymentSummary Summary
        {
            get { return _summary; }
            set
            {
                _summary = value;
                this.BindToCollection(Summary.Entries);
            }
        }

        public override int ItemCount => Summary?.Entries?.Count ?? 0;

        public override int GetItemViewType(int position)
        {
            return (int) Summary.Entries[position].Format;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var layoutId = Resource.Layout.payment_summary_default_line;

            switch ((PaymentSummaryFormat)viewType)
            {
                case PaymentSummaryFormat.Default:
                    layoutId = Resource.Layout.payment_summary_default_line;
                    break;
                case PaymentSummaryFormat.Discount:
                    break;
                case PaymentSummaryFormat.Total:
                    layoutId = Resource.Layout.payment_summary_total_line;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }

            return new PaymentSummaryViewHolder(
                LayoutInflater.From(parent.Context).Inflate(layoutId, parent, false)
                );
        }

        public override void OnBind(PaymentSummaryViewHolder holder, int position)
        {
            holder.TitleLabel.Text = Summary.Entries[position].Title;
            holder.PriceLabel.Text = Summary.Entries[position].Price;
        }
    }

    public class PaymentSummaryViewHolder : RecyclerView.ViewHolder
    {
        [Outlet]
        public TextView TitleLabel { get; set; }

        [Outlet]
        public TextView PriceLabel { get; set; }

        public PaymentSummaryViewHolder(View itemView) : base(itemView)
        {
            itemView.LocateOutlets(this);
        }
    }


    [MvxFragment(typeof (ApplicationViewModel), Resource.Id.application_host_container_primary, true)]
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

            this.OnViewModelEvent<CourtesyOfficerCheckingLocationsUpdated>(evt => { UpdateMarkers(); });

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
                var markerOptions = new MarkerOptions().SetPosition(new LatLng(location.Latitude ?? 0, location.Longitude ?? 0)).SetIcon(BitmapDescriptorFactory.FromBitmap(location.Complete ?? false ? GeoMarkerFilled : GeoMarker)).SetTitle(location.Label);
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
                sc = o.OutHeight/(float) lessSideSize;
                scale = Math.Round(sc);
            }
            // if image width is greater than height
            else
            {
                sc = o.OutWidth/(float) lessSideSize;
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