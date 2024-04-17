namespace PhoenixIot.Application.Models;

public record DeviceItemDto(
    Guid Id,
    string Identifier,
    bool FanSwitch1,
    bool FanSwitch2,
    bool WaterSwitch1,
    bool WaterSwitch2,
    bool ManualSetting,
    uint? FanSwitchOnAt,
    uint? WaterSwitchOnAt,
    string? BelongToUsername,
    string? Temperature,
    string? Humidity,
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
    string? Val20
);