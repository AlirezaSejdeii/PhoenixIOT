using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PhoenixIot.Application;
using PhoenixIot.Application.Services;
using PhoenixIot.Hubs;
using PhoenixIot.Infrastructure;
using PhoenixIot.Infrastructure.Hubs;
using PhoenixIot.Infrastructure.Seeder;
using PhoenixIot.Infrastructure.Services;
using PhoenixIot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Phoenix API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Services

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddSignalR();
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
app.UseAuthentication();
app.UseAuthorization();
// app.UseHttpsRedirection();
app.MapControllers();
app.MapHub<UpdateDeviceHub>("/hub/update-device-notification");

// Initialization
var scope = app.Services.CreateScope();
AppDbContext dbContext=scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.EnsureCreated();
ISeedUsers userSeederService = scope.ServiceProvider.GetRequiredService<ISeedUsers>();
await userSeederService.SeedInitialUser();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();