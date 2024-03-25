using Microsoft.EntityFrameworkCore;
using PhoenixIot.Application;
using PhoenixIot.Application.Services;
using PhoenixIot.Infrastructure;
using PhoenixIot.Infrastructure.Seeder;
using PhoenixIot.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Options

// Services

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyMethod();
    x.AllowAnyOrigin();
});
app.UseRouting();
app.UseHttpsRedirection();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

// Initialization
var scope = app.Services.CreateScope();
ISeedUsers userSeederService = scope.ServiceProvider.GetRequiredService<ISeedUsers>();
await userSeederService.SeedInitialUser();

app.Run();