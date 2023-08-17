using MediatR;
using System;

namespace Mc2.CrudTest.Application.Commands.Requests
{
    public class UpdateCustomerCommand : IRequest<Unit> 
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? BankAccountNumber { get; set; }
    }
}
