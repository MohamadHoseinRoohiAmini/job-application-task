using Mc2.CrudTest.Domain.Customer.Dtoes;
using MediatR;
using System;

namespace Mc2.CrudTest.Application.Queries.Requests
{
    public class GetCustomerRequest : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}
