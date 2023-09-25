// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RcloneWrapper;


async Task Test(ILoggerFactory factory, IConfiguration configuration)
{
    var localPath = configuration.GetValue<string>("localPath");
    var remotePath = configuration.GetValue<string>("remotePath");
    var logger = factory.CreateLogger<Program>();


    var fileId = Guid.NewGuid();
    var commandLine = RcloneOptionsBuilder.CopyTo(
        localPath,
        remotePath!.Replace("{$random}", fileId.ToString()));

    logger.LogInformation("Starting new rclone task");

    try
    {
        await new Rclone(factory) { RcloneExe = "/usr/bin/rclone" }
            .RunAsync(commandLine,
                new Progress<Rclone.RcloneLog>((log) =>
                {
                    logger.LogInformation("received new log: {0} {1}, {2}", log.Level, log.Stats, log.Time);
                }));
    }
    catch (RcloneException ex)
    {
        logger.LogError(ex, "Failed when trying to run rclone command {0}", ex.ProvidedArgs);
    }


    return;
}

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter("Microsoft", LogLevel.Warning)
        .AddFilter("System", LogLevel.Warning)
        .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
        .AddConsole();
});

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Test(loggerFactory, configuration)
    .GetAwaiter()
    .GetResult();
;