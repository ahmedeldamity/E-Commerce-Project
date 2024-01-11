using Core.Entities;
using Core.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SpecificationsEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
        {
            var query = inputQuery;

            if (spec.WhereCriteria != null)
                query = query.Where(spec.WhereCriteria);

            query = spec.IncludesCriteria.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            return query;
        }
    }
}