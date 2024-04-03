using Community.DBC;
using Community.IRepositories;
using Community.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Community.Api.Configuration;

public static class DependencyConfiguration
{
    public static void ConfigureDependency(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddDbContext<CommunityDBContext>(options => options.UseSqlServer(connectionString));
    }
}
