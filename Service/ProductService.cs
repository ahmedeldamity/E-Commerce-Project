using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Specifications;
using Core.Specifications.ProductSpecifications;

namespace Service
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var spec = new ProductWithBrandAndCategorySpecifications();
            var products = await _unitOfWork.Repository<Product>().GetAllWithSpecAsync(spec);
            return products;
        }
        public async Task<Product?> GetProductAsync(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product = await _unitOfWork.Repository<Product>().GetByIdWithSpecAsync(spec);
            return product;
        }        
    }
}