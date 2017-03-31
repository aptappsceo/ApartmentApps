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

        public IKernel Kernel;

        public PropertyExecutionContext(IKernel kernel)
        {
            Kernel = kernel;
           
            Register.RegisterServices(Kernel);
            Context = Kernel.Get<ApplicationDbContext>();
            Kernel.Bind<DefaultUserManager>().ToSelf().InSingletonScope();
            Kernel.Bind<UserManager<ApplicationUser>>().ToSelf().InSingletonScope();
            Kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InSingletonScope();
            Kernel.Bind<IUserContext>().ToMethod(p => UserContext);
        }

        public void SetUserWithProperty(int propertyId)
        {
            var user = Context.Users.First(p => p.UserName == "micahosborne@gmail.com");
            OldPropertyId = user.PropertyId;
            user.PropertyId = propertyId;
            Context.SaveChanges();
            UserContext = new FakeUserContext(Context, Kernel)
            {
                PropertyId = propertyId,
                UserId = user.Id,
                Email = "micahosborne@gmail.com",
                Name = "Jobs"
            };
        }

        public int? OldPropertyId { get; set; }

        public FakeUserContext UserContext { get; set; }

        public void Dispose()
        {
            var user = UserContext.CurrentUser;
            user.PropertyId = OldPropertyId;
            Context.SaveChanges();
        }
    }
}