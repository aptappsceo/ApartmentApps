using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.API.Service.Models;
using Microsoft.Owin;
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
            //UnityConfig.RegisterComponents();
            
            ConfigureAuth(app);
                
            //app.
        }
    }
}
