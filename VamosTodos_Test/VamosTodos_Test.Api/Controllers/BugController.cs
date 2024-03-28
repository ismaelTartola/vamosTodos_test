
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VamosTodos_Test.Api.Abstractions.ApiResponces;
using VamosTodos_Test.Api.Presentation.Extensions;
using VamosTodos_Test.Application.Bug.Commands.CreateBugCommand;
using VamosTodos_Test.Application.Bug.Querys.GetBugs;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Domain.Errors;
using VamosTodos_Test.Presentation.Abstractions;
using VamosTodos_Test.Presentation.Abstractions.ApiResponces;
using VamosTodos_Test.SharedKernel.MaybeObject;
using VamosTodos_Test.SharedKernel.ResultObject;

namespace VamosTodos_Test.Api.Controllers;

[Route("bug")]
public class BugController : ApiController
{
    public BugController(ISender sender, IMapper mapper) : base(sender, mapper)
    {
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(ApiOkResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiBadRequestResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(MethodNotAllowedresponse), (int)HttpStatusCode.MethodNotAllowed)]
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

    [ProducesResponseType(typeof(ApiOkResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiBadRequestResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(MethodNotAllowedresponse), (int)HttpStatusCode.MethodNotAllowed)]
    public async Task<IActionResult> GetBugs([FromQuery] GetBugRequest request)
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

        return await Maybe<GetBugsQuery>
                .From(_mapper.Map<GetBugsQuery>(request))
                .Bind(query => _sender.Send(query))
                .Match(Ok, NotFound);
    }
}
