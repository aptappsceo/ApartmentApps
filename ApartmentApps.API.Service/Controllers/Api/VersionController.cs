using System.Web.Http;

namespace ApartmentApps.API.Service.Controllers.Api
{
    public class VersionInfo
    {
        public string AndroidStoreUrl { get; set; }
        public string IPhoneStoreUrl { get; set; }
        public int BuildNumber { get; set; }
        public double Version { get; set; }
    }

    [System.Web.Http.RoutePrefix("api/Version")]
    public class VersionController : ApiController
    {
        public VersionInfo Get()
        {
            string appPackageName = "TODO";
            return new VersionInfo
            {
                AndroidStoreUrl = "http://play.google.com/store/apps/details?id=" + appPackageName,
                IPhoneStoreUrl = "https://itunes.apple.com/tj/app/apartment-apps-v2/id1088688855?mt=8",
                BuildNumber = 1,
                Version = 2.0
            };
        }
    }
}