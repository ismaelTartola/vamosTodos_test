
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Contracts.Project;

namespace VamosTodos_Test.Application.Project.Query.GetProjectsAllQuery;


public sealed record GetProjectsAllQuery : IQuery<GetProjectsResponse>
{ }
