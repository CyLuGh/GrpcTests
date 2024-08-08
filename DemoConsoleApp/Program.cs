// See https://aka.ms/new-console-template for more information
using Demo;
using Grpc.Net.Client;
using Spectre.Console;

AnsiConsole.MarkupLine("[bold][dodgerblue1].NET[/][/] client");

const string address = "http://localhost:5267";
AnsiConsole.MarkupLine($"Building client to [yellow]{address}[/]!");

var channel = GrpcChannel.ForAddress(address);
var client = new MiniDemo.MiniDemoClient(channel);

AnsiConsole.WriteLine();
Console.ReadLine();
AnsiConsole.MarkupLine("Let's test [yellow]unary call[/]");

AnsiConsole.MarkupLine("Let's sum [red]3[/] and [red]4[/]!");
var result = client.Sum(new SumRequestDto { First = 3, Second = 4 });
AnsiConsole.MarkupLine("Result is [red]{0}[/]", result.Result);

await Task.Delay(1000);

AnsiConsole.WriteLine();
Console.ReadLine();
AnsiConsole.MarkupLine("Let's test [yellow]unary call[/] with [yellow]repeated[/] elements");

SumArrayRequestDto sumArrayRequestDto = new();
sumArrayRequestDto.Elements.AddRange(Enumerable.Range(1, 10));

result = await client.SumArrayAsync(sumArrayRequestDto);
AnsiConsole.MarkupLine("Result is [red]{0}[/]", result.Result);

AnsiConsole.WriteLine();
Console.ReadLine();
AnsiConsole.MarkupLine("Let's test [yellow]client stream[/]");

var sumStream = client.SumStream();
for (int i = 1; i <= 10; i++)
{
    AnsiConsole.MarkupLine("Sending [green]{0}[/] to server", i);
    await Task.Delay(1);
    await sumStream.RequestStream.WriteAsync(new AccumulatedElementDto { Item = i });
}
await sumStream.RequestStream.CompleteAsync();
result = await sumStream.ResponseAsync;
AnsiConsole.MarkupLine("Result is [red]{0}[/]", result.Result);

AnsiConsole.WriteLine();
Console.ReadLine();
AnsiConsole.MarkupLine("Let's test [yellow]server stream[/]");

var detailStream = client.SumArrayDetailStream(sumArrayRequestDto);

while (await detailStream.ResponseStream.MoveNext(new CancellationToken()))
{
    AnsiConsole.MarkupLine("Result is [red]{0}[/]", detailStream.ResponseStream.Current.Result);
}

AnsiConsole.WriteLine();
Console.ReadLine();
AnsiConsole.MarkupLine("Let's test [yellow]bidirectional stream[/]");

var biDirStream = client.Accumulate();

await Task.WhenAll(
    Task.Run(async () =>
    {
        for (int i = 1; i <= 10; i++)
        {
            AnsiConsole.MarkupLine("Sending [green]{0}[/] to server", i);
            await Task.Delay(1);
            await biDirStream.RequestStream.WriteAsync(new AccumulatedElementDto { Item = i });
        }

        await biDirStream.RequestStream.CompleteAsync();
    }),
    Task.Run(async () =>
    {
        while (await biDirStream.ResponseStream.MoveNext(new CancellationToken()))
        {
            AnsiConsole.MarkupLine(
                "Current result is [red]{0}[/]",
                biDirStream.ResponseStream.Current.Result
            );
        }
    })
);

AnsiConsole.WriteLine();
Console.ReadLine();
