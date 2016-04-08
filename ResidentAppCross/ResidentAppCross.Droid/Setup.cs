using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Util;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Plugins;
using ResidentAppCross.Droid.Services;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ServiceClient;
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
            Mvx.RegisterSingleton<Application>(DroidApplication.Instance);
            Mvx.ConstructAndRegisterSingleton<IDialogService,AndroidDialogService>();
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

    [Application]
    public class DroidApplication : Application
    {



        protected DroidApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public DroidApplication()
        {

        }


        public static ISharedPreferences Preferences => Instance?.GetSharedPreferences("MyPreferences", FileCreationMode.Private);
        public static ISharedPreferencesEditor PreferencesEditor => Preferences?.Edit();

        public override void OnCreate()
        {
            Instance = this;
            App.ApartmentAppsClient.GetAuthToken = () => AuthToken;
            App.ApartmentAppsClient.SetAuthToken = (v) => AuthToken = v;
            base.OnCreate();
        }
   

        public static DroidApplication Instance { get; set; }

        public static string DeviceToken
        {
            get { return Preferences.GetString("AA_DEVICE_TOKEN",null); }
            set
            {
                PreferencesEditor.PutString("AA_DEVICE_TOKEN", value); 
                PreferencesEditor.Commit();
            }
        }

        public static string AuthToken
        {
            get { return Preferences.GetString("AA_TOKEN",null); }
            set
            {
                if (value == null)
                {
                    PreferencesEditor.Remove("AA_TOKEN");
                }
                else
                {
                    PreferencesEditor.PutString("AA_TOKEN", value);
                }
                PreferencesEditor.Commit();
            }
        }

        public static string HandleId
        {
            get { return Preferences.GetString("AA_HANDLE",null); }
            set
            {
                PreferencesEditor.PutString("AA_HANDLE", value);
                PreferencesEditor.Commit();
            }
        }

    }

}