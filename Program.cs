using EjemploServicioDotNET;

using Microsoft.Extensions.Logging.Configuration;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Test Servicio con .NET";
});

builder.Services.AddSingleton<MyHTTPServer>();
builder.Services.AddHostedService<Worker>();

// See: https://github.com/dotnet/runtime/issues/47303
builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));

IHost host = builder.Build();
host.Run();