using System.Text;
public sealed class FileLogger : ILogger
{
    public FileLoggerConfiguration _getCurrentConfig { get; set; }
    internal StringBuilder StringBuilder { get; set; } = new StringBuilder();

    public FileLogger(
        FileLoggerConfiguration config) =>
        _getCurrentConfig = config;

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

    public bool IsEnabled(LogLevel logLevel) =>
        !string.IsNullOrEmpty(_getCurrentConfig.Path);

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        StringBuilder.AppendLine($"[{eventId.Id,2}: {logLevel,-12}]");
        StringBuilder.Append($"{formatter(state, exception)}");
        StringBuilder.AppendLine();
    }
}