using Microsoft.EntityFrameworkCore;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Services;

public class RoleService(AppDbContext dbContext) : IRoleService
{
    public async Task<Role?> IsRoleExistByName(string title) =>
        await dbContext.Roles.FirstOrDefaultAsync(x => x.Title == title);

    public async Task AddRole(Role role)
    {
        await dbContext.Roles.AddAsync(role);
        await dbContext.SaveChangesAsync();
    }

    public async Task TryAddUserToRole(User adminUser, Role adminRole)
    {
        if (!adminUser.Roles.Any(x => x.Id == adminRole.Id))
        {
            adminUser.Roles.Add(adminRole);
            await dbContext.SaveChangesAsync();
        }
    }
}