using System;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Maps;
using Android.Runtime;
using Android.Util;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using Gcm;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Plugins;
using ResidentAppCross.Droid.Services;
using ResidentAppCross.Droid.Views.Sections;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels.Screens;
using ZXing.Mobile;

namespace ResidentAppCross.Droid
{
    public class Setup : MvxAndroidSetup, IVersionChecker
    {
        public bool CheckVersion(VersionInfo version)
        {
            return Constants.ANDROID_BUILD_NUMBER >= version.AndroidBuildNumber;
        }

        public void OpenInStore(VersionInfo version)
        {

            try
            {
                var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(version.AndroidStoreUrl));
                // we need to add this, because the activity is in a new context.
                // Otherwise the runtime will block the execution and throw an exception
                intent.AddFlags(ActivityFlags.NewTask);

                Application.Context.StartActivity(intent);
            }
            catch (ActivityNotFoundException)
            {
                var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse((version.AndroidStoreUrl)));
                // we need to add this, because the activity is in a new context.
                // Otherwise the runtime will block the execution and throw an exception
                intent.AddFlags(ActivityFlags.NewTask);

                Application.Context.StartActivity(intent);
            }
        }
        public Setup(Context applicationContext)
            : base(applicationContext)
        {

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += HandleExceptions;

        }

        private void HandleExceptions(object sender, UnhandledExceptionEventArgs e)
        {

            Android.Util.Log.WriteLine(LogPriority.Error, "ERROR", string.Format("EXCEPTION: {0} {1} {2}", sender, sender.GetType().Name,
                e.ExceptionObject));

        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            return presenter;
        }

        protected override IMvxViewDispatcher CreateViewDispatcher()
        {
            return base.CreateViewDispatcher();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.ConstructAndRegisterSingleton<IQRService,AndroidQRService>();
            Mvx.RegisterSingleton<Application>(DroidApplication.Instance);
            Mvx.ConstructAndRegisterSingleton<IDialogService,AndroidDialogService>();
            Mvx.ConstructAndRegisterSingleton<IDefaultViewModelTypeProvider,AndroidDefaultViewModelTypeProvider>();
            Mvx.RegisterSingleton<IVersionChecker>(this);
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

    public class AndroidDefaultViewModelTypeProvider : IDefaultViewModelTypeProvider
    {
        public Type DefaultViewModelType => typeof (NotificationIndexFormViewModel);
    }

    [Application]
    public class DroidApplication : Application
    {
        private static ISharedPreferencesEditor _preferencesEditor;
        private static ISharedPreferences _preferences;
        private static bool _pushNotificationsEnabled;

        protected DroidApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public DroidApplication()
        {
        }

        public static ISharedPreferences Preferences
        {
            get { return _preferences ?? (_preferences = Instance?.GetSharedPreferences("AA_PREFERENCES", FileCreationMode.Private)); }
            set { _preferences = value; }
        }

        public static ISharedPreferencesEditor PreferencesEditor
        {
            get { return _preferencesEditor ?? (_preferencesEditor = Preferences.Edit()); }
            set { _preferencesEditor = value; }
        }


        public override void OnCreate()
        {
       
            Instance = this;

            App.ApartmentAppsClient.GetAuthToken = () => AuthToken;
            App.ApartmentAppsClient.SetAuthToken = (v) => AuthToken = v;


            LoginService.DevicePlatform = "gcm";
            LoginService.DeviceHandle = DeviceToken;

            LoginService.GetRegistrationId = () => HandleId;
            LoginService.SetRegistrationId = (v) => HandleId = v;

            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);
            GcmClient.Register(this, GcmConstants.SenderID);

            try
            {
                MapsInitializer.Initialize(this);
            }
            catch (GooglePlayServicesNotAvailableException e)
            {
                e.PrintStackTrace();
            }

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

        public static bool PushNotificationsEnabled
        {
            get { return Preferences.GetBoolean("AA_PUSHNOTIFICATIONS", true); }
            set
            {
                PreferencesEditor.PutBoolean("AA_PUSHNOTIFICATIONS", value);
                PreferencesEditor.Commit();
            }
        }

        public static void RegisterForHandle(string deviceToken)
        {
            var client = Mvx.Resolve<IApartmentAppsAPIService>();

            if (HandleId == null)
            {
                HandleId = client.Register.Post(HandleId);
            }

            DeviceToken = deviceToken.ToString();
            LoginService.DeviceHandle = DeviceToken;
        }

    }

}