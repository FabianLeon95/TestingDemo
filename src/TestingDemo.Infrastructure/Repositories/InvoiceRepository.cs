using Microsoft.EntityFrameworkCore;
using TestingDemo.Domain.Entities;
using TestingDemo.Domain.Interfaces.Repositories;
using TestingDemo.Infrastructure.DataContexts;

namespace TestingDemo.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;

        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(Guid id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetConsecutiveByLocation(string locationCode)
        {
            return await _context.Invoices
                .Where(i => i.Code.Contains(locationCode))
                .CountAsync() + 1;
        }
    }
}
