using Demo;
using Grpc.Core;
using Splat;

namespace DemoService.Services;

public class DemoService : MiniDemo.MiniDemoBase, IEnableLogger
{
    public DemoService()
    {
        this.Log().Info("Creating service instance ");
    }

    public override Task<SumResultDto> Sum(SumRequestDto request, ServerCallContext context) =>
        Task.FromResult(new SumResultDto() { Result = request.First + request.Second });

    public override Task<SumResultDto> SumArray(
        SumArrayRequestDto request,
        ServerCallContext context
    ) => Task.FromResult(new SumResultDto() { Result = request.Elements.Sum() });

    public override async Task<SumResultDto> SumStream(
        IAsyncStreamReader<AccumulatedElementDto> requestStream,
        ServerCallContext context
    )
    {
        int acc = 0;

        while (await requestStream.MoveNext(context.CancellationToken))
        {
            var dto = requestStream.Current;
            acc += dto.Item;
        }

        return new() { Result = acc };
    }

    public override async Task SumArrayDetailStream(
        SumArrayRequestDto request,
        IServerStreamWriter<SumResultDto> responseStream,
        ServerCallContext context
    )
    {
        int acc = 0;

        foreach (var item in request.Elements)
        {
            acc += item;
            await responseStream.WriteAsync(new SumResultDto() { Result = acc });
        }
    }

    public override async Task Accumulate(
        IAsyncStreamReader<AccumulatedElementDto> requestStream,
        IServerStreamWriter<SumResultDto> responseStream,
        ServerCallContext context
    )
    {
        int acc = 0;

        while (await requestStream.MoveNext(context.CancellationToken))
        {
            var dto = requestStream.Current;
            acc += dto.Item;
            await responseStream.WriteAsync(new SumResultDto() { Result = acc });
        }
    }
}
