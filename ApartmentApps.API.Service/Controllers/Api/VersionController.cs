using System.Web.Http;

namespace ApartmentApps.API.Service.Controllers.Api
{
    public class VersionInfo
    {
        public string AndroidStoreUrl { get; set; }
        public string IPhoneStoreUrl { get; set; }
   
        public double Version { get; set; }
        public int IPhoneBuildNumber { get; set; }
        public int AndroidBuildNumber { get; set; }
    }

    [System.Web.Http.RoutePrefix("api/Version")]
    public class VersionController : ApiController
    {
        public VersionInfo Get()
        {
            string appPackageName = "com.apartmentapps";
            return new VersionInfo
            {
                AndroidStoreUrl = "http://play.google.com/store/apps/details?id=" + appPackageName,
                IPhoneStoreUrl = "https://itunes.apple.com/tj/app/apartment-apps-v2/id1088688855?mt=8",
                IPhoneBuildNumber = 4,
                AndroidBuildNumber = 6,
                Version = 2.3
            };
        }
    }
}