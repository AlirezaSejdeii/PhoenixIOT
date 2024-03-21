using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoenixIot.Application.Extension;

namespace PhoenixIot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddCustomAuthentication(configuration["JwtConfig:Secret"]!,configuration["JwtConfig:EncryptionKey"]!);
        return services;
    }
}