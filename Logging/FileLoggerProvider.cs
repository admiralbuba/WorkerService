//using Microsoft.Extensions.Options;
//using System.Collections.Concurrent;
//using System.Runtime.Versioning;

//[UnsupportedOSPlatform("browser")]
//[ProviderAlias("FileLogger")]
//public sealed class FileLoggerProvider : ILoggerProvider
//{
//    private readonly IDisposable? _onChangeToken;
//    private FileLoggerConfiguration _currentConfig;
//    private readonly ConcurrentDictionary<string, FileLogger> _loggers =
//        new(StringComparer.OrdinalIgnoreCase);

//    public FileLoggerProvider(
//        IOptionsMonitor<FileLoggerConfiguration> config)
//    {
//        _currentConfig = config.CurrentValue;
//        _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
//    }

//    public ILogger CreateLogger(string categoryName) =>
//        _loggers.GetOrAdd("FileLogger", name => new FileLogger(GetCurrentConfig));

//    private FileLoggerConfiguration GetCurrentConfig() => _currentConfig;

//    public void Dispose()
//    {
//        _loggers.Clear();
//        _onChangeToken?.Dispose();
//    }
//}