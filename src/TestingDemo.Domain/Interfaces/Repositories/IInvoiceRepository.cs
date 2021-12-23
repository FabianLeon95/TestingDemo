using TestingDemo.Domain.Entities;

namespace TestingDemo.Domain.Interfaces.Repositories;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetInvoicesAsync();
    Task<Invoice> GetInvoiceByIdAsync(Guid id);
    Task AddInvoice(Invoice invoice);
    Task<int> GetConsecutiveByLocation(string locationCode);
}