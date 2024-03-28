
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.Persistence.Common;
using VamosTodos_Test.Persistence.Project.Specifications;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Persistence.Project;

internal sealed class ProjectAggregateRootRepository : GenericRepository<ProjectAggregateRoot>, IProjectAggregateRootRepository
{
    public ProjectAggregateRootRepository(IDbContext dbContext)
        : base(dbContext)
    { }

    /// <inheritdoc />
    public async Task<Maybe<ProjectAggregateRoot>> GetByIdAsync(Guid id
        , CancellationToken cancellationToken = default)
        => await FirstOrDefaultAsync(new ProjectByIdSpecification(id)
            , cancellationToken);
}