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
using ApartmentApps.Client;
using Entrata.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlaygroundConsole
{
   
    class Program
    {
        static async void Main3()
        {
            var client = new EntrataClient()
            {
                Username = "apartmentappsinc",
                Password = "Password1",

            };
            var result = await client.GetCustomers("162896");
            var customers = result.Response.Result.Customers.Customer;
            foreach (var item in customers)
            {
                Console.WriteLine(item.FirstName);
            }

        }
        static async void Main2()
        {
            var client = new App.ApartmentAppsClient();
            var login = await client.LoginAsync("micahosborne@gmail.com", "Asdf1234!");
            JsonToken token;
            foreach (var item in client.Values.Get())
            {
                Console.WriteLine("VALUE = " + item);
            }
            //var url = "http://apartmentappsapiservice.azurewebsites.net";
            //var x = new HttpClient();

            //var response = await x.PostAsync(url + "/Token", new FormUrlEncodedContent(new Dictionary<string, string>()
            //{
            //    {"Username", "micahosborne@gmail.com" },
            //    {"password", "Asdf1234!" },
            //    {"grant_type", "password" },
            //}));

            //var responseString = await response.Content.ReadAsStringAsync();
            //var obj = JObject.Parse(responseString);
            //var accessToken = (string)obj["access_token"];
            //Console.WriteLine("ACCESS TOKEN = " + accessToken);

            //var a = new Unknowntype(new Uri("http://apartmentappsapiservice.azurewebsites.net"), new BearerDelegatingHandler(accessToken));
            //foreach (var item in a.Values.Get())
            //{
            //    Console.WriteLine("VALUE = " + item);
            //}

        }
        static void Main(string[] args)
        {
            Main3();
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

   
}
