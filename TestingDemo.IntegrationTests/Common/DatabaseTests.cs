using System;
using Microsoft.EntityFrameworkCore;
using TestingDemo.Domain.Entities;
using TestingDemo.Infrastructure.DataContexts;

namespace TestingDemo.IntegrationTests.Common
{
    public abstract class DatabaseTests
    {
        protected DatabaseTests()
        {
            ContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite("Filename=Test.db")
                .Options;

            Seed();
        }

        protected DbContextOptions<DataContext> ContextOptions { get; }

        private void Seed()
        {
            using var context = new DataContext(ContextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var invoices = new[]
            {
                new Invoice {Id = Guid.NewGuid(), Code = "P01_1", Total = 1000, Date = DateTime.Now},
                new Invoice {Id = Guid.NewGuid(), Code = "P01_2", Total = 5750, Date = DateTime.Now},
                new Invoice {Id = Guid.NewGuid(), Code = "P02_1", Total = 2000, Date = DateTime.Now},
                new Invoice {Id = Guid.NewGuid(), Code = "P03_1", Total = 3750, Date = DateTime.Now}
            };

            context.Invoices.AddRange(invoices);

            context.SaveChanges();
        }
    }
}