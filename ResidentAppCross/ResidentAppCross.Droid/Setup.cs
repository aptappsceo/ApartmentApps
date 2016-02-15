using System;
using Android.App;
using Android.Content;
using Android.Util;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Plugins;
using ResidentAppCross.Droid.Services;
using ResidentAppCross.Services;
using ZXing.Mobile;

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

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.ConstructAndRegisterSingleton<IQRService,AndroidQRService>();
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);
            registry.AddOrOverwrite("SharedIconsConverter",new SharedIconsConverter());
            registry.AddOrOverwrite("ByteArrayToImage", new ByteArrayToImage());
        }
    }

}