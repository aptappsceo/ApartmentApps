using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.Jobs;
using ApartmentApps.Portal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace ApartmentApps.Tests
{



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
