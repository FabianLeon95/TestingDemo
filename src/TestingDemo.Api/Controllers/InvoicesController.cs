using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestingDemo.Application.Invoices.Commands;
using TestingDemo.Application.Invoices.Queries;
using TestingDemo.Domain.Entities;

namespace TestingDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> Get()
        {
            var invoices = await _mediator.Send(new GetInvoicesQuery());

            return Ok(invoices);
        }

        [HttpGet("{id:guid}", Name = "GetById")]
        public async Task<ActionResult<Invoice>> Get(Guid id)
        {
            var invoice = await _mediator.Send(new GetInvoiceByIdQuery { Id = id });

            return Ok(invoice);
        }

        public async Task<ActionResult<Invoice>> Post(CreateInvoiceCommand command)
        {
            var invoice = await _mediator.Send(command);

            return CreatedAtRoute("GetById", new { id = invoice.Id }, invoice);
        }
    }
}
