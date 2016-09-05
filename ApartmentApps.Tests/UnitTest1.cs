using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApartmentApps.Tests
{



    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UpdateDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApartmentApps.Data.Migrations.Configuration>());
        }
        [TestMethod]
        public void TestMethod1()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApartmentApps.Data.Migrations.Configuration>());
            var dbContext = new ApplicationDbContext();
            var builder = ExpressionBuilder.GetExpression<Building>(new List<Filter>()
            {

                //new Filter() {Operator = ExpressionOperator.StartsWith, PropertyName = "Name", Value = "0"},
                //new Filter() {Operator = ExpressionOperator.Contains, PropertyName = "Name", Value = "02"}
            });

            var results = dbContext.Buildings.Where(builder).OrderBy("Name", true);

            foreach (var item in results)
            {
                Console.WriteLine(item.Name);
            }


        }

    }
}
