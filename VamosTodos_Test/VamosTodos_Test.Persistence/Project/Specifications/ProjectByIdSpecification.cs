
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Persistence.Common;

namespace VamosTodos_Test.Persistence.Project.Specifications;

internal sealed class ProjectByIdSpecification : Specification<ProjectAggregateRoot>
{
    public ProjectByIdSpecification(Guid id)
            : base(project => project.Id == id)
    { }
}