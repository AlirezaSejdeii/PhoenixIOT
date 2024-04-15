using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Models;

namespace PhoenixIot.Controller;

[ApiController]
[Route("users")]
public class UsersController(IUserService userService, IDeviceService deviceService) : ControllerBase
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

    [HttpPost("new")]
    [Authorize(RolesNames.Admin)]
    public async Task<IActionResult> NewUser([FromBody] NewUser newUser)
    {
        bool isExist = await userService.CheckAnyUsernameAndPassword(newUser.Username, newUser.Password);
        if (isExist)
        {
            return BadRequest("Username or password is not unique");
        }

        await userService.NewUser(newUser.Username, newUser.Password);
        return Ok();
    }

    [HttpGet("get-all-users")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<ActionResult<UserListDto>> GetAllUsers([FromQuery] PagingDto paging)
    {
        UserListDto result = await userService.GetAllUsersAsync(paging.PageNumber, paging.PageSize);
        return Ok(result);
    }
}