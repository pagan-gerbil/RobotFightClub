using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace RemoteControlGrpcService.Services
{
    public class RemoteControlService : RemoteController.RemoteControllerBase
    {
        private static ConcurrentDictionary<Guid, IServerStreamWriter<CommandReply>> _clients = new ConcurrentDictionary<Guid, IServerStreamWriter<CommandReply>>();

        public override async Task GetInstructions(Empty _, IServerStreamWriter<CommandReply> responseStream, ServerCallContext context)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(id);
            _clients.TryAdd(id, responseStream);

            while (!context.CancellationToken.IsCancellationRequested)
            {
                // do nothing...
            }

            _clients.TryRemove(id, out var _);
        }

        public async Task SendCommand(Guid id, int distance, int direction)
        {
            await _clients[id].WriteAsync(new CommandReply { Direction = direction, Distance = distance });
        }
    }
}
