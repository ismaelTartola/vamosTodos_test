
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Domain.Project;

public interface IProjectAggregateRootRepository
{
    Task<Maybe<ProjectAggregateRoot>> GetByIdAsync(Guid id
        , CancellationToken cancellationToken);
}
