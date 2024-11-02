using DockerDIService.PrintService;
using DockerGrpcClient.PrintService;
using DockerGrpcServer.Protos;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var build = new ConfigurationBuilder();

build.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
    .AddEnvironmentVariables();

Thread.Sleep(1000);

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        var serverUrl = config["GrpcSettings:ServerUrl"];

        services.AddSingleton(provider =>
        {
            // SSL 인증서 검증을 비활성화
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            var channel = GrpcChannel.ForAddress(serverUrl ?? "https://localhost:5050", new GrpcChannelOptions { HttpClient = new HttpClient(httpClientHandler) });
            return new Hello.HelloClient(channel);
        });
        // services.AddTransient<IPrint, PrintConsole>();
        services.AddTransient<IPrint, PrintServer>();
    })
    .Build();

var printService = host.Services.GetRequiredService<IPrint>();
await printService.Print("Hello World!");
