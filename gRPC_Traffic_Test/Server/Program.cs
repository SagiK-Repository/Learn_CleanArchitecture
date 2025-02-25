using Microsoft.Extensions.Options;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(option =>
{
    option.MaxReceiveMessageSize = 50 * 1024 * 1024; /*50MB*/
    option.MaxSendMessageSize = 50 * 1024 * 1024; /*50MB*/
    option.EnableDetailedErrors = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<MessageService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();