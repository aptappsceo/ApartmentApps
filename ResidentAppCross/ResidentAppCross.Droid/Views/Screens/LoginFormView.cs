using System.ComponentModel;
using Android.App;
using AndroidHUD;
using MvvmCross.Droid.Views;


namespace ResidentAppCross.Droid.Views
{
    [Activity(
        Label = "Authentication", 
        MainLauncher = true, 
        Icon = "@drawable/accounticon",
        NoHistory = true)]
    public class LoginFormView : ViewBase
    {

        public new LoginFormViewModel ViewModel
        {
            get { return (LoginFormViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {

            base.OnViewModelSet();
            //ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
            SetContentView(Resource.Layout.LoginViewLayout);
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
//            if (propertyChangedEventArgs.PropertyName == nameof(ViewModel.IsOperating))
//            {
//                if (ViewModel.IsOperating)
//                {
//                    AndHUD.Shared.Show(this, "Connecting...", -1, MaskType.Black, centered: true);
//                }
//                else
//                {
//                    AndHUD.Shared.Dismiss(this);
//                }
//            }
        }
    }
}