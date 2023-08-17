using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Domain.Customer.Entities;

namespace Mc2.CrudTest.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;
        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
