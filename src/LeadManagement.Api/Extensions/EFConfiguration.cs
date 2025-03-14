using LeadManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Api.Extensions;

public static class EFConfiguration
{
    public static IServiceCollection ConfigureEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure the DbContext with SQL Server
        services.AddDbContext<LeadContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static IServiceCollection ConfigureEntityFrameworkInMemory(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure the DbContext memory
        services.AddDbContext<LeadContext>(options =>
           options.UseInMemoryDatabase("InMemoryDb"));

        return services;
    }
}
