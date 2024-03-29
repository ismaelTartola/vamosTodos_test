
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.Application.Bug.Querys.GetBugsAll;


public sealed record GetBugsAllQuery : IQuery<GetBugsResponse>
{ }
