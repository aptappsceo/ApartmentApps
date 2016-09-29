using System;
using System.Linq;
using ApartmentApps.Api;
using ApartmentApps.Api.Auth;
using ApartmentApps.Data;
using ApartmentApps.IoC;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;

namespace ApartmentApps.Jobs
{
    public class PropertyExecutionContext : IDisposable
    {
        public ApplicationDbContext Context { get; }

        public IKernel Kernel = new StandardKernel();

        public PropertyExecutionContext(ApplicationDbContext dbContext, int propertyId)
        {
            Context = dbContext;
            Register.RegisterServices(Kernel);
            Kernel.Bind<DefaultUserManager>().ToSelf().InSingletonScope();
            Kernel.Bind<UserManager<ApplicationUser>>().ToSelf().InSingletonScope();
            Kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InSingletonScope();
            var userContext = new FakeUserContext(Context)
            {
                PropertyId = propertyId,
                UserId = Context.Users.First(p => p.UserName == "micahosborne@gmail.com").Id,
                Email = "micahosborne@gmail.com",
                Name = "Jobs"
            };

            Kernel.Bind<IUserContext>().ToMethod(p => userContext);

        }

        public void Dispose()
        {
            
        }
    }
}