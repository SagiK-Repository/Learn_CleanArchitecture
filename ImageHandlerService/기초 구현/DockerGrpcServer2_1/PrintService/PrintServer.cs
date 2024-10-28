using DockerGrpcServer.Protos;
using Grpc.Core;

namespace DockerGrpcServer2_1.PrintService;

public class PrintServer(Hello2.Hello2Client helloClient) : IPrint
{
    private readonly Hello2.Hello2Client _helloClient = helloClient;

    public async Task Print(string message)
    {
        await Task.Delay(1500);
        var clientRequested = new Hello2Request { Message = "This is Hello1" };
        var response = await _helloClient.Hello2Async(clientRequested, new CallOptions());
        Console.WriteLine(response.Reply);
    }
}