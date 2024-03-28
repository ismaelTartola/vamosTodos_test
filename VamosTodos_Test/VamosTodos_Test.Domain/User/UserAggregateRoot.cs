
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.Domain.User.ValueObjects;
using VamosTodos_Test.SharedKernel.Utility;

namespace VamosTodos_Test.Domain.User;

public sealed class UserAggregateRoot : AggregateRoot
{
    private readonly HashSet<BugEntity> _bugs = new();

    private UserAggregateRoot(FirstName firstName,
                 LastName lastName)
        : base(Guid.NewGuid())
    {
        Ensure.NotEmpty(firstName, "The first name is required.", nameof(firstName));
        Ensure.NotEmpty(lastName, "The last name is required.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    private UserAggregateRoot()
    { }

    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public string FullName => $"{FirstName} {LastName}";

    public IReadOnlyCollection<BugEntity> Bugs
        => _bugs.ToList();

    public static UserAggregateRoot Create(FirstName firstname,
        LastName lastName)
    {
        var user = new UserAggregateRoot(firstname, lastName);

        return user;
    }
}
