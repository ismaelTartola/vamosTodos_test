
using Microsoft.EntityFrameworkCore;
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Contracts.Project;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Application.Project.Query.GetProjectsAllQuery
{
	public sealed class GetProjectsAllQueryHandler : IQueryHandler<GetProjectsAllQuery, GetProjectsResponse>
	{
		private readonly IDbContext _dbContext;

		public GetProjectsAllQueryHandler(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Maybe<GetProjectsResponse>> Handle(GetProjectsAllQuery request, CancellationToken cancellationToken)
		{
			List<ProjectDto> response = await _dbContext.Set<ProjectAggregateRoot>()
				.Select(project => new ProjectDto(project.Id, project.ProjectName.Value, project.ProjectDescription.Value))
				.ToListAsync(cancellationToken);

			return Maybe<GetProjectsResponse>.From(new GetProjectsResponse(response));
		}
	}
}
