using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcShared;
using Spectre.Console;

namespace GrpcConsoleClient
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            AnsiConsole.MarkupLine("Let's sum [red]3[/] and [red]4[/]!");

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new MicroPoc.MicroPocClient(channel);

            var result = client.Sum(new SumRequest { First = 3, Second = 4 });

            AnsiConsole.MarkupLine("Result is [red]{0}[/]", result.Result);

            var token = new CancellationTokenSource();

            using var accumulate = client.Accumulate();

            Task.Run(async () =>
            {
                while (await accumulate.ResponseStream.MoveNext(token.Token))
                    AnsiConsole.MarkupLine("Accumulated [red]{0}[/]", accumulate.ResponseStream.Current.Result);
            });

            for (int i = 1; i < 10; i++)
            {
                await accumulate.RequestStream.WriteAsync(new AccumulatedElement { Element = i });
                await Task.Delay(1000);
            }

            await accumulate.RequestStream.CompleteAsync();

            var arReq = new SumArrayRequest();
            arReq.Elements.AddRange(new[] { 10, 25, 100 });
            var arResult = client.SumArray(arReq);
            AnsiConsole.MarkupLine("Array sum is [red]{0}[/]", arResult.Result);

            using var sumStream = client.SumStream();

            for (int i = 1; i < 10; i++)
            {
                await sumStream.RequestStream.WriteAsync(new AccumulatedElement { Element = i });
                await Task.Delay(100);
            }

            await sumStream.RequestStream.CompleteAsync();

            var res = await sumStream;
            AnsiConsole.MarkupLine("Streaming sum is [red]{0}[/]", arResult.Result);

            Console.ReadLine();
        }
    }
}