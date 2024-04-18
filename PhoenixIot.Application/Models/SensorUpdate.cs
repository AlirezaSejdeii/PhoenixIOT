namespace PhoenixIot.Application.Models;

public record SensorUpdate(string Identifier, int FanOnAtTemp,int FanOffAtTemp,int WaterOffFromHumidity);