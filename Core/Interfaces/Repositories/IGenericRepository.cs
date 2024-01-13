using Core.Entities;
using Core.Interfaces.Specifications;

namespace Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec);
        Task<int> GetCountAsync(ISpecifications<T> spec);
        Task<T?> GetByIdWithSpecAsync(ISpecifications<T> spec);
    }
}