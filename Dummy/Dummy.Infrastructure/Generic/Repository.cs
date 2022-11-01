
using Dummy.Domain.IGeneric;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dummy.Infrastructure.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitContext _unitcontext;

        public Repository(IUnitContext unitContext)
        {
            _unitcontext = unitContext;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _unitcontext.Context.Set<T>().ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _unitcontext.Context.Set<T>().AddAsync(entity);
            _unitcontext.Commit();
            return entity;
        }

    }
}
