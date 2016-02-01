using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.API.Service.Models;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Owin;

[assembly: OwinStartup(typeof(ApartmentApps.API.Service.Startup))]

namespace ApartmentApps.API.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var a = new UnityContainer();
            //a.RegisterType<ApplicationDbContext>()
            ConfigureAuth(app);
            //app.
        }
    }
}
