using System;
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
}
public class App : MvxApplication
{
    public App()
    {
        //Mvx.RegisterType<ICalculation, Calculation>();
        Mvx.ConstructAndRegisterSingleton<IImageService, ImageService>();
        Mvx.ConstructAndRegisterSingleton<ILocationService, LocationService>();
        //Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginFormViewModel>());
        
        //Mvx.RegisterSingleton<ILocationService,LocationService>();
        var client = new ApartmentAppsClient();
        //var client = new ApartmentAppsClient(new Uri("http://localhost:54683"));
        Mvx.RegisterSingleton<IApartmentAppsAPIService>(client);
        var loginService = new LoginService(client);
        Mvx.RegisterSingleton<ILoginManager>(loginService);
        //if (loginService.IsLoggedIn)
        //{
        //    Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<HomeMenuViewModel>());
        //}
        //else
        //{
        Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginFormViewModel>());
        //}

    }
    public class CustomAppStart
       : MvxNavigatingObject
       , IMvxAppStart
    {
        public void Start(object hint = null)
        {
            var auth = Mvx.Resolve<ILoginManager>();
            if (!auth.IsLoggedIn)
            {
                ShowViewModel<LoginFormViewModel>();
            }
            else
            {
                //ShowViewModel<LoginFormViewModel>();
                ShowViewModel<HomeMenuViewModel>();
            }
        }
    }
    public class ApartmentAppsClient : ApartmentAppsAPIService 
    {
        public ApartmentAppsClient() : base(new Uri("http://apartmentappsapiservice.azurewebsites.net"), new AparmentAppsDelegating())
        {
        }

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
                var json = await result.Content.ReadAsStringAsync();
                var obj = JObject.Parse(json);
                JToken token;
                if (obj.TryGetValue("access_token", out token))
                {
                    AparmentAppsDelegating.AuthorizationKey = token.Value<string>();
                   
                    return true;
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