using Microsoft.AspNetCore.Mvc;
using PhoenixIot.Application.Models;
using PhoenixIot.Hubs;
using PhoenixIot.Infrastructure;

namespace PhoenixIot.Controller;

/// <summary>
/// It's just useful for device firmware.
/// </summary>
[ApiController]
[Route("manager-device")]
public class ManageDeviceController(ILogger<ManageDeviceController> logger, AppDbContext dbContext) : ControllerBase
{
    private readonly ILogger _logger = logger;

    /// <summary>
    /// It's just useful for device firmware.
    /// </summary>
    [HttpGet]
    public IActionResult GetRelayStatus()
    {
        int x = Random.Shared.Next(0, 10);
        _logger.LogInformation("Random number: {Number}", x);
        RelayStatus res;
        if (x % 2 == 0)
        {
            res = new RelayStatus(true, true, false, false);
        }
        else
        {
            res = new RelayStatus(false, false, true, true);
        }

        _logger.LogInformation("Relay channel status is {@Channel}", res);
        return Ok(res);
    }

    /// <summary>
    /// It's just useful for device firmware.
    /// </summary>
    [HttpPost]
    public IActionResult UpdateHumidityAndTemperature(HumidityAndTemperature status)
    {
        _logger.LogInformation("Humidity and temperature is {@HumidityAndTemperature}", status);
        return NoContent();
    }
}
