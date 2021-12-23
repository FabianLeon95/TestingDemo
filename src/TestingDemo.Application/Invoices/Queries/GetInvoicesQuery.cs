using MediatR;
using TestingDemo.Domain.Entities;
using TestingDemo.Domain.Interfaces.Repositories;

namespace TestingDemo.Application.Invoices.Queries
{
    public class GetInvoicesQuery : IRequest<IEnumerable<Invoice>>
    {
    }

    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, IEnumerable<Invoice>>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetInvoicesQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<IEnumerable<Invoice>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.GetInvoicesAsync();
        }
    }
}
