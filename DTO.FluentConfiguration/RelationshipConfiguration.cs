using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Community.DTO;

namespace DTO.FluentConfiguration;

public sealed class RelationshipConfiguration : IEntityTypeConfiguration<Relationship>
{
    public void Configure(EntityTypeBuilder<Relationship> modelBuilder)
    {
        modelBuilder
            .HasKey(r => new { r.FromPersonId, r.ToPersonId });

        modelBuilder
            .Property(r => r.RelationshipType)
            .HasColumnType("Nvarchar")
            .IsRequired();

        modelBuilder
            .Property(r => r.CreateDate)
            .HasColumnType("DateTime")
            .HasDefaultValueSql("GetDate()");

        modelBuilder
            .Property(r => r.IsActive)
            .HasColumnType("Bit")
            .HasDefaultValue(true);

        modelBuilder
            .HasOne(r => r.FromPerson)
            .WithMany(r => r.RelationshipsFrom)
            .HasForeignKey(r => r.FromPersonId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .HasOne(r => r.ToPerson)
            .WithMany(r => r.RelationshipsTo)
            .HasForeignKey(r => r.ToPersonId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
