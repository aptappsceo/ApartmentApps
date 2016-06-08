using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.IoC;
using Ninject;

namespace ApartmentApps.Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationDbContext();
            foreach (var item in context.Properties)
            {
                IKernel kernel = new StandardKernel();
                Register.RegisterServices(kernel);
                var userContext = new JobsUserContext(context)
                {
                    PropertyId = item.Id,
                    UserId = context.Users.First(p=>p.UserName == "micahosborne@gmail.com").Id,
                    Email = "micahosborne@gmail.com",
                    Name = "Jobs"
                };
                kernel.Bind<IUserContext>().ToMethod(p=>userContext);

                foreach (var module in kernel.GetAll<IModule>().OfType<IWebJob>().ToArray())
                {
                    module.Execute(new ConsoleLogger());
                }

            }
           

        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Error(string str, params object[] args)
        {
            Console.WriteLine(str,args);
        }

        public void Warning(string str, params object[] args)
        {
            Console.WriteLine(str, args);
        }

        public void Info(string str, params object[] args)
        {
            Console.WriteLine(str, args);
        }
    }

    public class JobsUserContext : IUserContext
    {
        private readonly ApplicationDbContext _dbContext;

        public JobsUserContext(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ApplicationUser _currentUser;

        public bool IsInRole(string roleName)
        {
            return true;
        }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int PropertyId { get; set; }

        public void SetProperty(int propertyId)
        {
            
        }

        public ApplicationUser CurrentUser
        {
            get { return _currentUser ?? (_currentUser = _dbContext.Users.Find(UserId)); }
            set { _currentUser = value; }
        }
    }
   
}
