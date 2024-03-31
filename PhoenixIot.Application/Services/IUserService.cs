using PhoenixIot.Application.Models;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Application.Services;

public interface IUserService
{
    Task CreateUser(User user);
    Task<User?> IsUserExistByDate(DateTime createdAt);
    TokenDto GenerateToken(User user);
    Task<User?> GetUserByUsernameAndPasswordAsync(string loginDtoUsername, string loginDtoPassword);
}