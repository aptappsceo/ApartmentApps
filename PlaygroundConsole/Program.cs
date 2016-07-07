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
using Yardi.Client.ResidentTransactions;

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
                EndPoint = "rampartnersllc"
            };
            var result = await client.GetMitsLeases("162896");
            var leaseApps = result.response.result.LeaseApplication;
            
            var tenants = leaseApps.Tenant;
            var leases = leaseApps.LA_Lease;
            foreach (var item in tenants)
            {
                var id = item.LeaseID.Identification.FirstOrDefault();
                if (id != null)
                {
                   
                    var idValue = id.IDValue;
                    var lease = leases.FirstOrDefault(p => p.Identification.IDValue == idValue);
                    if (lease != null)
                    {
                        var charge =
                            lease.AccountingData.ChargeSet.SelectMany(p => p.Charge)
                                .FirstOrDefault(p => p.Attributes.ChargeType.ToUpper() == "BASE RENT");
                        if (charge != null)
                        {
                            Console.WriteLine(charge.Amount + item.Name.FirstName + " " + item.Name.LastName);
                        }

                    }
                    else
                    {
                        Console.WriteLine("NOT FOUND" + item.Name.FirstName + " " + item.Name.LastName);
                    }
                }
               
            }

        }

        static void Main(string[] args)
        {
            Main3();
            Console.ReadLine();

           
          
        }
    }

   
}
