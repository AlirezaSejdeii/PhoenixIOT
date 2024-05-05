using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PhoenixIot.Hubs;

namespace PhoenixIot.Infrastructure.Hubs;

[Authorize]
public class UpdateDeviceHub : Hub<IDeviceUpdateClient>;
