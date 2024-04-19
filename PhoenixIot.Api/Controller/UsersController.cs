using System.Security.Claims;
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
            return Ok(new ErrorModel("کاربری با این مشخصات یافت نشد"));
        }

        TokenDto token = userService.GenerateToken(user);
        return Ok(token);
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpPost("new")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> NewUser([FromBody] NewUser newUser)
    {
        bool isExist = await userService.CheckAnyUsernameAndPassword(newUser.Username, newUser.Password);
        if (isExist)
        {
            return Ok(new ErrorModel("کاربری با این مشخصات قبلا ثبت شده"));
        }

        await userService.NewUser(newUser.Username, newUser.Password);
        return Ok();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpGet("get-all-users")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<ActionResult<UserListDto>> GetAllUsers([FromQuery] PagingDto paging)
    {
        UserListDto result = await userService.GetAllUsersAsync(paging.PageNumber, paging.PageSize);
        return Ok(result);
    }

    /// <summary>
    /// Get user information
    /// </summary>
    [HttpGet]
    [Authorize]
    public ActionResult<UserDataDto> GetUserRoles()
    {
        UserDataDto userDataDto = new(
            Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.Name).Value),
            User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value,
            User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList()
        );
        return Ok(userDataDto);
    }
}