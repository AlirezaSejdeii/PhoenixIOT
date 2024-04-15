using Microsoft.EntityFrameworkCore;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Services;

public class DeviceService(AppDbContext dbContext) : IDeviceService
{
    public async Task CreateDevice(string identifier)
    {
        Device device = new(identifier, DateTime.UtcNow);
        await dbContext.Devices.AddAsync(device);
        await dbContext.SaveChangesAsync();
    }

    public async Task<DeviceDto> GetAllDevices(int page = 1, int size = 10)
    {
        IQueryable<Device> devices = dbContext.Devices.AsQueryable();
        return await GetResult(devices, page, size);
    }

    public async Task<DeviceDto> GetUserDevices(Guid userId, int page = 1, int size = 10)
    {
        IQueryable<Device> devices = dbContext.Devices.Where(x => x.User != null && x.User.Id == userId).AsQueryable();
        return await GetResult(devices, page, size);
    }

    public async Task<RelayStatus?> GetRelayStatus(string identifier)
    {
        Device? device = await dbContext.Devices.FirstOrDefaultAsync(x => x.Identifier == identifier);
        if (device == null)
        {
            return null;
        }

        return new RelayStatus(device.FanSwitch1, device.FanSwitch2, device.WaterSwitch1, device.WaterSwitch2);
    }

    public Task<Device?> GetDeviceByIdentifierAsync(string identifier)
    {
        return dbContext.Devices.FirstOrDefaultAsync(x => x.Identifier == identifier);
    }

    public async Task UpdateVariablesAsync(UpdateDeviceDto deviceDto, Device device)
    {
        device.UpdateVariables(
            deviceDto.Temperature,
            deviceDto.Humidity,
            deviceDto.Val1,
            deviceDto.Val2,
            deviceDto.Val3,
            deviceDto.Val4,
            deviceDto.Val5,
            deviceDto.Val6,
            deviceDto.Val7,
            deviceDto.Val8,
            deviceDto.Val9,
            deviceDto.Val10,
            deviceDto.Val11,
            deviceDto.Val12,
            deviceDto.Val13,
            deviceDto.Val14,
            deviceDto.Val15,
            deviceDto.Val16,
            deviceDto.Val17,
            deviceDto.Val18,
            deviceDto.Val19,
            deviceDto.Val20,
            DateTime.UtcNow);
        dbContext.Devices.Update(device);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateIdentifier(Device device, string newIdentifier)
    {
        device.SetIdentifier(newIdentifier, DateTime.UtcNow);
        dbContext.Devices.Update(device);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateDeviceRelays(RelayUpdate update, Device device)
    {
        device.UpdateRelays(update.Fan1, update.Fan2, update.Water1, update.Water2, DateTime.UtcNow);
        dbContext.Devices.Update(device);
        await dbContext.SaveChangesAsync();
    }

    public Task<Device?> GetDeviceById(Guid deviceId)
    {
        return dbContext.Devices.FirstOrDefaultAsync(x => x.Id == deviceId);
    }

    public Task UpdateDeviceRelays(RelayUpdate update)
    {
        throw new NotImplementedException();
    }

    private async Task<DeviceDto> GetResult(IQueryable<Device> devices, int page = 1, int size = 10)
    {
        int total = devices.Count();
        List<DeviceItemDto> items = await devices.Select(x => new DeviceItemDto(
                x.Id,
                x.Identifier,
                x.FanSwitch1,
                x.FanSwitch2,
                x.WaterSwitch1,
                x.WaterSwitch2,
                x.ManualSetting,
                x.FanSwitchOnAt,
                x.WaterSwitchOnAt,
                x.User == null ? null : x.User.Username,
                x.Temperature,
                x.Humidity,
                x.Val1,
                x.Val2,
                x.Val3,
                x.Val4,
                x.Val5,
                x.Val6,
                x.Val7,
                x.Val8,
                x.Val9,
                x.Val10,
                x.Val11,
                x.Val12,
                x.Val13,
                x.Val14,
                x.Val15,
                x.Val16,
                x.Val17,
                x.Val18,
                x.Val19,
                x.Val20))
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
        return new DeviceDto(items, total);
    }
}