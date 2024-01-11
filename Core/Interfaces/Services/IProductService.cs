using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<Product?> GetProductAsync(int id);
    }
}