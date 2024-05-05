using System.Text.Json;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using DeviceItemDto = PhoenixIot.WebSocketTester.DeviceItemDto;

string token =
    "eyJhbGciOiJBMTI4S1ciLCJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwidHlwIjoiSldUIiwiY3R5IjoiSldUIn0.8wuoy8OvzKPEmZVsG4G2vWnZaPFGD4xdcj19hFybu9BTt1fZ9RkQIA.O6ria0jMWPB82dSwBiFwwQ.-47286CFlxFsXFqtFZOzNftL-aUbJ7Epb4WH1Lip9ZGhqQ7E-JJFQxGI-bi921Ss_My8Led9MbeWPwKD7GuHQMibuAbUfshEWntjhzM7a94RKM1ZJbT1NOsjr2hJFF98pHNmW6vr6TRUibF-L_Dhpi5mu3yvl-pFK0uHPHyyNF3xaF_UbvhQZd1GU4TSY7O_Z3i0KtxcZ8r1Khk64Qy-9hIpnUEkXLL2QLH0LTxfz8JkBq01FjIby8DuRpE-bDGYfkYbWkNye6PLlIsgN8BDyLwJnHGDPDTuvg-tMN81JaJ_4NTviXcfJKoj4EzwZdkE_C93clOhV4-LNpH1GHmrOFRBb3T8I7LUJnZkQI_b0BlzAxZjRKE4cO8znreH_ipCgrzNK3MfDla6DvPqPOSu-r3lcm7Nl5CzX3q_4oSpQNo.KqQd_z5LTFt5gnR2j40OyQ";
string url = "ws://localhost:5264/hub/update-device-notification";

HubConnectionBuilder hubConnectionBuilder = new();

HubConnection connection = hubConnectionBuilder.WithUrl(url, options =>
    {
        options.SkipNegotiation = true;
        options.Transports = HttpTransportType.WebSockets;
        options.AccessTokenProvider = () => Task.FromResult(token)!;
    })
    .Build();
hubConnectionBuilder.WithAutomaticReconnect();

connection.StartAsync().ContinueWith(task =>
{
    if (task.IsFaulted)
    {
        Console.WriteLine("There was an error opening the connection:{0}", task.Exception.GetBaseException());
    }
    else
    {
        Console.WriteLine("Connected");
    }
}).Wait();

connection.On<DeviceItemDto>("OnDeviceUpdated", DoSomething);

Console.WriteLine(connection.ConnectionId);

Console.Read();

void DoSomething(DeviceItemDto param)
{
    Console.WriteLine($"Received at: {DateTime.Now}");
    // string json = JsonSerializer.Serialize(param, new JsonSerializerOptions { WriteIndented = true });
    // Console.WriteLine(json);
}