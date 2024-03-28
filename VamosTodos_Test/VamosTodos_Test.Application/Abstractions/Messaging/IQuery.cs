
using MediatR;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Application.Abstractions.Messaging;

public interface IQuery<TResponse>
    : IRequest<Maybe<TResponse>>
    , ILoggedRequest
    where TResponse : class
{ }