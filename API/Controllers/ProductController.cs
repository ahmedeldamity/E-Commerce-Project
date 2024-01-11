using Core.Entities;
using Core.Interfaces.Services;
using Core.Specifications.ProductSpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProduct(int id)
        {
            var products = await _productService.GetProductAsync(id);
            return Ok(products);
        }
    }
}