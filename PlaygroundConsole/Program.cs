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

        static async void Main3()
        {
            var client = new EntrataClient()
            {
                Username = "apartmentappsinc",
                Password = "Password1",
                EndPoint = "rampartnersllc"
            };
            var customer = await client.GetCustomers("162896");


            var customers = customer.Response.Result.Customers.Customer;
            var result = await client.GetMitsLeases("162896");
            var leases = result.response.result.LeaseApplication.LA_Lease;
            //  var tenants = result.response.result.LeaseApplication.Tenant;

            foreach (var item in customers)
            {
                var leaseId = item.LeaseId.Identification[0].IDValue.ToString();
                var entrataId = item.Attributes.Id;
                var lease = leases.FirstOrDefault(p => p.Identification.IDValue == leaseId);
                if (lease == null) continue;

                var moveOutInfo =
                    lease.LeaseEvents.LeaseEvent.FirstOrDefault(p => p.Attributes.EventType == "ActualMoveOut");
                if (moveOutInfo != null)
                {
                    Console.Write($"Archiving User {item.FirstName} {item.LastName} {leaseId} {entrataId} ");
                    //archive user
                }
            }
        }

        //    var leaseApps = result.response.result.LeaseApplication;
            
        //    var tenants = leaseApps.Tenant;
        //    var leases = leaseApps.LA_Lease;
        //    foreach (var item in tenants)
        //    {
        //        var id = item.LeaseID.Identification.FirstOrDefault();
        //        if (id != null)
        //        {
                   
        //            var idValue = id.IDValue;
        //            var lease = leases.FirstOrDefault(p => p.Identification.IDValue == idValue);
        //            if (lease != null)
        //            {
        //                var charge =
        //                    lease.AccountingData.ChargeSet.SelectMany(p => p.Charge)
        //                        .FirstOrDefault(p => p.Attributes.ChargeType.ToUpper() == "BASE RENT");
        //                if (charge != null)
        //                {
        //                    Console.WriteLine(charge.Amount + item.Name.FirstName + " " + item.Name.LastName);
        //                }

        //            }
        //            else
        //            {
        //                Console.WriteLine("NOT FOUND" + item.Name.FirstName + " " + item.Name.LastName);
        //            }
        //        }
               
        //    }

        //}

        static void Main(string[] args)
        {
            Main3();
            Console.ReadLine();

           
          
        }
    }

   
}

