
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.Domain.User.ValueObjects;

namespace VamosTodos_Test.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserAggregateRoot>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserAggregateRoot> builder)
    {
        builder.HasKey(user => user.Id);

        builder.OwnsOne(user => user.FirstName, firstNameBuilder =>
        {
            firstNameBuilder.WithOwner();

            firstNameBuilder.Property(firstName => firstName.Value)
                .HasColumnName(nameof(UserAggregateRoot.FirstName))
                .HasMaxLength(FirstName.MaxLength)
                .IsRequired();
        });

        builder.OwnsOne(user => user.LastName, lastNameBuilder =>
        {
            lastNameBuilder.WithOwner();

            lastNameBuilder.Property(lastName => lastName.Value)
                .HasColumnName(nameof(UserAggregateRoot.LastName))
                .HasMaxLength(LastName.MaxLength)
                .IsRequired();
        });

        builder.HasMany(user => user.Bugs)
                .WithOne()
                .HasForeignKey(bug => bug.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        builder.Ignore(user => user.FullName);        
    }
}