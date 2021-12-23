using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TestingDemo.Infrastructure.DataContexts;

namespace TestingDemo.IntegrationTests.Common
{
    public class DatabaseFixture : IDisposable
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public DatabaseFixture()
        {
            Connection = new SqliteConnection("Filename=IntegrationTestsDatabase.db");

            Seed();

            Connection.Open();
        }

        public DbConnection Connection { get; }

        public void Dispose()
        {
            Connection.Dispose();
        }

        public DataContext CreateContext(DbTransaction? transaction = null)
        {
            var context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseSqlite(Connection).Options);

            if (transaction != null) context.Database.UseTransaction(transaction);

            return context;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (_databaseInitialized) return;

                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    //DatabaseSetup.SeedData(context);
                }

                _databaseInitialized = true;
            }
        }
    }
}