using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
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
        public static string ConnectionStringTest = "Server=aptapps.database.windows.net,1433;Database=ApartmentApps_Test;User ID=aptapps;Password=Asdf1234!@#$;";
        public static string ConnectionStringDevelopment = "Server=aptapps.database.windows.net,1433;Database=ApartmentApps_Development;User ID=aptapps;Password=Asdf1234!@#$;";
        public static string ConnectionStringProduction = "Server=aptapps.database.windows.net,1433;Database=ApartmentApps;User ID=aptapps;Password=Asdf1234!@#$;";


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
        //#if !DEBUG
        [TestMethod]
        public void MigrateProdDb()
        {
#if DEBUG
            return;
#endif
            
            string backupDbName =
                $"ApartmentApps_Backup{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}_{DateTime.Now.Ticks}";

            // Make Backup
            MackProdBackup(backupDbName);

            Thread.Sleep(new TimeSpan(0, 0, 1, 0));
#if RELEASE
            // Migrate production database
            using (var productionDb = new SqlConnection(ConnectionStringProduction))
            {
                MigrateDbInternal(productionDb);
            }
#endif
#if TEST
            // Migrate Test database
            using (var testDb = new SqlConnection($"Server=aptapps.database.windows.net,1433;Database={backupDbName};User ID=aptapps;Password=Asdf1234!@#$"))
            {
                MigrateDbInternal(testDb);
            }

            // Rename backup database to test database
            using (var masterDb = new SqlConnection($"Server=aptapps.database.windows.net,1433;Database=master;User ID=aptapps;Password=Asdf1234!@#$"))
            {
                masterDb.Open();
                var cmd = new SqlCommand($"IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'ApartmentApps_Test') ALTER DATABASE ApartmentApps_Test Modify Name = ApartmentApps_Test_{DateTime.Now.Ticks}; ", masterDb);
                cmd.CommandTimeout = Int32.MaxValue;
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand($"ALTER DATABASE {backupDbName} Modify Name = ApartmentApps_Test; ", masterDb);
                cmd.CommandTimeout = Int32.MaxValue;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Moved database into place");
            }
#endif
        }

        private static void MackProdBackup(string backupDbName)
        {
            Console.WriteLine("Creating Backup");
            using (var prodDb = new SqlConnection(ConnectionStringProduction))
            {
                prodDb.Open();
                var cmd = new SqlCommand($"CREATE DATABASE {backupDbName} AS COPY OF ApartmentApps;", prodDb);
                cmd.CommandTimeout = Int32.MaxValue;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Copied Production Database");
            }
        }

        private void MigrateDbInternal(SqlConnection connection)
        {
            var diffScript = GenerateDiffScript();
            var cmds = diffScript.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Console.WriteLine("Migrating Database With OpenDBDiff");
            connection.Open();
            SqlCommand cmd = new SqlCommand("DROP TABLE [dbo].[__MigrationHistory]", connection);
            cmd.CommandTimeout = Int32.MaxValue;
            cmd.ExecuteNonQuery();

            foreach (var c in cmds)
            {
                try
                {
                    cmd = new SqlCommand(c, connection);
                    cmd.CommandTimeout = Int32.MaxValue;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(false,
                        $"Sql command {c} didn't execute successfully" + Environment.NewLine + ex.Message);
                }
                Console.WriteLine($"Success: {c}");
            }

            Console.WriteLine("Database migration complete");
        }

        //#endif
        public string GenerateDiffScript()
        {
            Database origin;
            Database destination;
            if (TestConnection(ConnectionStringProduction, ConnectionStringDevelopment))
            {
                Generate sql = new Generate();
                sql.ConnectionString = ConnectionStringProduction;
                Console.WriteLine("Reading first database...");
                sql.Options = SqlFilter;
                origin = sql.Process();
                sql.ConnectionString = ConnectionStringDevelopment;
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
                return origin.ToSqlDiff().ToSQL();
            }
            return null;
        }

        [TestMethod]
        public void GenerateScripts()
        {
            try
            {

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