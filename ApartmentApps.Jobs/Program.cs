using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.Modules;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;

namespace ApartmentApps.Jobs
{
    class Program
    {


        static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApartmentApps.Data.Migrations.Configuration>());
            
            var context = new ApplicationDbContext();

            foreach (var item in context.Properties.ToArray())
            {
                using (var execution = new PropertyExecutionContext(context, item.Id))
                {
                    var modules = execution.Kernel.GetAll<IModule>().Where(p => p.Enabled).OfType<IWebJob>().ToArray();
                    //var jobRepo = kernel.Get<IRepository<ProcessInfo>>();

                    foreach (var module in modules)
                    {
                        module.Execute(new ConsoleLogger());
                    }

                }
            }
   

        }
    }
}
