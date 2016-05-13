using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApartmentApps.Client;
using ApartmentApps.Payments.Forte;
using ApartmentApps.Payments.Forte.Forte.Client;
using Entrata.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PushSharp;
using PushSharp.Apple;

namespace PlaygroundConsole
{
   
    class Program
    {
        static async Task Main4()
        {
            //return Task.Delay(0);
            //var merchantId = "1234";
            //var apiClientId = "2000";
            //var key = "";
            //var client = new ApartmentApps.Payments.Forte.Forte.Client.ClientServiceClient();
            //var auth = Authenticate.GetClientAuthTicket(apiClientId, key);
            //var result = await client.createClientAsync(auth, new ClientRecord()
            //{
            //     FirstName = "",
            //     LastName = "",


            //});
            //var clientId = result.Body.createClientResult;

            //var  client.createPaymentMethodAsync(auth, new PaymentMethod()
            //{
            //    ClientID = result.Body.createClientResult,

            //    CcCardType = CcCardType.VISA,
            //    AcctHolderName = "",
            //    CcCardNumber = "",
            //    CcExpirationDate = "",
            //    CcProcurementCard = false,
            //    EcAccountNumber = "",

            //});
        } 
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
            Main4();
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
