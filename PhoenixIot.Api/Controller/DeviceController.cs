using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;
using PhoenixIot.Extentions;
using PhoenixIot.Models;

namespace PhoenixIot.Controller;

[ApiController]
[Route("device")]
public class DeviceController(IUserService userService, IDeviceService deviceService, ILogger<DeviceController> logger)
    : ControllerBase
{
    /// <summary>
    /// Just admin can access.
    /// </summary>
    [Authorize(Roles = RolesNames.Admin)]
    [HttpGet("all-devices")]
    public ActionResult<DeviceDto> GetAllDevices()
    {
        return deviceService.GetAllDevices();
    }

    [HttpGet("user-devices")]
    [Authorize]
    public ActionResult<DeviceDto> GetUserDevices()
    {
        Guid userId = Guid.Parse(User.Identity!.Name!);

        if (!userService.IsUserActive(userId))
        {
            return Ok(new ErrorModel("کاربر فعال نیست"));
        }

        return deviceService.GetUserDevices(userId);
    }

    [HttpGet("get-device/{deviceId:guid}")]
    [Authorize]
    public async Task<ActionResult<DeviceDto>> GetDeviceInfo([FromRoute] Guid deviceId)
    {
        Guid userId = Guid.Parse(User.Identity!.Name!);
        if (!await deviceService.IsDeviceExist(deviceId))
        {
            return Ok(new ErrorModel("دستگاه یافت نشد"));
        }

        if (!User.Claims.IsAdmin())
        {
            if (!await deviceService.IsDeviceBelongToUser(deviceId, userId))
            {
                return Ok(new ErrorModel("دستگاه متعلق به شما نیست"));
            }

            if (!userService.IsUserActive(userId))
            {
                return Ok(new ErrorModel("کاربر فعال نیست"));
            }
        }

        return Ok(deviceService.GetDeviceInfoById(deviceId));
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpPost("create")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> CreateDevice([FromBody] NewDevice device)
    {
        Device? existDevice = await deviceService.GetDeviceByIdentifierAsync(device.Identifier);
        if (existDevice != null)
        {
            return Ok(new ErrorModel("دستگاه از قبل وجود دارد"));
        }

        await deviceService.CreateDevice(
            device.Identifier,
            device.Switch1Name,
            device.Switch2Name,
            device.Switch3Name,
            device.Switch4Name);
        return NoContent();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpPut("update-identifier")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> UpdateIdentifier([FromBody] UpdateIdentifier updateIdentifier)
    {
        logger.LogInformation("Update device identifier requested for device with CurrentId: {CurrentId}",
            updateIdentifier.CurrentId);
        logger.LogInformation("Trying to find device by identifier");
        Device? device = await deviceService.GetDeviceByIdentifierAsync(updateIdentifier.CurrentId);
        if (device == null)
        {
            logger.LogInformation("Failed to find device");
            return Ok(new ErrorModel("دستگاه یافت نشد"));
        }

        await deviceService.UpdateIdentifier(device, updateIdentifier.NewIdentifier);
        return NoContent();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpPut("update-device")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> UpdateIdentifier([FromBody] UpdateDevice updateDevice)
    {
        Device? device = await deviceService.GetDeviceById(updateDevice.Id);
        if (device == null)
        {
            return Ok(new ErrorModel("دستگاه یافت نشد"));
        }

        await deviceService.UpdateDeviceSwitchName(
            device,
            updateDevice.Switch1Name,
            updateDevice.Switch2Name,
            updateDevice.Switch3Name,
            updateDevice.Switch4Name);
        return NoContent();
    }

    /// <summary>
    /// When you call this endpoint, the setting will set to Manual
    /// </summary>
    [HttpPost("update-relays")]
    [Authorize]
    public async Task<IActionResult> UpdateRelay(RelayUpdate update)
    {
        logger.LogInformation("Trying to update relay status for device with identifier: {Identifier}",
            update.Identifier);
        Device? device = await deviceService.GetDeviceByIdentifierAsync(update.Identifier);
        if (device == null)
        {
            logger.LogInformation("Device not be found");
            return Ok(new ErrorModel("دستگاه یافت نشد"));
        }

        if (!User.Claims.IsAdmin())
        {
            logger.LogInformation("Check is device belong to user");
            Guid userId = Guid.Parse(User.Identity!.Name!);
            if (!device.IsBelongToUser(userId))
            {
                logger.LogInformation("Device is not belong to user");

                return Ok(new ErrorModel("دستگاه مطعلق به شما نیست"));
            }

            if (!userService.IsUserActive(userId))
            {
                return Ok(new ErrorModel("کاربر فعال نیست"));
            }
        }

        logger.LogInformation("Updating device");
        await deviceService.UpdateDeviceRelays(update, device);
        return NoContent();
    }

    /// <summary>
    /// When you call this endpoint, the setting will set to Timer
    /// </summary>
    [HttpPost("update-timer")]
    [Authorize]
    public async Task<IActionResult> UpdateTimer(TimerUpdate update)
    {
        logger.LogInformation("Trying to update timer for device with identifier: {Identifier}",
            update.Identifier);
        Device? device = await deviceService.GetDeviceByIdentifierAsync(update.Identifier);
        if (device == null)
        {
            logger.LogInformation("Device not be found");
            return Ok(new ErrorModel("دستگاه یافت نشد"));
        }

        if (!User.Claims.IsAdmin())
        {
            logger.LogInformation("Check is device belong to user");
            Guid userId = Guid.Parse(User.Identity!.Name!);
            if (!device.IsBelongToUser(userId))
            {
                logger.LogInformation("Device is not belong to user");

                return Ok(new ErrorModel("دستگاه مطعلق به شما نیست"));
            }

            if (!userService.IsUserActive(userId))
            {
                return Ok(new ErrorModel("کاربر فعال نیست"));
            }
        }

        logger.LogInformation("Updating device");
        await deviceService.UpdateTimer(update, device);
        return NoContent();
    }


    /// <summary>
    /// When you call this endpoint, the setting will set to Sensor
    /// </summary>
    [HttpPost("update-sensor")]
    [Authorize]
    public async Task<IActionResult> UpdateSensor(SensorUpdate update)
    {
        logger.LogInformation("Trying to update timer for device with identifier: {Identifier}",
            update.Identifier);
        Device? device = await deviceService.GetDeviceByIdentifierAsync(update.Identifier);
        if (device == null)
        {
            logger.LogInformation("Device not be found");
            return Ok(new ErrorModel("دستگاه یافت نشد"));
        }

        if (!User.Claims.IsAdmin())
        {
            logger.LogInformation("Check is device belong to user");
            Guid userId = Guid.Parse(User.Identity!.Name!);
            if (!device.IsBelongToUser(userId))
            {
                logger.LogInformation("Device is not belong to user");

                return Ok(new ErrorModel("دستگاه مطعلق به شما نیست"));
            }

            if (!userService.IsUserActive(userId))
            {
                return Ok(new ErrorModel("کاربر فعال نیست"));
            }
        }

        logger.LogInformation("Updating device");
        await deviceService.UpdateSensor(update, device);
        return NoContent();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpPost("assign-device-to-user")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> AssignDeviceToUser(AssignDeviceToUserDto assignInfo)
    {
        Device? device = await deviceService.GetDeviceById(assignInfo.DeviceId);
        if (device == null)
        {
            return Ok(new ErrorModel("دستگاه یافت نشد"));
        }

        User? user = await userService.GetUserById(assignInfo.UserId);
        if (user == null)
        {
            return Ok(new ErrorModel("کاربر یافت نشد"));
        }

        await userService.AssignDeviceToUserAsync(device, user);
        return NoContent();
    }

    /// <summary>
    /// Just admin can access.
    /// </summary>
    [HttpDelete("delete-device/{id:guid}")]
    [Authorize(Roles = RolesNames.Admin)]
    public async Task<IActionResult> DeleteDevice([FromRoute] Guid id)
    {
        Device? device = await deviceService.GetDeviceById(id);
        if (device is null)
        {
            return Ok(new ErrorModel("دستگاه یافت نشد"));
        }

        await deviceService.DeleteDevice(device);
        return NoContent();
    }
}