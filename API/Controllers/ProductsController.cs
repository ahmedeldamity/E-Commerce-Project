using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Specifications.ProductSpecifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecificationParameters specParams)
        {
            var products = await _productService.GetProductsAsync(specParams);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);
            return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
        }
    }
}