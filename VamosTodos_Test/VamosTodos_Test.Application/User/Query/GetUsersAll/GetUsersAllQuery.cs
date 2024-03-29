
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.Application.User.Query.GetUsersAll;

public sealed record GetUsersAllQuery : IQuery<GetUsersResponse>
{ }
