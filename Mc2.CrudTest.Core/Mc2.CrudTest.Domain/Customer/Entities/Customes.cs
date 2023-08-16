using Mc2.CrudTest.Domain.Common;
using System;

namespace Mc2.CrudTest.Domain.Customer.Entities
{
    public class Customer : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? BankAccountNumber { get; set; }
    }
}
