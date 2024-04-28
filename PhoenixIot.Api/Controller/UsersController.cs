using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;
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
        return NoContent();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpDelete("remove/{id:guid}")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> RemoveUser([FromRoute] Guid id)
    {
        User? user = await userService.GetUserById(id);
        if (user == null)
        {
            return Ok(new ErrorModel("کاربری با این مشخصات یافت نشد"));
        }

        await userService.DeleteUser(user);
        return NoContent();
    }


    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpPut("update/{id:guid}")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] NewUser userInfo)
    {
        User? user = await userService.GetUserById(id);
        if (user == null)
        {
            return Ok(new ErrorModel("کاربری با این مشخصات یافت نشد"));
        }

        if (user.Username != userInfo.Username && await userService.CheckUsernameExist(userInfo.Username))
        {
            return Ok(new ErrorModel("نام کاربری از قبل ساخته شده است"));
        }

        await userService.UpdateUsernamePassword(user, userInfo.Username, userInfo.Password);
        return NoContent();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpPost("assign-role")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto userInfo)
    {
        User? user = await userService.GetUserById(userInfo.UserId);
        if (user == null)
        {
            return Ok(new ErrorModel("کاربری با این مشخصات یافت نشد"));
        }

        if (!userInfo.Roles.Contains(RolesNames.Admin))
        {
            return Ok(new ErrorModel("نقشی با این مشخصات یافت نشد"));
        }

        await userService.AddRole(user, userInfo.Roles);
        return NoContent();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpPost("remove-role")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> RemoveRole([FromBody] AssignRoleDto userInfo)
    {
        User? user = await userService.GetUserById(userInfo.UserId);
        if (user == null)
        {
            return Ok(new ErrorModel("کاربری با این مشخصات یافت نشد"));
        }

        if (!userInfo.Roles.Contains(RolesNames.Admin))
        {
            return Ok(new ErrorModel("نقشی با این مشخصات یافت نشد"));
        }

        await userService.RemoveRole(user, userInfo.Roles);
        return NoContent();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpGet("get-all-users")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<ActionResult<UserListDto>> GetAllUsers()
    {
        UserListDto result = await userService.GetAllUsersAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get user information
    /// </summary>
    [HttpGet("user-data")]
    [Authorize]
    public ActionResult<UserDataDto> GetUserInformation()
    {
        UserDataDto userDataDto = new(
            Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.Name).Value),
            User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value,
            User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList()
        );
        return Ok(userDataDto);
    }

    /// <summary>
    /// Get user information
    /// </summary>
    [HttpPatch("toggle-user-is-active/{id:guid}")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<ActionResult<UserDataDto>> ToggleUserActive(Guid id)
    {
        User? user = await userService.GetUserById(id);
        if (user == null)
        {
            return Ok(new ErrorModel("کاربر یافت نشد"));
        }

        await userService.ToggleActivity(user);
        return NoContent();
    }
}