
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VamosTodos_Test.Api.Presentation.Extensions;
using VamosTodos_Test.Application.Bug.Commands.CreateBugCommand;
using VamosTodos_Test.Application.Bug.Querys.GetBugsBy;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Domain.Errors;
using VamosTodos_Test.Presentation.Abstractions;
using VamosTodos_Test.SharedKernel.MaybeObject;
using VamosTodos_Test.SharedKernel.ResultObject;
using VamosTodos_Test.Application.Bug.Querys.GetBugsAll;
using VamosTodos_Test.Application.Abstractions.ApiResponces;
using VamosTodos_Test.Application.Contracts.ApiResponces;

namespace VamosTodos_Test.Api.Controllers;

[Route("bug")]
public class BugController : ApiController
{
    public BugController(ISender sender, IMapper mapper) : base(sender, mapper)
    {
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(GetBugsResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiBadRequestResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiMethodNotAllowedResponse), (int)HttpStatusCode.MethodNotAllowed)]
    public async Task<IActionResult> CreateBug([FromQuery] CreateBugRequest request
        , CancellationToken cancellationToken) 
    {
        return await Result.Create(_mapper.Map<CreateBugCommand>(request))
            .Bind(command => _sender.Send(command, cancellationToken))
            .Match(
              Ok,
              result => NotFound(result.ToProblemDetails())
        );
    }

    [ProducesResponseType(typeof(BugDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiBadRequestResponse), (int)HttpStatusCode.BadRequest)]
	[ProducesResponseType(typeof(ApiNotFoundResponse), (int)HttpStatusCode.NotFound)]
	[ProducesResponseType(typeof(ApiMethodNotAllowedResponse), (int)HttpStatusCode.MethodNotAllowed)]
    public async Task<IActionResult> GetBugsBy([FromQuery] GetBugByRequest request)
    {
        if (request.InvalidRequest)
        {
            return BadRequest(Result.Failure(DomainErrors.General.ValidationError));
        }

        if (Request.Method != "GET")
        {
            return MethodNotAllowed(Result.Failure(DomainErrors.General.InvalidMethodError)
                .ToProblemDetails());
        }

        return await Maybe<GetBugsByQuery>
                .From(_mapper.Map<GetBugsByQuery>(request))
                .Bind(query => _sender.Send(query))
                .Match(Ok, NotFound);
    }

	[HttpGet("all")]
	[ProducesResponseType(typeof(GetBugsResponse), (int)HttpStatusCode.OK)]
	[ProducesResponseType(typeof(ApiNotFoundResponse), (int)HttpStatusCode.NotFound)]
	public async Task<IActionResult> GetBugsAll()
	{
		return await Maybe<GetBugsAllQuery>
				.From(new GetBugsAllQuery())
				.Bind(query => _sender.Send(query))
				.Match(Ok, NotFound);
	}
}
