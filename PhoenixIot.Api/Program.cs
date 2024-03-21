using PhoenixIot.Application;
using PhoenixIot.Core.Options;
using PhoenixIot.Infrastructure;
using PhoenixIot.Infrastructure.Seeder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Options
builder.Services.Configure<MongoDbOptions>(builder.Configuration.GetSection("MongoDb"));

// Services
builder.Services.AddInfrastructure();
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
SeedUsers userSeederService = app.Services.GetRequiredService<SeedUsers>();
await userSeederService.SeedInitialUser();

app.Run();