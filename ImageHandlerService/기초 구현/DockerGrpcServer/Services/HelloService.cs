using DockerGrpcServer.Protos;
using Grpc.Core;

namespace DockerGrpcServer.Services;

public class HelloService : Hello.HelloBase
{
    public HelloService() { }

    public override async Task<HelloReply> Hello(HelloRequest request, ServerCallContext context)
    {
        await Task.CompletedTask;
        return new HelloReply() { Reply = "Hello World!" };
    }
}