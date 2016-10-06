using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entrata.Client.GetMitsLeases;
using Entrata.Client.GetMitsUnits;
using Entrata.Model.Requests;
using Newtonsoft.Json;

namespace Entrata.Client
{
    public class EntrataClient
    {
        public string BaseUrl => $"https://{EndPoint}.entrata.com/api/";
        public string Username { get; set; }
        public string Password { get; set; }
        public string  EndPoint { get; set; }
        public EntrataRequest BuildRequest(string name, Dictionary<string,string> parameters )
        {
            var request = new EntrataRequest
            {
                Auth = new Auth()
                {
                    Username = Username,
                    Type = "basic",
                    Password = Password
                },
                RequestId = 15,
                Method = new Method()
                {
                    Name = name,
                    Params = parameters
                }
            };
            return request;
        }

        public async Task<TResponse> SendRequest<TResponse>(string methodName, Dictionary<string,string> parameters, string apiName = "customers")
        {
            var client = new HttpClient();

            var result = await client.PostAsync(BaseUrl + apiName,
                new StringContent(JsonConvert.SerializeObject(BuildRequest(methodName, parameters)),Encoding.Default, "application/json"));
            var str = await result.Content.ReadAsStringAsync();
            return (TResponse)JsonConvert.DeserializeObject(str, typeof (TResponse));
        }

        public async Task<MitsUnitsResponse> GetMitsUnits(string propertyId)
        {
            var result = await SendRequest<MitsUnitsResponse>("getMitsPropertyUnits", new Dictionary<string, string>()
            {
                {"propertyIds", propertyId},
                {"availableUnitsOnly ", "0"},
                {"usePropertyPreferences", "0"},
                {"includeDisabledFloorplans", "0"},
                {"includeDisabledUnits", "0"},
                {"showUnitSpaces", "0"},
              
            }, "propertyunits");

            return result;
        }

        /// <summary>
        /// Use leaseStatusTypeIds = 6 for past, 4 = current
        /// </summary>
        /// <param name="propertyId"></param>
        /// <param name="leaseStatusTypeIds"></param>
        /// <returns></returns>
        public async Task<GetCustomersResponse> GetCustomers( string propertyId, string leaseStatusTypeIds = "4" )
        {
            var result = await SendRequest<GetCustomersResponse>("getCustomers", new Dictionary<string, string>()
            {
                {
                    "propertyId", propertyId
                    
                },
                {"leaseStatusTypeIds", leaseStatusTypeIds }
            });

            return result;
        }
        public async Task<GetMitsLeases.GetMitsLeasesResponse> GetMitsLeases(string propertyId)
        {
            var result = await SendRequest<GetMitsLeasesResponse>("getMitsLeases", new Dictionary<string, string>()
            {
                {"propertyId", propertyId},
                {"includeLeaseHistory", "0"},
                {"sendUnitSpaces", "0"},
                {"includeDemographics", "0"},
                {"includeOtherIncomeLeases", "1"},
                {"residentFriendlyMode", "0"},

            }, "leases");

            return result;
        }
    }
}
