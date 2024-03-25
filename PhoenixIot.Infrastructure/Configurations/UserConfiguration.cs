using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Configurations;

public class UserConfiguration:BaseConfiguration<User> {
    protected override void ExtraConfigure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Username)
            .HasMaxLength(150)
            .HasColumnName("username")
            .IsRequired();

        builder.Property(x => x.Password)
            .HasMaxLength(150)
            .HasColumnName("password")
            .IsRequired();
    }
}