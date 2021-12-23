using TestingDemo.Domain.Entities;

namespace TestingDemo.Domain.Interfaces.Repositories;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetInvoicesAsync();
    Task<Invoice> GetInvoiceByIdAsync(Guid id);
    Task AddInvoiceAsync(Invoice invoice);
    Task<int> GetConsecutiveByLocationAsync(string locationCode);
}