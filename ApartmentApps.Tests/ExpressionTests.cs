using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Web.Mvc;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.IoC;
using ApartmentApps.Jobs;
using ApartmentApps.Portal.Controllers;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace ApartmentApps.Tests
{
    public class PropertyControllerTest<TController> : PropertyTest
    {
        public override void Init()
        {
            base.Init();
            Context.Kernel.Bind<TController>().ToSelf();
            Controller = Context.Kernel.Get<TController>();
        }

        public TController Controller { get; set; }
    }
    [TestClass]
    public class PropertyTest
    {
        [TestInitialize]
        public virtual void Init()
        {
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
    [TestClass]
    public class DbQueryTests
    {
        [TestMethod]
        public void TestDbQuerySerialize()
        {
            DbQuery query = new DbQuery();
            query.Model = new DataModel();
            query.Model.LoadFromType(typeof(Unit));
            query.CreateSimpleCondition("Unit.Name", "Equal", "01");
            Console.WriteLine(query.SaveToString());
        }
    }

    [TestClass]
    public class ExpressionTests
    {
        [TestInitialize]
        public void Init()
        {
            
        }


        //[TestMethod]
        //public void TestSearchable()
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApartmentApps.Data.Migrations.Configuration>());
        //    var db = new ApplicationDbContext();

        //    var property = db.Properties.FirstOrDefault();
        //    Assert.IsNotNull(property, "Property is null");
        //    using (var ctx = new PropertyExecutionContext(db, property.Id))
        //    {
        //        var searchable = ctx.Kernel.Get<StandardCrudService<ApplicationUser>>();
        //        int c;
        //        var results = searchable.Search<UserBindingModel>(new UserSearchViewModel() , out c, "Email", true, 0, 40);
        //        foreach (var item in results)
        //        {
        //            Console.WriteLine(item.Email);
        //        }
        //    }
        //}
        //[TestMethod]
        //public void TestMemberFilter()
        //{
           
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApartmentApps.Data.Migrations.Configuration>());
        //    var dbContext = new ApplicationDbContext();
        //    var builder = ExpressionBuilder.GetExpression<ApplicationUser>(new List<Filter>()
        //    {

        //        new Filter() {Operator = ExpressionOperator.Contains, PropertyName = "Unit.Name", Value = "1"},
        //        //new Filter() {Operator = ExpressionOperator.Contains, PropertyName = "Name", Value = "02"}
        //    });

        //    var results = dbContext.Users.Where(builder);

        //    foreach (var item in results)
        //    {
        //        Console.WriteLine(item.Email);
        //    }


        //}

    }
}
