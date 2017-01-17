﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Auth;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.IoC;
using ApartmentApps.Modules.Inspections;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;

namespace ApartmentApps.Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel mainKernel = new StandardKernel();
            Register.RegisterServices(mainKernel);
            Inspection inspection = new Inspection();
            PaymentSummaryBindingModel model = new PaymentSummaryBindingModel();
//#if DEBUG
//            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApartmentApps.Data.Migrations.Configuration>());
//#endif   
            var context = new ApplicationDbContext();
            //var ids = new int[] {33};
            //foreach (var item in context.Properties.Where(x=>ids.Contains(x.Id)).ToArray())
            foreach (var item in context.Properties.Where(p=>p.State == PropertyState.Active).ToArray())
            {
                IKernel kernel = new StandardKernel();
                Register.RegisterServices(kernel);

                kernel.Bind<DefaultUserManager>().ToSelf().InSingletonScope();
                kernel.Bind<UserManager<ApplicationUser>>().ToSelf().InSingletonScope();
                kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InSingletonScope();
                var userContext = new FakeUserContext(context)
                {
                    PropertyId = item.Id,
                    UserId = context.Users.First(p=>p.UserName == "micahosborne@gmail.com").Id,
                    Email = "micahosborne@gmail.com",
                    Name = "Jobs"
                };
                
                kernel.Bind<IUserContext>().ToMethod(p=>userContext);
                kernel.Bind<ILogger>().To<ConsoleLogger>();
#if DEBUG
                var modules = kernel.GetAll<IModule>().Where(p=>p.Enabled).OfType<EntrataModule>().ToArray();
#else
                var modules = kernel.GetAll<IModule>().Where(p=>p.Enabled).OfType<IWebJob>().ToArray();
#endif

                foreach (var module in modules)
                {
                    try
                    {
                        module.Execute(new ConsoleLogger());
                    }
                    catch (Exception ex)
                    {
                        kernel.Get<IEmailService>().SendAsync(new IdentityMessage()
                        {
                            Subject = $"Background Error with module: {module.GetType().Name}",
                            Body = item.Name + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace,
                            Destination = "mosborne@apartmentapps.com"
                        });
                    }
                }

            }
   

        }
    }

    //public class ConsoleLogger : ILogger
    //{
    //    public void Error(string str, params object[] args)
    //    {
    //        Console.WriteLine(str,args);
    //    }

    //    public void Warning(string str, params object[] args)
    //    {
    //        Console.WriteLine(str, args);
    //    }

    //    public void Info(string str, params object[] args)
    //    {
    //        Console.WriteLine(str, args);
    //    }
    //}

    //public class JobsUserContext : IUserContext
    //{
    //    private readonly ApplicationDbContext _dbContext;

    //    public JobsUserContext(ApplicationDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    private ApplicationUser _currentUser;

    //    public bool IsInRole(string roleName)
    //    {
    //        return true;
    //    }

    //    public string UserId { get; set; }
    //    public string Email { get; set; }
    //    public string Name { get; set; }
    //    public int PropertyId { get; set; }

    //    public void SetProperty(int propertyId)
    //    {
            
    //    }

    //    public ApplicationUser CurrentUser
    //    {
    //        get { return _currentUser ?? (_currentUser = _dbContext.Users.Find(UserId)); }
    //        set { _currentUser = value; }
    //    }
    //}
   
}
