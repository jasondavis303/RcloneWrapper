using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RcloneWrapper
{
    public class Rclone
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web);


        /// <summary>
        /// Use --quiet --progress --stats-one-line, without any -v for the best experience
        /// </summary>
        public event EventHandler<int> OnProgress;
       
        public string RcloneExe { get; set; } = "rclone";

        private Process CreateProcess(string args, bool redirectStandardOutput)
        {

            var psi = new ProcessStartInfo
            {
                FileName = RcloneExe,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                StandardErrorEncoding = Encoding.UTF8
            };

            if (redirectStandardOutput)
            {
                psi.RedirectStandardOutput = true;
                psi.StandardOutputEncoding = Encoding.UTF8;
            }

            return new Process { StartInfo = psi };
        }

        private static async Task WaitForProcessAsync(Process proc, CancellationToken cancellationToken)
        {
            cancellationToken.Register(() =>
            {
                try { proc.Kill(); }
                catch { }

            }, false);

            proc.Start();
            await proc.WaitForExitAsync(cancellationToken).ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();


            if (proc.ExitCode != 0 && proc.ExitCode != 9)
            {
                string msg = proc.ExitCode switch
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

                Exception innerException = null;
                try
                {
                    var innerMsg = proc.StandardError.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(innerMsg))
                        innerException = new Exception(innerMsg);
                }
                catch { }

                throw new RcloneException(proc.ExitCode, msg, innerException);
            }
        }

        public async Task<int> RunAsync(string args, IProgress<int> progress = null, CancellationToken cancellationToken = default)
        {
            using var proc = CreateProcess(args, true);

            var task1 = WaitForProcessAsync(proc, cancellationToken);


            //Logic here:  stats will write output to the console as fast as it wants, and will NOT wait
            //for EventHandler to finish. And... there is no end of line marker, so it just
            //keeps writing and makes the parsing more difficult.
            //And I can't figure out how to do a true 'fire and forget'.

            //So my bad solution: As fast as data comes in, possible, add new progresses to a ConcurrentQueue, and 
            //use another task to pull objects out and invoke the EventHandler

            //My better but not yet available solution: I asked the rclone dev team to put a trailing \0 char at the end
            //of the line

            //Until then, I'm doing a simple search for percent only

            var cq = new ConcurrentQueue<int>();

            var task2 = Task.Run(() =>
            {
                string data = null;

                int lastPercent = 0;

                Span<char> buffer = new char[1024];
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    int read = proc.StandardOutput.Read(buffer);
                    if (read < 1)
                        return;

                    data = buffer[..read].ToString();
                    var parts = data.Split(',');
                    foreach (string part in parts.Where(item => item.Trim().EndsWith('%')))
                        if (int.TryParse(part.Trim().Trim('%'), out int newPercent))
                            if (newPercent != lastPercent)
                            {
                                lastPercent = newPercent;
                                cq.Enqueue(newPercent);
                            }
                }
            }, cancellationToken);



            var task3 = Task.Run(() =>
            {
                while (!(proc.HasExited && cq.IsEmpty))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (cq.TryDequeue(out int newProgress))
                    {
                        try { OnProgress?.Invoke(this, newProgress); }
                        catch { }
                        try { progress?.Report(newProgress); }
                        catch { }
                    }
                }
            }, cancellationToken);

            await Task.WhenAll(task1, task2, task3).ConfigureAwait(false);

            return proc.ExitCode;
        }

        /// <summary>
        /// Designed to be run with args: --quiet --progress --stats-one-line, without any -v
        /// </summary>
        public Task<int> RunAsync(CommandLineBuilder builder, IProgress<int> progress = null, CancellationToken cancellationToken = default) =>
            RunAsync(builder.Build(), progress, cancellationToken);


        /// <summary>
        /// Runs a command and deserializes the json output into an object
        /// </summary>
        public async Task<T> GetJsonAsync<T>(string args, CancellationToken cancellationToken = default)
        {
            using var proc = CreateProcess(args, true);
            var task1 = WaitForProcessAsync(proc, cancellationToken);
            var task2 = JsonSerializer.DeserializeAsync<T>(proc.StandardOutput.BaseStream, _jsonSerializerOptions, cancellationToken: cancellationToken).AsTask();
            await Task.WhenAll(task1, task2).ConfigureAwait(false);
            return task2.Result;
        }

        /// <summary>
        /// Runs a command and deserializes the json output into an object
        /// </summary>
        public Task<T> GetJsonAsync<T>(CommandLineBuilder builder, CancellationToken cancellationToken = default) =>
            GetJsonAsync<T>(builder.Build(), cancellationToken);



    }
}
