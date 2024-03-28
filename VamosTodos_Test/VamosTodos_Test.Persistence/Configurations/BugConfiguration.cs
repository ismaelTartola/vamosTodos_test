
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Domain.Bug.ValueObjects;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.Domain.User.ValueObjects;

namespace VamosTodos_Test.Persistence.Configurations;

internal sealed class BugConfiguration : IEntityTypeConfiguration<BugEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<BugEntity> builder)
    {
        builder.HasKey(bug => bug.Id);

        builder.OwnsOne(bug => bug.BugDescription, descriptionBuilder =>
        {
            descriptionBuilder.WithOwner();

            descriptionBuilder.Property(description => description.Value)
                .HasColumnName(nameof(BugEntity.BugDescription))
                .HasMaxLength(BugDescription.MaxLength)
                .IsRequired();
        });

        builder.OwnsOne(bug => bug.BugCreationDate, expirationDateBuilder =>
        {
            expirationDateBuilder.WithOwner();

            expirationDateBuilder.Property(expirationDate => expirationDate.Value)
                .HasColumnName(nameof(BugEntity.BugCreationDate))
                .IsRequired();
        });

        builder.Property(bug => bug.UserId).IsRequired();

        builder.Property(bug => bug.ProjectId).IsRequired();
    }
}