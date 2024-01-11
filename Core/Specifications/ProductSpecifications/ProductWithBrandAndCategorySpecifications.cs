using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.ProductSpecifications
{
    public class ProductWithBrandAndCategorySpecifications: BaseSpecification<Product>
    {
        public ProductWithBrandAndCategorySpecifications()
        {
            IncludesCriteria.Add(p => p.Brand);
            IncludesCriteria.Add(p => p.Category);
        }

        public ProductWithBrandAndCategorySpecifications(int id)
        {
            WhereCriteria = p => p.Id == id;
            IncludesCriteria.Add(p => p.Brand);
            IncludesCriteria.Add(p => p.Category);
        }
    }
}
