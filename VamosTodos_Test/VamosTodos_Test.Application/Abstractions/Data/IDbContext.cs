
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.SharedKernel.MaybeObject;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace VamosTodos_Test.Application.Abstractions.Data;

public interface IDbContext
{
    
    DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity;

     Task<Maybe<TEntity>> GetBydIdAsync<TEntity>(Guid id)
        where TEntity : Entity;

     void Insert<TEntity>(TEntity entity)
        where TEntity : Entity;

    void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities)
        where TEntity : Entity;

    void Remove<TEntity>(TEntity entity)
        where TEntity : Entity;

    Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default);
}