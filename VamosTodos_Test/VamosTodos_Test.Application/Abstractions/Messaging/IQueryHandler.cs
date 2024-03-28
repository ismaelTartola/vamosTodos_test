
using MediatR;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
: IRequestHandler<TQuery, Maybe<TResponse>>
where TQuery : IQuery<TResponse>
where TResponse : class
{
}