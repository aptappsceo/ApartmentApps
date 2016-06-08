using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Plugins.Network.Rest;
using Newtonsoft.Json.Linq;

namespace ResidentAppCross.ServiceClient
{

    public interface IRestClient
    {
        string BaseUrl { get; set; }
        string BearerToken { get; set; }
        Task<string> PostForm(string url, Dictionary<string,string> formContent );
        Task<string> PostString(string url, string str);
        Task<bool> LoginAsync(string username, string password);
    }

    public interface IAuthorizedRestClient : IRestClient
    {
        
    }
    public class RestClient : IRestClient
    {
        public string Url = "http://apartmentappsapiservice.azurewebsites.net";
     

        public virtual HttpClient CreateClient()
        {
            var client = new HttpClient();
            if (string.IsNullOrEmpty(BearerToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + BearerToken);
            }

            return client;
        }

        public string BearerToken { get; set; }

        public RestClient()
        {
            
        }

        public RestClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; set; } = "http://apartmentappsapiservice.azurewebsites.net";

            public async Task<bool> LoginAsync(string username, string password)
            {
                var result = await PostForm("Token", new Dictionary<string, string>()
                {
                    {"Username", username},
                    {"password", password},
                    {"grant_type", "password"},
                });
                try
                {
                    var obj = JObject.Parse(result);
                    JToken token;
                    if (obj.TryGetValue("access_token", out token))
                    {
                        BearerToken = token.Value<string>();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
                return false;

            }
        public async Task<string> PostForm(string url, Dictionary<string,string> formContent )
        {
            var client = CreateClient();
            var result = await client.PostAsync(BaseUrl + "/" + url, new FormUrlEncodedContent(formContent));
            return await result.Content.ReadAsStringAsync();
        }
        public async Task<string> PostString(string url, string str)
        {
            var client = CreateClient();
            var result = await client.PostAsync(BaseUrl + "/" + url, new StringContent(str));
            return await result.Content.ReadAsStringAsync();
        }
    }

    public interface ILoginManager
    {
        UserInfoViewModel UserInfo { get; }
        bool IsLoggedIn { get; }
        void Logout();
        Task<bool> LoginAsync(string username, string password);

        void RefreshUserInfo();
    }

    public interface IVersionChecker
    {
        bool CheckVersion(VersionInfo version);
        void OpenInStore(VersionInfo version);

    }
    public class LoginService : ILoginManager
    {
        public App.ApartmentAppsClient Data { get; set; }
        
        public LoginService(IApartmentAppsAPIService data)
        {
          
            Data = data as App.ApartmentAppsClient;
        }

        public bool IsLoggedIn { get { return AparmentAppsDelegating.AuthorizationKey != null; } }

        

        public void Logout()
        {
            Data.Logout();
        }
        public static Action<string> SetRegistrationId { get; set; }
        public static Func<string> GetRegistrationId { get; set; } 

        public static string DeviceHandle { get; set; }
        public static string DevicePlatform { get; set; }

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
           
                if (!IsLoggedIn)
                {
                    await Data.LoginAsync(username, password);
                }
               
                if (IsLoggedIn)
                {
                    RefreshUserInfo();
                    if (GetRegistrationId != null && DeviceHandle != null)
                    {
                        var registerResult = await Data.Register.PutAsync(GetRegistrationId().Replace("\"",""), new DeviceRegistration()
                        {
                            Handle = DeviceHandle.Replace("<","").Replace(">","").Replace(" ",""),
                            Platform = DevicePlatform,
                            Tags = new List<string>()
                        });
                        if (registerResult != null)
                        SetRegistrationId(registerResult);
                    }
                }
                return IsLoggedIn;
            }
            catch (Exception ex) { }
            {
                return false;
            }

        }

        public void RefreshUserInfo()
        {
            UserInfo = Data.Account.GetUserInfo();
        }

        public UserInfoViewModel UserInfo { get; set; }
    }
}
