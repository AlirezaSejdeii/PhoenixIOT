using PhoenixIot.Core.Entities;

namespace PhoenixIot.Application.Services;

public interface IUserService
{
    Task CreateUser(User user);
    Task<User?> IsUserExistByDate(DateTime createdAt);
}