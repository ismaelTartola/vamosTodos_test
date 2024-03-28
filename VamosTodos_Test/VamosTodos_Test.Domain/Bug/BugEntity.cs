
using VamosTodos_Test.Domain.Bug.ValueObjects;
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.Domain.User.ValueObjects;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.SharedKernel.Utility;

namespace VamosTodos_Test.Domain.Bug;

public class BugEntity : Entity
{
    private BugEntity(BugDescription bugDescription,
                 BugCreationDate bugCreationDate,
                 Guid userId,
                 Guid projectId)
        : base(Guid.NewGuid())
    {
        Ensure.NotEmpty(bugDescription, "The bug description is required.", nameof(bugDescription));
        Ensure.NotNull(bugCreationDate, "The bug creation date is required.", nameof(bugCreationDate));

        BugDescription = bugDescription;
        BugCreationDate = bugCreationDate;
        UserId = userId;
        ProjectId = projectId;
    }

    private BugEntity()
    { }

    public BugDescription BugDescription { get; private set; } = null!;
    public BugCreationDate BugCreationDate { get; private set;} = null!;
    public Guid UserId { get; private set; }
    public Guid ProjectId { get; private set; }

    public static BugEntity Create(BugDescription bugDescription,
                 BugCreationDate bugCreationDate,
                 Guid userId,
                 Guid projectId)
    {
        var newBug = new BugEntity(bugDescription, 
            bugCreationDate, userId, projectId);

        return newBug;
    }
}
