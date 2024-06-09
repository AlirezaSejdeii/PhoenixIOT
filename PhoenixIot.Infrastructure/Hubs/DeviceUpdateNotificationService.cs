using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoenixIot.Application.Models;
using PhoenixIot.Core.Entities;
using PhoenixIot.Hubs;
using PhoenixIot.Infrastructure.Services;

namespace PhoenixIot.Infrastructure.Hubs;

public class DeviceUpdateNotificationService : IDeviceUpdateNotificationService
{
    private readonly IHubContext<UpdateDeviceHub, IDeviceUpdateClient> _hubContext;
    private readonly AppDbContext _dbContext;
    private readonly ILogger<DeviceUpdateNotificationService> _logger;

    public DeviceUpdateNotificationService(
        IHubContext<UpdateDeviceHub, IDeviceUpdateClient> hubContext,
        AppDbContext dbContext,
        ILogger<DeviceUpdateNotificationService> logger)
    {
        _hubContext = hubContext;
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task DeviceUpdated(Device device)
    {
        Guid? givenDeviceUserId = device.User?.Id;
        if (givenDeviceUserId is not null)
        {
            _logger.LogInformation("sending notification to given device user");
            await _hubContext.Clients.User(givenDeviceUserId.ToString()!)
                .OnDeviceUpdated(DeviceService.MapDevice(device));
        }

        List<Guid> admins = await _dbContext.Users.Where(x => x.Roles.Any(b => b.Title == RolesNames.Admin))
            .Select(x => x.Id).ToListAsync();
        foreach (var id in admins.Where(x => x != givenDeviceUserId))
        {
            _logger.LogInformation("sending notification to admins");
            await _hubContext.Clients.User(id.ToString()).OnDeviceUpdated(DeviceService.MapDevice(device));
        }
    }
}