using WorkerService.BackgroundServices;

namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsoleLogger();
                    //logging.AddFileLogger();
                })
                .ConfigureServices((context, services) =>
                {
                    //context.Configuration.GetSection("Logging:FileLogger").Get<FileLoggerConfiguration>();
                    //services.AddSingleton<ILogger, FileLogger>();
                    services.AddHostedService<AppTrackerBackgroundService>();
                    services.AddHostedService<FileWriterBackgroundService>();
                })
                .Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogDebug(0, "Does this line get hit?");
            logger.LogInformation(4, "Nothing to see here.");
            logger.LogWarning(5, "Warning... that was odd.");
            logger.LogError(7, "Oops, there was an error.");
            logger.LogCritical(5!, "== 120.");

            host.Run();
        }
    }
}