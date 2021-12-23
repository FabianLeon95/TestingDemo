using System;
using System.Linq;
using System.Threading.Tasks;
using TestingDemo.Domain.Entities;
using TestingDemo.Infrastructure.DataContexts;
using TestingDemo.Infrastructure.Repositories;
using TestingDemo.IntegrationTests.Common;
using Xunit;

namespace TestingDemo.IntegrationTests.Repositories
{
    public class InvoiceRepositoryTests : DatabaseTests
    {
        [Fact]
        public async Task GetInvoicesAsync_ReturnsAllInvoices()
        {
            // Arrange
            await using var context = new DataContext(ContextOptions);
            var repository = new InvoiceRepository(context);

            // Act
            var invoices = await repository.GetInvoicesAsync();

            // Assert
            Assert.Equal(4, invoices.Count());
        }

        [Theory]
        [InlineData("P01", 3)]
        [InlineData("P02", 2)]
        [InlineData("P03", 2)]
        public async Task GetConsecutiveByLocation_ReturnsCorrectValue(string locationCode, int expectedValue)
        {
            // Arrange
            await using var context = new DataContext(ContextOptions);
            var repository = new InvoiceRepository(context);

            // Act
            var result = await repository.GetConsecutiveByLocationAsync(locationCode);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public async Task AddInvoice_SavesInvoice()
        {
            await using (var context = new DataContext(ContextOptions))
            {
                var repository = new InvoiceRepository(context);
                var newInvoice = new Invoice
                {
                    Id = new Guid("80590d65-add4-42b6-ba28-92733de8b570"),
                    Code = "P03_3",
                    Total = 3000,
                    Date = DateTime.Now
                };

                await repository.AddInvoiceAsync(newInvoice);
            }

            await using (var context = new DataContext(ContextOptions))
            {
                var repository = new InvoiceRepository(context);

                var invoice = await repository.GetInvoiceByIdAsync(new Guid("80590d65-add4-42b6-ba28-92733de8b570"));

                Assert.NotNull(invoice);
                Assert.Equal("80590d65-add4-42b6-ba28-92733de8b570", invoice.Id.ToString());
            }
        }
    }
}
