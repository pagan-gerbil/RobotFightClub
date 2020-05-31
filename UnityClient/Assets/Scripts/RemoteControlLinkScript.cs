using UnityEngine;
using RemoteControlGrpcService;
using Google.Protobuf.WellKnownTypes;
using System.Threading;
using Grpc.Core;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class RemoteControlLinkScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var channel = new Channel("https://localhost:5001", ChannelCredentials.Insecure);

        var controller = new RemoteController.RemoteControllerClient(channel);
        var cancellationToken = new CancellationToken();

        var pong = controller.Ping(new Empty());
                
        var streamingCall = controller.GetInstructions(new Empty(), cancellationToken: cancellationToken);
        ProcessStream(streamingCall, cancellationToken).GetAwaiter().GetResult();
    }

    private static async Task ProcessStream(AsyncServerStreamingCall<CommandReply> streamingCall, CancellationToken cancellationToken)
    {
        try
        {
            //await foreach (var command in streamingCall.ResponseStream .ReadAllAsync())
            //{
            //    await ProcessCommand(command);
            //}
        }
        catch (Exception e)
        {

        }
    }

    private static async Task ProcessCommand(CommandReply command)
    {
        await Task.CompletedTask;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
//public static class Extensions
//{
//    public static IAsyncEnumerable<T> ReadAllAsync<T>(this IAsyncStreamReader<T> streamReader, CancellationToken cancellationToken = default)
//    {
//        if (streamReader == null)
//        {
//            throw new System.ArgumentNullException(nameof(streamReader));
//        }

//        return ReadAllAsyncCore(streamReader, cancellationToken);
//    }

//    private static async IAsyncEnumerable<T> ReadAllAsyncCore<T>(IAsyncStreamReader<T> streamReader, [EnumeratorCancellation] CancellationToken cancellationToken)
//    {
//        while (await streamReader.MoveNext(cancellationToken).ConfigureAwait(false))
//        {
//            yield return streamReader.Current;
//        }
//    }
//}
