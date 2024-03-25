using Microsoft.EntityFrameworkCore;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Services;

public class UserService(AppDbContext dbContext) : IUserService
{
    public async Task CreateUser(User user) => await dbContext.AddAsync(user);

    public async Task<User?> IsUserExistByDate(DateTime createdAt) =>
        await dbContext.Users.FirstOrDefaultAsync(x => x.CreatedAt == createdAt);
}