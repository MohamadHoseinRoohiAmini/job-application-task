using System;

namespace Mc2.CrudTest.Domain.Customer.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(Guid customerId) : base($"Id : {customerId}")
        {

        }
    }
}
