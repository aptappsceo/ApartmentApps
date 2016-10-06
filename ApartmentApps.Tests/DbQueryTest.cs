using System;
using System.Data.SqlClient;
using System.IO;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Portal.Controllers;
using DBDiff.Schema.SQLServer.Generates.Generates;
using DBDiff.Schema.SQLServer.Generates.Model;
using DBDiff.Schema.SQLServer.Generates.Options;
using Korzh.EasyQuery;
using Korzh.EasyQuery.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace ApartmentApps.Tests
{
    [TestClass]
    public class DbTasks
    {
        public static string ConnectionString2 = "Server=aptapps.database.windows.net,1433;Database=ApartmentApps_Development;User ID=aptapps;Password=Asdf1234!@#$;";
        public static string ConnectionString1 = "Server=aptapps.database.windows.net,1433;Database=ApartmentApps;User ID=aptapps;Password=Asdf1234!@#$;";
        public static SqlOption SqlFilter = new SqlOption();
        static void SaveFile(string filenmame, string sql)
        {
            if (!String.IsNullOrEmpty(filenmame))
            {
                StreamWriter writer = new StreamWriter(filenmame, false);
                writer.Write(sql);
                writer.Close();
            }
        }
        static Boolean TestConnection(string connectionString1, string connectionString2)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = connectionString1;
                connection.Open();
                connection.Close();
                connection.ConnectionString = connectionString2;
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BackupProdDb()
        {
            
        }

        [TestMethod]
        public void GenerateScripts()
        {
            try
            {
                Database origin;
                Database destination;
                if (TestConnection(ConnectionString1, ConnectionString2))
                {
                    Generate sql = new Generate();
                    sql.ConnectionString = ConnectionString1;
                    Console.WriteLine("Reading first database...");
                    sql.Options = SqlFilter;
                    origin = sql.Process();
                    sql.ConnectionString = ConnectionString2;
                    Console.WriteLine("Reading second database...");
                    destination = sql.Process();
                    Console.WriteLine("Comparing databases schemas...");
                    origin = Generate.Compare(origin, destination);
                    //if (!arguments.OutputAll)
                    //{
                    //    // temporary work-around: run twice just like GUI
                    //    origin.ToSqlDiff();
                    //}
                    origin.ToSqlDiff();
                    Console.WriteLine("Generating SQL file...");
                    Console.WriteLine();

                    SaveFile("UpgradeDb.sql", origin.ToSqlDiff().ToSQL());


                    //completedSuccessfully = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("{0}\r\n{1}\r\n\r\nPlease report this issue at http://opendbiff.codeplex.com/workitem/list/basic\r\n\r\n", ex.Message, ex.StackTrace));
            }
        }
    }

    [TestClass]
    public class DbQueryTest : PropertyTest
    {
        [TestInitialize]
        public override void Init()
        {
            base.Init();
        }

        [TestCleanup]
        public override void DeInit()
        {
            base.DeInit();
        }

        [TestMethod]
        public void Test()
        {
            DbQuery query = new DbQuery();
            query.Model = new DbModel();
            query.Model.LoadFromType(typeof(ApplicationUser));
            query.Root.Conditions.Add(query.CreateSimpleCondition("ApplicationUser.Archived", "NotTrue"));
            var service = Context.Kernel.Get<UserService>();
            int count;
            var result = service.GetAll<UserBindingModel>(query, out count, null, false);
            Console.WriteLine(query.GetConditionsText(QueryTextFormats.Default));
            Console.WriteLine(count);
            //SqlQueryBuilder builder = new SqlQueryBuilder(query);
            //builder.BuildSQL();
            //string sql = builder.Result.SQL;
            //Console.WriteLine(sql);
        }
    }
}