namespace WorkerService.BackgroundServices
{
    public class FileWriterBackgroundService : BackgroundService
    {
        private readonly ILogger<FileWriterBackgroundService> _logger;
        private readonly FileLoggerConfiguration _fileLogger;

        public FileWriterBackgroundService(
            HostBuilderContext context,
            ILogger<FileWriterBackgroundService> logger)
        {
            _fileLogger = context.Configuration.GetSection("Logging:FileLogger").Get<FileLoggerConfiguration>();
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var path = _fileLogger.Path;//GetSection("Logging:FileLogger").GetValue<string>("Path");
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000, stoppingToken);
                //File.AppendAllText(path, _fileLogger.StringBuilder.ToString());
            }
        }
    }
}