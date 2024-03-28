
using VamosTodos_Test.SharedKernel.ResultObject;
using MediatR;

namespace VamosTodos_Test.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, ICommandBase
    , ILoggedRequest
{ }

public interface ICommand<TResponse>
    : IRequest<Result<TResponse>>, ICommandBase
    , ILoggedRequest
    where TResponse : class
{ }

public interface ICommandBase
{ }