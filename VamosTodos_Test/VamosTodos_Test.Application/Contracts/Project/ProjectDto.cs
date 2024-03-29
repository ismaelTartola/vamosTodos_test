namespace VamosTodos_Test.Application.Contracts.Project;

public sealed record ProjectDto(Guid Id,
    string ProjectName,
    string Description);