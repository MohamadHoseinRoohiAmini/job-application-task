using AutoMapper;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Application.Contracts.Validators;
using Mc2.CrudTest.Domain.Customer.Entities;
using Mc2.CrudTest.Domain.Customer.Exceptions;
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
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;            
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerDtoValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new CustomerDataNotValidateForCreateException();
            //Todo : Validate ValidatePhone. static method

            var customer = _mapper.Map<Customer>(request);

            customer = await _customerRepository.Add(customer);

            return customer.Id;
        }
    }
}
