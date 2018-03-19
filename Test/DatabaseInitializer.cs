using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migration;
using System.Configuration;

namespace Test
{
    [TestClass]
    public class DatabaseInitializer
    {
        [AssemblyInitialize]
        public static void InitializeTests(TestContext testContext)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            
            var migrationDatabaseInitializer = new MigrationDatabaseInitializer();
            migrationDatabaseInitializer.Reset(connectionString);
            migrationDatabaseInitializer.Initialize(connectionString);
            
        }
    }
}
