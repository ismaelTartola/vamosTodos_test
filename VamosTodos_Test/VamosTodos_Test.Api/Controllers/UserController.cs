using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VamosTodos_Test.Api.Presentation.Extensions;
using VamosTodos_Test.Application.Abstractions.ApiResponces;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Application.User.Query.GetUsersAll;
using VamosTodos_Test.Presentation.Abstractions;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Api.Controllers;

[Route("user")]
public class UserController : ApiController
{
	public UserController(ISender sender, IMapper mapper) 
		: base(sender, mapper)
	{
	}

	[HttpGet("all")]
	[ProducesResponseType(typeof(GetUsersResponse), (int)HttpStatusCode.OK)]
	[ProducesResponseType(typeof(ApiNotFoundResponse), (int)HttpStatusCode.NotFound)]
	public async Task<IActionResult> GetUsersAll()
	{
		return await Maybe<GetUsersAllQuery>
				.From(new GetUsersAllQuery())
				.Bind(query => _sender.Send(query))
				.Match(Ok, NotFound);
	}

}
