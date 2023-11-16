using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Queries.Requests;
using Mc2.CrudTest.Domain.Customer.Dtoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerDto>> Get(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerRequest { Id = id });
            return Ok(customer);
        }

        [HttpPost("Post")]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateCustomerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
