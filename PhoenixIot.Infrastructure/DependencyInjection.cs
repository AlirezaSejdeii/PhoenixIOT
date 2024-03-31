using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Infrastructure.Extension;
using PhoenixIot.Infrastructure.Seeder;
using PhoenixIot.Infrastructure.Services;

namespace PhoenixIot.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration["Database:ConnectionString"]));
        services.AddCustomAuthentication(configuration["JwtConfig:Secret"]!,configuration["JwtConfig:EncryptionKey"]!);
        // options
        services.Configure<JwtConfigDto>(configuration.GetSection("JwtConfig"));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ISeedUsers, SeedUsers>();
        return services;
    }
}