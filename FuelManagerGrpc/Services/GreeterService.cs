using FuelManagerGrpc;
using Grpc.Core;

namespace FuelManagerGrpc.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<FuelReply> FuelCalculator(FuelRequest request, ServerCallContext context)
        {
            double pct = request.Etanol / request.Gasolina;
            string message = pct < 0.7 ? "Etanol" : "Gasolina";

            return Task.FromResult(new FuelReply
            {
                Pct = pct,
                Message = message
            });
        }
    }
}
