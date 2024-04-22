using Grpc.Net.Client;
using GrpcService;
using GrpcService.Protos;
using System;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var input = new HelloRequest { Name = "Tim" };

            //var chanel = GrpcChannel.ForAddress("https://localhost:7193");
            //var client = new Greeter.GreeterClient(chanel);

            //var reply = await client.SayHelloAsync(input);

            //Console.WriteLine(reply.Message);

            var chanel = GrpcChannel.ForAddress("https://localhost:7193");
            var customerClient = new Customer.CustomerClient(chanel);

            var clientRequested = new CustomerLookupModel { UserId = 1 };

            var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

            Console.WriteLine($"{customer.FirstName} {customer.LastName}");

            Console.ReadLine();
        }
    }
}