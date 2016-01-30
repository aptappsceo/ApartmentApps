using System;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Exceptions;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using FlyOutMenu;
using ResidentAppCross;

namespace ResidentAppCross.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
         
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }

}