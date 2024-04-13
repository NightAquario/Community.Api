using Community.DBC;
using Community.IRepositories;
using Community.Repositories;
using Community.Services;
using Community.IServices;
using Microsoft.EntityFrameworkCore;

namespace Community.Api.Configuration;

public static class DependencyConfiguration
{
    public static void ConfigureDependency(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IPersonService, PersonService>();
        builder.Services.AddScoped<IRelationshipService, RelationshipService>();
        builder.Services.AddDbContext<CommunityDBContext>(options => options.UseSqlServer(connectionString));
    }
}
