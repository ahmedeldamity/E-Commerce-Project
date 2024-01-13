using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Specifications;
using Core.Specifications.ProductSpecifications;

namespace Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecificationParameters specParams);
        Task<int> GetProductCount(ProductSpecificationParameters specParams);
        Task<Product?> GetProductAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetBrandsAsync();
        Task<IReadOnlyList<ProductCategory>> GetCategoriesAsync();
    }
}