using Android.App;
using Android.OS;
using ResidentAppCross.ViewModels;
using ZXing.Mobile;

namespace ResidentAppCross.Droid.Views
{
    [Activity(
        Label = "Authentication",
        Icon = "@drawable/accounticon",
        NoHistory = true)]
    public class QRScannerView : ViewBase
    {
        private static bool _scannerInitialized;


        public new QRScannerViewModel ViewModel
        {
            get { return (QRScannerViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }
}