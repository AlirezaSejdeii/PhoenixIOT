using Microsoft.Extensions.Logging;
using PhoenixIot.Entities;
using PhoenixIot.Infrastructure.Services;

namespace PhoenixIot.Infrastructure.Seeder;

public class SeedUsers(UserService userService, ILogger<SeedUsers> logger)
{
    private readonly ILogger _logger = logger;

    public async Task SeedInitialUser()
    {
        _logger.LogInformation("Trying to reach admin user");
        DateTime createDate = new DateTime(2024, 9, 20);
        User? user = await userService.IsUserExistByDate(createDate);
        if (user == null)
        {
            _logger.LogInformation("Admin user were not found");
            user = new User("Admin", "Admin", createDate);
            await userService.CreateUser(user);
            _logger.LogInformation("Admin user has created");
        }
    }
}