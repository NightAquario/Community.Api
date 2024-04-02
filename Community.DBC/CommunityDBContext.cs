using Community.DTO;
using DTO.FluentConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Community.DBC;

public class CommunityDBContext : DbContext
{
    public CommunityDBContext(DbContextOptions<CommunityDBContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new ContactInfoConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new RelationshipConfiguration());
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<ContactInfo> ContactInfos { get; set; }
    public DbSet<Relationship> Relationships { get; set; }

}
