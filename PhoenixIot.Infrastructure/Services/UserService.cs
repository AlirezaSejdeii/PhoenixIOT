using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Services;

public class UserService(AppDbContext dbContext, IOptions<JwtConfigDto> jwtOptions) : IUserService
{
    public async Task CreateUser(User user)
    {
        await dbContext.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> IsUserExistByDate(DateTime createdAt) =>
        await dbContext.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.CreatedAt == createdAt);

    public TokenDto GenerateToken(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        byte[] secretBytes = Encoding.ASCII.GetBytes(jwtOptions.Value.Secret);
        SigningCredentials signingCredentials =
            new(new SymmetricSecurityKey(secretBytes), SecurityAlgorithms.HmacSha512Signature);

        byte[] encryptionKey = Encoding.ASCII.GetBytes(jwtOptions.Value.EncryptionKey);
        EncryptingCredentials encryptingCredentials = new(new SymmetricSecurityKey(encryptionKey),
            SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

        List<Claim> rolesList = new();
        foreach (Role role in user.Roles)
        {
            rolesList.Add(new Claim(ClaimTypes.Role, role.Title));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Username),
            }),

            Expires = DateTime.UtcNow.AddDays(jwtOptions.Value.ValidDays),
            SigningCredentials = signingCredentials,
            EncryptingCredentials = encryptingCredentials
        };
        tokenDescriptor.Subject.AddClaims(rolesList);

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        var jwtToken = jwtTokenHandler.WriteToken(token);

        return new TokenDto
        {
            ExpireDateUtc = tokenDescriptor.Expires.Value,
            Token = jwtToken
        };
    }

    public async Task<User?> GetUserByUsernameAndPasswordAsync(string loginDtoUsername, string loginDtoPassword)
    {
        return await dbContext.Users.Include(x => x.Roles).FirstOrDefaultAsync(x =>
            x.Username == loginDtoUsername && x.Password == loginDtoPassword);
    }

    public async Task<bool> IsUserInRole(Guid userId, string roleTitle)
    {
        return await dbContext.Users.AnyAsync(x => x.Id == userId && x.Roles.Any(y => y.Title == roleTitle));
    }

    public async Task<bool> CheckAnyUsernameAndPassword(string newUserUsername, string newUserPassword)
    {
        return await dbContext.Users.AnyAsync(x => x.Username == newUserUsername && x.Password == newUserPassword);
    }

    public async Task NewUser(string newUserUsername, string newUserPassword)
    {
        User user = new(newUserUsername, newUserPassword, DateTime.UtcNow);
        await dbContext.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public Task<User?> GetUserById(Guid assignInfoUserId)
    {
        return dbContext.Users.FirstOrDefaultAsync(x => x.Id == assignInfoUserId);
    }

    public async Task AssignDeviceToUserAsync(Device device, User user)
    {
        user.AssignNewDevice(device, DateTime.UtcNow);
        dbContext.Update(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task<UserListDto> GetAllUsersAsync()
    {
        IQueryable<UserInfoDto> infoList = dbContext.Users.Select(x => new UserInfoDto(x.Id, x.Username, x.CreatedAt));
        int total = infoList.Count();
        List<UserInfoDto> items = await infoList.ToListAsync();
        return new UserListDto(items, total);
    }

    public async Task DeleteUser(User user)
    {
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateUsernamePassword(User user, string newUsername, string newPassword)
    {
        user.UpdateUsernameAndPassword(newUsername, newPassword, DateTime.UtcNow);
        dbContext.Update(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddRole(User user, List<string> userInfoRoles)
    {
        List<Role> roles = dbContext.Roles.ToList();
        roles.ForEach(role => user.Roles.Add(role));
        await dbContext.SaveChangesAsync();
    }
    
    public async Task RemoveRole(User user, List<string> userInfoRoles)
    {
        List<Role> roles = dbContext.Roles.ToList();
        roles.ForEach(role => user.Roles.Remove(role));
        await dbContext.SaveChangesAsync();
    }
}