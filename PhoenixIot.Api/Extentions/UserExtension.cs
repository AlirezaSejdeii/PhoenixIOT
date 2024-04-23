using System.Security.Claims;
using PhoenixIot.Application.Models;

namespace PhoenixIot.Extentions;

public static class UserExtension
{
    public static bool IsAdmin(this IEnumerable<Claim> claims)
    {
        return claims.Any(x => x.Type == ClaimTypes.Role && x.Value == RolesNames.Admin);
    }
}