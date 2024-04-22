using Grpc.Core;
using GrpcService.Protos;

namespace GrpcService.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context )
        {
            CustomerModel output = new();

            if (request.UserId == 1)
            {
                output.FirstName = "Jamie";
                output.LastName = "Smith";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Jamie2";
                output.LastName = "Smith2";
            }
            else
            {
                output.FirstName = "Else";
                output.LastName = "Elsese";
            }

            return Task.FromResult(output);
        }
    }
}
