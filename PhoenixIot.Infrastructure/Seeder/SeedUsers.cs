using Microsoft.Extensions.Logging;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Seeder;

public class SeedUsers(IUserService userService, IRoleService roleService, ILogger<SeedUsers> logger) : ISeedUsers
{
    private readonly ILogger _logger = logger;

    public async Task SeedInitialUser()
    {
        _logger.LogInformation("Trying to reach admin user");
        DateTime createDate = new DateTime(2024, 9, 20);
        User? adminUser = await userService.IsUserExistByDate(createDate);
        if (adminUser == null)
        {
            _logger.LogInformation("Admin user were not found");
            adminUser = new User("Admin", "Admin", createDate);
            await userService.CreateUser(adminUser);
            _logger.LogInformation("Admin user has created");
        }

        Role? adminRole = await roleService.IsRoleExistByName(RolesNames.Admin);
        if (adminRole == null)
        {
            adminRole =
                new Role(RolesNames.Admin, "This role has full access through system without any restriction",
                    createDate);
            await roleService.AddRole(adminRole);
        }

        await roleService.TryAddUserToRole(adminUser, adminRole);
    }
}