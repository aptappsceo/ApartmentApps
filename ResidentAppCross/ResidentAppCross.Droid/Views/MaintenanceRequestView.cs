﻿using Android.App;
using Android.OS;
using Android.Util;
using MvvmCross.Droid.Views;
using ResidentAppCross;
using ResidentAppCross.Droid;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Droid.Views
{

    [Activity(Label = "ResidentAppCross.Droid", Icon = "@drawable/icon")]
    public class MaintenanceRequestView : ViewBase
    {

        public new MaintenanceRequestViewModel ViewModel
        {
            get { return (MaintenanceRequestViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MaintenanceRequestViewLayout);
        }

    }
}