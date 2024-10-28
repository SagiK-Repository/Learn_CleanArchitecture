using DockerGrpcServer.Protos;
using Grpc.Core;

namespace DockerGrpcServer2_2.PrintService;

public class PrintServer(Hello1.Hello1Client helloClient) : IPrint
{
    private readonly Hello1.Hello1Client _helloClient = helloClient;

    public async Task Print(string message)
    {
        await Task.Delay(1000);
        var clientRequested = new Hello1Request { Message = "This is Hello2" };
        var response = await _helloClient.Hello1Async(clientRequested, new CallOptions());
        Console.WriteLine(response.Reply);
    }
}