using FluentValidation;
using Mc2.CrudTest.Domain.Customer.Dtoes;

namespace Mc2.CrudTest.Domain.Customer.Validator
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            
        }
    }
}
