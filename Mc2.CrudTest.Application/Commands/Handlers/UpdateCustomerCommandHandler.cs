using AutoMapper;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Extensions;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Application.Contracts.Validators;
using Mc2.CrudTest.Domain.Customer.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;


        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerDtoValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new CustomerDataNotValidateForUpdateException();

            var validationMobile = ValidatePhone.MethodValidate(request.PhoneNumber ?? string.Empty);
            if (!validationMobile)
                throw new MobileNumberIsNotValidException();

            var customer = await _customerRepository.Get(request.Id ?? Guid.NewGuid());

            _mapper.Map(request, customer);

            if (customer == null)
                throw new CustomerNotCreatedException();

            await _customerRepository.Update(customer);

            return Unit.Value;
        }
    }
}
