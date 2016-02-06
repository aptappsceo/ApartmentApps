using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApartmentApps.Portal.Startup))]
namespace ApartmentApps.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
            ConfigureAuth(app);
        }
    }
}
