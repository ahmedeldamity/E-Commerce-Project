using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        
        public async Task<IReadOnlyList<T>> GetAllAsync() => await _storeContext.Set<T>().ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _storeContext.Set<T>().FindAsync(id);
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await SpecificationsEvaluator<T>.GetQuery(_storeContext.Set<T>(), spec).ToListAsync();
        }
        public async Task<int> GetCountAsync(ISpecifications<T> spec)
        {
            return await SpecificationsEvaluator<T>.GetQuery(_storeContext.Set<T>(), spec).CountAsync();
        }
        public async Task<T?> GetByIdWithSpecAsync(ISpecifications<T> spec)
        {
            return await SpecificationsEvaluator<T>.GetQuery(_storeContext.Set<T>(), spec).FirstOrDefaultAsync();
        }
    }
}