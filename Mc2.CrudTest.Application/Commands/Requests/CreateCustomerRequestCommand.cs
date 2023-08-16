using Mc2.CrudTest.Domain.Customer.Dtoes;
using MediatR;
using System;

namespace Mc2.CrudTest.Application.Commands.Requests
{
    public class CreateCustomerRequestCommand : IRequest<Guid>
    {
        public CreateCustomerDto? Dto { get; set; }
    }
}
