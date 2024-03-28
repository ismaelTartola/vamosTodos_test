
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.Project.ValueObjects;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.Domain.User.ValueObjects;
using VamosTodos_Test.SharedKernel.ResultObject;

namespace VamosTodos_Test.Persistence.Configurations;

internal sealed class ProjectConfiguration : IEntityTypeConfiguration<ProjectAggregateRoot>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<ProjectAggregateRoot> builder)
    {
        builder.HasKey(proj => proj.Id);

        builder.OwnsOne(proj => proj.ProjectName, projNameBuilder =>
        {
            projNameBuilder.WithOwner();

            projNameBuilder.Property(projName => projName.Value)
                .HasColumnName(nameof(ProjectAggregateRoot.ProjectName))
                .HasMaxLength(ProjectName.MaxLength)
                .IsRequired();
        });

        builder.OwnsOne(proj => proj.ProjectDescription, projDescBuilder =>
        {
            projDescBuilder.WithOwner();

            projDescBuilder.Property(projName => projName.Value)
                .HasColumnName(nameof(ProjectAggregateRoot.ProjectDescription))
                .HasMaxLength(ProjectDescription.MaxLength)
                .IsRequired();
        });

        builder.HasMany(proj => proj.Bugs)
                .WithOne()
                .HasForeignKey(bug => bug.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);       

    }
}