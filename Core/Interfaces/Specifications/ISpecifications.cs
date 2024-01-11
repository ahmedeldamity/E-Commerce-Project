using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Interfaces.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> WhereCriteria { get; set; } 

        public List<Expression<Func<T, object>>> IncludesCriteria { get; set; }
        
    }
}