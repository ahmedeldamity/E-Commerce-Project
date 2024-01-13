using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.ProductSpecifications
{
    public class ProductCountSpecification: BaseSpecification<Product>
    {
        public ProductCountSpecification(ProductSpecificationParameters specParams)
        {
            WhereCriteria =
               p => (string.IsNullOrEmpty(specParams.search) || p.Name.ToLower().Contains(specParams.search.ToLower())) &&
               (!specParams.brandId.HasValue || p.BrandId == specParams.brandId.Value) &&
               (!specParams.categoryId.HasValue || p.CategoryId == specParams.categoryId.Value);
        }
    }
}