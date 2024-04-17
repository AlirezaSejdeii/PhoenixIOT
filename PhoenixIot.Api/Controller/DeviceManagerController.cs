using Microsoft.AspNetCore.Mvc;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Controller;

/// <summary>
/// It's just useful for device firmware.
/// </summary>
[ApiController]
[Route("device-manager")]
public class DeviceManagerController(IDeviceService deviceService, ILogger<DeviceManagerController> logger)
    : ControllerBase
{
    /// <summary>
    /// It's just useful for device firmware.
    /// </summary>
    [HttpGet("status/{identifier}")]
    public async Task<ActionResult<RelayStatus>> GetRelayStatus([FromRoute] string identifier)
    {
        logger.LogInformation("Trying to reach relay status");
        logger.LogInformation("Relay identifier: {identifier}", identifier);
        RelayStatus? relayStatus = await deviceService.GetRelayStatus(identifier);
        if (relayStatus == null)
        {
            logger.LogInformation("Failed to find relay with given identifier");
            return NotFound();
        }

        logger.LogInformation("Status found successfully, status: {@Status}", relayStatus);

        return relayStatus;
    }

    /// <summary>
    /// It's just useful for device firmware.
    /// </summary>
    [HttpPost("update-variables/{identifier}")]
    public async Task<IActionResult> UpdateDeviceVariables(
        [FromRoute] string identifier,
        [FromBody] UpdateDeviceDto deviceDto)
    {
        logger.LogInformation("Trying to reach device by identifier: {Identifier}", identifier);
        Device? device = await deviceService.GetDeviceByIdentifierAsync(identifier);
        if (device == null)
        {
            logger.LogInformation("Failed to find device");
            return NotFound();
        }

        await deviceService.UpdateVariablesAsync(deviceDto, device);
        return NoContent();
    }
}