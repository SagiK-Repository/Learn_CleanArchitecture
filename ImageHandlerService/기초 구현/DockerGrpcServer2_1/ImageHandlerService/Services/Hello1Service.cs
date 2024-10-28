using DockerGrpcServer.Protos;
using Grpc.Core;

namespace DockerGrpcServer2_1.Services
{
    public class Hello1Service : Hello1.Hello1Base
    {
        public Hello1Service() { }

        public override async Task<Hello1Reply> Hello1(Hello1Request request, ServerCallContext context)
        {
            await Task.CompletedTask;
            return new Hello1Reply() { Reply = "Hello1 World!" };
        }
    }
}
