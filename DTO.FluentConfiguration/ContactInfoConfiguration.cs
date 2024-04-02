using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Community.DTO;

namespace DTO.FluentConfiguration;

public sealed class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
{
    public void Configure(EntityTypeBuilder<ContactInfo> modelBuilder)
    {
        modelBuilder
            .Property(ci => ci.Value)
            .HasColumnType("Nvarchar(50)")
            .IsRequired()
            .HasAnnotation("MinLength", 4);

        modelBuilder
            .Property(ci => ci.ContactType)
            .HasConversion(
                    ci => ci.ToString(),
                    ci => (ContactType)Enum.Parse(typeof(ContactType), ci)
                )
            .IsRequired();

        modelBuilder
            .Property(ci => ci.ContactCategory)
            .HasConversion(
                    ci => ci.ToString(),
                    ci => (ContactCategory)Enum.Parse(typeof(ContactCategory), ci)
                )
            .IsRequired();

        modelBuilder
            .Property(ci => ci.CreateDate)
            .HasColumnType("DateTime")
            .HasDefaultValueSql("GetDate()");

        modelBuilder
            .Property(ci => ci.IsActive)
            .HasColumnType("Bit")
            .HasDefaultValue(true);

        modelBuilder
            .HasOne(ci => ci.Person)
            .WithMany(p => p.ContactDetails);

    }
}
