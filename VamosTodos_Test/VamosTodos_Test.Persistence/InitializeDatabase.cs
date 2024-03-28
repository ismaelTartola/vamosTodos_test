
using VamosTodos_Test.Domain.Project.ValueObjects;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.Domain.User.ValueObjects;

namespace VamosTodos_Test.Persistence;

public static class InitializeDatabase
{
    public static void Initialize(ApiDbContext context)
    {        
        if (context.Set<UserAggregateRoot>().Any())
        {
            return;   
        }

        var users = new UserAggregateRoot[]
        {
               UserAggregateRoot.Create(FirstName.Create("UserFirstName1").Value
           , LastName.Create("UserLastName1").Value),
           UserAggregateRoot.Create(FirstName.Create("UserFirstName2").Value
           , LastName.Create("UserLastName2").Value),
           UserAggregateRoot.Create(FirstName.Create("UserFirstName3").Value
           , LastName.Create("UserLastName3").Value),
           UserAggregateRoot.Create(FirstName.Create("UserFirstName4").Value
           , LastName.Create("UserLastName4").Value),
           UserAggregateRoot.Create(FirstName.Create("UserFirstName5").Value
           , LastName.Create("UserLastName5").Value)
        };

        context.Set<UserAggregateRoot>().AddRange(users);

        context.SaveChanges();

        if (context.Set<ProjectAggregateRoot>().Any())
        {
            return;
        }

        var projects = new ProjectAggregateRoot[]
        {
            ProjectAggregateRoot.Create(ProjectName.Create("ProjectName1").Value,
               ProjectDescription.Create("ProjectDesc1").Value),
           ProjectAggregateRoot.Create(ProjectName.Create("ProjectName2").Value,
               ProjectDescription.Create("ProjectDesc2").Value),
           ProjectAggregateRoot.Create(ProjectName.Create("ProjectName3").Value,
               ProjectDescription.Create("ProjectDesc3").Value),
           ProjectAggregateRoot.Create(ProjectName.Create("ProjectName4").Value,
               ProjectDescription.Create("ProjectDesc4").Value),
           ProjectAggregateRoot.Create(ProjectName.Create("ProjectName5").Value,
               ProjectDescription.Create("ProjectDesc5").Value)
        };

        context.Set<ProjectAggregateRoot>().AddRange(projects);

        context.SaveChanges();
    }
}
