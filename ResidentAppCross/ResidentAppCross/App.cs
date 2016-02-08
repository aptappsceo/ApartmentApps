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
using Newtonsoft.Json.Linq;
using ResidentAppCross;
using ResidentAppCross.ServiceClient;
using ResidentAppCross.Services;

public class App : MvxApplication
{
    public App()
    {
        //Mvx.RegisterType<ICalculation, Calculation>();
        Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());
        var client = new ApartmentAppsClient();
        //var client = new ApartmentAppsClient(new Uri("http://localhost:54683"));
        Mvx.RegisterSingleton<IApartmentAppsAPIService>(client);
        Mvx.RegisterSingleton<ILoginManager>(new LoginService(client));
        Mvx.ConstructAndRegisterSingleton<IImageService,ImageService>();

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
                var obj = JObject.Parse(await result.Content.ReadAsStringAsync());
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

     

        public class AparmentAppsDelegating : DelegatingHandler
        {
            public static string AuthorizationKey { get; set; }


            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Add("Authorization", "Bearer " + AuthorizationKey);
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}