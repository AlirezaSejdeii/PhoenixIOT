using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Configurations;

public class RoleConfiguration : BaseConfiguration<Role>
{
    protected override void ExtraConfigure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(150)
            .IsRequired();
        builder.HasMany(x => x.Users)
            .WithMany(x => x.Roles);
    }
}