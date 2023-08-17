using FluentValidation;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Domain.Customer.Dtoes;

namespace Mc2.CrudTest.Application.Contracts.Validators
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is notValid");
            RuleFor(x => x.BankAccountNumber).NotEmpty().Matches(@"\d{10}").WithMessage("BankAccountNumber is not right");
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
