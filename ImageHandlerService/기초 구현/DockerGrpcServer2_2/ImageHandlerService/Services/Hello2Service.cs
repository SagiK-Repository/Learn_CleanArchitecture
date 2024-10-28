using DockerGrpcServer.Protos;
using Grpc.Core;

namespace DockerGrpcServer2_2.Services
{
    public class Hello2Service : Hello2.Hello2Base
    {
        public Hello2Service() { }

        public override async Task<Hello2Reply> Hello2(Hello2Request request, ServerCallContext context)
        {
            await Task.CompletedTask;
            return new Hello2Reply() { Reply = "Hello2 World!" };
        }
    }
}