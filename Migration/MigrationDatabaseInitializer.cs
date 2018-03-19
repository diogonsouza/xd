using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fbiz.Framework.DataAccess;
using MigSharp;

namespace Migration
{
    public class MigrationDatabaseInitializer : IDatabaseInitializer
    {
        public void Initialize(string connectionString)
        {
            this.runMigrator(connectionString);
        }

        public void Reset(string connectionString)
        {
            this.resetMigrator(connectionString);
        }

        private void resetMigrator(string connectionString)
        {
            getMigration(connectionString).MigrateTo(this.GetType().Assembly, 0);
        }

        private void runMigrator(string connectionString)
        {
            getMigration(connectionString).MigrateAll(this.GetType().Assembly);
        }

        private Migrator getMigration(string connectionString)
        {
            return new Migrator(connectionString, MigSharp.ProviderNames.SqlServer2008, getMigrationOptions());
        }

        private MigrationOptions getMigrationOptions()
        {
            var migrationOptions = new MigrationOptions();

            var supportedProviders = new[] { MigSharp.ProviderNames.SqlServer2005, ProviderNames.SqlServer2008, ProviderNames.SqlServer2012 };

            foreach (var providerName in migrationOptions.SupportedProviders.Names.ToArray())
            {
                if (!supportedProviders.Contains(providerName))
                    migrationOptions.SupportedProviders.Remove(providerName);
            }
            return migrationOptions;
        }
    }
}
