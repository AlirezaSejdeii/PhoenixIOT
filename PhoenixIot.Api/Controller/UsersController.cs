using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Models;

namespace PhoenixIot.Controller;

[ApiController]
[Route("users")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        Core.Entities.User? user =
            await userService.GetUserByUsernameAndPasswordAsync(loginDto.Username, loginDto.Password);
        if (user == null)
        {
            return NotFound("User not exist");
        }

        TokenDto token = userService.GenerateToken(user);
        return Ok(token);
    }
}