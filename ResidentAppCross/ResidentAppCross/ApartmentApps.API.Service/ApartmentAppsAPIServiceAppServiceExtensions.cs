using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace ApartmentApps.Client
{
    public static class ApartmentAppsAPIServiceAppServiceExtensions
    {
        public static ApartmentAppsAPIService CreateApartmentAppsAPIService(this IAppServiceClient client)
        {
            return new ApartmentAppsAPIService(client.CreateHandler());
        }

        public static ApartmentAppsAPIService CreateApartmentAppsAPIService(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new ApartmentAppsAPIService(client.CreateHandler(handlers));
        }

        public static ApartmentAppsAPIService CreateApartmentAppsAPIService(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new ApartmentAppsAPIService(uri, client.CreateHandler(handlers));
        }

        public static ApartmentAppsAPIService CreateApartmentAppsAPIService(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new ApartmentAppsAPIService(rootHandler, client.CreateHandler(handlers));
        }
    }
}
