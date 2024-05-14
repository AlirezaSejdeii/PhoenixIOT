using System.Text.Json;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using DeviceItemDto = PhoenixIot.WebSocketTester.DeviceItemDto;

string token =
    "eyJhbGciOiJBMTI4S1ciLCJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwidHlwIjoiSldUIiwiY3R5IjoiSldUIn0.h53F2o4YQFJsQG_MFZrnpypSN1HHA91YLg5nds_nhSFV8w0F3XxQPA.u2xeZxfK9Z_LIMYMzfUKkQ.jiElX9oWvaHa8_NtMxD6wLAlccOqOkcYJpBSgY_3iyW9KJ1xCan_OMZcTful7OnM96VV6oK6fk4w8MPBGl1cFXOMc8DCtJ_0tET7u3PyWWUQVotJLIRkNIWYrj3pdfLkvs0onnGWlNaOhstOvIRj4NqiyQna6swPGNTL4zAYSHvs-Q76w_rvQ976T6C8QabD66ERS6yOvD14o3_SSEekBZhXpfjMwpnDiuUky4AAvgGZqy3toCuX1zsIlyYHQb-wp8RmBB0cHnqS2dbmKYdAjjLvVqQStA5Co56ML1tbpbjxcJyU1zROsUpBdll02T-80kl4yjp75mHLJGfRu4hVP--6m_yId_U5CjVOdWnQZ7MoLDDFLil5ARcfjQ5ckgspWre0whUnhpjbU0xXd85emZqsb5q6ICO2hRiSOLGqJfU.rWWzX__JlmGMaGZKLMY2-w";
string url = "wss://phoenix.liara.run/hub/update-device-notification";

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