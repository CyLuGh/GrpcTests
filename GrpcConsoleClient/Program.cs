using System;
using Grpc.Net.Client;
using GrpcShared;
using Spectre.Console;

namespace GrpcConsoleClient
{
    class Program
    {
        static void Main( string[] args )
        {
            AnsiConsole.MarkupLine( "Let's sum [red]3[/] and [red]4[/]!" );

            var channel = GrpcChannel.ForAddress( "https://localhost:5001" );
            var client = new MicroPoc.MicroPocClient( channel );

            var result = client.Sum( new SumRequest { First = 3 , Second = 4 } );

            AnsiConsole.MarkupLine( "Result is [red]{0}[/]" , result.Result );

            Console.ReadLine();
        }
    }
}
