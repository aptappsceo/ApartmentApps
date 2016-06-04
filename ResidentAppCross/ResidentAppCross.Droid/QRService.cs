using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using ResidentAppCross.Services;
using ZXing.Mobile;

namespace ResidentAppCross.Droid.Services
{
    public class AndroidQRService : IQRService
    {
        private MobileBarcodeScanner _scanner;
        private IMvxAndroidCurrentTopActivity _topActivityResolver;
        private ActivityLifecycleContextListener _topActivity;

        public IMvxAndroidCurrentTopActivity TopActivityResolver
        {
            get { return _topActivityResolver ?? (_topActivityResolver= Mvx.Resolve<IMvxAndroidCurrentTopActivity>()); }
            set { _topActivityResolver = value; }
        }

        public Activity TopActivity => TopActivityResolver.Activity;

        public MobileBarcodeScanner Scanner
        {
            get {

                if (_scanner == null)
                {
                    var customOverlay = LayoutInflater.FromContext(TopActivity).Inflate(Resource.Layout.barcode_scanner_overlay, null);
                    _scanner = new MobileBarcodeScanner()
                    {
                        UseCustomOverlay = true,
                        CustomOverlay = customOverlay,
                    };


                    var button = customOverlay.FindViewById<Button>(Resource.Id.FlashButton);
                    button.Click += (sender, args) => _scanner.ToggleTorch();
                }

                return _scanner;
            }
            set { _scanner = value; }
        }

        public async Task<QRData> ScanAsync()
        {

            //Check if emulator and return emulated result
            string fing = Build.Fingerprint;
            bool isEmulator = false;
            if (fing != null)
            {
                isEmulator = fing.Contains("vbox") || fing.Contains("generic") || fing.Contains("vsemu");
            }

            if (isEmulator)
            {
                return new QRData()
                {
                    Data = "http://www.apartmentapps.com?coloc=17",
                    ImageData = new byte[0],
                    Timestamp = DateTime.Now.Ticks
                };
            }

            var data = await Scanner.Scan(new MobileBarcodeScanningOptions()
            {
                
            });
            if (data == null) return null;
            return new QRData()
            {
                Data = data.Text,
                ImageData = data.RawBytes,
                Timestamp = data.Timestamp
            };
        }
    }
}