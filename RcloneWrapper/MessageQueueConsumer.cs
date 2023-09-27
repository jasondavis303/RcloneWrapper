using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace RcloneWrapper;

class MessageQueueConsumer
{
    public static Task Start(
        ChannelReader<string> concurrentQueue,
        IProgress<RcloneLog> progress,
        ILogger<MessageQueueConsumer> logger,
        CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            try
            {
                await foreach (var log in concurrentQueue.ReadAllAsync(cancellationToken))
                {
                    try
                    {
                        var parsedLog = JsonSerializer.Deserialize<RcloneLog>(log,
                            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        progress?.Report(parsedLog);
                    }
                    catch (JsonException ex)
                    {
                        logger.LogWarning(ex, "Failed when trying to deserialize json: '{0}'", log);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Failed to report log");
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                logger.LogTrace("Task was cancelled.");
            }
        }, cancellationToken);
    }
}