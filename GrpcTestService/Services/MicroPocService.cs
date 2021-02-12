using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcShared;
using Microsoft.Extensions.Logging;

namespace GrpcTestService.Services
{
    public class MicroPocService : MicroPoc.MicroPocBase
    {
        private readonly ILogger<MicroPocService> _logger;

        public MicroPocService(ILogger<MicroPocService> logger)
        {
            _logger = logger;
        }

        public override Task<SumReply> Sum(SumRequest request, ServerCallContext context)
            => Task.FromResult(new SumReply { Result = request.First + request.Second });

        public override Task<SumReply> SumArray(SumArrayRequest request, ServerCallContext context)
            => Task.FromResult(new SumReply { Result = request.Elements.Sum(x => x) });

        public override async Task Accumulate(IAsyncStreamReader<AccumulatedElement> requestStream, IServerStreamWriter<SumReply> responseStream, ServerCallContext context)
        {
            int acc = 0;

            while (await requestStream.MoveNext(context.CancellationToken))
            {
                var accElement = requestStream.Current;
                acc += accElement.Element;

                if (!context.CancellationToken.IsCancellationRequested)
                    await responseStream.WriteAsync(new SumReply { Result = acc });
            }
        }

        public override async Task<SumReply> SumStream(IAsyncStreamReader<AccumulatedElement> requestStream, ServerCallContext context)
        {
            int acc = 0;

            while (await requestStream.MoveNext(context.CancellationToken))
            {
                var accElement = requestStream.Current;
                acc += accElement.Element;
            }

            return new SumReply { Result = acc };
        }
    }
}