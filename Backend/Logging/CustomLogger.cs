namespace Backend.Logging;

internal class CustomLogger : ILogger
{
    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) =>
        Console.WriteLine($"[{logLevel}] {formatter(state, exception)}");

    IDisposable? ILogger.BeginScope<TState>(TState state) => default;    
}
