using System;
using WindowsAzure.Messaging;
using ApartmentApps.Client;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using ObjCRuntime;
using ResidentAppCross.ServiceClient;
using UIKit;

namespace ResidentAppCross.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        // class-level declarations
        private SBNotificationHub Hub { get; set; }
        public override UIWindow Window
        {
            get;
            set;
        }

        public AppDelegate()
        {
            App.ApartmentAppsClient.GetAuthToken = () => AuthToken;
            App.ApartmentAppsClient.SetAuthToken = (v) => AuthToken = v;
        }
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
          
            // For push notifiations
            LoginService.DevicePlatform = "apns";
            LoginService.DeviceHandle = DeviceToken;
           
            LoginService.GetRegistrationId = () => HandleId;
            LoginService.SetRegistrationId = (v) => HandleId = v;
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                       UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                       new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }

            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var presenter = new MvxIosViewPresenter(this, Window);

            var setup = new Setup(this, presenter);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            return true;

        }
        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            ProcessNotification(userInfo, false);
        }
        void ProcessNotification(NSDictionary options, bool fromFinishedLaunching)
        {
            // Check to see if the dictionary has the aps key.  This is the notification payload you would have sent
            if (null != options && options.ContainsKey(new NSString("aps")))
            {
                //Get the aps dictionary
                NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;

                string alert = string.Empty;

                //Extract the alert text
                // NOTE: If you're using the simple alert by just specifying
                // "  aps:{alert:"alert msg here"}  ", this will work fine.
                // But if you're using a complex alert with Localization keys, etc.,
                // your "alert" object from the aps dictionary will be another NSDictionary.
                // Basically the JSON gets dumped right into a NSDictionary,
                // so keep that in mind.
                if (aps.ContainsKey(new NSString("alert")))
                    alert = (aps[new NSString("alert")] as NSString).ToString();

                //If this came from the ReceivedRemoteNotification while the app was running,
                // we of course need to manually process things like the sound, badge, and alert.
                if (!fromFinishedLaunching)
                {
                    //Manually show an alert
                    if (!string.IsNullOrEmpty(alert))
                    {
                        UIAlertView avAlert = new UIAlertView("Notification", alert, null, "OK", null);
                        avAlert.Show();
                    }
                }
            }
        }

        public static string DeviceToken
        {
            get { return NSUserDefaults.StandardUserDefaults.StringForKey("AA_DEVICE_TOKEN"); }
            set
            {
                NSUserDefaults.StandardUserDefaults.SetString(value,"AA_DEVICE_TOKEN");
            }
        }
        public static string AuthToken
        {
            get { return NSUserDefaults.StandardUserDefaults.StringForKey("AA_TOKEN"); }
            set
            {
                if (value == null)
                {
                    NSUserDefaults.StandardUserDefaults.RemoveObject("AA_TOKEN");
                }
                else
                {
                    NSUserDefaults.StandardUserDefaults.SetString(value, "AA_TOKEN");

                }
               
            }
        }
        public static string HandleId
        {
            get { return NSUserDefaults.StandardUserDefaults.StringForKey("AA_HANDLE"); }
            set
            {
                NSUserDefaults.StandardUserDefaults.SetString(value, "AA_HANDLE");
            }
        }
        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            //Hub = new SBNotificationHub(Constants.ConnectionString, Constants.NotificationHubPath);
           
            var client = new App.ApartmentAppsClient();
            if (HandleId == null)
            {
                HandleId = client.Register.Post(HandleId);
            }
            
            DeviceToken = deviceToken.ToString();
            LoginService.DeviceHandle = DeviceToken;
            //Hub.UnregisterAllAsync(deviceToken, (error) => {
            //    if (error != null)
            //    {
            //        Console.WriteLine("Error calling Unregister: {0}", error.ToString());
            //        return;
            //    }

            //    NSSet tags = new NSSet("all"); // create tags if you want
            //    Hub.RegisterNativeAsync(deviceToken, tags, (errorCallback) => {
            //        if (errorCallback != null)
            //            Console.WriteLine("RegisterNativeAsync error: " + errorCallback.ToString());
            //    });
            //});
        }
        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}


