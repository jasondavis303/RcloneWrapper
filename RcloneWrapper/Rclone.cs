using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace RcloneWrapper
{
    public class Rclone
    {
        public string RcloneExe { get; set; } = "rclone";
        private readonly ILogger<Rclone> _logger;

        public Rclone()
        {
            _logger = new NullLogger<Rclone>();
        }

        public Rclone(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Rclone>();
        }

        private Process CreateProcess(string args)
        {
            var process = new Process();
            process.StartInfo.FileName = RcloneExe;
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            
            process.Start();

            return process;
        }

        private static async Task WaitForProcessAsync(Process proc, CancellationToken cancellationToken)
        {
            cancellationToken.Register(() =>
            {
                try
                {
                    proc.Kill();
                }
                catch (Exception ex)
                {
                    // TODO: put some logs 
                }
            }, false);
        }

        public record RcloneLogStatus(
            long Bytes,
            int Checks,
            float ElapsedTime,
            int Errors,
            bool FatalError,
            string LastError,
            int Renames,
            bool RetryError,
            float Speed,
            long TotalBytes,
            int TotalChecks,
            int TotalTransfers,
            float TransferTime,
            int Transfers)
        {
            
        }

        public record RcloneLog(string Level, string Msg, DateTime Time, RcloneLogStatus Stats)
        {
        }

        public async Task<int> RunAsync(
            RcloneOptionsBuilder commandLine,
            IProgress<RcloneLog> progress = null,
            CancellationToken cancellationToken = default)
        {

            commandLine.AddOption("-v");
            commandLine.AddOption("--use-json-log");
            commandLine.AddOption("--stats 1s");

            var args = commandLine.Build();
            _logger.LogDebug("Spawning rclone with {0}", args);
            
            using var proc = CreateProcess(args);
            var concurrentQueue = new ConcurrentQueue<string>();

            var task2 = Task.Run(() =>
            {
                while (!proc.StandardError.EndOfStream)
                {
                    _logger.LogTrace("Is cancellation requested? {0}", cancellationToken.IsCancellationRequested);
                    cancellationToken.ThrowIfCancellationRequested();

                    // For some reason rclone only outputs to standard errors when using -v --use-json-log
                    var line = proc.StandardError.ReadLine();
                    if (line is not null)
                    {
                        concurrentQueue.Enqueue(line);
                    }

                    _logger.LogTrace("Reached end of stream");
                }
            }, cancellationToken);

            var processTask =
                Task.Run(async () => { await proc.WaitForExitAsync(cancellationToken).ConfigureAwait(false); },
                    cancellationToken);


            var task3 = Task.Run(() =>
            {
                while (!(proc.HasExited && concurrentQueue.IsEmpty))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (!concurrentQueue.TryDequeue(out var newLog)) continue;

                    try
                    {
                        var parsedLog = JsonSerializer.Deserialize<RcloneLog>(newLog, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        progress?.Report(parsedLog);
                    }
                    catch (Exception ex)
                    {
                        // TODO: put some logs. 
                    }
                }
            }, cancellationToken);

            await Task.WhenAll(processTask, task2, task3).ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            if (proc.ExitCode != 0 && proc.ExitCode != 9)
            {
                var msg = proc.ExitCode switch
                {
                    1 => "Syntax or usage error",
                    2 => "Error not otherwise categorised",
                    3 => "Directory not found",
                    4 => "File not found",
                    5 => "Temporary error, retries might fix",
                    6 => "Less serious errors",
                    7 => "Fatal error",
                    8 => "Transfer exceeded - limit set by --max-transfer reached",
                    _ => "Unknown error"
                };

                throw new RcloneException(proc.ExitCode, msg, args);
            }

            return proc.ExitCode;
        }
    }
}