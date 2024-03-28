
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Persistence.Common;

namespace VamosTodos_Test.Persistence.Bug;

internal sealed class BugEntityRepository : GenericRepository<BugEntity>, IBugEntityRepository
{
    public BugEntityRepository(IDbContext dbContext) 
        : base(dbContext)
    {
    }


}
