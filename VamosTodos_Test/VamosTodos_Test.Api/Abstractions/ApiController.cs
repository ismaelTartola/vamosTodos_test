using VamosTodos_Test.Presentation.Abstractions.ApiResponces;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VamosTodos_Test.Presentation.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender _sender;

    protected readonly IMapper _mapper;

    protected ApiController(ISender sender, IMapper mapper = null!)
    {
        _sender = sender;
        _mapper = mapper;
    }

    protected IActionResult BadRequest(IResult problemDetail) => base.BadRequest(new ApiBadRequestResponse(problemDetail));

    protected new IActionResult Ok(object? value = default) => base.Ok(new ApiOkResponse(value));
    
    protected IActionResult NotFound(IResult problemDetail) => base.NotFound(new ApiNotFoundResponse(problemDetail));

    protected IActionResult MethodNotAllowed(IResult problemDetail) => base.StatusCode(405, new ApiNotFoundResponse(problemDetail));
}