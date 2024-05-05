using PhoenixIot.Application.Models;

namespace PhoenixIot.Hubs;

public interface IDeviceUpdateClient
{
    public Task OnDeviceUpdated(DeviceItemDto deviceItemDto);
}