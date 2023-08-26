using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Application.Commands.Requests
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? BankAccountNumber { get; set; }
    }
}
