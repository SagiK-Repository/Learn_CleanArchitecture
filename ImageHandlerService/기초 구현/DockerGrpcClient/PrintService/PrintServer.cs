﻿using DockerDIService.PrintService;
using DockerGrpcServer.Protos;
using Grpc.Core;

namespace DockerGrpcClient.PrintService;

public class PrintServer(Hello.HelloClient helloClient) : IPrint
{
    private readonly Hello.HelloClient _helloClient = helloClient;

    public async Task Print(string message)
    {
        var clientRequested = new HelloRequest { Message = "Hello World!" };
        // var response = _helloClient.Hello(clientRequested, new CallOptions());
        var response = await _helloClient.HelloAsync(clientRequested, new CallOptions());
        await Task.CompletedTask;
        Console.WriteLine(response.Reply);
    }
}