using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> Get(Guid id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task HardDelete(T entity);
    }
}
