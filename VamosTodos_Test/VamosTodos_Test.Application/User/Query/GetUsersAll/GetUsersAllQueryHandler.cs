
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Bug.Querys.GetBugsAll;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Application.Contracts.User;
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Application.User.Query.GetUsersAll;

public sealed class GetUsersAllQueryHandler : IQueryHandler<GetUsersAllQuery, GetUsersResponse>
{
	private readonly IDbContext _dbContext;

	public GetUsersAllQueryHandler(IDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Maybe<GetUsersResponse>> Handle(GetUsersAllQuery request, CancellationToken cancellationToken)
	{
		List<UserDto> response = await _dbContext.Set<UserAggregateRoot>()
			.Select(user => new UserDto(user.Id, user.FirstName.Value, user.LastName.Value))
			.ToListAsync(cancellationToken);

		return Maybe<GetUsersResponse>.From(new GetUsersResponse(response));
	}
}
