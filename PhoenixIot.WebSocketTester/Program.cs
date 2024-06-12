using System.Text.Json;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using DeviceItemDto = PhoenixIot.WebSocketTester.DeviceItemDto;

string token =
    "eyJhbGciOiJBMTI4S1ciLCJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwidHlwIjoiSldUIiwiY3R5IjoiSldUIn0.JejJGHDH6LRD6GE-Fe665LPCu8saWFhnQEu2OWq6MiMKFubFHox77w.PXh55_AMLRleDml2-T2chA.8BJVzf2cEp-mfxZxJrugqW2s97iaHVN5mtG_oMXcEq_EeEqnekOffctLLDt8wG4ZzxNgLSehV07r1XtRMKqEhXR2zXEQKFKiW1ImKPS_YtP9jXaDwR2Z1VpNW3GtPNeVYVrBpyzMPDaoC-aMGyTUaQYJtVnv9CN3FoX9NEEoS36LTwKlRLi7dNGt7zqc1GZEh3iOg-NJZxbYFfnxgB-RaYZ_UqLJ2k54HKECrFbazClBUfTLloUojFUrU8WrS7DkfsqxnozXT2JghCuey2qI6_irq--_S8ynaxT_0pggRz97szdSHcTgvHiOSckzxviub5tc-c5K9gyZERX6ASw2sM9UOs6psdEveFe9X9-L3VqPQ5nDUoZ1Flc2r727HtG4TcHNP72qhB787Xheb4t61WyhhWqKXlQSjvqLM8VNRt0.Gk3blDJrVIf-R3Yr3ql5QQ";
string url = "ws://192.168.1.100:5264/hub/update-device-notification";

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