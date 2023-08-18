using AutoMapper;
using com.google.i18n.phonenumbers;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Application.Contracts.Validators;
using Mc2.CrudTest.Domain.Customer.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static com.google.i18n.phonenumbers.PhoneNumberUtil;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly PhoneNumberUtil _phoneNumberUtil;


        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, PhoneNumberUtil phoneNumberUtil)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _phoneNumberUtil = phoneNumberUtil;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerDtoValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new CustomerDataNotValidateForUpdateException();

            try
            {
                var number = _phoneNumberUtil.parse(request.PhoneNumber, "US"); // can be any country
                if (!_phoneNumberUtil.isValidNumber(number) || _phoneNumberUtil.getNumberType(number) != PhoneNumberType.MOBILE)
                {
                    throw new PhoneNumberNotValidException();
                }
            }
            catch (NumberParseException)
            {
                throw new PhoneNumberNotValidException();
            }

            var customer = await _customerRepository.Get(request.Id ?? Guid.NewGuid());

            _mapper.Map(request, customer);

            await _customerRepository.Update(customer);

            return Unit.Value;
        }
    }
}
