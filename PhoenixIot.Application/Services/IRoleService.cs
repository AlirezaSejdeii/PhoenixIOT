using PhoenixIot.Core.Entities;

namespace PhoenixIot.Application.Services;

public interface IRoleService
{
    Task<Role?> IsRoleExistByName(string title);
    Task AddRole(Role role);
    Task TryAddUserToRole(User adminUser, Role adminRole);
}