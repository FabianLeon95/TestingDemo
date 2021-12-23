using MediatR;
using TestingDemo.Domain.Entities;
using TestingDemo.Domain.Interfaces.Repositories;

namespace TestingDemo.Application.Invoices.Queries
{
    public class GetInvoiceByIdQuery : IRequest<Invoice>
    {
        public Guid Id { get; set; }
    }

    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.GetInvoiceByIdAsync(request.Id);
        }
    }
}
