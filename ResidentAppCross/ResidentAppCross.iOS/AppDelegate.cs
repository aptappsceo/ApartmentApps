﻿using System;
using System.Diagnostics;
using System.Linq;
using WindowsAzure.Messaging;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using Foundation;
using HockeyApp.iOS;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using ObjCRuntime;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;
using UIKit;

namespace ResidentAppCross.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate, IVersionChecker
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



        // http://stackoverflow.com/questions/27297435/detect-if-ios-app-is-downloaded-from-apples-testflight
        // BOOL isRunningTestFlightBeta = [[[[NSBundle mainBundle] appStoreReceiptURL] lastPathComponent] isEqualToString:@"sandboxReceipt"];

        public bool IsTestFlight => NSBundle.MainBundle.AppStoreReceiptUrl.LastPathComponent == "sandboxReceipt";

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {

            //Analytics
            //var manager = BITHockeyManager.SharedHockeyManager;
            //manager.Configure("397f14a1fe7d4bf68fe8002d8509e45b");
            //manager.StartManager();

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

            //Swap endpoint
            var service = Mvx.Resolve<IApartmentAppsAPIService>();

#if DEBUG
            service.BaseUri = App.DevEndpoint;
            Console.WriteLine($"Endpoint Substitues for DEBUG: {App.DevEndpoint}");
#else
            if(IsTestFlight){
              service.BaseUri = App.TestEndpoint;
				Console.WriteLine($"Endpoint Substitues for TESTFLIGHT: {App.TestEndpoint}");
            }
#endif

            Mvx.RegisterSingleton<IVersionChecker>(this);


            var dictionary = launchOptions?[UIApplication.LaunchOptionsRemoteNotificationKey] as NSDictionary;

            if (dictionary != null) LastOptions = dictionary;

            if (LastOptions != null)
            {
                ProcessNotification(LastOptions, true);
                LastOptions = null;
            }

            Mvx.Resolve<HomeMenuViewModel>().ShowViewModel<ApplicationViewModel>(x=> {});

            Window.MakeKeyAndVisible();



            

            

            return true;

        }

        
        

        private NSDictionary MockNotificationLaunchDictionary()
        {
            Debug.WriteLine("Start");
            var res = new NSMutableDictionary();
            var apsDictionry = new NSMutableDictionary();
            var alertDictionry = new NSMutableDictionary();
            var payloadDictionry = new NSMutableDictionary();


            res["aps"] = apsDictionry;
            apsDictionry["alert"] = alertDictionry;
            apsDictionry["content-available"] = new NSNumber(1);

            alertDictionry["title"] = new NSString("Hey Ho");
            alertDictionry["body"] = new NSString("This is the body");

            res["payload"] = payloadDictionry;

            payloadDictionry["Title"] = new NSString("Hello");
            payloadDictionry["Message"] = new NSString("Some Message Here");
            payloadDictionry["Semantic"] = new NSString("Default");
            payloadDictionry["Action"] = new NSString("View");
            payloadDictionry["DataId"] = new NSString("27");
            payloadDictionry["DataType"] = new NSString("Maintenance");
            Debug.WriteLine("End");

            return res;

        }

        public NSDictionary LastOptions { get; set; }


        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            ProcessNotification(userInfo, false);
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
                NSDictionary payloadD = null;

                if(options.ContainsKey(new NSString("payload")))
                payloadD = options.ObjectForKey(new NSString("payload")) as NSDictionary;

                string alert = string.Empty;

                //Extract the alert text
                // NOTE: If you're using the simple alert by just specifying
                // "  aps:{alert:"alert msg here"}  ", this will work fine.
                // But if you're using a complex alert with Localization keys, etc.,
                // your "alert" object from the aps dictionary will be another NSDictionary.
                // Basically the JSON gets dumped right into a NSDictionary,
                // so keep that in mind.
             //   if (aps.ContainsKey(new NSString("alert")))
             //       alert = (aps[new NSString("alert")] as NSString).ToString();



                NotificationPayload payload = null;

                if (payloadD != null)
                {
                    payload = payloadD.ToNotificationPayload();
                } 

                //If this came from the ReceivedRemoteNotification while the app was running,
                // we of course need to manually process things like the sound, badge, and alert.
                if (payload != null)
                {
                    if (!fromFinishedLaunching)
                    {

                        Mvx.Resolve<IDialogService>().OpenNotification(payload.Title, payload.Message, "View", () =>
                        {
                            Mvx.Resolve<IActionRequestHandler>()
                                .Handle(payload.ToActionRequest().ToTypedActionRequest());
                        });

                        //UIAlertView avAlert = new UIAlertView("Notification", alert, null, "OK", null);
                        //avAlert.Show();
                    }
                    else
                    {
                        Mvx.Resolve<IActionRequestHandler>().Handle(payload.ToActionRequest().ToTypedActionRequest());
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
            var client = Mvx.Resolve<IApartmentAppsAPIService>();
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

        public bool CheckVersion(VersionInfo version)
        {
            return Constants.IOS_BUILD_NUMBER >= version.IPhoneBuildNumber;
        }

        public void OpenInStore(VersionInfo version)
        {
            UIApplication.SharedApplication.OpenUrl(NSUrl.FromString(version.IPhoneStoreUrl));
        }
    }


    public static class ActionRequestExtentions
    {
        public static NotificationPayload ToNotificationPayload(this NSDictionary bundle)
        {
            var payload = new NotificationPayload();
            var actionKey = new NSString("Action");
            var dataTypeKey = new NSString("DataType");
            var dataIdKey = new NSString("DataId");
            var dataMessageKey = new NSString("Message");
            var dataTitleKey = new NSString("Title");
            var dataSemanticKey = new NSString("Semantic");
            payload.Action = bundle.Keys.Contains(actionKey) ? bundle[actionKey].ToString() : "None";
            payload.Title = bundle.Keys.Contains(dataTitleKey) ? bundle[dataTitleKey].ToString() : "" ;
            payload.Message = bundle.Keys.Contains(dataMessageKey) ? bundle[dataMessageKey].ToString() : "";
            payload.DataType = bundle.Keys.Contains(dataTypeKey) ? bundle[dataTypeKey].ToString() : "";
            payload.Semantic = bundle.Keys.Contains(dataSemanticKey) ? bundle[dataSemanticKey].ToString() : "Default";
            var idString = bundle.Keys.Contains(dataIdKey) ? bundle[dataIdKey].ToString() : "-1";
            payload.DataId = int.Parse(idString);

            return payload;
        }

        public static ActionRequest ToActionRequest(this NSDictionary bundle)
        {
            var actionKey = new NSString("Action");
            var dataTypeKey = new NSString("DataType");
            var dataIdKey = new NSString("DataId");
            var idString = bundle.Keys.Contains(dataIdKey) ? bundle[dataIdKey].ToString() : "-1";

            var action = new ActionRequest
            {
                Action = bundle.Keys.Contains(actionKey) ? bundle[actionKey].ToString() : "None",
                DataType = bundle.Keys.Contains(dataTypeKey) ? bundle[actionKey].ToString() : "None",
                DataId = int.Parse(idString)
            };
            return action;
        }


        public static ActionRequest ToActionRequest(this NotificationPayload payload)
        {
            return new ActionRequest()
            {
                Action = payload.Action,
                DataId = payload.DataId,
                DataType = payload.DataType
            };
        }

        public static TypedActionRequest ToTypedActionRequest(this ActionRequest request)
        {
            var result = new TypedActionRequest();
            ActionType act;
            if (!Enum.TryParse(request.Action, out act))
            {
                throw new Exception("ActionType Type Not Found: " + request.Action);
            }
            result.ActionType = act;
            result.DataId = request.DataId;
            result.DataType = request.DataType;

            return result;
        }
    }
}


