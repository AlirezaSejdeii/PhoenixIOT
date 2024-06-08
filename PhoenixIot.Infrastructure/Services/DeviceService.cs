using Microsoft.EntityFrameworkCore;
using PhoenixIot.Application.Models;
using PhoenixIot.Application.Services;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Services;

public class DeviceService(AppDbContext dbContext) : IDeviceService
{
    public async Task CreateDevice(
        string identifier,
        string switch1Name,
        string switch2Name,
        string switch3Name,
        string switch4Name)
    {
        Device device = new(identifier, switch1Name, switch2Name, switch3Name, switch4Name, DateTime.Now);
        await dbContext.Devices.AddAsync(device);
        await dbContext.SaveChangesAsync();
    }

    public DeviceDto GetAllDevices()
    {
        IQueryable<Device> devices = dbContext.Devices.Include(x => x.User).AsQueryable();
        return GetResult(devices);
    }

    public DeviceDto GetUserDevices(Guid userId)
    {
        IQueryable<Device> devices = dbContext.Devices.Include(x => x.User)
            .Where(x => x.User != null && x.User.Id == userId).AsQueryable();
        return GetResult(devices);
    }

    public async Task<bool> IsDeviceExist(Guid deviceId)
    {
        return await dbContext.Devices.AnyAsync(x => x.Id == deviceId);
    }

    public async Task<bool> IsDeviceBelongToUser(Guid deviceId, Guid userId)
    {
        return await dbContext.Devices.Include(x => x.User).AnyAsync(x =>
            x.Id == deviceId && x.User != null && x.User.Id == userId);
    }

    public async Task<RelayStatus?> GetRelayStatus(string identifier)
    {
        Device? device = await dbContext.Devices.FirstOrDefaultAsync(x => x.Identifier == identifier);
        if (device == null)
        {
            return null;
        }

        device.SetupDeviceRelays(DateTime.Now);
        dbContext.Update(device);
        await dbContext.SaveChangesAsync();

        return new RelayStatus(device.Switch1, device.Switch2, device.Switch3, device.Switch4);
    }

    public Task<Device?> GetDeviceByIdentifierAsync(string identifier)
    {
        return dbContext.Devices.Include(x => x.User).FirstOrDefaultAsync(x => x.Identifier == identifier);
    }

    public async Task<bool> AnyDeviceWithIdentifier(string identifier)
    {
        return await dbContext.Devices.AnyAsync(x => x.Identifier == identifier);
    }

    public async Task UpdateVariablesAsync(UpdateDeviceDto deviceDto, Device device)
    {
        device.UpdateVariables(
            deviceDto.WhetherTemperature,
            deviceDto.WhetherHumidity,
            deviceDto.SoilHumidity,
            deviceDto.LightBrightness,
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
            DateTime.Now);
        dbContext.Devices.Update(device);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateIdentifier(Device device, string newIdentifier)
    {
        device.SetIdentifier(newIdentifier, DateTime.Now);
        dbContext.Devices.Update(device);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateDeviceRelays(RelayUpdate update, Device device)
    {
        device.UpdateRelays(update.Fan1, update.Fan2, update.Water1, update.Water2, DateTime.Now);
        dbContext.Devices.Update(device);
        await dbContext.SaveChangesAsync();
    }

    public Task<Device?> GetDeviceById(Guid deviceId)
    {
        return dbContext.Devices.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == deviceId);
    }

    public DeviceItemDto GetDeviceInfoById(Guid deviceId)
    {
        return MapDevice(dbContext.Devices.First(x => x.Id == deviceId));
    }

    public async Task UpdateDeviceSwitchName(
        Device device,
        string switch1Name,
        string switch2Name,
        string switch3Name,
        string switch4Name,
        string identifier)
    {
        device.UpdatedSwitchName(
            switch1Name,
            switch2Name,
            switch3Name,
            switch4Name,
            DateTime.Now);
        device.SetIdentifier(identifier, DateTime.Now);
        dbContext.Update(device);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteDevice(Device device)
    {
        dbContext.Devices.Remove(device);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateLastSync(Device device)
    {
        device.UpdateLastSync(DateTime.Now);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateTimer(TimerUpdate update, Device device)
    {
        TimeOnly startTimeRelay1 =
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(update.StartHourAtRelay1)
                .Add(TimeSpan.FromMinutes(update.StartMinAtRelay1)));
        TimeOnly endTimeRelay1 =
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(update.EndHourAtRelay1)
                .Add(TimeSpan.FromMinutes(update.EndMinAtRelay1)));

        TimeOnly startTimeRelay2 =
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(update.StartHourAtRelay2)
                .Add(TimeSpan.FromMinutes(update.StartMinAtRelay2)));
        TimeOnly endTimeRelay2 =
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(update.EndHourAtRelay2)
                .Add(TimeSpan.FromMinutes(update.EndMinAtRelay2)));


        TimeOnly startTimeRelay3 =
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(update.StartHourAtRelay3)
                .Add(TimeSpan.FromMinutes(update.StartMinAtRelay3)));
        TimeOnly endTimeRelay3 =
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(update.EndHourAtRelay3)
                .Add(TimeSpan.FromMinutes(update.EndMinAtRelay3)));

        TimeOnly startTimeRelay4 =
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(update.StartHourAtRelay4)
                .Add(TimeSpan.FromMinutes(update.StartMinAtRelay4)));
        TimeOnly endTimeRelay4 =
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(update.EndHourAtRelay4)
                .Add(TimeSpan.FromMinutes(update.EndMinAtRelay4)));

        device.SetTimer(
            startTimeRelay1,
            endTimeRelay1,
            startTimeRelay2,
            endTimeRelay2,
            startTimeRelay3,
            endTimeRelay3,
            startTimeRelay4,
            endTimeRelay4,
            DateTime.Now);
        dbContext.Devices.Update(device);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateSensor(SensorUpdate update, Device device)
    {
        device.SetSensorValues(
            update.WhetherHumidityLimit,
            update.WhetherTemperatureLimit,
            update.SoilHumidityLimit,
            update.LightBrightnessLimit,
            DateTime.Now);
        dbContext.Devices.Update(device);
        await dbContext.SaveChangesAsync();
    }


    private DeviceDto GetResult(IQueryable<Device> devices)
    {
        int total = devices.Count();
        List<DeviceItemDto> items = devices.AsEnumerable().Select(MapDevice).ToList();
        return new DeviceDto(items, total);
    }

    public static DeviceItemDto MapDevice(Device device)
    {
        return new DeviceItemDto(
            device.Id,
            device.Identifier,
            device.Switch1,
            device.Switch2,
            device.Switch3,
            device.Switch4,
            device.Switch1Name,
            device.Switch2Name,
            device.Switch3Name,
            device.Switch4Name,
            device.Setting.ToString(),
            device.WhetherHumidityLimit,
            device.WhetherTemperatureLimit,
            device.SoilHumidityLimit,
            device.LightBrightnessLimit,
            device.StartWorkAtRelay1,
            device.EndWorkAtRelay1,
            device.StartWorkAtRelay2,
            device.EndWorkAtRelay2,
            device.StartWorkAtRelay3,
            device.EndWorkAtRelay3,
            device.StartWorkAtRelay4,
            device.EndWorkAtRelay4,
            device.User?.Username,
            device.WhetherTemperature,
            device.WhetherHumidity,
            device.SoilHumidity,
            device.LightBrightness,
            device.Val1,
            device.Val2,
            device.Val3,
            device.Val4,
            device.Val5,
            device.Val6,
            device.Val7,
            device.Val8,
            device.Val9,
            device.Val10,
            device.Val11,
            device.Val12,
            device.Val13,
            device.Val14,
            device.Val15,
            device.Val16,
            device.Val17,
            device.Val18,
            device.Val19,
            device.Val20,
            device.IsSync());
    }
}