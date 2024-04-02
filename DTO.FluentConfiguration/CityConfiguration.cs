using Community.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTO.FluentConfiguration;

public sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> modelBuilder)
    {
        modelBuilder
            .Property(c => c.Name)
            .HasColumnType("Nvarchar(50)")
            .IsRequired();

        modelBuilder
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder
            .Property(c => c.CreateDate)
            .HasColumnType("Datetime")
            .HasDefaultValueSql("GetDate()");

        modelBuilder
            .Property(c => c.IsActive)
            .HasColumnType("Bit")
            .HasDefaultValue(true);

        modelBuilder
            .HasMany(c => c.People)
            .WithOne(c => c.City)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
