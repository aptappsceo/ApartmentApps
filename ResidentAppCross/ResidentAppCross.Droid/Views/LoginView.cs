using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidHUD;
using MvvmCross.Droid.Views;


namespace ResidentAppCross.Droid.Views
{
    [Activity(Label = "ResidentAppCross.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginView : MvxActivity
    {

        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
            SetContentView(Resource.Layout.LoginViewLayout);
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(ViewModel.IsOperating))
            {
                if (ViewModel.IsOperating)
                {
                    Console.WriteLine("Should show");
                    AndHUD.Shared.Show(this, "Connecting...", -1, MaskType.Black, centered: true);
                }
                else
                {
                    Console.WriteLine("Should hide");
                    AndHUD.Shared.Dismiss(this);
                }
            }
        }
    }
}