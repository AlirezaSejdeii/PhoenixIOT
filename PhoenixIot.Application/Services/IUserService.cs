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
    Task NewUser(string newUserUsername, string newUserPassword);
}