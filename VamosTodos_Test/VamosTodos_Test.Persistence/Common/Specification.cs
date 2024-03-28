
using VamosTodos_Test.Domain.Primitives;
using System.Linq.Expressions;

namespace VamosTodos_Test.Persistence.Common;

/// <summary>
/// Represents the abstract base class for specifications.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
internal abstract class Specification<TEntity>
    where TEntity : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Specification{TEntity}"/> class.
    /// </summary>
    /// <param name="criteria">The specification base criteria.</param>
    protected Specification(Expression<Func<TEntity, bool>> criteria)
        => Criteria = criteria;

    public bool IsSplitQuery { get; protected set; }

    /// <summary>
    /// Gets the specification criteria.
    /// </summary>
    public Expression<Func<TEntity, bool>>? Criteria { get; }

    /// <summary>
    /// Gets the specification include expressions.
    /// </summary>
    public List<Expression<Func<TEntity, object>>> IncludeEspressions { get; } = new();

    /// <summary>
    /// Gets the specification order by expressions.
    /// </summary>
    public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }

    /// <summary>
    /// Gets the specification order by descending expressions.
    /// </summary>
    public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

    /// <summary>
    /// Add a include expression to the specification.
    /// </summary>
    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
        IncludeEspressions.Add(includeExpression);

    /// <summary>
    /// Set the specification order by espression.
    /// </summary>
    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) =>
       OrderByExpression = orderByExpression;

    /// <summary>
    /// Set the specification order by descending espression.
    /// </summary>
    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression) =>
       OrderByDescendingExpression = orderByDescendingExpression;   
}