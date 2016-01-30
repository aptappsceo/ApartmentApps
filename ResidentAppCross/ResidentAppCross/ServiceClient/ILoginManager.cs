using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
        bool IsLoggedIn { get; }
        void Logout();
        Task<string> Login(string username, string password);
    }

    public class LoginService : ILoginManager
    {
        public IRestClient RestClient { get; set; }

        public LoginService(IRestClient restClient)
        {
            RestClient = restClient;
        }


        public bool IsLoggedIn => RestClient.BearerToken != null;

        public void Logout()
        {
            RestClient.BearerToken = null;
        }

        public async Task<string> Login(string username, string password)
        {
            if (await RestClient.LoginAsync(username, password))
            {
                return null;
            }
            return "Error logging in.";
            //var x = new WebClient();

            //var webClient = new WebClient();

            //var nameValueCollection = new NameValueCollection()
            //{

            //};
            //nameValueCollection.Add("username", "micahosborne@gmail.com");
            //nameValueCollection.Add("password", "Asdf1234!");
            //nameValueCollection.Add("grant_type", "password");

            //var response = new UTF8Encoding().GetString(webClient.UploadValues(url + "/Token", "POST", nameValueCollection));
            //Console.WriteLine(response);



            //var obj = JObject.Parse(response);
            //var accessToken = (string)obj["access_token"];
            //Console.WriteLine("ACCESS TOKEN = " + accessToken);
        }
    }
}
