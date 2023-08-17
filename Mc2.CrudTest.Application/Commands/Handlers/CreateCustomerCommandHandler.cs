using AutoMapper;
using com.google.i18n.phonenumbers;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Application.Contracts.Validators;
using Mc2.CrudTest.Domain.Customer.Entities;
using Mc2.CrudTest.Domain.Customer.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static com.google.i18n.phonenumbers.PhoneNumberUtil;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly PhoneNumberUtil _phoneNumberUtil;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper , PhoneNumberUtil phoneNumberUtil)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _phoneNumberUtil = phoneNumberUtil;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Dto);

            if (!validationResult.IsValid)
                throw new CustomerDataNotValidateForCreateException();

            try
            {
                var number = _phoneNumberUtil.parse(request.Dto.PhoneNumber, "US"); // can be any country
                if (!_phoneNumberUtil.isValidNumber(number) || _phoneNumberUtil.getNumberType(number) != PhoneNumberType.MOBILE)
                {
                    throw new PhoneNumberNotValidException();
                }
            }
            catch (NumberParseException)
            {
                throw new PhoneNumberNotValidException();
            }

            var customer = _mapper.Map<Customer>(request.Dto);

            customer = await _customerRepository.Add(customer);

            return customer.Id;
        }
    }
}
