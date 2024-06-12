using System.Security.Claims;

namespace PhoenixIot.Extentions;

public static class ClaimsPrinsipalExtention
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        return Guid.Parse(user.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
    }
}