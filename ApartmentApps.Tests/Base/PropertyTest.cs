using System;
using System.Data.Entity;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.IoC;
using ApartmentApps.Jobs;
using ApartmentApps.Portal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace ApartmentApps.Tests
{
    [TestClass]
    public class PropertyTest
    {
        [TestInitialize]
        public virtual void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApartmentApps.Data.Migrations.Configuration>()); 
            Register.EnsureModuleAssemblies();
            Context = new PropertyExecutionContext(new StandardKernel());

            DbContext = Context.Context;
            Corporation = new Corporation()
            {
                Name = "Unit Test Corporation"
            };
            DbContext.Corporations.Add(Corporation);
            DbContext.SaveChanges();
            Property = new Property()
            {
                Name="Unit Test Property",
                CorporationId = Corporation.Id,
                TimeZoneIdentifier = "Eastern Standard Time",
                
            };
            DbContext.Properties.Add(Property);
            DbContext.SaveChanges();
            
          
            Context.SetUserWithProperty(Property.Id);
            

            Context.Kernel.Bind<ILogger>().To<ConsoleLogger>().InRequestScope();
            var buildingService = Context.Kernel.Get<BuildingService>();
            buildingService.Add(new BuildingViewModel()
            {
                Name="Building 1"
            });

            var unitService = Context.Kernel.Get<UnitService>();
            unitService.Add(new UnitViewModel()
            {
                BuildingId = Convert.ToInt32(buildingService.GetAll<BuildingViewModel>().First().Id),
                Name = "Unit 01"
            });

        }

        public Corporation Corporation { get; set; }

        public Property Property { get; set; }

        public ApplicationDbContext DbContext { get; set; }

        public PropertyExecutionContext Context { get; set; }

        public void RemoveAll<TType>() where TType : class
        {
            var set = Context.Kernel.Get<IRepository<TType>>();
            foreach (var item in set.ToArray())
            {
                set.Remove(item);
                set.Save();
            }
        }

        [TestCleanup]
        public virtual void DeInit()
        {
       
            RemoveAll<Unit>();
            RemoveAll<Building>();
            DbContext.Properties.Remove(Property);
            DbContext.SaveChanges();
            DbContext.Corporations.Remove(Corporation);
            DbContext.SaveChanges();

            Context.Dispose();
            DbContext.Dispose();
        }
    }
}