using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetProductsAsync(int? brandId, int? categoryId);
        Task<Product?> GetProductAsync(int id);
    }
}