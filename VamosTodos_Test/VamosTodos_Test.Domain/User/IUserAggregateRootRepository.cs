
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Domain.User;

public interface IUserAggregateRootRepository
{
    Task<Maybe<UserAggregateRoot>> GetByIdAsync(Guid id
        , CancellationToken cancellationToken);
}
