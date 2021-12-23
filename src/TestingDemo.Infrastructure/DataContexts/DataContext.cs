using Microsoft.EntityFrameworkCore;
using TestingDemo.Domain.Entities;

namespace TestingDemo.Infrastructure.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
