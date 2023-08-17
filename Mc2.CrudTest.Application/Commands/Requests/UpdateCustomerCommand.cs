using Mc2.CrudTest.Domain.Customer.Dtoes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Application.Commands.Requests
{
    public class UpdateCustomerCommand : IRequest<Unit> 
    {
        public UpdateCustomerDto UpdateDto { get; set; }
    }
}
