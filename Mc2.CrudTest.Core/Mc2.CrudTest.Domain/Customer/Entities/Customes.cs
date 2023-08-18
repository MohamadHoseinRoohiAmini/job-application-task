using Mc2.CrudTest.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Domain.Customer.Entities
{
    public class Customer : BaseEntity
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
