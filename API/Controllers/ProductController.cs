﻿using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Specifications.ProductSpecifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecificationParameters specParams)
        {
            var products = await _productService.GetProductsAsync(specParams);

            var productsDto = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            var productsCount = await _productService.GetProductCount(specParams);

            return Ok(new PaginationToReturn<ProductToReturnDto>(specParams.PageIndex, specParams.PageSize, productsCount, productsDto));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);

            if(product is null)
                return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _productService.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetCategories()
        {
            var categories = await _productService.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}