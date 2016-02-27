using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlyOutMenu;
using MvvmCross.Droid.Views;

namespace ResidentAppCross.Droid.Views
{
    [Activity(Label = "Home")]
    public class HomeMenuView : ViewBase

    {
        public new HomeMenuViewModel ViewModel
        {
            get { return (HomeMenuViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeMenuViewLayout);
        
            //var menu = FindViewById<FlyOutContainer>(Resource.Id.FlyOutContainer);
            //var menuButton = FindViewById(Resource.Id.MenuButton);
            //menuButton.Click += (sender, e) => {
            //    menu.AnimatedOpened = !menu.AnimatedOpened;
            //};
        }
    }
}