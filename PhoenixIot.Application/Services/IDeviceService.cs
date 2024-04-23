using PhoenixIot.Application.Models;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Application.Services;

public interface IDeviceService
{
    Task CreateDevice(
        string identifier,
        string switch1Name,
        string switch2Name,
        string switch3Name,
        string switch4Name);

    DeviceDto GetAllDevices();
    DeviceDto GetUserDevices(Guid userId);
    Task<RelayStatus?> GetRelayStatus(string identifier);
    Task<Device?> GetDeviceByIdentifierAsync(string identifier);
    Task UpdateVariablesAsync(UpdateDeviceDto deviceDto, Device device);
    Task UpdateIdentifier(Device device, string updateDeviceNewIdentifier);
    Task<Device?> GetDeviceById(Guid deviceId);
    Task DeleteDevice(Device device);
    Task UpdateLastSync(Device device);
    Task UpdateDeviceRelays(RelayUpdate update, Device device);
    Task UpdateTimer(TimerUpdate update, Device device);
    Task UpdateSensor(SensorUpdate update, Device device);
    Task<bool> IsDeviceBelongToUser(Guid deviceId, Guid userId);
    Task<bool> IsDeviceExist(Guid deviceId);
    DeviceItemDto GetDeviceInfoById(Guid deviceId);
    Task UpdateDeviceSwitchName(
        Device device, 
        string switch1Name, 
        string switch2Name, 
        string switch3Name, 
        string switch4Name);
}