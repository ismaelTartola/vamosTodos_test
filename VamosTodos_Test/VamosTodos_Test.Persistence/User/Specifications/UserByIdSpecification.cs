
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.Persistence.Common;

namespace VamosTodos_Test.Persistence.User.Specifications;

internal sealed class UserByIdSpecification : Specification<UserAggregateRoot>
{
    public UserByIdSpecification(Guid id)
            : base(user => user.Id == id)
    { }
}