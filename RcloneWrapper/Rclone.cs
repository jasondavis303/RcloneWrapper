using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RcloneWrapper
{
    public class Rclone
    {
        /// <summary>
        /// Use --quiet --progress --stats-one-line, without any -v for the best experience
        /// </summary>
        public event EventHandler<StatsProgress> OnProgress;

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
                //Send SIGINT
                //proc.WaitForExit(2000);
                //proc.Kill():

                proc.Kill();

            }, false);

            proc.Start();
            await proc.WaitForExitAsync(cancellationToken).ConfigureAwait(false);

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

        public async Task<int> RunAsync(string args, CancellationToken cancellationToken = default)
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

            var cq = new ConcurrentQueue<StatsProgress>();

            var task2 = Task.Run(() =>
            {
                string data = null;

                StatsProgress lastProgress = null;
                Span<char> buffer = new char[1024];
                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    int read = proc.StandardOutput.Read(buffer);
                    if (read < 1)
                        return;

                    data += buffer[..read].ToString();

                    //Error messages have \n before and after                    
                    var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string line = lines[i];
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            if (double.TryParse(line.Substring(0, line.IndexOf(' ')), out _))
                            {
                                while (line.Length > 0)
                                {
                                    // 0 B / 14.195 MiB, 0%, 0 B/s, ETA -

                                    int etaPos = line.IndexOf("ETA ");
                                    if (etaPos < 0)
                                        break;

                                    int lineLength = line.Length;
                                    int endPos = line.IndexOf(')', etaPos);
                                    if (endPos < 0)
                                        endPos = line.IndexOf('-', etaPos);
                                    if (endPos < 0)
                                        endPos = line.IndexOf('s', etaPos);
                                    if (endPos < 0)
                                        break;

                                    var raw = line[..(endPos + 1)];
                                    line = line[raw.Length..];
                                    var newProgress = new StatsProgress(raw);
                                    if (newProgress != lastProgress)
                                    {
                                        lastProgress = newProgress;
                                        cq.Enqueue(newProgress);
                                    }

                                }
                                lines[i] = line;
                            }
                        }
                    }

                    //Didn't find the end of the line, so cache what info we have so far
                    if(lines.Count > 0)
                        data = lines.Last();

                }
            }, cancellationToken);



            var task3 = Task.Run(() =>
            {
                while (!(proc.HasExited && cq.IsEmpty))
                {
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    if (cq.TryDequeue(out StatsProgress newProgress))
                        try { OnProgress.Invoke(this, newProgress); }
                        catch { }
                }
            }, cancellationToken);

            await Task.WhenAll(task1, task2, task3).ConfigureAwait(false);

            return proc.ExitCode;
        }

        /// <summary>
        /// Designed to be run with args: --quiet --progress --stats-one-line, without any -v
        /// </summary>
        public Task<int> RunAsync(CommandLineBuilder builder, CancellationToken cancellationToken = default) =>
            RunAsync(builder.Build(), cancellationToken);


        /// <summary>
        /// Runs a command and deserializes the json output into an object
        /// </summary>
        public async Task<T> GetJsonAsync<T>(string args, CancellationToken cancellationToken = default)
        {
            using var proc = CreateProcess(args, true);
            var task1 = WaitForProcessAsync(proc, cancellationToken);
            var task2 = JsonSerializer.DeserializeAsync<T>(proc.StandardOutput.BaseStream, cancellationToken: cancellationToken).AsTask();
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
