﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApartmentApps.Client;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Location;
using Newtonsoft.Json.Linq;
using ResidentAppCross;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.Services;
using ResidentAppCross.ViewModels;

public static class Constants
{
    public const string ConnectionString = "Endpoint=sb://aptappspush.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=b8UIg+ith9oTvd+/4bhvCkc81e6nSnombxgsTqTB8ak=";
    public const string NotificationHubPath = "apartmentapps";
    public const int IOS_BUILD_NUMBER = 4;
    public const int ANDROID_BUILD_NUMBER = 6;
}
public class App : MvxApplication
{
    public App()
    {
        Mvx.ConstructAndRegisterSingleton<IImageService, ImageService>();
        Mvx.ConstructAndRegisterSingleton<ILocationService, LocationService>();

        //sini pc endpoint
        //var apartmentAppsApiService = new ApartmentAppsClient(new Uri("http://82.151.208.56.nip.io:54685"));

        //dev deployment endpoint
        //var apartmentAppsApiService = new ApartmentAppsClient(new Uri("http://apartmentappsapiservicedev.azurewebsites.net/"));
        
        //production endpoint
        var apartmentAppsApiService = new ApartmentAppsClient(new Uri("http://apartmentappsapiservice.azurewebsites.net"));


        Mvx.RegisterSingleton<IApartmentAppsAPIService>(apartmentAppsApiService);
        Mvx.RegisterSingleton<ILoginManager>(new LoginService(apartmentAppsApiService));
        Mvx.RegisterSingleton<IMvxAppStart>(new CustomAppStart());
        Mvx.LazyConstructAndRegisterSingleton<ISharedCommands, SharedCommands>();
        Mvx.ConstructAndRegisterSingleton<HomeMenuViewModel, HomeMenuViewModel>();
        Mvx.ConstructAndRegisterSingleton<IActionRequestHandler, ActionRequestHandler>();
    }

    public class CustomAppStart
       : MvxNavigatingObject
       , IMvxAppStart
    {


        public void Start(object hint = null)
        {
       
        }
    }

    public class ApartmentAppsClient : ApartmentAppsAPIService 
    {

        public ApartmentAppsClient(Uri baseUri) : base(baseUri, new AparmentAppsDelegating())
        {
        }

        public void Logout()
        {
            AparmentAppsDelegating.AuthorizationKey = null; 
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            
            var result = await HttpClient.PostAsync(this.BaseUri + "/Token", new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                {"username", username},
                {"password", password},
                {"grant_type", "password"},
            }));
            try
            {
                Logout();
                var json = await result.Content.ReadAsStringAsync();
                var obj = JObject.Parse(json);
                JToken token;
                if (obj.TryGetValue("access_token", out token))
                {
                    AparmentAppsDelegating.AuthorizationKey = token.Value<string>();

                    return true;
                }
                else
                {
                    AparmentAppsDelegating.AuthorizationKey = null;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;

        }

        public static Func<string> GetAuthToken { get; set; }

        public static Action<string> SetAuthToken { get; set; }


    }


}