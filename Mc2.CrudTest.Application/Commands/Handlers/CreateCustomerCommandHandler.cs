using AutoMapper;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Domain.Customer.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request.Dto);

            customer = await _customerRepository.Add(customer);

            return customer.Id;
        }
    }
}
