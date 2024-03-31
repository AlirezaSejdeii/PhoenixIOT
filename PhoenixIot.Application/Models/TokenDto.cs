using Microsoft.AspNetCore.Identity;

namespace PhoenixIot.Application.Models;

public class TokenDto
{
    public DateTime ExpireDateUtc { get; set; }
    public string Token { get; set; }
}