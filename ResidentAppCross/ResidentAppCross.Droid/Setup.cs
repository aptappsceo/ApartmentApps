using System;
using Android.Content;
using Android.Util;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;

namespace ResidentAppCross.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += HandleExceptions;

        }

        private void HandleExceptions(object sender, UnhandledExceptionEventArgs e)
        {

            Android.Util.Log.WriteLine(LogPriority.Error, "Holy shit", string.Format("EXCEPTION: {0} {1} {2}", sender, sender.GetType().Name,
                e.ExceptionObject));

        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);
            registry.AddOrOverwrite("SharedIconsConverter",new SharedIconsConverter());
        }
    }

}