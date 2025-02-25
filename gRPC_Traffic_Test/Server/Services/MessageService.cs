using Grpc.Core;

namespace Server.Services
{
    public class MessageService : StreamService.StreamServiceBase
    {
        public override async Task StreamData(StreamingRequest request, IServerStreamWriter<StreamingResponse> responseStream, ServerCallContext context)
        {
            var data10MBText = File.ReadAllLines("./Files/10MB.txt");
            string data = string.Join("", data10MBText);

            await responseStream.WriteAsync(new StreamingResponse { Response = data });
        }
    }
}
