using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace RcloneWrapper;

class ProcessLogStreamConsumer
{
    public static Task Start(
        StreamReader stream,
        ChannelWriter<string> concurrentQueue,
        ILogger<ProcessLogStreamConsumer> logger,
        CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            while (!stream.EndOfStream)
            {
                logger.LogTrace("Is cancellation requested? {0}", cancellationToken.IsCancellationRequested);
                // For some reason rclone only outputs to standard errors when using -v --use-json-log
                var line = await stream.ReadLineAsync();
                if (line is not null)
                {
                    await concurrentQueue.WriteAsync(line, cancellationToken);
                    continue;
                }

                logger.LogTrace("Reached end of stream");
                break;
            }

            logger.LogInformation("AAAAAAAAAAAAAAAAa");
        }, cancellationToken);
    }
}