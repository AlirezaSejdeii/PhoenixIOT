namespace PhoenixIot.Application.Models;

public record SensorUpdate(
    string Identifier,
    int WhetherHumidityLimit,
    int WhetherTemperatureLimit,
    int SoilHumidityLimit,
    int LightBrightnessLimit);