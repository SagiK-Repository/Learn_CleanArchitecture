using Grpc.Core;
using Grpc.Net.Client;
using Server;

var data10MBText = File.ReadAllLines("./Files/5MB.txt");
string data = string.Join("", data10MBText);

for (int index = 0; index < 10; index++)
{
    // SSL 인증서 검증을 비활성화
    var httpClientHandler = new HttpClientHandler();
    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

    using var channel = GrpcChannel.ForAddress("http://server:8080", new GrpcChannelOptions { HttpClient = new HttpClient(httpClientHandler), MaxReceiveMessageSize = 50 * 1024 * 1024 /*50MB*/ });
    var client = new StreamService.StreamServiceClient(channel);
    using var call = client.StreamData(new StreamingRequest { Message = data });

    await Task.Delay(1500);

    try
    {
        while (await call.ResponseStream.MoveNext())
        {
            //Console.WriteLine(call.ResponseStream.Current.Response);
            Console.WriteLine("Receive");
        }
        Console.WriteLine("Receive Complete");
    }
    catch (RpcException ex)
    {
        Console.WriteLine($"Error: {ex.Status}");
    }

}

Console.ReadLine();