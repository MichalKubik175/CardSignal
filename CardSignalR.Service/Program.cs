using CardSignalR.Service;
using CardSignalR.Service.Interfaces;
using CardSignalR.Service.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICardLinkService, CardLinkService>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();