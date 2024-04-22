using PhoenixIot.Application.Models;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Application.Services;

public interface IUserService
{
    Task CreateUser(User user);
    Task<User?> IsUserExistByDate(DateTime createdAt);
    TokenDto GenerateToken(User user);
    Task<User?> GetUserByUsernameAndPasswordAsync(string loginDtoUsername, string loginDtoPassword);
    Task<bool> IsUserInRole(Guid userId, string roleTitle);
    Task<bool> CheckAnyUsernameAndPassword(string newUserUsername, string newUserPassword);
    Task<bool> CheckUsernameExist(string newUserUsername);
    Task NewUser(string newUserUsername, string newUserPassword);
    Task<User?> GetUserById(Guid assignInfoUserId);
    Task AssignDeviceToUserAsync(Device device, User user);
    Task<UserListDto> GetAllUsersAsync();
    Task DeleteUser(User user);
    Task UpdateUsernamePassword(User user, string newUsername, string newPassword);
    Task AddRole(User user, List<string> userInfoRoles);
    Task RemoveRole(User user, List<string> userInfoRoles);
}