using System.Threading.Tasks;
using Grpc.Core;
using GrpcShared;
using Microsoft.Extensions.Logging;

namespace GrpcTestService.Services
{
    public class MicroPocService : MicroPoc.MicroPocBase
    {
        //private readonly ILogger<MicroPocService> _logger;
        //public MicroPocService( ILogger<MicroPocService> logger )
        //{
        //    _logger = logger;
        //}

        public override Task<SumReply> Sum( SumRequest request , ServerCallContext context )
            => Task.FromResult( new SumReply() { Result = request.First + request.Second } );
    }
}
