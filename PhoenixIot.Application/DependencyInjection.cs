using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoenixIot.Application.Extension;
using PhoenixIot.Extension.Models;

namespace PhoenixIot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddCustomAuthentication(configuration.GetValue<JwtConfig>("JwtConfig")!);
        return services;
    }
}