using Mc2.CrudTest.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CustomerDbContext _dbContext;
        public GenericRepository(CustomerDbContext customerDbContext)
        {
            _dbContext = customerDbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> Get(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task HardDelete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
