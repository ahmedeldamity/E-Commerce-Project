using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.ProductSpecifications
{
    public class ProductSpecificationParameters
    {
        public int? brandId { get; set; }
        public int? categoryId { get; set; }
        public string? sort { get; set; }
    }
}