using Microsoft.Extensions.DependencyInjection;
using PhoenixIot.Infrastructure.Seeder;
using PhoenixIot.Infrastructure.Services;

namespace PhoenixIot.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<UserService>();
        services.AddSingleton<SeedUsers>();
        return services;
    }
}