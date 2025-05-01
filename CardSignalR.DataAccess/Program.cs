using CardSignalR.DataAccess;
using CardSignalR.DataAccess.Interface;
using CardSignalR.DataAccess.Interfaces;
using CardSignalR.DataAccess.Repository;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICardLinkRepository, CardLinkRepository>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();