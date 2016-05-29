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
using ResidentAppCross.Services;
using Action = System.Action;

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
        private NotificationManager _notificationManager;
        public static string RegistrationID { get; private set; }
        private NotificationHub Hub { get; set; }

        public PushHandlerService() : base(GcmConstants.SenderID)
        {
            Log.Verbose(BroadcastReceiver.TAG,"GCM Service Started");
        }

        public override void OnCreate()
        {
            base.OnCreate();
            /*
            #if DEBUG
                if(!Android.OS.Debug.IsDebuggerConnected)
                    Android.OS.Debug.WaitForDebugger();
            #endif
            */
        }

        protected override void OnMessage(Context context, Intent intent)
        {
            Log.Verbose(BroadcastReceiver.TAG, "Message Recieved");
            NotifyWithPayload(intent?.Extras?.ToNotificationPayload());
        }

        protected override void OnError(Context context, string errorId)
        {
            Log.Error(BroadcastReceiver.TAG, "GCM Error: " + errorId);
        }

        protected override void OnRegistered(Context context, string registrationId)
        {
            DroidApplication.RegisterForHandle(registrationId);
            RegistrationID = registrationId; 
        }

        protected override bool OnRecoverableError(Context context, string errorId)
        {
            return base.OnRecoverableError(context, errorId);
        }

        protected override void OnUnRegistered(Context context, string registrationId)
        {
            NotifyWithData("GCM Unregistered...", "The device has been unregistered!");
        }

        private void NotifyWithPayload(NotificationPayload payload)
        {
            //Create an intent to open app and pass a bundle to be executed
            var uiIntent = new Intent(this, typeof(ApplicationHostActivity));
            payload.ToActionRequest().Save(uiIntent);
            var id = payload.DataType.GetHashCode()+payload.Action.GetHashCode()+payload.DataId ?? -1;
            Notify(payload.Title, payload.Message, uiIntent, id);
        }

        void NotifyWithData(string title, string message, int id = 1)
        {
            var uiIntent = new Intent(this, typeof(ApplicationHostActivity));
            Notify(title, message, uiIntent, id);
        }

        public NotificationManager NotificationManager
        {
            get { return _notificationManager ?? (_notificationManager = GetSystemService(Context.NotificationService) as NotificationManager); }
            set { _notificationManager = value; }
        }

        void Notify(string title, string message, Intent tapIntent, int id, int iconId = Android.Resource.Drawable.SymActionEmail)
        {

            if (tapIntent == null) tapIntent = new Intent(this, typeof(ApplicationHostActivity));

            var builder = new NotificationCompat.Builder(this)
                .SetSmallIcon(iconId)
                .SetContentTitle(id+" "+title).SetContentText(message)
                .SetAutoCancel(true)
                .SetContentIntent(PendingIntent.GetActivity(this, id, tapIntent, PendingIntentFlags.UpdateCurrent));

            NotificationManager.Notify(id, builder.Build());
        }


        public const int PushHandlerRequestCode = 18824;

    }

    public static class BundleExtensions
    {
        public static NotificationPayload ToNotificationPayload(this Bundle bundle)
        {
            var payload = new NotificationPayload();

            payload.Action = bundle.GetString("Action", "None");
            payload.Title = bundle.GetString("Title", "");
            payload.Message = bundle.GetString("Message", "");
            payload.DataType = bundle.GetString("DataType", "");
            payload.Semantic = bundle.GetString("Semantic", "Default");
            payload.DataId = int.Parse(bundle.GetString("DataId", "-1"));

            return payload;
        }

        public static ActionRequest ToActionRequest(this Bundle bundle)
        {
            var action = new ActionRequest
            {
                Action = bundle.GetString("Action", "None"),
                DataType = bundle.GetString("DataType", "None"),
                DataId = int.Parse(bundle.GetString("DataId", "-1"))
            };
            return action;
        }

        public static void Save(this ActionRequest request, Intent intent)
        {
            intent.PutExtra("Action", request.Action);
            intent.PutExtra("DataType", request.DataType);
            intent.PutExtra("DataId", (request.DataId ?? -1).ToString());
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