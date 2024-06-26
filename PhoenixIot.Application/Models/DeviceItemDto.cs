namespace PhoenixIot.Application.Models;

public record DeviceItemDto(
    Guid Id,
    string Identifier,
    bool Switch1,
    bool Switch2,
    bool Switch3,
    bool Switch4,
    string Switch1Name,
    string Switch2Name,
    string Switch3Name,
    string Switch4Name,
    string Setting,
    int WhetherHumidityLimit,
    int WhetherTemperatureLimit,
    int SoilHumidityLimit,
    int LightBrightnessLimit,
    TimeOnly Relay1StartWorkAt,
    TimeOnly Relay1EndWorkAt,
    TimeOnly Relay2StartWorkAt,
    TimeOnly Relay2EndWorkAt,
    TimeOnly Relay3StartWorkAt,
    TimeOnly Relay3EndWorkAt,
    TimeOnly Relay4StartWorkAt,
    TimeOnly Relay4EndWorkAt,
    string? BelongToUsername,
    string? WhetherTemperature,
    string? WhetherHumidity,
    string? SoilHumidity,
    string? LightBrightness,
    string? Val1,
    string? Val2,
    string? Val3,
    string? Val4,
    string? Val5,
    string? Val6,
    string? Val7,
    string? Val8,
    string? Val9,
    string? Val10,
    string? Val11,
    string? Val12,
    string? Val13,
    string? Val14,
    string? Val15,
    string? Val16,
    string? Val17,
    string? Val18,
    string? Val19,
    string? Val20,
    bool IsSync
);