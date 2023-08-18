using MediatR;
using System;

namespace Mc2.CrudTest.Application.Commands.Requests
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
