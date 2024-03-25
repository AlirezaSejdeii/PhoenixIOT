using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoenixIot.Application.Services;
using PhoenixIot.Infrastructure.Seeder;
using PhoenixIot.Infrastructure.Services;

namespace PhoenixIot.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration["Database:ConnectionString"]));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISeedUsers, SeedUsers>();
        return services;
    }
}