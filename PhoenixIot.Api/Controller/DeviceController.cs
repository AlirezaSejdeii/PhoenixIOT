using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;
using PhoenixIot.Models;

namespace PhoenixIot.Controller;

[ApiController]
[Route("device")]
public class DeviceController(IUserService userService, IDeviceService deviceService, ILogger<DeviceController> logger)
    : ControllerBase
{
    [Authorize(Roles = RolesNames.Admin)]
    [HttpGet("all-devices")]
    public async Task<ActionResult<DeviceDto>> GetAllDevices([FromQuery] PagingDto paging)
    {
        Guid userId = Guid.Parse(User.Identity!.Name!);
        if (await userService.IsUserInRole(userId, RolesNames.Admin))
        {
            return await deviceService.GetAllDevices(paging.PageNumber, paging.PageSize);
        }

        return Ok(HttpStatusCode.Forbidden);
    }

    [HttpGet("user-devices")]
    public async Task<ActionResult<DeviceDto>> GetUserDevices([FromQuery] PagingDto paging)
    {
        Guid userId = Guid.Parse(User.Identity!.Name!);
        return await deviceService.GetUserDevices(userId, paging.PageNumber, paging.PageSize);
    }

    [HttpPost("create")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> CreateDevice([FromBody] string identifier)
    {
        await deviceService.CreateDevice(identifier);
        return NoContent();
    }

    [HttpPut("update-identifier")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> UpdateIdentifier([FromBody] UpdateDevice updateDevice)
    {
        logger.LogInformation("Update device identifier requested for device with Id: {Id}", updateDevice.Id);
        logger.LogInformation("Trying to find device by identifier");
        Device? device = await deviceService.GetDeviceByIdentifierAsync(updateDevice.Id);
        if (device == null)
        {
            logger.LogInformation("Failed to find device");
            return NotFound();
        }

        await deviceService.UpdateIdentifier(device, updateDevice.NewIdentifier);
        return NoContent();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateRelay(RelayUpdate update)
    {
        logger.LogInformation("Trying to update relay status for device with identifier: {Identifier}",
            update.Identifier);
        Device? device = await deviceService.GetDeviceByIdentifierAsync(update.Identifier);
        if (device == null)
        {
            logger.LogInformation("Device not be found");
            return NotFound();
        }

        logger.LogInformation("Check is device belong to user");
        Guid userId = Guid.Parse(User.Identity!.Name!);
        if (!device.IsBelongToUser(userId))
        {
            logger.LogInformation("Device is not belong to user");

            return Ok(HttpStatusCode.Forbidden);
        }

        logger.LogInformation("Updating device");
        await deviceService.UpdateDeviceRelays(update, device);
        return NoContent();
    }
}