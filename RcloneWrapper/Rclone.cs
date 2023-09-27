using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace RcloneWrapper
{
    public class Rclone
    {
        public string RcloneExe { get; set; } = "rclone";
        private readonly ILogger<Rclone> _logger;
        private readonly ILoggerFactory _loggerFactory;


        private Rclone(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Rclone>();
            _loggerFactory = loggerFactory;
        }


        public static Rclone Create(ILoggerFactory loggerFactory, string executableFile = "/usr/bin/rclone")
        {
            return new Rclone(loggerFactory)
            {
                RcloneExe = executableFile,
            };
        }

        public static Rclone Create(string executableFile)
        {
            return new Rclone(new NullLoggerFactory())
            {
                RcloneExe = executableFile,
            };
        }

        private Process CreateProcess(string args, CancellationToken cancellationToken)
        {
            var process = new Process();
            process.StartInfo.FileName = RcloneExe;
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.StandardErrorEncoding = Encoding.UTF8;

            process.Start();
            RegisterProcessCancellation(process, cancellationToken);

            return process;
        }

        public async Task RunAsync(RcloneOptionsBuilder commandLine,
            IProgress<RcloneLog> progress = null,
            CancellationToken cancellationToken = default)
        {
            commandLine.AddOption("-v");
            commandLine.AddOption("--use-json-log");
            commandLine.AddOption("--stats 1s");

            var args = commandLine.Build();
            var proc = CreateProcess(args, cancellationToken);
            var cancellationTokenSource = new CancellationTokenSource();
            var messageChanel = Channel.CreateBounded<string>(new BoundedChannelOptions(100)
            {
                SingleReader = true,
                SingleWriter = true,
                FullMode = BoundedChannelFullMode.Wait
            });

            var processTask = Task.Run(async () =>
            {
                await proc.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
                cancellationTokenSource.Cancel();
                
                _logger.LogInformation("Process exited.");
            }, cancellationToken);

            var task2 = ProcessLogStreamConsumer.Start(
                proc.StandardError,
                messageChanel,
                _loggerFactory.CreateLogger<ProcessLogStreamConsumer>(),
                cancellationTokenSource.Token);

            var task3 = MessageQueueConsumer.Start(
                messageChanel,
                progress,
                _loggerFactory.CreateLogger<MessageQueueConsumer>(),
                cancellationTokenSource.Token);

            await Task.WhenAll(processTask, task2, task3).ConfigureAwait(false);
            CheckExitCode(proc);
        }

        private void RegisterProcessCancellation(Process process, CancellationToken cancellationToken)
        {
            cancellationToken.Register(() =>
            {
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                    // TODO: put some logs 
                }
            }, false);
        }

        private void CheckExitCode(Process process)
        {
            if (process.ExitCode is 0 or 9)
            {
                return;
            }

            var msg = process.ExitCode switch
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

            throw new RcloneException(process.ExitCode, msg, process.StartInfo.Arguments);
        }
    }
}