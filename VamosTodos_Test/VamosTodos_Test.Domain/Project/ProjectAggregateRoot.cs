
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.SharedKernel.Utility;
using VamosTodos_Test.Domain.Project.ValueObjects;
using VamosTodos_Test.Domain.Bug;

namespace VamosTodos_Test.Domain.Project;

public sealed class ProjectAggregateRoot : AggregateRoot
{
    private readonly HashSet<BugEntity> _bugs = new();

    private ProjectAggregateRoot(ProjectName projectName,
                 ProjectDescription projectDesc)
        : base(Guid.NewGuid())
    {
        Ensure.NotEmpty(projectName, "The project name is required.", nameof(projectName));
        Ensure.NotEmpty(projectDesc, "The project description is required.", nameof(projectDesc));

        ProjectName = projectName;
        ProjectDescription = projectDesc;
    }

    private ProjectAggregateRoot()
    { }

    public ProjectName ProjectName { get; private set; } = null!;

    public ProjectDescription ProjectDescription { get; private set; } = null!;

    public IReadOnlyCollection<BugEntity> Bugs
        => _bugs.ToList();

    public static ProjectAggregateRoot Create(ProjectName projectName,
        ProjectDescription projectDesc)
    {
        var project = new ProjectAggregateRoot(projectName, projectDesc);

        return project;
    }
}
