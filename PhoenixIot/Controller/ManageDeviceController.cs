using Microsoft.AspNetCore.Mvc;

namespace PhoenixIot.Controller;

[ApiController]
[Route("device-manager")]
public class ManageDeviceController(ILogger<ManageDeviceController> logger) : ControllerBase
{
    private readonly ILogger _logger = logger;

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

    [HttpPost]
    public IActionResult UpdateHumidityAndTemperature(HumidityAndTemperature status)
    {
        _logger.LogInformation("Humidity and temperature is {@HumidityAndTemperature}", status);
        return NoContent();
    }
}

public record RelayStatus(bool Pin1, bool Pin2, bool Pin3, bool Pin4);

public record HumidityAndTemperature(float Humidity, float Temperature);