using Community.DBC;
using Microsoft.EntityFrameworkCore;

namespace Community.Api.Configuration;

public static class DependencyConfiguration
{
    public static void ConfigureDependency(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<CommunityDBContext>(options => options.UseSqlServer(connectionString));
    }
}
