using DockerGrpcServer.Protos;
using DockerGrpcServer2_1.PrintService;
using DockerGrpcServer2_1.Services;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddGrpc();

var serverUrl = builder.Configuration["GrpcSettings:ServerUrl"];
builder.Services.AddSingleton(provider =>
{
    // SSL 인증서 검증을 비활성화
    var httpClientHandler = new HttpClientHandler();
    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

    var channel = GrpcChannel.ForAddress(serverUrl ?? "https://localhost:5050", new GrpcChannelOptions { HttpClient = new HttpClient(httpClientHandler) });
    return new Hello2.Hello2Client(channel);
});
builder.Services.AddTransient<IPrint, PrintServer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<Hello1Service>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Run();

var printService = app.Services.GetRequiredService<IPrint>();
await printService.Print("Hello World!");