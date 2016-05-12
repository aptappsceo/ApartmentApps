using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsAzure.Messaging;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Gcm.Client;
using ResidentAppCross.Droid.Views;

[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

//GET_ACCOUNTS is needed only for Android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

namespace ResidentAppCross.Droid
{

    public static class GcmConstants
    {
        public const string SenderID = "575898383085"; // Google API Project Number
        public const string ListenConnectionString = "Endpoint=sb://apartmentappsapihub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=y1hY/2CAo+YUTnGbSIAC85yeyZ26PrGHmrlc9h4jVHM=";
        public const string NotificationHubName = "apartmentappsapihub";
    }

    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE },
        Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK },
        Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY },
        Categories = new string[] { "@PACKAGE_NAME@" })]
    public class BroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
    {
        public static string[] SENDER_IDS = new string[] { GcmConstants.SenderID };

        public const string TAG = "BroadcastReceiver-GCM";
    }

    [Service]
    public class PushHandlerService : GcmServiceBase
    {
        public static string RegistrationID { get; private set; }
        private NotificationHub Hub { get; set; }

        public PushHandlerService() : base(GcmConstants.SenderID)
        {
            Log.Info(BroadcastReceiver.TAG, "PushHandlerService() constructor");
        }

        protected override void OnMessage(Context context, Intent intent)
        {
            Log.Info(BroadcastReceiver.TAG, "GCM Message Received!");

            var msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            }

            string messageText = intent.Extras.GetString("message");
            if (!string.IsNullOrEmpty(messageText))
            {
                createNotification("Apartment Apps", messageText);
            }
            else
            {
                createNotification("Unknown message details", msg.ToString());
            }
        }

        protected override void OnError(Context context, string errorId)
        {
            Log.Error(BroadcastReceiver.TAG, "GCM Error: " + errorId);
        }

        protected override void OnRegistered(Context context, string registrationId)
        {
        
            DroidApplication.RegisterForHandle(registrationId);
            Log.Verbose(BroadcastReceiver.TAG, "GCM Registered: " + registrationId);
            RegistrationID = registrationId;

            //createNotification("PushHandlerService-GCM Registered...",
            //                    "The device has been Registered!");

            //Hub = new NotificationHub(Views.Constants.NotificationHubName, Views.Constants.ListenConnectionString,
            //                            context);
            //try
            //{
            //    Hub.UnregisterAll(registrationId);
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(BroadcastReceiver.TAG, ex.Message);
            //}

            ////var tags = new List<string>() { "falcons" }; // create tags if you want
            //var tags = new List<string>() { };

            //try
            //{
            //    var hubRegistration = Hub.Register(registrationId, tags.ToArray());
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(BroadcastReceiver.TAG, ex.Message);
            //}
        }

        protected override bool OnRecoverableError(Context context, string errorId)
        {
            Log.Warn(BroadcastReceiver.TAG, "Recoverable Error: " + errorId);
            return base.OnRecoverableError(context, errorId);
        }

        protected override void OnUnRegistered(Context context, string registrationId)
        {
            Log.Verbose(BroadcastReceiver.TAG, "GCM Unregistered: " + registrationId);

            createNotification("GCM Unregistered...", "The device has been unregistered!");
        }


        void createNotification(string title, string desc, int id = 1)
        {
            //Create notification
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            //Create an intent to show UI
            var uiIntent = new Intent(this, typeof(ApplicationHostActivity));


            var builder = new NotificationCompat.Builder(this)
                .SetSmallIcon(Android.Resource.Drawable.SymActionEmail)
                .SetContentTitle(title).SetContentText(desc)
                .SetAutoCancel(true)
                .SetContentIntent(PendingIntent.GetActivity(this, 0, uiIntent, 0));

            //Create the notification
         //   var notification = new Notification(Android.Resource.Drawable.SymActionEmail, title);

            //Auto-cancel will remove the notification once the user touches it
        //    notification.Flags = NotificationFlags.AutoCancel;

            //Set the notification info
            //we use the pending intent, passing our ui intent over, which will get called
            //when the notification is tapped.
           // notification.SetLatestEventInfo(this, title, desc, PendingIntent.GetActivity(this, 0, uiIntent, 0));

            //Show the notification
            notificationManager.Notify(id, builder.Build());
        //    dialogNotify(title, desc);
        }
        /*
        protected void dialogNotify(String title, String message)
        {

            ApplicationHostActivity.instance.RunOnUiThread(() => {
                AlertDialog.Builder dlg = new AlertDialog.Builder(MainActivity.instance);
                AlertDialog alert = dlg.Create();
                alert.SetTitle(title);
                alert.SetButton("Ok", delegate {
                    alert.Dismiss();
                });
                alert.SetMessage(message);
                alert.Show();
            });
        }
        */
    }
}