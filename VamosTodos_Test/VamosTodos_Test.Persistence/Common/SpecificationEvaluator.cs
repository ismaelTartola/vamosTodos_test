
using VamosTodos_Test.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace VamosTodos_Test.Persistence.Common;

internal static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> inputQueryable
        , Specification<TEntity> specification)
        where TEntity : Entity
    {
        IQueryable<TEntity> queryable = inputQueryable;

        if(specification.Criteria is not null)
            queryable = queryable.Where(specification.Criteria);

        specification.IncludeEspressions.Aggregate(
            queryable,
            (current, includeExpression) =>
           queryable = current.Include(includeExpression));

        if(specification.OrderByExpression is not null)
           queryable = queryable.OrderBy(specification.OrderByExpression);

        if (specification.OrderByDescendingExpression is not null)
            queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);

        if(specification.IsSplitQuery)
            queryable = queryable.AsSplitQuery();

        return queryable;
    }
}
