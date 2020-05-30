using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Core.Utils;
using Grpc.Net.Client;
using RemoteControlGrpcService;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteControlClientTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var controller = new RemoteController.RemoteControllerClient(channel);
            var streamingCall = controller.GetInstructions(new Empty(), cancellationToken: new CancellationToken());

            await GetStream(streamingCall);
        }

        private static async Task GetStream(AsyncServerStreamingCall<CommandReply> streamingCall)
        {
            try
            {
                await foreach (var command in streamingCall.ResponseStream.ReadAllAsync())
                {
                    await ProcessCommand(command);
                }
            }
            catch
            {
                Console.WriteLine("Waiting...");
                await Task.Delay(1000);
                await GetStream(streamingCall);
            }
        }

        private static Task ProcessCommand(CommandReply arg)
        {
            Console.WriteLine($"Command received, Direction: {arg.Direction}, Distance: {arg.Distance}");
            return Task.CompletedTask;
        }
    }
}
