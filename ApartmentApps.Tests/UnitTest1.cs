using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                new Filter() {Operator = ExpressionOperator.EndsWith, PropertyName = "Name", Value = "1"},
                //new Filter() {Operator = ExpressionOperator.Contains, PropertyName = "Name", Value = "02"}
            });

            foreach (var item in dbContext.Buildings.Where(builder))
            {
                Console.WriteLine(item.Name);
            }


        }
    }
}
