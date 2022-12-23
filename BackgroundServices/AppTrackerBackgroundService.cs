using System.Diagnostics;

namespace WorkerService.BackgroundServices
{
    public class AppTrackerBackgroundService : BackgroundService
    {
        private readonly ILogger<AppTrackerBackgroundService> _logger;

        public AppTrackerBackgroundService(ILogger<AppTrackerBackgroundService> logger) => _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Process p = null;
                do
                {
                    Process[] pArr = Process.GetProcessesByName("notepad");
                    p = pArr.SingleOrDefault();
                    await Task.Delay(1000, stoppingToken);
                }
                while (p is null);
                _logger.LogInformation("Notepad started at: {time}", p.StartTime);
                var sh = p.SafeHandle;

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Start loop");
                    p.WaitForExit();

                    _logger.LogInformation("Notepad closed at: {time}", p.ExitTime);
                    _logger.LogInformation("Notepad total time: {time}", p.TotalProcessorTime);
                    break;
                }
            }
        }
    }
}