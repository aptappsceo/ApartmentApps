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
using Cirrious.MvvmCross.Droid.Views;
using FlyOutMenu;

namespace ResidentAppCross.Droid.Views
{
    [Activity()]
    public class MainView : MvxActivity

    {
        public new HomeViewModel ViewModel
        {
            get { return (HomeViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main2);
            var menu = FindViewById<FlyOutContainer>(Resource.Id.FlyOutContainer);
            var menuButton = FindViewById(Resource.Id.MenuButton);
            menuButton.Click += (sender, e) => {
                menu.AnimatedOpened = !menu.AnimatedOpened;
            };
        }
    }
}