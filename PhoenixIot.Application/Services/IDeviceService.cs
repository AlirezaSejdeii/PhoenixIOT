using PhoenixIot.Application.Models;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Application.Services;

public interface IDeviceService
{
    Task CreateDevice(string identifier);
    Task<DeviceDto> GetAllDevices(int page = 1, int size = 10);
    Task<DeviceDto> GetUserDevices(Guid userId, int page = 1, int size = 10);
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
}