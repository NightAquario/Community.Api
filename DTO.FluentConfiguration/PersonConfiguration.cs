using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Community.DTO;

namespace DTO.FluentConfiguration;

public sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> modelBuilder)
    {
        modelBuilder
            .Property(p => p.FirstName)
            .HasColumnType("Nvarchar(50)")
            .HasAnnotation("MinLength", 2)
            .IsRequired();

        modelBuilder
            .Property(p => p.LastName)
            .HasColumnType("Nvarchar(50)")
            .HasAnnotation("MinLength", 2)
            .IsRequired();

        modelBuilder
            .Property(p => p.Gender)
            .HasConversion(
                    ci => ci.ToString(),
                    ci => (Gender)Enum.Parse(typeof(Gender), ci)
                )
            .IsRequired();

        modelBuilder
            .Property(p => p.PersonalCode)
            .HasColumnType("Nvarchar")
            .IsRequired();

        modelBuilder
            .Property(p => p.PersonalNumber)
            .HasColumnType("Nvarchar(11)")
            .IsRequired();

        modelBuilder
            .Property(p => p.BirthDate)
            .HasColumnType("Date")
            .IsRequired();

        modelBuilder
            .Property(p => p.CreateDate)
            .HasColumnType("DateTime")
            .HasDefaultValueSql("GetDate()");

        modelBuilder
            .Property(p => p.IsActive)
            .HasColumnType("Bit")
            .HasDefaultValue(true);

        modelBuilder
            .HasMany(p => p.ContactDetails)
            .WithOne(ci => ci.Person);

    }
}
