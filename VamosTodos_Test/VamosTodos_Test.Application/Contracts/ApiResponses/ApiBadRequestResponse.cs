﻿namespace VamosTodos_Test.Application.Abstractions.ApiResponces;

public class ApiBadRequestResponse : ApiResponse

{
    public ApiBadRequestResponse(object result = default!
        , string message = default!
        , string customStatusCode = default!)
        : base(400, result, message, customStatusCode)
    { }
}