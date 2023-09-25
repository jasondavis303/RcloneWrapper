// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RcloneWrapper;


// This should act as an example of how to use the library. (and also a test)
async Task Test(ILoggerFactory logFactory, IConfiguration configuration)
{
    var localPath = configuration.GetValue<string>("localPath");
    var remotePath = configuration.GetValue<string>("remotePath");
    var logger = logFactory.CreateLogger<Program>();

    var fileId = Guid.NewGuid();
    
    var commandLine = RcloneOptionsBuilder.CopyTo(
        localPath,
        remotePath!.Replace("{$random}", fileId.ToString()));

    logger.LogInformation("Starting new rclone task");

    try
    {
        await Rclone
            .Create(logFactory) 
            .RunAsync(commandLine,
                new Progress<RcloneLog>((log) =>
                {
                    if (log.Stats is null)
                    {
                        return;
                    }
                    
                    switch (log.Level)
                    {
                        case "info":
                            var stats = log.Stats;
                            logger.LogInformation(
                                "Speed: {0}MB/s, Percentage: {1}%",
                                stats.Speed / (1024 * 1024),
                                ((float) stats.Bytes / stats.TotalBytes) * 100);
                            break;        
                    }
                }));
        
        logger.LogInformation("Finished job of uploading file.");
    }
    catch (RcloneException ex)
    {
        logger.LogError(ex, "Failed when trying to run rclone command {0}", ex.ProvidedArgs);
    }

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