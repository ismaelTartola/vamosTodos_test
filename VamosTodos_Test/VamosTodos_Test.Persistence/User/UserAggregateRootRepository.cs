
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.Persistence.Common;
using VamosTodos_Test.Persistence.User.Specifications;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Persistence.User;

internal sealed class UserAggregateRootRepository : GenericRepository<UserAggregateRoot>, IUserAggregateRootRepository
{
    public UserAggregateRootRepository(IDbContext dbContext)
        : base(dbContext)
    { }

    /// <inheritdoc />
    public async Task<Maybe<UserAggregateRoot>> GetByIdAsync(Guid id
        , CancellationToken cancellationToken = default)
        => await FirstOrDefaultAsync(new UserByIdSpecification(id)
            , cancellationToken);
}