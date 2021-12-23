using MediatR;
using TestingDemo.Application.Services;
using TestingDemo.Domain.Entities;
using TestingDemo.Domain.Interfaces.Repositories;

namespace TestingDemo.Application.Invoices.Commands
{
    public class CreateInvoiceCommand : IRequest<Invoice>
    {
        public string LocationCode { get; set; }
        public double BaseRate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var consecutive = await _invoiceRepository.GetConsecutiveByLocation(request.LocationCode);
            var code = InvoiceService.GenerateCode(request.LocationCode, consecutive);
            var total = InvoiceService.CalculatePrice(request.BaseRate, request.CheckIn, request.CheckOut);

            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Code = code,
                Total = total
            };

            await _invoiceRepository.AddInvoice(invoice);

            return invoice;
        }
    }
}
