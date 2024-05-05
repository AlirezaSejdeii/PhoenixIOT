using PhoenixIot.Core.Entities;

namespace PhoenixIot.Hubs;

public interface IDeviceUpdateNotificationService
{
    public Task DeviceUpdated(Device device);
}