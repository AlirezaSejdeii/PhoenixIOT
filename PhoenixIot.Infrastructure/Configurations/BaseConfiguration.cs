using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Configurations;

public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnOrder(1);
        builder.HasKey(x => x.Id);

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");

        ExtraConfigure(builder);
    }

    protected abstract void ExtraConfigure(EntityTypeBuilder<T> builder);
}