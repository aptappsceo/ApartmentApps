using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlaygroundConsole
{
    class Program
    {
        static async void Main2()
        {
            var url = "http://apartmentappsapiservice.azurewebsites.net";
            var x = new HttpClient();

            var response = await x.PostAsync(url + "/Token", new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                {"Username", "micahosborne@gmail.com" },
                {"password", "Asdf1234!" },
                {"grant_type", "password" },
            }));

            var responseString = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(responseString);
            var accessToken = (string)obj["access_token"];
            Console.WriteLine("ACCESS TOKEN = " + accessToken);

            var a = new Unknowntype(new Uri("http://apartmentappsapiservice.azurewebsites.net"), new BearerDelegatingHandler(accessToken));
            foreach (var item in a.Values.Get())
            {
                Console.WriteLine("VALUE = " + item);
            }
            
        }
        static void Main(string[] args)
        {
            Main2();
            Console.ReadLine();

            //var webClient = new WebClient();
            
            //var nameValueCollection = new NameValueCollection()
            //{
              
            //};
            //nameValueCollection.Add("username", "micahosborne@gmail.com");
            //nameValueCollection.Add("password", "Asdf1234!");
            //nameValueCollection.Add("grant_type", "password");

            //var response = new UTF8Encoding().GetString(webClient.UploadValues(url + "/Token","POST", nameValueCollection));
            //Console.WriteLine(response);

          
        }
    }

    public class BearerDelegatingHandler :DelegatingHandler
    {
        public string AuthorizationKey { get; set; }

        public BearerDelegatingHandler(string authorizationKey)
        {
            AuthorizationKey = authorizationKey;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization","Bearer " + AuthorizationKey);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
