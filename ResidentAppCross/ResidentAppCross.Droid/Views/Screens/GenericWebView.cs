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
using MvvmCross.Droid.Views;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Droid.Views
{
    [Activity()]
    public class GenericWebView : MvxActivity

    {
        public new GenericWebViewModel ViewModel
        {
            get { return (GenericWebViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            //var menu = FindViewById<FlyOutContainer>(Resource.Id.FlyOutContainer);
            //var menuButton = FindViewById(Resource.Id.MenuButton);
            //menuButton.Click += (sender, e) => {
            //    menu.AnimatedOpened = !menu.AnimatedOpened;
            //};
        }
    }
}