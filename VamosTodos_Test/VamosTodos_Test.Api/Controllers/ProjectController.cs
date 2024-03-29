
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VamosTodos_Test.Api.Presentation.Extensions;
using VamosTodos_Test.Application.Abstractions.ApiResponces;
using VamosTodos_Test.Application.Contracts.Project;
using VamosTodos_Test.Application.Project.Query.GetProjectsAllQuery;
using VamosTodos_Test.Presentation.Abstractions;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Api.Controllers;

[Route("project")]
public class ProjectController : ApiController
{
	public ProjectController(ISender sender, IMapper mapper)
		: base(sender, mapper)
	{
	}

	[HttpGet("all")]
	[ProducesResponseType(typeof(GetProjectsResponse), (int)HttpStatusCode.OK)]
	[ProducesResponseType(typeof(ApiNotFoundResponse), (int)HttpStatusCode.NotFound)]
	public async Task<IActionResult> GetProjectsAll()
	{
		return await Maybe<GetProjectsAllQuery>
				.From(new GetProjectsAllQuery())
				.Bind(query => _sender.Send(query))
				.Match(Ok, NotFound);
	}
}
