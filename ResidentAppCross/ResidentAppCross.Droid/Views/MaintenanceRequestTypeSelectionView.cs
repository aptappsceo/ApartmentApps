using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using ResidentAppCross;
using ResidentAppCross.Droid;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Droid.Views
{

    [Activity(Label = "ResidentAppCross.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MaintenanceRequestTypeSelectionView : MvxActivity
    {

        public new MaintenanceRequestTypeSelectionViewModel ViewModel
        {
            get { return (MaintenanceRequestTypeSelectionViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MaintenanceRequestTypeSelectionViewLayout);
        }
    }
}