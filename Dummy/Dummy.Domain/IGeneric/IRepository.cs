using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dummy.Domain.IGeneric
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<IEnumerable<T>> GetAsync();
    }
}
